using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class CombatState : ConfigData<CombatStateItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 金针伐脉功·正
		/// </summary>
		public const short JinZhenFaMaiGongDirect = 0;

		/// <summary>
		/// 金针伐脉功·逆
		/// </summary>
		public const short JinZhenFaMaiGongReverse = 1;

		/// <summary>
		/// 离魂功·正
		/// </summary>
		public const short LiHunGongDirect = 2;

		/// <summary>
		/// 离魂功·逆
		/// </summary>
		public const short LiHunGongReverse = 3;

		/// <summary>
		/// 大金刚拳·正增益
		/// </summary>
		public const short DaJinGangQuanDirectBuff = 4;

		/// <summary>
		/// 大金刚拳·正减益
		/// </summary>
		public const short DaJinGangQuanDirectDebuff = 5;

		/// <summary>
		/// 大金刚拳·逆增益
		/// </summary>
		public const short DaJinGangQuanReverseBuff = 6;

		/// <summary>
		/// 大金刚拳·逆减益
		/// </summary>
		public const short DaJinGangQuanReverseDebuff = 7;

		/// <summary>
		/// 少林一指禅·正
		/// </summary>
		public const short ShaoLinYiZhiChanDirect = 8;

		/// <summary>
		/// 少林一指禅·逆
		/// </summary>
		public const short ShaoLinYiZhiChanReverse = 9;

		/// <summary>
		/// 轻身术
		/// </summary>
		public const short QingShenShu = 10;

		/// <summary>
		/// 沾衣十八跌·正
		/// </summary>
		public const short ZhanYiShiBaDieDirect = 11;

		/// <summary>
		/// 沾衣十八跌·逆
		/// </summary>
		public const short ZhanYiShiBaDieReverse = 12;

		/// <summary>
		/// 移花接木手·正增益
		/// </summary>
		public const short YiHuaJieMuShouDirectBuff = 13;

		/// <summary>
		/// 移花接木手·正减益
		/// </summary>
		public const short YiHuaJieMuShouDirectDebuff = 14;

		/// <summary>
		/// 移花接木手·逆增益
		/// </summary>
		public const short YiHuaJieMuShouReverseBuff = 15;

		/// <summary>
		/// 移花接木手·逆减益
		/// </summary>
		public const short YiHuaJieMuShouReverseDebuff = 16;

		/// <summary>
		/// 峨眉一指禅·正
		/// </summary>
		public const short EMeiYiZhiChanDirect = 17;

		/// <summary>
		/// 峨眉一指禅·逆
		/// </summary>
		public const short EMeiYiZhiChanReverse = 18;

		/// <summary>
		/// 金顶飞仙
		/// </summary>
		public const short JinDingFeiXian = 19;

		/// <summary>
		/// 血海凝冰术·正
		/// </summary>
		public const short XueHaiNingBingShuDirect = 20;

		/// <summary>
		/// 血海凝冰术·逆
		/// </summary>
		public const short XueHaiNingBingShuReverse = 21;

		/// <summary>
		/// 太极剑法·正
		/// </summary>
		public const short TaiJiJianFaDirect = 22;

		/// <summary>
		/// 太极剑法·逆
		/// </summary>
		public const short TaiJiJianFaReverse = 23;

		/// <summary>
		/// 云床九练·正
		/// </summary>
		public const short YunChuangJiuLianDirect = 24;

		/// <summary>
		/// 云床九练·逆
		/// </summary>
		public const short YunChuangJiuLianReverse = 25;

		/// <summary>
		/// 开阖剑术·正0
		/// </summary>
		public const short KaiHeJianShuDirect0 = 26;

		/// <summary>
		/// 开阖剑术·正1
		/// </summary>
		public const short KaiHeJianShuDirect1 = 27;

		/// <summary>
		/// 开阖剑术·正2
		/// </summary>
		public const short KaiHeJianShuDirect2 = 28;

		/// <summary>
		/// 开阖剑术·正3
		/// </summary>
		public const short KaiHeJianShuDirect3 = 29;

		/// <summary>
		/// 开阖剑术·逆0
		/// </summary>
		public const short KaiHeJianShuReverse0 = 30;

		/// <summary>
		/// 开阖剑术·逆1
		/// </summary>
		public const short KaiHeJianShuReverse1 = 31;

		/// <summary>
		/// 开阖剑术·逆2
		/// </summary>
		public const short KaiHeJianShuReverse2 = 32;

		/// <summary>
		/// 开阖剑术·逆3
		/// </summary>
		public const short KaiHeJianShuReverse3 = 33;

		/// <summary>
		/// 御风符·正
		/// </summary>
		public const short YuFengFuDirect = 34;

		/// <summary>
		/// 御风符·逆
		/// </summary>
		public const short YuFengFuReverse = 35;

		/// <summary>
		/// 不思归
		/// </summary>
		public const short BuSiGui = 36;

		/// <summary>
		/// 凤来仪·正
		/// </summary>
		public const short FengLaiYiDirect = 37;

		/// <summary>
		/// 凤来仪·逆
		/// </summary>
		public const short FengLaiYiReverse = 38;

		/// <summary>
		/// 嫘祖剥茧式·正
		/// </summary>
		public const short LeiZuBoJianShiDirect = 39;

		/// <summary>
		/// 嫘祖剥茧式·逆
		/// </summary>
		public const short LeiZuBoJianShiReverse = 40;

		/// <summary>
		/// 大太阴一明指
		/// </summary>
		public const short DaTaiYinYiMingZhi = 41;

		/// <summary>
		/// 断魂幽吟曲
		/// </summary>
		public const short DuanHunYouYinQu = 42;

		/// <summary>
		/// 柴山擒跌手·正
		/// </summary>
		public const short ChaiShanQinDieShouDirect = 43;

		/// <summary>
		/// 柴山擒跌手·逆
		/// </summary>
		public const short ChaiShanQinDieShouReverse = 44;

		/// <summary>
		/// 威灵仙化骨掌·正
		/// </summary>
		public const short WeiLingXianHuaGuZhangDirect = 45;

		/// <summary>
		/// 威灵仙化骨掌·逆
		/// </summary>
		public const short WeiLingXianHuaGuZhangReverse = 46;

		/// <summary>
		/// 磕金震玉小八式·正增益
		/// </summary>
		public const short KeJinZhenYuXiaoBaShiDirectBuff = 47;

		/// <summary>
		/// 磕金震玉小八式·正减益
		/// </summary>
		public const short KeJinZhenYuXiaoBaShiDirectDebuff = 48;

		/// <summary>
		/// 磕金震玉小八式·逆增益
		/// </summary>
		public const short KeJinZhenYuXiaoBaShiReverseBuff = 49;

		/// <summary>
		/// 磕金震玉小八式·逆减益
		/// </summary>
		public const short KeJinZhenYuXiaoBaShiReverseDebuff = 50;

		/// <summary>
		/// 飞山断海大八式·正
		/// </summary>
		public const short FeiShanDuanHaiDaBaShiDirect = 51;

		/// <summary>
		/// 飞山断海大八式·逆
		/// </summary>
		public const short FeiShanDuanHaiDaBaShiReverse = 52;

		/// <summary>
		/// 五怒手·正
		/// </summary>
		public const short WuNuShouDirect = 53;

		/// <summary>
		/// 五怒手·逆
		/// </summary>
		public const short WuNuShouReverse = 54;

		/// <summary>
		/// 金刚黑砂掌·正
		/// </summary>
		public const short JinGangHeiShaZhangDirect = 55;

		/// <summary>
		/// 金刚黑砂掌·逆
		/// </summary>
		public const short JinGangHeiShaZhangReverse = 56;

		/// <summary>
		/// 拿脉功·正
		/// </summary>
		public const short NaMaiGongDirect = 57;

		/// <summary>
		/// 拿脉功·逆
		/// </summary>
		public const short NaMaiGongReverse = 58;

		/// <summary>
		/// 勾镰剑法·正
		/// </summary>
		public const short GouLianJianFaDirect = 59;

		/// <summary>
		/// 勾镰剑法·逆
		/// </summary>
		public const short GouLianJianFaReverse = 60;

		/// <summary>
		/// 玉索倒悬·正
		/// </summary>
		public const short YuSuoDaoXuanDirect = 61;

		/// <summary>
		/// 玉索倒悬·逆
		/// </summary>
		public const short YuSuoDaoXuanReverse = 62;

		/// <summary>
		/// 天蛇翻
		/// </summary>
		public const short TianSheFan = 63;

		/// <summary>
		/// 血偶破煞法·正
		/// </summary>
		public const short XueOuPoShaFaDirect = 64;

		/// <summary>
		/// 血偶破煞法·逆
		/// </summary>
		public const short XueOuPoShaFaReverse = 65;

		/// <summary>
		/// 血偶破煞·正
		/// </summary>
		public const short XueOuPoShaDirect = 66;

		/// <summary>
		/// 血偶破煞·逆
		/// </summary>
		public const short XueOuPoShaReverse = 67;

		/// <summary>
		/// 天渊纵
		/// </summary>
		public const short TianYuanZong = 68;

		/// <summary>
		/// 赤青神火劲·正增益
		/// </summary>
		public const short ChiQingShenHuoJinDirectBuff = 69;

		/// <summary>
		/// 赤青神火劲·正减益
		/// </summary>
		public const short ChiQingShenHuoJinDirectDebuff = 70;

		/// <summary>
		/// 赤青神火劲·逆增益
		/// </summary>
		public const short ChiQingShenHuoJinReverseBuff = 71;

		/// <summary>
		/// 赤青神火劲·逆减益
		/// </summary>
		public const short ChiQingShenHuoJinReverseDebuff = 72;

		/// <summary>
		/// 蝎子勾魂脚·正
		/// </summary>
		public const short XieZiGouHunJiaoDirect = 73;

		/// <summary>
		/// 蝎子勾魂脚·逆
		/// </summary>
		public const short XieZiGouHunJiaoReverse = 74;

		/// <summary>
		/// 伏君忧虞·力道
		/// </summary>
		public const short FuJunYouYuHit0 = 75;

		/// <summary>
		/// 伏君忧虞·精妙
		/// </summary>
		public const short FuJunYouYuHit1 = 76;

		/// <summary>
		/// 伏君忧虞·迅疾
		/// </summary>
		public const short FuJunYouYuHit2 = 77;

		/// <summary>
		/// 伏君忧虞·动心
		/// </summary>
		public const short FuJunYouYuHit3 = 78;

		/// <summary>
		/// 伏君忧虞·卸力
		/// </summary>
		public const short FuJunYouYuAvoid0 = 79;

		/// <summary>
		/// 伏君忧虞·拆招
		/// </summary>
		public const short FuJunYouYuAvoid1 = 80;

		/// <summary>
		/// 伏君忧虞·闪避
		/// </summary>
		public const short FuJunYouYuAvoid2 = 81;

		/// <summary>
		/// 伏君忧虞·守心
		/// </summary>
		public const short FuJunYouYuAvoid3 = 82;

		/// <summary>
		/// 解封·架势恢复
		/// </summary>
		public const short JieFeng0 = 83;

		/// <summary>
		/// 解封·提气恢复
		/// </summary>
		public const short JieFeng1 = 84;

		/// <summary>
		/// 解封·移动速度
		/// </summary>
		public const short JieFeng2 = 85;

		/// <summary>
		/// 解封·步伐稳健
		/// </summary>
		public const short JieFeng3 = 86;

		/// <summary>
		/// 解封·施展速度
		/// </summary>
		public const short JieFeng4 = 87;

		/// <summary>
		/// 解封·引气冲关
		/// </summary>
		public const short JieFeng5 = 88;

		/// <summary>
		/// 解封·兵器切换
		/// </summary>
		public const short JieFeng6 = 89;

		/// <summary>
		/// 解封·攻击速度
		/// </summary>
		public const short JieFeng7 = 90;

		/// <summary>
		/// 解封·内功发挥
		/// </summary>
		public const short JieFeng8 = 91;

		/// <summary>
		/// 解封·调息吐纳
		/// </summary>
		public const short JieFeng9 = 92;

		/// <summary>
		/// 试锋
		/// </summary>
		public const short ShiFeng = 93;

		/// <summary>
		/// 拆刃增益·架势恢复
		/// </summary>
		public const short ChaiRenBuff0 = 94;

		/// <summary>
		/// 拆刃增益·提气恢复
		/// </summary>
		public const short ChaiRenBuff1 = 95;

		/// <summary>
		/// 拆刃增益·移动速度
		/// </summary>
		public const short ChaiRenBuff2 = 96;

		/// <summary>
		/// 拆刃增益·步伐稳健
		/// </summary>
		public const short ChaiRenBuff3 = 97;

		/// <summary>
		/// 拆刃增益·施展速度
		/// </summary>
		public const short ChaiRenBuff4 = 98;

		/// <summary>
		/// 拆刃增益·引气冲关
		/// </summary>
		public const short ChaiRenBuff5 = 99;

		/// <summary>
		/// 拆刃增益·兵器切换
		/// </summary>
		public const short ChaiRenBuff6 = 100;

		/// <summary>
		/// 拆刃增益·攻击速度
		/// </summary>
		public const short ChaiRenBuff7 = 101;

		/// <summary>
		/// 拆刃增益·内功发挥
		/// </summary>
		public const short ChaiRenBuff8 = 102;

		/// <summary>
		/// 拆刃增益·调息吐纳
		/// </summary>
		public const short ChaiRenBuff9 = 103;

		/// <summary>
		/// 拆刃减益·架势恢复
		/// </summary>
		public const short ChaiRenDebuff0 = 104;

		/// <summary>
		/// 拆刃减益·提气恢复
		/// </summary>
		public const short ChaiRenDebuff1 = 105;

		/// <summary>
		/// 拆刃减益·移动速度
		/// </summary>
		public const short ChaiRenDebuff2 = 106;

		/// <summary>
		/// 拆刃减益·步伐稳健
		/// </summary>
		public const short ChaiRenDebuff3 = 107;

		/// <summary>
		/// 拆刃减益·施展速度
		/// </summary>
		public const short ChaiRenDebuff4 = 108;

		/// <summary>
		/// 拆刃减益·引气冲关
		/// </summary>
		public const short ChaiRenDebuff5 = 109;

		/// <summary>
		/// 拆刃减益·兵器切换
		/// </summary>
		public const short ChaiRenDebuff6 = 110;

		/// <summary>
		/// 拆刃减益·攻击速度
		/// </summary>
		public const short ChaiRenDebuff7 = 111;

		/// <summary>
		/// 拆刃减益·内功发挥
		/// </summary>
		public const short ChaiRenDebuff8 = 112;

		/// <summary>
		/// 拆刃减益·调息吐纳
		/// </summary>
		public const short ChaiRenDebuff9 = 113;

		/// <summary>
		/// 夺神·增益
		/// </summary>
		public const short DuoShenBuff = 114;

		/// <summary>
		/// 夺神·减益
		/// </summary>
		public const short DuoShenDebuff = 115;

		/// <summary>
		/// 心神动摇
		/// </summary>
		public const short ReduceMindAvoid = 116;

		/// <summary>
		/// 浑心无字
		/// </summary>
		public const short LegendaryBook0 = 117;

		/// <summary>
		/// 白衣行化
		/// </summary>
		public const short LegendaryBook1 = 118;

		/// <summary>
		/// 大全千法
		/// </summary>
		public const short LegendaryBook2 = 119;

		/// <summary>
		/// 象龙演画
		/// </summary>
		public const short LegendaryBook3 = 120;

		/// <summary>
		/// 心观残笺
		/// </summary>
		public const short LegendaryBook4 = 121;

		/// <summary>
		/// 八埏至宝
		/// </summary>
		public const short LegendaryBook5 = 122;

		/// <summary>
		/// 化影奇功
		/// </summary>
		public const short LegendaryBook6 = 123;

		/// <summary>
		/// 无名神剑
		/// </summary>
		public const short LegendaryBook7 = 124;

		/// <summary>
		/// 十杀魔罗
		/// </summary>
		public const short LegendaryBook8 = 125;

		/// <summary>
		/// 一画开天
		/// </summary>
		public const short LegendaryBook9 = 126;

		/// <summary>
		/// 无先玄元
		/// </summary>
		public const short LegendaryBook10 = 127;

		/// <summary>
		/// 九似真藏
		/// </summary>
		public const short LegendaryBook11 = 128;

		/// <summary>
		/// 天通神术
		/// </summary>
		public const short LegendaryBook12 = 129;

		/// <summary>
		/// 神女绝音
		/// </summary>
		public const short LegendaryBook13 = 130;

		/// <summary>
		/// 凌绝顶
		/// </summary>
		public const short SavageSkillMountain = 131;

		/// <summary>
		/// 一线天
		/// </summary>
		public const short SavageSkillCanyon = 132;

		/// <summary>
		/// 九折径
		/// </summary>
		public const short SavageSkillHill = 133;

		/// <summary>
		/// 苍茫野
		/// </summary>
		public const short SavageSkillField = 134;

		/// <summary>
		/// 连山翠
		/// </summary>
		public const short SavageSkillWoodland = 135;

		/// <summary>
		/// 空行涧
		/// </summary>
		public const short SavageSkillRiverBeach = 136;

		/// <summary>
		/// 烟波荡
		/// </summary>
		public const short SavageSkillLake = 137;

		/// <summary>
		/// 森罗嶂
		/// </summary>
		public const short SavageSkillJungle = 138;

		/// <summary>
		/// 岩穴暝
		/// </summary>
		public const short SavageSkillCave = 139;

		/// <summary>
		/// 幽潭沉
		/// </summary>
		public const short SavageSkillSwamp = 140;

		/// <summary>
		/// 桃花源
		/// </summary>
		public const short SavageSkillTaoYuan = 141;

		/// <summary>
		/// 无命奇毒0
		/// </summary>
		public const short WuMingQiDu0 = 142;

		/// <summary>
		/// 无命奇毒1
		/// </summary>
		public const short WuMingQiDu1 = 143;

		/// <summary>
		/// 无命奇毒2
		/// </summary>
		public const short WuMingQiDu2 = 144;

		/// <summary>
		/// 无命奇毒3
		/// </summary>
		public const short WuMingQiDu3 = 145;

		/// <summary>
		/// 坏血断肠
		/// </summary>
		public const short HuaiXueDuanChang = 146;

		/// <summary>
		/// 剧恶深苦
		/// </summary>
		public const short JuEShenKu = 147;

		/// <summary>
		/// 猴子
		/// </summary>
		public const short Monkey0 = 148;

		/// <summary>
		/// 恶鹰
		/// </summary>
		public const short Eagle0 = 149;

		/// <summary>
		/// 野猪
		/// </summary>
		public const short Pig0 = 150;

		/// <summary>
		/// 棕熊
		/// </summary>
		public const short Bear0 = 151;

		/// <summary>
		/// 野牛
		/// </summary>
		public const short Bull0 = 152;

		/// <summary>
		/// 巨蛇
		/// </summary>
		public const short Snake0 = 153;

		/// <summary>
		/// 花豹
		/// </summary>
		public const short Jaguar0 = 154;

		/// <summary>
		/// 狮子
		/// </summary>
		public const short Lion0 = 155;

		/// <summary>
		/// 老虎
		/// </summary>
		public const short Tiger0 = 156;

		/// <summary>
		/// 灵猴
		/// </summary>
		public const short Monkey1 = 157;

		/// <summary>
		/// 金鹏
		/// </summary>
		public const short Eagle1 = 158;

		/// <summary>
		/// 玄猪
		/// </summary>
		public const short Pig1 = 159;

		/// <summary>
		/// 白熊
		/// </summary>
		public const short Bear1 = 160;

		/// <summary>
		/// 夔牛
		/// </summary>
		public const short Bull1 = 161;

		/// <summary>
		/// 巴蟒
		/// </summary>
		public const short Snake1 = 162;

		/// <summary>
		/// 黑豹
		/// </summary>
		public const short Jaguar1 = 163;

		/// <summary>
		/// 金狮
		/// </summary>
		public const short Lion1 = 164;

		/// <summary>
		/// 白虎
		/// </summary>
		public const short Tiger1 = 165;

		/// <summary>
		/// 七轮感应法·正
		/// </summary>
		public const short QiLunGanYingFaDirect = 166;

		/// <summary>
		/// 七轮感应法·逆
		/// </summary>
		public const short QiLunGanYingFaReverse = 167;

		/// <summary>
		/// 白蛟
		/// </summary>
		public const short JiaoWhite = 168;

		/// <summary>
		/// 黑蛟
		/// </summary>
		public const short JiaoBlack = 169;

		/// <summary>
		/// 青蛟
		/// </summary>
		public const short JiaoGreen = 170;

		/// <summary>
		/// 赤蛟
		/// </summary>
		public const short JiaoRed = 171;

		/// <summary>
		/// 黄蛟
		/// </summary>
		public const short JiaoYellow = 172;

		/// <summary>
		/// 白黑蛟
		/// </summary>
		public const short JiaoWB = 173;

		/// <summary>
		/// 白青蛟
		/// </summary>
		public const short JiaoWG = 174;

		/// <summary>
		/// 白赤蛟
		/// </summary>
		public const short JiaoWR = 175;

		/// <summary>
		/// 白黄蛟
		/// </summary>
		public const short JiaoWY = 176;

		/// <summary>
		/// 黑青蛟
		/// </summary>
		public const short JiaoBG = 177;

		/// <summary>
		/// 黑赤蛟
		/// </summary>
		public const short JiaoBR = 178;

		/// <summary>
		/// 黑黄蛟
		/// </summary>
		public const short JiaoBY = 179;

		/// <summary>
		/// 青赤蛟
		/// </summary>
		public const short JiaoGR = 180;

		/// <summary>
		/// 青黄蛟
		/// </summary>
		public const short JiaoGY = 181;

		/// <summary>
		/// 赤黄蛟
		/// </summary>
		public const short JiaoRY = 182;

		/// <summary>
		/// 白黑青蛟
		/// </summary>
		public const short JiaoWBG = 183;

		/// <summary>
		/// 白黑赤蛟
		/// </summary>
		public const short JiaoWBR = 184;

		/// <summary>
		/// 白黑黄蛟
		/// </summary>
		public const short JiaoWBY = 185;

		/// <summary>
		/// 白青赤蛟
		/// </summary>
		public const short JiaoWGR = 186;

		/// <summary>
		/// 白青黄蛟
		/// </summary>
		public const short JiaoWGY = 187;

		/// <summary>
		/// 白赤黄蛟
		/// </summary>
		public const short JiaoWRY = 188;

		/// <summary>
		/// 黑青赤蛟
		/// </summary>
		public const short JiaoBGR = 189;

		/// <summary>
		/// 黑青黄蛟
		/// </summary>
		public const short JiaoBGY = 190;

		/// <summary>
		/// 黑赤黄蛟
		/// </summary>
		public const short JiaoBRY = 191;

		/// <summary>
		/// 青赤黄蛟
		/// </summary>
		public const short JiaoGRY = 192;

		/// <summary>
		/// 白黑青赤蛟
		/// </summary>
		public const short JiaoWBGR = 193;

		/// <summary>
		/// 白黑青黄蛟
		/// </summary>
		public const short JiaoWBGY = 194;

		/// <summary>
		/// 白黑赤黄蛟
		/// </summary>
		public const short JiaoWBRY = 195;

		/// <summary>
		/// 白青赤黄蛟
		/// </summary>
		public const short JiaoWGRY = 196;

		/// <summary>
		/// 黑青赤黄蛟
		/// </summary>
		public const short JiaoBGRY = 197;

		/// <summary>
		/// 白青赤黄黑蛟
		/// </summary>
		public const short JiaoWGRYB = 198;

		/// <summary>
		/// 囚牛
		/// </summary>
		public const short Qiuniu = 199;

		/// <summary>
		/// 睚眦
		/// </summary>
		public const short Yazi = 200;

		/// <summary>
		/// 嘲风
		/// </summary>
		public const short Chaofeng = 201;

		/// <summary>
		/// 蒲牢
		/// </summary>
		public const short Pulao = 202;

		/// <summary>
		/// 狻猊
		/// </summary>
		public const short Suanni = 203;

		/// <summary>
		/// 霸下
		/// </summary>
		public const short Baxia = 204;

		/// <summary>
		/// 狴犴
		/// </summary>
		public const short Bian = 205;

		/// <summary>
		/// 负屃
		/// </summary>
		public const short Fuxi = 206;

		/// <summary>
		/// 螭吻
		/// </summary>
		public const short Chiwen = 207;

		/// <summary>
		/// 六合刀法·正
		/// </summary>
		public const short LiuHeDaoFaDirect = 208;

		/// <summary>
		/// 六合刀法·逆
		/// </summary>
		public const short LiuHeDaoFaReverse = 209;

		/// <summary>
		/// 鸩羽香·正
		/// </summary>
		public const short ZhenYuXiangDirect = 210;

		/// <summary>
		/// 鸩羽香·逆
		/// </summary>
		public const short ZhenYuXiangReverse = 211;

		/// <summary>
		/// 阴风蝎子手·正
		/// </summary>
		public const short YinFengXieZiShouDirect = 212;

		/// <summary>
		/// 阴风蝎子手·逆
		/// </summary>
		public const short YinFengXieZiShouReverse = 213;

		/// <summary>
		/// 寒冰刺骨法·正
		/// </summary>
		public const short HanBingCiGuFaDirect = 214;

		/// <summary>
		/// 寒冰刺骨法·逆
		/// </summary>
		public const short HanBingCiGuFaReverse = 215;

		/// <summary>
		/// 掌血功·正
		/// </summary>
		public const short ZhangXueGongDirect = 216;

		/// <summary>
		/// 掌血功·逆
		/// </summary>
		public const short ZhangXueGongReverse = 217;

		/// <summary>
		/// 黄泉指·正
		/// </summary>
		public const short HuangQuanZhiDirect = 218;

		/// <summary>
		/// 黄泉指·逆
		/// </summary>
		public const short HuangQuanZhiReverse = 219;

		/// <summary>
		/// 大花曼陀罗指·正
		/// </summary>
		public const short DaHuaManTuoLuoZhiDirect = 220;

		/// <summary>
		/// 大花曼陀罗指·逆
		/// </summary>
		public const short DaHuaManTuoLuoZhiReverse = 221;

		/// <summary>
		/// 琼花叹·正
		/// </summary>
		public const short QiongHuaTanDirect = 222;

		/// <summary>
		/// 琼花叹·逆
		/// </summary>
		public const short QiongHuaTanReverse = 223;

		/// <summary>
		/// 胸中死气
		/// </summary>
		public const short XiongZhongSiQi = 224;

		/// <summary>
		/// 死气夺魂
		/// </summary>
		public const short SiQiDuoHun = 225;

		/// <summary>
		/// 少林遗力
		/// </summary>
		public const short LegacyPowerShaolin = 226;

		/// <summary>
		/// 峨眉遗力
		/// </summary>
		public const short LegacyPowerEmei = 227;

		/// <summary>
		/// 百花遗力
		/// </summary>
		public const short LegacyPowerBaihua = 228;

		/// <summary>
		/// 武当遗力
		/// </summary>
		public const short LegacyPowerWudang = 229;

		/// <summary>
		/// 元山遗力
		/// </summary>
		public const short LegacyPowerYuanshan = 230;

		/// <summary>
		/// 狮相遗力
		/// </summary>
		public const short LegacyPowerShixiang = 231;

		/// <summary>
		/// 然山遗力
		/// </summary>
		public const short LegacyPowerRanshan = 232;

		/// <summary>
		/// 璇女遗力
		/// </summary>
		public const short LegacyPowerXuannv = 233;

		/// <summary>
		/// 铸剑遗力
		/// </summary>
		public const short LegacyPowerZhujian = 234;

		/// <summary>
		/// 空桑遗力
		/// </summary>
		public const short LegacyPowerKongsang = 235;

		/// <summary>
		/// 金刚遗力
		/// </summary>
		public const short LegacyPowerJingang = 236;

		/// <summary>
		/// 五仙遗力
		/// </summary>
		public const short LegacyPowerWuxian = 237;

		/// <summary>
		/// 界青遗力
		/// </summary>
		public const short LegacyPowerJieqing = 238;

		/// <summary>
		/// 伏龙遗力
		/// </summary>
		public const short LegacyPowerFulong = 239;

		/// <summary>
		/// 血犼遗力
		/// </summary>
		public const short LegacyPowerXuehou = 240;

		/// <summary>
		/// 落魂钟
		/// </summary>
		public const short SoulWitheringBell = 241;

		/// <summary>
		/// 落魂钟转移后
		/// </summary>
		public const short SoulWitheringBellAfterTransfer = 242;

		/// <summary>
		/// 狩猎野兽
		/// </summary>
		public const short HuntingBeasts = 243;

		/// <summary>
		/// 天铸玄铁册·正
		/// </summary>
		public const short TianZhuXuanTieCeDirect = 244;

		/// <summary>
		/// 天铸玄铁册·逆
		/// </summary>
		public const short TianZhuXuanTieCeReverse = 245;

		/// <summary>
		/// 金刚狱石
		/// </summary>
		public const short FiveElementsStoneMetal = 246;

		/// <summary>
		/// 紫霞狱石
		/// </summary>
		public const short FiveElementsStoneWood = 247;

		/// <summary>
		/// 玄阴狱石
		/// </summary>
		public const short FiveElementsStoneWater = 248;

		/// <summary>
		/// 纯阳狱石
		/// </summary>
		public const short FiveElementsStoneFire = 249;

		/// <summary>
		/// 归元狱石
		/// </summary>
		public const short FiveElementsStoneEarth = 250;

		/// <summary>
		/// 金蚕蛊·增益
		/// </summary>
		public const short GoldenSilkwormBuff = 251;

		/// <summary>
		/// 金蚕蛊·减益
		/// </summary>
		public const short GoldenSilkwormDebuff = 252;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 金针伐脉功·正
		/// </summary>
		public static CombatStateItem JinZhenFaMaiGongDirect => Instance[(short)0];

		/// <summary>
		/// 金针伐脉功·逆
		/// </summary>
		public static CombatStateItem JinZhenFaMaiGongReverse => Instance[(short)1];

		/// <summary>
		/// 离魂功·正
		/// </summary>
		public static CombatStateItem LiHunGongDirect => Instance[(short)2];

		/// <summary>
		/// 离魂功·逆
		/// </summary>
		public static CombatStateItem LiHunGongReverse => Instance[(short)3];

		/// <summary>
		/// 大金刚拳·正增益
		/// </summary>
		public static CombatStateItem DaJinGangQuanDirectBuff => Instance[(short)4];

		/// <summary>
		/// 大金刚拳·正减益
		/// </summary>
		public static CombatStateItem DaJinGangQuanDirectDebuff => Instance[(short)5];

		/// <summary>
		/// 大金刚拳·逆增益
		/// </summary>
		public static CombatStateItem DaJinGangQuanReverseBuff => Instance[(short)6];

		/// <summary>
		/// 大金刚拳·逆减益
		/// </summary>
		public static CombatStateItem DaJinGangQuanReverseDebuff => Instance[(short)7];

		/// <summary>
		/// 少林一指禅·正
		/// </summary>
		public static CombatStateItem ShaoLinYiZhiChanDirect => Instance[(short)8];

		/// <summary>
		/// 少林一指禅·逆
		/// </summary>
		public static CombatStateItem ShaoLinYiZhiChanReverse => Instance[(short)9];

		/// <summary>
		/// 轻身术
		/// </summary>
		public static CombatStateItem QingShenShu => Instance[(short)10];

		/// <summary>
		/// 沾衣十八跌·正
		/// </summary>
		public static CombatStateItem ZhanYiShiBaDieDirect => Instance[(short)11];

		/// <summary>
		/// 沾衣十八跌·逆
		/// </summary>
		public static CombatStateItem ZhanYiShiBaDieReverse => Instance[(short)12];

		/// <summary>
		/// 移花接木手·正增益
		/// </summary>
		public static CombatStateItem YiHuaJieMuShouDirectBuff => Instance[(short)13];

		/// <summary>
		/// 移花接木手·正减益
		/// </summary>
		public static CombatStateItem YiHuaJieMuShouDirectDebuff => Instance[(short)14];

		/// <summary>
		/// 移花接木手·逆增益
		/// </summary>
		public static CombatStateItem YiHuaJieMuShouReverseBuff => Instance[(short)15];

		/// <summary>
		/// 移花接木手·逆减益
		/// </summary>
		public static CombatStateItem YiHuaJieMuShouReverseDebuff => Instance[(short)16];

		/// <summary>
		/// 峨眉一指禅·正
		/// </summary>
		public static CombatStateItem EMeiYiZhiChanDirect => Instance[(short)17];

		/// <summary>
		/// 峨眉一指禅·逆
		/// </summary>
		public static CombatStateItem EMeiYiZhiChanReverse => Instance[(short)18];

		/// <summary>
		/// 金顶飞仙
		/// </summary>
		public static CombatStateItem JinDingFeiXian => Instance[(short)19];

		/// <summary>
		/// 血海凝冰术·正
		/// </summary>
		public static CombatStateItem XueHaiNingBingShuDirect => Instance[(short)20];

		/// <summary>
		/// 血海凝冰术·逆
		/// </summary>
		public static CombatStateItem XueHaiNingBingShuReverse => Instance[(short)21];

		/// <summary>
		/// 太极剑法·正
		/// </summary>
		public static CombatStateItem TaiJiJianFaDirect => Instance[(short)22];

		/// <summary>
		/// 太极剑法·逆
		/// </summary>
		public static CombatStateItem TaiJiJianFaReverse => Instance[(short)23];

		/// <summary>
		/// 云床九练·正
		/// </summary>
		public static CombatStateItem YunChuangJiuLianDirect => Instance[(short)24];

		/// <summary>
		/// 云床九练·逆
		/// </summary>
		public static CombatStateItem YunChuangJiuLianReverse => Instance[(short)25];

		/// <summary>
		/// 开阖剑术·正0
		/// </summary>
		public static CombatStateItem KaiHeJianShuDirect0 => Instance[(short)26];

		/// <summary>
		/// 开阖剑术·正1
		/// </summary>
		public static CombatStateItem KaiHeJianShuDirect1 => Instance[(short)27];

		/// <summary>
		/// 开阖剑术·正2
		/// </summary>
		public static CombatStateItem KaiHeJianShuDirect2 => Instance[(short)28];

		/// <summary>
		/// 开阖剑术·正3
		/// </summary>
		public static CombatStateItem KaiHeJianShuDirect3 => Instance[(short)29];

		/// <summary>
		/// 开阖剑术·逆0
		/// </summary>
		public static CombatStateItem KaiHeJianShuReverse0 => Instance[(short)30];

		/// <summary>
		/// 开阖剑术·逆1
		/// </summary>
		public static CombatStateItem KaiHeJianShuReverse1 => Instance[(short)31];

		/// <summary>
		/// 开阖剑术·逆2
		/// </summary>
		public static CombatStateItem KaiHeJianShuReverse2 => Instance[(short)32];

		/// <summary>
		/// 开阖剑术·逆3
		/// </summary>
		public static CombatStateItem KaiHeJianShuReverse3 => Instance[(short)33];

		/// <summary>
		/// 御风符·正
		/// </summary>
		public static CombatStateItem YuFengFuDirect => Instance[(short)34];

		/// <summary>
		/// 御风符·逆
		/// </summary>
		public static CombatStateItem YuFengFuReverse => Instance[(short)35];

		/// <summary>
		/// 不思归
		/// </summary>
		public static CombatStateItem BuSiGui => Instance[(short)36];

		/// <summary>
		/// 凤来仪·正
		/// </summary>
		public static CombatStateItem FengLaiYiDirect => Instance[(short)37];

		/// <summary>
		/// 凤来仪·逆
		/// </summary>
		public static CombatStateItem FengLaiYiReverse => Instance[(short)38];

		/// <summary>
		/// 嫘祖剥茧式·正
		/// </summary>
		public static CombatStateItem LeiZuBoJianShiDirect => Instance[(short)39];

		/// <summary>
		/// 嫘祖剥茧式·逆
		/// </summary>
		public static CombatStateItem LeiZuBoJianShiReverse => Instance[(short)40];

		/// <summary>
		/// 大太阴一明指
		/// </summary>
		public static CombatStateItem DaTaiYinYiMingZhi => Instance[(short)41];

		/// <summary>
		/// 断魂幽吟曲
		/// </summary>
		public static CombatStateItem DuanHunYouYinQu => Instance[(short)42];

		/// <summary>
		/// 柴山擒跌手·正
		/// </summary>
		public static CombatStateItem ChaiShanQinDieShouDirect => Instance[(short)43];

		/// <summary>
		/// 柴山擒跌手·逆
		/// </summary>
		public static CombatStateItem ChaiShanQinDieShouReverse => Instance[(short)44];

		/// <summary>
		/// 威灵仙化骨掌·正
		/// </summary>
		public static CombatStateItem WeiLingXianHuaGuZhangDirect => Instance[(short)45];

		/// <summary>
		/// 威灵仙化骨掌·逆
		/// </summary>
		public static CombatStateItem WeiLingXianHuaGuZhangReverse => Instance[(short)46];

		/// <summary>
		/// 磕金震玉小八式·正增益
		/// </summary>
		public static CombatStateItem KeJinZhenYuXiaoBaShiDirectBuff => Instance[(short)47];

		/// <summary>
		/// 磕金震玉小八式·正减益
		/// </summary>
		public static CombatStateItem KeJinZhenYuXiaoBaShiDirectDebuff => Instance[(short)48];

		/// <summary>
		/// 磕金震玉小八式·逆增益
		/// </summary>
		public static CombatStateItem KeJinZhenYuXiaoBaShiReverseBuff => Instance[(short)49];

		/// <summary>
		/// 磕金震玉小八式·逆减益
		/// </summary>
		public static CombatStateItem KeJinZhenYuXiaoBaShiReverseDebuff => Instance[(short)50];

		/// <summary>
		/// 飞山断海大八式·正
		/// </summary>
		public static CombatStateItem FeiShanDuanHaiDaBaShiDirect => Instance[(short)51];

		/// <summary>
		/// 飞山断海大八式·逆
		/// </summary>
		public static CombatStateItem FeiShanDuanHaiDaBaShiReverse => Instance[(short)52];

		/// <summary>
		/// 五怒手·正
		/// </summary>
		public static CombatStateItem WuNuShouDirect => Instance[(short)53];

		/// <summary>
		/// 五怒手·逆
		/// </summary>
		public static CombatStateItem WuNuShouReverse => Instance[(short)54];

		/// <summary>
		/// 金刚黑砂掌·正
		/// </summary>
		public static CombatStateItem JinGangHeiShaZhangDirect => Instance[(short)55];

		/// <summary>
		/// 金刚黑砂掌·逆
		/// </summary>
		public static CombatStateItem JinGangHeiShaZhangReverse => Instance[(short)56];

		/// <summary>
		/// 拿脉功·正
		/// </summary>
		public static CombatStateItem NaMaiGongDirect => Instance[(short)57];

		/// <summary>
		/// 拿脉功·逆
		/// </summary>
		public static CombatStateItem NaMaiGongReverse => Instance[(short)58];

		/// <summary>
		/// 勾镰剑法·正
		/// </summary>
		public static CombatStateItem GouLianJianFaDirect => Instance[(short)59];

		/// <summary>
		/// 勾镰剑法·逆
		/// </summary>
		public static CombatStateItem GouLianJianFaReverse => Instance[(short)60];

		/// <summary>
		/// 玉索倒悬·正
		/// </summary>
		public static CombatStateItem YuSuoDaoXuanDirect => Instance[(short)61];

		/// <summary>
		/// 玉索倒悬·逆
		/// </summary>
		public static CombatStateItem YuSuoDaoXuanReverse => Instance[(short)62];

		/// <summary>
		/// 天蛇翻
		/// </summary>
		public static CombatStateItem TianSheFan => Instance[(short)63];

		/// <summary>
		/// 血偶破煞法·正
		/// </summary>
		public static CombatStateItem XueOuPoShaFaDirect => Instance[(short)64];

		/// <summary>
		/// 血偶破煞法·逆
		/// </summary>
		public static CombatStateItem XueOuPoShaFaReverse => Instance[(short)65];

		/// <summary>
		/// 血偶破煞·正
		/// </summary>
		public static CombatStateItem XueOuPoShaDirect => Instance[(short)66];

		/// <summary>
		/// 血偶破煞·逆
		/// </summary>
		public static CombatStateItem XueOuPoShaReverse => Instance[(short)67];

		/// <summary>
		/// 天渊纵
		/// </summary>
		public static CombatStateItem TianYuanZong => Instance[(short)68];

		/// <summary>
		/// 赤青神火劲·正增益
		/// </summary>
		public static CombatStateItem ChiQingShenHuoJinDirectBuff => Instance[(short)69];

		/// <summary>
		/// 赤青神火劲·正减益
		/// </summary>
		public static CombatStateItem ChiQingShenHuoJinDirectDebuff => Instance[(short)70];

		/// <summary>
		/// 赤青神火劲·逆增益
		/// </summary>
		public static CombatStateItem ChiQingShenHuoJinReverseBuff => Instance[(short)71];

		/// <summary>
		/// 赤青神火劲·逆减益
		/// </summary>
		public static CombatStateItem ChiQingShenHuoJinReverseDebuff => Instance[(short)72];

		/// <summary>
		/// 蝎子勾魂脚·正
		/// </summary>
		public static CombatStateItem XieZiGouHunJiaoDirect => Instance[(short)73];

		/// <summary>
		/// 蝎子勾魂脚·逆
		/// </summary>
		public static CombatStateItem XieZiGouHunJiaoReverse => Instance[(short)74];

		/// <summary>
		/// 伏君忧虞·力道
		/// </summary>
		public static CombatStateItem FuJunYouYuHit0 => Instance[(short)75];

		/// <summary>
		/// 伏君忧虞·精妙
		/// </summary>
		public static CombatStateItem FuJunYouYuHit1 => Instance[(short)76];

		/// <summary>
		/// 伏君忧虞·迅疾
		/// </summary>
		public static CombatStateItem FuJunYouYuHit2 => Instance[(short)77];

		/// <summary>
		/// 伏君忧虞·动心
		/// </summary>
		public static CombatStateItem FuJunYouYuHit3 => Instance[(short)78];

		/// <summary>
		/// 伏君忧虞·卸力
		/// </summary>
		public static CombatStateItem FuJunYouYuAvoid0 => Instance[(short)79];

		/// <summary>
		/// 伏君忧虞·拆招
		/// </summary>
		public static CombatStateItem FuJunYouYuAvoid1 => Instance[(short)80];

		/// <summary>
		/// 伏君忧虞·闪避
		/// </summary>
		public static CombatStateItem FuJunYouYuAvoid2 => Instance[(short)81];

		/// <summary>
		/// 伏君忧虞·守心
		/// </summary>
		public static CombatStateItem FuJunYouYuAvoid3 => Instance[(short)82];

		/// <summary>
		/// 解封·架势恢复
		/// </summary>
		public static CombatStateItem JieFeng0 => Instance[(short)83];

		/// <summary>
		/// 解封·提气恢复
		/// </summary>
		public static CombatStateItem JieFeng1 => Instance[(short)84];

		/// <summary>
		/// 解封·移动速度
		/// </summary>
		public static CombatStateItem JieFeng2 => Instance[(short)85];

		/// <summary>
		/// 解封·步伐稳健
		/// </summary>
		public static CombatStateItem JieFeng3 => Instance[(short)86];

		/// <summary>
		/// 解封·施展速度
		/// </summary>
		public static CombatStateItem JieFeng4 => Instance[(short)87];

		/// <summary>
		/// 解封·引气冲关
		/// </summary>
		public static CombatStateItem JieFeng5 => Instance[(short)88];

		/// <summary>
		/// 解封·兵器切换
		/// </summary>
		public static CombatStateItem JieFeng6 => Instance[(short)89];

		/// <summary>
		/// 解封·攻击速度
		/// </summary>
		public static CombatStateItem JieFeng7 => Instance[(short)90];

		/// <summary>
		/// 解封·内功发挥
		/// </summary>
		public static CombatStateItem JieFeng8 => Instance[(short)91];

		/// <summary>
		/// 解封·调息吐纳
		/// </summary>
		public static CombatStateItem JieFeng9 => Instance[(short)92];

		/// <summary>
		/// 试锋
		/// </summary>
		public static CombatStateItem ShiFeng => Instance[(short)93];

		/// <summary>
		/// 拆刃增益·架势恢复
		/// </summary>
		public static CombatStateItem ChaiRenBuff0 => Instance[(short)94];

		/// <summary>
		/// 拆刃增益·提气恢复
		/// </summary>
		public static CombatStateItem ChaiRenBuff1 => Instance[(short)95];

		/// <summary>
		/// 拆刃增益·移动速度
		/// </summary>
		public static CombatStateItem ChaiRenBuff2 => Instance[(short)96];

		/// <summary>
		/// 拆刃增益·步伐稳健
		/// </summary>
		public static CombatStateItem ChaiRenBuff3 => Instance[(short)97];

		/// <summary>
		/// 拆刃增益·施展速度
		/// </summary>
		public static CombatStateItem ChaiRenBuff4 => Instance[(short)98];

		/// <summary>
		/// 拆刃增益·引气冲关
		/// </summary>
		public static CombatStateItem ChaiRenBuff5 => Instance[(short)99];

		/// <summary>
		/// 拆刃增益·兵器切换
		/// </summary>
		public static CombatStateItem ChaiRenBuff6 => Instance[(short)100];

		/// <summary>
		/// 拆刃增益·攻击速度
		/// </summary>
		public static CombatStateItem ChaiRenBuff7 => Instance[(short)101];

		/// <summary>
		/// 拆刃增益·内功发挥
		/// </summary>
		public static CombatStateItem ChaiRenBuff8 => Instance[(short)102];

		/// <summary>
		/// 拆刃增益·调息吐纳
		/// </summary>
		public static CombatStateItem ChaiRenBuff9 => Instance[(short)103];

		/// <summary>
		/// 拆刃减益·架势恢复
		/// </summary>
		public static CombatStateItem ChaiRenDebuff0 => Instance[(short)104];

		/// <summary>
		/// 拆刃减益·提气恢复
		/// </summary>
		public static CombatStateItem ChaiRenDebuff1 => Instance[(short)105];

		/// <summary>
		/// 拆刃减益·移动速度
		/// </summary>
		public static CombatStateItem ChaiRenDebuff2 => Instance[(short)106];

		/// <summary>
		/// 拆刃减益·步伐稳健
		/// </summary>
		public static CombatStateItem ChaiRenDebuff3 => Instance[(short)107];

		/// <summary>
		/// 拆刃减益·施展速度
		/// </summary>
		public static CombatStateItem ChaiRenDebuff4 => Instance[(short)108];

		/// <summary>
		/// 拆刃减益·引气冲关
		/// </summary>
		public static CombatStateItem ChaiRenDebuff5 => Instance[(short)109];

		/// <summary>
		/// 拆刃减益·兵器切换
		/// </summary>
		public static CombatStateItem ChaiRenDebuff6 => Instance[(short)110];

		/// <summary>
		/// 拆刃减益·攻击速度
		/// </summary>
		public static CombatStateItem ChaiRenDebuff7 => Instance[(short)111];

		/// <summary>
		/// 拆刃减益·内功发挥
		/// </summary>
		public static CombatStateItem ChaiRenDebuff8 => Instance[(short)112];

		/// <summary>
		/// 拆刃减益·调息吐纳
		/// </summary>
		public static CombatStateItem ChaiRenDebuff9 => Instance[(short)113];

		/// <summary>
		/// 夺神·增益
		/// </summary>
		public static CombatStateItem DuoShenBuff => Instance[(short)114];

		/// <summary>
		/// 夺神·减益
		/// </summary>
		public static CombatStateItem DuoShenDebuff => Instance[(short)115];

		/// <summary>
		/// 心神动摇
		/// </summary>
		public static CombatStateItem ReduceMindAvoid => Instance[(short)116];

		/// <summary>
		/// 浑心无字
		/// </summary>
		public static CombatStateItem LegendaryBook0 => Instance[(short)117];

		/// <summary>
		/// 白衣行化
		/// </summary>
		public static CombatStateItem LegendaryBook1 => Instance[(short)118];

		/// <summary>
		/// 大全千法
		/// </summary>
		public static CombatStateItem LegendaryBook2 => Instance[(short)119];

		/// <summary>
		/// 象龙演画
		/// </summary>
		public static CombatStateItem LegendaryBook3 => Instance[(short)120];

		/// <summary>
		/// 心观残笺
		/// </summary>
		public static CombatStateItem LegendaryBook4 => Instance[(short)121];

		/// <summary>
		/// 八埏至宝
		/// </summary>
		public static CombatStateItem LegendaryBook5 => Instance[(short)122];

		/// <summary>
		/// 化影奇功
		/// </summary>
		public static CombatStateItem LegendaryBook6 => Instance[(short)123];

		/// <summary>
		/// 无名神剑
		/// </summary>
		public static CombatStateItem LegendaryBook7 => Instance[(short)124];

		/// <summary>
		/// 十杀魔罗
		/// </summary>
		public static CombatStateItem LegendaryBook8 => Instance[(short)125];

		/// <summary>
		/// 一画开天
		/// </summary>
		public static CombatStateItem LegendaryBook9 => Instance[(short)126];

		/// <summary>
		/// 无先玄元
		/// </summary>
		public static CombatStateItem LegendaryBook10 => Instance[(short)127];

		/// <summary>
		/// 九似真藏
		/// </summary>
		public static CombatStateItem LegendaryBook11 => Instance[(short)128];

		/// <summary>
		/// 天通神术
		/// </summary>
		public static CombatStateItem LegendaryBook12 => Instance[(short)129];

		/// <summary>
		/// 神女绝音
		/// </summary>
		public static CombatStateItem LegendaryBook13 => Instance[(short)130];

		/// <summary>
		/// 凌绝顶
		/// </summary>
		public static CombatStateItem SavageSkillMountain => Instance[(short)131];

		/// <summary>
		/// 一线天
		/// </summary>
		public static CombatStateItem SavageSkillCanyon => Instance[(short)132];

		/// <summary>
		/// 九折径
		/// </summary>
		public static CombatStateItem SavageSkillHill => Instance[(short)133];

		/// <summary>
		/// 苍茫野
		/// </summary>
		public static CombatStateItem SavageSkillField => Instance[(short)134];

		/// <summary>
		/// 连山翠
		/// </summary>
		public static CombatStateItem SavageSkillWoodland => Instance[(short)135];

		/// <summary>
		/// 空行涧
		/// </summary>
		public static CombatStateItem SavageSkillRiverBeach => Instance[(short)136];

		/// <summary>
		/// 烟波荡
		/// </summary>
		public static CombatStateItem SavageSkillLake => Instance[(short)137];

		/// <summary>
		/// 森罗嶂
		/// </summary>
		public static CombatStateItem SavageSkillJungle => Instance[(short)138];

		/// <summary>
		/// 岩穴暝
		/// </summary>
		public static CombatStateItem SavageSkillCave => Instance[(short)139];

		/// <summary>
		/// 幽潭沉
		/// </summary>
		public static CombatStateItem SavageSkillSwamp => Instance[(short)140];

		/// <summary>
		/// 桃花源
		/// </summary>
		public static CombatStateItem SavageSkillTaoYuan => Instance[(short)141];

		/// <summary>
		/// 无命奇毒0
		/// </summary>
		public static CombatStateItem WuMingQiDu0 => Instance[(short)142];

		/// <summary>
		/// 无命奇毒1
		/// </summary>
		public static CombatStateItem WuMingQiDu1 => Instance[(short)143];

		/// <summary>
		/// 无命奇毒2
		/// </summary>
		public static CombatStateItem WuMingQiDu2 => Instance[(short)144];

		/// <summary>
		/// 无命奇毒3
		/// </summary>
		public static CombatStateItem WuMingQiDu3 => Instance[(short)145];

		/// <summary>
		/// 坏血断肠
		/// </summary>
		public static CombatStateItem HuaiXueDuanChang => Instance[(short)146];

		/// <summary>
		/// 剧恶深苦
		/// </summary>
		public static CombatStateItem JuEShenKu => Instance[(short)147];

		/// <summary>
		/// 猴子
		/// </summary>
		public static CombatStateItem Monkey0 => Instance[(short)148];

		/// <summary>
		/// 恶鹰
		/// </summary>
		public static CombatStateItem Eagle0 => Instance[(short)149];

		/// <summary>
		/// 野猪
		/// </summary>
		public static CombatStateItem Pig0 => Instance[(short)150];

		/// <summary>
		/// 棕熊
		/// </summary>
		public static CombatStateItem Bear0 => Instance[(short)151];

		/// <summary>
		/// 野牛
		/// </summary>
		public static CombatStateItem Bull0 => Instance[(short)152];

		/// <summary>
		/// 巨蛇
		/// </summary>
		public static CombatStateItem Snake0 => Instance[(short)153];

		/// <summary>
		/// 花豹
		/// </summary>
		public static CombatStateItem Jaguar0 => Instance[(short)154];

		/// <summary>
		/// 狮子
		/// </summary>
		public static CombatStateItem Lion0 => Instance[(short)155];

		/// <summary>
		/// 老虎
		/// </summary>
		public static CombatStateItem Tiger0 => Instance[(short)156];

		/// <summary>
		/// 灵猴
		/// </summary>
		public static CombatStateItem Monkey1 => Instance[(short)157];

		/// <summary>
		/// 金鹏
		/// </summary>
		public static CombatStateItem Eagle1 => Instance[(short)158];

		/// <summary>
		/// 玄猪
		/// </summary>
		public static CombatStateItem Pig1 => Instance[(short)159];

		/// <summary>
		/// 白熊
		/// </summary>
		public static CombatStateItem Bear1 => Instance[(short)160];

		/// <summary>
		/// 夔牛
		/// </summary>
		public static CombatStateItem Bull1 => Instance[(short)161];

		/// <summary>
		/// 巴蟒
		/// </summary>
		public static CombatStateItem Snake1 => Instance[(short)162];

		/// <summary>
		/// 黑豹
		/// </summary>
		public static CombatStateItem Jaguar1 => Instance[(short)163];

		/// <summary>
		/// 金狮
		/// </summary>
		public static CombatStateItem Lion1 => Instance[(short)164];

		/// <summary>
		/// 白虎
		/// </summary>
		public static CombatStateItem Tiger1 => Instance[(short)165];

		/// <summary>
		/// 七轮感应法·正
		/// </summary>
		public static CombatStateItem QiLunGanYingFaDirect => Instance[(short)166];

		/// <summary>
		/// 七轮感应法·逆
		/// </summary>
		public static CombatStateItem QiLunGanYingFaReverse => Instance[(short)167];

		/// <summary>
		/// 白蛟
		/// </summary>
		public static CombatStateItem JiaoWhite => Instance[(short)168];

		/// <summary>
		/// 黑蛟
		/// </summary>
		public static CombatStateItem JiaoBlack => Instance[(short)169];

		/// <summary>
		/// 青蛟
		/// </summary>
		public static CombatStateItem JiaoGreen => Instance[(short)170];

		/// <summary>
		/// 赤蛟
		/// </summary>
		public static CombatStateItem JiaoRed => Instance[(short)171];

		/// <summary>
		/// 黄蛟
		/// </summary>
		public static CombatStateItem JiaoYellow => Instance[(short)172];

		/// <summary>
		/// 白黑蛟
		/// </summary>
		public static CombatStateItem JiaoWB => Instance[(short)173];

		/// <summary>
		/// 白青蛟
		/// </summary>
		public static CombatStateItem JiaoWG => Instance[(short)174];

		/// <summary>
		/// 白赤蛟
		/// </summary>
		public static CombatStateItem JiaoWR => Instance[(short)175];

		/// <summary>
		/// 白黄蛟
		/// </summary>
		public static CombatStateItem JiaoWY => Instance[(short)176];

		/// <summary>
		/// 黑青蛟
		/// </summary>
		public static CombatStateItem JiaoBG => Instance[(short)177];

		/// <summary>
		/// 黑赤蛟
		/// </summary>
		public static CombatStateItem JiaoBR => Instance[(short)178];

		/// <summary>
		/// 黑黄蛟
		/// </summary>
		public static CombatStateItem JiaoBY => Instance[(short)179];

		/// <summary>
		/// 青赤蛟
		/// </summary>
		public static CombatStateItem JiaoGR => Instance[(short)180];

		/// <summary>
		/// 青黄蛟
		/// </summary>
		public static CombatStateItem JiaoGY => Instance[(short)181];

		/// <summary>
		/// 赤黄蛟
		/// </summary>
		public static CombatStateItem JiaoRY => Instance[(short)182];

		/// <summary>
		/// 白黑青蛟
		/// </summary>
		public static CombatStateItem JiaoWBG => Instance[(short)183];

		/// <summary>
		/// 白黑赤蛟
		/// </summary>
		public static CombatStateItem JiaoWBR => Instance[(short)184];

		/// <summary>
		/// 白黑黄蛟
		/// </summary>
		public static CombatStateItem JiaoWBY => Instance[(short)185];

		/// <summary>
		/// 白青赤蛟
		/// </summary>
		public static CombatStateItem JiaoWGR => Instance[(short)186];

		/// <summary>
		/// 白青黄蛟
		/// </summary>
		public static CombatStateItem JiaoWGY => Instance[(short)187];

		/// <summary>
		/// 白赤黄蛟
		/// </summary>
		public static CombatStateItem JiaoWRY => Instance[(short)188];

		/// <summary>
		/// 黑青赤蛟
		/// </summary>
		public static CombatStateItem JiaoBGR => Instance[(short)189];

		/// <summary>
		/// 黑青黄蛟
		/// </summary>
		public static CombatStateItem JiaoBGY => Instance[(short)190];

		/// <summary>
		/// 黑赤黄蛟
		/// </summary>
		public static CombatStateItem JiaoBRY => Instance[(short)191];

		/// <summary>
		/// 青赤黄蛟
		/// </summary>
		public static CombatStateItem JiaoGRY => Instance[(short)192];

		/// <summary>
		/// 白黑青赤蛟
		/// </summary>
		public static CombatStateItem JiaoWBGR => Instance[(short)193];

		/// <summary>
		/// 白黑青黄蛟
		/// </summary>
		public static CombatStateItem JiaoWBGY => Instance[(short)194];

		/// <summary>
		/// 白黑赤黄蛟
		/// </summary>
		public static CombatStateItem JiaoWBRY => Instance[(short)195];

		/// <summary>
		/// 白青赤黄蛟
		/// </summary>
		public static CombatStateItem JiaoWGRY => Instance[(short)196];

		/// <summary>
		/// 黑青赤黄蛟
		/// </summary>
		public static CombatStateItem JiaoBGRY => Instance[(short)197];

		/// <summary>
		/// 白青赤黄黑蛟
		/// </summary>
		public static CombatStateItem JiaoWGRYB => Instance[(short)198];

		/// <summary>
		/// 囚牛
		/// </summary>
		public static CombatStateItem Qiuniu => Instance[(short)199];

		/// <summary>
		/// 睚眦
		/// </summary>
		public static CombatStateItem Yazi => Instance[(short)200];

		/// <summary>
		/// 嘲风
		/// </summary>
		public static CombatStateItem Chaofeng => Instance[(short)201];

		/// <summary>
		/// 蒲牢
		/// </summary>
		public static CombatStateItem Pulao => Instance[(short)202];

		/// <summary>
		/// 狻猊
		/// </summary>
		public static CombatStateItem Suanni => Instance[(short)203];

		/// <summary>
		/// 霸下
		/// </summary>
		public static CombatStateItem Baxia => Instance[(short)204];

		/// <summary>
		/// 狴犴
		/// </summary>
		public static CombatStateItem Bian => Instance[(short)205];

		/// <summary>
		/// 负屃
		/// </summary>
		public static CombatStateItem Fuxi => Instance[(short)206];

		/// <summary>
		/// 螭吻
		/// </summary>
		public static CombatStateItem Chiwen => Instance[(short)207];

		/// <summary>
		/// 六合刀法·正
		/// </summary>
		public static CombatStateItem LiuHeDaoFaDirect => Instance[(short)208];

		/// <summary>
		/// 六合刀法·逆
		/// </summary>
		public static CombatStateItem LiuHeDaoFaReverse => Instance[(short)209];

		/// <summary>
		/// 鸩羽香·正
		/// </summary>
		public static CombatStateItem ZhenYuXiangDirect => Instance[(short)210];

		/// <summary>
		/// 鸩羽香·逆
		/// </summary>
		public static CombatStateItem ZhenYuXiangReverse => Instance[(short)211];

		/// <summary>
		/// 阴风蝎子手·正
		/// </summary>
		public static CombatStateItem YinFengXieZiShouDirect => Instance[(short)212];

		/// <summary>
		/// 阴风蝎子手·逆
		/// </summary>
		public static CombatStateItem YinFengXieZiShouReverse => Instance[(short)213];

		/// <summary>
		/// 寒冰刺骨法·正
		/// </summary>
		public static CombatStateItem HanBingCiGuFaDirect => Instance[(short)214];

		/// <summary>
		/// 寒冰刺骨法·逆
		/// </summary>
		public static CombatStateItem HanBingCiGuFaReverse => Instance[(short)215];

		/// <summary>
		/// 掌血功·正
		/// </summary>
		public static CombatStateItem ZhangXueGongDirect => Instance[(short)216];

		/// <summary>
		/// 掌血功·逆
		/// </summary>
		public static CombatStateItem ZhangXueGongReverse => Instance[(short)217];

		/// <summary>
		/// 黄泉指·正
		/// </summary>
		public static CombatStateItem HuangQuanZhiDirect => Instance[(short)218];

		/// <summary>
		/// 黄泉指·逆
		/// </summary>
		public static CombatStateItem HuangQuanZhiReverse => Instance[(short)219];

		/// <summary>
		/// 大花曼陀罗指·正
		/// </summary>
		public static CombatStateItem DaHuaManTuoLuoZhiDirect => Instance[(short)220];

		/// <summary>
		/// 大花曼陀罗指·逆
		/// </summary>
		public static CombatStateItem DaHuaManTuoLuoZhiReverse => Instance[(short)221];

		/// <summary>
		/// 琼花叹·正
		/// </summary>
		public static CombatStateItem QiongHuaTanDirect => Instance[(short)222];

		/// <summary>
		/// 琼花叹·逆
		/// </summary>
		public static CombatStateItem QiongHuaTanReverse => Instance[(short)223];

		/// <summary>
		/// 胸中死气
		/// </summary>
		public static CombatStateItem XiongZhongSiQi => Instance[(short)224];

		/// <summary>
		/// 死气夺魂
		/// </summary>
		public static CombatStateItem SiQiDuoHun => Instance[(short)225];

		/// <summary>
		/// 少林遗力
		/// </summary>
		public static CombatStateItem LegacyPowerShaolin => Instance[(short)226];

		/// <summary>
		/// 峨眉遗力
		/// </summary>
		public static CombatStateItem LegacyPowerEmei => Instance[(short)227];

		/// <summary>
		/// 百花遗力
		/// </summary>
		public static CombatStateItem LegacyPowerBaihua => Instance[(short)228];

		/// <summary>
		/// 武当遗力
		/// </summary>
		public static CombatStateItem LegacyPowerWudang => Instance[(short)229];

		/// <summary>
		/// 元山遗力
		/// </summary>
		public static CombatStateItem LegacyPowerYuanshan => Instance[(short)230];

		/// <summary>
		/// 狮相遗力
		/// </summary>
		public static CombatStateItem LegacyPowerShixiang => Instance[(short)231];

		/// <summary>
		/// 然山遗力
		/// </summary>
		public static CombatStateItem LegacyPowerRanshan => Instance[(short)232];

		/// <summary>
		/// 璇女遗力
		/// </summary>
		public static CombatStateItem LegacyPowerXuannv => Instance[(short)233];

		/// <summary>
		/// 铸剑遗力
		/// </summary>
		public static CombatStateItem LegacyPowerZhujian => Instance[(short)234];

		/// <summary>
		/// 空桑遗力
		/// </summary>
		public static CombatStateItem LegacyPowerKongsang => Instance[(short)235];

		/// <summary>
		/// 金刚遗力
		/// </summary>
		public static CombatStateItem LegacyPowerJingang => Instance[(short)236];

		/// <summary>
		/// 五仙遗力
		/// </summary>
		public static CombatStateItem LegacyPowerWuxian => Instance[(short)237];

		/// <summary>
		/// 界青遗力
		/// </summary>
		public static CombatStateItem LegacyPowerJieqing => Instance[(short)238];

		/// <summary>
		/// 伏龙遗力
		/// </summary>
		public static CombatStateItem LegacyPowerFulong => Instance[(short)239];

		/// <summary>
		/// 血犼遗力
		/// </summary>
		public static CombatStateItem LegacyPowerXuehou => Instance[(short)240];

		/// <summary>
		/// 落魂钟
		/// </summary>
		public static CombatStateItem SoulWitheringBell => Instance[(short)241];

		/// <summary>
		/// 落魂钟转移后
		/// </summary>
		public static CombatStateItem SoulWitheringBellAfterTransfer => Instance[(short)242];

		/// <summary>
		/// 狩猎野兽
		/// </summary>
		public static CombatStateItem HuntingBeasts => Instance[(short)243];

		/// <summary>
		/// 天铸玄铁册·正
		/// </summary>
		public static CombatStateItem TianZhuXuanTieCeDirect => Instance[(short)244];

		/// <summary>
		/// 天铸玄铁册·逆
		/// </summary>
		public static CombatStateItem TianZhuXuanTieCeReverse => Instance[(short)245];

		/// <summary>
		/// 金刚狱石
		/// </summary>
		public static CombatStateItem FiveElementsStoneMetal => Instance[(short)246];

		/// <summary>
		/// 紫霞狱石
		/// </summary>
		public static CombatStateItem FiveElementsStoneWood => Instance[(short)247];

		/// <summary>
		/// 玄阴狱石
		/// </summary>
		public static CombatStateItem FiveElementsStoneWater => Instance[(short)248];

		/// <summary>
		/// 纯阳狱石
		/// </summary>
		public static CombatStateItem FiveElementsStoneFire => Instance[(short)249];

		/// <summary>
		/// 归元狱石
		/// </summary>
		public static CombatStateItem FiveElementsStoneEarth => Instance[(short)250];

		/// <summary>
		/// 金蚕蛊·增益
		/// </summary>
		public static CombatStateItem GoldenSilkwormBuff => Instance[(short)251];

		/// <summary>
		/// 金蚕蛊·减益
		/// </summary>
		public static CombatStateItem GoldenSilkwormDebuff => Instance[(short)252];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CombatState Instance = new CombatState();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "PropertyList", "ReverseState", "TipsDesc", "Desc", "TemplateId" };

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
		_dataArray.Add(new CombatStateItem(0, LocalStringManager.GetConfig("CombatState_language", "Name_0"), new List<CombatStateProperty>
		{
			new CombatStateProperty(6, 3, 1),
			new CombatStateProperty(7, 3, 1),
			new CombatStateProperty(8, 3, 1),
			new CombatStateProperty(9, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_0"), LocalStringManager.GetConfig("CombatState_language", "Desc_0")));
		_dataArray.Add(new CombatStateItem(1, LocalStringManager.GetConfig("CombatState_language", "Name_1"), new List<CombatStateProperty>
		{
			new CombatStateProperty(0, 3, 1),
			new CombatStateProperty(1, 3, 1),
			new CombatStateProperty(2, 3, 1),
			new CombatStateProperty(3, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_1"), LocalStringManager.GetConfig("CombatState_language", "Desc_1")));
		_dataArray.Add(new CombatStateItem(2, LocalStringManager.GetConfig("CombatState_language", "Name_2"), new List<CombatStateProperty>
		{
			new CombatStateProperty(6, 3, 1),
			new CombatStateProperty(7, 3, 1),
			new CombatStateProperty(8, 3, 1),
			new CombatStateProperty(9, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_2"), LocalStringManager.GetConfig("CombatState_language", "Desc_2")));
		_dataArray.Add(new CombatStateItem(3, LocalStringManager.GetConfig("CombatState_language", "Name_3"), new List<CombatStateProperty>
		{
			new CombatStateProperty(0, 3, 1),
			new CombatStateProperty(1, 3, 1),
			new CombatStateProperty(2, 3, 1),
			new CombatStateProperty(3, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_3"), LocalStringManager.GetConfig("CombatState_language", "Desc_3")));
		_dataArray.Add(new CombatStateItem(4, LocalStringManager.GetConfig("CombatState_language", "Name_4"), new List<CombatStateProperty>
		{
			new CombatStateProperty(4, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_4"), LocalStringManager.GetConfig("CombatState_language", "Desc_4")));
		_dataArray.Add(new CombatStateItem(5, LocalStringManager.GetConfig("CombatState_language", "Name_5"), new List<CombatStateProperty>
		{
			new CombatStateProperty(5, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_5"), LocalStringManager.GetConfig("CombatState_language", "Desc_5")));
		_dataArray.Add(new CombatStateItem(6, LocalStringManager.GetConfig("CombatState_language", "Name_6"), new List<CombatStateProperty>
		{
			new CombatStateProperty(5, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_6"), LocalStringManager.GetConfig("CombatState_language", "Desc_6")));
		_dataArray.Add(new CombatStateItem(7, LocalStringManager.GetConfig("CombatState_language", "Name_7"), new List<CombatStateProperty>
		{
			new CombatStateProperty(4, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_7"), LocalStringManager.GetConfig("CombatState_language", "Desc_7")));
		_dataArray.Add(new CombatStateItem(8, LocalStringManager.GetConfig("CombatState_language", "Name_8"), new List<CombatStateProperty>
		{
			new CombatStateProperty(4, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_8"), LocalStringManager.GetConfig("CombatState_language", "Desc_8")));
		_dataArray.Add(new CombatStateItem(9, LocalStringManager.GetConfig("CombatState_language", "Name_9"), new List<CombatStateProperty>
		{
			new CombatStateProperty(10, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_9"), LocalStringManager.GetConfig("CombatState_language", "Desc_9")));
		_dataArray.Add(new CombatStateItem(10, LocalStringManager.GetConfig("CombatState_language", "Name_10"), new List<CombatStateProperty>
		{
			new CombatStateProperty(32, 7, 1),
			new CombatStateProperty(13, 20, 0),
			new CombatStateProperty(12, 20, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_10"), LocalStringManager.GetConfig("CombatState_language", "Desc_10")));
		_dataArray.Add(new CombatStateItem(11, LocalStringManager.GetConfig("CombatState_language", "Name_11"), new List<CombatStateProperty>
		{
			new CombatStateProperty(6, 3, 1),
			new CombatStateProperty(7, 3, 1),
			new CombatStateProperty(8, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_11"), LocalStringManager.GetConfig("CombatState_language", "Desc_11")));
		_dataArray.Add(new CombatStateItem(12, LocalStringManager.GetConfig("CombatState_language", "Name_12"), new List<CombatStateProperty>
		{
			new CombatStateProperty(6, -3, 1),
			new CombatStateProperty(7, -3, 1),
			new CombatStateProperty(8, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_12"), LocalStringManager.GetConfig("CombatState_language", "Desc_12")));
		_dataArray.Add(new CombatStateItem(13, LocalStringManager.GetConfig("CombatState_language", "Name_13"), new List<CombatStateProperty>
		{
			new CombatStateProperty(11, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_13"), LocalStringManager.GetConfig("CombatState_language", "Desc_13")));
		_dataArray.Add(new CombatStateItem(14, LocalStringManager.GetConfig("CombatState_language", "Name_14"), new List<CombatStateProperty>
		{
			new CombatStateProperty(10, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_14"), LocalStringManager.GetConfig("CombatState_language", "Desc_14")));
		_dataArray.Add(new CombatStateItem(15, LocalStringManager.GetConfig("CombatState_language", "Name_15"), new List<CombatStateProperty>
		{
			new CombatStateProperty(10, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_15"), LocalStringManager.GetConfig("CombatState_language", "Desc_15")));
		_dataArray.Add(new CombatStateItem(16, LocalStringManager.GetConfig("CombatState_language", "Name_16"), new List<CombatStateProperty>
		{
			new CombatStateProperty(11, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_16"), LocalStringManager.GetConfig("CombatState_language", "Desc_16")));
		_dataArray.Add(new CombatStateItem(17, LocalStringManager.GetConfig("CombatState_language", "Name_17"), new List<CombatStateProperty>
		{
			new CombatStateProperty(5, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_17"), LocalStringManager.GetConfig("CombatState_language", "Desc_17")));
		_dataArray.Add(new CombatStateItem(18, LocalStringManager.GetConfig("CombatState_language", "Name_18"), new List<CombatStateProperty>
		{
			new CombatStateProperty(11, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_18"), LocalStringManager.GetConfig("CombatState_language", "Desc_18")));
		_dataArray.Add(new CombatStateItem(19, LocalStringManager.GetConfig("CombatState_language", "Name_19"), new List<CombatStateProperty>
		{
			new CombatStateProperty(0, 3, 1),
			new CombatStateProperty(1, 3, 1),
			new CombatStateProperty(2, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_19"), LocalStringManager.GetConfig("CombatState_language", "Desc_19")));
		_dataArray.Add(new CombatStateItem(20, LocalStringManager.GetConfig("CombatState_language", "Name_20"), new List<CombatStateProperty>
		{
			new CombatStateProperty(10, 300, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_20"), LocalStringManager.GetConfig("CombatState_language", "Desc_20")));
		_dataArray.Add(new CombatStateItem(21, LocalStringManager.GetConfig("CombatState_language", "Name_21"), new List<CombatStateProperty>
		{
			new CombatStateProperty(11, 300, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_21"), LocalStringManager.GetConfig("CombatState_language", "Desc_21")));
		_dataArray.Add(new CombatStateItem(22, LocalStringManager.GetConfig("CombatState_language", "Name_22"), new List<CombatStateProperty>
		{
			new CombatStateProperty(4, -300, 0),
			new CombatStateProperty(5, -300, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_22"), LocalStringManager.GetConfig("CombatState_language", "Desc_22")));
		_dataArray.Add(new CombatStateItem(23, LocalStringManager.GetConfig("CombatState_language", "Name_23"), new List<CombatStateProperty>
		{
			new CombatStateProperty(10, -300, 0),
			new CombatStateProperty(11, -300, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_23"), LocalStringManager.GetConfig("CombatState_language", "Desc_23")));
		_dataArray.Add(new CombatStateItem(24, LocalStringManager.GetConfig("CombatState_language", "Name_24"), new List<CombatStateProperty>
		{
			new CombatStateProperty(15, 30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_24"), LocalStringManager.GetConfig("CombatState_language", "Desc_24")));
		_dataArray.Add(new CombatStateItem(25, LocalStringManager.GetConfig("CombatState_language", "Name_25"), new List<CombatStateProperty>
		{
			new CombatStateProperty(17, 30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_25"), LocalStringManager.GetConfig("CombatState_language", "Desc_25")));
		_dataArray.Add(new CombatStateItem(26, LocalStringManager.GetConfig("CombatState_language", "Name_26"), new List<CombatStateProperty>
		{
			new CombatStateProperty(0, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_26"), LocalStringManager.GetConfig("CombatState_language", "Desc_26")));
		_dataArray.Add(new CombatStateItem(27, LocalStringManager.GetConfig("CombatState_language", "Name_27"), new List<CombatStateProperty>
		{
			new CombatStateProperty(1, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_27"), LocalStringManager.GetConfig("CombatState_language", "Desc_27")));
		_dataArray.Add(new CombatStateItem(28, LocalStringManager.GetConfig("CombatState_language", "Name_28"), new List<CombatStateProperty>
		{
			new CombatStateProperty(2, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_28"), LocalStringManager.GetConfig("CombatState_language", "Desc_28")));
		_dataArray.Add(new CombatStateItem(29, LocalStringManager.GetConfig("CombatState_language", "Name_29"), new List<CombatStateProperty>
		{
			new CombatStateProperty(3, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_29"), LocalStringManager.GetConfig("CombatState_language", "Desc_29")));
		_dataArray.Add(new CombatStateItem(30, LocalStringManager.GetConfig("CombatState_language", "Name_30"), new List<CombatStateProperty>
		{
			new CombatStateProperty(6, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_30"), LocalStringManager.GetConfig("CombatState_language", "Desc_30")));
		_dataArray.Add(new CombatStateItem(31, LocalStringManager.GetConfig("CombatState_language", "Name_31"), new List<CombatStateProperty>
		{
			new CombatStateProperty(7, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_31"), LocalStringManager.GetConfig("CombatState_language", "Desc_31")));
		_dataArray.Add(new CombatStateItem(32, LocalStringManager.GetConfig("CombatState_language", "Name_32"), new List<CombatStateProperty>
		{
			new CombatStateProperty(8, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_32"), LocalStringManager.GetConfig("CombatState_language", "Desc_32")));
		_dataArray.Add(new CombatStateItem(33, LocalStringManager.GetConfig("CombatState_language", "Name_33"), new List<CombatStateProperty>
		{
			new CombatStateProperty(9, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_33"), LocalStringManager.GetConfig("CombatState_language", "Desc_33")));
		_dataArray.Add(new CombatStateItem(34, LocalStringManager.GetConfig("CombatState_language", "Name_34"), new List<CombatStateProperty>
		{
			new CombatStateProperty(16, 30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_34"), LocalStringManager.GetConfig("CombatState_language", "Desc_34")));
		_dataArray.Add(new CombatStateItem(35, LocalStringManager.GetConfig("CombatState_language", "Name_35"), new List<CombatStateProperty>
		{
			new CombatStateProperty(16, -30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_35"), LocalStringManager.GetConfig("CombatState_language", "Desc_35")));
		_dataArray.Add(new CombatStateItem(36, LocalStringManager.GetConfig("CombatState_language", "Name_36"), new List<CombatStateProperty>
		{
			new CombatStateProperty(30, 15, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_36"), LocalStringManager.GetConfig("CombatState_language", "Desc_36")));
		_dataArray.Add(new CombatStateItem(37, LocalStringManager.GetConfig("CombatState_language", "Name_37"), new List<CombatStateProperty>
		{
			new CombatStateProperty(3, 3, 1),
			new CombatStateProperty(9, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_37"), LocalStringManager.GetConfig("CombatState_language", "Desc_37")));
		_dataArray.Add(new CombatStateItem(38, LocalStringManager.GetConfig("CombatState_language", "Name_38"), new List<CombatStateProperty>
		{
			new CombatStateProperty(3, -3, 1),
			new CombatStateProperty(9, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_38"), LocalStringManager.GetConfig("CombatState_language", "Desc_38")));
		_dataArray.Add(new CombatStateItem(39, LocalStringManager.GetConfig("CombatState_language", "Name_39"), new List<CombatStateProperty>
		{
			new CombatStateProperty(10, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_39"), LocalStringManager.GetConfig("CombatState_language", "Desc_39")));
		_dataArray.Add(new CombatStateItem(40, LocalStringManager.GetConfig("CombatState_language", "Name_40"), new List<CombatStateProperty>
		{
			new CombatStateProperty(11, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_40"), LocalStringManager.GetConfig("CombatState_language", "Desc_40")));
		_dataArray.Add(new CombatStateItem(41, LocalStringManager.GetConfig("CombatState_language", "Name_41"), new List<CombatStateProperty>
		{
			new CombatStateProperty(31, -15, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_41"), LocalStringManager.GetConfig("CombatState_language", "Desc_41")));
		_dataArray.Add(new CombatStateItem(42, LocalStringManager.GetConfig("CombatState_language", "Name_42"), new List<CombatStateProperty>
		{
			new CombatStateProperty(30, -15, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_42"), LocalStringManager.GetConfig("CombatState_language", "Desc_42")));
		_dataArray.Add(new CombatStateItem(43, LocalStringManager.GetConfig("CombatState_language", "Name_43"), new List<CombatStateProperty>
		{
			new CombatStateProperty(14, -30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_43"), LocalStringManager.GetConfig("CombatState_language", "Desc_43")));
		_dataArray.Add(new CombatStateItem(44, LocalStringManager.GetConfig("CombatState_language", "Name_44"), new List<CombatStateProperty>
		{
			new CombatStateProperty(19, -30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_44"), LocalStringManager.GetConfig("CombatState_language", "Desc_44")));
		_dataArray.Add(new CombatStateItem(45, LocalStringManager.GetConfig("CombatState_language", "Name_45"), new List<CombatStateProperty>
		{
			new CombatStateProperty(15, -30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_45"), LocalStringManager.GetConfig("CombatState_language", "Desc_45")));
		_dataArray.Add(new CombatStateItem(46, LocalStringManager.GetConfig("CombatState_language", "Name_46"), new List<CombatStateProperty>
		{
			new CombatStateProperty(17, -30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_46"), LocalStringManager.GetConfig("CombatState_language", "Desc_46")));
		_dataArray.Add(new CombatStateItem(47, LocalStringManager.GetConfig("CombatState_language", "Name_47"), new List<CombatStateProperty>
		{
			new CombatStateProperty(4, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_47"), LocalStringManager.GetConfig("CombatState_language", "Desc_47")));
		_dataArray.Add(new CombatStateItem(48, LocalStringManager.GetConfig("CombatState_language", "Name_48"), new List<CombatStateProperty>
		{
			new CombatStateProperty(10, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_48"), LocalStringManager.GetConfig("CombatState_language", "Desc_48")));
		_dataArray.Add(new CombatStateItem(49, LocalStringManager.GetConfig("CombatState_language", "Name_49"), new List<CombatStateProperty>
		{
			new CombatStateProperty(5, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_49"), LocalStringManager.GetConfig("CombatState_language", "Desc_49")));
		_dataArray.Add(new CombatStateItem(50, LocalStringManager.GetConfig("CombatState_language", "Name_50"), new List<CombatStateProperty>
		{
			new CombatStateProperty(11, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_50"), LocalStringManager.GetConfig("CombatState_language", "Desc_50")));
		_dataArray.Add(new CombatStateItem(51, LocalStringManager.GetConfig("CombatState_language", "Name_51"), new List<CombatStateProperty>
		{
			new CombatStateProperty(15, -10, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_51"), LocalStringManager.GetConfig("CombatState_language", "Desc_51")));
		_dataArray.Add(new CombatStateItem(52, LocalStringManager.GetConfig("CombatState_language", "Name_52"), new List<CombatStateProperty>
		{
			new CombatStateProperty(17, -10, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_52"), LocalStringManager.GetConfig("CombatState_language", "Desc_52")));
		_dataArray.Add(new CombatStateItem(53, LocalStringManager.GetConfig("CombatState_language", "Name_53"), new List<CombatStateProperty>
		{
			new CombatStateProperty(4, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_53"), LocalStringManager.GetConfig("CombatState_language", "Desc_53")));
		_dataArray.Add(new CombatStateItem(54, LocalStringManager.GetConfig("CombatState_language", "Name_54"), new List<CombatStateProperty>
		{
			new CombatStateProperty(5, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_54"), LocalStringManager.GetConfig("CombatState_language", "Desc_54")));
		_dataArray.Add(new CombatStateItem(55, LocalStringManager.GetConfig("CombatState_language", "Name_55"), new List<CombatStateProperty>
		{
			new CombatStateProperty(28, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_55"), LocalStringManager.GetConfig("CombatState_language", "Desc_55")));
		_dataArray.Add(new CombatStateItem(56, LocalStringManager.GetConfig("CombatState_language", "Name_56"), new List<CombatStateProperty>
		{
			new CombatStateProperty(29, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_56"), LocalStringManager.GetConfig("CombatState_language", "Desc_56")));
		_dataArray.Add(new CombatStateItem(57, LocalStringManager.GetConfig("CombatState_language", "Name_57"), new List<CombatStateProperty>
		{
			new CombatStateProperty(12, -5, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_57"), LocalStringManager.GetConfig("CombatState_language", "Desc_57")));
		_dataArray.Add(new CombatStateItem(58, LocalStringManager.GetConfig("CombatState_language", "Name_58"), new List<CombatStateProperty>
		{
			new CombatStateProperty(13, -5, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_58"), LocalStringManager.GetConfig("CombatState_language", "Desc_58")));
		_dataArray.Add(new CombatStateItem(59, LocalStringManager.GetConfig("CombatState_language", "Name_59"), new List<CombatStateProperty>
		{
			new CombatStateProperty(19, -5, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_59"), LocalStringManager.GetConfig("CombatState_language", "Desc_59")));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CombatStateItem(60, LocalStringManager.GetConfig("CombatState_language", "Name_60"), new List<CombatStateProperty>
		{
			new CombatStateProperty(14, -5, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_60"), LocalStringManager.GetConfig("CombatState_language", "Desc_60")));
		_dataArray.Add(new CombatStateItem(61, LocalStringManager.GetConfig("CombatState_language", "Name_61"), new List<CombatStateProperty>
		{
			new CombatStateProperty(13, 30, 0),
			new CombatStateProperty(12, 30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_61"), LocalStringManager.GetConfig("CombatState_language", "Desc_61")));
		_dataArray.Add(new CombatStateItem(62, LocalStringManager.GetConfig("CombatState_language", "Name_62"), new List<CombatStateProperty>
		{
			new CombatStateProperty(13, -30, 0),
			new CombatStateProperty(12, -30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_62"), LocalStringManager.GetConfig("CombatState_language", "Desc_62")));
		_dataArray.Add(new CombatStateItem(63, LocalStringManager.GetConfig("CombatState_language", "Name_63"), new List<CombatStateProperty>
		{
			new CombatStateProperty(22, -60, 0),
			new CombatStateProperty(23, -60, 0),
			new CombatStateProperty(24, -60, 0),
			new CombatStateProperty(25, -60, 0),
			new CombatStateProperty(26, -60, 0),
			new CombatStateProperty(27, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_63"), LocalStringManager.GetConfig("CombatState_language", "Desc_63")));
		_dataArray.Add(new CombatStateItem(64, LocalStringManager.GetConfig("CombatState_language", "Name_64"), new List<CombatStateProperty>
		{
			new CombatStateProperty(4, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_64"), LocalStringManager.GetConfig("CombatState_language", "Desc_64")));
		_dataArray.Add(new CombatStateItem(65, LocalStringManager.GetConfig("CombatState_language", "Name_65"), new List<CombatStateProperty>
		{
			new CombatStateProperty(5, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_65"), LocalStringManager.GetConfig("CombatState_language", "Desc_65")));
		_dataArray.Add(new CombatStateItem(66, LocalStringManager.GetConfig("CombatState_language", "Name_66"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_66"), LocalStringManager.GetConfig("CombatState_language", "Desc_66")));
		_dataArray.Add(new CombatStateItem(67, LocalStringManager.GetConfig("CombatState_language", "Name_67"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_67"), LocalStringManager.GetConfig("CombatState_language", "Desc_67")));
		_dataArray.Add(new CombatStateItem(68, LocalStringManager.GetConfig("CombatState_language", "Name_68"), new List<CombatStateProperty>
		{
			new CombatStateProperty(4, 3, 1),
			new CombatStateProperty(5, 3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_68"), LocalStringManager.GetConfig("CombatState_language", "Desc_68")));
		_dataArray.Add(new CombatStateItem(69, LocalStringManager.GetConfig("CombatState_language", "Name_69"), new List<CombatStateProperty>
		{
			new CombatStateProperty(4, 6, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_69"), LocalStringManager.GetConfig("CombatState_language", "Desc_69")));
		_dataArray.Add(new CombatStateItem(70, LocalStringManager.GetConfig("CombatState_language", "Name_70"), new List<CombatStateProperty>
		{
			new CombatStateProperty(10, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_70"), LocalStringManager.GetConfig("CombatState_language", "Desc_70")));
		_dataArray.Add(new CombatStateItem(71, LocalStringManager.GetConfig("CombatState_language", "Name_71"), new List<CombatStateProperty>
		{
			new CombatStateProperty(5, 6, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_71"), LocalStringManager.GetConfig("CombatState_language", "Desc_71")));
		_dataArray.Add(new CombatStateItem(72, LocalStringManager.GetConfig("CombatState_language", "Name_72"), new List<CombatStateProperty>
		{
			new CombatStateProperty(11, -3, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_72"), LocalStringManager.GetConfig("CombatState_language", "Desc_72")));
		_dataArray.Add(new CombatStateItem(73, LocalStringManager.GetConfig("CombatState_language", "Name_73"), new List<CombatStateProperty>
		{
			new CombatStateProperty(14, 30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_73"), LocalStringManager.GetConfig("CombatState_language", "Desc_73")));
		_dataArray.Add(new CombatStateItem(74, LocalStringManager.GetConfig("CombatState_language", "Name_74"), new List<CombatStateProperty>
		{
			new CombatStateProperty(19, 30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_74"), LocalStringManager.GetConfig("CombatState_language", "Desc_74")));
		_dataArray.Add(new CombatStateItem(75, LocalStringManager.GetConfig("CombatState_language", "Name_75"), new List<CombatStateProperty>
		{
			new CombatStateProperty(0, 600, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_75"), LocalStringManager.GetConfig("CombatState_language", "Desc_75")));
		_dataArray.Add(new CombatStateItem(76, LocalStringManager.GetConfig("CombatState_language", "Name_76"), new List<CombatStateProperty>
		{
			new CombatStateProperty(1, 600, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_76"), LocalStringManager.GetConfig("CombatState_language", "Desc_76")));
		_dataArray.Add(new CombatStateItem(77, LocalStringManager.GetConfig("CombatState_language", "Name_77"), new List<CombatStateProperty>
		{
			new CombatStateProperty(2, 600, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_77"), LocalStringManager.GetConfig("CombatState_language", "Desc_77")));
		_dataArray.Add(new CombatStateItem(78, LocalStringManager.GetConfig("CombatState_language", "Name_78"), new List<CombatStateProperty>
		{
			new CombatStateProperty(3, 600, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_78"), LocalStringManager.GetConfig("CombatState_language", "Desc_78")));
		_dataArray.Add(new CombatStateItem(79, LocalStringManager.GetConfig("CombatState_language", "Name_79"), new List<CombatStateProperty>
		{
			new CombatStateProperty(6, 600, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_79"), LocalStringManager.GetConfig("CombatState_language", "Desc_79")));
		_dataArray.Add(new CombatStateItem(80, LocalStringManager.GetConfig("CombatState_language", "Name_80"), new List<CombatStateProperty>
		{
			new CombatStateProperty(7, 600, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_80"), LocalStringManager.GetConfig("CombatState_language", "Desc_80")));
		_dataArray.Add(new CombatStateItem(81, LocalStringManager.GetConfig("CombatState_language", "Name_81"), new List<CombatStateProperty>
		{
			new CombatStateProperty(8, 600, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_81"), LocalStringManager.GetConfig("CombatState_language", "Desc_81")));
		_dataArray.Add(new CombatStateItem(82, LocalStringManager.GetConfig("CombatState_language", "Name_82"), new List<CombatStateProperty>
		{
			new CombatStateProperty(9, 600, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_82"), LocalStringManager.GetConfig("CombatState_language", "Desc_82")));
		_dataArray.Add(new CombatStateItem(83, LocalStringManager.GetConfig("CombatState_language", "Name_83"), new List<CombatStateProperty>
		{
			new CombatStateProperty(12, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_83"), LocalStringManager.GetConfig("CombatState_language", "Desc_83")));
		_dataArray.Add(new CombatStateItem(84, LocalStringManager.GetConfig("CombatState_language", "Name_84"), new List<CombatStateProperty>
		{
			new CombatStateProperty(13, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_84"), LocalStringManager.GetConfig("CombatState_language", "Desc_84")));
		_dataArray.Add(new CombatStateItem(85, LocalStringManager.GetConfig("CombatState_language", "Name_85"), new List<CombatStateProperty>
		{
			new CombatStateProperty(14, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_85"), LocalStringManager.GetConfig("CombatState_language", "Desc_85")));
		_dataArray.Add(new CombatStateItem(86, LocalStringManager.GetConfig("CombatState_language", "Name_86"), new List<CombatStateProperty>
		{
			new CombatStateProperty(15, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_86"), LocalStringManager.GetConfig("CombatState_language", "Desc_86")));
		_dataArray.Add(new CombatStateItem(87, LocalStringManager.GetConfig("CombatState_language", "Name_87"), new List<CombatStateProperty>
		{
			new CombatStateProperty(16, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_87"), LocalStringManager.GetConfig("CombatState_language", "Desc_87")));
		_dataArray.Add(new CombatStateItem(88, LocalStringManager.GetConfig("CombatState_language", "Name_88"), new List<CombatStateProperty>
		{
			new CombatStateProperty(17, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_88"), LocalStringManager.GetConfig("CombatState_language", "Desc_88")));
		_dataArray.Add(new CombatStateItem(89, LocalStringManager.GetConfig("CombatState_language", "Name_89"), new List<CombatStateProperty>
		{
			new CombatStateProperty(18, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_89"), LocalStringManager.GetConfig("CombatState_language", "Desc_89")));
		_dataArray.Add(new CombatStateItem(90, LocalStringManager.GetConfig("CombatState_language", "Name_90"), new List<CombatStateProperty>
		{
			new CombatStateProperty(19, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_90"), LocalStringManager.GetConfig("CombatState_language", "Desc_90")));
		_dataArray.Add(new CombatStateItem(91, LocalStringManager.GetConfig("CombatState_language", "Name_91"), new List<CombatStateProperty>
		{
			new CombatStateProperty(20, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_91"), LocalStringManager.GetConfig("CombatState_language", "Desc_91")));
		_dataArray.Add(new CombatStateItem(92, LocalStringManager.GetConfig("CombatState_language", "Name_92"), new List<CombatStateProperty>
		{
			new CombatStateProperty(21, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_92"), LocalStringManager.GetConfig("CombatState_language", "Desc_92")));
		_dataArray.Add(new CombatStateItem(93, LocalStringManager.GetConfig("CombatState_language", "Name_93"), new List<CombatStateProperty>
		{
			new CombatStateProperty(4, 16, 1),
			new CombatStateProperty(5, 16, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_93"), LocalStringManager.GetConfig("CombatState_language", "Desc_93")));
		_dataArray.Add(new CombatStateItem(94, LocalStringManager.GetConfig("CombatState_language", "Name_94"), new List<CombatStateProperty>
		{
			new CombatStateProperty(12, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_94"), LocalStringManager.GetConfig("CombatState_language", "Desc_94")));
		_dataArray.Add(new CombatStateItem(95, LocalStringManager.GetConfig("CombatState_language", "Name_95"), new List<CombatStateProperty>
		{
			new CombatStateProperty(13, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_95"), LocalStringManager.GetConfig("CombatState_language", "Desc_95")));
		_dataArray.Add(new CombatStateItem(96, LocalStringManager.GetConfig("CombatState_language", "Name_96"), new List<CombatStateProperty>
		{
			new CombatStateProperty(14, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_96"), LocalStringManager.GetConfig("CombatState_language", "Desc_96")));
		_dataArray.Add(new CombatStateItem(97, LocalStringManager.GetConfig("CombatState_language", "Name_97"), new List<CombatStateProperty>
		{
			new CombatStateProperty(15, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_97"), LocalStringManager.GetConfig("CombatState_language", "Desc_97")));
		_dataArray.Add(new CombatStateItem(98, LocalStringManager.GetConfig("CombatState_language", "Name_98"), new List<CombatStateProperty>
		{
			new CombatStateProperty(16, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_98"), LocalStringManager.GetConfig("CombatState_language", "Desc_98")));
		_dataArray.Add(new CombatStateItem(99, LocalStringManager.GetConfig("CombatState_language", "Name_99"), new List<CombatStateProperty>
		{
			new CombatStateProperty(17, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_99"), LocalStringManager.GetConfig("CombatState_language", "Desc_99")));
		_dataArray.Add(new CombatStateItem(100, LocalStringManager.GetConfig("CombatState_language", "Name_100"), new List<CombatStateProperty>
		{
			new CombatStateProperty(18, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_100"), LocalStringManager.GetConfig("CombatState_language", "Desc_100")));
		_dataArray.Add(new CombatStateItem(101, LocalStringManager.GetConfig("CombatState_language", "Name_101"), new List<CombatStateProperty>
		{
			new CombatStateProperty(19, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_101"), LocalStringManager.GetConfig("CombatState_language", "Desc_101")));
		_dataArray.Add(new CombatStateItem(102, LocalStringManager.GetConfig("CombatState_language", "Name_102"), new List<CombatStateProperty>
		{
			new CombatStateProperty(20, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_102"), LocalStringManager.GetConfig("CombatState_language", "Desc_102")));
		_dataArray.Add(new CombatStateItem(103, LocalStringManager.GetConfig("CombatState_language", "Name_103"), new List<CombatStateProperty>
		{
			new CombatStateProperty(21, 60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_103"), LocalStringManager.GetConfig("CombatState_language", "Desc_103")));
		_dataArray.Add(new CombatStateItem(104, LocalStringManager.GetConfig("CombatState_language", "Name_104"), new List<CombatStateProperty>
		{
			new CombatStateProperty(12, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_104"), LocalStringManager.GetConfig("CombatState_language", "Desc_104")));
		_dataArray.Add(new CombatStateItem(105, LocalStringManager.GetConfig("CombatState_language", "Name_105"), new List<CombatStateProperty>
		{
			new CombatStateProperty(13, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_105"), LocalStringManager.GetConfig("CombatState_language", "Desc_105")));
		_dataArray.Add(new CombatStateItem(106, LocalStringManager.GetConfig("CombatState_language", "Name_106"), new List<CombatStateProperty>
		{
			new CombatStateProperty(14, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_106"), LocalStringManager.GetConfig("CombatState_language", "Desc_106")));
		_dataArray.Add(new CombatStateItem(107, LocalStringManager.GetConfig("CombatState_language", "Name_107"), new List<CombatStateProperty>
		{
			new CombatStateProperty(15, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_107"), LocalStringManager.GetConfig("CombatState_language", "Desc_107")));
		_dataArray.Add(new CombatStateItem(108, LocalStringManager.GetConfig("CombatState_language", "Name_108"), new List<CombatStateProperty>
		{
			new CombatStateProperty(16, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_108"), LocalStringManager.GetConfig("CombatState_language", "Desc_108")));
		_dataArray.Add(new CombatStateItem(109, LocalStringManager.GetConfig("CombatState_language", "Name_109"), new List<CombatStateProperty>
		{
			new CombatStateProperty(17, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_109"), LocalStringManager.GetConfig("CombatState_language", "Desc_109")));
		_dataArray.Add(new CombatStateItem(110, LocalStringManager.GetConfig("CombatState_language", "Name_110"), new List<CombatStateProperty>
		{
			new CombatStateProperty(18, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_110"), LocalStringManager.GetConfig("CombatState_language", "Desc_110")));
		_dataArray.Add(new CombatStateItem(111, LocalStringManager.GetConfig("CombatState_language", "Name_111"), new List<CombatStateProperty>
		{
			new CombatStateProperty(19, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_111"), LocalStringManager.GetConfig("CombatState_language", "Desc_111")));
		_dataArray.Add(new CombatStateItem(112, LocalStringManager.GetConfig("CombatState_language", "Name_112"), new List<CombatStateProperty>
		{
			new CombatStateProperty(20, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_112"), LocalStringManager.GetConfig("CombatState_language", "Desc_112")));
		_dataArray.Add(new CombatStateItem(113, LocalStringManager.GetConfig("CombatState_language", "Name_113"), new List<CombatStateProperty>
		{
			new CombatStateProperty(21, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_113"), LocalStringManager.GetConfig("CombatState_language", "Desc_113")));
		_dataArray.Add(new CombatStateItem(114, LocalStringManager.GetConfig("CombatState_language", "Name_114"), new List<CombatStateProperty>
		{
			new CombatStateProperty(4, 16, 1),
			new CombatStateProperty(5, 16, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_114"), LocalStringManager.GetConfig("CombatState_language", "Desc_114")));
		_dataArray.Add(new CombatStateItem(115, LocalStringManager.GetConfig("CombatState_language", "Name_115"), new List<CombatStateProperty>
		{
			new CombatStateProperty(4, -16, 1),
			new CombatStateProperty(5, -16, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_115"), LocalStringManager.GetConfig("CombatState_language", "Desc_115")));
		_dataArray.Add(new CombatStateItem(116, LocalStringManager.GetConfig("CombatState_language", "Name_116"), new List<CombatStateProperty>
		{
			new CombatStateProperty(9, -6, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_116"), LocalStringManager.GetConfig("CombatState_language", "Desc_116")));
		_dataArray.Add(new CombatStateItem(117, LocalStringManager.GetConfig("CombatState_language", "Name_117"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_117"), LocalStringManager.GetConfig("CombatState_language", "Desc_117")));
		_dataArray.Add(new CombatStateItem(118, LocalStringManager.GetConfig("CombatState_language", "Name_118"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_118"), LocalStringManager.GetConfig("CombatState_language", "Desc_118")));
		_dataArray.Add(new CombatStateItem(119, LocalStringManager.GetConfig("CombatState_language", "Name_119"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_119"), LocalStringManager.GetConfig("CombatState_language", "Desc_119")));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new CombatStateItem(120, LocalStringManager.GetConfig("CombatState_language", "Name_120"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_120"), LocalStringManager.GetConfig("CombatState_language", "Desc_120")));
		_dataArray.Add(new CombatStateItem(121, LocalStringManager.GetConfig("CombatState_language", "Name_121"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_121"), LocalStringManager.GetConfig("CombatState_language", "Desc_121")));
		_dataArray.Add(new CombatStateItem(122, LocalStringManager.GetConfig("CombatState_language", "Name_122"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_122"), LocalStringManager.GetConfig("CombatState_language", "Desc_122")));
		_dataArray.Add(new CombatStateItem(123, LocalStringManager.GetConfig("CombatState_language", "Name_123"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_123"), LocalStringManager.GetConfig("CombatState_language", "Desc_123")));
		_dataArray.Add(new CombatStateItem(124, LocalStringManager.GetConfig("CombatState_language", "Name_124"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_124"), LocalStringManager.GetConfig("CombatState_language", "Desc_124")));
		_dataArray.Add(new CombatStateItem(125, LocalStringManager.GetConfig("CombatState_language", "Name_125"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_125"), LocalStringManager.GetConfig("CombatState_language", "Desc_125")));
		_dataArray.Add(new CombatStateItem(126, LocalStringManager.GetConfig("CombatState_language", "Name_126"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_126"), LocalStringManager.GetConfig("CombatState_language", "Desc_126")));
		_dataArray.Add(new CombatStateItem(127, LocalStringManager.GetConfig("CombatState_language", "Name_127"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_127"), LocalStringManager.GetConfig("CombatState_language", "Desc_127")));
		_dataArray.Add(new CombatStateItem(128, LocalStringManager.GetConfig("CombatState_language", "Name_128"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_128"), LocalStringManager.GetConfig("CombatState_language", "Desc_128")));
		_dataArray.Add(new CombatStateItem(129, LocalStringManager.GetConfig("CombatState_language", "Name_129"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_129"), LocalStringManager.GetConfig("CombatState_language", "Desc_129")));
		_dataArray.Add(new CombatStateItem(130, LocalStringManager.GetConfig("CombatState_language", "Name_130"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_130"), LocalStringManager.GetConfig("CombatState_language", "Desc_130")));
		_dataArray.Add(new CombatStateItem(131, LocalStringManager.GetConfig("CombatState_language", "Name_131"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_131"), LocalStringManager.GetConfig("CombatState_language", "Desc_131")));
		_dataArray.Add(new CombatStateItem(132, LocalStringManager.GetConfig("CombatState_language", "Name_132"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_132"), LocalStringManager.GetConfig("CombatState_language", "Desc_132")));
		_dataArray.Add(new CombatStateItem(133, LocalStringManager.GetConfig("CombatState_language", "Name_133"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_133"), LocalStringManager.GetConfig("CombatState_language", "Desc_133")));
		_dataArray.Add(new CombatStateItem(134, LocalStringManager.GetConfig("CombatState_language", "Name_134"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_134"), LocalStringManager.GetConfig("CombatState_language", "Desc_134")));
		_dataArray.Add(new CombatStateItem(135, LocalStringManager.GetConfig("CombatState_language", "Name_135"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_135"), LocalStringManager.GetConfig("CombatState_language", "Desc_135")));
		_dataArray.Add(new CombatStateItem(136, LocalStringManager.GetConfig("CombatState_language", "Name_136"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_136"), LocalStringManager.GetConfig("CombatState_language", "Desc_136")));
		_dataArray.Add(new CombatStateItem(137, LocalStringManager.GetConfig("CombatState_language", "Name_137"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_137"), LocalStringManager.GetConfig("CombatState_language", "Desc_137")));
		_dataArray.Add(new CombatStateItem(138, LocalStringManager.GetConfig("CombatState_language", "Name_138"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_138"), LocalStringManager.GetConfig("CombatState_language", "Desc_138")));
		_dataArray.Add(new CombatStateItem(139, LocalStringManager.GetConfig("CombatState_language", "Name_139"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_139"), LocalStringManager.GetConfig("CombatState_language", "Desc_139")));
		_dataArray.Add(new CombatStateItem(140, LocalStringManager.GetConfig("CombatState_language", "Name_140"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_140"), LocalStringManager.GetConfig("CombatState_language", "Desc_140")));
		_dataArray.Add(new CombatStateItem(141, LocalStringManager.GetConfig("CombatState_language", "Name_141"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_141"), LocalStringManager.GetConfig("CombatState_language", "Desc_141")));
		_dataArray.Add(new CombatStateItem(142, LocalStringManager.GetConfig("CombatState_language", "Name_142"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_142"), LocalStringManager.GetConfig("CombatState_language", "Desc_142")));
		_dataArray.Add(new CombatStateItem(143, LocalStringManager.GetConfig("CombatState_language", "Name_143"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_143"), LocalStringManager.GetConfig("CombatState_language", "Desc_143")));
		_dataArray.Add(new CombatStateItem(144, LocalStringManager.GetConfig("CombatState_language", "Name_144"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_144"), LocalStringManager.GetConfig("CombatState_language", "Desc_144")));
		_dataArray.Add(new CombatStateItem(145, LocalStringManager.GetConfig("CombatState_language", "Name_145"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_145"), LocalStringManager.GetConfig("CombatState_language", "Desc_145")));
		_dataArray.Add(new CombatStateItem(146, LocalStringManager.GetConfig("CombatState_language", "Name_146"), new List<CombatStateProperty>
		{
			new CombatStateProperty(6, -6, 1),
			new CombatStateProperty(7, -6, 1),
			new CombatStateProperty(8, -6, 1),
			new CombatStateProperty(9, -6, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_146"), LocalStringManager.GetConfig("CombatState_language", "Desc_146")));
		_dataArray.Add(new CombatStateItem(147, LocalStringManager.GetConfig("CombatState_language", "Name_147"), new List<CombatStateProperty>
		{
			new CombatStateProperty(0, -6, 1),
			new CombatStateProperty(1, -6, 1),
			new CombatStateProperty(2, -6, 1),
			new CombatStateProperty(3, -6, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_147"), LocalStringManager.GetConfig("CombatState_language", "Desc_147")));
		_dataArray.Add(new CombatStateItem(148, LocalStringManager.GetConfig("CombatState_language", "Name_148"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_148"), LocalStringManager.GetConfig("CombatState_language", "Desc_148")));
		_dataArray.Add(new CombatStateItem(149, LocalStringManager.GetConfig("CombatState_language", "Name_149"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_149"), LocalStringManager.GetConfig("CombatState_language", "Desc_149")));
		_dataArray.Add(new CombatStateItem(150, LocalStringManager.GetConfig("CombatState_language", "Name_150"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_150"), LocalStringManager.GetConfig("CombatState_language", "Desc_150")));
		_dataArray.Add(new CombatStateItem(151, LocalStringManager.GetConfig("CombatState_language", "Name_151"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_151"), LocalStringManager.GetConfig("CombatState_language", "Desc_151")));
		_dataArray.Add(new CombatStateItem(152, LocalStringManager.GetConfig("CombatState_language", "Name_152"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_152"), LocalStringManager.GetConfig("CombatState_language", "Desc_152")));
		_dataArray.Add(new CombatStateItem(153, LocalStringManager.GetConfig("CombatState_language", "Name_153"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_153"), LocalStringManager.GetConfig("CombatState_language", "Desc_153")));
		_dataArray.Add(new CombatStateItem(154, LocalStringManager.GetConfig("CombatState_language", "Name_154"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_154"), LocalStringManager.GetConfig("CombatState_language", "Desc_154")));
		_dataArray.Add(new CombatStateItem(155, LocalStringManager.GetConfig("CombatState_language", "Name_155"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_155"), LocalStringManager.GetConfig("CombatState_language", "Desc_155")));
		_dataArray.Add(new CombatStateItem(156, LocalStringManager.GetConfig("CombatState_language", "Name_156"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_156"), LocalStringManager.GetConfig("CombatState_language", "Desc_156")));
		_dataArray.Add(new CombatStateItem(157, LocalStringManager.GetConfig("CombatState_language", "Name_157"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_157"), LocalStringManager.GetConfig("CombatState_language", "Desc_157")));
		_dataArray.Add(new CombatStateItem(158, LocalStringManager.GetConfig("CombatState_language", "Name_158"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_158"), LocalStringManager.GetConfig("CombatState_language", "Desc_158")));
		_dataArray.Add(new CombatStateItem(159, LocalStringManager.GetConfig("CombatState_language", "Name_159"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_159"), LocalStringManager.GetConfig("CombatState_language", "Desc_159")));
		_dataArray.Add(new CombatStateItem(160, LocalStringManager.GetConfig("CombatState_language", "Name_160"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_160"), LocalStringManager.GetConfig("CombatState_language", "Desc_160")));
		_dataArray.Add(new CombatStateItem(161, LocalStringManager.GetConfig("CombatState_language", "Name_161"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_161"), LocalStringManager.GetConfig("CombatState_language", "Desc_161")));
		_dataArray.Add(new CombatStateItem(162, LocalStringManager.GetConfig("CombatState_language", "Name_162"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_162"), LocalStringManager.GetConfig("CombatState_language", "Desc_162")));
		_dataArray.Add(new CombatStateItem(163, LocalStringManager.GetConfig("CombatState_language", "Name_163"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_163"), LocalStringManager.GetConfig("CombatState_language", "Desc_163")));
		_dataArray.Add(new CombatStateItem(164, LocalStringManager.GetConfig("CombatState_language", "Name_164"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_164"), LocalStringManager.GetConfig("CombatState_language", "Desc_164")));
		_dataArray.Add(new CombatStateItem(165, LocalStringManager.GetConfig("CombatState_language", "Name_165"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_165"), LocalStringManager.GetConfig("CombatState_language", "Desc_165")));
		_dataArray.Add(new CombatStateItem(166, LocalStringManager.GetConfig("CombatState_language", "Name_166"), new List<CombatStateProperty>(), 167, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_166"), LocalStringManager.GetConfig("CombatState_language", "Desc_166")));
		_dataArray.Add(new CombatStateItem(167, LocalStringManager.GetConfig("CombatState_language", "Name_167"), new List<CombatStateProperty>(), 166, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_167"), LocalStringManager.GetConfig("CombatState_language", "Desc_167")));
		_dataArray.Add(new CombatStateItem(168, LocalStringManager.GetConfig("CombatState_language", "Name_168"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_168"), LocalStringManager.GetConfig("CombatState_language", "Desc_168")));
		_dataArray.Add(new CombatStateItem(169, LocalStringManager.GetConfig("CombatState_language", "Name_169"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_169"), LocalStringManager.GetConfig("CombatState_language", "Desc_169")));
		_dataArray.Add(new CombatStateItem(170, LocalStringManager.GetConfig("CombatState_language", "Name_170"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_170"), LocalStringManager.GetConfig("CombatState_language", "Desc_170")));
		_dataArray.Add(new CombatStateItem(171, LocalStringManager.GetConfig("CombatState_language", "Name_171"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_171"), LocalStringManager.GetConfig("CombatState_language", "Desc_171")));
		_dataArray.Add(new CombatStateItem(172, LocalStringManager.GetConfig("CombatState_language", "Name_172"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_172"), LocalStringManager.GetConfig("CombatState_language", "Desc_172")));
		_dataArray.Add(new CombatStateItem(173, LocalStringManager.GetConfig("CombatState_language", "Name_173"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_173"), LocalStringManager.GetConfig("CombatState_language", "Desc_173")));
		_dataArray.Add(new CombatStateItem(174, LocalStringManager.GetConfig("CombatState_language", "Name_174"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_174"), LocalStringManager.GetConfig("CombatState_language", "Desc_174")));
		_dataArray.Add(new CombatStateItem(175, LocalStringManager.GetConfig("CombatState_language", "Name_175"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_175"), LocalStringManager.GetConfig("CombatState_language", "Desc_175")));
		_dataArray.Add(new CombatStateItem(176, LocalStringManager.GetConfig("CombatState_language", "Name_176"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_176"), LocalStringManager.GetConfig("CombatState_language", "Desc_176")));
		_dataArray.Add(new CombatStateItem(177, LocalStringManager.GetConfig("CombatState_language", "Name_177"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_177"), LocalStringManager.GetConfig("CombatState_language", "Desc_177")));
		_dataArray.Add(new CombatStateItem(178, LocalStringManager.GetConfig("CombatState_language", "Name_178"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_178"), LocalStringManager.GetConfig("CombatState_language", "Desc_178")));
		_dataArray.Add(new CombatStateItem(179, LocalStringManager.GetConfig("CombatState_language", "Name_179"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_179"), LocalStringManager.GetConfig("CombatState_language", "Desc_179")));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new CombatStateItem(180, LocalStringManager.GetConfig("CombatState_language", "Name_180"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_180"), LocalStringManager.GetConfig("CombatState_language", "Desc_180")));
		_dataArray.Add(new CombatStateItem(181, LocalStringManager.GetConfig("CombatState_language", "Name_181"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_181"), LocalStringManager.GetConfig("CombatState_language", "Desc_181")));
		_dataArray.Add(new CombatStateItem(182, LocalStringManager.GetConfig("CombatState_language", "Name_182"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_182"), LocalStringManager.GetConfig("CombatState_language", "Desc_182")));
		_dataArray.Add(new CombatStateItem(183, LocalStringManager.GetConfig("CombatState_language", "Name_183"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_183"), LocalStringManager.GetConfig("CombatState_language", "Desc_183")));
		_dataArray.Add(new CombatStateItem(184, LocalStringManager.GetConfig("CombatState_language", "Name_184"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_184"), LocalStringManager.GetConfig("CombatState_language", "Desc_184")));
		_dataArray.Add(new CombatStateItem(185, LocalStringManager.GetConfig("CombatState_language", "Name_185"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_185"), LocalStringManager.GetConfig("CombatState_language", "Desc_185")));
		_dataArray.Add(new CombatStateItem(186, LocalStringManager.GetConfig("CombatState_language", "Name_186"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_186"), LocalStringManager.GetConfig("CombatState_language", "Desc_186")));
		_dataArray.Add(new CombatStateItem(187, LocalStringManager.GetConfig("CombatState_language", "Name_187"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_187"), LocalStringManager.GetConfig("CombatState_language", "Desc_187")));
		_dataArray.Add(new CombatStateItem(188, LocalStringManager.GetConfig("CombatState_language", "Name_188"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_188"), LocalStringManager.GetConfig("CombatState_language", "Desc_188")));
		_dataArray.Add(new CombatStateItem(189, LocalStringManager.GetConfig("CombatState_language", "Name_189"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_189"), LocalStringManager.GetConfig("CombatState_language", "Desc_189")));
		_dataArray.Add(new CombatStateItem(190, LocalStringManager.GetConfig("CombatState_language", "Name_190"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_190"), LocalStringManager.GetConfig("CombatState_language", "Desc_190")));
		_dataArray.Add(new CombatStateItem(191, LocalStringManager.GetConfig("CombatState_language", "Name_191"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_191"), LocalStringManager.GetConfig("CombatState_language", "Desc_191")));
		_dataArray.Add(new CombatStateItem(192, LocalStringManager.GetConfig("CombatState_language", "Name_192"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_192"), LocalStringManager.GetConfig("CombatState_language", "Desc_192")));
		_dataArray.Add(new CombatStateItem(193, LocalStringManager.GetConfig("CombatState_language", "Name_193"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_193"), LocalStringManager.GetConfig("CombatState_language", "Desc_193")));
		_dataArray.Add(new CombatStateItem(194, LocalStringManager.GetConfig("CombatState_language", "Name_194"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_194"), LocalStringManager.GetConfig("CombatState_language", "Desc_194")));
		_dataArray.Add(new CombatStateItem(195, LocalStringManager.GetConfig("CombatState_language", "Name_195"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_195"), LocalStringManager.GetConfig("CombatState_language", "Desc_195")));
		_dataArray.Add(new CombatStateItem(196, LocalStringManager.GetConfig("CombatState_language", "Name_196"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_196"), LocalStringManager.GetConfig("CombatState_language", "Desc_196")));
		_dataArray.Add(new CombatStateItem(197, LocalStringManager.GetConfig("CombatState_language", "Name_197"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_197"), LocalStringManager.GetConfig("CombatState_language", "Desc_197")));
		_dataArray.Add(new CombatStateItem(198, LocalStringManager.GetConfig("CombatState_language", "Name_198"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_198"), LocalStringManager.GetConfig("CombatState_language", "Desc_198")));
		_dataArray.Add(new CombatStateItem(199, LocalStringManager.GetConfig("CombatState_language", "Name_199"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_199"), LocalStringManager.GetConfig("CombatState_language", "Desc_199")));
		_dataArray.Add(new CombatStateItem(200, LocalStringManager.GetConfig("CombatState_language", "Name_200"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_200"), LocalStringManager.GetConfig("CombatState_language", "Desc_200")));
		_dataArray.Add(new CombatStateItem(201, LocalStringManager.GetConfig("CombatState_language", "Name_201"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_201"), LocalStringManager.GetConfig("CombatState_language", "Desc_201")));
		_dataArray.Add(new CombatStateItem(202, LocalStringManager.GetConfig("CombatState_language", "Name_202"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_202"), LocalStringManager.GetConfig("CombatState_language", "Desc_202")));
		_dataArray.Add(new CombatStateItem(203, LocalStringManager.GetConfig("CombatState_language", "Name_203"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_203"), LocalStringManager.GetConfig("CombatState_language", "Desc_203")));
		_dataArray.Add(new CombatStateItem(204, LocalStringManager.GetConfig("CombatState_language", "Name_204"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_204"), LocalStringManager.GetConfig("CombatState_language", "Desc_204")));
		_dataArray.Add(new CombatStateItem(205, LocalStringManager.GetConfig("CombatState_language", "Name_205"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_205"), LocalStringManager.GetConfig("CombatState_language", "Desc_205")));
		_dataArray.Add(new CombatStateItem(206, LocalStringManager.GetConfig("CombatState_language", "Name_206"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_206"), LocalStringManager.GetConfig("CombatState_language", "Desc_206")));
		_dataArray.Add(new CombatStateItem(207, LocalStringManager.GetConfig("CombatState_language", "Name_207"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_207"), LocalStringManager.GetConfig("CombatState_language", "Desc_207")));
		_dataArray.Add(new CombatStateItem(208, LocalStringManager.GetConfig("CombatState_language", "Name_208"), new List<CombatStateProperty>
		{
			new CombatStateProperty(34, 2, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_208"), LocalStringManager.GetConfig("CombatState_language", "Desc_208")));
		_dataArray.Add(new CombatStateItem(209, LocalStringManager.GetConfig("CombatState_language", "Name_209"), new List<CombatStateProperty>
		{
			new CombatStateProperty(33, 2, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_209"), LocalStringManager.GetConfig("CombatState_language", "Desc_209")));
		_dataArray.Add(new CombatStateItem(210, LocalStringManager.GetConfig("CombatState_language", "Name_210"), new List<CombatStateProperty>
		{
			new CombatStateProperty(22, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_210"), LocalStringManager.GetConfig("CombatState_language", "Desc_210")));
		_dataArray.Add(new CombatStateItem(211, LocalStringManager.GetConfig("CombatState_language", "Name_211"), new List<CombatStateProperty>
		{
			new CombatStateProperty(22, 30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_211"), LocalStringManager.GetConfig("CombatState_language", "Desc_211")));
		_dataArray.Add(new CombatStateItem(212, LocalStringManager.GetConfig("CombatState_language", "Name_212"), new List<CombatStateProperty>
		{
			new CombatStateProperty(23, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_212"), LocalStringManager.GetConfig("CombatState_language", "Desc_212")));
		_dataArray.Add(new CombatStateItem(213, LocalStringManager.GetConfig("CombatState_language", "Name_213"), new List<CombatStateProperty>
		{
			new CombatStateProperty(23, 30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_213"), LocalStringManager.GetConfig("CombatState_language", "Desc_213")));
		_dataArray.Add(new CombatStateItem(214, LocalStringManager.GetConfig("CombatState_language", "Name_214"), new List<CombatStateProperty>
		{
			new CombatStateProperty(24, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_214"), LocalStringManager.GetConfig("CombatState_language", "Desc_214")));
		_dataArray.Add(new CombatStateItem(215, LocalStringManager.GetConfig("CombatState_language", "Name_215"), new List<CombatStateProperty>
		{
			new CombatStateProperty(24, 30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_215"), LocalStringManager.GetConfig("CombatState_language", "Desc_215")));
		_dataArray.Add(new CombatStateItem(216, LocalStringManager.GetConfig("CombatState_language", "Name_216"), new List<CombatStateProperty>
		{
			new CombatStateProperty(25, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_216"), LocalStringManager.GetConfig("CombatState_language", "Desc_216")));
		_dataArray.Add(new CombatStateItem(217, LocalStringManager.GetConfig("CombatState_language", "Name_217"), new List<CombatStateProperty>
		{
			new CombatStateProperty(25, 30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_217"), LocalStringManager.GetConfig("CombatState_language", "Desc_217")));
		_dataArray.Add(new CombatStateItem(218, LocalStringManager.GetConfig("CombatState_language", "Name_218"), new List<CombatStateProperty>
		{
			new CombatStateProperty(26, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_218"), LocalStringManager.GetConfig("CombatState_language", "Desc_218")));
		_dataArray.Add(new CombatStateItem(219, LocalStringManager.GetConfig("CombatState_language", "Name_219"), new List<CombatStateProperty>
		{
			new CombatStateProperty(26, 30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_219"), LocalStringManager.GetConfig("CombatState_language", "Desc_219")));
		_dataArray.Add(new CombatStateItem(220, LocalStringManager.GetConfig("CombatState_language", "Name_220"), new List<CombatStateProperty>
		{
			new CombatStateProperty(27, -60, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_220"), LocalStringManager.GetConfig("CombatState_language", "Desc_220")));
		_dataArray.Add(new CombatStateItem(221, LocalStringManager.GetConfig("CombatState_language", "Name_221"), new List<CombatStateProperty>
		{
			new CombatStateProperty(27, 30, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_221"), LocalStringManager.GetConfig("CombatState_language", "Desc_221")));
		_dataArray.Add(new CombatStateItem(222, LocalStringManager.GetConfig("CombatState_language", "Name_222"), new List<CombatStateProperty>
		{
			new CombatStateProperty(35, 10, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_222"), LocalStringManager.GetConfig("CombatState_language", "Desc_222")));
		_dataArray.Add(new CombatStateItem(223, LocalStringManager.GetConfig("CombatState_language", "Name_223"), new List<CombatStateProperty>
		{
			new CombatStateProperty(35, -10, 0)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_223"), LocalStringManager.GetConfig("CombatState_language", "Desc_223")));
		_dataArray.Add(new CombatStateItem(224, LocalStringManager.GetConfig("CombatState_language", "Name_224"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_224"), LocalStringManager.GetConfig("CombatState_language", "Desc_224")));
		_dataArray.Add(new CombatStateItem(225, LocalStringManager.GetConfig("CombatState_language", "Name_225"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_225"), LocalStringManager.GetConfig("CombatState_language", "Desc_225")));
		_dataArray.Add(new CombatStateItem(226, LocalStringManager.GetConfig("CombatState_language", "Name_226"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_226"), LocalStringManager.GetConfig("CombatState_language", "Desc_226")));
		_dataArray.Add(new CombatStateItem(227, LocalStringManager.GetConfig("CombatState_language", "Name_227"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_227"), LocalStringManager.GetConfig("CombatState_language", "Desc_227")));
		_dataArray.Add(new CombatStateItem(228, LocalStringManager.GetConfig("CombatState_language", "Name_228"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_228"), LocalStringManager.GetConfig("CombatState_language", "Desc_228")));
		_dataArray.Add(new CombatStateItem(229, LocalStringManager.GetConfig("CombatState_language", "Name_229"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_229"), LocalStringManager.GetConfig("CombatState_language", "Desc_229")));
		_dataArray.Add(new CombatStateItem(230, LocalStringManager.GetConfig("CombatState_language", "Name_230"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_230"), LocalStringManager.GetConfig("CombatState_language", "Desc_230")));
		_dataArray.Add(new CombatStateItem(231, LocalStringManager.GetConfig("CombatState_language", "Name_231"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_231"), LocalStringManager.GetConfig("CombatState_language", "Desc_231")));
		_dataArray.Add(new CombatStateItem(232, LocalStringManager.GetConfig("CombatState_language", "Name_232"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_232"), LocalStringManager.GetConfig("CombatState_language", "Desc_232")));
		_dataArray.Add(new CombatStateItem(233, LocalStringManager.GetConfig("CombatState_language", "Name_233"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_233"), LocalStringManager.GetConfig("CombatState_language", "Desc_233")));
		_dataArray.Add(new CombatStateItem(234, LocalStringManager.GetConfig("CombatState_language", "Name_234"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_234"), LocalStringManager.GetConfig("CombatState_language", "Desc_234")));
		_dataArray.Add(new CombatStateItem(235, LocalStringManager.GetConfig("CombatState_language", "Name_235"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_235"), LocalStringManager.GetConfig("CombatState_language", "Desc_235")));
		_dataArray.Add(new CombatStateItem(236, LocalStringManager.GetConfig("CombatState_language", "Name_236"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_236"), LocalStringManager.GetConfig("CombatState_language", "Desc_236")));
		_dataArray.Add(new CombatStateItem(237, LocalStringManager.GetConfig("CombatState_language", "Name_237"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_237"), LocalStringManager.GetConfig("CombatState_language", "Desc_237")));
		_dataArray.Add(new CombatStateItem(238, LocalStringManager.GetConfig("CombatState_language", "Name_238"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_238"), LocalStringManager.GetConfig("CombatState_language", "Desc_238")));
		_dataArray.Add(new CombatStateItem(239, LocalStringManager.GetConfig("CombatState_language", "Name_239"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_239"), LocalStringManager.GetConfig("CombatState_language", "Desc_239")));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new CombatStateItem(240, LocalStringManager.GetConfig("CombatState_language", "Name_240"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_240"), LocalStringManager.GetConfig("CombatState_language", "Desc_240")));
		_dataArray.Add(new CombatStateItem(241, LocalStringManager.GetConfig("CombatState_language", "Name_241"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_241"), LocalStringManager.GetConfig("CombatState_language", "Desc_241")));
		_dataArray.Add(new CombatStateItem(242, LocalStringManager.GetConfig("CombatState_language", "Name_242"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_242"), LocalStringManager.GetConfig("CombatState_language", "Desc_242")));
		_dataArray.Add(new CombatStateItem(243, LocalStringManager.GetConfig("CombatState_language", "Name_243"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_243"), LocalStringManager.GetConfig("CombatState_language", "Desc_243")));
		_dataArray.Add(new CombatStateItem(244, LocalStringManager.GetConfig("CombatState_language", "Name_244"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_244"), LocalStringManager.GetConfig("CombatState_language", "Desc_244")));
		_dataArray.Add(new CombatStateItem(245, LocalStringManager.GetConfig("CombatState_language", "Name_245"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_245"), LocalStringManager.GetConfig("CombatState_language", "Desc_245")));
		_dataArray.Add(new CombatStateItem(246, LocalStringManager.GetConfig("CombatState_language", "Name_246"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_246"), LocalStringManager.GetConfig("CombatState_language", "Desc_246")));
		_dataArray.Add(new CombatStateItem(247, LocalStringManager.GetConfig("CombatState_language", "Name_247"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_247"), LocalStringManager.GetConfig("CombatState_language", "Desc_247")));
		_dataArray.Add(new CombatStateItem(248, LocalStringManager.GetConfig("CombatState_language", "Name_248"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_248"), LocalStringManager.GetConfig("CombatState_language", "Desc_248")));
		_dataArray.Add(new CombatStateItem(249, LocalStringManager.GetConfig("CombatState_language", "Name_249"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_249"), LocalStringManager.GetConfig("CombatState_language", "Desc_249")));
		_dataArray.Add(new CombatStateItem(250, LocalStringManager.GetConfig("CombatState_language", "Name_250"), new List<CombatStateProperty>(), -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_250"), LocalStringManager.GetConfig("CombatState_language", "Desc_250")));
		_dataArray.Add(new CombatStateItem(251, LocalStringManager.GetConfig("CombatState_language", "Name_251"), new List<CombatStateProperty>
		{
			new CombatStateProperty(36, -5, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_251"), LocalStringManager.GetConfig("CombatState_language", "Desc_251")));
		_dataArray.Add(new CombatStateItem(252, LocalStringManager.GetConfig("CombatState_language", "Name_252"), new List<CombatStateProperty>
		{
			new CombatStateProperty(36, 5, 1)
		}, -1, LocalStringManager.GetConfig("CombatState_language", "TipsDesc_252"), LocalStringManager.GetConfig("CombatState_language", "Desc_252")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CombatStateItem>(253);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
	}
}
