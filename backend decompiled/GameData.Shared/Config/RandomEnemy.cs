using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class RandomEnemy : ConfigData<RandomEnemyItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 病乞丐
		/// </summary>
		public const short SickBeggar = 0;

		/// <summary>
		/// 恶丐
		/// </summary>
		public const short EvilBeggar = 1;

		/// <summary>
		/// 托钵恶丐
		/// </summary>
		public const short BowlBeggar = 2;

		/// <summary>
		/// 弄蛇恶丐
		/// </summary>
		public const short SnakeBeggar = 3;

		/// <summary>
		/// 恶丐头子
		/// </summary>
		public const short BossBeggar = 4;

		/// <summary>
		/// 小毛贼
		/// </summary>
		public const short PettyThief = 5;

		/// <summary>
		/// 惯盗
		/// </summary>
		public const short CommonThief = 6;

		/// <summary>
		/// 采花贼
		/// </summary>
		public const short RapistThief = 7;

		/// <summary>
		/// 女飞贼
		/// </summary>
		public const short FemaleThief = 8;

		/// <summary>
		/// 大盗
		/// </summary>
		public const short BigThief = 9;

		/// <summary>
		/// 地痞
		/// </summary>
		public const short LocalThug = 10;

		/// <summary>
		/// 山贼
		/// </summary>
		public const short MountainBandit = 11;

		/// <summary>
		/// 恶霸
		/// </summary>
		public const short EvilBandit = 12;

		/// <summary>
		/// 悍匪
		/// </summary>
		public const short FierceBandit = 13;

		/// <summary>
		/// 山大王
		/// </summary>
		public const short BossBandit = 14;

		/// <summary>
		/// 少林弃徒
		/// </summary>
		public const short ShaolinTraitor = 15;

		/// <summary>
		/// 峨眉弃徒
		/// </summary>
		public const short EmeiTraitor = 16;

		/// <summary>
		/// 百花弃徒
		/// </summary>
		public const short BaihuaTraitor = 17;

		/// <summary>
		/// 武当弃徒
		/// </summary>
		public const short WudangTraitor = 18;

		/// <summary>
		/// 元山弃徒
		/// </summary>
		public const short YuanshanTraitor = 19;

		/// <summary>
		/// 狮相弃徒
		/// </summary>
		public const short ShixiangTraitor = 20;

		/// <summary>
		/// 然山弃徒
		/// </summary>
		public const short RanshanTraitor = 21;

		/// <summary>
		/// 璇女弃徒
		/// </summary>
		public const short XuannvTraitor = 22;

		/// <summary>
		/// 铸剑弃徒
		/// </summary>
		public const short ZhujianTraitor = 23;

		/// <summary>
		/// 空桑弃徒
		/// </summary>
		public const short KongsangTraitor = 24;

		/// <summary>
		/// 金刚弃徒
		/// </summary>
		public const short JingangTraitor = 25;

		/// <summary>
		/// 五仙弃徒
		/// </summary>
		public const short WuxianTraitor = 26;

		/// <summary>
		/// 界青弃徒
		/// </summary>
		public const short JieqingTraitor = 27;

		/// <summary>
		/// 伏龙弃徒
		/// </summary>
		public const short FulongTraitor = 28;

		/// <summary>
		/// 血犼弃徒
		/// </summary>
		public const short XuehouTraitor = 29;

		/// <summary>
		/// 亡命徒
		/// </summary>
		public const short Desperado = 30;

		/// <summary>
		/// 花和尚
		/// </summary>
		public const short RapistMonk = 31;

		/// <summary>
		/// 妖道
		/// </summary>
		public const short DevilishTaoist = 32;

		/// <summary>
		/// 吃人鬼
		/// </summary>
		public const short ManEatingGhost = 33;

		/// <summary>
		/// 元凶
		/// </summary>
		public const short CrimeCulprit = 34;

		/// <summary>
		/// 狐媚子
		/// </summary>
		public const short FoxyGirl = 35;

		/// <summary>
		/// 妖妇
		/// </summary>
		public const short DevilishWoman = 36;

		/// <summary>
		/// 毒寡妇
		/// </summary>
		public const short PoisonousWidow = 37;

		/// <summary>
		/// 合欢仙
		/// </summary>
		public const short HappyReunionFairy = 38;

		/// <summary>
		/// 玉面娘娘
		/// </summary>
		public const short FairFaceQueen = 39;

		/// <summary>
		/// 鬼仆
		/// </summary>
		public const short GhostServant = 40;

		/// <summary>
		/// 炼尸人
		/// </summary>
		public const short RefineCorpsePerson = 41;

		/// <summary>
		/// 尸爪人
		/// </summary>
		public const short CorpseClawPerson = 42;

		/// <summary>
		/// 鬼医
		/// </summary>
		public const short GhostDoctor = 43;

		/// <summary>
		/// 活死人
		/// </summary>
		public const short LivingDead = 44;

		/// <summary>
		/// 妖乐师
		/// </summary>
		public const short DevilishMusician = 45;

		/// <summary>
		/// 阴阳生
		/// </summary>
		public const short MystifyingChessPlayer = 46;

		/// <summary>
		/// 血书客
		/// </summary>
		public const short BloodCalligrapher = 47;

		/// <summary>
		/// 坏色翁
		/// </summary>
		public const short BadMonkOldMan = 48;

		/// <summary>
		/// 无明子
		/// </summary>
		public const short IgnorantWiseMan = 49;

		/// <summary>
		/// 金刚教众
		/// </summary>
		public const short HereticMetal = 50;

		/// <summary>
		/// 紫霞教众
		/// </summary>
		public const short HereticWood = 51;

		/// <summary>
		/// 玄阴教众
		/// </summary>
		public const short HereticWater = 52;

		/// <summary>
		/// 纯阳教众
		/// </summary>
		public const short HereticFire = 53;

		/// <summary>
		/// 归元教众
		/// </summary>
		public const short HereticEarth = 54;

		/// <summary>
		/// 异疆怪人
		/// </summary>
		public const short ForeignWeirdo = 55;

		/// <summary>
		/// 毒手客
		/// </summary>
		public const short PoisonHand = 56;

		/// <summary>
		/// 邪士
		/// </summary>
		public const short EvilBachelor = 57;

		/// <summary>
		/// 童身老怪
		/// </summary>
		public const short PureOldBeing = 58;

		/// <summary>
		/// 邪道共主
		/// </summary>
		public const short EvilWayConjointBoss = 59;

		/// <summary>
		/// 丧心侠士
		/// </summary>
		public const short LoseHeartChivalrousMan = 60;

		/// <summary>
		/// 恶煞
		/// </summary>
		public const short EvilSpirit = 61;

		/// <summary>
		/// 失魂人
		/// </summary>
		public const short LoseSoulPerson = 62;

		/// <summary>
		/// 血披战鬼
		/// </summary>
		public const short BloodyWarGhost = 63;

		/// <summary>
		/// 炼心师
		/// </summary>
		public const short RefineHeartMaster = 64;

		/// <summary>
		/// 疯魔
		/// </summary>
		public const short MadDemon = 65;

		/// <summary>
		/// 火池客
		/// </summary>
		public const short FirePondMale = 66;

		/// <summary>
		/// 寒池女
		/// </summary>
		public const short ColdPondFemale = 67;

		/// <summary>
		/// 阿鼻众
		/// </summary>
		public const short AviciFolk = 68;

		/// <summary>
		/// 摩罗尊主
		/// </summary>
		public const short SoumoulouLord = 69;

		/// <summary>
		/// 绝境客
		/// </summary>
		public const short DesperatePerson = 70;

		/// <summary>
		/// 非人众
		/// </summary>
		public const short InHumanFolk = 71;

		/// <summary>
		/// 无相老僧
		/// </summary>
		public const short NoAppearanceOldMonk = 72;

		/// <summary>
		/// 无名老道
		/// </summary>
		public const short NoNameOldTaoist = 73;

		/// <summary>
		/// 弃世老人
		/// </summary>
		public const short WorldWearyOldPerson = 74;

		/// <summary>
		/// 相枢闻恶声
		/// </summary>
		public const short XiangshuMinion0 = 75;

		/// <summary>
		/// 相枢祛善
		/// </summary>
		public const short XiangshuMinion1 = 76;

		/// <summary>
		/// 相枢唤目
		/// </summary>
		public const short XiangshuMinion2 = 77;

		/// <summary>
		/// 相枢妖心示显
		/// </summary>
		public const short XiangshuMinion3 = 78;

		/// <summary>
		/// 相枢百邪
		/// </summary>
		public const short XiangshuMinion4 = 79;

		/// <summary>
		/// 相枢堕心九部众
		/// </summary>
		public const short XiangshuMinion5 = 80;

		/// <summary>
		/// 相枢众相生
		/// </summary>
		public const short XiangshuMinion6 = 81;

		/// <summary>
		/// 相枢神断护法
		/// </summary>
		public const short XiangshuMinion7 = 82;

		/// <summary>
		/// 相枢玄狱九老
		/// </summary>
		public const short XiangshuMinion8 = 83;

		/// <summary>
		/// 任侠义士
		/// </summary>
		public const short Righteous0 = 84;

		/// <summary>
		/// 任侠巡街武人
		/// </summary>
		public const short Righteous1 = 85;

		/// <summary>
		/// 任侠年轻侠士
		/// </summary>
		public const short Righteous2 = 86;

		/// <summary>
		/// 任侠镖师
		/// </summary>
		public const short Righteous3 = 87;

		/// <summary>
		/// 任侠成名镖师
		/// </summary>
		public const short Righteous4 = 88;

		/// <summary>
		/// 任侠江湖奇人
		/// </summary>
		public const short Righteous5 = 89;

		/// <summary>
		/// 任侠无名侠客
		/// </summary>
		public const short Righteous6 = 90;

		/// <summary>
		/// 任侠成名英豪
		/// </summary>
		public const short Righteous7 = 91;

		/// <summary>
		/// 任侠隐居名宿
		/// </summary>
		public const short Righteous8 = 92;

		/// <summary>
		/// 隐退的少林前辈
		/// </summary>
		public const short ShaolinRetiredSenior = 93;

		/// <summary>
		/// 少林长老
		/// </summary>
		public const short ShaolinMember6 = 94;

		/// <summary>
		/// 少林十八罗汉
		/// </summary>
		public const short ShaolinMember5 = 95;

		/// <summary>
		/// 少林持戒僧
		/// </summary>
		public const short ShaolinMember4 = 96;

		/// <summary>
		/// 少林菩提院弟子
		/// </summary>
		public const short ShaolinMember3 = 97;

		/// <summary>
		/// 少林般若堂弟子
		/// </summary>
		public const short ShaolinMember2 = 98;

		/// <summary>
		/// 少林罗汉堂弟子
		/// </summary>
		public const short ShaolinMember1 = 99;

		/// <summary>
		/// 少林比丘
		/// </summary>
		public const short ShaolinMember0 = 100;

		/// <summary>
		/// 隐退的峨眉前辈
		/// </summary>
		public const short EmeiRetiredSenior = 101;

		/// <summary>
		/// 峨眉掌门弟子
		/// </summary>
		public const short EmeiMember6 = 102;

		/// <summary>
		/// 峨眉真传弟子
		/// </summary>
		public const short EmeiMember5 = 103;

		/// <summary>
		/// 峨眉八门嫡传
		/// </summary>
		public const short EmeiMember4 = 104;

		/// <summary>
		/// 峨眉八门正徒
		/// </summary>
		public const short EmeiMember3 = 105;

		/// <summary>
		/// 峨眉杂门弟子
		/// </summary>
		public const short EmeiMember2 = 106;

		/// <summary>
		/// 峨眉内门散徒
		/// </summary>
		public const short EmeiMember1 = 107;

		/// <summary>
		/// 峨眉外门散徒
		/// </summary>
		public const short EmeiMember0 = 108;

		/// <summary>
		/// 隐退的百花前辈
		/// </summary>
		public const short BaihuaRetiredSenior = 109;

		/// <summary>
		/// 百花鹿裳使
		/// </summary>
		public const short BaihuaMember6 = 110;

		/// <summary>
		/// 百花妙手
		/// </summary>
		public const short BaihuaMember5 = 111;

		/// <summary>
		/// 百花朱匣弟子
		/// </summary>
		public const short BaihuaMember4 = 112;

		/// <summary>
		/// 百花玉匣弟子
		/// </summary>
		public const short BaihuaMember3 = 113;

		/// <summary>
		/// 百花金匣弟子
		/// </summary>
		public const short BaihuaMember2 = 114;

		/// <summary>
		/// 百花花匣弟子
		/// </summary>
		public const short BaihuaMember1 = 115;

		/// <summary>
		/// 百花牧鹿童
		/// </summary>
		public const short BaihuaMember0 = 116;

		/// <summary>
		/// 隐退的武当前辈
		/// </summary>
		public const short WudangRetiredSenior = 117;

		/// <summary>
		/// 武当掌门弟子
		/// </summary>
		public const short WudangMember6 = 118;

		/// <summary>
		/// 武当真传弟子
		/// </summary>
		public const short WudangMember5 = 119;

		/// <summary>
		/// 武当真武殿弟子
		/// </summary>
		public const short WudangMember4 = 120;

		/// <summary>
		/// 武当紫霄宫弟子
		/// </summary>
		public const short WudangMember3 = 121;

		/// <summary>
		/// 武当太和宫弟子
		/// </summary>
		public const short WudangMember2 = 122;

		/// <summary>
		/// 武当接引道人
		/// </summary>
		public const short WudangMember1 = 123;

		/// <summary>
		/// 武当外门弟子
		/// </summary>
		public const short WudangMember0 = 124;

		/// <summary>
		/// 隐退的元山前辈
		/// </summary>
		public const short YuanshanRetiredSenior = 125;

		/// <summary>
		/// 元山伏魔众
		/// </summary>
		public const short YuanshanMember6 = 126;

		/// <summary>
		/// 元山传法众
		/// </summary>
		public const short YuanshanMember5 = 127;

		/// <summary>
		/// 元山苦行众
		/// </summary>
		public const short YuanshanMember4 = 128;

		/// <summary>
		/// 元山护法弟子
		/// </summary>
		public const short YuanshanMember3 = 129;

		/// <summary>
		/// 元山石牢弟子
		/// </summary>
		public const short YuanshanMember2 = 130;

		/// <summary>
		/// 元山入门弟子
		/// </summary>
		public const short YuanshanMember1 = 131;

		/// <summary>
		/// 元山受戒仆
		/// </summary>
		public const short YuanshanMember0 = 132;

		/// <summary>
		/// 隐退的狮相前辈
		/// </summary>
		public const short ShixiangRetiredSenior = 133;

		/// <summary>
		/// 狮相狂狮强手
		/// </summary>
		public const short ShixiangMember6 = 134;

		/// <summary>
		/// 狮相锦狮强手
		/// </summary>
		public const short ShixiangMember5 = 135;

		/// <summary>
		/// 狮相睡狮强手
		/// </summary>
		public const short ShixiangMember4 = 136;

		/// <summary>
		/// 狮相狂狮堂弟子
		/// </summary>
		public const short ShixiangMember3 = 137;

		/// <summary>
		/// 狮相锦狮堂弟子
		/// </summary>
		public const short ShixiangMember2 = 138;

		/// <summary>
		/// 狮相睡狮堂弟子
		/// </summary>
		public const short ShixiangMember1 = 139;

		/// <summary>
		/// 狮相狮崽子
		/// </summary>
		public const short ShixiangMember0 = 140;

		/// <summary>
		/// 隐退的然山前辈
		/// </summary>
		public const short RanshanRetiredSenior = 141;

		/// <summary>
		/// 然山青琅护法
		/// </summary>
		public const short RanshanMember6 = 142;

		/// <summary>
		/// 然山三宗传人
		/// </summary>
		public const short RanshanMember5 = 143;

		/// <summary>
		/// 然山玉符宗游士
		/// </summary>
		public const short RanshanMember4 = 144;

		/// <summary>
		/// 然山神剑宗游士
		/// </summary>
		public const short RanshanMember3 = 145;

		/// <summary>
		/// 然山阴阳宗游士
		/// </summary>
		public const short RanshanMember2 = 146;

		/// <summary>
		/// 然山剑奴
		/// </summary>
		public const short RanshanMember1 = 147;

		/// <summary>
		/// 然山散人
		/// </summary>
		public const short RanshanMember0 = 148;

		/// <summary>
		/// 隐退的璇女前辈
		/// </summary>
		public const short XuannvRetiredSenior = 149;

		/// <summary>
		/// 璇女羽衣使
		/// </summary>
		public const short XuannvMember6 = 150;

		/// <summary>
		/// 璇女霓裳使
		/// </summary>
		public const short XuannvMember5 = 151;

		/// <summary>
		/// 璇女守玉人
		/// </summary>
		public const short XuannvMember4 = 152;

		/// <summary>
		/// 璇女天音阁弟子
		/// </summary>
		public const short XuannvMember3 = 153;

		/// <summary>
		/// 璇女内门弟子
		/// </summary>
		public const short XuannvMember2 = 154;

		/// <summary>
		/// 璇女外门弟子
		/// </summary>
		public const short XuannvMember1 = 155;

		/// <summary>
		/// 璇女婢子
		/// </summary>
		public const short XuannvMember0 = 156;

		/// <summary>
		/// 隐退的铸剑前辈
		/// </summary>
		public const short ZhujianRetiredSenior = 157;

		/// <summary>
		/// 铸剑七星匠
		/// </summary>
		public const short ZhujianMember6 = 158;

		/// <summary>
		/// 铸剑玄鸿匠
		/// </summary>
		public const short ZhujianMember5 = 159;

		/// <summary>
		/// 铸剑镇山匠
		/// </summary>
		public const short ZhujianMember4 = 160;

		/// <summary>
		/// 铸剑百辟匠
		/// </summary>
		public const short ZhujianMember3 = 161;

		/// <summary>
		/// 铸剑青君匠
		/// </summary>
		public const short ZhujianMember2 = 162;

		/// <summary>
		/// 铸剑学徒
		/// </summary>
		public const short ZhujianMember1 = 163;

		/// <summary>
		/// 铸剑火工
		/// </summary>
		public const short ZhujianMember0 = 164;

		/// <summary>
		/// 隐退的空桑前辈
		/// </summary>
		public const short KongsangRetiredSenior = 165;

		/// <summary>
		/// 空桑长老
		/// </summary>
		public const short KongsangMember6 = 166;

		/// <summary>
		/// 空桑蛟士
		/// </summary>
		public const short KongsangMember5 = 167;

		/// <summary>
		/// 空桑持鼎首徒
		/// </summary>
		public const short KongsangMember4 = 168;

		/// <summary>
		/// 空桑玄炉院弟子
		/// </summary>
		public const short KongsangMember3 = 169;

		/// <summary>
		/// 空桑蛟王院弟子
		/// </summary>
		public const short KongsangMember2 = 170;

		/// <summary>
		/// 空桑朱砭院弟子
		/// </summary>
		public const short KongsangMember1 = 171;

		/// <summary>
		/// 空桑药童
		/// </summary>
		public const short KongsangMember0 = 172;

		/// <summary>
		/// 隐退的金刚前辈
		/// </summary>
		public const short JingangRetiredSenior = 173;

		/// <summary>
		/// 金刚上尊
		/// </summary>
		public const short JingangMember6 = 174;

		/// <summary>
		/// 金刚护法尊者
		/// </summary>
		public const short JingangMember5 = 175;

		/// <summary>
		/// 金刚金刚力士
		/// </summary>
		public const short JingangMember4 = 176;

		/// <summary>
		/// 金刚不动殿弟子
		/// </summary>
		public const short JingangMember3 = 177;

		/// <summary>
		/// 金刚金刚院弟子
		/// </summary>
		public const short JingangMember2 = 178;

		/// <summary>
		/// 金刚罗刹院弟子
		/// </summary>
		public const short JingangMember1 = 179;

		/// <summary>
		/// 金刚净火童
		/// </summary>
		public const short JingangMember0 = 180;

		/// <summary>
		/// 隐退的五仙前辈
		/// </summary>
		public const short WuxianRetiredSenior = 181;

		/// <summary>
		/// 五仙巫相
		/// </summary>
		public const short WuxianMember6 = 182;

		/// <summary>
		/// 五仙族长
		/// </summary>
		public const short WuxianMember5 = 183;

		/// <summary>
		/// 五仙仙娘使
		/// </summary>
		public const short WuxianMember4 = 184;

		/// <summary>
		/// 五仙五毒使
		/// </summary>
		public const short WuxianMember3 = 185;

		/// <summary>
		/// 五仙花蛊部众
		/// </summary>
		public const short WuxianMember2 = 186;

		/// <summary>
		/// 五仙五毒部众
		/// </summary>
		public const short WuxianMember1 = 187;

		/// <summary>
		/// 五仙教众
		/// </summary>
		public const short WuxianMember0 = 188;

		/// <summary>
		/// 隐退的界青前辈
		/// </summary>
		public const short JieqingRetiredSenior = 189;

		/// <summary>
		/// 界青七宿鬼
		/// </summary>
		public const short JieqingMember6 = 190;

		/// <summary>
		/// 界青魁首
		/// </summary>
		public const short JieqingMember5 = 191;

		/// <summary>
		/// 界青死士
		/// </summary>
		public const short JieqingMember4 = 192;

		/// <summary>
		/// 界青杀手
		/// </summary>
		public const short JieqingMember3 = 193;

		/// <summary>
		/// 界青门人
		/// </summary>
		public const short JieqingMember2 = 194;

		/// <summary>
		/// 界青引路人
		/// </summary>
		public const short JieqingMember1 = 195;

		/// <summary>
		/// 界青外门众
		/// </summary>
		public const short JieqingMember0 = 196;

		/// <summary>
		/// 隐退的伏龙前辈
		/// </summary>
		public const short FulongRetiredSenior = 197;

		/// <summary>
		/// 伏龙龙头长老
		/// </summary>
		public const short FulongMember6 = 198;

		/// <summary>
		/// 伏龙首徒
		/// </summary>
		public const short FulongMember5 = 199;

		/// <summary>
		/// 伏龙巡海使
		/// </summary>
		public const short FulongMember4 = 200;

		/// <summary>
		/// 伏龙赐姓弟子
		/// </summary>
		public const short FulongMember3 = 201;

		/// <summary>
		/// 伏龙入门弟子
		/// </summary>
		public const short FulongMember2 = 202;

		/// <summary>
		/// 伏龙外姓弟子
		/// </summary>
		public const short FulongMember1 = 203;

		/// <summary>
		/// 伏龙岛众
		/// </summary>
		public const short FulongMember0 = 204;

		/// <summary>
		/// 隐退的血犼前辈
		/// </summary>
		public const short XuehouRetiredSenior = 205;

		/// <summary>
		/// 血犼长老
		/// </summary>
		public const short XuehouMember6 = 206;

		/// <summary>
		/// 血犼犼母圣使
		/// </summary>
		public const short XuehouMember5 = 207;

		/// <summary>
		/// 血犼护法
		/// </summary>
		public const short XuehouMember4 = 208;

		/// <summary>
		/// 血犼血童子
		/// </summary>
		public const short XuehouMember3 = 209;

		/// <summary>
		/// 血犼精英
		/// </summary>
		public const short XuehouMember2 = 210;

		/// <summary>
		/// 血犼教众
		/// </summary>
		public const short XuehouMember1 = 211;

		/// <summary>
		/// 血犼杂役
		/// </summary>
		public const short XuehouMember0 = 212;

		/// <summary>
		/// 兔儿郎
		/// </summary>
		public const short FoxyBoy = 233;

		/// <summary>
		/// 浪子
		/// </summary>
		public const short DevilishMan = 234;

		/// <summary>
		/// 裙带倌
		/// </summary>
		public const short PoisonousWidower = 235;

		/// <summary>
		/// 风流客
		/// </summary>
		public const short PhilanderingMan = 236;

		/// <summary>
		/// 粉面郎君
		/// </summary>
		public const short FairFaceKing = 237;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 病乞丐
		/// </summary>
		public static RandomEnemyItem SickBeggar => Instance[(short)0];

		/// <summary>
		/// 恶丐
		/// </summary>
		public static RandomEnemyItem EvilBeggar => Instance[(short)1];

		/// <summary>
		/// 托钵恶丐
		/// </summary>
		public static RandomEnemyItem BowlBeggar => Instance[(short)2];

		/// <summary>
		/// 弄蛇恶丐
		/// </summary>
		public static RandomEnemyItem SnakeBeggar => Instance[(short)3];

		/// <summary>
		/// 恶丐头子
		/// </summary>
		public static RandomEnemyItem BossBeggar => Instance[(short)4];

		/// <summary>
		/// 小毛贼
		/// </summary>
		public static RandomEnemyItem PettyThief => Instance[(short)5];

		/// <summary>
		/// 惯盗
		/// </summary>
		public static RandomEnemyItem CommonThief => Instance[(short)6];

		/// <summary>
		/// 采花贼
		/// </summary>
		public static RandomEnemyItem RapistThief => Instance[(short)7];

		/// <summary>
		/// 女飞贼
		/// </summary>
		public static RandomEnemyItem FemaleThief => Instance[(short)8];

		/// <summary>
		/// 大盗
		/// </summary>
		public static RandomEnemyItem BigThief => Instance[(short)9];

		/// <summary>
		/// 地痞
		/// </summary>
		public static RandomEnemyItem LocalThug => Instance[(short)10];

		/// <summary>
		/// 山贼
		/// </summary>
		public static RandomEnemyItem MountainBandit => Instance[(short)11];

		/// <summary>
		/// 恶霸
		/// </summary>
		public static RandomEnemyItem EvilBandit => Instance[(short)12];

		/// <summary>
		/// 悍匪
		/// </summary>
		public static RandomEnemyItem FierceBandit => Instance[(short)13];

		/// <summary>
		/// 山大王
		/// </summary>
		public static RandomEnemyItem BossBandit => Instance[(short)14];

		/// <summary>
		/// 少林弃徒
		/// </summary>
		public static RandomEnemyItem ShaolinTraitor => Instance[(short)15];

		/// <summary>
		/// 峨眉弃徒
		/// </summary>
		public static RandomEnemyItem EmeiTraitor => Instance[(short)16];

		/// <summary>
		/// 百花弃徒
		/// </summary>
		public static RandomEnemyItem BaihuaTraitor => Instance[(short)17];

		/// <summary>
		/// 武当弃徒
		/// </summary>
		public static RandomEnemyItem WudangTraitor => Instance[(short)18];

		/// <summary>
		/// 元山弃徒
		/// </summary>
		public static RandomEnemyItem YuanshanTraitor => Instance[(short)19];

		/// <summary>
		/// 狮相弃徒
		/// </summary>
		public static RandomEnemyItem ShixiangTraitor => Instance[(short)20];

		/// <summary>
		/// 然山弃徒
		/// </summary>
		public static RandomEnemyItem RanshanTraitor => Instance[(short)21];

		/// <summary>
		/// 璇女弃徒
		/// </summary>
		public static RandomEnemyItem XuannvTraitor => Instance[(short)22];

		/// <summary>
		/// 铸剑弃徒
		/// </summary>
		public static RandomEnemyItem ZhujianTraitor => Instance[(short)23];

		/// <summary>
		/// 空桑弃徒
		/// </summary>
		public static RandomEnemyItem KongsangTraitor => Instance[(short)24];

		/// <summary>
		/// 金刚弃徒
		/// </summary>
		public static RandomEnemyItem JingangTraitor => Instance[(short)25];

		/// <summary>
		/// 五仙弃徒
		/// </summary>
		public static RandomEnemyItem WuxianTraitor => Instance[(short)26];

		/// <summary>
		/// 界青弃徒
		/// </summary>
		public static RandomEnemyItem JieqingTraitor => Instance[(short)27];

		/// <summary>
		/// 伏龙弃徒
		/// </summary>
		public static RandomEnemyItem FulongTraitor => Instance[(short)28];

		/// <summary>
		/// 血犼弃徒
		/// </summary>
		public static RandomEnemyItem XuehouTraitor => Instance[(short)29];

		/// <summary>
		/// 亡命徒
		/// </summary>
		public static RandomEnemyItem Desperado => Instance[(short)30];

		/// <summary>
		/// 花和尚
		/// </summary>
		public static RandomEnemyItem RapistMonk => Instance[(short)31];

		/// <summary>
		/// 妖道
		/// </summary>
		public static RandomEnemyItem DevilishTaoist => Instance[(short)32];

		/// <summary>
		/// 吃人鬼
		/// </summary>
		public static RandomEnemyItem ManEatingGhost => Instance[(short)33];

		/// <summary>
		/// 元凶
		/// </summary>
		public static RandomEnemyItem CrimeCulprit => Instance[(short)34];

		/// <summary>
		/// 狐媚子
		/// </summary>
		public static RandomEnemyItem FoxyGirl => Instance[(short)35];

		/// <summary>
		/// 妖妇
		/// </summary>
		public static RandomEnemyItem DevilishWoman => Instance[(short)36];

		/// <summary>
		/// 毒寡妇
		/// </summary>
		public static RandomEnemyItem PoisonousWidow => Instance[(short)37];

		/// <summary>
		/// 合欢仙
		/// </summary>
		public static RandomEnemyItem HappyReunionFairy => Instance[(short)38];

		/// <summary>
		/// 玉面娘娘
		/// </summary>
		public static RandomEnemyItem FairFaceQueen => Instance[(short)39];

		/// <summary>
		/// 鬼仆
		/// </summary>
		public static RandomEnemyItem GhostServant => Instance[(short)40];

		/// <summary>
		/// 炼尸人
		/// </summary>
		public static RandomEnemyItem RefineCorpsePerson => Instance[(short)41];

		/// <summary>
		/// 尸爪人
		/// </summary>
		public static RandomEnemyItem CorpseClawPerson => Instance[(short)42];

		/// <summary>
		/// 鬼医
		/// </summary>
		public static RandomEnemyItem GhostDoctor => Instance[(short)43];

		/// <summary>
		/// 活死人
		/// </summary>
		public static RandomEnemyItem LivingDead => Instance[(short)44];

		/// <summary>
		/// 妖乐师
		/// </summary>
		public static RandomEnemyItem DevilishMusician => Instance[(short)45];

		/// <summary>
		/// 阴阳生
		/// </summary>
		public static RandomEnemyItem MystifyingChessPlayer => Instance[(short)46];

		/// <summary>
		/// 血书客
		/// </summary>
		public static RandomEnemyItem BloodCalligrapher => Instance[(short)47];

		/// <summary>
		/// 坏色翁
		/// </summary>
		public static RandomEnemyItem BadMonkOldMan => Instance[(short)48];

		/// <summary>
		/// 无明子
		/// </summary>
		public static RandomEnemyItem IgnorantWiseMan => Instance[(short)49];

		/// <summary>
		/// 金刚教众
		/// </summary>
		public static RandomEnemyItem HereticMetal => Instance[(short)50];

		/// <summary>
		/// 紫霞教众
		/// </summary>
		public static RandomEnemyItem HereticWood => Instance[(short)51];

		/// <summary>
		/// 玄阴教众
		/// </summary>
		public static RandomEnemyItem HereticWater => Instance[(short)52];

		/// <summary>
		/// 纯阳教众
		/// </summary>
		public static RandomEnemyItem HereticFire => Instance[(short)53];

		/// <summary>
		/// 归元教众
		/// </summary>
		public static RandomEnemyItem HereticEarth => Instance[(short)54];

		/// <summary>
		/// 异疆怪人
		/// </summary>
		public static RandomEnemyItem ForeignWeirdo => Instance[(short)55];

		/// <summary>
		/// 毒手客
		/// </summary>
		public static RandomEnemyItem PoisonHand => Instance[(short)56];

		/// <summary>
		/// 邪士
		/// </summary>
		public static RandomEnemyItem EvilBachelor => Instance[(short)57];

		/// <summary>
		/// 童身老怪
		/// </summary>
		public static RandomEnemyItem PureOldBeing => Instance[(short)58];

		/// <summary>
		/// 邪道共主
		/// </summary>
		public static RandomEnemyItem EvilWayConjointBoss => Instance[(short)59];

		/// <summary>
		/// 丧心侠士
		/// </summary>
		public static RandomEnemyItem LoseHeartChivalrousMan => Instance[(short)60];

		/// <summary>
		/// 恶煞
		/// </summary>
		public static RandomEnemyItem EvilSpirit => Instance[(short)61];

		/// <summary>
		/// 失魂人
		/// </summary>
		public static RandomEnemyItem LoseSoulPerson => Instance[(short)62];

		/// <summary>
		/// 血披战鬼
		/// </summary>
		public static RandomEnemyItem BloodyWarGhost => Instance[(short)63];

		/// <summary>
		/// 炼心师
		/// </summary>
		public static RandomEnemyItem RefineHeartMaster => Instance[(short)64];

		/// <summary>
		/// 疯魔
		/// </summary>
		public static RandomEnemyItem MadDemon => Instance[(short)65];

		/// <summary>
		/// 火池客
		/// </summary>
		public static RandomEnemyItem FirePondMale => Instance[(short)66];

		/// <summary>
		/// 寒池女
		/// </summary>
		public static RandomEnemyItem ColdPondFemale => Instance[(short)67];

		/// <summary>
		/// 阿鼻众
		/// </summary>
		public static RandomEnemyItem AviciFolk => Instance[(short)68];

		/// <summary>
		/// 摩罗尊主
		/// </summary>
		public static RandomEnemyItem SoumoulouLord => Instance[(short)69];

		/// <summary>
		/// 绝境客
		/// </summary>
		public static RandomEnemyItem DesperatePerson => Instance[(short)70];

		/// <summary>
		/// 非人众
		/// </summary>
		public static RandomEnemyItem InHumanFolk => Instance[(short)71];

		/// <summary>
		/// 无相老僧
		/// </summary>
		public static RandomEnemyItem NoAppearanceOldMonk => Instance[(short)72];

		/// <summary>
		/// 无名老道
		/// </summary>
		public static RandomEnemyItem NoNameOldTaoist => Instance[(short)73];

		/// <summary>
		/// 弃世老人
		/// </summary>
		public static RandomEnemyItem WorldWearyOldPerson => Instance[(short)74];

		/// <summary>
		/// 相枢闻恶声
		/// </summary>
		public static RandomEnemyItem XiangshuMinion0 => Instance[(short)75];

		/// <summary>
		/// 相枢祛善
		/// </summary>
		public static RandomEnemyItem XiangshuMinion1 => Instance[(short)76];

		/// <summary>
		/// 相枢唤目
		/// </summary>
		public static RandomEnemyItem XiangshuMinion2 => Instance[(short)77];

		/// <summary>
		/// 相枢妖心示显
		/// </summary>
		public static RandomEnemyItem XiangshuMinion3 => Instance[(short)78];

		/// <summary>
		/// 相枢百邪
		/// </summary>
		public static RandomEnemyItem XiangshuMinion4 => Instance[(short)79];

		/// <summary>
		/// 相枢堕心九部众
		/// </summary>
		public static RandomEnemyItem XiangshuMinion5 => Instance[(short)80];

		/// <summary>
		/// 相枢众相生
		/// </summary>
		public static RandomEnemyItem XiangshuMinion6 => Instance[(short)81];

		/// <summary>
		/// 相枢神断护法
		/// </summary>
		public static RandomEnemyItem XiangshuMinion7 => Instance[(short)82];

		/// <summary>
		/// 相枢玄狱九老
		/// </summary>
		public static RandomEnemyItem XiangshuMinion8 => Instance[(short)83];

		/// <summary>
		/// 任侠义士
		/// </summary>
		public static RandomEnemyItem Righteous0 => Instance[(short)84];

		/// <summary>
		/// 任侠巡街武人
		/// </summary>
		public static RandomEnemyItem Righteous1 => Instance[(short)85];

		/// <summary>
		/// 任侠年轻侠士
		/// </summary>
		public static RandomEnemyItem Righteous2 => Instance[(short)86];

		/// <summary>
		/// 任侠镖师
		/// </summary>
		public static RandomEnemyItem Righteous3 => Instance[(short)87];

		/// <summary>
		/// 任侠成名镖师
		/// </summary>
		public static RandomEnemyItem Righteous4 => Instance[(short)88];

		/// <summary>
		/// 任侠江湖奇人
		/// </summary>
		public static RandomEnemyItem Righteous5 => Instance[(short)89];

		/// <summary>
		/// 任侠无名侠客
		/// </summary>
		public static RandomEnemyItem Righteous6 => Instance[(short)90];

		/// <summary>
		/// 任侠成名英豪
		/// </summary>
		public static RandomEnemyItem Righteous7 => Instance[(short)91];

		/// <summary>
		/// 任侠隐居名宿
		/// </summary>
		public static RandomEnemyItem Righteous8 => Instance[(short)92];

		/// <summary>
		/// 隐退的少林前辈
		/// </summary>
		public static RandomEnemyItem ShaolinRetiredSenior => Instance[(short)93];

		/// <summary>
		/// 少林长老
		/// </summary>
		public static RandomEnemyItem ShaolinMember6 => Instance[(short)94];

		/// <summary>
		/// 少林十八罗汉
		/// </summary>
		public static RandomEnemyItem ShaolinMember5 => Instance[(short)95];

		/// <summary>
		/// 少林持戒僧
		/// </summary>
		public static RandomEnemyItem ShaolinMember4 => Instance[(short)96];

		/// <summary>
		/// 少林菩提院弟子
		/// </summary>
		public static RandomEnemyItem ShaolinMember3 => Instance[(short)97];

		/// <summary>
		/// 少林般若堂弟子
		/// </summary>
		public static RandomEnemyItem ShaolinMember2 => Instance[(short)98];

		/// <summary>
		/// 少林罗汉堂弟子
		/// </summary>
		public static RandomEnemyItem ShaolinMember1 => Instance[(short)99];

		/// <summary>
		/// 少林比丘
		/// </summary>
		public static RandomEnemyItem ShaolinMember0 => Instance[(short)100];

		/// <summary>
		/// 隐退的峨眉前辈
		/// </summary>
		public static RandomEnemyItem EmeiRetiredSenior => Instance[(short)101];

		/// <summary>
		/// 峨眉掌门弟子
		/// </summary>
		public static RandomEnemyItem EmeiMember6 => Instance[(short)102];

		/// <summary>
		/// 峨眉真传弟子
		/// </summary>
		public static RandomEnemyItem EmeiMember5 => Instance[(short)103];

		/// <summary>
		/// 峨眉八门嫡传
		/// </summary>
		public static RandomEnemyItem EmeiMember4 => Instance[(short)104];

		/// <summary>
		/// 峨眉八门正徒
		/// </summary>
		public static RandomEnemyItem EmeiMember3 => Instance[(short)105];

		/// <summary>
		/// 峨眉杂门弟子
		/// </summary>
		public static RandomEnemyItem EmeiMember2 => Instance[(short)106];

		/// <summary>
		/// 峨眉内门散徒
		/// </summary>
		public static RandomEnemyItem EmeiMember1 => Instance[(short)107];

		/// <summary>
		/// 峨眉外门散徒
		/// </summary>
		public static RandomEnemyItem EmeiMember0 => Instance[(short)108];

		/// <summary>
		/// 隐退的百花前辈
		/// </summary>
		public static RandomEnemyItem BaihuaRetiredSenior => Instance[(short)109];

		/// <summary>
		/// 百花鹿裳使
		/// </summary>
		public static RandomEnemyItem BaihuaMember6 => Instance[(short)110];

		/// <summary>
		/// 百花妙手
		/// </summary>
		public static RandomEnemyItem BaihuaMember5 => Instance[(short)111];

		/// <summary>
		/// 百花朱匣弟子
		/// </summary>
		public static RandomEnemyItem BaihuaMember4 => Instance[(short)112];

		/// <summary>
		/// 百花玉匣弟子
		/// </summary>
		public static RandomEnemyItem BaihuaMember3 => Instance[(short)113];

		/// <summary>
		/// 百花金匣弟子
		/// </summary>
		public static RandomEnemyItem BaihuaMember2 => Instance[(short)114];

		/// <summary>
		/// 百花花匣弟子
		/// </summary>
		public static RandomEnemyItem BaihuaMember1 => Instance[(short)115];

		/// <summary>
		/// 百花牧鹿童
		/// </summary>
		public static RandomEnemyItem BaihuaMember0 => Instance[(short)116];

		/// <summary>
		/// 隐退的武当前辈
		/// </summary>
		public static RandomEnemyItem WudangRetiredSenior => Instance[(short)117];

		/// <summary>
		/// 武当掌门弟子
		/// </summary>
		public static RandomEnemyItem WudangMember6 => Instance[(short)118];

		/// <summary>
		/// 武当真传弟子
		/// </summary>
		public static RandomEnemyItem WudangMember5 => Instance[(short)119];

		/// <summary>
		/// 武当真武殿弟子
		/// </summary>
		public static RandomEnemyItem WudangMember4 => Instance[(short)120];

		/// <summary>
		/// 武当紫霄宫弟子
		/// </summary>
		public static RandomEnemyItem WudangMember3 => Instance[(short)121];

		/// <summary>
		/// 武当太和宫弟子
		/// </summary>
		public static RandomEnemyItem WudangMember2 => Instance[(short)122];

		/// <summary>
		/// 武当接引道人
		/// </summary>
		public static RandomEnemyItem WudangMember1 => Instance[(short)123];

		/// <summary>
		/// 武当外门弟子
		/// </summary>
		public static RandomEnemyItem WudangMember0 => Instance[(short)124];

		/// <summary>
		/// 隐退的元山前辈
		/// </summary>
		public static RandomEnemyItem YuanshanRetiredSenior => Instance[(short)125];

		/// <summary>
		/// 元山伏魔众
		/// </summary>
		public static RandomEnemyItem YuanshanMember6 => Instance[(short)126];

		/// <summary>
		/// 元山传法众
		/// </summary>
		public static RandomEnemyItem YuanshanMember5 => Instance[(short)127];

		/// <summary>
		/// 元山苦行众
		/// </summary>
		public static RandomEnemyItem YuanshanMember4 => Instance[(short)128];

		/// <summary>
		/// 元山护法弟子
		/// </summary>
		public static RandomEnemyItem YuanshanMember3 => Instance[(short)129];

		/// <summary>
		/// 元山石牢弟子
		/// </summary>
		public static RandomEnemyItem YuanshanMember2 => Instance[(short)130];

		/// <summary>
		/// 元山入门弟子
		/// </summary>
		public static RandomEnemyItem YuanshanMember1 => Instance[(short)131];

		/// <summary>
		/// 元山受戒仆
		/// </summary>
		public static RandomEnemyItem YuanshanMember0 => Instance[(short)132];

		/// <summary>
		/// 隐退的狮相前辈
		/// </summary>
		public static RandomEnemyItem ShixiangRetiredSenior => Instance[(short)133];

		/// <summary>
		/// 狮相狂狮强手
		/// </summary>
		public static RandomEnemyItem ShixiangMember6 => Instance[(short)134];

		/// <summary>
		/// 狮相锦狮强手
		/// </summary>
		public static RandomEnemyItem ShixiangMember5 => Instance[(short)135];

		/// <summary>
		/// 狮相睡狮强手
		/// </summary>
		public static RandomEnemyItem ShixiangMember4 => Instance[(short)136];

		/// <summary>
		/// 狮相狂狮堂弟子
		/// </summary>
		public static RandomEnemyItem ShixiangMember3 => Instance[(short)137];

		/// <summary>
		/// 狮相锦狮堂弟子
		/// </summary>
		public static RandomEnemyItem ShixiangMember2 => Instance[(short)138];

		/// <summary>
		/// 狮相睡狮堂弟子
		/// </summary>
		public static RandomEnemyItem ShixiangMember1 => Instance[(short)139];

		/// <summary>
		/// 狮相狮崽子
		/// </summary>
		public static RandomEnemyItem ShixiangMember0 => Instance[(short)140];

		/// <summary>
		/// 隐退的然山前辈
		/// </summary>
		public static RandomEnemyItem RanshanRetiredSenior => Instance[(short)141];

		/// <summary>
		/// 然山青琅护法
		/// </summary>
		public static RandomEnemyItem RanshanMember6 => Instance[(short)142];

		/// <summary>
		/// 然山三宗传人
		/// </summary>
		public static RandomEnemyItem RanshanMember5 => Instance[(short)143];

		/// <summary>
		/// 然山玉符宗游士
		/// </summary>
		public static RandomEnemyItem RanshanMember4 => Instance[(short)144];

		/// <summary>
		/// 然山神剑宗游士
		/// </summary>
		public static RandomEnemyItem RanshanMember3 => Instance[(short)145];

		/// <summary>
		/// 然山阴阳宗游士
		/// </summary>
		public static RandomEnemyItem RanshanMember2 => Instance[(short)146];

		/// <summary>
		/// 然山剑奴
		/// </summary>
		public static RandomEnemyItem RanshanMember1 => Instance[(short)147];

		/// <summary>
		/// 然山散人
		/// </summary>
		public static RandomEnemyItem RanshanMember0 => Instance[(short)148];

		/// <summary>
		/// 隐退的璇女前辈
		/// </summary>
		public static RandomEnemyItem XuannvRetiredSenior => Instance[(short)149];

		/// <summary>
		/// 璇女羽衣使
		/// </summary>
		public static RandomEnemyItem XuannvMember6 => Instance[(short)150];

		/// <summary>
		/// 璇女霓裳使
		/// </summary>
		public static RandomEnemyItem XuannvMember5 => Instance[(short)151];

		/// <summary>
		/// 璇女守玉人
		/// </summary>
		public static RandomEnemyItem XuannvMember4 => Instance[(short)152];

		/// <summary>
		/// 璇女天音阁弟子
		/// </summary>
		public static RandomEnemyItem XuannvMember3 => Instance[(short)153];

		/// <summary>
		/// 璇女内门弟子
		/// </summary>
		public static RandomEnemyItem XuannvMember2 => Instance[(short)154];

		/// <summary>
		/// 璇女外门弟子
		/// </summary>
		public static RandomEnemyItem XuannvMember1 => Instance[(short)155];

		/// <summary>
		/// 璇女婢子
		/// </summary>
		public static RandomEnemyItem XuannvMember0 => Instance[(short)156];

		/// <summary>
		/// 隐退的铸剑前辈
		/// </summary>
		public static RandomEnemyItem ZhujianRetiredSenior => Instance[(short)157];

		/// <summary>
		/// 铸剑七星匠
		/// </summary>
		public static RandomEnemyItem ZhujianMember6 => Instance[(short)158];

		/// <summary>
		/// 铸剑玄鸿匠
		/// </summary>
		public static RandomEnemyItem ZhujianMember5 => Instance[(short)159];

		/// <summary>
		/// 铸剑镇山匠
		/// </summary>
		public static RandomEnemyItem ZhujianMember4 => Instance[(short)160];

		/// <summary>
		/// 铸剑百辟匠
		/// </summary>
		public static RandomEnemyItem ZhujianMember3 => Instance[(short)161];

		/// <summary>
		/// 铸剑青君匠
		/// </summary>
		public static RandomEnemyItem ZhujianMember2 => Instance[(short)162];

		/// <summary>
		/// 铸剑学徒
		/// </summary>
		public static RandomEnemyItem ZhujianMember1 => Instance[(short)163];

		/// <summary>
		/// 铸剑火工
		/// </summary>
		public static RandomEnemyItem ZhujianMember0 => Instance[(short)164];

		/// <summary>
		/// 隐退的空桑前辈
		/// </summary>
		public static RandomEnemyItem KongsangRetiredSenior => Instance[(short)165];

		/// <summary>
		/// 空桑长老
		/// </summary>
		public static RandomEnemyItem KongsangMember6 => Instance[(short)166];

		/// <summary>
		/// 空桑蛟士
		/// </summary>
		public static RandomEnemyItem KongsangMember5 => Instance[(short)167];

		/// <summary>
		/// 空桑持鼎首徒
		/// </summary>
		public static RandomEnemyItem KongsangMember4 => Instance[(short)168];

		/// <summary>
		/// 空桑玄炉院弟子
		/// </summary>
		public static RandomEnemyItem KongsangMember3 => Instance[(short)169];

		/// <summary>
		/// 空桑蛟王院弟子
		/// </summary>
		public static RandomEnemyItem KongsangMember2 => Instance[(short)170];

		/// <summary>
		/// 空桑朱砭院弟子
		/// </summary>
		public static RandomEnemyItem KongsangMember1 => Instance[(short)171];

		/// <summary>
		/// 空桑药童
		/// </summary>
		public static RandomEnemyItem KongsangMember0 => Instance[(short)172];

		/// <summary>
		/// 隐退的金刚前辈
		/// </summary>
		public static RandomEnemyItem JingangRetiredSenior => Instance[(short)173];

		/// <summary>
		/// 金刚上尊
		/// </summary>
		public static RandomEnemyItem JingangMember6 => Instance[(short)174];

		/// <summary>
		/// 金刚护法尊者
		/// </summary>
		public static RandomEnemyItem JingangMember5 => Instance[(short)175];

		/// <summary>
		/// 金刚金刚力士
		/// </summary>
		public static RandomEnemyItem JingangMember4 => Instance[(short)176];

		/// <summary>
		/// 金刚不动殿弟子
		/// </summary>
		public static RandomEnemyItem JingangMember3 => Instance[(short)177];

		/// <summary>
		/// 金刚金刚院弟子
		/// </summary>
		public static RandomEnemyItem JingangMember2 => Instance[(short)178];

		/// <summary>
		/// 金刚罗刹院弟子
		/// </summary>
		public static RandomEnemyItem JingangMember1 => Instance[(short)179];

		/// <summary>
		/// 金刚净火童
		/// </summary>
		public static RandomEnemyItem JingangMember0 => Instance[(short)180];

		/// <summary>
		/// 隐退的五仙前辈
		/// </summary>
		public static RandomEnemyItem WuxianRetiredSenior => Instance[(short)181];

		/// <summary>
		/// 五仙巫相
		/// </summary>
		public static RandomEnemyItem WuxianMember6 => Instance[(short)182];

		/// <summary>
		/// 五仙族长
		/// </summary>
		public static RandomEnemyItem WuxianMember5 => Instance[(short)183];

		/// <summary>
		/// 五仙仙娘使
		/// </summary>
		public static RandomEnemyItem WuxianMember4 => Instance[(short)184];

		/// <summary>
		/// 五仙五毒使
		/// </summary>
		public static RandomEnemyItem WuxianMember3 => Instance[(short)185];

		/// <summary>
		/// 五仙花蛊部众
		/// </summary>
		public static RandomEnemyItem WuxianMember2 => Instance[(short)186];

		/// <summary>
		/// 五仙五毒部众
		/// </summary>
		public static RandomEnemyItem WuxianMember1 => Instance[(short)187];

		/// <summary>
		/// 五仙教众
		/// </summary>
		public static RandomEnemyItem WuxianMember0 => Instance[(short)188];

		/// <summary>
		/// 隐退的界青前辈
		/// </summary>
		public static RandomEnemyItem JieqingRetiredSenior => Instance[(short)189];

		/// <summary>
		/// 界青七宿鬼
		/// </summary>
		public static RandomEnemyItem JieqingMember6 => Instance[(short)190];

		/// <summary>
		/// 界青魁首
		/// </summary>
		public static RandomEnemyItem JieqingMember5 => Instance[(short)191];

		/// <summary>
		/// 界青死士
		/// </summary>
		public static RandomEnemyItem JieqingMember4 => Instance[(short)192];

		/// <summary>
		/// 界青杀手
		/// </summary>
		public static RandomEnemyItem JieqingMember3 => Instance[(short)193];

		/// <summary>
		/// 界青门人
		/// </summary>
		public static RandomEnemyItem JieqingMember2 => Instance[(short)194];

		/// <summary>
		/// 界青引路人
		/// </summary>
		public static RandomEnemyItem JieqingMember1 => Instance[(short)195];

		/// <summary>
		/// 界青外门众
		/// </summary>
		public static RandomEnemyItem JieqingMember0 => Instance[(short)196];

		/// <summary>
		/// 隐退的伏龙前辈
		/// </summary>
		public static RandomEnemyItem FulongRetiredSenior => Instance[(short)197];

		/// <summary>
		/// 伏龙龙头长老
		/// </summary>
		public static RandomEnemyItem FulongMember6 => Instance[(short)198];

		/// <summary>
		/// 伏龙首徒
		/// </summary>
		public static RandomEnemyItem FulongMember5 => Instance[(short)199];

		/// <summary>
		/// 伏龙巡海使
		/// </summary>
		public static RandomEnemyItem FulongMember4 => Instance[(short)200];

		/// <summary>
		/// 伏龙赐姓弟子
		/// </summary>
		public static RandomEnemyItem FulongMember3 => Instance[(short)201];

		/// <summary>
		/// 伏龙入门弟子
		/// </summary>
		public static RandomEnemyItem FulongMember2 => Instance[(short)202];

		/// <summary>
		/// 伏龙外姓弟子
		/// </summary>
		public static RandomEnemyItem FulongMember1 => Instance[(short)203];

		/// <summary>
		/// 伏龙岛众
		/// </summary>
		public static RandomEnemyItem FulongMember0 => Instance[(short)204];

		/// <summary>
		/// 隐退的血犼前辈
		/// </summary>
		public static RandomEnemyItem XuehouRetiredSenior => Instance[(short)205];

		/// <summary>
		/// 血犼长老
		/// </summary>
		public static RandomEnemyItem XuehouMember6 => Instance[(short)206];

		/// <summary>
		/// 血犼犼母圣使
		/// </summary>
		public static RandomEnemyItem XuehouMember5 => Instance[(short)207];

		/// <summary>
		/// 血犼护法
		/// </summary>
		public static RandomEnemyItem XuehouMember4 => Instance[(short)208];

		/// <summary>
		/// 血犼血童子
		/// </summary>
		public static RandomEnemyItem XuehouMember3 => Instance[(short)209];

		/// <summary>
		/// 血犼精英
		/// </summary>
		public static RandomEnemyItem XuehouMember2 => Instance[(short)210];

		/// <summary>
		/// 血犼教众
		/// </summary>
		public static RandomEnemyItem XuehouMember1 => Instance[(short)211];

		/// <summary>
		/// 血犼杂役
		/// </summary>
		public static RandomEnemyItem XuehouMember0 => Instance[(short)212];

		/// <summary>
		/// 兔儿郎
		/// </summary>
		public static RandomEnemyItem FoxyBoy => Instance[(short)233];

		/// <summary>
		/// 浪子
		/// </summary>
		public static RandomEnemyItem DevilishMan => Instance[(short)234];

		/// <summary>
		/// 裙带倌
		/// </summary>
		public static RandomEnemyItem PoisonousWidower => Instance[(short)235];

		/// <summary>
		/// 风流客
		/// </summary>
		public static RandomEnemyItem PhilanderingMan => Instance[(short)236];

		/// <summary>
		/// 粉面郎君
		/// </summary>
		public static RandomEnemyItem FairFaceKing => Instance[(short)237];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static RandomEnemy Instance = new RandomEnemy();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "SectIds", "RequireAttackSkillType", "PoisonsToAdd", "TemplateId", "PracticeRandomRange" };

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
		_dataArray.Add(new RandomEnemyItem(0, new List<short> { 5, 14, 15 }, 1, new List<short>(), 0, -40, -40, 2, 4, 1, new short[6] { 0, 9, 18, 27, 36, 45 }, (30, 100), new(int, int)[2]
		{
			(1, 2),
			(1, 2)
		}));
		_dataArray.Add(new RandomEnemyItem(1, new List<short> { 5, 14, 15 }, 1, new List<short>(), 0, -40, -40, 2, 4, 1, new short[6] { 0, 9, 18, 27, 36, 45 }, (30, 100), new(int, int)[2]
		{
			(1, 2),
			(1, 2)
		}));
		_dataArray.Add(new RandomEnemyItem(2, new List<short> { 5, 14, 15 }, 1, new List<short>(), 0, -40, -40, 2, 4, 1, new short[6] { 0, 9, 18, 27, 36, 45 }, (30, 100), new(int, int)[2]
		{
			(1, 2),
			(1, 2)
		}));
		_dataArray.Add(new RandomEnemyItem(3, new List<short> { 5, 14, 15 }, 1, new List<short>(), 0, -40, -40, 2, 4, 1, new short[6] { 0, 9, 18, 27, 36, 45 }, (30, 100), new(int, int)[2]
		{
			(1, 2),
			(1, 2)
		}));
		_dataArray.Add(new RandomEnemyItem(4, new List<short> { 5, 14, 15 }, 2, new List<short>(), 1, -40, -40, 10, 12, 1, new short[6] { 0, 9, 18, 27, 36, 45 }, (100, 100), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(5, new List<short> { 2, 8, 13 }, 1, new List<short>(), 0, -20, -20, 4, 0, 0, new short[0], (35, 110), new(int, int)[2]
		{
			(1, 3),
			(1, 3)
		}));
		_dataArray.Add(new RandomEnemyItem(6, new List<short> { 2, 8, 13 }, 1, new List<short>(), 0, -20, -20, 4, 0, 0, new short[0], (35, 110), new(int, int)[2]
		{
			(1, 3),
			(1, 3)
		}));
		_dataArray.Add(new RandomEnemyItem(7, new List<short> { 2, 8, 13 }, 1, new List<short>(), 1, -20, -20, 4, 0, 0, new short[0], (35, 110), new(int, int)[2]
		{
			(1, 3),
			(1, 3)
		}));
		_dataArray.Add(new RandomEnemyItem(8, new List<short> { 2, 8, 13 }, 1, new List<short>(), 1, -20, -20, 4, 0, 0, new short[0], (35, 110), new(int, int)[2]
		{
			(1, 3),
			(1, 3)
		}));
		_dataArray.Add(new RandomEnemyItem(9, new List<short> { 2, 8, 13 }, 2, new List<short>(), 2, -20, -20, 20, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(10, new List<short> { 1, 6, 11 }, 1, new List<short>(), 1, 0, 0, 6, 0, 0, new short[0], (40, 120), new(int, int)[2]
		{
			(1, 4),
			(1, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(11, new List<short> { 1, 6, 11 }, 1, new List<short>(), 1, 0, 0, 6, 0, 0, new short[0], (40, 120), new(int, int)[2]
		{
			(1, 4),
			(1, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(12, new List<short> { 1, 6, 11 }, 1, new List<short>(), 1, 0, 0, 6, 0, 0, new short[0], (40, 120), new(int, int)[2]
		{
			(1, 4),
			(1, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(13, new List<short> { 1, 6, 11 }, 1, new List<short>(), 2, 0, 0, 6, 0, 0, new short[0], (40, 120), new(int, int)[2]
		{
			(1, 4),
			(1, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(14, new List<short> { 1, 6, 11 }, 2, new List<short>(), 3, 0, 0, 30, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(15, new List<short> { 1 }, 1, new List<short>(), 3, 0, 0, 8, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(16, new List<short> { 2 }, 1, new List<short>(), 3, 0, 0, 8, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(17, new List<short> { 3 }, 1, new List<short>(), 3, 0, 0, 8, 20, 2, new short[3] { 11, 20, 47 }, (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(18, new List<short> { 4 }, 1, new List<short>(), 3, 0, 0, 8, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(19, new List<short> { 5 }, 1, new List<short>(), 3, 0, 0, 8, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(20, new List<short> { 6 }, 1, new List<short>(), 3, 0, 0, 8, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(21, new List<short> { 7 }, 1, new List<short>(), 3, 0, 0, 8, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(22, new List<short> { 8 }, 1, new List<short>(), 3, 0, 0, 8, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(23, new List<short> { 9 }, 1, new List<short>(), 3, 0, 0, 8, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(24, new List<short> { 10 }, 1, new List<short>(), 3, 0, 0, 8, 28, 2, new short[6] { 2, 11, 20, 29, 38, 47 }, (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(25, new List<short> { 11 }, 1, new List<short>(), 3, 0, 0, 8, 12, 1, new short[3] { 1, 28, 37 }, (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(26, new List<short> { 12 }, 1, new List<short>(), 3, 0, 0, 8, 36, 2, new short[6] { 2, 11, 20, 29, 38, 47 }, (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(27, new List<short> { 13 }, 1, new List<short>(), 3, 0, 0, 8, 12, 1, new short[3] { 10, 19, 46 }, (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(28, new List<short> { 14 }, 1, new List<short>(), 3, 0, 0, 8, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(29, new List<short> { 15 }, 1, new List<short>(), 3, 0, 0, 8, 12, 1, new short[3] { 1, 28, 37 }, (45, 130), new(int, int)[2]
		{
			(2, 4),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(30, new List<short> { 3, 8, 13 }, 1, new List<short>(), 2, -20, 30, 10, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(2, 5),
			(2, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(31, new List<short> { 1, 6, 11 }, 1, new List<short>(), 2, -20, 30, 10, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(2, 5),
			(2, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(32, new List<short> { 2, 7, 12 }, 1, new List<short>(), 2, -20, 30, 10, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(2, 5),
			(2, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(33, new List<short> { 5, 10, 15 }, 1, new List<short>(), 3, -20, 30, 10, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(2, 5),
			(2, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(34, new List<short> { 4, 9, 14 }, 2, new List<short>(), 4, -20, 30, 50, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(35, new List<short> { 2, 3, 7, 8, 12, 13 }, 2, new List<short>(), 2, 30, -20, 12, 8, 2, new short[3] { 11, 20, 47 }, (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(36, new List<short> { 2, 3, 7, 8, 12, 13 }, 2, new List<short>(), 2, 30, -20, 12, 8, 2, new short[3] { 11, 20, 47 }, (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(37, new List<short> { 2, 3, 7, 8, 12, 13 }, 2, new List<short>(), 3, 30, -20, 12, 8, 2, new short[3] { 11, 20, 47 }, (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(38, new List<short> { 2, 3, 7, 8, 12, 13 }, 2, new List<short>(), 3, 30, -20, 12, 8, 2, new short[3] { 11, 20, 47 }, (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(39, new List<short> { 2, 3, 7, 8, 12, 13 }, 3, new List<short>(), 4, 30, -20, 60, 24, 3, new short[3] { 11, 20, 47 }, (100, 100), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(40, new List<short> { 4, 5, 9, 10, 14, 15 }, 2, new List<short>(), 3, 0, 0, 14, 12, 2, new short[6] { 3, 12, 21, 30, 39, 48 }, (60, 160), new(int, int)[2]
		{
			(2, 7),
			(2, 7)
		}));
		_dataArray.Add(new RandomEnemyItem(41, new List<short> { 4, 5, 9, 10, 14, 15 }, 2, new List<short>(), 3, 0, 0, 14, 12, 2, new short[6] { 3, 12, 21, 30, 39, 48 }, (60, 160), new(int, int)[2]
		{
			(2, 7),
			(2, 7)
		}));
		_dataArray.Add(new RandomEnemyItem(42, new List<short> { 4, 5, 9, 10, 14, 15 }, 2, new List<short>(), 3, 0, 0, 14, 12, 2, new short[6] { 3, 12, 21, 30, 39, 48 }, (60, 160), new(int, int)[2]
		{
			(2, 7),
			(2, 7)
		}));
		_dataArray.Add(new RandomEnemyItem(43, new List<short> { 4, 5, 9, 10, 14, 15 }, 2, new List<short>(), 4, 0, 0, 14, 12, 2, new short[6] { 3, 12, 21, 30, 39, 48 }, (60, 160), new(int, int)[2]
		{
			(2, 7),
			(2, 7)
		}));
		_dataArray.Add(new RandomEnemyItem(44, new List<short> { 4, 5, 9, 10, 14, 15 }, 3, new List<short>(), 5, 0, 0, 70, 36, 3, new short[6] { 3, 12, 21, 30, 39, 48 }, (100, 100), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(45, new List<short> { 3, 8, 13 }, 2, new List<short>(), 3, 40, 0, 16, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(2, 8),
			(2, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(46, new List<short> { 4, 14, 9 }, 2, new List<short>(), 3, 40, 0, 16, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(2, 8),
			(2, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(47, new List<short> { 5, 10, 15 }, 2, new List<short>(), 4, 40, 0, 16, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(2, 8),
			(2, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(48, new List<short> { 1, 6, 11 }, 2, new List<short>(), 4, 40, 0, 16, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(2, 8),
			(2, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(49, new List<short> { 2, 7, 12 }, 2, new List<short>(), 5, 40, 0, 80, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(50, new List<short> { 10, 11 }, 2, new List<short>(), 4, 20, 20, 18, 24, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (70, 180), new(int, int)[2]
		{
			(2, 9),
			(2, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(51, new List<short> { 3, 12 }, 2, new List<short>(), 4, 20, 20, 18, 24, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (70, 180), new(int, int)[2]
		{
			(2, 9),
			(2, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(52, new List<short> { 3, 11 }, 2, new List<short>(), 4, 20, 20, 18, 24, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (70, 180), new(int, int)[2]
		{
			(2, 9),
			(2, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(53, new List<short> { 12, 14 }, 2, new List<short>(), 4, 20, 20, 18, 24, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (70, 180), new(int, int)[2]
		{
			(2, 9),
			(2, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(54, new List<short> { 10, 14 }, 2, new List<short>(), 4, 20, 20, 18, 24, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (70, 180), new(int, int)[2]
		{
			(2, 9),
			(2, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(55, new List<short> { 3, 10, 11, 12, 14 }, 2, new List<short>(), 4, 20, 20, 18, 24, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (70, 180), new(int, int)[2]
		{
			(2, 9),
			(2, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(56, new List<short> { 3, 10, 11, 12, 14 }, 2, new List<short>(), 4, 20, 20, 18, 24, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (70, 180), new(int, int)[2]
		{
			(2, 9),
			(2, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(57, new List<short> { 3, 10, 11, 12, 14 }, 2, new List<short>(), 4, 20, 20, 18, 24, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (70, 180), new(int, int)[2]
		{
			(2, 9),
			(2, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(58, new List<short> { 3, 10, 11, 12, 14 }, 2, new List<short>(), 5, 20, 20, 18, 24, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (70, 180), new(int, int)[2]
		{
			(2, 9),
			(2, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(59, new List<short> { 3, 10, 11, 12, 14 }, 5, new List<short>(), 6, 20, 20, 90, 72, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (100, 100), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new RandomEnemyItem(60, new List<short> { 1, 2, 3, 4, 5 }, 2, new List<short>(), 4, 0, 40, 20, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(2, 10),
			(2, 10)
		}));
		_dataArray.Add(new RandomEnemyItem(61, new List<short> { 1, 2, 3, 4, 5 }, 2, new List<short>(), 4, 0, 40, 20, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(2, 10),
			(2, 10)
		}));
		_dataArray.Add(new RandomEnemyItem(62, new List<short> { 1, 2, 3, 4, 5 }, 2, new List<short>(), 5, 0, 40, 20, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(2, 10),
			(2, 10)
		}));
		_dataArray.Add(new RandomEnemyItem(63, new List<short> { 1, 2, 3, 4, 5 }, 2, new List<short>(), 5, 0, 40, 20, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(2, 10),
			(2, 10)
		}));
		_dataArray.Add(new RandomEnemyItem(64, new List<short> { 11, 12, 13, 14, 15 }, 3, new List<short>(), 6, 0, 40, 100, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(65, new List<short> { 1, 3, 6, 8, 11, 13 }, 3, new List<short>(), 5, 30, 30, 22, 16, 3, new short[6] { 5, 14, 23, 32, 41, 50 }, (80, 200), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(66, new List<short> { 4, 5, 9, 10, 14, 15 }, 3, new List<short>(), 5, 30, 30, 22, 16, 3, new short[6] { 5, 14, 23, 32, 41, 50 }, (80, 200), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(67, new List<short> { 2, 3, 7, 8, 12, 13 }, 3, new List<short>(), 5, 30, 30, 22, 16, 3, new short[6] { 5, 14, 23, 32, 41, 50 }, (80, 200), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(68, new List<short> { 2, 4, 7, 9, 12, 14 }, 3, new List<short>(), 6, 30, 30, 22, 16, 3, new short[6] { 5, 14, 23, 32, 41, 50 }, (80, 200), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(69, new List<short> { 1, 5, 6, 10, 11, 15 }, 4, new List<short>(), 7, 30, 30, 110, 48, 3, new short[6] { 5, 14, 23, 32, 41, 50 }, (100, 100), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(70, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 3, new List<short>(), 5, 30, 30, 24, 0, 0, new short[0], (85, 210), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(71, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 3, new List<short>(), 5, 30, 30, 24, 0, 0, new short[0], (85, 210), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(72, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 3, new List<short>(), 6, 30, 30, 24, 0, 0, new short[0], (85, 210), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(73, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 3, new List<short>(), 6, 30, 30, 24, 0, 0, new short[0], (85, 210), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(74, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 4, new List<short>(), 7, 30, 30, 120, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(75, new List<short> { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1, new List<short>(), 1, -20, -20, 0, 4, 1, new short[6] { 0, 9, 18, 27, 36, 45 }, (60, 140), new(int, int)[2]
		{
			(0, 0),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(76, new List<short> { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1, new List<short>(), 1, -10, -10, 0, 8, 1, new short[6] { 0, 9, 18, 27, 36, 45 }, (65, 150), new(int, int)[2]
		{
			(0, 0),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(77, new List<short> { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1, new List<short>(), 2, 0, 0, 0, 12, 1, new short[6] { 1, 10, 19, 28, 37, 46 }, (70, 160), new(int, int)[2]
		{
			(0, 0),
			(3, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(78, new List<short> { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 2, new List<short>(), 3, 10, 10, 0, 16, 2, new short[6] { 2, 11, 20, 29, 38, 47 }, (75, 170), new(int, int)[2]
		{
			(0, 0),
			(3, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(79, new List<short> { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 2, new List<short>(), 4, 20, 20, 0, 20, 2, new short[6] { 2, 11, 20, 29, 38, 47 }, (80, 180), new(int, int)[2]
		{
			(0, 0),
			(4, 12)
		}));
		_dataArray.Add(new RandomEnemyItem(80, new List<short> { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 3, new List<short>(), 5, 30, 30, 0, 24, 2, new short[6] { 3, 12, 21, 30, 39, 48 }, (85, 190), new(int, int)[2]
		{
			(0, 0),
			(4, 12)
		}));
		_dataArray.Add(new RandomEnemyItem(81, new List<short> { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 3, new List<short>(), 6, 40, 40, 0, 28, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (90, 200), new(int, int)[2]
		{
			(0, 0),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(82, new List<short> { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 4, new List<short>(), 6, 50, 50, 0, 32, 3, new short[6] { 5, 14, 23, 32, 41, 50 }, (95, 210), new(int, int)[2]
		{
			(0, 0),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(83, new List<short> { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 4, new List<short>(), 7, 60, 60, 0, 36, 3, new short[6] { 6, 15, 24, 33, 42, 51 }, (100, 100), new(int, int)[2]
		{
			(0, 0),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(84, new List<short> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, new List<short>(), 1, 0, 0, -20, 0, 0, new short[0], (60, 140), new(int, int)[2]
		{
			(2, 6),
			(0, 0)
		}));
		_dataArray.Add(new RandomEnemyItem(85, new List<short> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, new List<short>(), 1, 5, 5, -30, 0, 0, new short[0], (65, 150), new(int, int)[2]
		{
			(2, 6),
			(0, 0)
		}));
		_dataArray.Add(new RandomEnemyItem(86, new List<short> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, new List<short>(), 2, 10, 10, -40, 0, 0, new short[0], (70, 160), new(int, int)[2]
		{
			(3, 9),
			(0, 0)
		}));
		_dataArray.Add(new RandomEnemyItem(87, new List<short> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, new List<short>(), 3, 15, 15, -50, 0, 0, new short[0], (75, 170), new(int, int)[2]
		{
			(3, 9),
			(0, 0)
		}));
		_dataArray.Add(new RandomEnemyItem(88, new List<short> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, new List<short>(), 4, 20, 20, -60, 0, 0, new short[0], (80, 180), new(int, int)[2]
		{
			(4, 12),
			(0, 0)
		}));
		_dataArray.Add(new RandomEnemyItem(89, new List<short> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3, new List<short>(), 5, 25, 25, -70, 0, 0, new short[0], (85, 190), new(int, int)[2]
		{
			(4, 12),
			(0, 0)
		}));
		_dataArray.Add(new RandomEnemyItem(90, new List<short> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3, new List<short>(), 6, 30, 30, -80, 0, 0, new short[0], (90, 200), new(int, int)[2]
		{
			(5, 5),
			(0, 0)
		}));
		_dataArray.Add(new RandomEnemyItem(91, new List<short> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 4, new List<short>(), 6, 35, 35, -90, 0, 0, new short[0], (95, 210), new(int, int)[2]
		{
			(5, 5),
			(0, 0)
		}));
		_dataArray.Add(new RandomEnemyItem(92, new List<short> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 4, new List<short>(), 7, 40, 40, -100, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(0, 0)
		}));
		_dataArray.Add(new RandomEnemyItem(93, new List<short> { 1 }, 1, new List<short>(), 7, 40, 40, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(94, new List<short> { 1 }, 1, new List<short>(), 6, 0, 0, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(95, new List<short> { 1 }, 1, new List<short>(), 5, 0, 0, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(96, new List<short> { 1 }, 1, new List<short>(), 4, 0, 0, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(4, 8),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(97, new List<short> { 1 }, 1, new List<short>(), 3, 0, 0, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(4, 8),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(98, new List<short> { 1 }, 1, new List<short>(), 2, 0, 0, 0, 0, 0, new short[0], (55, 150), new(int, int)[2]
		{
			(3, 6),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(99, new List<short> { 1 }, 1, new List<short>(), 1, 0, 0, 0, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(3, 6),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(100, new List<short> { 1 }, 1, new List<short>(), 0, 0, 0, 0, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(1, 2)
		}));
		_dataArray.Add(new RandomEnemyItem(101, new List<short> { 2 }, 1, new List<short>(), 7, 40, 40, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(102, new List<short> { 2 }, 1, new List<short>(), 6, 0, 0, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(103, new List<short> { 2 }, 1, new List<short>(), 5, 0, 0, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(104, new List<short> { 2 }, 1, new List<short>(), 4, 0, 0, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(4, 8),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(105, new List<short> { 2 }, 1, new List<short>(), 3, 0, 0, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(4, 8),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(106, new List<short> { 2 }, 1, new List<short>(), 2, 0, 0, 0, 0, 0, new short[0], (55, 150), new(int, int)[2]
		{
			(3, 6),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(107, new List<short> { 2 }, 1, new List<short>(), 1, 0, 0, 0, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(3, 6),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(108, new List<short> { 2 }, 1, new List<short>(), 0, 0, 0, 0, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(1, 2)
		}));
		_dataArray.Add(new RandomEnemyItem(109, new List<short> { 3 }, 1, new List<short>(), 7, 40, 40, 0, 72, 3, new short[3] { 15, 24, 51 }, (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(110, new List<short> { 3 }, 1, new List<short>(), 6, 0, 0, 0, 36, 3, new short[3] { 14, 23, 50 }, (75, 190), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(111, new List<short> { 3 }, 1, new List<short>(), 5, 0, 0, 0, 32, 3, new short[3] { 13, 22, 49 }, (70, 180), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(112, new List<short> { 3 }, 1, new List<short>(), 4, 0, 0, 0, 28, 2, new short[3] { 12, 21, 48 }, (65, 170), new(int, int)[2]
		{
			(4, 8),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(113, new List<short> { 3 }, 1, new List<short>(), 3, 0, 0, 0, 24, 2, new short[3] { 11, 20, 47 }, (60, 160), new(int, int)[2]
		{
			(4, 8),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(114, new List<short> { 3 }, 1, new List<short>(), 2, 0, 0, 0, 20, 2, new short[3] { 10, 19, 46 }, (55, 150), new(int, int)[2]
		{
			(3, 6),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(115, new List<short> { 3 }, 1, new List<short>(), 1, 0, 0, 0, 16, 1, new short[3] { 9, 18, 45 }, (50, 140), new(int, int)[2]
		{
			(3, 6),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(116, new List<short> { 3 }, 1, new List<short>(), 0, 0, 0, 0, 12, 1, new short[3] { 9, 18, 45 }, (45, 130), new(int, int)[2]
		{
			(2, 4),
			(1, 2)
		}));
		_dataArray.Add(new RandomEnemyItem(117, new List<short> { 4 }, 1, new List<short>(), 7, 40, 40, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(118, new List<short> { 4 }, 1, new List<short>(), 6, 0, 0, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(119, new List<short> { 4 }, 1, new List<short>(), 5, 0, 0, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new RandomEnemyItem(120, new List<short> { 4 }, 1, new List<short>(), 4, 0, 0, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(4, 8),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(121, new List<short> { 4 }, 1, new List<short>(), 3, 0, 0, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(4, 8),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(122, new List<short> { 4 }, 1, new List<short>(), 2, 0, 0, 0, 0, 0, new short[0], (55, 150), new(int, int)[2]
		{
			(3, 6),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(123, new List<short> { 4 }, 1, new List<short>(), 1, 0, 0, 0, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(3, 6),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(124, new List<short> { 4 }, 1, new List<short>(), 0, 0, 0, 0, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(1, 2)
		}));
		_dataArray.Add(new RandomEnemyItem(125, new List<short> { 5 }, 1, new List<short>(), 7, 40, 40, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(126, new List<short> { 5 }, 1, new List<short>(), 6, 0, 0, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(127, new List<short> { 5 }, 1, new List<short>(), 5, 0, 0, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(128, new List<short> { 5 }, 1, new List<short>(), 4, 0, 0, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(4, 8),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(129, new List<short> { 5 }, 1, new List<short>(), 3, 0, 0, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(4, 8),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(130, new List<short> { 5 }, 1, new List<short>(), 2, 0, 0, 0, 0, 0, new short[0], (55, 150), new(int, int)[2]
		{
			(3, 6),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(131, new List<short> { 5 }, 1, new List<short>(), 1, 0, 0, 0, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(3, 6),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(132, new List<short> { 5 }, 1, new List<short>(), 0, 0, 0, 0, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(2, 4),
			(1, 2)
		}));
		_dataArray.Add(new RandomEnemyItem(133, new List<short> { 6 }, 1, new List<short>(), 7, 40, 40, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(134, new List<short> { 6 }, 1, new List<short>(), 6, 0, 0, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(4, 12),
			(4, 12)
		}));
		_dataArray.Add(new RandomEnemyItem(135, new List<short> { 6 }, 1, new List<short>(), 5, 0, 0, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(4, 12),
			(4, 12)
		}));
		_dataArray.Add(new RandomEnemyItem(136, new List<short> { 6 }, 1, new List<short>(), 4, 0, 0, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(3, 9),
			(3, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(137, new List<short> { 6 }, 1, new List<short>(), 3, 0, 0, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(3, 9),
			(3, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(138, new List<short> { 6 }, 1, new List<short>(), 2, 0, 0, 0, 0, 0, new short[0], (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(139, new List<short> { 6 }, 1, new List<short>(), 1, 0, 0, 0, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(140, new List<short> { 6 }, 1, new List<short>(), 0, 0, 0, 0, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(1, 3),
			(1, 3)
		}));
		_dataArray.Add(new RandomEnemyItem(141, new List<short> { 7 }, 1, new List<short>(), 7, 40, 40, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(142, new List<short> { 7 }, 1, new List<short>(), 6, 0, 0, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(4, 12),
			(4, 12)
		}));
		_dataArray.Add(new RandomEnemyItem(143, new List<short> { 7 }, 1, new List<short>(), 5, 0, 0, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(4, 12),
			(4, 12)
		}));
		_dataArray.Add(new RandomEnemyItem(144, new List<short> { 7 }, 1, new List<short>(), 4, 0, 0, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(3, 9),
			(3, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(145, new List<short> { 7 }, 1, new List<short>(), 3, 0, 0, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(3, 9),
			(3, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(146, new List<short> { 7 }, 1, new List<short>(), 2, 0, 0, 0, 0, 0, new short[0], (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(147, new List<short> { 7 }, 1, new List<short>(), 1, 0, 0, 0, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(148, new List<short> { 7 }, 1, new List<short>(), 0, 0, 0, 0, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(1, 3),
			(1, 3)
		}));
		_dataArray.Add(new RandomEnemyItem(149, new List<short> { 8 }, 1, new List<short>(), 7, 40, 40, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(150, new List<short> { 8 }, 1, new List<short>(), 6, 0, 0, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(4, 12),
			(4, 12)
		}));
		_dataArray.Add(new RandomEnemyItem(151, new List<short> { 8 }, 1, new List<short>(), 5, 0, 0, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(4, 12),
			(4, 12)
		}));
		_dataArray.Add(new RandomEnemyItem(152, new List<short> { 8 }, 1, new List<short>(), 4, 0, 0, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(3, 9),
			(3, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(153, new List<short> { 8 }, 1, new List<short>(), 3, 0, 0, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(3, 9),
			(3, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(154, new List<short> { 8 }, 1, new List<short>(), 2, 0, 0, 0, 0, 0, new short[0], (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(155, new List<short> { 8 }, 1, new List<short>(), 1, 0, 0, 0, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(156, new List<short> { 8 }, 1, new List<short>(), 0, 0, 0, 0, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(1, 3),
			(1, 3)
		}));
		_dataArray.Add(new RandomEnemyItem(157, new List<short> { 9 }, 1, new List<short>(), 7, 40, 40, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(158, new List<short> { 9 }, 1, new List<short>(), 6, 0, 0, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(4, 12),
			(4, 12)
		}));
		_dataArray.Add(new RandomEnemyItem(159, new List<short> { 9 }, 1, new List<short>(), 5, 0, 0, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(4, 12),
			(4, 12)
		}));
		_dataArray.Add(new RandomEnemyItem(160, new List<short> { 9 }, 1, new List<short>(), 4, 0, 0, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(3, 9),
			(3, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(161, new List<short> { 9 }, 1, new List<short>(), 3, 0, 0, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(3, 9),
			(3, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(162, new List<short> { 9 }, 1, new List<short>(), 2, 0, 0, 0, 0, 0, new short[0], (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(163, new List<short> { 9 }, 1, new List<short>(), 1, 0, 0, 0, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(164, new List<short> { 9 }, 1, new List<short>(), 0, 0, 0, 0, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(1, 3),
			(1, 3)
		}));
		_dataArray.Add(new RandomEnemyItem(165, new List<short> { 10 }, 1, new List<short>(), 7, 40, 40, 0, 88, 3, new short[6] { 6, 15, 24, 33, 42, 51 }, (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(166, new List<short> { 10 }, 1, new List<short>(), 6, 0, 0, 0, 44, 3, new short[6] { 5, 14, 23, 32, 41, 50 }, (75, 190), new(int, int)[2]
		{
			(4, 12),
			(4, 12)
		}));
		_dataArray.Add(new RandomEnemyItem(167, new List<short> { 10 }, 1, new List<short>(), 5, 0, 0, 0, 40, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (70, 180), new(int, int)[2]
		{
			(4, 12),
			(4, 12)
		}));
		_dataArray.Add(new RandomEnemyItem(168, new List<short> { 10 }, 1, new List<short>(), 4, 0, 0, 0, 36, 2, new short[6] { 3, 12, 21, 30, 39, 48 }, (65, 170), new(int, int)[2]
		{
			(3, 9),
			(3, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(169, new List<short> { 10 }, 1, new List<short>(), 3, 0, 0, 0, 32, 2, new short[6] { 2, 11, 20, 29, 38, 47 }, (60, 160), new(int, int)[2]
		{
			(3, 9),
			(3, 9)
		}));
		_dataArray.Add(new RandomEnemyItem(170, new List<short> { 10 }, 1, new List<short>(), 2, 0, 0, 0, 28, 2, new short[6] { 1, 10, 19, 28, 37, 46 }, (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(171, new List<short> { 10 }, 1, new List<short>(), 1, 0, 0, 0, 24, 1, new short[6] { 0, 9, 18, 27, 36, 45 }, (50, 140), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(172, new List<short> { 10 }, 1, new List<short>(), 0, 0, 0, 0, 20, 1, new short[6] { 0, 9, 18, 27, 36, 45 }, (45, 130), new(int, int)[2]
		{
			(1, 3),
			(1, 3)
		}));
		_dataArray.Add(new RandomEnemyItem(173, new List<short> { 11 }, 1, new List<short>(), 7, 40, 40, 0, 56, 3, new short[3] { 6, 33, 42 }, (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(174, new List<short> { 11 }, 1, new List<short>(), 6, 0, 0, 0, 28, 3, new short[3] { 5, 32, 41 }, (75, 190), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(175, new List<short> { 11 }, 1, new List<short>(), 5, 0, 0, 0, 24, 3, new short[3] { 4, 31, 40 }, (70, 180), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(176, new List<short> { 11 }, 1, new List<short>(), 4, 0, 0, 0, 20, 2, new short[3] { 3, 30, 39 }, (65, 170), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(177, new List<short> { 11 }, 1, new List<short>(), 3, 0, 0, 0, 16, 2, new short[3] { 2, 29, 38 }, (60, 160), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(178, new List<short> { 11 }, 1, new List<short>(), 2, 0, 0, 0, 12, 2, new short[3] { 1, 28, 37 }, (55, 150), new(int, int)[2]
		{
			(2, 4),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(179, new List<short> { 11 }, 1, new List<short>(), 1, 0, 0, 0, 8, 1, new short[3] { 0, 27, 36 }, (50, 140), new(int, int)[2]
		{
			(2, 4),
			(3, 6)
		}));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new RandomEnemyItem(180, new List<short> { 11 }, 1, new List<short>(), 0, 0, 0, 0, 4, 1, new short[3] { 0, 27, 36 }, (45, 130), new(int, int)[2]
		{
			(1, 2),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(181, new List<short> { 12 }, 1, new List<short>(), 7, 40, 40, 0, 88, 3, new short[6] { 6, 15, 24, 33, 42, 51 }, (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(182, new List<short> { 12 }, 1, new List<short>(), 6, 0, 0, 0, 44, 3, new short[6] { 5, 14, 23, 32, 41, 50 }, (75, 190), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(183, new List<short> { 12 }, 1, new List<short>(), 5, 0, 0, 0, 40, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (70, 180), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(184, new List<short> { 12 }, 1, new List<short>(), 4, 0, 0, 0, 36, 2, new short[6] { 3, 12, 21, 30, 39, 48 }, (65, 170), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(185, new List<short> { 12 }, 1, new List<short>(), 3, 0, 0, 0, 32, 2, new short[6] { 2, 11, 20, 29, 38, 47 }, (60, 160), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(186, new List<short> { 12 }, 1, new List<short>(), 2, 0, 0, 0, 28, 2, new short[6] { 1, 10, 19, 28, 37, 46 }, (55, 150), new(int, int)[2]
		{
			(2, 4),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(187, new List<short> { 12 }, 1, new List<short>(), 1, 0, 0, 0, 24, 1, new short[6] { 0, 9, 18, 27, 36, 45 }, (50, 140), new(int, int)[2]
		{
			(2, 4),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(188, new List<short> { 12 }, 1, new List<short>(), 0, 0, 0, 0, 20, 1, new short[6] { 0, 9, 18, 27, 36, 45 }, (45, 130), new(int, int)[2]
		{
			(1, 2),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(189, new List<short> { 13 }, 1, new List<short>(), 7, 40, 40, 0, 56, 3, new short[3] { 15, 24, 51 }, (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(190, new List<short> { 13 }, 1, new List<short>(), 6, 0, 0, 0, 28, 3, new short[3] { 14, 23, 50 }, (75, 190), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(191, new List<short> { 13 }, 1, new List<short>(), 5, 0, 0, 0, 24, 3, new short[3] { 13, 22, 49 }, (70, 180), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(192, new List<short> { 13 }, 1, new List<short>(), 4, 0, 0, 0, 20, 2, new short[3] { 12, 21, 48 }, (65, 170), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(193, new List<short> { 13 }, 1, new List<short>(), 3, 0, 0, 0, 16, 2, new short[3] { 11, 20, 47 }, (60, 160), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(194, new List<short> { 13 }, 1, new List<short>(), 2, 0, 0, 0, 12, 2, new short[3] { 10, 19, 46 }, (55, 150), new(int, int)[2]
		{
			(2, 4),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(195, new List<short> { 13 }, 1, new List<short>(), 1, 0, 0, 0, 8, 1, new short[3] { 9, 18, 45 }, (50, 140), new(int, int)[2]
		{
			(2, 4),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(196, new List<short> { 13 }, 1, new List<short>(), 0, 0, 0, 0, 4, 1, new short[3] { 9, 18, 45 }, (45, 130), new(int, int)[2]
		{
			(1, 2),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(197, new List<short> { 14 }, 1, new List<short>(), 7, 40, 40, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(198, new List<short> { 14 }, 1, new List<short>(), 6, 0, 0, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(199, new List<short> { 14 }, 1, new List<short>(), 5, 0, 0, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(200, new List<short> { 14 }, 1, new List<short>(), 4, 0, 0, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(201, new List<short> { 14 }, 1, new List<short>(), 3, 0, 0, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(202, new List<short> { 14 }, 1, new List<short>(), 2, 0, 0, 0, 0, 0, new short[0], (55, 150), new(int, int)[2]
		{
			(2, 4),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(203, new List<short> { 14 }, 1, new List<short>(), 1, 0, 0, 0, 0, 0, new short[0], (50, 140), new(int, int)[2]
		{
			(2, 4),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(204, new List<short> { 14 }, 1, new List<short>(), 0, 0, 0, 0, 0, 0, new short[0], (45, 130), new(int, int)[2]
		{
			(1, 2),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(205, new List<short> { 15 }, 1, new List<short>(), 7, 40, 40, 0, 56, 3, new short[3] { 6, 33, 42 }, (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(206, new List<short> { 15 }, 1, new List<short>(), 6, 0, 0, 0, 28, 3, new short[3] { 5, 32, 41 }, (75, 190), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(207, new List<short> { 15 }, 1, new List<short>(), 5, 0, 0, 0, 24, 3, new short[3] { 4, 31, 40 }, (70, 180), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(208, new List<short> { 15 }, 1, new List<short>(), 4, 0, 0, 0, 20, 2, new short[3] { 3, 30, 39 }, (65, 170), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(209, new List<short> { 15 }, 1, new List<short>(), 3, 0, 0, 0, 16, 2, new short[3] { 2, 29, 38 }, (60, 160), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(210, new List<short> { 15 }, 1, new List<short>(), 2, 0, 0, 0, 12, 2, new short[3] { 1, 28, 37 }, (55, 150), new(int, int)[2]
		{
			(2, 4),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(211, new List<short> { 15 }, 1, new List<short>(), 1, 0, 0, 0, 8, 1, new short[3] { 0, 27, 36 }, (50, 140), new(int, int)[2]
		{
			(2, 4),
			(3, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(212, new List<short> { 15 }, 1, new List<short>(), 0, 0, 0, 0, 4, 1, new short[3] { 0, 27, 36 }, (45, 130), new(int, int)[2]
		{
			(1, 2),
			(2, 4)
		}));
		_dataArray.Add(new RandomEnemyItem(213, new List<short> { 1 }, 1, new List<short>(), 6, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(214, new List<short> { 2 }, 1, new List<short>(), 6, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(215, new List<short> { 3 }, 1, new List<short>(), 6, 20, 20, 0, 54, 3, new short[3] { 14, 23, 50 }, (80, 200), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(216, new List<short> { 4 }, 1, new List<short>(), 6, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(217, new List<short> { 5 }, 1, new List<short>(), 6, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(5, 5),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(218, new List<short> { 6 }, 1, new List<short>(), 6, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(219, new List<short> { 7 }, 1, new List<short>(), 6, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(220, new List<short> { 8 }, 1, new List<short>(), 6, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(221, new List<short> { 9 }, 1, new List<short>(), 6, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(222, new List<short> { 10 }, 1, new List<short>(), 6, 20, 20, 0, 66, 3, new short[6] { 5, 14, 23, 32, 41, 50 }, (80, 200), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(223, new List<short> { 11 }, 1, new List<short>(), 6, 20, 20, 0, 42, 3, new short[3] { 5, 32, 41 }, (80, 200), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(224, new List<short> { 12 }, 1, new List<short>(), 6, 20, 20, 0, 66, 3, new short[6] { 5, 14, 23, 32, 41, 50 }, (80, 200), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(225, new List<short> { 13 }, 1, new List<short>(), 6, 20, 20, 0, 42, 3, new short[3] { 14, 23, 50 }, (80, 200), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(226, new List<short> { 14 }, 1, new List<short>(), 6, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(227, new List<short> { 15 }, 1, new List<short>(), 6, 20, 20, 0, 42, 3, new short[3] { 5, 32, 41 }, (80, 200), new(int, int)[2]
		{
			(4, 8),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(228, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 3, new List<short>(), 2, 40, 40, 0, 36, 2, new short[6] { 3, 12, 21, 30, 39, 48 }, (60, 160), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(229, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 3, new List<short>(), 3, 40, 40, 0, 40, 3, new short[6] { 4, 13, 22, 31, 40, 49 }, (65, 170), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(230, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 3, new List<short>(), 4, 40, 40, 0, 44, 3, new short[6] { 5, 14, 23, 32, 41, 50 }, (70, 180), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(231, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 3, new List<short>(), 5, 40, 40, 0, 66, 3, new short[6] { 5, 14, 23, 32, 41, 50 }, (75, 190), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(232, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 3, new List<short>(), 6, 40, 40, 0, 88, 3, new short[6] { 6, 15, 24, 33, 42, 51 }, (80, 200), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(233, new List<short> { 2, 3, 7, 8, 12, 13 }, 2, new List<short>(), 2, 30, -20, 12, 8, 2, new short[3] { 11, 20, 47 }, (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(234, new List<short> { 2, 3, 7, 8, 12, 13 }, 2, new List<short>(), 2, 30, -20, 12, 8, 2, new short[3] { 11, 20, 47 }, (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(235, new List<short> { 2, 3, 7, 8, 12, 13 }, 2, new List<short>(), 3, 30, -20, 12, 8, 2, new short[3] { 11, 20, 47 }, (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(236, new List<short> { 2, 3, 7, 8, 12, 13 }, 2, new List<short>(), 3, 30, -20, 12, 8, 2, new short[3] { 11, 20, 47 }, (55, 150), new(int, int)[2]
		{
			(2, 6),
			(2, 6)
		}));
		_dataArray.Add(new RandomEnemyItem(237, new List<short> { 2, 3, 7, 8, 12, 13 }, 3, new List<short>(), 4, 30, -20, 60, 24, 3, new short[3] { 11, 20, 47 }, (100, 100), new(int, int)[2]
		{
			(3, 5),
			(3, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(238, new List<short> { 4 }, 1, new List<short>(), 1, 0, 0, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(239, new List<short> { 4 }, 1, new List<short>(), 2, 0, 0, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new RandomEnemyItem(240, new List<short> { 4 }, 1, new List<short>(), 3, 0, 0, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(241, new List<short> { 4 }, 1, new List<short>(), 4, 0, 0, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(242, new List<short> { 4 }, 1, new List<short>(), 5, 0, 0, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(243, new List<short> { 4 }, 1, new List<short>(), 2, 40, 40, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(244, new List<short> { 4 }, 1, new List<short>(), 3, 40, 40, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(245, new List<short> { 4 }, 1, new List<short>(), 4, 40, 40, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(246, new List<short> { 4 }, 1, new List<short>(), 5, 40, 40, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(247, new List<short> { 4 }, 1, new List<short>(), 6, 40, 40, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(248, new List<short> { 15 }, 1, new List<short>(), 1, 20, 20, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(249, new List<short> { 15 }, 1, new List<short>(), 2, 20, 20, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(250, new List<short> { 15 }, 1, new List<short>(), 3, 20, 20, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(251, new List<short> { 15 }, 1, new List<short>(), 4, 20, 20, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(252, new List<short> { 15 }, 1, new List<short>(), 5, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(253, new List<short> { 6 }, 1, new List<short>(), 1, 20, 20, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(254, new List<short> { 6 }, 1, new List<short>(), 2, 20, 20, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(255, new List<short> { 6 }, 1, new List<short>(), 3, 20, 20, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(256, new List<short> { 6 }, 1, new List<short>(), 4, 20, 20, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(257, new List<short> { 6 }, 1, new List<short>(), 5, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(258, new List<short> { 2, 7, 13 }, 1, new List<short> { 7 }, 1, 20, 20, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(259, new List<short> { 2, 7, 13 }, 1, new List<short> { 7 }, 2, 20, 20, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(260, new List<short> { 2, 7, 13 }, 1, new List<short> { 7 }, 3, 20, 20, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(261, new List<short> { 2, 7, 13 }, 1, new List<short> { 7 }, 4, 20, 20, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(262, new List<short> { 2, 7, 13 }, 1, new List<short> { 7 }, 5, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(263, new List<short> { 5, 6, 14 }, 1, new List<short> { 8 }, 1, 20, 20, 0, 0, 0, new short[0], (60, 160), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(264, new List<short> { 5, 6, 14 }, 1, new List<short> { 8 }, 2, 20, 20, 0, 0, 0, new short[0], (65, 170), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(265, new List<short> { 5, 6, 14 }, 1, new List<short> { 8 }, 3, 20, 20, 0, 0, 0, new short[0], (70, 180), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(266, new List<short> { 5, 6, 14 }, 1, new List<short> { 8 }, 4, 20, 20, 0, 0, 0, new short[0], (75, 190), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(267, new List<short> { 5, 6, 14 }, 1, new List<short> { 8 }, 5, 20, 20, 0, 0, 0, new short[0], (80, 200), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(268, new List<short> { 1, 2, 3, 4, 5 }, 1, new List<short>(), 2, 20, 20, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(3, 6),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(269, new List<short> { 1, 2, 3, 4, 5 }, 1, new List<short>(), 4, 40, 40, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(4, 8),
			(4, 8)
		}));
		_dataArray.Add(new RandomEnemyItem(270, new List<short> { 1, 2, 3, 4, 5 }, 1, new List<short>(), 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(271, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 3, new List<short>(), 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(272, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 3, new List<short>(), 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(273, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 3, new List<short>(), 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(274, new List<short>
		{
			1, 2, 4, 6, 7, 8, 10, 11, 12, 14,
			15
		}, 3, new List<short> { 3 }, 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(275, new List<short> { 1, 2, 3, 7, 8, 12, 13, 15 }, 3, new List<short> { 4 }, 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(276, new List<short> { 5, 10, 15 }, 3, new List<short> { 5 }, 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(277, new List<short> { 2, 4, 5, 7, 9, 12, 13 }, 3, new List<short> { 7 }, 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(278, new List<short> { 5, 6, 9, 11, 14 }, 3, new List<short> { 8 }, 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(279, new List<short> { 1, 6, 9 }, 3, new List<short> { 9 }, 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(280, new List<short> { 10, 13, 14, 15 }, 3, new List<short> { 6 }, 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(281, new List<short> { 2, 7, 11 }, 3, new List<short> { 10 }, 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(282, new List<short> { 4, 12 }, 3, new List<short> { 11 }, 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(283, new List<short> { 3, 9 }, 3, new List<short> { 12 }, 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
		_dataArray.Add(new RandomEnemyItem(284, new List<short> { 3, 8 }, 3, new List<short> { 13 }, 6, 60, 60, 0, 0, 0, new short[0], (100, 100), new(int, int)[2]
		{
			(5, 5),
			(5, 5)
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<RandomEnemyItem>(285);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
	}
}
