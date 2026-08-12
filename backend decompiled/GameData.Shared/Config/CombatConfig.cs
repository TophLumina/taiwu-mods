using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CombatConfig : ConfigData<CombatConfigItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 通常切磋
		/// </summary>
		public const short PlayNormal = 0;

		/// <summary>
		/// 通常恶斗
		/// </summary>
		public const short BeatNormal = 1;

		/// <summary>
		/// 通常死斗
		/// </summary>
		public const short DieNormal = 2;

		/// <summary>
		/// 通常接招
		/// </summary>
		public const short TestNormal = 3;

		/// <summary>
		/// 通常观战
		/// </summary>
		public const short NpcNormal = 242;

		/// <summary>
		/// 不逃切磋
		/// </summary>
		public const short PlayNoFlee = 4;

		/// <summary>
		/// 不逃恶斗
		/// </summary>
		public const short BeatNoFlee = 5;

		/// <summary>
		/// 不逃死斗
		/// </summary>
		public const short DieNoFlee = 6;

		/// <summary>
		/// 近距恶斗
		/// </summary>
		public const short BeatShort = 7;

		/// <summary>
		/// 中距恶斗
		/// </summary>
		public const short BeatMiddle = 8;

		/// <summary>
		/// 长距恶斗
		/// </summary>
		public const short BeatFar = 9;

		/// <summary>
		/// 近距死斗
		/// </summary>
		public const short DieShort = 10;

		/// <summary>
		/// 中距死斗
		/// </summary>
		public const short DieMiddle = 11;

		/// <summary>
		/// 长距死斗
		/// </summary>
		public const short DieFar = 12;

		/// <summary>
		/// 金功死斗
		/// </summary>
		public const short DieGold = 13;

		/// <summary>
		/// 木功死斗
		/// </summary>
		public const short DieWood = 14;

		/// <summary>
		/// 水功死斗
		/// </summary>
		public const short DieWater = 15;

		/// <summary>
		/// 火功死斗
		/// </summary>
		public const short DieFire = 16;

		/// <summary>
		/// 土功死斗
		/// </summary>
		public const short DieSoil = 17;

		/// <summary>
		/// 混功死斗
		/// </summary>
		public const short DieMixed = 18;

		/// <summary>
		/// 金功不逃死斗
		/// </summary>
		public const short DieGoldNoFlee = 19;

		/// <summary>
		/// 木功不逃死斗
		/// </summary>
		public const short DieWoodNoFlee = 20;

		/// <summary>
		/// 水功不逃死斗
		/// </summary>
		public const short DieWaterNoFlee = 21;

		/// <summary>
		/// 火功不逃死斗
		/// </summary>
		public const short DieFireNoFlee = 22;

		/// <summary>
		/// 土功不逃死斗
		/// </summary>
		public const short DieSoilNoFlee = 23;

		/// <summary>
		/// 混功不逃死斗
		/// </summary>
		public const short DieMixedNoFlee = 24;

		/// <summary>
		/// 拳掌死斗
		/// </summary>
		public const short DieFistAndPalm = 25;

		/// <summary>
		/// 指法死斗
		/// </summary>
		public const short DieFinger = 26;

		/// <summary>
		/// 腿法死斗
		/// </summary>
		public const short DieLeg = 27;

		/// <summary>
		/// 暗器死斗
		/// </summary>
		public const short DieThrow = 28;

		/// <summary>
		/// 剑法死斗
		/// </summary>
		public const short DieSword = 29;

		/// <summary>
		/// 刀法死斗
		/// </summary>
		public const short DieBlade = 30;

		/// <summary>
		/// 长兵死斗
		/// </summary>
		public const short DiePolearm = 31;

		/// <summary>
		/// 奇门死斗
		/// </summary>
		public const short DieSpecial = 32;

		/// <summary>
		/// 软兵死斗
		/// </summary>
		public const short DieWhip = 33;

		/// <summary>
		/// 御射死斗
		/// </summary>
		public const short DieControllableShot = 34;

		/// <summary>
		/// 乐器死斗
		/// </summary>
		public const short DieCombatMusic = 35;

		/// <summary>
		/// 冢中莫女
		/// </summary>
		public const short BossMoNv = 36;

		/// <summary>
		/// 冢中大岳瑶常
		/// </summary>
		public const short BossDaYueYaoChang = 37;

		/// <summary>
		/// 冢中九寒
		/// </summary>
		public const short BossJiuHan = 38;

		/// <summary>
		/// 冢中金凰儿
		/// </summary>
		public const short BossJinHuangEr = 39;

		/// <summary>
		/// 冢中衣以候
		/// </summary>
		public const short BossYiYiHou = 40;

		/// <summary>
		/// 冢中卫起
		/// </summary>
		public const short BossWeiQi = 41;

		/// <summary>
		/// 冢中以向
		/// </summary>
		public const short BossYiXiang = 42;

		/// <summary>
		/// 冢中血枫
		/// </summary>
		public const short BossXueFeng = 43;

		/// <summary>
		/// 冢中术方
		/// </summary>
		public const short BossShuFang = 44;

		/// <summary>
		/// 离冢莫女
		/// </summary>
		public const short OutBossMoNv = 45;

		/// <summary>
		/// 离冢大岳瑶常
		/// </summary>
		public const short OutBossDaYueYaoChang = 46;

		/// <summary>
		/// 离冢九寒
		/// </summary>
		public const short OutBossJiuHan = 47;

		/// <summary>
		/// 离冢金凰儿
		/// </summary>
		public const short OutBossJinHuangEr = 48;

		/// <summary>
		/// 离冢衣以候
		/// </summary>
		public const short OutBossYiYiHou = 49;

		/// <summary>
		/// 离冢卫起
		/// </summary>
		public const short OutBossWeiQi = 50;

		/// <summary>
		/// 离冢以向
		/// </summary>
		public const short OutBossYiXiang = 51;

		/// <summary>
		/// 离冢血枫
		/// </summary>
		public const short OutBossXueFeng = 52;

		/// <summary>
		/// 离冢术方
		/// </summary>
		public const short OutBossShuFang = 53;

		/// <summary>
		/// 玄石莫女
		/// </summary>
		public const short RockBossMoNv = 54;

		/// <summary>
		/// 玄石大岳瑶常
		/// </summary>
		public const short RockBossDaYueYaoChang = 55;

		/// <summary>
		/// 玄石九寒
		/// </summary>
		public const short RockBossJiuHan = 56;

		/// <summary>
		/// 玄石金凰儿
		/// </summary>
		public const short RockBossJinHuangEr = 57;

		/// <summary>
		/// 玄石衣以候
		/// </summary>
		public const short RockBossYiYiHou = 58;

		/// <summary>
		/// 玄石卫起
		/// </summary>
		public const short RockBossWeiQi = 59;

		/// <summary>
		/// 玄石以向
		/// </summary>
		public const short RockBossYiXiang = 60;

		/// <summary>
		/// 玄石血枫
		/// </summary>
		public const short RockBossXueFeng = 61;

		/// <summary>
		/// 玄石术方
		/// </summary>
		public const short RockBossShuFang = 62;

		/// <summary>
		/// 紫竹莫女
		/// </summary>
		public const short BambooBossMoNv = 63;

		/// <summary>
		/// 紫竹大岳瑶常
		/// </summary>
		public const short BambooBossDaYueYaoChang = 64;

		/// <summary>
		/// 紫竹九寒
		/// </summary>
		public const short BambooBossJiuHan = 65;

		/// <summary>
		/// 紫竹金凰儿
		/// </summary>
		public const short BambooBossJinHuangEr = 66;

		/// <summary>
		/// 紫竹衣以候
		/// </summary>
		public const short BambooBossYiYiHou = 67;

		/// <summary>
		/// 紫竹卫起
		/// </summary>
		public const short BambooBossWeiQi = 68;

		/// <summary>
		/// 紫竹以向
		/// </summary>
		public const short BambooBossYiXiang = 69;

		/// <summary>
		/// 紫竹血枫
		/// </summary>
		public const short BambooBossXueFeng = 70;

		/// <summary>
		/// 紫竹术方
		/// </summary>
		public const short BambooBossShuFang = 71;

		/// <summary>
		/// 相枢
		/// </summary>
		public const short BossXiangShu = 72;

		/// <summary>
		/// 染尘子
		/// </summary>
		public const short BossRanChenZi = 73;

		/// <summary>
		/// 焕心
		/// </summary>
		public const short BossHuanXin = 74;

		/// <summary>
		/// 龙语茯
		/// </summary>
		public const short BossLongYuFu = 75;

		/// <summary>
		/// 紫无绡
		/// </summary>
		public const short BossZiWuXiao = 76;

		/// <summary>
		/// 恶斗无掉落
		/// </summary>
		public const short BeatNoReward = 77;

		/// <summary>
		/// 死斗无掉落
		/// </summary>
		public const short DieNoReward = 78;

		/// <summary>
		/// 拳掌切磋
		/// </summary>
		public const short PlayCombatFistAndPalm = 79;

		/// <summary>
		/// 指法切磋
		/// </summary>
		public const short PlayCombatFinger = 80;

		/// <summary>
		/// 腿法切磋
		/// </summary>
		public const short PlayCombatLeg = 81;

		/// <summary>
		/// 暗器切磋
		/// </summary>
		public const short PlayCombatThrow = 82;

		/// <summary>
		/// 剑法切磋
		/// </summary>
		public const short PlayCombatSword = 83;

		/// <summary>
		/// 刀法切磋
		/// </summary>
		public const short PlayCombatBlade = 84;

		/// <summary>
		/// 长兵切磋
		/// </summary>
		public const short PlayCombatPolearm = 85;

		/// <summary>
		/// 奇门切磋
		/// </summary>
		public const short PlayCombatSpecial = 86;

		/// <summary>
		/// 软兵切磋
		/// </summary>
		public const short PlayCombatWhip = 87;

		/// <summary>
		/// 御射切磋
		/// </summary>
		public const short PlayCombatControllableShot = 88;

		/// <summary>
		/// 乐器切磋
		/// </summary>
		public const short PlayCombatMusic = 89;

		/// <summary>
		/// 武林大会少林
		/// </summary>
		public const short WulinConferenceShaolin = 90;

		/// <summary>
		/// 武林大会峨眉
		/// </summary>
		public const short WulinConferenceEmei = 91;

		/// <summary>
		/// 武林大会百花
		/// </summary>
		public const short WulinConferenceBaihua = 92;

		/// <summary>
		/// 武林大会武当
		/// </summary>
		public const short WulinConferenceWudang = 93;

		/// <summary>
		/// 武林大会元山
		/// </summary>
		public const short WulinConferenceYuanshan = 94;

		/// <summary>
		/// 武林大会狮相
		/// </summary>
		public const short WulinConferenceShixiang = 95;

		/// <summary>
		/// 武林大会然山
		/// </summary>
		public const short WulinConferenceRanshan = 96;

		/// <summary>
		/// 武林大会璇女
		/// </summary>
		public const short WulinConferenceXuannv = 97;

		/// <summary>
		/// 武林大会铸剑
		/// </summary>
		public const short WulinConferenceZhujian = 98;

		/// <summary>
		/// 武林大会空桑
		/// </summary>
		public const short WulinConferenceKongsang = 99;

		/// <summary>
		/// 武林大会金刚
		/// </summary>
		public const short WulinConferenceJingang = 100;

		/// <summary>
		/// 武林大会五仙
		/// </summary>
		public const short WulinConferenceWuxian = 101;

		/// <summary>
		/// 武林大会界青
		/// </summary>
		public const short WulinConferenceJieqing = 102;

		/// <summary>
		/// 武林大会伏龙
		/// </summary>
		public const short WulinConferenceFulong = 103;

		/// <summary>
		/// 武林大会血犼
		/// </summary>
		public const short WulinConferenceXuehou = 104;

		/// <summary>
		/// 切磋少林
		/// </summary>
		public const short PlayCombatShaolin = 105;

		/// <summary>
		/// 切磋峨眉
		/// </summary>
		public const short PlayCombatEmei = 106;

		/// <summary>
		/// 切磋百花
		/// </summary>
		public const short PlayCombatBaihua = 107;

		/// <summary>
		/// 切磋武当
		/// </summary>
		public const short PlayCombatWudang = 108;

		/// <summary>
		/// 切磋元山
		/// </summary>
		public const short PlayCombatYuanshan = 109;

		/// <summary>
		/// 切磋狮相
		/// </summary>
		public const short PlayCombatShixiang = 110;

		/// <summary>
		/// 切磋然山
		/// </summary>
		public const short PlayCombatRanshan = 111;

		/// <summary>
		/// 切磋璇女
		/// </summary>
		public const short PlayCombatXuannv = 112;

		/// <summary>
		/// 切磋铸剑
		/// </summary>
		public const short PlayCombatZhujian = 113;

		/// <summary>
		/// 切磋空桑
		/// </summary>
		public const short PlayCombatKongsang = 114;

		/// <summary>
		/// 切磋金刚
		/// </summary>
		public const short PlayCombatJingang = 115;

		/// <summary>
		/// 切磋五仙
		/// </summary>
		public const short PlayCombatWuxian = 116;

		/// <summary>
		/// 切磋界青
		/// </summary>
		public const short PlayCombatJieqing = 117;

		/// <summary>
		/// 切磋伏龙
		/// </summary>
		public const short PlayCombatFulong = 118;

		/// <summary>
		/// 切磋血犼
		/// </summary>
		public const short PlayCombatXuehou = 119;

		/// <summary>
		/// 切磋不绑
		/// </summary>
		public const short PlayNoKidnap = 120;

		/// <summary>
		/// 恶斗不绑
		/// </summary>
		public const short BeatNoKidnap = 121;

		/// <summary>
		/// 死斗不绑
		/// </summary>
		public const short DieNoKidnap = 122;

		/// <summary>
		/// 恶斗不绑不掉
		/// </summary>
		public const short BeatNone = 123;

		/// <summary>
		/// 死斗不绑不掉
		/// </summary>
		public const short DieNone = 124;

		/// <summary>
		/// 演武第3章
		/// </summary>
		public const short Tutorial3 = 249;

		/// <summary>
		/// 演武第4章
		/// </summary>
		public const short Tutorial4 = 125;

		/// <summary>
		/// 剧情离冢莫女
		/// </summary>
		public const short OutBossMoNvNoFlee = 126;

		/// <summary>
		/// 剧情离冢大岳瑶常
		/// </summary>
		public const short OutBossDaYueYaoChangNoFlee = 127;

		/// <summary>
		/// 剧情离冢九寒
		/// </summary>
		public const short OutBossJiuHanNoFlee = 128;

		/// <summary>
		/// 剧情离冢金凰儿
		/// </summary>
		public const short OutBossJinHuangErNoFlee = 129;

		/// <summary>
		/// 剧情离冢衣以候
		/// </summary>
		public const short OutBossYiYiHouNoFlee = 130;

		/// <summary>
		/// 剧情离冢卫起
		/// </summary>
		public const short OutBossWeiQiNoFlee = 131;

		/// <summary>
		/// 剧情离冢以向
		/// </summary>
		public const short OutBossYiXiangNoFlee = 132;

		/// <summary>
		/// 剧情离冢血枫
		/// </summary>
		public const short OutBossXueFengNoFlee = 133;

		/// <summary>
		/// 剧情离冢术方
		/// </summary>
		public const short OutBossShuFangNoFlee = 134;

		/// <summary>
		/// 无敌相枢
		/// </summary>
		public const short BossXiangShuNoFlee = 135;

		/// <summary>
		/// 接招一招
		/// </summary>
		public const short TestCombat1Count = 136;

		/// <summary>
		/// 接招二招
		/// </summary>
		public const short TestCombat2Count = 137;

		/// <summary>
		/// 接招三招
		/// </summary>
		public const short TestCombat3Count = 138;

		/// <summary>
		/// 接招四招
		/// </summary>
		public const short TestCombat4Count = 139;

		/// <summary>
		/// 接招五招
		/// </summary>
		public const short TestCombat5Count = 140;

		/// <summary>
		/// 接招六招
		/// </summary>
		public const short TestCombat6Count = 141;

		/// <summary>
		/// 接招七招
		/// </summary>
		public const short TestCombat7Count = 142;

		/// <summary>
		/// 接招八招
		/// </summary>
		public const short TestCombat8Count = 143;

		/// <summary>
		/// 接招九招
		/// </summary>
		public const short TestCombat9Count = 144;

		/// <summary>
		/// 恶斗不绑不掉不逃
		/// </summary>
		public const short BeatNoRewardKidnapFlee = 145;

		/// <summary>
		/// 拳掌恶斗
		/// </summary>
		public const short BeatCombatFistAndPalm = 146;

		/// <summary>
		/// 指法恶斗
		/// </summary>
		public const short BeatCombatFinger = 147;

		/// <summary>
		/// 腿法恶斗
		/// </summary>
		public const short BeatCombatLeg = 148;

		/// <summary>
		/// 暗器恶斗
		/// </summary>
		public const short BeatCombatThrow = 149;

		/// <summary>
		/// 剑法恶斗
		/// </summary>
		public const short BeatCombatSword = 150;

		/// <summary>
		/// 刀法恶斗
		/// </summary>
		public const short BeatCombatBlade = 151;

		/// <summary>
		/// 长兵恶斗
		/// </summary>
		public const short BeatCombatPolearm = 152;

		/// <summary>
		/// 奇门恶斗
		/// </summary>
		public const short BeatCombatSpecial = 153;

		/// <summary>
		/// 软兵恶斗
		/// </summary>
		public const short BeatCombatWhip = 154;

		/// <summary>
		/// 御射恶斗
		/// </summary>
		public const short BeatCombatControllableShot = 155;

		/// <summary>
		/// 乐器恶斗
		/// </summary>
		public const short BeatCombatMusic = 156;

		/// <summary>
		/// 奇书奇遇身法恶斗
		/// </summary>
		public const short LegendaryBookAdventurePosingBeat = 157;

		/// <summary>
		/// 奇书奇遇身法死斗
		/// </summary>
		public const short LegendaryBookAdventurePosingDie = 158;

		/// <summary>
		/// 奇书奇遇绝技恶斗
		/// </summary>
		public const short LegendaryBookAdventureStuntBeat = 159;

		/// <summary>
		/// 奇书奇遇绝技死斗
		/// </summary>
		public const short LegendaryBookAdventureStuntDie = 160;

		/// <summary>
		/// 奇书解锁
		/// </summary>
		public const short LegendaryBookUnlock = 161;

		/// <summary>
		/// 奇书堕魔死斗
		/// </summary>
		public const short LegendaryBookConsumed = 162;

		/// <summary>
		/// 敌方伤害恢复恶斗
		/// </summary>
		public const short BeatEnemyHealDamage = 163;

		/// <summary>
		/// 廖无命试毒战斗0
		/// </summary>
		public const short LiaoWumingTryPoison0 = 164;

		/// <summary>
		/// 廖无命试毒战斗1
		/// </summary>
		public const short LiaoWumingTryPoison1 = 165;

		/// <summary>
		/// 廖无命试毒战斗2
		/// </summary>
		public const short LiaoWumingTryPoison2 = 166;

		/// <summary>
		/// 死斗不绑不掉不逃
		/// </summary>
		public const short DieNoRewardKidnapFlee = 167;

		/// <summary>
		/// 恶斗不绑敌方不逃
		/// </summary>
		public const short BeatNoKidnapEnemyNoFlee = 168;

		/// <summary>
		/// 死斗不绑不逃
		/// </summary>
		public const short DieNoKidnapFlee = 169;

		/// <summary>
		/// 恶斗不绑不逃
		/// </summary>
		public const short BeatNoKidnapFlee = 170;

		/// <summary>
		/// 少林地区主线
		/// </summary>
		public const short ShaoLinStory = 171;

		/// <summary>
		/// 同道切磋
		/// </summary>
		public const short PlayNormalInTeam = 172;

		/// <summary>
		/// 放生姬穸死斗
		/// </summary>
		public const short DieJixi = 173;

		/// <summary>
		/// 廖无命死斗
		/// </summary>
		public const short DieLiaoWuming = 174;

		/// <summary>
		/// 切磋不绑不掉不逃
		/// </summary>
		public const short PlayNoKidnapRewardFlee = 175;

		/// <summary>
		/// 石候酒白猿死斗
		/// </summary>
		public const short SectMainStoryEmeiDie = 176;

		/// <summary>
		/// 石候酒首次切磋
		/// </summary>
		public const short ShiHoujiuFirstCombat = 177;

		/// <summary>
		/// 恶斗不绑不逃有掉落
		/// </summary>
		public const short BeatNoKidnapEscapeWithReward = 178;

		/// <summary>
		/// 混功死斗易逃跑
		/// </summary>
		public const short DieMixedForEscape = 179;

		/// <summary>
		/// 死斗不绑不逃不处决
		/// </summary>
		public const short DieNoKidnapFleeExecution = 180;

		/// <summary>
		/// 死斗不绑不处决
		/// </summary>
		public const short DieNoKidnapExecution = 181;

		/// <summary>
		/// 白龙战斗
		/// </summary>
		public const short LoongWhite = 182;

		/// <summary>
		/// 黑龙战斗
		/// </summary>
		public const short LoongBlack = 183;

		/// <summary>
		/// 青龙战斗
		/// </summary>
		public const short LoongGreen = 184;

		/// <summary>
		/// 赤龙战斗
		/// </summary>
		public const short LoongRed = 185;

		/// <summary>
		/// 黄龙战斗
		/// </summary>
		public const short LoongYellow = 186;

		/// <summary>
		/// 小白龙战斗
		/// </summary>
		public const short MinionLoongWhite = 187;

		/// <summary>
		/// 小黑龙战斗
		/// </summary>
		public const short MinionLoongBlack = 188;

		/// <summary>
		/// 小青龙战斗
		/// </summary>
		public const short MinionLoongGreen = 189;

		/// <summary>
		/// 小赤龙战斗
		/// </summary>
		public const short MinionLoongRed = 190;

		/// <summary>
		/// 小黄龙战斗
		/// </summary>
		public const short MinionLoongYellow = 191;

		/// <summary>
		/// 杂物蛟战斗
		/// </summary>
		public const short JiaoCombatNoCarrierReceived = 192;

		/// <summary>
		/// 失心人战斗
		/// </summary>
		public const short InfectedCombat = 193;

		/// <summary>
		/// 烛仙死斗
		/// </summary>
		public const short DieZhuxian = 194;

		/// <summary>
		/// 然山华居线恶斗
		/// </summary>
		public const short BeatCombatHuaju = 195;

		/// <summary>
		/// 然山玄质线恶斗
		/// </summary>
		public const short BeatCombatXuanzhi = 196;

		/// <summary>
		/// 三宗比武路径战斗
		/// </summary>
		public const short BeatCombatRanshan = 197;

		/// <summary>
		/// 百花无名之人逃跑战斗
		/// </summary>
		public const short BaihuaAnonymEscape = 198;

		/// <summary>
		/// 恶斗不绑不逃敌人代称
		/// </summary>
		public const short BeatNoKidNapNoEscapeEnemyDisplayTitle = 199;

		/// <summary>
		/// 烛仙死斗无负面事件
		/// </summary>
		public const short DieZhuxian1 = 200;

		/// <summary>
		/// 三宗比武路径2负面
		/// </summary>
		public const short BeatCombatRanshanNeg = 201;

		/// <summary>
		/// 三宗比武路径3负面
		/// </summary>
		public const short BeatCombatRanshanNeg1 = 202;

		/// <summary>
		/// 百花无名之人不可击败战斗
		/// </summary>
		public const short BaihuaAnonymInvincible = 203;

		/// <summary>
		/// 百花无名之人最终战
		/// </summary>
		public const short BaihuaAnonymFinalBattle = 204;

		/// <summary>
		/// 伏龙第七十七最终战
		/// </summary>
		public const short FulongNoSeventySevenBattle = 205;

		/// <summary>
		/// 死斗不绑敌方不逃
		/// </summary>
		public const short DieNoKidnapNoEnemyFlee = 206;

		/// <summary>
		/// 死斗不绑不掉不处决
		/// </summary>
		public const short DieNoKidnapRewardExecution = 207;

		/// <summary>
		/// 铸剑正常战斗
		/// </summary>
		public const short BeatCombatZhujian = 208;

		/// <summary>
		/// 铸剑剑炉战斗
		/// </summary>
		public const short BeatCombatInsidefurnace = 209;

		/// <summary>
		/// 铸剑偃师死斗
		/// </summary>
		public const short DieYanshi = 210;

		/// <summary>
		/// 诛魔试炼通常战斗
		/// </summary>
		public const short DemonSlayerTrialDefault = 211;

		/// <summary>
		/// 机关人切磋
		/// </summary>
		public const short PlayWithGearMate = 223;

		/// <summary>
		/// 互动逃跑限时战斗
		/// </summary>
		public const short InteractionTimeLimit = 224;

		/// <summary>
		/// 元山不逃不绑死斗
		/// </summary>
		public const short SectMainStoryYuanshanDieNoFlee = 225;

		/// <summary>
		/// 元山恶斗不绑不掉不逃
		/// </summary>
		public const short SectMainStoryYuanshaBeatNoRewardKidnapFlee = 226;

		/// <summary>
		/// 公库死斗
		/// </summary>
		public const short FightDeepGuard = 227;

		/// <summary>
		/// 公库恶斗
		/// </summary>
		public const short FightGuard = 228;

		/// <summary>
		/// 五行石阵限时不逃切磋
		/// </summary>
		public const short TutorialNeilCombat = 241;

		/// <summary>
		/// 血犼地区剧情无敌红衣老人
		/// </summary>
		public const short SectStoryXuehouInvincibleManInRed = 229;

		/// <summary>
		/// 金刚狱石-BOSS
		/// </summary>
		public const short FiveElementsStoneMetal0 = 230;

		/// <summary>
		/// 紫霞狱石-BOSS
		/// </summary>
		public const short FiveElementsStoneWood0 = 231;

		/// <summary>
		/// 玄阴狱石-BOSS
		/// </summary>
		public const short FiveElementsStoneWater0 = 232;

		/// <summary>
		/// 纯阳狱石-BOSS
		/// </summary>
		public const short FiveElementsStoneFire0 = 233;

		/// <summary>
		/// 归元狱石-BOSS
		/// </summary>
		public const short FiveElementsStoneEarth0 = 234;

		/// <summary>
		/// 金刚狱石-普通
		/// </summary>
		public const short FiveElementsStoneMetal1 = 235;

		/// <summary>
		/// 紫霞狱石-普通
		/// </summary>
		public const short FiveElementsStoneWood1 = 236;

		/// <summary>
		/// 玄阴狱石-普通
		/// </summary>
		public const short FiveElementsStoneWater1 = 237;

		/// <summary>
		/// 纯阳狱石-普通
		/// </summary>
		public const short FiveElementsStoneFire1 = 238;

		/// <summary>
		/// 归元狱石-普通
		/// </summary>
		public const short FiveElementsStoneEarth1 = 239;

		/// <summary>
		/// 界青地区剧情玉蝉助战
		/// </summary>
		public const short SectStoryJieqingYuchanAssists = 243;

		/// <summary>
		/// 界青地区剧情入魔万恶
		/// </summary>
		public const short SectStoryJieqingMilevilion = 244;

		/// <summary>
		/// 首次武林盟会龙语茯恶斗
		/// </summary>
		public const short MainStoryMeetYufu = 245;

		/// <summary>
		/// 武林盟会通常观战
		/// </summary>
		public const short NpcWulinNormal = 246;

		/// <summary>
		/// 十二邪仙死斗
		/// </summary>
		public const short MainStoryImmortalsCombat = 250;

		/// <summary>
		/// 死斗不绑不掉不逃不处决
		/// </summary>
		public const short DieNoKidnapRewardFleeExecution = 253;

		/// <summary>
		/// 焚尘死斗不绑不逃不处决
		/// </summary>
		public const short FenChenCombat = 254;

		/// <summary>
		/// 妄相迷心
		/// </summary>
		public const short WanXiangMiXinCombat = 255;

		/// <summary>
		/// 邪影乱心
		/// </summary>
		public const short XieYinLuanXinCombat = 256;

		/// <summary>
		/// 凶魔扰心
		/// </summary>
		public const short XionMoRanXinCombat = 257;

		/// <summary>
		/// 石候酒首战恶斗
		/// </summary>
		public const short ShihoujiuBeatNormal = 258;

		/// <summary>
		/// 峨眉比武观战
		/// </summary>
		public const short EmeiBattleNormal = 259;

		/// <summary>
		/// 小和尚死斗不绑不逃不掉不处决
		/// </summary>
		public const short XiaoHeShangCombat = 260;

		/// <summary>
		/// 相枢爪牙通常恶斗
		/// </summary>
		public const short XiangshuMinionBeatNormal = 261;

		/// <summary>
		/// 相枢爪牙通常死斗
		/// </summary>
		public const short XiangshuMinionDieNormal = 262;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 通常切磋
		/// </summary>
		public static CombatConfigItem PlayNormal => Instance[(short)0];

		/// <summary>
		/// 通常恶斗
		/// </summary>
		public static CombatConfigItem BeatNormal => Instance[(short)1];

		/// <summary>
		/// 通常死斗
		/// </summary>
		public static CombatConfigItem DieNormal => Instance[(short)2];

		/// <summary>
		/// 通常接招
		/// </summary>
		public static CombatConfigItem TestNormal => Instance[(short)3];

		/// <summary>
		/// 通常观战
		/// </summary>
		public static CombatConfigItem NpcNormal => Instance[(short)242];

		/// <summary>
		/// 不逃切磋
		/// </summary>
		public static CombatConfigItem PlayNoFlee => Instance[(short)4];

		/// <summary>
		/// 不逃恶斗
		/// </summary>
		public static CombatConfigItem BeatNoFlee => Instance[(short)5];

		/// <summary>
		/// 不逃死斗
		/// </summary>
		public static CombatConfigItem DieNoFlee => Instance[(short)6];

		/// <summary>
		/// 近距恶斗
		/// </summary>
		public static CombatConfigItem BeatShort => Instance[(short)7];

		/// <summary>
		/// 中距恶斗
		/// </summary>
		public static CombatConfigItem BeatMiddle => Instance[(short)8];

		/// <summary>
		/// 长距恶斗
		/// </summary>
		public static CombatConfigItem BeatFar => Instance[(short)9];

		/// <summary>
		/// 近距死斗
		/// </summary>
		public static CombatConfigItem DieShort => Instance[(short)10];

		/// <summary>
		/// 中距死斗
		/// </summary>
		public static CombatConfigItem DieMiddle => Instance[(short)11];

		/// <summary>
		/// 长距死斗
		/// </summary>
		public static CombatConfigItem DieFar => Instance[(short)12];

		/// <summary>
		/// 金功死斗
		/// </summary>
		public static CombatConfigItem DieGold => Instance[(short)13];

		/// <summary>
		/// 木功死斗
		/// </summary>
		public static CombatConfigItem DieWood => Instance[(short)14];

		/// <summary>
		/// 水功死斗
		/// </summary>
		public static CombatConfigItem DieWater => Instance[(short)15];

		/// <summary>
		/// 火功死斗
		/// </summary>
		public static CombatConfigItem DieFire => Instance[(short)16];

		/// <summary>
		/// 土功死斗
		/// </summary>
		public static CombatConfigItem DieSoil => Instance[(short)17];

		/// <summary>
		/// 混功死斗
		/// </summary>
		public static CombatConfigItem DieMixed => Instance[(short)18];

		/// <summary>
		/// 金功不逃死斗
		/// </summary>
		public static CombatConfigItem DieGoldNoFlee => Instance[(short)19];

		/// <summary>
		/// 木功不逃死斗
		/// </summary>
		public static CombatConfigItem DieWoodNoFlee => Instance[(short)20];

		/// <summary>
		/// 水功不逃死斗
		/// </summary>
		public static CombatConfigItem DieWaterNoFlee => Instance[(short)21];

		/// <summary>
		/// 火功不逃死斗
		/// </summary>
		public static CombatConfigItem DieFireNoFlee => Instance[(short)22];

		/// <summary>
		/// 土功不逃死斗
		/// </summary>
		public static CombatConfigItem DieSoilNoFlee => Instance[(short)23];

		/// <summary>
		/// 混功不逃死斗
		/// </summary>
		public static CombatConfigItem DieMixedNoFlee => Instance[(short)24];

		/// <summary>
		/// 拳掌死斗
		/// </summary>
		public static CombatConfigItem DieFistAndPalm => Instance[(short)25];

		/// <summary>
		/// 指法死斗
		/// </summary>
		public static CombatConfigItem DieFinger => Instance[(short)26];

		/// <summary>
		/// 腿法死斗
		/// </summary>
		public static CombatConfigItem DieLeg => Instance[(short)27];

		/// <summary>
		/// 暗器死斗
		/// </summary>
		public static CombatConfigItem DieThrow => Instance[(short)28];

		/// <summary>
		/// 剑法死斗
		/// </summary>
		public static CombatConfigItem DieSword => Instance[(short)29];

		/// <summary>
		/// 刀法死斗
		/// </summary>
		public static CombatConfigItem DieBlade => Instance[(short)30];

		/// <summary>
		/// 长兵死斗
		/// </summary>
		public static CombatConfigItem DiePolearm => Instance[(short)31];

		/// <summary>
		/// 奇门死斗
		/// </summary>
		public static CombatConfigItem DieSpecial => Instance[(short)32];

		/// <summary>
		/// 软兵死斗
		/// </summary>
		public static CombatConfigItem DieWhip => Instance[(short)33];

		/// <summary>
		/// 御射死斗
		/// </summary>
		public static CombatConfigItem DieControllableShot => Instance[(short)34];

		/// <summary>
		/// 乐器死斗
		/// </summary>
		public static CombatConfigItem DieCombatMusic => Instance[(short)35];

		/// <summary>
		/// 冢中莫女
		/// </summary>
		public static CombatConfigItem BossMoNv => Instance[(short)36];

		/// <summary>
		/// 冢中大岳瑶常
		/// </summary>
		public static CombatConfigItem BossDaYueYaoChang => Instance[(short)37];

		/// <summary>
		/// 冢中九寒
		/// </summary>
		public static CombatConfigItem BossJiuHan => Instance[(short)38];

		/// <summary>
		/// 冢中金凰儿
		/// </summary>
		public static CombatConfigItem BossJinHuangEr => Instance[(short)39];

		/// <summary>
		/// 冢中衣以候
		/// </summary>
		public static CombatConfigItem BossYiYiHou => Instance[(short)40];

		/// <summary>
		/// 冢中卫起
		/// </summary>
		public static CombatConfigItem BossWeiQi => Instance[(short)41];

		/// <summary>
		/// 冢中以向
		/// </summary>
		public static CombatConfigItem BossYiXiang => Instance[(short)42];

		/// <summary>
		/// 冢中血枫
		/// </summary>
		public static CombatConfigItem BossXueFeng => Instance[(short)43];

		/// <summary>
		/// 冢中术方
		/// </summary>
		public static CombatConfigItem BossShuFang => Instance[(short)44];

		/// <summary>
		/// 离冢莫女
		/// </summary>
		public static CombatConfigItem OutBossMoNv => Instance[(short)45];

		/// <summary>
		/// 离冢大岳瑶常
		/// </summary>
		public static CombatConfigItem OutBossDaYueYaoChang => Instance[(short)46];

		/// <summary>
		/// 离冢九寒
		/// </summary>
		public static CombatConfigItem OutBossJiuHan => Instance[(short)47];

		/// <summary>
		/// 离冢金凰儿
		/// </summary>
		public static CombatConfigItem OutBossJinHuangEr => Instance[(short)48];

		/// <summary>
		/// 离冢衣以候
		/// </summary>
		public static CombatConfigItem OutBossYiYiHou => Instance[(short)49];

		/// <summary>
		/// 离冢卫起
		/// </summary>
		public static CombatConfigItem OutBossWeiQi => Instance[(short)50];

		/// <summary>
		/// 离冢以向
		/// </summary>
		public static CombatConfigItem OutBossYiXiang => Instance[(short)51];

		/// <summary>
		/// 离冢血枫
		/// </summary>
		public static CombatConfigItem OutBossXueFeng => Instance[(short)52];

		/// <summary>
		/// 离冢术方
		/// </summary>
		public static CombatConfigItem OutBossShuFang => Instance[(short)53];

		/// <summary>
		/// 玄石莫女
		/// </summary>
		public static CombatConfigItem RockBossMoNv => Instance[(short)54];

		/// <summary>
		/// 玄石大岳瑶常
		/// </summary>
		public static CombatConfigItem RockBossDaYueYaoChang => Instance[(short)55];

		/// <summary>
		/// 玄石九寒
		/// </summary>
		public static CombatConfigItem RockBossJiuHan => Instance[(short)56];

		/// <summary>
		/// 玄石金凰儿
		/// </summary>
		public static CombatConfigItem RockBossJinHuangEr => Instance[(short)57];

		/// <summary>
		/// 玄石衣以候
		/// </summary>
		public static CombatConfigItem RockBossYiYiHou => Instance[(short)58];

		/// <summary>
		/// 玄石卫起
		/// </summary>
		public static CombatConfigItem RockBossWeiQi => Instance[(short)59];

		/// <summary>
		/// 玄石以向
		/// </summary>
		public static CombatConfigItem RockBossYiXiang => Instance[(short)60];

		/// <summary>
		/// 玄石血枫
		/// </summary>
		public static CombatConfigItem RockBossXueFeng => Instance[(short)61];

		/// <summary>
		/// 玄石术方
		/// </summary>
		public static CombatConfigItem RockBossShuFang => Instance[(short)62];

		/// <summary>
		/// 紫竹莫女
		/// </summary>
		public static CombatConfigItem BambooBossMoNv => Instance[(short)63];

		/// <summary>
		/// 紫竹大岳瑶常
		/// </summary>
		public static CombatConfigItem BambooBossDaYueYaoChang => Instance[(short)64];

		/// <summary>
		/// 紫竹九寒
		/// </summary>
		public static CombatConfigItem BambooBossJiuHan => Instance[(short)65];

		/// <summary>
		/// 紫竹金凰儿
		/// </summary>
		public static CombatConfigItem BambooBossJinHuangEr => Instance[(short)66];

		/// <summary>
		/// 紫竹衣以候
		/// </summary>
		public static CombatConfigItem BambooBossYiYiHou => Instance[(short)67];

		/// <summary>
		/// 紫竹卫起
		/// </summary>
		public static CombatConfigItem BambooBossWeiQi => Instance[(short)68];

		/// <summary>
		/// 紫竹以向
		/// </summary>
		public static CombatConfigItem BambooBossYiXiang => Instance[(short)69];

		/// <summary>
		/// 紫竹血枫
		/// </summary>
		public static CombatConfigItem BambooBossXueFeng => Instance[(short)70];

		/// <summary>
		/// 紫竹术方
		/// </summary>
		public static CombatConfigItem BambooBossShuFang => Instance[(short)71];

		/// <summary>
		/// 相枢
		/// </summary>
		public static CombatConfigItem BossXiangShu => Instance[(short)72];

		/// <summary>
		/// 染尘子
		/// </summary>
		public static CombatConfigItem BossRanChenZi => Instance[(short)73];

		/// <summary>
		/// 焕心
		/// </summary>
		public static CombatConfigItem BossHuanXin => Instance[(short)74];

		/// <summary>
		/// 龙语茯
		/// </summary>
		public static CombatConfigItem BossLongYuFu => Instance[(short)75];

		/// <summary>
		/// 紫无绡
		/// </summary>
		public static CombatConfigItem BossZiWuXiao => Instance[(short)76];

		/// <summary>
		/// 恶斗无掉落
		/// </summary>
		public static CombatConfigItem BeatNoReward => Instance[(short)77];

		/// <summary>
		/// 死斗无掉落
		/// </summary>
		public static CombatConfigItem DieNoReward => Instance[(short)78];

		/// <summary>
		/// 拳掌切磋
		/// </summary>
		public static CombatConfigItem PlayCombatFistAndPalm => Instance[(short)79];

		/// <summary>
		/// 指法切磋
		/// </summary>
		public static CombatConfigItem PlayCombatFinger => Instance[(short)80];

		/// <summary>
		/// 腿法切磋
		/// </summary>
		public static CombatConfigItem PlayCombatLeg => Instance[(short)81];

		/// <summary>
		/// 暗器切磋
		/// </summary>
		public static CombatConfigItem PlayCombatThrow => Instance[(short)82];

		/// <summary>
		/// 剑法切磋
		/// </summary>
		public static CombatConfigItem PlayCombatSword => Instance[(short)83];

		/// <summary>
		/// 刀法切磋
		/// </summary>
		public static CombatConfigItem PlayCombatBlade => Instance[(short)84];

		/// <summary>
		/// 长兵切磋
		/// </summary>
		public static CombatConfigItem PlayCombatPolearm => Instance[(short)85];

		/// <summary>
		/// 奇门切磋
		/// </summary>
		public static CombatConfigItem PlayCombatSpecial => Instance[(short)86];

		/// <summary>
		/// 软兵切磋
		/// </summary>
		public static CombatConfigItem PlayCombatWhip => Instance[(short)87];

		/// <summary>
		/// 御射切磋
		/// </summary>
		public static CombatConfigItem PlayCombatControllableShot => Instance[(short)88];

		/// <summary>
		/// 乐器切磋
		/// </summary>
		public static CombatConfigItem PlayCombatMusic => Instance[(short)89];

		/// <summary>
		/// 武林大会少林
		/// </summary>
		public static CombatConfigItem WulinConferenceShaolin => Instance[(short)90];

		/// <summary>
		/// 武林大会峨眉
		/// </summary>
		public static CombatConfigItem WulinConferenceEmei => Instance[(short)91];

		/// <summary>
		/// 武林大会百花
		/// </summary>
		public static CombatConfigItem WulinConferenceBaihua => Instance[(short)92];

		/// <summary>
		/// 武林大会武当
		/// </summary>
		public static CombatConfigItem WulinConferenceWudang => Instance[(short)93];

		/// <summary>
		/// 武林大会元山
		/// </summary>
		public static CombatConfigItem WulinConferenceYuanshan => Instance[(short)94];

		/// <summary>
		/// 武林大会狮相
		/// </summary>
		public static CombatConfigItem WulinConferenceShixiang => Instance[(short)95];

		/// <summary>
		/// 武林大会然山
		/// </summary>
		public static CombatConfigItem WulinConferenceRanshan => Instance[(short)96];

		/// <summary>
		/// 武林大会璇女
		/// </summary>
		public static CombatConfigItem WulinConferenceXuannv => Instance[(short)97];

		/// <summary>
		/// 武林大会铸剑
		/// </summary>
		public static CombatConfigItem WulinConferenceZhujian => Instance[(short)98];

		/// <summary>
		/// 武林大会空桑
		/// </summary>
		public static CombatConfigItem WulinConferenceKongsang => Instance[(short)99];

		/// <summary>
		/// 武林大会金刚
		/// </summary>
		public static CombatConfigItem WulinConferenceJingang => Instance[(short)100];

		/// <summary>
		/// 武林大会五仙
		/// </summary>
		public static CombatConfigItem WulinConferenceWuxian => Instance[(short)101];

		/// <summary>
		/// 武林大会界青
		/// </summary>
		public static CombatConfigItem WulinConferenceJieqing => Instance[(short)102];

		/// <summary>
		/// 武林大会伏龙
		/// </summary>
		public static CombatConfigItem WulinConferenceFulong => Instance[(short)103];

		/// <summary>
		/// 武林大会血犼
		/// </summary>
		public static CombatConfigItem WulinConferenceXuehou => Instance[(short)104];

		/// <summary>
		/// 切磋少林
		/// </summary>
		public static CombatConfigItem PlayCombatShaolin => Instance[(short)105];

		/// <summary>
		/// 切磋峨眉
		/// </summary>
		public static CombatConfigItem PlayCombatEmei => Instance[(short)106];

		/// <summary>
		/// 切磋百花
		/// </summary>
		public static CombatConfigItem PlayCombatBaihua => Instance[(short)107];

		/// <summary>
		/// 切磋武当
		/// </summary>
		public static CombatConfigItem PlayCombatWudang => Instance[(short)108];

		/// <summary>
		/// 切磋元山
		/// </summary>
		public static CombatConfigItem PlayCombatYuanshan => Instance[(short)109];

		/// <summary>
		/// 切磋狮相
		/// </summary>
		public static CombatConfigItem PlayCombatShixiang => Instance[(short)110];

		/// <summary>
		/// 切磋然山
		/// </summary>
		public static CombatConfigItem PlayCombatRanshan => Instance[(short)111];

		/// <summary>
		/// 切磋璇女
		/// </summary>
		public static CombatConfigItem PlayCombatXuannv => Instance[(short)112];

		/// <summary>
		/// 切磋铸剑
		/// </summary>
		public static CombatConfigItem PlayCombatZhujian => Instance[(short)113];

		/// <summary>
		/// 切磋空桑
		/// </summary>
		public static CombatConfigItem PlayCombatKongsang => Instance[(short)114];

		/// <summary>
		/// 切磋金刚
		/// </summary>
		public static CombatConfigItem PlayCombatJingang => Instance[(short)115];

		/// <summary>
		/// 切磋五仙
		/// </summary>
		public static CombatConfigItem PlayCombatWuxian => Instance[(short)116];

		/// <summary>
		/// 切磋界青
		/// </summary>
		public static CombatConfigItem PlayCombatJieqing => Instance[(short)117];

		/// <summary>
		/// 切磋伏龙
		/// </summary>
		public static CombatConfigItem PlayCombatFulong => Instance[(short)118];

		/// <summary>
		/// 切磋血犼
		/// </summary>
		public static CombatConfigItem PlayCombatXuehou => Instance[(short)119];

		/// <summary>
		/// 切磋不绑
		/// </summary>
		public static CombatConfigItem PlayNoKidnap => Instance[(short)120];

		/// <summary>
		/// 恶斗不绑
		/// </summary>
		public static CombatConfigItem BeatNoKidnap => Instance[(short)121];

		/// <summary>
		/// 死斗不绑
		/// </summary>
		public static CombatConfigItem DieNoKidnap => Instance[(short)122];

		/// <summary>
		/// 恶斗不绑不掉
		/// </summary>
		public static CombatConfigItem BeatNone => Instance[(short)123];

		/// <summary>
		/// 死斗不绑不掉
		/// </summary>
		public static CombatConfigItem DieNone => Instance[(short)124];

		/// <summary>
		/// 演武第3章
		/// </summary>
		public static CombatConfigItem Tutorial3 => Instance[(short)249];

		/// <summary>
		/// 演武第4章
		/// </summary>
		public static CombatConfigItem Tutorial4 => Instance[(short)125];

		/// <summary>
		/// 剧情离冢莫女
		/// </summary>
		public static CombatConfigItem OutBossMoNvNoFlee => Instance[(short)126];

		/// <summary>
		/// 剧情离冢大岳瑶常
		/// </summary>
		public static CombatConfigItem OutBossDaYueYaoChangNoFlee => Instance[(short)127];

		/// <summary>
		/// 剧情离冢九寒
		/// </summary>
		public static CombatConfigItem OutBossJiuHanNoFlee => Instance[(short)128];

		/// <summary>
		/// 剧情离冢金凰儿
		/// </summary>
		public static CombatConfigItem OutBossJinHuangErNoFlee => Instance[(short)129];

		/// <summary>
		/// 剧情离冢衣以候
		/// </summary>
		public static CombatConfigItem OutBossYiYiHouNoFlee => Instance[(short)130];

		/// <summary>
		/// 剧情离冢卫起
		/// </summary>
		public static CombatConfigItem OutBossWeiQiNoFlee => Instance[(short)131];

		/// <summary>
		/// 剧情离冢以向
		/// </summary>
		public static CombatConfigItem OutBossYiXiangNoFlee => Instance[(short)132];

		/// <summary>
		/// 剧情离冢血枫
		/// </summary>
		public static CombatConfigItem OutBossXueFengNoFlee => Instance[(short)133];

		/// <summary>
		/// 剧情离冢术方
		/// </summary>
		public static CombatConfigItem OutBossShuFangNoFlee => Instance[(short)134];

		/// <summary>
		/// 无敌相枢
		/// </summary>
		public static CombatConfigItem BossXiangShuNoFlee => Instance[(short)135];

		/// <summary>
		/// 接招一招
		/// </summary>
		public static CombatConfigItem TestCombat1Count => Instance[(short)136];

		/// <summary>
		/// 接招二招
		/// </summary>
		public static CombatConfigItem TestCombat2Count => Instance[(short)137];

		/// <summary>
		/// 接招三招
		/// </summary>
		public static CombatConfigItem TestCombat3Count => Instance[(short)138];

		/// <summary>
		/// 接招四招
		/// </summary>
		public static CombatConfigItem TestCombat4Count => Instance[(short)139];

		/// <summary>
		/// 接招五招
		/// </summary>
		public static CombatConfigItem TestCombat5Count => Instance[(short)140];

		/// <summary>
		/// 接招六招
		/// </summary>
		public static CombatConfigItem TestCombat6Count => Instance[(short)141];

		/// <summary>
		/// 接招七招
		/// </summary>
		public static CombatConfigItem TestCombat7Count => Instance[(short)142];

		/// <summary>
		/// 接招八招
		/// </summary>
		public static CombatConfigItem TestCombat8Count => Instance[(short)143];

		/// <summary>
		/// 接招九招
		/// </summary>
		public static CombatConfigItem TestCombat9Count => Instance[(short)144];

		/// <summary>
		/// 恶斗不绑不掉不逃
		/// </summary>
		public static CombatConfigItem BeatNoRewardKidnapFlee => Instance[(short)145];

		/// <summary>
		/// 拳掌恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatFistAndPalm => Instance[(short)146];

		/// <summary>
		/// 指法恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatFinger => Instance[(short)147];

		/// <summary>
		/// 腿法恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatLeg => Instance[(short)148];

		/// <summary>
		/// 暗器恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatThrow => Instance[(short)149];

		/// <summary>
		/// 剑法恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatSword => Instance[(short)150];

		/// <summary>
		/// 刀法恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatBlade => Instance[(short)151];

		/// <summary>
		/// 长兵恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatPolearm => Instance[(short)152];

		/// <summary>
		/// 奇门恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatSpecial => Instance[(short)153];

		/// <summary>
		/// 软兵恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatWhip => Instance[(short)154];

		/// <summary>
		/// 御射恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatControllableShot => Instance[(short)155];

		/// <summary>
		/// 乐器恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatMusic => Instance[(short)156];

		/// <summary>
		/// 奇书奇遇身法恶斗
		/// </summary>
		public static CombatConfigItem LegendaryBookAdventurePosingBeat => Instance[(short)157];

		/// <summary>
		/// 奇书奇遇身法死斗
		/// </summary>
		public static CombatConfigItem LegendaryBookAdventurePosingDie => Instance[(short)158];

		/// <summary>
		/// 奇书奇遇绝技恶斗
		/// </summary>
		public static CombatConfigItem LegendaryBookAdventureStuntBeat => Instance[(short)159];

		/// <summary>
		/// 奇书奇遇绝技死斗
		/// </summary>
		public static CombatConfigItem LegendaryBookAdventureStuntDie => Instance[(short)160];

		/// <summary>
		/// 奇书解锁
		/// </summary>
		public static CombatConfigItem LegendaryBookUnlock => Instance[(short)161];

		/// <summary>
		/// 奇书堕魔死斗
		/// </summary>
		public static CombatConfigItem LegendaryBookConsumed => Instance[(short)162];

		/// <summary>
		/// 敌方伤害恢复恶斗
		/// </summary>
		public static CombatConfigItem BeatEnemyHealDamage => Instance[(short)163];

		/// <summary>
		/// 廖无命试毒战斗0
		/// </summary>
		public static CombatConfigItem LiaoWumingTryPoison0 => Instance[(short)164];

		/// <summary>
		/// 廖无命试毒战斗1
		/// </summary>
		public static CombatConfigItem LiaoWumingTryPoison1 => Instance[(short)165];

		/// <summary>
		/// 廖无命试毒战斗2
		/// </summary>
		public static CombatConfigItem LiaoWumingTryPoison2 => Instance[(short)166];

		/// <summary>
		/// 死斗不绑不掉不逃
		/// </summary>
		public static CombatConfigItem DieNoRewardKidnapFlee => Instance[(short)167];

		/// <summary>
		/// 恶斗不绑敌方不逃
		/// </summary>
		public static CombatConfigItem BeatNoKidnapEnemyNoFlee => Instance[(short)168];

		/// <summary>
		/// 死斗不绑不逃
		/// </summary>
		public static CombatConfigItem DieNoKidnapFlee => Instance[(short)169];

		/// <summary>
		/// 恶斗不绑不逃
		/// </summary>
		public static CombatConfigItem BeatNoKidnapFlee => Instance[(short)170];

		/// <summary>
		/// 少林地区主线
		/// </summary>
		public static CombatConfigItem ShaoLinStory => Instance[(short)171];

		/// <summary>
		/// 同道切磋
		/// </summary>
		public static CombatConfigItem PlayNormalInTeam => Instance[(short)172];

		/// <summary>
		/// 放生姬穸死斗
		/// </summary>
		public static CombatConfigItem DieJixi => Instance[(short)173];

		/// <summary>
		/// 廖无命死斗
		/// </summary>
		public static CombatConfigItem DieLiaoWuming => Instance[(short)174];

		/// <summary>
		/// 切磋不绑不掉不逃
		/// </summary>
		public static CombatConfigItem PlayNoKidnapRewardFlee => Instance[(short)175];

		/// <summary>
		/// 石候酒白猿死斗
		/// </summary>
		public static CombatConfigItem SectMainStoryEmeiDie => Instance[(short)176];

		/// <summary>
		/// 石候酒首次切磋
		/// </summary>
		public static CombatConfigItem ShiHoujiuFirstCombat => Instance[(short)177];

		/// <summary>
		/// 恶斗不绑不逃有掉落
		/// </summary>
		public static CombatConfigItem BeatNoKidnapEscapeWithReward => Instance[(short)178];

		/// <summary>
		/// 混功死斗易逃跑
		/// </summary>
		public static CombatConfigItem DieMixedForEscape => Instance[(short)179];

		/// <summary>
		/// 死斗不绑不逃不处决
		/// </summary>
		public static CombatConfigItem DieNoKidnapFleeExecution => Instance[(short)180];

		/// <summary>
		/// 死斗不绑不处决
		/// </summary>
		public static CombatConfigItem DieNoKidnapExecution => Instance[(short)181];

		/// <summary>
		/// 白龙战斗
		/// </summary>
		public static CombatConfigItem LoongWhite => Instance[(short)182];

		/// <summary>
		/// 黑龙战斗
		/// </summary>
		public static CombatConfigItem LoongBlack => Instance[(short)183];

		/// <summary>
		/// 青龙战斗
		/// </summary>
		public static CombatConfigItem LoongGreen => Instance[(short)184];

		/// <summary>
		/// 赤龙战斗
		/// </summary>
		public static CombatConfigItem LoongRed => Instance[(short)185];

		/// <summary>
		/// 黄龙战斗
		/// </summary>
		public static CombatConfigItem LoongYellow => Instance[(short)186];

		/// <summary>
		/// 小白龙战斗
		/// </summary>
		public static CombatConfigItem MinionLoongWhite => Instance[(short)187];

		/// <summary>
		/// 小黑龙战斗
		/// </summary>
		public static CombatConfigItem MinionLoongBlack => Instance[(short)188];

		/// <summary>
		/// 小青龙战斗
		/// </summary>
		public static CombatConfigItem MinionLoongGreen => Instance[(short)189];

		/// <summary>
		/// 小赤龙战斗
		/// </summary>
		public static CombatConfigItem MinionLoongRed => Instance[(short)190];

		/// <summary>
		/// 小黄龙战斗
		/// </summary>
		public static CombatConfigItem MinionLoongYellow => Instance[(short)191];

		/// <summary>
		/// 杂物蛟战斗
		/// </summary>
		public static CombatConfigItem JiaoCombatNoCarrierReceived => Instance[(short)192];

		/// <summary>
		/// 失心人战斗
		/// </summary>
		public static CombatConfigItem InfectedCombat => Instance[(short)193];

		/// <summary>
		/// 烛仙死斗
		/// </summary>
		public static CombatConfigItem DieZhuxian => Instance[(short)194];

		/// <summary>
		/// 然山华居线恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatHuaju => Instance[(short)195];

		/// <summary>
		/// 然山玄质线恶斗
		/// </summary>
		public static CombatConfigItem BeatCombatXuanzhi => Instance[(short)196];

		/// <summary>
		/// 三宗比武路径战斗
		/// </summary>
		public static CombatConfigItem BeatCombatRanshan => Instance[(short)197];

		/// <summary>
		/// 百花无名之人逃跑战斗
		/// </summary>
		public static CombatConfigItem BaihuaAnonymEscape => Instance[(short)198];

		/// <summary>
		/// 恶斗不绑不逃敌人代称
		/// </summary>
		public static CombatConfigItem BeatNoKidNapNoEscapeEnemyDisplayTitle => Instance[(short)199];

		/// <summary>
		/// 烛仙死斗无负面事件
		/// </summary>
		public static CombatConfigItem DieZhuxian1 => Instance[(short)200];

		/// <summary>
		/// 三宗比武路径2负面
		/// </summary>
		public static CombatConfigItem BeatCombatRanshanNeg => Instance[(short)201];

		/// <summary>
		/// 三宗比武路径3负面
		/// </summary>
		public static CombatConfigItem BeatCombatRanshanNeg1 => Instance[(short)202];

		/// <summary>
		/// 百花无名之人不可击败战斗
		/// </summary>
		public static CombatConfigItem BaihuaAnonymInvincible => Instance[(short)203];

		/// <summary>
		/// 百花无名之人最终战
		/// </summary>
		public static CombatConfigItem BaihuaAnonymFinalBattle => Instance[(short)204];

		/// <summary>
		/// 伏龙第七十七最终战
		/// </summary>
		public static CombatConfigItem FulongNoSeventySevenBattle => Instance[(short)205];

		/// <summary>
		/// 死斗不绑敌方不逃
		/// </summary>
		public static CombatConfigItem DieNoKidnapNoEnemyFlee => Instance[(short)206];

		/// <summary>
		/// 死斗不绑不掉不处决
		/// </summary>
		public static CombatConfigItem DieNoKidnapRewardExecution => Instance[(short)207];

		/// <summary>
		/// 铸剑正常战斗
		/// </summary>
		public static CombatConfigItem BeatCombatZhujian => Instance[(short)208];

		/// <summary>
		/// 铸剑剑炉战斗
		/// </summary>
		public static CombatConfigItem BeatCombatInsidefurnace => Instance[(short)209];

		/// <summary>
		/// 铸剑偃师死斗
		/// </summary>
		public static CombatConfigItem DieYanshi => Instance[(short)210];

		/// <summary>
		/// 诛魔试炼通常战斗
		/// </summary>
		public static CombatConfigItem DemonSlayerTrialDefault => Instance[(short)211];

		/// <summary>
		/// 机关人切磋
		/// </summary>
		public static CombatConfigItem PlayWithGearMate => Instance[(short)223];

		/// <summary>
		/// 互动逃跑限时战斗
		/// </summary>
		public static CombatConfigItem InteractionTimeLimit => Instance[(short)224];

		/// <summary>
		/// 元山不逃不绑死斗
		/// </summary>
		public static CombatConfigItem SectMainStoryYuanshanDieNoFlee => Instance[(short)225];

		/// <summary>
		/// 元山恶斗不绑不掉不逃
		/// </summary>
		public static CombatConfigItem SectMainStoryYuanshaBeatNoRewardKidnapFlee => Instance[(short)226];

		/// <summary>
		/// 公库死斗
		/// </summary>
		public static CombatConfigItem FightDeepGuard => Instance[(short)227];

		/// <summary>
		/// 公库恶斗
		/// </summary>
		public static CombatConfigItem FightGuard => Instance[(short)228];

		/// <summary>
		/// 五行石阵限时不逃切磋
		/// </summary>
		public static CombatConfigItem TutorialNeilCombat => Instance[(short)241];

		/// <summary>
		/// 血犼地区剧情无敌红衣老人
		/// </summary>
		public static CombatConfigItem SectStoryXuehouInvincibleManInRed => Instance[(short)229];

		/// <summary>
		/// 金刚狱石-BOSS
		/// </summary>
		public static CombatConfigItem FiveElementsStoneMetal0 => Instance[(short)230];

		/// <summary>
		/// 紫霞狱石-BOSS
		/// </summary>
		public static CombatConfigItem FiveElementsStoneWood0 => Instance[(short)231];

		/// <summary>
		/// 玄阴狱石-BOSS
		/// </summary>
		public static CombatConfigItem FiveElementsStoneWater0 => Instance[(short)232];

		/// <summary>
		/// 纯阳狱石-BOSS
		/// </summary>
		public static CombatConfigItem FiveElementsStoneFire0 => Instance[(short)233];

		/// <summary>
		/// 归元狱石-BOSS
		/// </summary>
		public static CombatConfigItem FiveElementsStoneEarth0 => Instance[(short)234];

		/// <summary>
		/// 金刚狱石-普通
		/// </summary>
		public static CombatConfigItem FiveElementsStoneMetal1 => Instance[(short)235];

		/// <summary>
		/// 紫霞狱石-普通
		/// </summary>
		public static CombatConfigItem FiveElementsStoneWood1 => Instance[(short)236];

		/// <summary>
		/// 玄阴狱石-普通
		/// </summary>
		public static CombatConfigItem FiveElementsStoneWater1 => Instance[(short)237];

		/// <summary>
		/// 纯阳狱石-普通
		/// </summary>
		public static CombatConfigItem FiveElementsStoneFire1 => Instance[(short)238];

		/// <summary>
		/// 归元狱石-普通
		/// </summary>
		public static CombatConfigItem FiveElementsStoneEarth1 => Instance[(short)239];

		/// <summary>
		/// 界青地区剧情玉蝉助战
		/// </summary>
		public static CombatConfigItem SectStoryJieqingYuchanAssists => Instance[(short)243];

		/// <summary>
		/// 界青地区剧情入魔万恶
		/// </summary>
		public static CombatConfigItem SectStoryJieqingMilevilion => Instance[(short)244];

		/// <summary>
		/// 首次武林盟会龙语茯恶斗
		/// </summary>
		public static CombatConfigItem MainStoryMeetYufu => Instance[(short)245];

		/// <summary>
		/// 武林盟会通常观战
		/// </summary>
		public static CombatConfigItem NpcWulinNormal => Instance[(short)246];

		/// <summary>
		/// 十二邪仙死斗
		/// </summary>
		public static CombatConfigItem MainStoryImmortalsCombat => Instance[(short)250];

		/// <summary>
		/// 死斗不绑不掉不逃不处决
		/// </summary>
		public static CombatConfigItem DieNoKidnapRewardFleeExecution => Instance[(short)253];

		/// <summary>
		/// 焚尘死斗不绑不逃不处决
		/// </summary>
		public static CombatConfigItem FenChenCombat => Instance[(short)254];

		/// <summary>
		/// 妄相迷心
		/// </summary>
		public static CombatConfigItem WanXiangMiXinCombat => Instance[(short)255];

		/// <summary>
		/// 邪影乱心
		/// </summary>
		public static CombatConfigItem XieYinLuanXinCombat => Instance[(short)256];

		/// <summary>
		/// 凶魔扰心
		/// </summary>
		public static CombatConfigItem XionMoRanXinCombat => Instance[(short)257];

		/// <summary>
		/// 石候酒首战恶斗
		/// </summary>
		public static CombatConfigItem ShihoujiuBeatNormal => Instance[(short)258];

		/// <summary>
		/// 峨眉比武观战
		/// </summary>
		public static CombatConfigItem EmeiBattleNormal => Instance[(short)259];

		/// <summary>
		/// 小和尚死斗不绑不逃不掉不处决
		/// </summary>
		public static CombatConfigItem XiaoHeShangCombat => Instance[(short)260];

		/// <summary>
		/// 相枢爪牙通常恶斗
		/// </summary>
		public static CombatConfigItem XiangshuMinionBeatNormal => Instance[(short)261];

		/// <summary>
		/// 相枢爪牙通常死斗
		/// </summary>
		public static CombatConfigItem XiangshuMinionDieNormal => Instance[(short)262];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CombatConfig Instance = new CombatConfig();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "SpecialTeammateCommands", "SpecialTeammateCommandBubbleTexts", "CombatSkillType", "Sect", "CaptureRequireRope", "Scene", "EnemyAi", "TemplateId", "Bgm" };

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
		_dataArray.Add(new CombatConfigItem(0, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(1, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(2, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(3, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 5400u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(4, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(5, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(6, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(7, 1, isBossCombat: false, 20, 60, -1, 60, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(8, 1, isBossCombat: false, 50, 90, -1, 90, 70, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(9, 1, isBossCombat: false, 80, 120, -1, 120, 100, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(10, 2, isBossCombat: false, 20, 60, -1, 60, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(11, 2, isBossCombat: false, 50, 90, -1, 90, 70, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(12, 2, isBossCombat: false, 80, 120, -1, 120, 100, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(13, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 0 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(14, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 1 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(15, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 2 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(16, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 3 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(17, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 4 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(18, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 5 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(19, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 0 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(20, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 1 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(21, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 2 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(22, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 3 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(23, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 4 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(24, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 5 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(25, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 3 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(26, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 4 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(27, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 5 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(28, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 6 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(29, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 7 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(30, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 8 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(31, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 9 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(32, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 10 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(33, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 11 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(34, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 12 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(35, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 13 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(36, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_monv_monvyi" }, 31, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(37, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_dayueyaochang_zhanyaoji" }, 27, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(38, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jiuhan_hanshankongming" }, 25, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(39, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jinhuanger_fenghuangjian" }, 26, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(40, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yiyihou_yiwuyuhongyan" }, 28, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(41, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_weiqi_hualong" }, 24, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(42, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yixiang_rongchenyin" }, 23, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(43, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_xuefeng_aozhan" }, 29, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(44, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_shufang_jiucaixia" }, 30, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(45, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_monv_monvyi" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(46, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_dayueyaochang_zhanyaoji" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(47, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jiuhan_hanshankongming" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(48, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jinhuanger_fenghuangjian" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(49, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yiyihou_yiwuyuhongyan" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(50, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_weiqi_hualong" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(51, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yixiang_rongchenyin" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(52, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_xuefeng_aozhan" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(53, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_shufang_jiucaixia" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(54, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_monv_monvyi" }, 31, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(55, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_dayueyaochang_zhanyaoji" }, 27, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(56, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jiuhan_hanshankongming" }, 25, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(57, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jinhuanger_fenghuangjian" }, 26, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(58, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yiyihou_yiwuyuhongyan" }, 28, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(59, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_weiqi_hualong" }, 24, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CombatConfigItem(60, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yixiang_rongchenyin" }, 23, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(61, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_xuefeng_aozhan" }, 29, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(62, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_shufang_jiucaixia" }, 30, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(63, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_monv_monvyi" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(64, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_dayueyaochang_zhanyaoji" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(65, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jiuhan_hanshankongming" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(66, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jinhuanger_fenghuangjian" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(67, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yiyihou_yiwuyuhongyan" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(68, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_weiqi_hualong" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(69, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yixiang_rongchenyin" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(70, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_xuefeng_aozhan" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(71, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_shufang_jiucaixia" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(72, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_xs" }, 39, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(73, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[3] { "combat_rcz_part_1", "combat_rcz_part_2", "combat_rcz_part_3" }, 40, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(74, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_hx" }, 34, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(75, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yufu" }, 32, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(76, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_zwx" }, 33, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(77, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(78, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(79, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 3 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(80, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 4 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(81, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 5 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(82, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 6 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(83, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 7 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(84, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 8 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(85, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 9 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(86, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 10 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(87, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 11 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(88, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 12 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(89, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 13 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(90, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(91, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 2, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(92, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 3, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(93, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 4, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(94, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 5, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(95, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 6, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(96, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 7, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(97, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 8, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(98, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 9, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(99, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 10, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(100, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 11, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(101, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 12, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(102, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 13, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(103, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 14, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(104, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 15, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(105, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(106, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 2, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(107, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 3, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(108, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 4, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(109, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 5, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(110, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 6, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(111, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 7, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(112, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 8, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(113, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 9, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(114, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 10, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(115, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 11, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(116, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 12, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(117, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 13, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(118, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 14, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(119, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 15, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new CombatConfigItem(120, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(121, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(122, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(123, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(124, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(125, 2, isBossCombat: true, 20, 120, 45, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(126, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_monv_monvyi" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(127, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_dayueyaochang_zhanyaoji" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(128, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_jiuhan_hanshankongming" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(129, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_jinhuanger_fenghuangjian" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(130, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_yiyihou_yiwuyuhongyan" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(131, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_weiqi_hualong" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(132, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_yixiang_rongchenyin" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(133, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_xuefeng_aozhan" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(134, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_shufang_jiucaixia" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(135, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_xs" }, 39, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(136, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 1800u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(137, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 2700u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(138, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 3600u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(139, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 4500u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(140, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 5400u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(141, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 6300u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(142, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 7200u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(143, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 8100u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(144, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 9000u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(145, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(146, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 3 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(147, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 4 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(148, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 5 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(149, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 6 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(150, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 7 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(151, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 8 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(152, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 9 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(153, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 10 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(154, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 11 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(155, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 12 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(156, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 13 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(157, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(158, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(159, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(160, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(161, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "legendbookbattle" }, 43, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(162, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "legendbookbattle" }, 43, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(163, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: true, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(164, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(165, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(166, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(167, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(168, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(169, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(170, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(171, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "story_shaolin" }, 44, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(172, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(173, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: true, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(174, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(175, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(176, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_emei" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(177, 0, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: true, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(178, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(179, 2, isBossCombat: false, 20, 120, 110, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 5 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new CombatConfigItem(180, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(181, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(182, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 200, lootAllInventory: false, 100, 275, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "loong_battle" }, 45, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(183, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 200, lootAllInventory: false, 100, 275, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "loong_battle" }, 46, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(184, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 200, lootAllInventory: false, 100, 275, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "loong_battle" }, 47, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(185, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 200, lootAllInventory: false, 100, 275, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "loong_battle" }, 48, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(186, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 200, lootAllInventory: false, 100, 275, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "loong_battle" }, 49, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(187, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: true, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 45, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(188, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: true, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 46, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(189, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: true, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 47, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(190, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: true, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 48, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(191, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: true, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 49, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(192, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(193, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(194, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>
		{
			new List<sbyte> { 34, 38, 32 },
			new List<sbyte> { 33, 31, 32 },
			new List<sbyte> { 36, 37, 35 }
		}, new string[3]
		{
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_194_0"),
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_194_1"),
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_194_2")
		}, new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_ranshan" }, 50, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(195, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>
		{
			new List<sbyte>(),
			new List<sbyte> { 34, 38, 32 },
			new List<sbyte>()
		}, new string[3]
		{
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_195_0"),
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_195_1"),
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_195_2")
		}, new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(196, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>
		{
			new List<sbyte>(),
			new List<sbyte>(),
			new List<sbyte> { 33, 31, 32 }
		}, new string[3]
		{
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_196_0"),
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_196_1"),
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_196_2")
		}, new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(197, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 50, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(198, 1, isBossCombat: true, 20, 120, 90, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: true, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, 1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(199, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: true, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(200, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_ranshan" }, 50, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(201, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>
		{
			new List<sbyte> { 31, 36, 38 },
			new List<sbyte>(),
			new List<sbyte>()
		}, new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 50, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(202, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>
		{
			new List<sbyte> { 33, 31, 32 },
			new List<sbyte>(),
			new List<sbyte>()
		}, new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(203, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 1800u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(204, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(205, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_fulongtan2" }, 51, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(206, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(207, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(208, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(209, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_zhujian" }, 52, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(210, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_zhujian" }, 52, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(211, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(212, 2, isBossCombat: false, 20, 90, 20, 90, 70, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(213, 2, isBossCombat: false, 50, 120, 120, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(214, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 28800u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(215, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 14400u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(216, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 7200u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(217, 2, isBossCombat: false, 20, 90, 20, 90, 70, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 28800u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(218, 2, isBossCombat: false, 20, 90, 20, 90, 70, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 14400u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(219, 2, isBossCombat: false, 20, 90, 20, 90, 70, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 7200u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(220, 2, isBossCombat: false, 50, 120, 120, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 28800u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(221, 2, isBossCombat: false, 50, 120, 120, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 14400u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(222, 2, isBossCombat: false, 50, 120, 120, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 7200u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(223, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, 25, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(224, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 7200u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(225, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_yuanshan" }, 53, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(226, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(227, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: true, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(228, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: true, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(229, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 1800u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(230, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(231, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(232, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(233, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(234, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(235, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(236, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(237, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(238, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(239, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new CombatConfigItem(240, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(241, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 2700u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(242, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.TiredMark, 10800u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(243, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(244, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(245, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(246, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.TiredMark, 10800u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(247, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(248, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(249, 2, isBossCombat: false, 20, 120, 70, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(250, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_twelve_immortals" }, 43, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(251, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_xs" }, 39, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(252, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "mainstory_lastbattle_part_1" }, 57, -1, skipChangePhase: false, startInSecondPhase: false, 0.6f));
		_dataArray.Add(new CombatConfigItem(253, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(254, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_zwx" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(255, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_03" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(256, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_04" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(257, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_05" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(258, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: true, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(259, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.TiredMark, 10800u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(260, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_05" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(261, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(262, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CombatConfigItem>(263);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
	}
}
