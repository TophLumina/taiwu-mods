using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AchievementInfo : ConfigData<AchievementInfoItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 真正的山猪
		/// </summary>
		public const short RealPig = 0;

		/// <summary>
		/// 初出茅庐
		/// </summary>
		public const short ChuChuMaoLu = 1;

		/// <summary>
		/// 桃源一梦
		/// </summary>
		public const short TaoYuanYiMeng = 2;

		/// <summary>
		/// 太吾复归
		/// </summary>
		public const short TaiWuFuGui = 3;

		/// <summary>
		/// 再续香火
		/// </summary>
		public const short ZaiXuXiangHuo = 4;

		/// <summary>
		/// 重开驿路
		/// </summary>
		public const short ChongKaiYiLu = 5;

		/// <summary>
		/// 神女还剑
		/// </summary>
		public const short ShenNvHuanJian = 6;

		/// <summary>
		/// 镇狱伏邪
		/// </summary>
		public const short ZhenYuFuXie = 7;

		/// <summary>
		/// 奇寒灵气
		/// </summary>
		public const short QiHanLingQi = 8;

		/// <summary>
		/// 七文五彩
		/// </summary>
		public const short QiWenWuCai = 9;

		/// <summary>
		/// 倾国绝世
		/// </summary>
		public const short QingGuoJueShi = 10;

		/// <summary>
		/// 龙胎化命
		/// </summary>
		public const short LongTaiHuaMing = 11;

		/// <summary>
		/// 溶尘化玉
		/// </summary>
		public const short RongChenHuaYu = 12;

		/// <summary>
		/// 八肱八趾
		/// </summary>
		public const short BaGongBaZhi = 13;

		/// <summary>
		/// 方天敕令
		/// </summary>
		public const short FangTianChiLing = 14;

		/// <summary>
		/// 九剑归一
		/// </summary>
		public const short JiuJianGuiYi = 15;

		/// <summary>
		/// 仙客奇书
		/// </summary>
		public const short XianKeQiShu = 16;

		/// <summary>
		/// 武林盟会
		/// </summary>
		public const short WuLinMengHui = 17;

		/// <summary>
		/// 爪牙伏诛
		/// </summary>
		public const short ZhaoYaFuZhu = 18;

		/// <summary>
		/// 出神之地
		/// </summary>
		public const short ChuShenZhiDi = 19;

		/// <summary>
		/// 返梦魂回
		/// </summary>
		public const short FanMengHunHui = 20;

		/// <summary>
		/// 神火金身
		/// </summary>
		public const short ShenHuoJinShen = 21;

		/// <summary>
		/// 七元万道
		/// </summary>
		public const short QiYuanWanDao = 22;

		/// <summary>
		/// 玄相真魔
		/// </summary>
		public const short XuanXiangZhenMo = 23;

		/// <summary>
		/// 英雄猴杰
		/// </summary>
		public const short YingXiongHouJie = 24;

		/// <summary>
		/// 阿牛同行
		/// </summary>
		public const short ANiuTongXing = 25;

		/// <summary>
		/// 小猫同行
		/// </summary>
		public const short XiaoMaoTongXing = 26;

		/// <summary>
		/// 郭彦同行
		/// </summary>
		public const short GuoYanTongXing = 27;

		/// <summary>
		/// 还月同行
		/// </summary>
		public const short HuanYueTongXing = 28;

		/// <summary>
		/// 巨蛇就擒
		/// </summary>
		public const short JuSheJiuQin = 29;

		/// <summary>
		/// 无名剑冢
		/// </summary>
		public const short WuMingJianZhong = 30;

		/// <summary>
		/// 太吾村覆灭
		/// </summary>
		public const short TaiWuCunFuMie = 31;

		/// <summary>
		/// 退魔辟邪
		/// </summary>
		public const short TuiMoBiXie = 32;

		/// <summary>
		/// 还剑之愿
		/// </summary>
		public const short HuanJianZhiYuan = 33;

		/// <summary>
		/// 除魔之誓
		/// </summary>
		public const short ChuMoZhiShi = 34;

		/// <summary>
		/// 囿于俗见
		/// </summary>
		public const short YouYuSuJian = 35;

		/// <summary>
		/// 苦寻圣人
		/// </summary>
		public const short KuXunShengRen = 36;

		/// <summary>
		/// 焚心之悲
		/// </summary>
		public const short FenXinZhiBei = 37;

		/// <summary>
		/// 舍身求道
		/// </summary>
		public const short SheShenQiuDao = 38;

		/// <summary>
		/// 无瑕之念
		/// </summary>
		public const short WuXiaZhiNian = 39;

		/// <summary>
		/// 百战不折
		/// </summary>
		public const short BaiZhanBuZhe = 40;

		/// <summary>
		/// 恩义难全
		/// </summary>
		public const short EnYiNanQuan = 41;

		/// <summary>
		/// 禅武之道
		/// </summary>
		public const short ChanWuZhiDao = 42;

		/// <summary>
		/// 禅武之道·续
		/// </summary>
		public const short ChanWuZhiDaoXu = 43;

		/// <summary>
		/// 隐世白猿
		/// </summary>
		public const short YinShiBaiYuan = 44;

		/// <summary>
		/// 隐世白猿·续
		/// </summary>
		public const short YinShiBaiYuanXu = 45;

		/// <summary>
		/// 玄鸮白鹿
		/// </summary>
		public const short XuanXiaoBaiLu = 46;

		/// <summary>
		/// 玄鸮白鹿·续
		/// </summary>
		public const short XuanXiaoBaiLuXu = 47;

		/// <summary>
		/// 龟蛇蟠扶
		/// </summary>
		public const short GuiShePanFu = 48;

		/// <summary>
		/// 龟蛇蟠扶·续
		/// </summary>
		public const short GuiShePanFuXu = 49;

		/// <summary>
		/// 石牢三魔
		/// </summary>
		public const short ShiLaoSanMo = 50;

		/// <summary>
		/// 石牢三魔·续
		/// </summary>
		public const short ShiLaoSanMoXu = 51;

		/// <summary>
		/// 文武双全
		/// </summary>
		public const short WenWuShuangQuan = 52;

		/// <summary>
		/// 文武双全·续
		/// </summary>
		public const short WenWuShuangQuanXu = 53;

		/// <summary>
		/// 青琅仙阁
		/// </summary>
		public const short QingLangXianGe = 54;

		/// <summary>
		/// 青琅仙阁·续
		/// </summary>
		public const short QingLangXianGeXu = 55;

		/// <summary>
		/// 镜水倒颠
		/// </summary>
		public const short JingShuiDaoDian = 56;

		/// <summary>
		/// 镜水倒颠·续
		/// </summary>
		public const short JingShuiDaoDianXu = 57;

		/// <summary>
		/// 铜生试剑
		/// </summary>
		public const short TongShengShiJian = 58;

		/// <summary>
		/// 铜生试剑·续
		/// </summary>
		public const short TongShengShiJianXu = 59;

		/// <summary>
		/// 奇毒绝方
		/// </summary>
		public const short QiDuJueFang = 60;

		/// <summary>
		/// 奇毒绝方·续
		/// </summary>
		public const short QiDuJueFangXu = 61;

		/// <summary>
		/// 真经无字
		/// </summary>
		public const short ZhenJingWuZi = 62;

		/// <summary>
		/// 真经无字·续
		/// </summary>
		public const short ZhenJingWuZiXu = 63;

		/// <summary>
		/// 五圣心毒
		/// </summary>
		public const short WuShengXinDu = 64;

		/// <summary>
		/// 五圣心毒·续
		/// </summary>
		public const short WuShengXinDuXu = 65;

		/// <summary>
		/// 善恶无生
		/// </summary>
		public const short ShanEWuSheng = 66;

		/// <summary>
		/// 善恶无生·续
		/// </summary>
		public const short ShanEWuShengXu = 67;

		/// <summary>
		/// 伏龙化羽
		/// </summary>
		public const short FuLongHuaYu = 68;

		/// <summary>
		/// 伏龙化羽·续
		/// </summary>
		public const short FuLongHuaYuXu = 69;

		/// <summary>
		/// 血冢遗姝
		/// </summary>
		public const short XueZhongYiShu = 70;

		/// <summary>
		/// 血冢遗姝·续
		/// </summary>
		public const short XueZhongYiShuXu = 71;

		/// <summary>
		/// 绘卷新篇
		/// </summary>
		public const short HuiJuanXinPian = 72;

		/// <summary>
		/// 前尘往事
		/// </summary>
		public const short QianChenWangShi = 73;

		/// <summary>
		/// 剑中记忆
		/// </summary>
		public const short JianZhongJiYi = 74;

		/// <summary>
		/// 再续前缘
		/// </summary>
		public const short ZaiXuQianYuan = 75;

		/// <summary>
		/// 玄狱之劫
		/// </summary>
		public const short XuanYuZhiJie = 76;

		/// <summary>
		/// 任其自然
		/// </summary>
		public const short RenQiZiRan = 77;

		/// <summary>
		/// 福泽绵长
		/// </summary>
		public const short FuZeMianChang = 78;

		/// <summary>
		/// 一脉相承
		/// </summary>
		public const short YiMaiXiangCheng = 79;

		/// <summary>
		/// 后继有人
		/// </summary>
		public const short HouJiYouRen = 80;

		/// <summary>
		/// 薪火相传
		/// </summary>
		public const short XinHuoXiangChuan = 81;

		/// <summary>
		/// 一世通天
		/// </summary>
		public const short YiShiTongTian = 82;

		/// <summary>
		/// 十世相承
		/// </summary>
		public const short ShiShiXiangCheng = 83;

		/// <summary>
		/// 重操旧业
		/// </summary>
		public const short ChongCaoJiuYe = 84;

		/// <summary>
		/// 伏虞护命
		/// </summary>
		public const short FuYuHuMing = 85;

		/// <summary>
		/// 有相皆痴苦
		/// </summary>
		public const short YouXiangJieChiKu = 86;

		/// <summary>
		/// 无人脱网罗
		/// </summary>
		public const short WuRenTuoWangLuo = 87;

		/// <summary>
		/// 恶贯满盈
		/// </summary>
		public const short EGuanManYing = 88;

		/// <summary>
		/// 名扬四海
		/// </summary>
		public const short MingYangSiHai = 89;

		/// <summary>
		/// 顺心而行
		/// </summary>
		public const short ShunXinErXing = 90;

		/// <summary>
		/// 违心之举
		/// </summary>
		public const short WeiXinZhiJu = 91;

		/// <summary>
		/// 笑口常开
		/// </summary>
		public const short XiaoKouChangKai = 92;

		/// <summary>
		/// 肝肠寸断
		/// </summary>
		public const short GanChangCunDuan = 93;

		/// <summary>
		/// 长生久视
		/// </summary>
		public const short ChangShengJiuShi = 94;

		/// <summary>
		/// 志同道合
		/// </summary>
		public const short ZhiTongDaoHe = 95;

		/// <summary>
		/// 连理同心
		/// </summary>
		public const short LianLiTongXin = 96;

		/// <summary>
		/// 呱呱坠地
		/// </summary>
		public const short GuGuZhuiDi = 97;

		/// <summary>
		/// 多子多福
		/// </summary>
		public const short DuoZiDuoFu = 98;

		/// <summary>
		/// 异胎降世
		/// </summary>
		public const short YiTaiJiangShi = 99;

		/// <summary>
		/// 远走高飞
		/// </summary>
		public const short YuanGaoFeiZou = 100;

		/// <summary>
		/// 金兰之契
		/// </summary>
		public const short JinLanZhiQi = 101;

		/// <summary>
		/// 飘零半生
		/// </summary>
		public const short PiaoLingBanSheng = 102;

		/// <summary>
		/// 三生石上
		/// </summary>
		public const short SanShengShiShang = 103;

		/// <summary>
		/// 倒反纲常
		/// </summary>
		public const short DaoFanGangChang = 104;

		/// <summary>
		/// 众星捧月
		/// </summary>
		public const short ZhongXingPengYue = 105;

		/// <summary>
		/// 众矢之的
		/// </summary>
		public const short ZhongShiZhiDi = 106;

		/// <summary>
		/// 使命必达
		/// </summary>
		public const short ShiMingBiDa = 107;

		/// <summary>
		/// 寸草不生
		/// </summary>
		public const short CunCaoBuSheng = 108;

		/// <summary>
		/// 爱恨交织
		/// </summary>
		public const short AiHenJiaoZhi = 109;

		/// <summary>
		/// 江湖百晓生
		/// </summary>
		public const short JiangHuBaiXiaoSheng = 110;

		/// <summary>
		/// 点到为止
		/// </summary>
		public const short DianDaoWeiZhi = 111;

		/// <summary>
		/// 身经百战
		/// </summary>
		public const short ShenJingBaiZhan = 112;

		/// <summary>
		/// 应对自如
		/// </summary>
		public const short YingDuiZiRu = 113;

		/// <summary>
		/// 不死不休
		/// </summary>
		public const short BuSiBuXiu = 114;

		/// <summary>
		/// 良言美意
		/// </summary>
		public const short LiangYanMeiYi = 115;

		/// <summary>
		/// 恶语伤人
		/// </summary>
		public const short EYuShangRen = 116;

		/// <summary>
		/// 五花八门
		/// </summary>
		public const short WuHuaBaMen = 117;

		/// <summary>
		/// 走为上计
		/// </summary>
		public const short ZouWeiShangJi = 118;

		/// <summary>
		/// 甘拜下风
		/// </summary>
		public const short GanBaiXiaFeng = 119;

		/// <summary>
		/// 五花大绑
		/// </summary>
		public const short WuHuaDaBang = 120;

		/// <summary>
		/// 伏虞救厄
		/// </summary>
		public const short FuYuJiuE = 121;

		/// <summary>
		/// 除魔卫道
		/// </summary>
		public const short ChuMoWeiDao = 122;

		/// <summary>
		/// 再造之恩
		/// </summary>
		public const short ZaiZaoZhiEn = 123;

		/// <summary>
		/// 仗义行侠
		/// </summary>
		public const short ZhangYiXingXia = 124;

		/// <summary>
		/// 逆我者亡
		/// </summary>
		public const short NiWoZheWang = 125;

		/// <summary>
		/// 降龙伏虎
		/// </summary>
		public const short XiangLongFuHu = 126;

		/// <summary>
		/// 辗转腾挪
		/// </summary>
		public const short ZhanZhuanTengNuo = 127;

		/// <summary>
		/// 不动如山
		/// </summary>
		public const short BuDongRuShan = 128;

		/// <summary>
		/// 变化莫测
		/// </summary>
		public const short BianHuaMoCe = 129;

		/// <summary>
		/// 齐心协力
		/// </summary>
		public const short QiXinXieLi = 130;

		/// <summary>
		/// 祸起萧墙
		/// </summary>
		public const short HuoQiXiaoQiang = 131;

		/// <summary>
		/// 他强由他强
		/// </summary>
		public const short TaQiangYouTaQiang = 132;

		/// <summary>
		/// 排山倒海
		/// </summary>
		public const short PaiShanDaoHai = 133;

		/// <summary>
		/// 洞金裂石
		/// </summary>
		public const short DongJinLieShi = 134;

		/// <summary>
		/// 踢星踏月
		/// </summary>
		public const short TiXingTaYue = 135;

		/// <summary>
		/// 飞花摘叶
		/// </summary>
		public const short FeiHuaZhaiYe = 136;

		/// <summary>
		/// 剑气纵横
		/// </summary>
		public const short JianQiZongHeng = 137;

		/// <summary>
		/// 劈波斩浪
		/// </summary>
		public const short PiBoZhanLang = 138;

		/// <summary>
		/// 寸长寸强
		/// </summary>
		public const short CunChangCunQiang = 139;

		/// <summary>
		/// 奇门异术
		/// </summary>
		public const short QiMenYiShu = 140;

		/// <summary>
		/// 势若游龙
		/// </summary>
		public const short ShiRuoYouLong = 141;

		/// <summary>
		/// 百步穿杨
		/// </summary>
		public const short BaiBuChuanYang = 142;

		/// <summary>
		/// 魔音贯耳
		/// </summary>
		public const short MoYinGuanEr = 143;

		/// <summary>
		/// 势不可挡
		/// </summary>
		public const short ShiBuKeDang = 144;

		/// <summary>
		/// 蹩脚功夫
		/// </summary>
		public const short BieJiaoGongFu = 145;

		/// <summary>
		/// 分筋错骨
		/// </summary>
		public const short FenJinCuoGu = 146;

		/// <summary>
		/// 身残志坚
		/// </summary>
		public const short ShenCanZhiJian = 147;

		/// <summary>
		/// 毒气攻心
		/// </summary>
		public const short DuQiGongXin = 148;

		/// <summary>
		/// 七彩玲珑心
		/// </summary>
		public const short QiCaiLingLongXin = 149;

		/// <summary>
		/// 气冲斗牛
		/// </summary>
		public const short QiChongDouNiu = 150;

		/// <summary>
		/// 气散功消
		/// </summary>
		public const short QiSanGongXiao = 151;

		/// <summary>
		/// 穷追猛打
		/// </summary>
		public const short QiongZhuiMengDa = 152;

		/// <summary>
		/// 心有所向
		/// </summary>
		public const short XinYouSuoXiang = 153;

		/// <summary>
		/// 志有所成
		/// </summary>
		public const short ZhiYouSuoCheng = 154;

		/// <summary>
		/// 山中高士
		/// </summary>
		public const short ShanZhongGaoShi = 155;

		/// <summary>
		/// 百兽之王
		/// </summary>
		public const short BaiShouZhiWang = 156;

		/// <summary>
		/// 巧夺天工
		/// </summary>
		public const short QiaoDuoTianGong = 157;

		/// <summary>
		/// 一呼百应
		/// </summary>
		public const short YiHuBaiYing = 158;

		/// <summary>
		/// 才高八斗
		/// </summary>
		public const short CaiGaoBaDou = 159;

		/// <summary>
		/// 道法自然
		/// </summary>
		public const short DaoFaZiRan = 160;

		/// <summary>
		/// 功德圆满
		/// </summary>
		public const short GongDeYuanMan = 161;

		/// <summary>
		/// 酒中豪杰
		/// </summary>
		public const short JiuZhongHaoJie = 162;

		/// <summary>
		/// 钟鸣鼎食
		/// </summary>
		public const short ZhongMingDingShi = 163;

		/// <summary>
		/// 游戏人间
		/// </summary>
		public const short YouXiRenJian = 164;

		/// <summary>
		/// 布衣自适
		/// </summary>
		public const short BuYiZiShi = 165;

		/// <summary>
		/// 行遍天涯
		/// </summary>
		public const short XingBianTianYa = 166;

		/// <summary>
		/// 明心见性
		/// </summary>
		public const short MingXinJianXing = 167;

		/// <summary>
		/// 妙手回春
		/// </summary>
		public const short MiaoShouHuiChun = 168;

		/// <summary>
		/// 化外逍遥
		/// </summary>
		public const short HuaWaiXiaoYao = 169;

		/// <summary>
		/// 挥金如土
		/// </summary>
		public const short HuiJinRuTu = 170;

		/// <summary>
		/// 风流雅士
		/// </summary>
		public const short FengLiuYaShi = 171;

		/// <summary>
		/// 万民来朝
		/// </summary>
		public const short WanMinLaiChao = 172;

		/// <summary>
		/// 诸业精通
		/// </summary>
		public const short ZhuYeJingTong = 173;

		/// <summary>
		/// 初窥门径
		/// </summary>
		public const short ChuKuiMenJing = 174;

		/// <summary>
		/// 术业专攻
		/// </summary>
		public const short ShuYeZhuanGong = 175;

		/// <summary>
		/// 音律大成
		/// </summary>
		public const short YinLvDaCheng = 176;

		/// <summary>
		/// 弈棋大成
		/// </summary>
		public const short YiQiDaCheng = 177;

		/// <summary>
		/// 诗书大成
		/// </summary>
		public const short ShiShuDaCheng = 178;

		/// <summary>
		/// 绘画大成
		/// </summary>
		public const short HuiHuaDaCheng = 179;

		/// <summary>
		/// 术数大成
		/// </summary>
		public const short ShuShuDaCheng = 180;

		/// <summary>
		/// 品鉴大成
		/// </summary>
		public const short PinJianDaCheng = 181;

		/// <summary>
		/// 锻造大成
		/// </summary>
		public const short DuanZaoDaCheng = 182;

		/// <summary>
		/// 制木大成
		/// </summary>
		public const short ZhiMuDaCheng = 183;

		/// <summary>
		/// 医术大成
		/// </summary>
		public const short YiShuDaCheng = 184;

		/// <summary>
		/// 毒术大成
		/// </summary>
		public const short DuShuDaCheng = 185;

		/// <summary>
		/// 织锦大成
		/// </summary>
		public const short ZhiJinDaCheng = 186;

		/// <summary>
		/// 巧匠大成
		/// </summary>
		public const short QiaoJiangDaCheng = 187;

		/// <summary>
		/// 道法大成
		/// </summary>
		public const short DaoFaDaCheng = 188;

		/// <summary>
		/// 佛学大成
		/// </summary>
		public const short FoXueDaCheng = 189;

		/// <summary>
		/// 厨艺大成
		/// </summary>
		public const short ChuYiDaCheng = 190;

		/// <summary>
		/// 杂学大成
		/// </summary>
		public const short ZaXueDaCheng = 191;

		/// <summary>
		/// 学究天人
		/// </summary>
		public const short XueJiuTianRen = 192;

		/// <summary>
		/// 技高一筹
		/// </summary>
		public const short JiGaoYiChou = 193;

		/// <summary>
		/// 舌灿莲花
		/// </summary>
		public const short SheCanLianHua = 194;

		/// <summary>
		/// 初学乍练
		/// </summary>
		public const short ChuXueZhaLian = 195;

		/// <summary>
		/// 尽得真传
		/// </summary>
		public const short JinDeZhenChuan = 196;

		/// <summary>
		/// 少林绝学
		/// </summary>
		public const short ShaoLinJueXue = 197;

		/// <summary>
		/// 峨眉绝学
		/// </summary>
		public const short EMeiJueXue = 198;

		/// <summary>
		/// 百花绝学
		/// </summary>
		public const short BaiHuaJueXue = 199;

		/// <summary>
		/// 武当绝学
		/// </summary>
		public const short WuDangJueXue = 200;

		/// <summary>
		/// 元山绝学
		/// </summary>
		public const short YuanShanJueXue = 201;

		/// <summary>
		/// 狮相绝学
		/// </summary>
		public const short ShiXiangJueXue = 202;

		/// <summary>
		/// 然山绝学
		/// </summary>
		public const short RanShanJueXue = 203;

		/// <summary>
		/// 璇女绝学
		/// </summary>
		public const short XuanNvJueXue = 204;

		/// <summary>
		/// 铸剑绝学
		/// </summary>
		public const short ZhuJianJueXue = 205;

		/// <summary>
		/// 空桑绝学
		/// </summary>
		public const short KongSangJueXue = 206;

		/// <summary>
		/// 金刚绝学
		/// </summary>
		public const short JinGangJueXue = 207;

		/// <summary>
		/// 五仙绝学
		/// </summary>
		public const short WuXianJueXue = 208;

		/// <summary>
		/// 界青绝学
		/// </summary>
		public const short JieQingJueXue = 209;

		/// <summary>
		/// 伏龙绝学
		/// </summary>
		public const short FuLongJueXue = 210;

		/// <summary>
		/// 血犼绝学
		/// </summary>
		public const short XueHaoJueXue = 211;

		/// <summary>
		/// 功参造化
		/// </summary>
		public const short GongCanZaoHua = 212;

		/// <summary>
		/// 少林盟誓
		/// </summary>
		public const short ShaoLinMengShi = 213;

		/// <summary>
		/// 峨眉盟誓
		/// </summary>
		public const short EMeiMengShi = 214;

		/// <summary>
		/// 百花盟誓
		/// </summary>
		public const short BaiHuaMengShi = 215;

		/// <summary>
		/// 武当盟誓
		/// </summary>
		public const short WuDangMengShi = 216;

		/// <summary>
		/// 元山盟誓
		/// </summary>
		public const short YuanShanMengShi = 217;

		/// <summary>
		/// 狮相盟誓
		/// </summary>
		public const short ShiXiangMengShi = 218;

		/// <summary>
		/// 然山盟誓
		/// </summary>
		public const short RanShanMengShi = 219;

		/// <summary>
		/// 璇女盟誓
		/// </summary>
		public const short XuanNvMengShi = 220;

		/// <summary>
		/// 铸剑盟誓
		/// </summary>
		public const short ZhuJianMengShi = 221;

		/// <summary>
		/// 空桑盟誓
		/// </summary>
		public const short KongSangMengShi = 222;

		/// <summary>
		/// 金刚盟誓
		/// </summary>
		public const short JinGangMengShi = 223;

		/// <summary>
		/// 五仙盟誓
		/// </summary>
		public const short WuXianMengShi = 224;

		/// <summary>
		/// 界青盟誓
		/// </summary>
		public const short JieQingMengShi = 225;

		/// <summary>
		/// 伏龙盟誓
		/// </summary>
		public const short FuLongMengShi = 226;

		/// <summary>
		/// 血犼盟誓
		/// </summary>
		public const short XueHaoMengShi = 227;

		/// <summary>
		/// 无坚不摧
		/// </summary>
		public const short WuJianBuCui = 228;

		/// <summary>
		/// 奔逸绝尘
		/// </summary>
		public const short BenYiJueChen = 229;

		/// <summary>
		/// 固若金汤
		/// </summary>
		public const short GuRuoJinTang = 230;

		/// <summary>
		/// 奇经八脉
		/// </summary>
		public const short QiJingBaMai = 231;

		/// <summary>
		/// 冲破玄关
		/// </summary>
		public const short ChongPoXuanGuan = 232;

		/// <summary>
		/// 走火入魔
		/// </summary>
		public const short ZouHuoRuMo = 233;

		/// <summary>
		/// 熟能生巧
		/// </summary>
		public const short ShuNengShengQiao = 234;

		/// <summary>
		/// 浑心无字
		/// </summary>
		public const short HunXinWuZi = 235;

		/// <summary>
		/// 白衣行化
		/// </summary>
		public const short BaiYiXingHua = 236;

		/// <summary>
		/// 大全千法
		/// </summary>
		public const short DaQuanQianFa = 237;

		/// <summary>
		/// 象龙演画
		/// </summary>
		public const short XiangLongYanHua = 238;

		/// <summary>
		/// 心观残笺
		/// </summary>
		public const short XinGuanCanJian = 239;

		/// <summary>
		/// 八埏至宝
		/// </summary>
		public const short BaYanZhiBao = 240;

		/// <summary>
		/// 化影奇功
		/// </summary>
		public const short HuaYingQiGong = 241;

		/// <summary>
		/// 无名神剑
		/// </summary>
		public const short WuMingShenJian = 242;

		/// <summary>
		/// 十杀魔罗
		/// </summary>
		public const short ShiShaMoLuo = 243;

		/// <summary>
		/// 一画开天
		/// </summary>
		public const short YiHuaKaiTian = 244;

		/// <summary>
		/// 无先玄元
		/// </summary>
		public const short WuXianXuanYuan = 245;

		/// <summary>
		/// 九似真藏
		/// </summary>
		public const short JiuSiZhenCang = 246;

		/// <summary>
		/// 天通神术
		/// </summary>
		public const short TianTongShenShu = 247;

		/// <summary>
		/// 神女绝音
		/// </summary>
		public const short ShenNvJueYin = 248;

		/// <summary>
		/// 十四奇书
		/// </summary>
		public const short ShiSiQiShu = 249;

		/// <summary>
		/// 地力充盈
		/// </summary>
		public const short DiLiChongYing = 250;

		/// <summary>
		/// 物华天宝
		/// </summary>
		public const short WuHuaTianBao = 251;

		/// <summary>
		/// 人丁兴旺
		/// </summary>
		public const short RenDingXingWang = 252;

		/// <summary>
		/// 各司其职
		/// </summary>
		public const short GeSiQiZhi = 253;

		/// <summary>
		/// 仓廪丰实
		/// </summary>
		public const short CangLinFengShi = 254;

		/// <summary>
		/// 鸡鸣千里
		/// </summary>
		public const short JiMingQianLi = 255;

		/// <summary>
		/// 设席开宴
		/// </summary>
		public const short SheXiKaiYan = 256;

		/// <summary>
		/// 宴请八方
		/// </summary>
		public const short YanQingBaFang = 257;

		/// <summary>
		/// 轮回往生
		/// </summary>
		public const short LunHuiWangSheng = 258;

		/// <summary>
		/// 六道轮回
		/// </summary>
		public const short LiuDaoLunHui = 259;

		/// <summary>
		/// 丝路复兴
		/// </summary>
		public const short SiLuFuXing = 260;

		/// <summary>
		/// 服牛帮上宾
		/// </summary>
		public const short FuNiuBangShangBin = 261;

		/// <summary>
		/// 书海阁上宾
		/// </summary>
		public const short ShuHaiGeShangBin = 262;

		/// <summary>
		/// 五湖上宾
		/// </summary>
		public const short WuHuShangBin = 263;

		/// <summary>
		/// 大武魁上宾
		/// </summary>
		public const short DaWuKuiShangBin = 264;

		/// <summary>
		/// 回春堂上宾
		/// </summary>
		public const short HuiChunTangShangBin = 265;

		/// <summary>
		/// 公输坊上宾
		/// </summary>
		public const short GongShuFangShangBin = 266;

		/// <summary>
		/// 奇货斋上宾
		/// </summary>
		public const short QiHuoZhaiShangBin = 267;

		/// <summary>
		/// 千锤百炼
		/// </summary>
		public const short QianChuiBaiLian = 268;

		/// <summary>
		/// 鬼斧神工
		/// </summary>
		public const short GuiFuShenGong = 269;

		/// <summary>
		/// 织霞成锦
		/// </summary>
		public const short ZhiXiaChengJin = 270;

		/// <summary>
		/// 连城之璧
		/// </summary>
		public const short LianChengZhiBi = 271;

		/// <summary>
		/// 炉火纯青
		/// </summary>
		public const short LuHuoChunQing = 272;

		/// <summary>
		/// 封喉断肠
		/// </summary>
		public const short FengHouDuanChang = 273;

		/// <summary>
		/// 烹龙炮凤
		/// </summary>
		public const short PengLongPaoFeng = 274;

		/// <summary>
		/// 驿路初通
		/// </summary>
		public const short YiLuChuTong = 275;

		/// <summary>
		/// 九州通衢
		/// </summary>
		public const short JiuZhouTongQu = 276;

		/// <summary>
		/// 恶丐窝
		/// </summary>
		public const short EGaiWo = 277;

		/// <summary>
		/// 贼人营寨
		/// </summary>
		public const short ZeiRenYingZhai = 278;

		/// <summary>
		/// 悍匪砦
		/// </summary>
		public const short HanFeiZhai = 279;

		/// <summary>
		/// 叛徒结伙
		/// </summary>
		public const short PanTuJieHuo = 280;

		/// <summary>
		/// 恶人谷
		/// </summary>
		public const short ERenGu = 281;

		/// <summary>
		/// 迷香阵
		/// </summary>
		public const short MiXiangZhen = 282;

		/// <summary>
		/// 乱葬岗
		/// </summary>
		public const short LuanZangGang = 283;

		/// <summary>
		/// 异士居
		/// </summary>
		public const short YiShiJu = 284;

		/// <summary>
		/// 邪人死地
		/// </summary>
		public const short XieRenSiDi = 285;

		/// <summary>
		/// 修罗场
		/// </summary>
		public const short XiuLuoChang = 286;

		/// <summary>
		/// 群魔乱舞
		/// </summary>
		public const short QunMoLuanWu = 287;

		/// <summary>
		/// 弃世绝境
		/// </summary>
		public const short QiShiJueJing = 288;

		/// <summary>
		/// 义士堂
		/// </summary>
		public const short YiShiTang = 289;

		/// <summary>
		/// 任侠会盟
		/// </summary>
		public const short RenXiaHuiMeng = 290;

		/// <summary>
		/// 世外秘境
		/// </summary>
		public const short ShiWaiMiJing = 291;

		/// <summary>
		/// 秋虫高鸣
		/// </summary>
		public const short QiuChongGaoMing = 292;

		/// <summary>
		/// 聊以饲鸡
		/// </summary>
		public const short LiaoYiSiJi = 293;

		/// <summary>
		/// 一鸣惊人
		/// </summary>
		public const short YiMingJingRen = 294;

		/// <summary>
		/// 虫王全谱
		/// </summary>
		public const short ChongWangQuanPu = 295;

		/// <summary>
		/// 斗虫之道
		/// </summary>
		public const short DouChongZhiDao = 296;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 真正的山猪
		/// </summary>
		public static AchievementInfoItem RealPig => Instance[(short)0];

		/// <summary>
		/// 初出茅庐
		/// </summary>
		public static AchievementInfoItem ChuChuMaoLu => Instance[(short)1];

		/// <summary>
		/// 桃源一梦
		/// </summary>
		public static AchievementInfoItem TaoYuanYiMeng => Instance[(short)2];

		/// <summary>
		/// 太吾复归
		/// </summary>
		public static AchievementInfoItem TaiWuFuGui => Instance[(short)3];

		/// <summary>
		/// 再续香火
		/// </summary>
		public static AchievementInfoItem ZaiXuXiangHuo => Instance[(short)4];

		/// <summary>
		/// 重开驿路
		/// </summary>
		public static AchievementInfoItem ChongKaiYiLu => Instance[(short)5];

		/// <summary>
		/// 神女还剑
		/// </summary>
		public static AchievementInfoItem ShenNvHuanJian => Instance[(short)6];

		/// <summary>
		/// 镇狱伏邪
		/// </summary>
		public static AchievementInfoItem ZhenYuFuXie => Instance[(short)7];

		/// <summary>
		/// 奇寒灵气
		/// </summary>
		public static AchievementInfoItem QiHanLingQi => Instance[(short)8];

		/// <summary>
		/// 七文五彩
		/// </summary>
		public static AchievementInfoItem QiWenWuCai => Instance[(short)9];

		/// <summary>
		/// 倾国绝世
		/// </summary>
		public static AchievementInfoItem QingGuoJueShi => Instance[(short)10];

		/// <summary>
		/// 龙胎化命
		/// </summary>
		public static AchievementInfoItem LongTaiHuaMing => Instance[(short)11];

		/// <summary>
		/// 溶尘化玉
		/// </summary>
		public static AchievementInfoItem RongChenHuaYu => Instance[(short)12];

		/// <summary>
		/// 八肱八趾
		/// </summary>
		public static AchievementInfoItem BaGongBaZhi => Instance[(short)13];

		/// <summary>
		/// 方天敕令
		/// </summary>
		public static AchievementInfoItem FangTianChiLing => Instance[(short)14];

		/// <summary>
		/// 九剑归一
		/// </summary>
		public static AchievementInfoItem JiuJianGuiYi => Instance[(short)15];

		/// <summary>
		/// 仙客奇书
		/// </summary>
		public static AchievementInfoItem XianKeQiShu => Instance[(short)16];

		/// <summary>
		/// 武林盟会
		/// </summary>
		public static AchievementInfoItem WuLinMengHui => Instance[(short)17];

		/// <summary>
		/// 爪牙伏诛
		/// </summary>
		public static AchievementInfoItem ZhaoYaFuZhu => Instance[(short)18];

		/// <summary>
		/// 出神之地
		/// </summary>
		public static AchievementInfoItem ChuShenZhiDi => Instance[(short)19];

		/// <summary>
		/// 返梦魂回
		/// </summary>
		public static AchievementInfoItem FanMengHunHui => Instance[(short)20];

		/// <summary>
		/// 神火金身
		/// </summary>
		public static AchievementInfoItem ShenHuoJinShen => Instance[(short)21];

		/// <summary>
		/// 七元万道
		/// </summary>
		public static AchievementInfoItem QiYuanWanDao => Instance[(short)22];

		/// <summary>
		/// 玄相真魔
		/// </summary>
		public static AchievementInfoItem XuanXiangZhenMo => Instance[(short)23];

		/// <summary>
		/// 英雄猴杰
		/// </summary>
		public static AchievementInfoItem YingXiongHouJie => Instance[(short)24];

		/// <summary>
		/// 阿牛同行
		/// </summary>
		public static AchievementInfoItem ANiuTongXing => Instance[(short)25];

		/// <summary>
		/// 小猫同行
		/// </summary>
		public static AchievementInfoItem XiaoMaoTongXing => Instance[(short)26];

		/// <summary>
		/// 郭彦同行
		/// </summary>
		public static AchievementInfoItem GuoYanTongXing => Instance[(short)27];

		/// <summary>
		/// 还月同行
		/// </summary>
		public static AchievementInfoItem HuanYueTongXing => Instance[(short)28];

		/// <summary>
		/// 巨蛇就擒
		/// </summary>
		public static AchievementInfoItem JuSheJiuQin => Instance[(short)29];

		/// <summary>
		/// 无名剑冢
		/// </summary>
		public static AchievementInfoItem WuMingJianZhong => Instance[(short)30];

		/// <summary>
		/// 太吾村覆灭
		/// </summary>
		public static AchievementInfoItem TaiWuCunFuMie => Instance[(short)31];

		/// <summary>
		/// 退魔辟邪
		/// </summary>
		public static AchievementInfoItem TuiMoBiXie => Instance[(short)32];

		/// <summary>
		/// 还剑之愿
		/// </summary>
		public static AchievementInfoItem HuanJianZhiYuan => Instance[(short)33];

		/// <summary>
		/// 除魔之誓
		/// </summary>
		public static AchievementInfoItem ChuMoZhiShi => Instance[(short)34];

		/// <summary>
		/// 囿于俗见
		/// </summary>
		public static AchievementInfoItem YouYuSuJian => Instance[(short)35];

		/// <summary>
		/// 苦寻圣人
		/// </summary>
		public static AchievementInfoItem KuXunShengRen => Instance[(short)36];

		/// <summary>
		/// 焚心之悲
		/// </summary>
		public static AchievementInfoItem FenXinZhiBei => Instance[(short)37];

		/// <summary>
		/// 舍身求道
		/// </summary>
		public static AchievementInfoItem SheShenQiuDao => Instance[(short)38];

		/// <summary>
		/// 无瑕之念
		/// </summary>
		public static AchievementInfoItem WuXiaZhiNian => Instance[(short)39];

		/// <summary>
		/// 百战不折
		/// </summary>
		public static AchievementInfoItem BaiZhanBuZhe => Instance[(short)40];

		/// <summary>
		/// 恩义难全
		/// </summary>
		public static AchievementInfoItem EnYiNanQuan => Instance[(short)41];

		/// <summary>
		/// 禅武之道
		/// </summary>
		public static AchievementInfoItem ChanWuZhiDao => Instance[(short)42];

		/// <summary>
		/// 禅武之道·续
		/// </summary>
		public static AchievementInfoItem ChanWuZhiDaoXu => Instance[(short)43];

		/// <summary>
		/// 隐世白猿
		/// </summary>
		public static AchievementInfoItem YinShiBaiYuan => Instance[(short)44];

		/// <summary>
		/// 隐世白猿·续
		/// </summary>
		public static AchievementInfoItem YinShiBaiYuanXu => Instance[(short)45];

		/// <summary>
		/// 玄鸮白鹿
		/// </summary>
		public static AchievementInfoItem XuanXiaoBaiLu => Instance[(short)46];

		/// <summary>
		/// 玄鸮白鹿·续
		/// </summary>
		public static AchievementInfoItem XuanXiaoBaiLuXu => Instance[(short)47];

		/// <summary>
		/// 龟蛇蟠扶
		/// </summary>
		public static AchievementInfoItem GuiShePanFu => Instance[(short)48];

		/// <summary>
		/// 龟蛇蟠扶·续
		/// </summary>
		public static AchievementInfoItem GuiShePanFuXu => Instance[(short)49];

		/// <summary>
		/// 石牢三魔
		/// </summary>
		public static AchievementInfoItem ShiLaoSanMo => Instance[(short)50];

		/// <summary>
		/// 石牢三魔·续
		/// </summary>
		public static AchievementInfoItem ShiLaoSanMoXu => Instance[(short)51];

		/// <summary>
		/// 文武双全
		/// </summary>
		public static AchievementInfoItem WenWuShuangQuan => Instance[(short)52];

		/// <summary>
		/// 文武双全·续
		/// </summary>
		public static AchievementInfoItem WenWuShuangQuanXu => Instance[(short)53];

		/// <summary>
		/// 青琅仙阁
		/// </summary>
		public static AchievementInfoItem QingLangXianGe => Instance[(short)54];

		/// <summary>
		/// 青琅仙阁·续
		/// </summary>
		public static AchievementInfoItem QingLangXianGeXu => Instance[(short)55];

		/// <summary>
		/// 镜水倒颠
		/// </summary>
		public static AchievementInfoItem JingShuiDaoDian => Instance[(short)56];

		/// <summary>
		/// 镜水倒颠·续
		/// </summary>
		public static AchievementInfoItem JingShuiDaoDianXu => Instance[(short)57];

		/// <summary>
		/// 铜生试剑
		/// </summary>
		public static AchievementInfoItem TongShengShiJian => Instance[(short)58];

		/// <summary>
		/// 铜生试剑·续
		/// </summary>
		public static AchievementInfoItem TongShengShiJianXu => Instance[(short)59];

		/// <summary>
		/// 奇毒绝方
		/// </summary>
		public static AchievementInfoItem QiDuJueFang => Instance[(short)60];

		/// <summary>
		/// 奇毒绝方·续
		/// </summary>
		public static AchievementInfoItem QiDuJueFangXu => Instance[(short)61];

		/// <summary>
		/// 真经无字
		/// </summary>
		public static AchievementInfoItem ZhenJingWuZi => Instance[(short)62];

		/// <summary>
		/// 真经无字·续
		/// </summary>
		public static AchievementInfoItem ZhenJingWuZiXu => Instance[(short)63];

		/// <summary>
		/// 五圣心毒
		/// </summary>
		public static AchievementInfoItem WuShengXinDu => Instance[(short)64];

		/// <summary>
		/// 五圣心毒·续
		/// </summary>
		public static AchievementInfoItem WuShengXinDuXu => Instance[(short)65];

		/// <summary>
		/// 善恶无生
		/// </summary>
		public static AchievementInfoItem ShanEWuSheng => Instance[(short)66];

		/// <summary>
		/// 善恶无生·续
		/// </summary>
		public static AchievementInfoItem ShanEWuShengXu => Instance[(short)67];

		/// <summary>
		/// 伏龙化羽
		/// </summary>
		public static AchievementInfoItem FuLongHuaYu => Instance[(short)68];

		/// <summary>
		/// 伏龙化羽·续
		/// </summary>
		public static AchievementInfoItem FuLongHuaYuXu => Instance[(short)69];

		/// <summary>
		/// 血冢遗姝
		/// </summary>
		public static AchievementInfoItem XueZhongYiShu => Instance[(short)70];

		/// <summary>
		/// 血冢遗姝·续
		/// </summary>
		public static AchievementInfoItem XueZhongYiShuXu => Instance[(short)71];

		/// <summary>
		/// 绘卷新篇
		/// </summary>
		public static AchievementInfoItem HuiJuanXinPian => Instance[(short)72];

		/// <summary>
		/// 前尘往事
		/// </summary>
		public static AchievementInfoItem QianChenWangShi => Instance[(short)73];

		/// <summary>
		/// 剑中记忆
		/// </summary>
		public static AchievementInfoItem JianZhongJiYi => Instance[(short)74];

		/// <summary>
		/// 再续前缘
		/// </summary>
		public static AchievementInfoItem ZaiXuQianYuan => Instance[(short)75];

		/// <summary>
		/// 玄狱之劫
		/// </summary>
		public static AchievementInfoItem XuanYuZhiJie => Instance[(short)76];

		/// <summary>
		/// 任其自然
		/// </summary>
		public static AchievementInfoItem RenQiZiRan => Instance[(short)77];

		/// <summary>
		/// 福泽绵长
		/// </summary>
		public static AchievementInfoItem FuZeMianChang => Instance[(short)78];

		/// <summary>
		/// 一脉相承
		/// </summary>
		public static AchievementInfoItem YiMaiXiangCheng => Instance[(short)79];

		/// <summary>
		/// 后继有人
		/// </summary>
		public static AchievementInfoItem HouJiYouRen => Instance[(short)80];

		/// <summary>
		/// 薪火相传
		/// </summary>
		public static AchievementInfoItem XinHuoXiangChuan => Instance[(short)81];

		/// <summary>
		/// 一世通天
		/// </summary>
		public static AchievementInfoItem YiShiTongTian => Instance[(short)82];

		/// <summary>
		/// 十世相承
		/// </summary>
		public static AchievementInfoItem ShiShiXiangCheng => Instance[(short)83];

		/// <summary>
		/// 重操旧业
		/// </summary>
		public static AchievementInfoItem ChongCaoJiuYe => Instance[(short)84];

		/// <summary>
		/// 伏虞护命
		/// </summary>
		public static AchievementInfoItem FuYuHuMing => Instance[(short)85];

		/// <summary>
		/// 有相皆痴苦
		/// </summary>
		public static AchievementInfoItem YouXiangJieChiKu => Instance[(short)86];

		/// <summary>
		/// 无人脱网罗
		/// </summary>
		public static AchievementInfoItem WuRenTuoWangLuo => Instance[(short)87];

		/// <summary>
		/// 恶贯满盈
		/// </summary>
		public static AchievementInfoItem EGuanManYing => Instance[(short)88];

		/// <summary>
		/// 名扬四海
		/// </summary>
		public static AchievementInfoItem MingYangSiHai => Instance[(short)89];

		/// <summary>
		/// 顺心而行
		/// </summary>
		public static AchievementInfoItem ShunXinErXing => Instance[(short)90];

		/// <summary>
		/// 违心之举
		/// </summary>
		public static AchievementInfoItem WeiXinZhiJu => Instance[(short)91];

		/// <summary>
		/// 笑口常开
		/// </summary>
		public static AchievementInfoItem XiaoKouChangKai => Instance[(short)92];

		/// <summary>
		/// 肝肠寸断
		/// </summary>
		public static AchievementInfoItem GanChangCunDuan => Instance[(short)93];

		/// <summary>
		/// 长生久视
		/// </summary>
		public static AchievementInfoItem ChangShengJiuShi => Instance[(short)94];

		/// <summary>
		/// 志同道合
		/// </summary>
		public static AchievementInfoItem ZhiTongDaoHe => Instance[(short)95];

		/// <summary>
		/// 连理同心
		/// </summary>
		public static AchievementInfoItem LianLiTongXin => Instance[(short)96];

		/// <summary>
		/// 呱呱坠地
		/// </summary>
		public static AchievementInfoItem GuGuZhuiDi => Instance[(short)97];

		/// <summary>
		/// 多子多福
		/// </summary>
		public static AchievementInfoItem DuoZiDuoFu => Instance[(short)98];

		/// <summary>
		/// 异胎降世
		/// </summary>
		public static AchievementInfoItem YiTaiJiangShi => Instance[(short)99];

		/// <summary>
		/// 远走高飞
		/// </summary>
		public static AchievementInfoItem YuanGaoFeiZou => Instance[(short)100];

		/// <summary>
		/// 金兰之契
		/// </summary>
		public static AchievementInfoItem JinLanZhiQi => Instance[(short)101];

		/// <summary>
		/// 飘零半生
		/// </summary>
		public static AchievementInfoItem PiaoLingBanSheng => Instance[(short)102];

		/// <summary>
		/// 三生石上
		/// </summary>
		public static AchievementInfoItem SanShengShiShang => Instance[(short)103];

		/// <summary>
		/// 倒反纲常
		/// </summary>
		public static AchievementInfoItem DaoFanGangChang => Instance[(short)104];

		/// <summary>
		/// 众星捧月
		/// </summary>
		public static AchievementInfoItem ZhongXingPengYue => Instance[(short)105];

		/// <summary>
		/// 众矢之的
		/// </summary>
		public static AchievementInfoItem ZhongShiZhiDi => Instance[(short)106];

		/// <summary>
		/// 使命必达
		/// </summary>
		public static AchievementInfoItem ShiMingBiDa => Instance[(short)107];

		/// <summary>
		/// 寸草不生
		/// </summary>
		public static AchievementInfoItem CunCaoBuSheng => Instance[(short)108];

		/// <summary>
		/// 爱恨交织
		/// </summary>
		public static AchievementInfoItem AiHenJiaoZhi => Instance[(short)109];

		/// <summary>
		/// 江湖百晓生
		/// </summary>
		public static AchievementInfoItem JiangHuBaiXiaoSheng => Instance[(short)110];

		/// <summary>
		/// 点到为止
		/// </summary>
		public static AchievementInfoItem DianDaoWeiZhi => Instance[(short)111];

		/// <summary>
		/// 身经百战
		/// </summary>
		public static AchievementInfoItem ShenJingBaiZhan => Instance[(short)112];

		/// <summary>
		/// 应对自如
		/// </summary>
		public static AchievementInfoItem YingDuiZiRu => Instance[(short)113];

		/// <summary>
		/// 不死不休
		/// </summary>
		public static AchievementInfoItem BuSiBuXiu => Instance[(short)114];

		/// <summary>
		/// 良言美意
		/// </summary>
		public static AchievementInfoItem LiangYanMeiYi => Instance[(short)115];

		/// <summary>
		/// 恶语伤人
		/// </summary>
		public static AchievementInfoItem EYuShangRen => Instance[(short)116];

		/// <summary>
		/// 五花八门
		/// </summary>
		public static AchievementInfoItem WuHuaBaMen => Instance[(short)117];

		/// <summary>
		/// 走为上计
		/// </summary>
		public static AchievementInfoItem ZouWeiShangJi => Instance[(short)118];

		/// <summary>
		/// 甘拜下风
		/// </summary>
		public static AchievementInfoItem GanBaiXiaFeng => Instance[(short)119];

		/// <summary>
		/// 五花大绑
		/// </summary>
		public static AchievementInfoItem WuHuaDaBang => Instance[(short)120];

		/// <summary>
		/// 伏虞救厄
		/// </summary>
		public static AchievementInfoItem FuYuJiuE => Instance[(short)121];

		/// <summary>
		/// 除魔卫道
		/// </summary>
		public static AchievementInfoItem ChuMoWeiDao => Instance[(short)122];

		/// <summary>
		/// 再造之恩
		/// </summary>
		public static AchievementInfoItem ZaiZaoZhiEn => Instance[(short)123];

		/// <summary>
		/// 仗义行侠
		/// </summary>
		public static AchievementInfoItem ZhangYiXingXia => Instance[(short)124];

		/// <summary>
		/// 逆我者亡
		/// </summary>
		public static AchievementInfoItem NiWoZheWang => Instance[(short)125];

		/// <summary>
		/// 降龙伏虎
		/// </summary>
		public static AchievementInfoItem XiangLongFuHu => Instance[(short)126];

		/// <summary>
		/// 辗转腾挪
		/// </summary>
		public static AchievementInfoItem ZhanZhuanTengNuo => Instance[(short)127];

		/// <summary>
		/// 不动如山
		/// </summary>
		public static AchievementInfoItem BuDongRuShan => Instance[(short)128];

		/// <summary>
		/// 变化莫测
		/// </summary>
		public static AchievementInfoItem BianHuaMoCe => Instance[(short)129];

		/// <summary>
		/// 齐心协力
		/// </summary>
		public static AchievementInfoItem QiXinXieLi => Instance[(short)130];

		/// <summary>
		/// 祸起萧墙
		/// </summary>
		public static AchievementInfoItem HuoQiXiaoQiang => Instance[(short)131];

		/// <summary>
		/// 他强由他强
		/// </summary>
		public static AchievementInfoItem TaQiangYouTaQiang => Instance[(short)132];

		/// <summary>
		/// 排山倒海
		/// </summary>
		public static AchievementInfoItem PaiShanDaoHai => Instance[(short)133];

		/// <summary>
		/// 洞金裂石
		/// </summary>
		public static AchievementInfoItem DongJinLieShi => Instance[(short)134];

		/// <summary>
		/// 踢星踏月
		/// </summary>
		public static AchievementInfoItem TiXingTaYue => Instance[(short)135];

		/// <summary>
		/// 飞花摘叶
		/// </summary>
		public static AchievementInfoItem FeiHuaZhaiYe => Instance[(short)136];

		/// <summary>
		/// 剑气纵横
		/// </summary>
		public static AchievementInfoItem JianQiZongHeng => Instance[(short)137];

		/// <summary>
		/// 劈波斩浪
		/// </summary>
		public static AchievementInfoItem PiBoZhanLang => Instance[(short)138];

		/// <summary>
		/// 寸长寸强
		/// </summary>
		public static AchievementInfoItem CunChangCunQiang => Instance[(short)139];

		/// <summary>
		/// 奇门异术
		/// </summary>
		public static AchievementInfoItem QiMenYiShu => Instance[(short)140];

		/// <summary>
		/// 势若游龙
		/// </summary>
		public static AchievementInfoItem ShiRuoYouLong => Instance[(short)141];

		/// <summary>
		/// 百步穿杨
		/// </summary>
		public static AchievementInfoItem BaiBuChuanYang => Instance[(short)142];

		/// <summary>
		/// 魔音贯耳
		/// </summary>
		public static AchievementInfoItem MoYinGuanEr => Instance[(short)143];

		/// <summary>
		/// 势不可挡
		/// </summary>
		public static AchievementInfoItem ShiBuKeDang => Instance[(short)144];

		/// <summary>
		/// 蹩脚功夫
		/// </summary>
		public static AchievementInfoItem BieJiaoGongFu => Instance[(short)145];

		/// <summary>
		/// 分筋错骨
		/// </summary>
		public static AchievementInfoItem FenJinCuoGu => Instance[(short)146];

		/// <summary>
		/// 身残志坚
		/// </summary>
		public static AchievementInfoItem ShenCanZhiJian => Instance[(short)147];

		/// <summary>
		/// 毒气攻心
		/// </summary>
		public static AchievementInfoItem DuQiGongXin => Instance[(short)148];

		/// <summary>
		/// 七彩玲珑心
		/// </summary>
		public static AchievementInfoItem QiCaiLingLongXin => Instance[(short)149];

		/// <summary>
		/// 气冲斗牛
		/// </summary>
		public static AchievementInfoItem QiChongDouNiu => Instance[(short)150];

		/// <summary>
		/// 气散功消
		/// </summary>
		public static AchievementInfoItem QiSanGongXiao => Instance[(short)151];

		/// <summary>
		/// 穷追猛打
		/// </summary>
		public static AchievementInfoItem QiongZhuiMengDa => Instance[(short)152];

		/// <summary>
		/// 心有所向
		/// </summary>
		public static AchievementInfoItem XinYouSuoXiang => Instance[(short)153];

		/// <summary>
		/// 志有所成
		/// </summary>
		public static AchievementInfoItem ZhiYouSuoCheng => Instance[(short)154];

		/// <summary>
		/// 山中高士
		/// </summary>
		public static AchievementInfoItem ShanZhongGaoShi => Instance[(short)155];

		/// <summary>
		/// 百兽之王
		/// </summary>
		public static AchievementInfoItem BaiShouZhiWang => Instance[(short)156];

		/// <summary>
		/// 巧夺天工
		/// </summary>
		public static AchievementInfoItem QiaoDuoTianGong => Instance[(short)157];

		/// <summary>
		/// 一呼百应
		/// </summary>
		public static AchievementInfoItem YiHuBaiYing => Instance[(short)158];

		/// <summary>
		/// 才高八斗
		/// </summary>
		public static AchievementInfoItem CaiGaoBaDou => Instance[(short)159];

		/// <summary>
		/// 道法自然
		/// </summary>
		public static AchievementInfoItem DaoFaZiRan => Instance[(short)160];

		/// <summary>
		/// 功德圆满
		/// </summary>
		public static AchievementInfoItem GongDeYuanMan => Instance[(short)161];

		/// <summary>
		/// 酒中豪杰
		/// </summary>
		public static AchievementInfoItem JiuZhongHaoJie => Instance[(short)162];

		/// <summary>
		/// 钟鸣鼎食
		/// </summary>
		public static AchievementInfoItem ZhongMingDingShi => Instance[(short)163];

		/// <summary>
		/// 游戏人间
		/// </summary>
		public static AchievementInfoItem YouXiRenJian => Instance[(short)164];

		/// <summary>
		/// 布衣自适
		/// </summary>
		public static AchievementInfoItem BuYiZiShi => Instance[(short)165];

		/// <summary>
		/// 行遍天涯
		/// </summary>
		public static AchievementInfoItem XingBianTianYa => Instance[(short)166];

		/// <summary>
		/// 明心见性
		/// </summary>
		public static AchievementInfoItem MingXinJianXing => Instance[(short)167];

		/// <summary>
		/// 妙手回春
		/// </summary>
		public static AchievementInfoItem MiaoShouHuiChun => Instance[(short)168];

		/// <summary>
		/// 化外逍遥
		/// </summary>
		public static AchievementInfoItem HuaWaiXiaoYao => Instance[(short)169];

		/// <summary>
		/// 挥金如土
		/// </summary>
		public static AchievementInfoItem HuiJinRuTu => Instance[(short)170];

		/// <summary>
		/// 风流雅士
		/// </summary>
		public static AchievementInfoItem FengLiuYaShi => Instance[(short)171];

		/// <summary>
		/// 万民来朝
		/// </summary>
		public static AchievementInfoItem WanMinLaiChao => Instance[(short)172];

		/// <summary>
		/// 诸业精通
		/// </summary>
		public static AchievementInfoItem ZhuYeJingTong => Instance[(short)173];

		/// <summary>
		/// 初窥门径
		/// </summary>
		public static AchievementInfoItem ChuKuiMenJing => Instance[(short)174];

		/// <summary>
		/// 术业专攻
		/// </summary>
		public static AchievementInfoItem ShuYeZhuanGong => Instance[(short)175];

		/// <summary>
		/// 音律大成
		/// </summary>
		public static AchievementInfoItem YinLvDaCheng => Instance[(short)176];

		/// <summary>
		/// 弈棋大成
		/// </summary>
		public static AchievementInfoItem YiQiDaCheng => Instance[(short)177];

		/// <summary>
		/// 诗书大成
		/// </summary>
		public static AchievementInfoItem ShiShuDaCheng => Instance[(short)178];

		/// <summary>
		/// 绘画大成
		/// </summary>
		public static AchievementInfoItem HuiHuaDaCheng => Instance[(short)179];

		/// <summary>
		/// 术数大成
		/// </summary>
		public static AchievementInfoItem ShuShuDaCheng => Instance[(short)180];

		/// <summary>
		/// 品鉴大成
		/// </summary>
		public static AchievementInfoItem PinJianDaCheng => Instance[(short)181];

		/// <summary>
		/// 锻造大成
		/// </summary>
		public static AchievementInfoItem DuanZaoDaCheng => Instance[(short)182];

		/// <summary>
		/// 制木大成
		/// </summary>
		public static AchievementInfoItem ZhiMuDaCheng => Instance[(short)183];

		/// <summary>
		/// 医术大成
		/// </summary>
		public static AchievementInfoItem YiShuDaCheng => Instance[(short)184];

		/// <summary>
		/// 毒术大成
		/// </summary>
		public static AchievementInfoItem DuShuDaCheng => Instance[(short)185];

		/// <summary>
		/// 织锦大成
		/// </summary>
		public static AchievementInfoItem ZhiJinDaCheng => Instance[(short)186];

		/// <summary>
		/// 巧匠大成
		/// </summary>
		public static AchievementInfoItem QiaoJiangDaCheng => Instance[(short)187];

		/// <summary>
		/// 道法大成
		/// </summary>
		public static AchievementInfoItem DaoFaDaCheng => Instance[(short)188];

		/// <summary>
		/// 佛学大成
		/// </summary>
		public static AchievementInfoItem FoXueDaCheng => Instance[(short)189];

		/// <summary>
		/// 厨艺大成
		/// </summary>
		public static AchievementInfoItem ChuYiDaCheng => Instance[(short)190];

		/// <summary>
		/// 杂学大成
		/// </summary>
		public static AchievementInfoItem ZaXueDaCheng => Instance[(short)191];

		/// <summary>
		/// 学究天人
		/// </summary>
		public static AchievementInfoItem XueJiuTianRen => Instance[(short)192];

		/// <summary>
		/// 技高一筹
		/// </summary>
		public static AchievementInfoItem JiGaoYiChou => Instance[(short)193];

		/// <summary>
		/// 舌灿莲花
		/// </summary>
		public static AchievementInfoItem SheCanLianHua => Instance[(short)194];

		/// <summary>
		/// 初学乍练
		/// </summary>
		public static AchievementInfoItem ChuXueZhaLian => Instance[(short)195];

		/// <summary>
		/// 尽得真传
		/// </summary>
		public static AchievementInfoItem JinDeZhenChuan => Instance[(short)196];

		/// <summary>
		/// 少林绝学
		/// </summary>
		public static AchievementInfoItem ShaoLinJueXue => Instance[(short)197];

		/// <summary>
		/// 峨眉绝学
		/// </summary>
		public static AchievementInfoItem EMeiJueXue => Instance[(short)198];

		/// <summary>
		/// 百花绝学
		/// </summary>
		public static AchievementInfoItem BaiHuaJueXue => Instance[(short)199];

		/// <summary>
		/// 武当绝学
		/// </summary>
		public static AchievementInfoItem WuDangJueXue => Instance[(short)200];

		/// <summary>
		/// 元山绝学
		/// </summary>
		public static AchievementInfoItem YuanShanJueXue => Instance[(short)201];

		/// <summary>
		/// 狮相绝学
		/// </summary>
		public static AchievementInfoItem ShiXiangJueXue => Instance[(short)202];

		/// <summary>
		/// 然山绝学
		/// </summary>
		public static AchievementInfoItem RanShanJueXue => Instance[(short)203];

		/// <summary>
		/// 璇女绝学
		/// </summary>
		public static AchievementInfoItem XuanNvJueXue => Instance[(short)204];

		/// <summary>
		/// 铸剑绝学
		/// </summary>
		public static AchievementInfoItem ZhuJianJueXue => Instance[(short)205];

		/// <summary>
		/// 空桑绝学
		/// </summary>
		public static AchievementInfoItem KongSangJueXue => Instance[(short)206];

		/// <summary>
		/// 金刚绝学
		/// </summary>
		public static AchievementInfoItem JinGangJueXue => Instance[(short)207];

		/// <summary>
		/// 五仙绝学
		/// </summary>
		public static AchievementInfoItem WuXianJueXue => Instance[(short)208];

		/// <summary>
		/// 界青绝学
		/// </summary>
		public static AchievementInfoItem JieQingJueXue => Instance[(short)209];

		/// <summary>
		/// 伏龙绝学
		/// </summary>
		public static AchievementInfoItem FuLongJueXue => Instance[(short)210];

		/// <summary>
		/// 血犼绝学
		/// </summary>
		public static AchievementInfoItem XueHaoJueXue => Instance[(short)211];

		/// <summary>
		/// 功参造化
		/// </summary>
		public static AchievementInfoItem GongCanZaoHua => Instance[(short)212];

		/// <summary>
		/// 少林盟誓
		/// </summary>
		public static AchievementInfoItem ShaoLinMengShi => Instance[(short)213];

		/// <summary>
		/// 峨眉盟誓
		/// </summary>
		public static AchievementInfoItem EMeiMengShi => Instance[(short)214];

		/// <summary>
		/// 百花盟誓
		/// </summary>
		public static AchievementInfoItem BaiHuaMengShi => Instance[(short)215];

		/// <summary>
		/// 武当盟誓
		/// </summary>
		public static AchievementInfoItem WuDangMengShi => Instance[(short)216];

		/// <summary>
		/// 元山盟誓
		/// </summary>
		public static AchievementInfoItem YuanShanMengShi => Instance[(short)217];

		/// <summary>
		/// 狮相盟誓
		/// </summary>
		public static AchievementInfoItem ShiXiangMengShi => Instance[(short)218];

		/// <summary>
		/// 然山盟誓
		/// </summary>
		public static AchievementInfoItem RanShanMengShi => Instance[(short)219];

		/// <summary>
		/// 璇女盟誓
		/// </summary>
		public static AchievementInfoItem XuanNvMengShi => Instance[(short)220];

		/// <summary>
		/// 铸剑盟誓
		/// </summary>
		public static AchievementInfoItem ZhuJianMengShi => Instance[(short)221];

		/// <summary>
		/// 空桑盟誓
		/// </summary>
		public static AchievementInfoItem KongSangMengShi => Instance[(short)222];

		/// <summary>
		/// 金刚盟誓
		/// </summary>
		public static AchievementInfoItem JinGangMengShi => Instance[(short)223];

		/// <summary>
		/// 五仙盟誓
		/// </summary>
		public static AchievementInfoItem WuXianMengShi => Instance[(short)224];

		/// <summary>
		/// 界青盟誓
		/// </summary>
		public static AchievementInfoItem JieQingMengShi => Instance[(short)225];

		/// <summary>
		/// 伏龙盟誓
		/// </summary>
		public static AchievementInfoItem FuLongMengShi => Instance[(short)226];

		/// <summary>
		/// 血犼盟誓
		/// </summary>
		public static AchievementInfoItem XueHaoMengShi => Instance[(short)227];

		/// <summary>
		/// 无坚不摧
		/// </summary>
		public static AchievementInfoItem WuJianBuCui => Instance[(short)228];

		/// <summary>
		/// 奔逸绝尘
		/// </summary>
		public static AchievementInfoItem BenYiJueChen => Instance[(short)229];

		/// <summary>
		/// 固若金汤
		/// </summary>
		public static AchievementInfoItem GuRuoJinTang => Instance[(short)230];

		/// <summary>
		/// 奇经八脉
		/// </summary>
		public static AchievementInfoItem QiJingBaMai => Instance[(short)231];

		/// <summary>
		/// 冲破玄关
		/// </summary>
		public static AchievementInfoItem ChongPoXuanGuan => Instance[(short)232];

		/// <summary>
		/// 走火入魔
		/// </summary>
		public static AchievementInfoItem ZouHuoRuMo => Instance[(short)233];

		/// <summary>
		/// 熟能生巧
		/// </summary>
		public static AchievementInfoItem ShuNengShengQiao => Instance[(short)234];

		/// <summary>
		/// 浑心无字
		/// </summary>
		public static AchievementInfoItem HunXinWuZi => Instance[(short)235];

		/// <summary>
		/// 白衣行化
		/// </summary>
		public static AchievementInfoItem BaiYiXingHua => Instance[(short)236];

		/// <summary>
		/// 大全千法
		/// </summary>
		public static AchievementInfoItem DaQuanQianFa => Instance[(short)237];

		/// <summary>
		/// 象龙演画
		/// </summary>
		public static AchievementInfoItem XiangLongYanHua => Instance[(short)238];

		/// <summary>
		/// 心观残笺
		/// </summary>
		public static AchievementInfoItem XinGuanCanJian => Instance[(short)239];

		/// <summary>
		/// 八埏至宝
		/// </summary>
		public static AchievementInfoItem BaYanZhiBao => Instance[(short)240];

		/// <summary>
		/// 化影奇功
		/// </summary>
		public static AchievementInfoItem HuaYingQiGong => Instance[(short)241];

		/// <summary>
		/// 无名神剑
		/// </summary>
		public static AchievementInfoItem WuMingShenJian => Instance[(short)242];

		/// <summary>
		/// 十杀魔罗
		/// </summary>
		public static AchievementInfoItem ShiShaMoLuo => Instance[(short)243];

		/// <summary>
		/// 一画开天
		/// </summary>
		public static AchievementInfoItem YiHuaKaiTian => Instance[(short)244];

		/// <summary>
		/// 无先玄元
		/// </summary>
		public static AchievementInfoItem WuXianXuanYuan => Instance[(short)245];

		/// <summary>
		/// 九似真藏
		/// </summary>
		public static AchievementInfoItem JiuSiZhenCang => Instance[(short)246];

		/// <summary>
		/// 天通神术
		/// </summary>
		public static AchievementInfoItem TianTongShenShu => Instance[(short)247];

		/// <summary>
		/// 神女绝音
		/// </summary>
		public static AchievementInfoItem ShenNvJueYin => Instance[(short)248];

		/// <summary>
		/// 十四奇书
		/// </summary>
		public static AchievementInfoItem ShiSiQiShu => Instance[(short)249];

		/// <summary>
		/// 地力充盈
		/// </summary>
		public static AchievementInfoItem DiLiChongYing => Instance[(short)250];

		/// <summary>
		/// 物华天宝
		/// </summary>
		public static AchievementInfoItem WuHuaTianBao => Instance[(short)251];

		/// <summary>
		/// 人丁兴旺
		/// </summary>
		public static AchievementInfoItem RenDingXingWang => Instance[(short)252];

		/// <summary>
		/// 各司其职
		/// </summary>
		public static AchievementInfoItem GeSiQiZhi => Instance[(short)253];

		/// <summary>
		/// 仓廪丰实
		/// </summary>
		public static AchievementInfoItem CangLinFengShi => Instance[(short)254];

		/// <summary>
		/// 鸡鸣千里
		/// </summary>
		public static AchievementInfoItem JiMingQianLi => Instance[(short)255];

		/// <summary>
		/// 设席开宴
		/// </summary>
		public static AchievementInfoItem SheXiKaiYan => Instance[(short)256];

		/// <summary>
		/// 宴请八方
		/// </summary>
		public static AchievementInfoItem YanQingBaFang => Instance[(short)257];

		/// <summary>
		/// 轮回往生
		/// </summary>
		public static AchievementInfoItem LunHuiWangSheng => Instance[(short)258];

		/// <summary>
		/// 六道轮回
		/// </summary>
		public static AchievementInfoItem LiuDaoLunHui => Instance[(short)259];

		/// <summary>
		/// 丝路复兴
		/// </summary>
		public static AchievementInfoItem SiLuFuXing => Instance[(short)260];

		/// <summary>
		/// 服牛帮上宾
		/// </summary>
		public static AchievementInfoItem FuNiuBangShangBin => Instance[(short)261];

		/// <summary>
		/// 书海阁上宾
		/// </summary>
		public static AchievementInfoItem ShuHaiGeShangBin => Instance[(short)262];

		/// <summary>
		/// 五湖上宾
		/// </summary>
		public static AchievementInfoItem WuHuShangBin => Instance[(short)263];

		/// <summary>
		/// 大武魁上宾
		/// </summary>
		public static AchievementInfoItem DaWuKuiShangBin => Instance[(short)264];

		/// <summary>
		/// 回春堂上宾
		/// </summary>
		public static AchievementInfoItem HuiChunTangShangBin => Instance[(short)265];

		/// <summary>
		/// 公输坊上宾
		/// </summary>
		public static AchievementInfoItem GongShuFangShangBin => Instance[(short)266];

		/// <summary>
		/// 奇货斋上宾
		/// </summary>
		public static AchievementInfoItem QiHuoZhaiShangBin => Instance[(short)267];

		/// <summary>
		/// 千锤百炼
		/// </summary>
		public static AchievementInfoItem QianChuiBaiLian => Instance[(short)268];

		/// <summary>
		/// 鬼斧神工
		/// </summary>
		public static AchievementInfoItem GuiFuShenGong => Instance[(short)269];

		/// <summary>
		/// 织霞成锦
		/// </summary>
		public static AchievementInfoItem ZhiXiaChengJin => Instance[(short)270];

		/// <summary>
		/// 连城之璧
		/// </summary>
		public static AchievementInfoItem LianChengZhiBi => Instance[(short)271];

		/// <summary>
		/// 炉火纯青
		/// </summary>
		public static AchievementInfoItem LuHuoChunQing => Instance[(short)272];

		/// <summary>
		/// 封喉断肠
		/// </summary>
		public static AchievementInfoItem FengHouDuanChang => Instance[(short)273];

		/// <summary>
		/// 烹龙炮凤
		/// </summary>
		public static AchievementInfoItem PengLongPaoFeng => Instance[(short)274];

		/// <summary>
		/// 驿路初通
		/// </summary>
		public static AchievementInfoItem YiLuChuTong => Instance[(short)275];

		/// <summary>
		/// 九州通衢
		/// </summary>
		public static AchievementInfoItem JiuZhouTongQu => Instance[(short)276];

		/// <summary>
		/// 恶丐窝
		/// </summary>
		public static AchievementInfoItem EGaiWo => Instance[(short)277];

		/// <summary>
		/// 贼人营寨
		/// </summary>
		public static AchievementInfoItem ZeiRenYingZhai => Instance[(short)278];

		/// <summary>
		/// 悍匪砦
		/// </summary>
		public static AchievementInfoItem HanFeiZhai => Instance[(short)279];

		/// <summary>
		/// 叛徒结伙
		/// </summary>
		public static AchievementInfoItem PanTuJieHuo => Instance[(short)280];

		/// <summary>
		/// 恶人谷
		/// </summary>
		public static AchievementInfoItem ERenGu => Instance[(short)281];

		/// <summary>
		/// 迷香阵
		/// </summary>
		public static AchievementInfoItem MiXiangZhen => Instance[(short)282];

		/// <summary>
		/// 乱葬岗
		/// </summary>
		public static AchievementInfoItem LuanZangGang => Instance[(short)283];

		/// <summary>
		/// 异士居
		/// </summary>
		public static AchievementInfoItem YiShiJu => Instance[(short)284];

		/// <summary>
		/// 邪人死地
		/// </summary>
		public static AchievementInfoItem XieRenSiDi => Instance[(short)285];

		/// <summary>
		/// 修罗场
		/// </summary>
		public static AchievementInfoItem XiuLuoChang => Instance[(short)286];

		/// <summary>
		/// 群魔乱舞
		/// </summary>
		public static AchievementInfoItem QunMoLuanWu => Instance[(short)287];

		/// <summary>
		/// 弃世绝境
		/// </summary>
		public static AchievementInfoItem QiShiJueJing => Instance[(short)288];

		/// <summary>
		/// 义士堂
		/// </summary>
		public static AchievementInfoItem YiShiTang => Instance[(short)289];

		/// <summary>
		/// 任侠会盟
		/// </summary>
		public static AchievementInfoItem RenXiaHuiMeng => Instance[(short)290];

		/// <summary>
		/// 世外秘境
		/// </summary>
		public static AchievementInfoItem ShiWaiMiJing => Instance[(short)291];

		/// <summary>
		/// 秋虫高鸣
		/// </summary>
		public static AchievementInfoItem QiuChongGaoMing => Instance[(short)292];

		/// <summary>
		/// 聊以饲鸡
		/// </summary>
		public static AchievementInfoItem LiaoYiSiJi => Instance[(short)293];

		/// <summary>
		/// 一鸣惊人
		/// </summary>
		public static AchievementInfoItem YiMingJingRen => Instance[(short)294];

		/// <summary>
		/// 虫王全谱
		/// </summary>
		public static AchievementInfoItem ChongWangQuanPu => Instance[(short)295];

		/// <summary>
		/// 斗虫之道
		/// </summary>
		public static AchievementInfoItem DouChongZhiDao => Instance[(short)296];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AchievementInfo Instance = new AchievementInfo();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "RequirementTypes", "RequirementStats", "TemplateId", "Icon", "IconSmall", "Type", "Level", "SteamName" };

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
		_dataArray.Add(new AchievementInfoItem(0, LocalStringManager.GetConfig("AchievementInfo_language", "Name_0"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_0"), "ui9_icon_achievement_RealPig", "ui9_icon_achievement_RealPig_small", EAchievementInfoType.Building, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 0, 1 } }, 0u, isHidden: false, "RealPig"));
		_dataArray.Add(new AchievementInfoItem(1, LocalStringManager.GetConfig("AchievementInfo_language", "Name_1"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_1"), "ui9_icon_achievement_ChuChuMaoLu", "ui9_icon_achievement_ChuChuMaoLu_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 149, 1 } }, 0u, isHidden: true, "ChuChuMaoLu"));
		_dataArray.Add(new AchievementInfoItem(2, LocalStringManager.GetConfig("AchievementInfo_language", "Name_2"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_2"), "ui9_icon_achievement_TaoYuanYiMeng", "ui9_icon_achievement_TaoYuanYiMeng_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 150, 1 } }, 0u, isHidden: true, "TaoYuanYiMeng"));
		_dataArray.Add(new AchievementInfoItem(3, LocalStringManager.GetConfig("AchievementInfo_language", "Name_3"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_3"), "ui9_icon_achievement_TaiWuFuGui", "ui9_icon_achievement_TaiWuFuGui_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 151, 1 } }, 0u, isHidden: true, "TaiWuFuGui"));
		_dataArray.Add(new AchievementInfoItem(4, LocalStringManager.GetConfig("AchievementInfo_language", "Name_4"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_4"), "ui9_icon_achievement_ZaiXuXiangHuo", "ui9_icon_achievement_ZaiXuXiangHuo_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 152, 1 } }, 0u, isHidden: false, "ZaiXuXiangHuo"));
		_dataArray.Add(new AchievementInfoItem(5, LocalStringManager.GetConfig("AchievementInfo_language", "Name_5"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_5"), "ui9_icon_achievement_ChongKaiYiLu", "ui9_icon_achievement_ChongKaiYiLu_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 153, 1 } }, 0u, isHidden: true, "ChongKaiYiLu"));
		_dataArray.Add(new AchievementInfoItem(6, LocalStringManager.GetConfig("AchievementInfo_language", "Name_6"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_6"), "ui9_icon_achievement_ShenNvHuanJian", "ui9_icon_achievement_ShenNvHuanJian_small", EAchievementInfoType.Taiwu, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 154, 1 } }, 0u, isHidden: true, "ShenNvHuanJian"));
		_dataArray.Add(new AchievementInfoItem(7, LocalStringManager.GetConfig("AchievementInfo_language", "Name_7"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_7"), "ui9_icon_achievement_ZhenYuFuXie", "ui9_icon_achievement_ZhenYuFuXie_small", EAchievementInfoType.Taiwu, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 155, 1 } }, 0u, isHidden: true, "ZhenYuFuXie"));
		_dataArray.Add(new AchievementInfoItem(8, LocalStringManager.GetConfig("AchievementInfo_language", "Name_8"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_8"), "ui9_icon_achievement_QiHanLingQi", "ui9_icon_achievement_QiHanLingQi_small", EAchievementInfoType.Taiwu, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 156, 1 } }, 0u, isHidden: true, "QiHanLingQi"));
		_dataArray.Add(new AchievementInfoItem(9, LocalStringManager.GetConfig("AchievementInfo_language", "Name_9"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_9"), "ui9_icon_achievement_QiWenWuCai", "ui9_icon_achievement_QiWenWuCai_small", EAchievementInfoType.Taiwu, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 157, 1 } }, 0u, isHidden: true, "QiWenWuCai"));
		_dataArray.Add(new AchievementInfoItem(10, LocalStringManager.GetConfig("AchievementInfo_language", "Name_10"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_10"), "ui9_icon_achievement_QingGuoJueShi", "ui9_icon_achievement_QingGuoJueShi_small", EAchievementInfoType.Taiwu, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 158, 1 } }, 0u, isHidden: true, "QingGuoJueShi"));
		_dataArray.Add(new AchievementInfoItem(11, LocalStringManager.GetConfig("AchievementInfo_language", "Name_11"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_11"), "ui9_icon_achievement_LongTaiHuaMing", "ui9_icon_achievement_LongTaiHuaMing_small", EAchievementInfoType.Taiwu, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 159, 1 } }, 0u, isHidden: true, "LongTaiHuaMing"));
		_dataArray.Add(new AchievementInfoItem(12, LocalStringManager.GetConfig("AchievementInfo_language", "Name_12"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_12"), "ui9_icon_achievement_RongChenHuaYu", "ui9_icon_achievement_RongChenHuaYu_small", EAchievementInfoType.Taiwu, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 160, 1 } }, 0u, isHidden: true, "RongChenHuaYu"));
		_dataArray.Add(new AchievementInfoItem(13, LocalStringManager.GetConfig("AchievementInfo_language", "Name_13"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_13"), "ui9_icon_achievement_BaGongBaZhi", "ui9_icon_achievement_BaGongBaZhi_small", EAchievementInfoType.Taiwu, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 161, 1 } }, 0u, isHidden: true, "BaGongBaZhi"));
		_dataArray.Add(new AchievementInfoItem(14, LocalStringManager.GetConfig("AchievementInfo_language", "Name_14"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_14"), "ui9_icon_achievement_FangTianChiLing", "ui9_icon_achievement_FangTianChiLing_small", EAchievementInfoType.Taiwu, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 162, 1 } }, 0u, isHidden: true, "FangTianChiLing"));
		_dataArray.Add(new AchievementInfoItem(15, LocalStringManager.GetConfig("AchievementInfo_language", "Name_15"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_15"), "ui9_icon_achievement_JiuJianGuiYi", "ui9_icon_achievement_JiuJianGuiYi_small", EAchievementInfoType.Taiwu, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 163, 1 } }, 0u, isHidden: true, "JiuJianGuiYi"));
		_dataArray.Add(new AchievementInfoItem(16, LocalStringManager.GetConfig("AchievementInfo_language", "Name_16"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_16"), "ui9_icon_achievement_XianKeQiShu", "ui9_icon_achievement_XianKeQiShu_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 164, 1 } }, 0u, isHidden: true, "XianKeQiShu"));
		_dataArray.Add(new AchievementInfoItem(17, LocalStringManager.GetConfig("AchievementInfo_language", "Name_17"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_17"), "ui9_icon_achievement_WuLinMengHui", "ui9_icon_achievement_WuLinMengHui_small", EAchievementInfoType.Taiwu, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 165, 1 } }, 0u, isHidden: true, "WuLinMengHui"));
		_dataArray.Add(new AchievementInfoItem(18, LocalStringManager.GetConfig("AchievementInfo_language", "Name_18"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_18"), "ui9_icon_achievement_ZhaoYaFuZhu", "ui9_icon_achievement_ZhaoYaFuZhu_small", EAchievementInfoType.Taiwu, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 166, 1 } }, 0u, isHidden: true, "ZhaoYaFuZhu"));
		_dataArray.Add(new AchievementInfoItem(19, LocalStringManager.GetConfig("AchievementInfo_language", "Name_19"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_19"), "ui9_icon_achievement_ChuShenZhiDi", "ui9_icon_achievement_ChuShenZhiDi_small", EAchievementInfoType.Taiwu, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 167, 1 } }, 0u, isHidden: true, "ChuShenZhiDi"));
		_dataArray.Add(new AchievementInfoItem(20, LocalStringManager.GetConfig("AchievementInfo_language", "Name_20"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_20"), "ui9_icon_achievement_FanMengHunHui", "ui9_icon_achievement_FanMengHunHui_small", EAchievementInfoType.Taiwu, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 168, 1 } }, 0u, isHidden: true, "FanMengHunHui"));
		_dataArray.Add(new AchievementInfoItem(21, LocalStringManager.GetConfig("AchievementInfo_language", "Name_21"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_21"), "ui9_icon_achievement_ShenHuoJinShen", "ui9_icon_achievement_ShenHuoJinShen_small", EAchievementInfoType.Taiwu, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 169, 1 } }, 0u, isHidden: true, "ShenHuoJinShen"));
		_dataArray.Add(new AchievementInfoItem(22, LocalStringManager.GetConfig("AchievementInfo_language", "Name_22"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_22"), "ui9_icon_achievement_QiYuanWanDao", "ui9_icon_achievement_QiYuanWanDao_small", EAchievementInfoType.Taiwu, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 170, 1 } }, 0u, isHidden: true, "QiYuanWanDao"));
		_dataArray.Add(new AchievementInfoItem(23, LocalStringManager.GetConfig("AchievementInfo_language", "Name_23"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_23"), "ui9_icon_achievement_XuanXiangZhenMo", "ui9_icon_achievement_XuanXiangZhenMo_small", EAchievementInfoType.Taiwu, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 171, 1 } }, 0u, isHidden: true, "XuanXiangZhenMo"));
		_dataArray.Add(new AchievementInfoItem(24, LocalStringManager.GetConfig("AchievementInfo_language", "Name_24"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_24"), "ui9_icon_achievement_YingXiongHouJie", "ui9_icon_achievement_YingXiongHouJie_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 172, 1 } }, 0u, isHidden: true, "YingXiongHouJie"));
		_dataArray.Add(new AchievementInfoItem(25, LocalStringManager.GetConfig("AchievementInfo_language", "Name_25"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_25"), "ui9_icon_achievement_ANiuTongXing", "ui9_icon_achievement_ANiuTongXing_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 173, 1 } }, 0u, isHidden: true, "ANiuTongXing"));
		_dataArray.Add(new AchievementInfoItem(26, LocalStringManager.GetConfig("AchievementInfo_language", "Name_26"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_26"), "ui9_icon_achievement_XiaoMaoTongXing", "ui9_icon_achievement_XiaoMaoTongXing_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 174, 1 } }, 0u, isHidden: true, "XiaoMaoTongXing"));
		_dataArray.Add(new AchievementInfoItem(27, LocalStringManager.GetConfig("AchievementInfo_language", "Name_27"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_27"), "ui9_icon_achievement_GuoYanTongXing", "ui9_icon_achievement_GuoYanTongXing_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 175, 1 } }, 0u, isHidden: true, "GuoYanTongXing"));
		_dataArray.Add(new AchievementInfoItem(28, LocalStringManager.GetConfig("AchievementInfo_language", "Name_28"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_28"), "ui9_icon_achievement_HuanYueTongXing", "ui9_icon_achievement_HuanYueTongXing_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 176, 1 } }, 0u, isHidden: true, "HuanYueTongXing"));
		_dataArray.Add(new AchievementInfoItem(29, LocalStringManager.GetConfig("AchievementInfo_language", "Name_29"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_29"), "ui9_icon_achievement_JuSheJiuQin", "ui9_icon_achievement_JuSheJiuQin_small", EAchievementInfoType.Taiwu, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 31, 1 } }, 0u, isHidden: true, "JuSheJiuQin"));
		_dataArray.Add(new AchievementInfoItem(30, LocalStringManager.GetConfig("AchievementInfo_language", "Name_30"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_30"), "ui9_icon_achievement_WuMingJianZhong", "ui9_icon_achievement_WuMingJianZhong_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 178, 1 } }, 0u, isHidden: true, "WuMingJianZhong"));
		_dataArray.Add(new AchievementInfoItem(31, LocalStringManager.GetConfig("AchievementInfo_language", "Name_31"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_31"), "ui9_icon_achievement_TaiWuCunFuMie", "ui9_icon_achievement_TaiWuCunFuMie_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 179, 1 } }, 0u, isHidden: true, "TaiWuCunFuMie"));
		_dataArray.Add(new AchievementInfoItem(32, LocalStringManager.GetConfig("AchievementInfo_language", "Name_32"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_32"), "ui9_icon_achievement_TuiMoBiXie", "ui9_icon_achievement_TuiMoBiXie_small", EAchievementInfoType.Taiwu, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 108, 9 } }, 0u, isHidden: true, null));
		_dataArray.Add(new AchievementInfoItem(33, LocalStringManager.GetConfig("AchievementInfo_language", "Name_33"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_33"), "ui9_icon_achievement_HuanJianZhiYuan", "ui9_icon_achievement_HuanJianZhiYuan_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 180, 1 } }, 0u, isHidden: true, "HuanJianZhiYuan"));
		_dataArray.Add(new AchievementInfoItem(34, LocalStringManager.GetConfig("AchievementInfo_language", "Name_34"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_34"), "ui9_icon_achievement_ChuMoZhiShi", "ui9_icon_achievement_ChuMoZhiShi_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 181, 1 } }, 0u, isHidden: true, "ChuMoZhiShi"));
		_dataArray.Add(new AchievementInfoItem(35, LocalStringManager.GetConfig("AchievementInfo_language", "Name_35"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_35"), "ui9_icon_achievement_YouYuSuJian", "ui9_icon_achievement_YouYuSuJian_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 182, 1 } }, 0u, isHidden: true, "YouYuSuJian"));
		_dataArray.Add(new AchievementInfoItem(36, LocalStringManager.GetConfig("AchievementInfo_language", "Name_36"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_36"), "ui9_icon_achievement_KuXunShengRen", "ui9_icon_achievement_KuXunShengRen_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 183, 1 } }, 0u, isHidden: true, "KuXunShengRen"));
		_dataArray.Add(new AchievementInfoItem(37, LocalStringManager.GetConfig("AchievementInfo_language", "Name_37"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_37"), "ui9_icon_achievement_FenXinZhiBei", "ui9_icon_achievement_FenXinZhiBei_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 184, 1 } }, 0u, isHidden: true, "FenXinZhiBei"));
		_dataArray.Add(new AchievementInfoItem(38, LocalStringManager.GetConfig("AchievementInfo_language", "Name_38"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_38"), "ui9_icon_achievement_SheShenQiuDao", "ui9_icon_achievement_SheShenQiuDao_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 185, 1 } }, 0u, isHidden: true, "SheShenQiuDao"));
		_dataArray.Add(new AchievementInfoItem(39, LocalStringManager.GetConfig("AchievementInfo_language", "Name_39"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_39"), "ui9_icon_achievement_WuXiaZhiNian", "ui9_icon_achievement_WuXiaZhiNian_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 186, 1 } }, 0u, isHidden: true, "WuXiaZhiNian"));
		_dataArray.Add(new AchievementInfoItem(40, LocalStringManager.GetConfig("AchievementInfo_language", "Name_40"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_40"), "ui9_icon_achievement_BaiZhanBuZhe", "ui9_icon_achievement_BaiZhanBuZhe_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 187, 1 } }, 0u, isHidden: true, "BaiZhanBuZhe"));
		_dataArray.Add(new AchievementInfoItem(41, LocalStringManager.GetConfig("AchievementInfo_language", "Name_41"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_41"), "ui9_icon_achievement_EnYiNanQuan", "ui9_icon_achievement_EnYiNanQuan_small", EAchievementInfoType.Taiwu, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 188, 1 } }, 0u, isHidden: true, "EnYiNanQuan"));
		_dataArray.Add(new AchievementInfoItem(42, LocalStringManager.GetConfig("AchievementInfo_language", "Name_42"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_42"), "ui9_icon_achievement_ChanWuZhiDao", "ui9_icon_achievement_ChanWuZhiDao_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 189, 1 } }, 0u, isHidden: true, "ChanWuZhiDao"));
		_dataArray.Add(new AchievementInfoItem(43, LocalStringManager.GetConfig("AchievementInfo_language", "Name_43"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_43"), "ui9_icon_achievement_ChanWuZhiDaoXu", "ui9_icon_achievement_ChanWuZhiDaoXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 190, 1 } }, 0u, isHidden: true, "ChanWuZhiDaoXu"));
		_dataArray.Add(new AchievementInfoItem(44, LocalStringManager.GetConfig("AchievementInfo_language", "Name_44"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_44"), "ui9_icon_achievement_YinShiBaiYuan", "ui9_icon_achievement_YinShiBaiYuan_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 191, 1 } }, 0u, isHidden: true, "YinShiBaiYuan"));
		_dataArray.Add(new AchievementInfoItem(45, LocalStringManager.GetConfig("AchievementInfo_language", "Name_45"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_45"), "ui9_icon_achievement_YinShiBaiYuanXu", "ui9_icon_achievement_YinShiBaiYuanXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 192, 1 } }, 0u, isHidden: true, "YinShiBaiYuanXu"));
		_dataArray.Add(new AchievementInfoItem(46, LocalStringManager.GetConfig("AchievementInfo_language", "Name_46"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_46"), "ui9_icon_achievement_XuanXiaoBaiLu", "ui9_icon_achievement_XuanXiaoBaiLu_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 193, 1 } }, 0u, isHidden: true, "XuanXiaoBaiLu"));
		_dataArray.Add(new AchievementInfoItem(47, LocalStringManager.GetConfig("AchievementInfo_language", "Name_47"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_47"), "ui9_icon_achievement_XuanXiaoBaiLuXu", "ui9_icon_achievement_XuanXiaoBaiLuXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 194, 1 } }, 0u, isHidden: true, "XuanXiaoBaiLuXu"));
		_dataArray.Add(new AchievementInfoItem(48, LocalStringManager.GetConfig("AchievementInfo_language", "Name_48"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_48"), "ui9_icon_achievement_GuiShePanFu", "ui9_icon_achievement_GuiShePanFu_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 195, 1 } }, 0u, isHidden: true, "GuiShePanFu"));
		_dataArray.Add(new AchievementInfoItem(49, LocalStringManager.GetConfig("AchievementInfo_language", "Name_49"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_49"), "ui9_icon_achievement_GuiShePanFuXu", "ui9_icon_achievement_GuiShePanFuXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 196, 1 } }, 0u, isHidden: true, "GuiShePanFuXu"));
		_dataArray.Add(new AchievementInfoItem(50, LocalStringManager.GetConfig("AchievementInfo_language", "Name_50"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_50"), "ui9_icon_achievement_ShiLaoSanMo", "ui9_icon_achievement_ShiLaoSanMo_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 197, 1 } }, 0u, isHidden: true, "ShiLaoSanMo"));
		_dataArray.Add(new AchievementInfoItem(51, LocalStringManager.GetConfig("AchievementInfo_language", "Name_51"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_51"), "ui9_icon_achievement_ShiLaoSanMoXu", "ui9_icon_achievement_ShiLaoSanMoXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 198, 1 } }, 0u, isHidden: true, "ShiLaoSanMoXu"));
		_dataArray.Add(new AchievementInfoItem(52, LocalStringManager.GetConfig("AchievementInfo_language", "Name_52"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_52"), "ui9_icon_achievement_WenWuShuangQuan", "ui9_icon_achievement_WenWuShuangQuan_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 199, 1 } }, 0u, isHidden: true, "WenWuShuangQuan"));
		_dataArray.Add(new AchievementInfoItem(53, LocalStringManager.GetConfig("AchievementInfo_language", "Name_53"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_53"), "ui9_icon_achievement_WenWuShuangQuanXu", "ui9_icon_achievement_WenWuShuangQuanXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 200, 1 } }, 0u, isHidden: true, "WenWuShuangQuanXu"));
		_dataArray.Add(new AchievementInfoItem(54, LocalStringManager.GetConfig("AchievementInfo_language", "Name_54"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_54"), "ui9_icon_achievement_QingLangXianGe", "ui9_icon_achievement_QingLangXianGe_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 201, 1 } }, 0u, isHidden: true, "QingLangXianGe"));
		_dataArray.Add(new AchievementInfoItem(55, LocalStringManager.GetConfig("AchievementInfo_language", "Name_55"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_55"), "ui9_icon_achievement_QingLangXianGeXu", "ui9_icon_achievement_QingLangXianGeXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 202, 1 } }, 0u, isHidden: true, "QingLangXianGeXu"));
		_dataArray.Add(new AchievementInfoItem(56, LocalStringManager.GetConfig("AchievementInfo_language", "Name_56"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_56"), "ui9_icon_achievement_JingShuiDaoDian", "ui9_icon_achievement_JingShuiDaoDian_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 203, 1 } }, 0u, isHidden: true, "JingShuiDaoDian"));
		_dataArray.Add(new AchievementInfoItem(57, LocalStringManager.GetConfig("AchievementInfo_language", "Name_57"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_57"), "ui9_icon_achievement_JingShuiDaoDianXu", "ui9_icon_achievement_JingShuiDaoDianXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 204, 1 } }, 0u, isHidden: true, "JingShuiDaoDianXu"));
		_dataArray.Add(new AchievementInfoItem(58, LocalStringManager.GetConfig("AchievementInfo_language", "Name_58"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_58"), "ui9_icon_achievement_TongShengShiJian", "ui9_icon_achievement_TongShengShiJian_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 205, 1 } }, 0u, isHidden: true, "TongShengShiJian"));
		_dataArray.Add(new AchievementInfoItem(59, LocalStringManager.GetConfig("AchievementInfo_language", "Name_59"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_59"), "ui9_icon_achievement_TongShengShiJianXu", "ui9_icon_achievement_TongShengShiJianXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 206, 1 } }, 0u, isHidden: true, "TongShengShiJianXu"));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new AchievementInfoItem(60, LocalStringManager.GetConfig("AchievementInfo_language", "Name_60"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_60"), "ui9_icon_achievement_QiDuJueFang", "ui9_icon_achievement_QiDuJueFang_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 207, 1 } }, 0u, isHidden: true, "QiDuJueFang"));
		_dataArray.Add(new AchievementInfoItem(61, LocalStringManager.GetConfig("AchievementInfo_language", "Name_61"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_61"), "ui9_icon_achievement_QiDuJueFangXu", "ui9_icon_achievement_QiDuJueFangXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 208, 1 } }, 0u, isHidden: true, "QiDuJueFangXu"));
		_dataArray.Add(new AchievementInfoItem(62, LocalStringManager.GetConfig("AchievementInfo_language", "Name_62"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_62"), "ui9_icon_achievement_ZhenJingWuZi", "ui9_icon_achievement_ZhenJingWuZi_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 209, 1 } }, 0u, isHidden: true, "ZhenJingWuZi"));
		_dataArray.Add(new AchievementInfoItem(63, LocalStringManager.GetConfig("AchievementInfo_language", "Name_63"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_63"), "ui9_icon_achievement_ZhenJingWuZiXu", "ui9_icon_achievement_ZhenJingWuZiXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 210, 1 } }, 0u, isHidden: true, "ZhenJingWuZiXu"));
		_dataArray.Add(new AchievementInfoItem(64, LocalStringManager.GetConfig("AchievementInfo_language", "Name_64"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_64"), "ui9_icon_achievement_WuShengXinDu", "ui9_icon_achievement_WuShengXinDu_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 211, 1 } }, 0u, isHidden: true, "WuShengXinDu"));
		_dataArray.Add(new AchievementInfoItem(65, LocalStringManager.GetConfig("AchievementInfo_language", "Name_65"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_65"), "ui9_icon_achievement_WuShengXinDuXu", "ui9_icon_achievement_WuShengXinDuXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 212, 1 } }, 0u, isHidden: true, "WuShengXinDuXu"));
		_dataArray.Add(new AchievementInfoItem(66, LocalStringManager.GetConfig("AchievementInfo_language", "Name_66"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_66"), "ui9_icon_achievement_ShanEWuSheng", "ui9_icon_achievement_ShanEWuSheng_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 213, 1 } }, 0u, isHidden: true, "ShanEWuSheng"));
		_dataArray.Add(new AchievementInfoItem(67, LocalStringManager.GetConfig("AchievementInfo_language", "Name_67"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_67"), "ui9_icon_achievement_ShanEWuShengXu", "ui9_icon_achievement_ShanEWuShengXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 214, 1 } }, 0u, isHidden: true, "ShanEWuShengXu"));
		_dataArray.Add(new AchievementInfoItem(68, LocalStringManager.GetConfig("AchievementInfo_language", "Name_68"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_68"), "ui9_icon_achievement_FuLongHuaYu", "ui9_icon_achievement_FuLongHuaYu_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 215, 1 } }, 0u, isHidden: true, "FuLongHuaYu"));
		_dataArray.Add(new AchievementInfoItem(69, LocalStringManager.GetConfig("AchievementInfo_language", "Name_69"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_69"), "ui9_icon_achievement_FuLongHuaYuXu", "ui9_icon_achievement_FuLongHuaYuXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 216, 1 } }, 0u, isHidden: true, "FuLongHuaYuXu"));
		_dataArray.Add(new AchievementInfoItem(70, LocalStringManager.GetConfig("AchievementInfo_language", "Name_70"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_70"), "ui9_icon_achievement_XueZhongYiShu", "ui9_icon_achievement_XueZhongYiShu_small", EAchievementInfoType.Area, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 217, 1 } }, 0u, isHidden: true, "XueZhongYiShu"));
		_dataArray.Add(new AchievementInfoItem(71, LocalStringManager.GetConfig("AchievementInfo_language", "Name_71"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_71"), "ui9_icon_achievement_XueZhongYiShuXu", "ui9_icon_achievement_XueZhongYiShuXu_small", EAchievementInfoType.Area, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 218, 1 } }, 0u, isHidden: true, "XueZhongYiShuXu"));
		_dataArray.Add(new AchievementInfoItem(72, LocalStringManager.GetConfig("AchievementInfo_language", "Name_72"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_72"), "ui9_icon_achievement_HuiJuanXinPian", "ui9_icon_achievement_HuiJuanXinPian_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 59, 1 } }, 0u, isHidden: false, "HuiJuanXinPian"));
		_dataArray.Add(new AchievementInfoItem(73, LocalStringManager.GetConfig("AchievementInfo_language", "Name_73"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_73"), "ui9_icon_achievement_QianChenWangShi", "ui9_icon_achievement_QianChenWangShi_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 219, 1 } }, 0u, isHidden: false, "QianChenWangShi"));
		_dataArray.Add(new AchievementInfoItem(74, LocalStringManager.GetConfig("AchievementInfo_language", "Name_74"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_74"), "ui9_icon_achievement_JianZhongJiYi", "ui9_icon_achievement_JianZhongJiYi_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 60, 1 } }, 0u, isHidden: false, "JianZhongJiYi"));
		_dataArray.Add(new AchievementInfoItem(75, LocalStringManager.GetConfig("AchievementInfo_language", "Name_75"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_75"), "ui9_icon_achievement_ZaiXuQianYuan", "ui9_icon_achievement_ZaiXuQianYuan_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 61, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(76, LocalStringManager.GetConfig("AchievementInfo_language", "Name_76"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_76"), "ui9_icon_achievement_XuanYuZhiJie", "ui9_icon_achievement_XuanYuZhiJie_small", EAchievementInfoType.Character, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 16, 1 } }, 0u, isHidden: false, "XuanYuZhiJie"));
		_dataArray.Add(new AchievementInfoItem(77, LocalStringManager.GetConfig("AchievementInfo_language", "Name_77"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_77"), "ui9_icon_achievement_RenQiZiRan", "ui9_icon_achievement_RenQiZiRan_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 48, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(78, LocalStringManager.GetConfig("AchievementInfo_language", "Name_78"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_78"), "ui9_icon_achievement_FuZeMianChang", "ui9_icon_achievement_FuZeMianChang_small", EAchievementInfoType.Character, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 47, 10000 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(79, LocalStringManager.GetConfig("AchievementInfo_language", "Name_79"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_79"), "ui9_icon_achievement_YiMaiXiangCheng", "ui9_icon_achievement_YiMaiXiangCheng_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 49, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(80, LocalStringManager.GetConfig("AchievementInfo_language", "Name_80"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_80"), "ui9_icon_achievement_HouJiYouRen", "ui9_icon_achievement_HouJiYouRen_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 50, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(81, LocalStringManager.GetConfig("AchievementInfo_language", "Name_81"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_81"), "ui9_icon_achievement_XinHuoXiangChuan", "ui9_icon_achievement_XinHuoXiangChuan_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 51, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(82, LocalStringManager.GetConfig("AchievementInfo_language", "Name_82"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_82"), "ui9_icon_achievement_YiShiTongTian", "ui9_icon_achievement_YiShiTongTian_small", EAchievementInfoType.Character, 4, new List<EAchievementInfoRequirementType>
		{
			EAchievementInfoRequirementType.Equal,
			EAchievementInfoRequirementType.GreaterOrEqual
		}, new List<int[]>
		{
			new int[2] { 52, 0 },
			new int[2] { 148, 1 }
		}, 0u, isHidden: false, "YiShiTongTian"));
		_dataArray.Add(new AchievementInfoItem(83, LocalStringManager.GetConfig("AchievementInfo_language", "Name_83"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_83"), "ui9_icon_achievement_ShiShiXiangCheng", "ui9_icon_achievement_ShiShiXiangCheng_small", EAchievementInfoType.Character, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 52, 9 } }, 0u, isHidden: false, "ShiShiXiangCheng"));
		_dataArray.Add(new AchievementInfoItem(84, LocalStringManager.GetConfig("AchievementInfo_language", "Name_84"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_84"), "ui9_icon_achievement_ChongCaoJiuYe", "ui9_icon_achievement_ChongCaoJiuYe_small", EAchievementInfoType.Character, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 53, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(85, LocalStringManager.GetConfig("AchievementInfo_language", "Name_85"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_85"), "ui9_icon_achievement_FuYuHuMing", "ui9_icon_achievement_FuYuHuMing_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 220, 1 } }, 0u, isHidden: false, "FuYuHuMing"));
		_dataArray.Add(new AchievementInfoItem(86, LocalStringManager.GetConfig("AchievementInfo_language", "Name_86"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_86"), "ui9_icon_achievement_YouXiangJieChiKu", "ui9_icon_achievement_YouXiangJieChiKu_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 229, 1 } }, 0u, isHidden: false, "YouXiangJieChiKu"));
		_dataArray.Add(new AchievementInfoItem(87, LocalStringManager.GetConfig("AchievementInfo_language", "Name_87"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_87"), "ui9_icon_achievement_WuRenTuoWangLuo", "ui9_icon_achievement_WuRenTuoWangLuo_small", EAchievementInfoType.Character, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 229, 2 } }, 0u, isHidden: false, "WuRenTuoWangLuo"));
		_dataArray.Add(new AchievementInfoItem(88, LocalStringManager.GetConfig("AchievementInfo_language", "Name_88"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_88"), "ui9_icon_achievement_EGuanManYing", "ui9_icon_achievement_EGuanManYing_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.LessOrEqual }, new List<int[]> { new int[2] { 230, -75 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(89, LocalStringManager.GetConfig("AchievementInfo_language", "Name_89"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_89"), "ui9_icon_achievement_MingYangSiHai", "ui9_icon_achievement_MingYangSiHai_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 230, 75 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(90, LocalStringManager.GetConfig("AchievementInfo_language", "Name_90"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_90"), "ui9_icon_achievement_ShunXinErXing", "ui9_icon_achievement_ShunXinErXing_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 90, 1 } }, 0u, isHidden: false, "ShunXinErXing"));
		_dataArray.Add(new AchievementInfoItem(91, LocalStringManager.GetConfig("AchievementInfo_language", "Name_91"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_91"), "ui9_icon_achievement_WeiXinZhiJu", "ui9_icon_achievement_WeiXinZhiJu_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 91, 1 } }, 0u, isHidden: false, "WeiXinZhiJu"));
		_dataArray.Add(new AchievementInfoItem(92, LocalStringManager.GetConfig("AchievementInfo_language", "Name_92"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_92"), "ui9_icon_achievement_XiaoKouChangKai", "ui9_icon_achievement_XiaoKouChangKai_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 231, 90 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(93, LocalStringManager.GetConfig("AchievementInfo_language", "Name_93"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_93"), "ui9_icon_achievement_GanChangCunDuan", "ui9_icon_achievement_GanChangCunDuan_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.LessOrEqual }, new List<int[]> { new int[2] { 231, -90 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(94, LocalStringManager.GetConfig("AchievementInfo_language", "Name_94"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_94"), "ui9_icon_achievement_ChangShengJiuShi", "ui9_icon_achievement_ChangShengJiuShi_small", EAchievementInfoType.Character, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 232, 200 } }, 0u, isHidden: false, "ChangShengJiuShi"));
		_dataArray.Add(new AchievementInfoItem(95, LocalStringManager.GetConfig("AchievementInfo_language", "Name_95"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_95"), "ui9_icon_achievement_ZhiTongDaoHe", "ui9_icon_achievement_ZhiTongDaoHe_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 221, 1 } }, 0u, isHidden: false, "ZhiTongDaoHe"));
		_dataArray.Add(new AchievementInfoItem(96, LocalStringManager.GetConfig("AchievementInfo_language", "Name_96"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_96"), "ui9_icon_achievement_LianLiTongXin", "ui9_icon_achievement_LianLiTongXin_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 222, 1 } }, 0u, isHidden: false, "LianLiTongXin"));
		_dataArray.Add(new AchievementInfoItem(97, LocalStringManager.GetConfig("AchievementInfo_language", "Name_97"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_97"), "ui9_icon_achievement_GuGuZhuiDi", "ui9_icon_achievement_GuGuZhuiDi_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 233, 1 } }, 0u, isHidden: false, "GuGuZhuiDi"));
		_dataArray.Add(new AchievementInfoItem(98, LocalStringManager.GetConfig("AchievementInfo_language", "Name_98"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_98"), "ui9_icon_achievement_DuoZiDuoFu", "ui9_icon_achievement_DuoZiDuoFu_small", EAchievementInfoType.Character, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 233, 2 } }, 0u, isHidden: false, "DuoZiDuoFu"));
		_dataArray.Add(new AchievementInfoItem(99, LocalStringManager.GetConfig("AchievementInfo_language", "Name_99"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_99"), "ui9_icon_achievement_YiTaiJiangShi", "ui9_icon_achievement_YiTaiJiangShi_small", EAchievementInfoType.Character, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 223, 1 } }, 0u, isHidden: false, "YiTaiJiangShi"));
		_dataArray.Add(new AchievementInfoItem(100, LocalStringManager.GetConfig("AchievementInfo_language", "Name_100"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_100"), "ui9_icon_achievement_YuanGaoFeiZou", "ui9_icon_achievement_YuanGaoFeiZou_small", EAchievementInfoType.Character, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 224, 1 } }, 0u, isHidden: false, "YuanGaoFeiZou"));
		_dataArray.Add(new AchievementInfoItem(101, LocalStringManager.GetConfig("AchievementInfo_language", "Name_101"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_101"), "ui9_icon_achievement_JinLanZhiQi", "ui9_icon_achievement_JinLanZhiQi_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 225, 1 } }, 0u, isHidden: false, "JinLanZhiQi"));
		_dataArray.Add(new AchievementInfoItem(102, LocalStringManager.GetConfig("AchievementInfo_language", "Name_102"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_102"), "ui9_icon_achievement_PiaoLingBanSheng", "ui9_icon_achievement_PiaoLingBanSheng_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 226, 1 } }, 0u, isHidden: false, "PiaoLingBanSheng"));
		_dataArray.Add(new AchievementInfoItem(103, LocalStringManager.GetConfig("AchievementInfo_language", "Name_103"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_103"), "ui9_icon_achievement_SanShengShiShang", "ui9_icon_achievement_SanShengShiShang_small", EAchievementInfoType.Character, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 234, 1 } }, 0u, isHidden: false, "SanShengShiShang"));
		_dataArray.Add(new AchievementInfoItem(104, LocalStringManager.GetConfig("AchievementInfo_language", "Name_104"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_104"), "ui9_icon_achievement_DaoFanGangChang", "ui9_icon_achievement_DaoFanGangChang_small", EAchievementInfoType.Character, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 235, 1 } }, 0u, isHidden: false, "DaoFanGangChang"));
		_dataArray.Add(new AchievementInfoItem(105, LocalStringManager.GetConfig("AchievementInfo_language", "Name_105"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_105"), "ui9_icon_achievement_ZhongXingPengYue", "ui9_icon_achievement_ZhongXingPengYue_small", EAchievementInfoType.Character, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 1, 9 } }, 0u, isHidden: false, "ZhongXingPengYue"));
		_dataArray.Add(new AchievementInfoItem(106, LocalStringManager.GetConfig("AchievementInfo_language", "Name_106"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_106"), "ui9_icon_achievement_ZhongShiZhiDi", "ui9_icon_achievement_ZhongShiZhiDi_small", EAchievementInfoType.Character, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 2, 9 } }, 0u, isHidden: false, "ZhongShiZhiDi"));
		_dataArray.Add(new AchievementInfoItem(107, LocalStringManager.GetConfig("AchievementInfo_language", "Name_107"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_107"), "ui9_icon_achievement_ShiMingBiDa", "ui9_icon_achievement_ShiMingBiDa_small", EAchievementInfoType.Character, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 236, 1 } }, 0u, isHidden: false, "ShiMingBiDa"));
		_dataArray.Add(new AchievementInfoItem(108, LocalStringManager.GetConfig("AchievementInfo_language", "Name_108"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_108"), "ui9_icon_achievement_CunCaoBuSheng", "ui9_icon_achievement_CunCaoBuSheng_small", EAchievementInfoType.Character, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 11, 1 } }, 0u, isHidden: false, "CunCaoBuSheng"));
		_dataArray.Add(new AchievementInfoItem(109, LocalStringManager.GetConfig("AchievementInfo_language", "Name_109"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_109"), "ui9_icon_achievement_AiHenJiaoZhi", "ui9_icon_achievement_AiHenJiaoZhi_small", EAchievementInfoType.Character, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 3, 1 } }, 0u, isHidden: false, "AiHenJiaoZhi"));
		_dataArray.Add(new AchievementInfoItem(110, LocalStringManager.GetConfig("AchievementInfo_language", "Name_110"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_110"), "ui9_icon_achievement_JiangHuBaiXiaoSheng", "ui9_icon_achievement_JiangHuBaiXiaoSheng_small", EAchievementInfoType.Character, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 4, 99 } }, 0u, isHidden: false, "JiangHuBaiXiaoSheng"));
		_dataArray.Add(new AchievementInfoItem(111, LocalStringManager.GetConfig("AchievementInfo_language", "Name_111"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_111"), "ui9_icon_achievement_DianDaoWeiZhi", "ui9_icon_achievement_DianDaoWeiZhi_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 109, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(112, LocalStringManager.GetConfig("AchievementInfo_language", "Name_112"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_112"), "ui9_icon_achievement_ShenJingBaiZhan", "ui9_icon_achievement_ShenJingBaiZhan_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 110, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(113, LocalStringManager.GetConfig("AchievementInfo_language", "Name_113"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_113"), "ui9_icon_achievement_YingDuiZiRu", "ui9_icon_achievement_YingDuiZiRu_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 111, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(114, LocalStringManager.GetConfig("AchievementInfo_language", "Name_114"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_114"), "ui9_icon_achievement_BuSiBuXiu", "ui9_icon_achievement_BuSiBuXiu_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 112, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(115, LocalStringManager.GetConfig("AchievementInfo_language", "Name_115"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_115"), "ui9_icon_achievement_LiangYanMeiYi", "ui9_icon_achievement_LiangYanMeiYi_small", EAchievementInfoType.Character, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 227, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(116, LocalStringManager.GetConfig("AchievementInfo_language", "Name_116"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_116"), "ui9_icon_achievement_EYuShangRen", "ui9_icon_achievement_EYuShangRen_small", EAchievementInfoType.Character, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 228, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(117, LocalStringManager.GetConfig("AchievementInfo_language", "Name_117"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_117"), "ui9_icon_achievement_WuHuaBaMen", "ui9_icon_achievement_WuHuaBaMen_small", EAchievementInfoType.Combat, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 113, 1 } }, 0u, isHidden: false, "WuHuaBaMen"));
		_dataArray.Add(new AchievementInfoItem(118, LocalStringManager.GetConfig("AchievementInfo_language", "Name_118"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_118"), "ui9_icon_achievement_ZouWeiShangJi", "ui9_icon_achievement_ZouWeiShangJi_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 114, 1 } }, 0u, isHidden: false, "ZouWeiShangJi"));
		_dataArray.Add(new AchievementInfoItem(119, LocalStringManager.GetConfig("AchievementInfo_language", "Name_119"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_119"), "ui9_icon_achievement_GanBaiXiaFeng", "ui9_icon_achievement_GanBaiXiaFeng_small", EAchievementInfoType.Combat, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 115, 1 } }, 0u, isHidden: false, "GanBaiXiaFeng"));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new AchievementInfoItem(120, LocalStringManager.GetConfig("AchievementInfo_language", "Name_120"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_120"), "ui9_icon_achievement_WuHuaDaBang", "ui9_icon_achievement_WuHuaDaBang_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 116, 1 } }, 0u, isHidden: false, "WuHuaDaBang"));
		_dataArray.Add(new AchievementInfoItem(121, LocalStringManager.GetConfig("AchievementInfo_language", "Name_121"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_121"), "ui9_icon_achievement_FuYuJiuE", "ui9_icon_achievement_FuYuJiuE_small", EAchievementInfoType.Combat, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 117, 1 } }, 0u, isHidden: false, "FuYuJiuE"));
		_dataArray.Add(new AchievementInfoItem(122, LocalStringManager.GetConfig("AchievementInfo_language", "Name_122"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_122"), "ui9_icon_achievement_ChuMoWeiDao", "ui9_icon_achievement_ChuMoWeiDao_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 118, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(123, LocalStringManager.GetConfig("AchievementInfo_language", "Name_123"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_123"), "ui9_icon_achievement_ZaiZaoZhiEn", "ui9_icon_achievement_ZaiZaoZhiEn_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 117, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(124, LocalStringManager.GetConfig("AchievementInfo_language", "Name_124"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_124"), "ui9_icon_achievement_ZhangYiXingXia", "ui9_icon_achievement_ZhangYiXingXia_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 119, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(125, LocalStringManager.GetConfig("AchievementInfo_language", "Name_125"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_125"), "ui9_icon_achievement_NiWoZheWang", "ui9_icon_achievement_NiWoZheWang_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 120, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(126, LocalStringManager.GetConfig("AchievementInfo_language", "Name_126"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_126"), "ui9_icon_achievement_XiangLongFuHu", "ui9_icon_achievement_XiangLongFuHu_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 121, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(127, LocalStringManager.GetConfig("AchievementInfo_language", "Name_127"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_127"), "ui9_icon_achievement_ZhanZhuanTengNuo", "ui9_icon_achievement_ZhanZhuanTengNuo_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 122, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(128, LocalStringManager.GetConfig("AchievementInfo_language", "Name_128"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_128"), "ui9_icon_achievement_BuDongRuShan", "ui9_icon_achievement_BuDongRuShan_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 123, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(129, LocalStringManager.GetConfig("AchievementInfo_language", "Name_129"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_129"), "ui9_icon_achievement_BianHuaMoCe", "ui9_icon_achievement_BianHuaMoCe_small", EAchievementInfoType.Combat, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 124, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(130, LocalStringManager.GetConfig("AchievementInfo_language", "Name_130"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_130"), "ui9_icon_achievement_QiXinXieLi", "ui9_icon_achievement_QiXinXieLi_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 125, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(131, LocalStringManager.GetConfig("AchievementInfo_language", "Name_131"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_131"), "ui9_icon_achievement_HuoQiXiaoQiang", "ui9_icon_achievement_HuoQiXiaoQiang_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 126, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(132, LocalStringManager.GetConfig("AchievementInfo_language", "Name_132"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_132"), "ui9_icon_achievement_TaQiangYouTaQiang", "ui9_icon_achievement_TaQiangYouTaQiang_small", EAchievementInfoType.Combat, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 127, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(133, LocalStringManager.GetConfig("AchievementInfo_language", "Name_133"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_133"), "ui9_icon_achievement_PaiShanDaoHai", "ui9_icon_achievement_PaiShanDaoHai_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 128, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(134, LocalStringManager.GetConfig("AchievementInfo_language", "Name_134"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_134"), "ui9_icon_achievement_DongJinLieShi", "ui9_icon_achievement_DongJinLieShi_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 129, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(135, LocalStringManager.GetConfig("AchievementInfo_language", "Name_135"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_135"), "ui9_icon_achievement_TiXingTaYue", "ui9_icon_achievement_TiXingTaYue_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 130, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(136, LocalStringManager.GetConfig("AchievementInfo_language", "Name_136"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_136"), "ui9_icon_achievement_FeiHuaZhaiYe", "ui9_icon_achievement_FeiHuaZhaiYe_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 131, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(137, LocalStringManager.GetConfig("AchievementInfo_language", "Name_137"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_137"), "ui9_icon_achievement_JianQiZongHeng", "ui9_icon_achievement_JianQiZongHeng_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 132, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(138, LocalStringManager.GetConfig("AchievementInfo_language", "Name_138"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_138"), "ui9_icon_achievement_PiBoZhanLang", "ui9_icon_achievement_PiBoZhanLang_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 133, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(139, LocalStringManager.GetConfig("AchievementInfo_language", "Name_139"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_139"), "ui9_icon_achievement_CunChangCunQiang", "ui9_icon_achievement_CunChangCunQiang_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 134, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(140, LocalStringManager.GetConfig("AchievementInfo_language", "Name_140"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_140"), "ui9_icon_achievement_QiMenYiShu", "ui9_icon_achievement_QiMenYiShu_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 135, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(141, LocalStringManager.GetConfig("AchievementInfo_language", "Name_141"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_141"), "ui9_icon_achievement_ShiRuoYouLong", "ui9_icon_achievement_ShiRuoYouLong_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 136, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(142, LocalStringManager.GetConfig("AchievementInfo_language", "Name_142"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_142"), "ui9_icon_achievement_BaiBuChuanYang", "ui9_icon_achievement_BaiBuChuanYang_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 137, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(143, LocalStringManager.GetConfig("AchievementInfo_language", "Name_143"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_143"), "ui9_icon_achievement_MoYinGuanEr", "ui9_icon_achievement_MoYinGuanEr_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 138, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(144, LocalStringManager.GetConfig("AchievementInfo_language", "Name_144"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_144"), "ui9_icon_achievement_ShiBuKeDang", "ui9_icon_achievement_ShiBuKeDang_small", EAchievementInfoType.Combat, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 139, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(145, LocalStringManager.GetConfig("AchievementInfo_language", "Name_145"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_145"), "ui9_icon_achievement_BieJiaoGongFu", "ui9_icon_achievement_BieJiaoGongFu_small", EAchievementInfoType.Combat, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 140, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(146, LocalStringManager.GetConfig("AchievementInfo_language", "Name_146"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_146"), "ui9_icon_achievement_FenJinCuoGu", "ui9_icon_achievement_FenJinCuoGu_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 141, 1 } }, 0u, isHidden: false, "FenJinCuoGu"));
		_dataArray.Add(new AchievementInfoItem(147, LocalStringManager.GetConfig("AchievementInfo_language", "Name_147"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_147"), "ui9_icon_achievement_ShenCanZhiJian", "ui9_icon_achievement_ShenCanZhiJian_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 142, 1 } }, 0u, isHidden: false, "ShenCanZhiJian"));
		_dataArray.Add(new AchievementInfoItem(148, LocalStringManager.GetConfig("AchievementInfo_language", "Name_148"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_148"), "ui9_icon_achievement_DuQiGongXin", "ui9_icon_achievement_DuQiGongXin_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 143, 9 } }, 0u, isHidden: false, "DuQiGongXin"));
		_dataArray.Add(new AchievementInfoItem(149, LocalStringManager.GetConfig("AchievementInfo_language", "Name_149"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_149"), "ui9_icon_achievement_QiCaiLingLongXin", "ui9_icon_achievement_QiCaiLingLongXin_small", EAchievementInfoType.Combat, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 237, 6 } }, 0u, isHidden: false, "QiCaiLingLongXin"));
		_dataArray.Add(new AchievementInfoItem(150, LocalStringManager.GetConfig("AchievementInfo_language", "Name_150"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_150"), "ui9_icon_achievement_QiChongDouNiu", "ui9_icon_achievement_QiChongDouNiu_small", EAchievementInfoType.Combat, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 144, 1 } }, 0u, isHidden: false, "QiChongDouNiu"));
		_dataArray.Add(new AchievementInfoItem(151, LocalStringManager.GetConfig("AchievementInfo_language", "Name_151"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_151"), "ui9_icon_achievement_QiSanGongXiao", "ui9_icon_achievement_QiSanGongXiao_small", EAchievementInfoType.Combat, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 145, 1 } }, 0u, isHidden: false, "QiSanGongXiao"));
		_dataArray.Add(new AchievementInfoItem(152, LocalStringManager.GetConfig("AchievementInfo_language", "Name_152"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_152"), "ui9_icon_achievement_QiongZhuiMengDa", "ui9_icon_achievement_QiongZhuiMengDa_small", EAchievementInfoType.Combat, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 146, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(153, LocalStringManager.GetConfig("AchievementInfo_language", "Name_153"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_153"), "ui9_icon_achievement_XinYouSuoXiang", "ui9_icon_achievement_XinYouSuoXiang_small", EAchievementInfoType.Profession, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 62, 1 } }, 0u, isHidden: false, "XinYouSuoXiang"));
		_dataArray.Add(new AchievementInfoItem(154, LocalStringManager.GetConfig("AchievementInfo_language", "Name_154"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_154"), "ui9_icon_achievement_ZhiYouSuoCheng", "ui9_icon_achievement_ZhiYouSuoCheng_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 63, 1 } }, 0u, isHidden: false, "ZhiYouSuoCheng"));
		_dataArray.Add(new AchievementInfoItem(155, LocalStringManager.GetConfig("AchievementInfo_language", "Name_155"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_155"), "ui9_icon_achievement_ShanZhongGaoShi", "ui9_icon_achievement_ShanZhongGaoShi_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 64, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(156, LocalStringManager.GetConfig("AchievementInfo_language", "Name_156"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_156"), "ui9_icon_achievement_BaiShouZhiWang", "ui9_icon_achievement_BaiShouZhiWang_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 65, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(157, LocalStringManager.GetConfig("AchievementInfo_language", "Name_157"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_157"), "ui9_icon_achievement_QiaoDuoTianGong", "ui9_icon_achievement_QiaoDuoTianGong_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 66, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(158, LocalStringManager.GetConfig("AchievementInfo_language", "Name_158"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_158"), "ui9_icon_achievement_YiHuBaiYing", "ui9_icon_achievement_YiHuBaiYing_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 67, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(159, LocalStringManager.GetConfig("AchievementInfo_language", "Name_159"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_159"), "ui9_icon_achievement_CaiGaoBaDou", "ui9_icon_achievement_CaiGaoBaDou_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 68, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(160, LocalStringManager.GetConfig("AchievementInfo_language", "Name_160"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_160"), "ui9_icon_achievement_DaoFaZiRan", "ui9_icon_achievement_DaoFaZiRan_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 69, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(161, LocalStringManager.GetConfig("AchievementInfo_language", "Name_161"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_161"), "ui9_icon_achievement_GongDeYuanMan", "ui9_icon_achievement_GongDeYuanMan_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 70, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(162, LocalStringManager.GetConfig("AchievementInfo_language", "Name_162"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_162"), "ui9_icon_achievement_JiuZhongHaoJie", "ui9_icon_achievement_JiuZhongHaoJie_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 71, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(163, LocalStringManager.GetConfig("AchievementInfo_language", "Name_163"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_163"), "ui9_icon_achievement_ZhongMingDingShi", "ui9_icon_achievement_ZhongMingDingShi_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 72, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(164, LocalStringManager.GetConfig("AchievementInfo_language", "Name_164"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_164"), "ui9_icon_achievement_YouXiRenJian", "ui9_icon_achievement_YouXiRenJian_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 73, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(165, LocalStringManager.GetConfig("AchievementInfo_language", "Name_165"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_165"), "ui9_icon_achievement_BuYiZiShi", "ui9_icon_achievement_BuYiZiShi_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 74, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(166, LocalStringManager.GetConfig("AchievementInfo_language", "Name_166"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_166"), "ui9_icon_achievement_XingBianTianYa", "ui9_icon_achievement_XingBianTianYa_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 75, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(167, LocalStringManager.GetConfig("AchievementInfo_language", "Name_167"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_167"), "ui9_icon_achievement_MingXinJianXing", "ui9_icon_achievement_MingXinJianXing_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 76, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(168, LocalStringManager.GetConfig("AchievementInfo_language", "Name_168"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_168"), "ui9_icon_achievement_MiaoShouHuiChun", "ui9_icon_achievement_MiaoShouHuiChun_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 77, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(169, LocalStringManager.GetConfig("AchievementInfo_language", "Name_169"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_169"), "ui9_icon_achievement_HuaWaiXiaoYao", "ui9_icon_achievement_HuaWaiXiaoYao_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 78, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(170, LocalStringManager.GetConfig("AchievementInfo_language", "Name_170"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_170"), "ui9_icon_achievement_HuiJinRuTu", "ui9_icon_achievement_HuiJinRuTu_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 79, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(171, LocalStringManager.GetConfig("AchievementInfo_language", "Name_171"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_171"), "ui9_icon_achievement_FengLiuYaShi", "ui9_icon_achievement_FengLiuYaShi_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 80, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(172, LocalStringManager.GetConfig("AchievementInfo_language", "Name_172"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_172"), "ui9_icon_achievement_WanMinLaiChao", "ui9_icon_achievement_WanMinLaiChao_small", EAchievementInfoType.Profession, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 81, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(173, LocalStringManager.GetConfig("AchievementInfo_language", "Name_173"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_173"), "ui9_icon_achievement_ZhuYeJingTong", "ui9_icon_achievement_ZhuYeJingTong_small", EAchievementInfoType.Profession, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 82, 1 } }, 0u, isHidden: false, "ZhuYeJingTong"));
		_dataArray.Add(new AchievementInfoItem(174, LocalStringManager.GetConfig("AchievementInfo_language", "Name_174"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_174"), "ui9_icon_achievement_ChuKuiMenJing", "ui9_icon_achievement_ChuKuiMenJing_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 238, 1 } }, 0u, isHidden: false, "ChuKuiMenJing"));
		_dataArray.Add(new AchievementInfoItem(175, LocalStringManager.GetConfig("AchievementInfo_language", "Name_175"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_175"), "ui9_icon_achievement_ShuYeZhuanGong", "ui9_icon_achievement_ShuYeZhuanGong_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 239, 1 } }, 0u, isHidden: false, "ShuYeZhuanGong"));
		_dataArray.Add(new AchievementInfoItem(176, LocalStringManager.GetConfig("AchievementInfo_language", "Name_176"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_176"), "ui9_icon_achievement_YinLvDaCheng", "ui9_icon_achievement_YinLvDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 240, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(177, LocalStringManager.GetConfig("AchievementInfo_language", "Name_177"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_177"), "ui9_icon_achievement_YiQiDaCheng", "ui9_icon_achievement_YiQiDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 241, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(178, LocalStringManager.GetConfig("AchievementInfo_language", "Name_178"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_178"), "ui9_icon_achievement_ShiShuDaCheng", "ui9_icon_achievement_ShiShuDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 242, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(179, LocalStringManager.GetConfig("AchievementInfo_language", "Name_179"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_179"), "ui9_icon_achievement_HuiHuaDaCheng", "ui9_icon_achievement_HuiHuaDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 243, 9 } }, 0u, isHidden: false, null));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new AchievementInfoItem(180, LocalStringManager.GetConfig("AchievementInfo_language", "Name_180"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_180"), "ui9_icon_achievement_ShuShuDaCheng", "ui9_icon_achievement_ShuShuDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 244, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(181, LocalStringManager.GetConfig("AchievementInfo_language", "Name_181"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_181"), "ui9_icon_achievement_PinJianDaCheng", "ui9_icon_achievement_PinJianDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 245, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(182, LocalStringManager.GetConfig("AchievementInfo_language", "Name_182"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_182"), "ui9_icon_achievement_DuanZaoDaCheng", "ui9_icon_achievement_DuanZaoDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 246, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(183, LocalStringManager.GetConfig("AchievementInfo_language", "Name_183"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_183"), "ui9_icon_achievement_ZhiMuDaCheng", "ui9_icon_achievement_ZhiMuDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 247, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(184, LocalStringManager.GetConfig("AchievementInfo_language", "Name_184"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_184"), "ui9_icon_achievement_YiShuDaCheng", "ui9_icon_achievement_YiShuDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 248, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(185, LocalStringManager.GetConfig("AchievementInfo_language", "Name_185"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_185"), "ui9_icon_achievement_DuShuDaCheng", "ui9_icon_achievement_DuShuDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 249, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(186, LocalStringManager.GetConfig("AchievementInfo_language", "Name_186"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_186"), "ui9_icon_achievement_ZhiJinDaCheng", "ui9_icon_achievement_ZhiJinDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 250, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(187, LocalStringManager.GetConfig("AchievementInfo_language", "Name_187"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_187"), "ui9_icon_achievement_QiaoJiangDaCheng", "ui9_icon_achievement_QiaoJiangDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 251, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(188, LocalStringManager.GetConfig("AchievementInfo_language", "Name_188"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_188"), "ui9_icon_achievement_DaoFaDaCheng", "ui9_icon_achievement_DaoFaDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 252, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(189, LocalStringManager.GetConfig("AchievementInfo_language", "Name_189"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_189"), "ui9_icon_achievement_FoXueDaCheng", "ui9_icon_achievement_FoXueDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 253, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(190, LocalStringManager.GetConfig("AchievementInfo_language", "Name_190"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_190"), "ui9_icon_achievement_ChuYiDaCheng", "ui9_icon_achievement_ChuYiDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 254, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(191, LocalStringManager.GetConfig("AchievementInfo_language", "Name_191"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_191"), "ui9_icon_achievement_ZaXueDaCheng", "ui9_icon_achievement_ZaXueDaCheng_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 255, 9 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(192, LocalStringManager.GetConfig("AchievementInfo_language", "Name_192"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_192"), "ui9_icon_achievement_XueJiuTianRen", "ui9_icon_achievement_XueJiuTianRen_small", EAchievementInfoType.LifeSkill, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 238, 144 } }, 0u, isHidden: false, "XueJiuTianRen"));
		_dataArray.Add(new AchievementInfoItem(193, LocalStringManager.GetConfig("AchievementInfo_language", "Name_193"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_193"), "ui9_icon_achievement_JiGaoYiChou", "ui9_icon_achievement_JiGaoYiChou_small", EAchievementInfoType.LifeSkill, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 5, 1 } }, 0u, isHidden: false, "JiGaoYiChou"));
		_dataArray.Add(new AchievementInfoItem(194, LocalStringManager.GetConfig("AchievementInfo_language", "Name_194"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_194"), "ui9_icon_achievement_SheCanLianHua", "ui9_icon_achievement_SheCanLianHua_small", EAchievementInfoType.LifeSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 5, 99 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(195, LocalStringManager.GetConfig("AchievementInfo_language", "Name_195"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_195"), "ui9_icon_achievement_ChuXueZhaLian", "ui9_icon_achievement_ChuXueZhaLian_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 256, 1 } }, 0u, isHidden: false, "ChuXueZhaLian"));
		_dataArray.Add(new AchievementInfoItem(196, LocalStringManager.GetConfig("AchievementInfo_language", "Name_196"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_196"), "ui9_icon_achievement_JinDeZhenChuan", "ui9_icon_achievement_JinDeZhenChuan_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 257, 1 } }, 0u, isHidden: false, "JinDeZhenChuan"));
		_dataArray.Add(new AchievementInfoItem(197, LocalStringManager.GetConfig("AchievementInfo_language", "Name_197"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_197"), "ui9_icon_achievement_ShaoLinJueXue", "ui9_icon_achievement_ShaoLinJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 258, 47 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(198, LocalStringManager.GetConfig("AchievementInfo_language", "Name_198"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_198"), "ui9_icon_achievement_EMeiJueXue", "ui9_icon_achievement_EMeiJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 259, 55 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(199, LocalStringManager.GetConfig("AchievementInfo_language", "Name_199"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_199"), "ui9_icon_achievement_BaiHuaJueXue", "ui9_icon_achievement_BaiHuaJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 260, 47 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(200, LocalStringManager.GetConfig("AchievementInfo_language", "Name_200"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_200"), "ui9_icon_achievement_WuDangJueXue", "ui9_icon_achievement_WuDangJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 261, 50 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(201, LocalStringManager.GetConfig("AchievementInfo_language", "Name_201"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_201"), "ui9_icon_achievement_YuanShanJueXue", "ui9_icon_achievement_YuanShanJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 262, 41 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(202, LocalStringManager.GetConfig("AchievementInfo_language", "Name_202"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_202"), "ui9_icon_achievement_ShiXiangJueXue", "ui9_icon_achievement_ShiXiangJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 263, 42 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(203, LocalStringManager.GetConfig("AchievementInfo_language", "Name_203"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_203"), "ui9_icon_achievement_RanShanJueXue", "ui9_icon_achievement_RanShanJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 264, 49 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(204, LocalStringManager.GetConfig("AchievementInfo_language", "Name_204"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_204"), "ui9_icon_achievement_XuanNvJueXue", "ui9_icon_achievement_XuanNvJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 265, 49 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(205, LocalStringManager.GetConfig("AchievementInfo_language", "Name_205"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_205"), "ui9_icon_achievement_ZhuJianJueXue", "ui9_icon_achievement_ZhuJianJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 266, 53 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(206, LocalStringManager.GetConfig("AchievementInfo_language", "Name_206"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_206"), "ui9_icon_achievement_KongSangJueXue", "ui9_icon_achievement_KongSangJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 267, 48 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(207, LocalStringManager.GetConfig("AchievementInfo_language", "Name_207"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_207"), "ui9_icon_achievement_JinGangJueXue", "ui9_icon_achievement_JinGangJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 268, 46 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(208, LocalStringManager.GetConfig("AchievementInfo_language", "Name_208"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_208"), "ui9_icon_achievement_WuXianJueXue", "ui9_icon_achievement_WuXianJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 269, 56 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(209, LocalStringManager.GetConfig("AchievementInfo_language", "Name_209"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_209"), "ui9_icon_achievement_JieQingJueXue", "ui9_icon_achievement_JieQingJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 270, 49 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(210, LocalStringManager.GetConfig("AchievementInfo_language", "Name_210"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_210"), "ui9_icon_achievement_FuLongJueXue", "ui9_icon_achievement_FuLongJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 271, 45 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(211, LocalStringManager.GetConfig("AchievementInfo_language", "Name_211"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_211"), "ui9_icon_achievement_XueHaoJueXue", "ui9_icon_achievement_XueHaoJueXue_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 272, 53 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(212, LocalStringManager.GetConfig("AchievementInfo_language", "Name_212"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_212"), "ui9_icon_achievement_GongCanZaoHua", "ui9_icon_achievement_GongCanZaoHua_small", EAchievementInfoType.CombatSkill, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 256, 734 } }, 0u, isHidden: false, "GongCanZaoHua"));
		_dataArray.Add(new AchievementInfoItem(213, LocalStringManager.GetConfig("AchievementInfo_language", "Name_213"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_213"), "ui9_icon_achievement_ShaoLinMengShi", "ui9_icon_achievement_ShaoLinMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 92, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(214, LocalStringManager.GetConfig("AchievementInfo_language", "Name_214"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_214"), "ui9_icon_achievement_EMeiMengShi", "ui9_icon_achievement_EMeiMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 93, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(215, LocalStringManager.GetConfig("AchievementInfo_language", "Name_215"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_215"), "ui9_icon_achievement_BaiHuaMengShi", "ui9_icon_achievement_BaiHuaMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 94, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(216, LocalStringManager.GetConfig("AchievementInfo_language", "Name_216"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_216"), "ui9_icon_achievement_WuDangMengShi", "ui9_icon_achievement_WuDangMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 95, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(217, LocalStringManager.GetConfig("AchievementInfo_language", "Name_217"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_217"), "ui9_icon_achievement_YuanShanMengShi", "ui9_icon_achievement_YuanShanMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 96, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(218, LocalStringManager.GetConfig("AchievementInfo_language", "Name_218"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_218"), "ui9_icon_achievement_ShiXiangMengShi", "ui9_icon_achievement_ShiXiangMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 97, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(219, LocalStringManager.GetConfig("AchievementInfo_language", "Name_219"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_219"), "ui9_icon_achievement_RanShanMengShi", "ui9_icon_achievement_RanShanMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 98, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(220, LocalStringManager.GetConfig("AchievementInfo_language", "Name_220"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_220"), "ui9_icon_achievement_XuanNvMengShi", "ui9_icon_achievement_XuanNvMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 99, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(221, LocalStringManager.GetConfig("AchievementInfo_language", "Name_221"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_221"), "ui9_icon_achievement_ZhuJianMengShi", "ui9_icon_achievement_ZhuJianMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 100, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(222, LocalStringManager.GetConfig("AchievementInfo_language", "Name_222"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_222"), "ui9_icon_achievement_KongSangMengShi", "ui9_icon_achievement_KongSangMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 101, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(223, LocalStringManager.GetConfig("AchievementInfo_language", "Name_223"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_223"), "ui9_icon_achievement_JinGangMengShi", "ui9_icon_achievement_JinGangMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 102, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(224, LocalStringManager.GetConfig("AchievementInfo_language", "Name_224"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_224"), "ui9_icon_achievement_WuXianMengShi", "ui9_icon_achievement_WuXianMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 103, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(225, LocalStringManager.GetConfig("AchievementInfo_language", "Name_225"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_225"), "ui9_icon_achievement_JieQingMengShi", "ui9_icon_achievement_JieQingMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 104, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(226, LocalStringManager.GetConfig("AchievementInfo_language", "Name_226"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_226"), "ui9_icon_achievement_FuLongMengShi", "ui9_icon_achievement_FuLongMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 105, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(227, LocalStringManager.GetConfig("AchievementInfo_language", "Name_227"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_227"), "ui9_icon_achievement_XueHaoMengShi", "ui9_icon_achievement_XueHaoMengShi_small", EAchievementInfoType.CombatSkill, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 106, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(228, LocalStringManager.GetConfig("AchievementInfo_language", "Name_228"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_228"), "ui9_icon_achievement_WuJianBuCui", "ui9_icon_achievement_WuJianBuCui_small", EAchievementInfoType.CombatSkill, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 83, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(229, LocalStringManager.GetConfig("AchievementInfo_language", "Name_229"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_229"), "ui9_icon_achievement_BenYiJueChen", "ui9_icon_achievement_BenYiJueChen_small", EAchievementInfoType.CombatSkill, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 84, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(230, LocalStringManager.GetConfig("AchievementInfo_language", "Name_230"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_230"), "ui9_icon_achievement_GuRuoJinTang", "ui9_icon_achievement_GuRuoJinTang_small", EAchievementInfoType.CombatSkill, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 85, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(231, LocalStringManager.GetConfig("AchievementInfo_language", "Name_231"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_231"), "ui9_icon_achievement_QiJingBaMai", "ui9_icon_achievement_QiJingBaMai_small", EAchievementInfoType.CombatSkill, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 86, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(232, LocalStringManager.GetConfig("AchievementInfo_language", "Name_232"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_232"), "ui9_icon_achievement_ChongPoXuanGuan", "ui9_icon_achievement_ChongPoXuanGuan_small", EAchievementInfoType.CombatSkill, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 8, 1 } }, 0u, isHidden: false, "ChongPoXuanGuan"));
		_dataArray.Add(new AchievementInfoItem(233, LocalStringManager.GetConfig("AchievementInfo_language", "Name_233"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_233"), "ui9_icon_achievement_ZouHuoRuMo", "ui9_icon_achievement_ZouHuoRuMo_small", EAchievementInfoType.CombatSkill, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 9, 1 } }, 0u, isHidden: false, "ZouHuoRuMo"));
		_dataArray.Add(new AchievementInfoItem(234, LocalStringManager.GetConfig("AchievementInfo_language", "Name_234"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_234"), "ui9_icon_achievement_ShuNengShengQiao", "ui9_icon_achievement_ShuNengShengQiao_small", EAchievementInfoType.CombatSkill, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 147, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(235, LocalStringManager.GetConfig("AchievementInfo_language", "Name_235"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_235"), "ui9_icon_achievement_HunXinWuZi", "ui9_icon_achievement_HunXinWuZi_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 273, 1 } }, 0u, isHidden: false, "HunXinWuZi"));
		_dataArray.Add(new AchievementInfoItem(236, LocalStringManager.GetConfig("AchievementInfo_language", "Name_236"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_236"), "ui9_icon_achievement_BaiYiXingHua", "ui9_icon_achievement_BaiYiXingHua_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 274, 1 } }, 0u, isHidden: false, "BaiYiXingHua"));
		_dataArray.Add(new AchievementInfoItem(237, LocalStringManager.GetConfig("AchievementInfo_language", "Name_237"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_237"), "ui9_icon_achievement_DaQuanQianFa", "ui9_icon_achievement_DaQuanQianFa_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 275, 1 } }, 0u, isHidden: false, "DaQuanQianFa"));
		_dataArray.Add(new AchievementInfoItem(238, LocalStringManager.GetConfig("AchievementInfo_language", "Name_238"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_238"), "ui9_icon_achievement_XiangLongYanHua", "ui9_icon_achievement_XiangLongYanHua_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 276, 1 } }, 0u, isHidden: false, "XiangLongYanHua"));
		_dataArray.Add(new AchievementInfoItem(239, LocalStringManager.GetConfig("AchievementInfo_language", "Name_239"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_239"), "ui9_icon_achievement_XinGuanCanJian", "ui9_icon_achievement_XinGuanCanJian_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 277, 1 } }, 0u, isHidden: false, "XinGuanCanJian"));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new AchievementInfoItem(240, LocalStringManager.GetConfig("AchievementInfo_language", "Name_240"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_240"), "ui9_icon_achievement_BaYanZhiBao", "ui9_icon_achievement_BaYanZhiBao_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 278, 1 } }, 0u, isHidden: false, "BaYanZhiBao"));
		_dataArray.Add(new AchievementInfoItem(241, LocalStringManager.GetConfig("AchievementInfo_language", "Name_241"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_241"), "ui9_icon_achievement_HuaYingQiGong", "ui9_icon_achievement_HuaYingQiGong_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 279, 1 } }, 0u, isHidden: false, "HuaYingQiGong"));
		_dataArray.Add(new AchievementInfoItem(242, LocalStringManager.GetConfig("AchievementInfo_language", "Name_242"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_242"), "ui9_icon_achievement_WuMingShenJian", "ui9_icon_achievement_WuMingShenJian_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 280, 1 } }, 0u, isHidden: false, "WuMingShenJian"));
		_dataArray.Add(new AchievementInfoItem(243, LocalStringManager.GetConfig("AchievementInfo_language", "Name_243"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_243"), "ui9_icon_achievement_ShiShaMoLuo", "ui9_icon_achievement_ShiShaMoLuo_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 281, 1 } }, 0u, isHidden: false, "ShiShaMoLuo"));
		_dataArray.Add(new AchievementInfoItem(244, LocalStringManager.GetConfig("AchievementInfo_language", "Name_244"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_244"), "ui9_icon_achievement_YiHuaKaiTian", "ui9_icon_achievement_YiHuaKaiTian_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 282, 1 } }, 0u, isHidden: false, "YiHuaKaiTian"));
		_dataArray.Add(new AchievementInfoItem(245, LocalStringManager.GetConfig("AchievementInfo_language", "Name_245"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_245"), "ui9_icon_achievement_WuXianXuanYuan", "ui9_icon_achievement_WuXianXuanYuan_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 283, 1 } }, 0u, isHidden: false, "WuXianXuanYuan"));
		_dataArray.Add(new AchievementInfoItem(246, LocalStringManager.GetConfig("AchievementInfo_language", "Name_246"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_246"), "ui9_icon_achievement_JiuSiZhenCang", "ui9_icon_achievement_JiuSiZhenCang_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 284, 1 } }, 0u, isHidden: false, "JiuSiZhenCang"));
		_dataArray.Add(new AchievementInfoItem(247, LocalStringManager.GetConfig("AchievementInfo_language", "Name_247"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_247"), "ui9_icon_achievement_TianTongShenShu", "ui9_icon_achievement_TianTongShenShu_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 285, 1 } }, 0u, isHidden: false, "TianTongShenShu"));
		_dataArray.Add(new AchievementInfoItem(248, LocalStringManager.GetConfig("AchievementInfo_language", "Name_248"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_248"), "ui9_icon_achievement_ShenNvJueYin", "ui9_icon_achievement_ShenNvJueYin_small", EAchievementInfoType.LegendBook, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Equal }, new List<int[]> { new int[2] { 286, 1 } }, 0u, isHidden: false, "ShenNvJueYin"));
		_dataArray.Add(new AchievementInfoItem(249, LocalStringManager.GetConfig("AchievementInfo_language", "Name_249"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_249"), "ui9_icon_achievement_ShiSiQiShu", "ui9_icon_achievement_ShiSiQiShu_small", EAchievementInfoType.LegendBook, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 287, 14 } }, 0u, isHidden: false, "ShiSiQiShu"));
		_dataArray.Add(new AchievementInfoItem(250, LocalStringManager.GetConfig("AchievementInfo_language", "Name_250"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_250"), "ui9_icon_achievement_DiLiChongYing", "ui9_icon_achievement_DiLiChongYing_small", EAchievementInfoType.Building, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 87, 1 } }, 0u, isHidden: false, "DiLiChongYing"));
		_dataArray.Add(new AchievementInfoItem(251, LocalStringManager.GetConfig("AchievementInfo_language", "Name_251"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_251"), "ui9_icon_achievement_WuHuaTianBao", "ui9_icon_achievement_WuHuaTianBao_small", EAchievementInfoType.Building, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 88, 1 } }, 0u, isHidden: false, "WuHuaTianBao"));
		_dataArray.Add(new AchievementInfoItem(252, LocalStringManager.GetConfig("AchievementInfo_language", "Name_252"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_252"), "ui9_icon_achievement_RenDingXingWang", "ui9_icon_achievement_RenDingXingWang_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 107, 100 } }, 0u, isHidden: false, "RenDingXingWang"));
		_dataArray.Add(new AchievementInfoItem(253, LocalStringManager.GetConfig("AchievementInfo_language", "Name_253"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_253"), "ui9_icon_achievement_GeSiQiZhi", "ui9_icon_achievement_GeSiQiZhi_small", EAchievementInfoType.Building, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 10, 1 } }, 0u, isHidden: false, "GeSiQiZhi"));
		_dataArray.Add(new AchievementInfoItem(254, LocalStringManager.GetConfig("AchievementInfo_language", "Name_254"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_254"), "ui9_icon_achievement_CangLinFengShi", "ui9_icon_achievement_CangLinFengShi_small", EAchievementInfoType.Building, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 6, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(255, LocalStringManager.GetConfig("AchievementInfo_language", "Name_255"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_255"), "ui9_icon_achievement_JiMingQianLi", "ui9_icon_achievement_JiMingQianLi_small", EAchievementInfoType.Building, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 12, 64 } }, 0u, isHidden: false, "JiMingQianLi"));
		_dataArray.Add(new AchievementInfoItem(256, LocalStringManager.GetConfig("AchievementInfo_language", "Name_256"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_256"), "ui9_icon_achievement_SheXiKaiYan", "ui9_icon_achievement_SheXiKaiYan_small", EAchievementInfoType.Building, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 7, 1 } }, 0u, isHidden: false, "SheXiKaiYan"));
		_dataArray.Add(new AchievementInfoItem(257, LocalStringManager.GetConfig("AchievementInfo_language", "Name_257"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_257"), "ui9_icon_achievement_YanQingBaFang", "ui9_icon_achievement_YanQingBaFang_small", EAchievementInfoType.Building, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 7, 9 } }, 0u, isHidden: false, "YanQingBaFang"));
		_dataArray.Add(new AchievementInfoItem(258, LocalStringManager.GetConfig("AchievementInfo_language", "Name_258"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_258"), "ui9_icon_achievement_LunHuiWangSheng", "ui9_icon_achievement_LunHuiWangSheng_small", EAchievementInfoType.Building, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Greater }, new List<int[]> { new int[2] { 54, 0 } }, 0u, isHidden: false, "LunHuiWangSheng"));
		_dataArray.Add(new AchievementInfoItem(259, LocalStringManager.GetConfig("AchievementInfo_language", "Name_259"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_259"), "ui9_icon_achievement_LiuDaoLunHui", "ui9_icon_achievement_LiuDaoLunHui_small", EAchievementInfoType.Building, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 55, 6 } }, 0u, isHidden: false, "LiuDaoLunHui"));
		_dataArray.Add(new AchievementInfoItem(260, LocalStringManager.GetConfig("AchievementInfo_language", "Name_260"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_260"), "ui9_icon_achievement_SiLuFuXing", "ui9_icon_achievement_SiLuFuXing_small", EAchievementInfoType.Building, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 56, 20 } }, 0u, isHidden: false, "SiLuFuXing"));
		_dataArray.Add(new AchievementInfoItem(261, LocalStringManager.GetConfig("AchievementInfo_language", "Name_261"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_261"), "ui9_icon_achievement_FuNiuBangShangBin", "ui9_icon_achievement_FuNiuBangShangBin_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 17, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(262, LocalStringManager.GetConfig("AchievementInfo_language", "Name_262"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_262"), "ui9_icon_achievement_ShuHaiGeShangBin", "ui9_icon_achievement_ShuHaiGeShangBin_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 18, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(263, LocalStringManager.GetConfig("AchievementInfo_language", "Name_263"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_263"), "ui9_icon_achievement_WuHuShangBin", "ui9_icon_achievement_WuHuShangBin_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 19, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(264, LocalStringManager.GetConfig("AchievementInfo_language", "Name_264"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_264"), "ui9_icon_achievement_DaWuKuiShangBin", "ui9_icon_achievement_DaWuKuiShangBin_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 20, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(265, LocalStringManager.GetConfig("AchievementInfo_language", "Name_265"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_265"), "ui9_icon_achievement_HuiChunTangShangBin", "ui9_icon_achievement_HuiChunTangShangBin_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 21, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(266, LocalStringManager.GetConfig("AchievementInfo_language", "Name_266"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_266"), "ui9_icon_achievement_GongShuFangShangBin", "ui9_icon_achievement_GongShuFangShangBin_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 22, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(267, LocalStringManager.GetConfig("AchievementInfo_language", "Name_267"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_267"), "ui9_icon_achievement_QiHuoZhaiShangBin", "ui9_icon_achievement_QiHuoZhaiShangBin_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 23, 1 } }, 0u, isHidden: false, null));
		_dataArray.Add(new AchievementInfoItem(268, LocalStringManager.GetConfig("AchievementInfo_language", "Name_268"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_268"), "ui9_icon_achievement_QianChuiBaiLian", "ui9_icon_achievement_QianChuiBaiLian_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 24, 1 } }, 0u, isHidden: false, "QianChuiBaiLian"));
		_dataArray.Add(new AchievementInfoItem(269, LocalStringManager.GetConfig("AchievementInfo_language", "Name_269"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_269"), "ui9_icon_achievement_GuiFuShenGong", "ui9_icon_achievement_GuiFuShenGong_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 25, 1 } }, 0u, isHidden: false, "GuiFuShenGong"));
		_dataArray.Add(new AchievementInfoItem(270, LocalStringManager.GetConfig("AchievementInfo_language", "Name_270"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_270"), "ui9_icon_achievement_ZhiXiaChengJin", "ui9_icon_achievement_ZhiXiaChengJin_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 26, 1 } }, 0u, isHidden: false, "ZhiXiaChengJin"));
		_dataArray.Add(new AchievementInfoItem(271, LocalStringManager.GetConfig("AchievementInfo_language", "Name_271"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_271"), "ui9_icon_achievement_LianChengZhiBi", "ui9_icon_achievement_LianChengZhiBi_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 27, 1 } }, 0u, isHidden: false, "LianChengZhiBi"));
		_dataArray.Add(new AchievementInfoItem(272, LocalStringManager.GetConfig("AchievementInfo_language", "Name_272"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_272"), "ui9_icon_achievement_LuHuoChunQing", "ui9_icon_achievement_LuHuoChunQing_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 28, 1 } }, 0u, isHidden: false, "LuHuoChunQing"));
		_dataArray.Add(new AchievementInfoItem(273, LocalStringManager.GetConfig("AchievementInfo_language", "Name_273"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_273"), "ui9_icon_achievement_FengHouDuanChang", "ui9_icon_achievement_FengHouDuanChang_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 29, 1 } }, 0u, isHidden: false, "FengHouDuanChang"));
		_dataArray.Add(new AchievementInfoItem(274, LocalStringManager.GetConfig("AchievementInfo_language", "Name_274"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_274"), "ui9_icon_achievement_PengLongPaoFeng", "ui9_icon_achievement_PengLongPaoFeng_small", EAchievementInfoType.Building, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 30, 1 } }, 0u, isHidden: false, "PengLongPaoFeng"));
		_dataArray.Add(new AchievementInfoItem(275, LocalStringManager.GetConfig("AchievementInfo_language", "Name_275"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_275"), "ui9_icon_achievement_YiLuChuTong", "ui9_icon_achievement_YiLuChuTong_small", EAchievementInfoType.Travel, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.Greater }, new List<int[]> { new int[2] { 57, 0 } }, 0u, isHidden: false, "YiLuChuTong"));
		_dataArray.Add(new AchievementInfoItem(276, LocalStringManager.GetConfig("AchievementInfo_language", "Name_276"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_276"), "ui9_icon_achievement_JiuZhouTongQu", "ui9_icon_achievement_JiuZhouTongQu_small", EAchievementInfoType.Travel, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 57, 108 } }, 0u, isHidden: false, "JiuZhouTongQu"));
		_dataArray.Add(new AchievementInfoItem(277, LocalStringManager.GetConfig("AchievementInfo_language", "Name_277"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_277"), "ui9_icon_achievement_EGaiWo", "ui9_icon_achievement_EGaiWo_small", EAchievementInfoType.Travel, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 32, 1 } }, 0u, isHidden: false, "EGaiWo"));
		_dataArray.Add(new AchievementInfoItem(278, LocalStringManager.GetConfig("AchievementInfo_language", "Name_278"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_278"), "ui9_icon_achievement_ZeiRenYingZhai", "ui9_icon_achievement_ZeiRenYingZhai_small", EAchievementInfoType.Travel, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 33, 1 } }, 0u, isHidden: false, "ZeiRenYingZhai"));
		_dataArray.Add(new AchievementInfoItem(279, LocalStringManager.GetConfig("AchievementInfo_language", "Name_279"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_279"), "ui9_icon_achievement_HanFeiZhai", "ui9_icon_achievement_HanFeiZhai_small", EAchievementInfoType.Travel, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 34, 1 } }, 0u, isHidden: false, "HanFeiZhai"));
		_dataArray.Add(new AchievementInfoItem(280, LocalStringManager.GetConfig("AchievementInfo_language", "Name_280"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_280"), "ui9_icon_achievement_PanTuJieHuo", "ui9_icon_achievement_PanTuJieHuo_small", EAchievementInfoType.Travel, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 35, 1 } }, 0u, isHidden: false, "PanTuJieHuo"));
		_dataArray.Add(new AchievementInfoItem(281, LocalStringManager.GetConfig("AchievementInfo_language", "Name_281"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_281"), "ui9_icon_achievement_ERenGu", "ui9_icon_achievement_ERenGu_small", EAchievementInfoType.Travel, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 36, 1 } }, 0u, isHidden: false, "ERenGu"));
		_dataArray.Add(new AchievementInfoItem(282, LocalStringManager.GetConfig("AchievementInfo_language", "Name_282"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_282"), "ui9_icon_achievement_MiXiangZhen", "ui9_icon_achievement_MiXiangZhen_small", EAchievementInfoType.Travel, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 37, 1 } }, 0u, isHidden: false, "MiXiangZhen"));
		_dataArray.Add(new AchievementInfoItem(283, LocalStringManager.GetConfig("AchievementInfo_language", "Name_283"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_283"), "ui9_icon_achievement_LuanZangGang", "ui9_icon_achievement_LuanZangGang_small", EAchievementInfoType.Travel, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 38, 1 } }, 0u, isHidden: false, "LuanZangGang"));
		_dataArray.Add(new AchievementInfoItem(284, LocalStringManager.GetConfig("AchievementInfo_language", "Name_284"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_284"), "ui9_icon_achievement_YiShiJu", "ui9_icon_achievement_YiShiJu_small", EAchievementInfoType.Travel, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 39, 1 } }, 0u, isHidden: false, "YiShiJu"));
		_dataArray.Add(new AchievementInfoItem(285, LocalStringManager.GetConfig("AchievementInfo_language", "Name_285"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_285"), "ui9_icon_achievement_XieRenSiDi", "ui9_icon_achievement_XieRenSiDi_small", EAchievementInfoType.Travel, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 40, 1 } }, 0u, isHidden: false, "XieRenSiDi"));
		_dataArray.Add(new AchievementInfoItem(286, LocalStringManager.GetConfig("AchievementInfo_language", "Name_286"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_286"), "ui9_icon_achievement_XiuLuoChang", "ui9_icon_achievement_XiuLuoChang_small", EAchievementInfoType.Travel, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 41, 1 } }, 0u, isHidden: false, "XiuLuoChang"));
		_dataArray.Add(new AchievementInfoItem(287, LocalStringManager.GetConfig("AchievementInfo_language", "Name_287"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_287"), "ui9_icon_achievement_QunMoLuanWu", "ui9_icon_achievement_QunMoLuanWu_small", EAchievementInfoType.Travel, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 42, 1 } }, 0u, isHidden: false, "QunMoLuanWu"));
		_dataArray.Add(new AchievementInfoItem(288, LocalStringManager.GetConfig("AchievementInfo_language", "Name_288"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_288"), "ui9_icon_achievement_QiShiJueJing", "ui9_icon_achievement_QiShiJueJing_small", EAchievementInfoType.Travel, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 43, 1 } }, 0u, isHidden: false, "QiShiJueJing"));
		_dataArray.Add(new AchievementInfoItem(289, LocalStringManager.GetConfig("AchievementInfo_language", "Name_289"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_289"), "ui9_icon_achievement_YiShiTang", "ui9_icon_achievement_YiShiTang_small", EAchievementInfoType.Travel, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 44, 1 } }, 0u, isHidden: false, "YiShiTang"));
		_dataArray.Add(new AchievementInfoItem(290, LocalStringManager.GetConfig("AchievementInfo_language", "Name_290"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_290"), "ui9_icon_achievement_RenXiaHuiMeng", "ui9_icon_achievement_RenXiaHuiMeng_small", EAchievementInfoType.Travel, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 45, 1 } }, 0u, isHidden: false, "RenXiaHuiMeng"));
		_dataArray.Add(new AchievementInfoItem(291, LocalStringManager.GetConfig("AchievementInfo_language", "Name_291"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_291"), "ui9_icon_achievement_ShiWaiMiJing", "ui9_icon_achievement_ShiWaiMiJing_small", EAchievementInfoType.Travel, 3, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 46, 1 } }, 0u, isHidden: false, "ShiWaiMiJing"));
		_dataArray.Add(new AchievementInfoItem(292, LocalStringManager.GetConfig("AchievementInfo_language", "Name_292"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_292"), "ui9_icon_achievement_QiuChongGaoMing", "ui9_icon_achievement_QiuChongGaoMing_small", EAchievementInfoType.Travel, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 13, 1 } }, 0u, isHidden: false, "QiuChongGaoMing"));
		_dataArray.Add(new AchievementInfoItem(293, LocalStringManager.GetConfig("AchievementInfo_language", "Name_293"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_293"), "ui9_icon_achievement_LiaoYiSiJi", "ui9_icon_achievement_LiaoYiSiJi_small", EAchievementInfoType.Travel, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 14, 1 } }, 0u, isHidden: false, "LiaoYiSiJi"));
		_dataArray.Add(new AchievementInfoItem(294, LocalStringManager.GetConfig("AchievementInfo_language", "Name_294"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_294"), "ui9_icon_achievement_YiMingJingRen", "ui9_icon_achievement_YiMingJingRen_small", EAchievementInfoType.Travel, 2, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 15, 1 } }, 0u, isHidden: false, "YiMingJingRen"));
		_dataArray.Add(new AchievementInfoItem(295, LocalStringManager.GetConfig("AchievementInfo_language", "Name_295"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_295"), "ui9_icon_achievement_ChongWangQuanPu", "ui9_icon_achievement_ChongWangQuanPu_small", EAchievementInfoType.Travel, 4, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 15, 21 } }, 0u, isHidden: false, "ChongWangQuanPu"));
		_dataArray.Add(new AchievementInfoItem(296, LocalStringManager.GetConfig("AchievementInfo_language", "Name_296"), LocalStringManager.GetConfig("AchievementInfo_language", "Desc_296"), "ui9_icon_achievement_DouChongZhiDao", "ui9_icon_achievement_DouChongZhiDao_small", EAchievementInfoType.Travel, 1, new List<EAchievementInfoRequirementType> { EAchievementInfoRequirementType.GreaterOrEqual }, new List<int[]> { new int[2] { 89, 1 } }, 0u, isHidden: false, "DouChongZhiDao"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AchievementInfoItem>(297);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
	}
}
