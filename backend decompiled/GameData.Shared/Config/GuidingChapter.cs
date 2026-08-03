using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class GuidingChapter : ConfigData<GuidingChapterItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 伏虞剑柄
		/// </summary>
		public const short Item1 = 0;

		/// <summary>
		/// 太吾传承
		/// </summary>
		public const short Item2 = 1;

		/// <summary>
		/// 遗惠点数
		/// </summary>
		public const short Item3 = 2;

		/// <summary>
		/// 生平遗惠
		/// </summary>
		public const short Item4 = 3;

		/// <summary>
		/// 铭刻
		/// </summary>
		public const short Item5 = 4;

		/// <summary>
		/// 侵袭进度
		/// </summary>
		public const short Item6 = 5;

		/// <summary>
		/// 相枢入魔
		/// </summary>
		public const short Item7 = 6;

		/// <summary>
		/// 失心人
		/// </summary>
		public const short Item8 = 7;

		/// <summary>
		/// 玄石火灰
		/// </summary>
		public const short Item9 = 8;

		/// <summary>
		/// 伏虞心念
		/// </summary>
		public const short Item10 = 9;

		/// <summary>
		/// 剑冢
		/// </summary>
		public const short Item11 = 10;

		/// <summary>
		/// 相枢化身
		/// </summary>
		public const short Item12 = 11;

		/// <summary>
		/// 神剑碎片
		/// </summary>
		public const short Item13 = 12;

		/// <summary>
		/// 破冢化身
		/// </summary>
		public const short Item14 = 13;

		/// <summary>
		/// 紫竹化身
		/// </summary>
		public const short Item15 = 14;

		/// <summary>
		/// 州域与地区
		/// </summary>
		public const short Item16 = 15;

		/// <summary>
		/// 世界旅行
		/// </summary>
		public const short Item17 = 16;

		/// <summary>
		/// 传驿通路
		/// </summary>
		public const short Item18 = 17;

		/// <summary>
		/// 地区恩义
		/// </summary>
		public const short Item19 = 18;

		/// <summary>
		/// 地格与地形
		/// </summary>
		public const short Item20 = 19;

		/// <summary>
		/// 地格移动
		/// </summary>
		public const short Item21 = 20;

		/// <summary>
		/// 视野
		/// </summary>
		public const short Item22 = 21;

		/// <summary>
		/// 定居点
		/// </summary>
		public const short Item23 = 22;

		/// <summary>
		/// 地格资源
		/// </summary>
		public const short Item24 = 23;

		/// <summary>
		/// 天灾
		/// </summary>
		public const short Item25 = 24;

		/// <summary>
		/// 拾取遗宝
		/// </summary>
		public const short Item26 = 25;

		/// <summary>
		/// 行囊超重
		/// </summary>
		public const short Item27 = 26;

		/// <summary>
		/// 挖掘系统
		/// </summary>
		public const short Item28 = 27;

		/// <summary>
		/// 精力
		/// </summary>
		public const short Item29 = 28;

		/// <summary>
		/// 月份更替
		/// </summary>
		public const short Item30 = 29;

		/// <summary>
		/// 太吾月报
		/// </summary>
		public const short Item31 = 30;

		/// <summary>
		/// 势力与身份
		/// </summary>
		public const short Item32 = 31;

		/// <summary>
		/// 势力值
		/// </summary>
		public const short Item33 = 32;

		/// <summary>
		/// 晋升
		/// </summary>
		public const short Item34 = 33;

		/// <summary>
		/// 守卫
		/// </summary>
		public const short Item35 = 34;

		/// <summary>
		/// 法规
		/// </summary>
		public const short Item36 = 35;

		/// <summary>
		/// 监牢界面
		/// </summary>
		public const short Item37 = 36;

		/// <summary>
		/// 囚犯
		/// </summary>
		public const short Item38 = 37;

		/// <summary>
		/// 悬赏与送监
		/// </summary>
		public const short Item39 = 38;

		/// <summary>
		/// 犯罪处罚
		/// </summary>
		public const short Item40 = 39;

		/// <summary>
		/// 库房
		/// </summary>
		public const short Item41 = 40;

		/// <summary>
		/// 库房交换
		/// </summary>
		public const short Item42 = 41;

		/// <summary>
		/// 商会
		/// </summary>
		public const short Item43 = 42;

		/// <summary>
		/// 商店等级
		/// </summary>
		public const short Item44 = 43;

		/// <summary>
		/// 商会好感
		/// </summary>
		public const short Item45 = 44;

		/// <summary>
		/// 额外商品
		/// </summary>
		public const short Item46 = 45;

		/// <summary>
		/// 交易
		/// </summary>
		public const short Item47 = 46;

		/// <summary>
		/// 商队
		/// </summary>
		public const short Item48 = 47;

		/// <summary>
		/// 外道与任侠
		/// </summary>
		public const short Item49 = 48;

		/// <summary>
		/// 相枢爪牙
		/// </summary>
		public const short Item50 = 49;

		/// <summary>
		/// 野兽
		/// </summary>
		public const short Item51 = 50;

		/// <summary>
		/// 门派
		/// </summary>
		public const short Item52 = 51;

		/// <summary>
		/// 门派戒律
		/// </summary>
		public const short Item53 = 52;

		/// <summary>
		/// 学艺许可
		/// </summary>
		public const short Item54 = 53;

		/// <summary>
		/// 门派修习
		/// </summary>
		public const short Item55 = 54;

		/// <summary>
		/// 门派支持度
		/// </summary>
		public const short Item56 = 55;

		/// <summary>
		/// 门派较武
		/// </summary>
		public const short Item57 = 56;

		/// <summary>
		/// 地区故事
		/// </summary>
		public const short Item58 = 57;

		/// <summary>
		/// 少林派
		/// </summary>
		public const short Item59 = 58;

		/// <summary>
		/// 峨眉派
		/// </summary>
		public const short Item60 = 59;

		/// <summary>
		/// 百花谷
		/// </summary>
		public const short Item61 = 60;

		/// <summary>
		/// 武当派
		/// </summary>
		public const short Item62 = 61;

		/// <summary>
		/// 元山派
		/// </summary>
		public const short Item63 = 62;

		/// <summary>
		/// 狮相门
		/// </summary>
		public const short Item64 = 63;

		/// <summary>
		/// 然山派
		/// </summary>
		public const short Item65 = 64;

		/// <summary>
		/// 璇女派
		/// </summary>
		public const short Item66 = 65;

		/// <summary>
		/// 铸剑山庄
		/// </summary>
		public const short Item67 = 66;

		/// <summary>
		/// 空桑派
		/// </summary>
		public const short Item68 = 67;

		/// <summary>
		/// 金刚宗
		/// </summary>
		public const short Item69 = 68;

		/// <summary>
		/// 五仙教
		/// </summary>
		public const short Item70 = 69;

		/// <summary>
		/// 界青门
		/// </summary>
		public const short Item71 = 70;

		/// <summary>
		/// 伏龙坛
		/// </summary>
		public const short Item72 = 71;

		/// <summary>
		/// 血犼教
		/// </summary>
		public const short Item73 = 72;

		/// <summary>
		/// 姓名
		/// </summary>
		public const short Item74 = 73;

		/// <summary>
		/// 生时
		/// </summary>
		public const short Item75 = 74;

		/// <summary>
		/// 年龄
		/// </summary>
		public const short Item76 = 75;

		/// <summary>
		/// 性别
		/// </summary>
		public const short Item77 = 76;

		/// <summary>
		/// 魅力
		/// </summary>
		public const short Item78 = 77;

		/// <summary>
		/// 相貌
		/// </summary>
		public const short Item79 = 78;

		/// <summary>
		/// 理想门派
		/// </summary>
		public const short Item80 = 79;

		/// <summary>
		/// 称号
		/// </summary>
		public const short Item81 = 80;

		/// <summary>
		/// 心情
		/// </summary>
		public const short Item82 = 81;

		/// <summary>
		/// 好感
		/// </summary>
		public const short Item83 = 82;

		/// <summary>
		/// 戒心
		/// </summary>
		public const short Item84 = 83;

		/// <summary>
		/// 喜恶
		/// </summary>
		public const short Item85 = 84;

		/// <summary>
		/// 立场
		/// </summary>
		public const short Item86 = 85;

		/// <summary>
		/// 名誉
		/// </summary>
		public const short Item87 = 86;

		/// <summary>
		/// 轮回
		/// </summary>
		public const short Item88 = 87;

		/// <summary>
		/// 九世轮回
		/// </summary>
		public const short Item89 = 88;

		/// <summary>
		/// 资质
		/// </summary>
		public const short Item90 = 89;

		/// <summary>
		/// 造诣
		/// </summary>
		public const short Item91 = 90;

		/// <summary>
		/// 主要属性
		/// </summary>
		public const short Item92 = 91;

		/// <summary>
		/// 主要属性的消耗与恢复
		/// </summary>
		public const short Item93 = 92;

		/// <summary>
		/// 攻击属性
		/// </summary>
		public const short Item94 = 93;

		/// <summary>
		/// 防御属性
		/// </summary>
		public const short Item95 = 94;

		/// <summary>
		/// 命中属性
		/// </summary>
		public const short Item96 = 95;

		/// <summary>
		/// 化解属性
		/// </summary>
		public const short Item97 = 96;

		/// <summary>
		/// 次要属性
		/// </summary>
		public const short Item98 = 97;

		/// <summary>
		/// 人物特性
		/// </summary>
		public const short Item99 = 98;

		/// <summary>
		/// 特性倾向
		/// </summary>
		public const short Item100 = 99;

		/// <summary>
		/// 队伍机略
		/// </summary>
		public const short Item101 = 100;

		/// <summary>
		/// 七元赋性
		/// </summary>
		public const short Item102 = 101;

		/// <summary>
		/// 伤病
		/// </summary>
		public const short Item103 = 102;

		/// <summary>
		/// 健康
		/// </summary>
		public const short Item104 = 103;

		/// <summary>
		/// 寿元
		/// </summary>
		public const short Item105 = 104;

		/// <summary>
		/// 伤势
		/// </summary>
		public const short Item106 = 105;

		/// <summary>
		/// 毒素
		/// </summary>
		public const short Item107 = 106;

		/// <summary>
		/// 施加毒素
		/// </summary>
		public const short Item108 = 107;

		/// <summary>
		/// 混合毒素
		/// </summary>
		public const short Item109 = 108;

		/// <summary>
		/// 毒性发作
		/// </summary>
		public const short Item110 = 109;

		/// <summary>
		/// 内息
		/// </summary>
		public const short Item111 = 110;

		/// <summary>
		/// 蛊虫
		/// </summary>
		public const short Item112 = 111;

		/// <summary>
		/// 蛊引
		/// </summary>
		public const short Item113 = 112;

		/// <summary>
		/// 蛊虫的成长
		/// </summary>
		public const short Item114 = 113;

		/// <summary>
		/// 解蛊
		/// </summary>
		public const short Item115 = 114;

		/// <summary>
		/// 王蛊
		/// </summary>
		public const short Item116 = 115;

		/// <summary>
		/// 诊疗
		/// </summary>
		public const short Item117 = 116;

		/// <summary>
		/// 服食汲饮
		/// </summary>
		public const short Item118 = 117;

		/// <summary>
		/// 用药
		/// </summary>
		public const short Item119 = 118;

		/// <summary>
		/// 关系
		/// </summary>
		public const short Item120 = 119;

		/// <summary>
		/// 爱慕
		/// </summary>
		public const short Item121 = 120;

		/// <summary>
		/// 仇敌
		/// </summary>
		public const short Item122 = 121;

		/// <summary>
		/// 族谱
		/// </summary>
		public const short Item123 = 122;

		/// <summary>
		/// 经历
		/// </summary>
		public const short Item124 = 123;

		/// <summary>
		/// 见闻
		/// </summary>
		public const short Item125 = 124;

		/// <summary>
		/// 地方见闻
		/// </summary>
		public const short Item126 = 125;

		/// <summary>
		/// 门派见闻
		/// </summary>
		public const short Item127 = 126;

		/// <summary>
		/// 技艺见闻
		/// </summary>
		public const short Item128 = 127;

		/// <summary>
		/// 西域见闻
		/// </summary>
		public const short Item129 = 128;

		/// <summary>
		/// 剑冢见闻
		/// </summary>
		public const short Item130 = 129;

		/// <summary>
		/// 志向见闻
		/// </summary>
		public const short Item131 = 130;

		/// <summary>
		/// 人物互动
		/// </summary>
		public const short Item132 = 131;

		/// <summary>
		/// 互动-交谈
		/// </summary>
		public const short Item133 = 132;

		/// <summary>
		/// 个人交换
		/// </summary>
		public const short Item134 = 133;

		/// <summary>
		/// 互动-比试
		/// </summary>
		public const short Item135 = 134;

		/// <summary>
		/// 请教
		/// </summary>
		public const short Item136 = 135;

		/// <summary>
		/// 交换藏书
		/// </summary>
		public const short Item137 = 136;

		/// <summary>
		/// 互动-修习
		/// </summary>
		public const short Item138 = 137;

		/// <summary>
		/// 邀为同道
		/// </summary>
		public const short Item139 = 138;

		/// <summary>
		/// 互动-亲近
		/// </summary>
		public const short Item140 = 139;

		/// <summary>
		/// 互动-敌对
		/// </summary>
		public const short Item141 = 140;

		/// <summary>
		/// 乞丐
		/// </summary>
		public const short Item142 = 141;

		/// <summary>
		/// 农户
		/// </summary>
		public const short Item143 = 142;

		/// <summary>
		/// 下九流
		/// </summary>
		public const short Item144 = 143;

		/// <summary>
		/// 手艺人
		/// </summary>
		public const short Item145 = 144;

		/// <summary>
		/// 大夫
		/// </summary>
		public const short Item146 = 145;

		/// <summary>
		/// 商人
		/// </summary>
		public const short Item147 = 146;

		/// <summary>
		/// 文人
		/// </summary>
		public const short Item148 = 147;

		/// <summary>
		/// 富豪
		/// </summary>
		public const short Item149 = 148;

		/// <summary>
		/// 城镇二阶身份
		/// </summary>
		public const short Item150 = 149;

		/// <summary>
		/// 城镇一阶身份
		/// </summary>
		public const short Item151 = 150;

		/// <summary>
		/// 修改法规
		/// </summary>
		public const short Item152 = 151;

		/// <summary>
		/// 荐送弟子
		/// </summary>
		public const short Item153 = 152;

		/// <summary>
		/// 面壁阅经
		/// </summary>
		public const short Item154 = 153;

		/// <summary>
		/// 天府之国
		/// </summary>
		public const short Item155 = 154;

		/// <summary>
		/// 起死回生
		/// </summary>
		public const short Item156 = 155;

		/// <summary>
		/// 七星调元
		/// </summary>
		public const short Item157 = 156;

		/// <summary>
		/// 石牢静坐
		/// </summary>
		public const short Item158 = 157;

		/// <summary>
		/// 散播威名
		/// </summary>
		public const short Item159 = 158;

		/// <summary>
		/// 王禅典籍
		/// </summary>
		public const short Item160 = 159;

		/// <summary>
		/// 玉镜沉思
		/// </summary>
		public const short Item161 = 160;

		/// <summary>
		/// 欧冶古具
		/// </summary>
		public const short Item162 = 161;

		/// <summary>
		/// 铸剑试炼
		/// </summary>
		public const short Item163 = 162;

		/// <summary>
		/// 秘药延寿
		/// </summary>
		public const short Item164 = 163;

		/// <summary>
		/// 金刚秘法
		/// </summary>
		public const short Item165 = 164;

		/// <summary>
		/// 五圣秘浴
		/// </summary>
		public const short Item166 = 165;

		/// <summary>
		/// 委托暗杀
		/// </summary>
		public const short Item167 = 166;

		/// <summary>
		/// 龙岛忠仆
		/// </summary>
		public const short Item168 = 167;

		/// <summary>
		/// 血池秘法
		/// </summary>
		public const short Item169 = 168;

		/// <summary>
		/// 同道
		/// </summary>
		public const short Item170 = 169;

		/// <summary>
		/// 俘虏
		/// </summary>
		public const short Item171 = 170;

		/// <summary>
		/// 生育
		/// </summary>
		public const short Item172 = 171;

		/// <summary>
		/// 怀孕
		/// </summary>
		public const short Item173 = 172;

		/// <summary>
		/// 养育子女
		/// </summary>
		public const short Item174 = 173;

		/// <summary>
		/// 坟墓
		/// </summary>
		public const short Item175 = 174;

		/// <summary>
		/// NPC需求查看
		/// </summary>
		public const short Item176 = 175;

		/// <summary>
		/// 满足NPC的需求
		/// </summary>
		public const short Item177 = 176;

		/// <summary>
		/// 过月代办意外事件
		/// </summary>
		public const short Item178 = 177;

		/// <summary>
		/// 技艺
		/// </summary>
		public const short Item179 = 178;

		/// <summary>
		/// 武学
		/// </summary>
		public const short Item180 = 179;

		/// <summary>
		/// 研读书籍
		/// </summary>
		public const short Item181 = 180;

		/// <summary>
		/// 参考书籍
		/// </summary>
		public const short Item182 = 181;

		/// <summary>
		/// 总纲与心法
		/// </summary>
		public const short Item183 = 182;

		/// <summary>
		/// 研读技艺
		/// </summary>
		public const short Item184 = 183;

		/// <summary>
		/// 周天运转
		/// </summary>
		public const short Item185 = 184;

		/// <summary>
		/// 辅助内功
		/// </summary>
		public const short Item186 = 185;

		/// <summary>
		/// 灵光一闪
		/// </summary>
		public const short Item187 = 186;

		/// <summary>
		/// 研读策略
		/// </summary>
		public const short Item188 = 187;

		/// <summary>
		/// 天人感应
		/// </summary>
		public const short Item189 = 188;

		/// <summary>
		/// 周天策略
		/// </summary>
		public const short Item190 = 189;

		/// <summary>
		/// 专心致志与聚精会神
		/// </summary>
		public const short Item191 = 190;

		/// <summary>
		/// 心法效果
		/// </summary>
		public const short Item192 = 191;

		/// <summary>
		/// 内外功比例
		/// </summary>
		public const short Item193 = 192;

		/// <summary>
		/// 突破准备
		/// </summary>
		public const short Item194 = 193;

		/// <summary>
		/// 突破流程
		/// </summary>
		public const short Item195 = 194;

		/// <summary>
		/// 连接突破格
		/// </summary>
		public const short Item196 = 195;

		/// <summary>
		/// 突破功法 - 天资上限/走火入魔
		/// </summary>
		public const short Item197 = 196;

		/// <summary>
		/// 突破功法 - 突破格类型
		/// </summary>
		public const short Item198 = 197;

		/// <summary>
		/// 玄机格
		/// </summary>
		public const short Item199 = 198;

		/// <summary>
		/// 参悟玄机
		/// </summary>
		public const short Item200 = 199;

		/// <summary>
		/// 突破功法 - 完成突破
		/// </summary>
		public const short Item201 = 200;

		/// <summary>
		/// 功法五行
		/// </summary>
		public const short Item202 = 201;

		/// <summary>
		/// 功法威力
		/// </summary>
		public const short Item203 = 202;

		/// <summary>
		/// 发挥需求
		/// </summary>
		public const short Item204 = 203;

		/// <summary>
		/// 运功
		/// </summary>
		public const short Item205 = 204;

		/// <summary>
		/// 精解
		/// </summary>
		public const short Item206 = 205;

		/// <summary>
		/// 运功效果
		/// </summary>
		public const short Item207 = 206;

		/// <summary>
		/// 精纯境界
		/// </summary>
		public const short Item208 = 207;

		/// <summary>
		/// 内力
		/// </summary>
		public const short Item209 = 208;

		/// <summary>
		/// 内力属性
		/// </summary>
		public const short Item210 = 209;

		/// <summary>
		/// 内力冲克
		/// </summary>
		public const short Item211 = 210;

		/// <summary>
		/// 凝聚真气
		/// </summary>
		public const short Item212 = 211;

		/// <summary>
		/// 奇书宝典
		/// </summary>
		public const short Item213 = 212;

		/// <summary>
		/// 争夺奇书
		/// </summary>
		public const short Item214 = 213;

		/// <summary>
		/// 奇书奇遇
		/// </summary>
		public const short Item215 = 214;

		/// <summary>
		/// 解读奇书
		/// </summary>
		public const short Item216 = 215;

		/// <summary>
		/// 奇书执迷
		/// </summary>
		public const short Item217 = 216;

		/// <summary>
		/// 战斗类型
		/// </summary>
		public const short Item218 = 217;

		/// <summary>
		/// 战斗准备
		/// </summary>
		public const short Item219 = 218;

		/// <summary>
		/// 战斗限制
		/// </summary>
		public const short Item220 = 219;

		/// <summary>
		/// 战斗结算
		/// </summary>
		public const short Item221 = 220;

		/// <summary>
		/// 距离与移动
		/// </summary>
		public const short Item222 = 221;

		/// <summary>
		/// 兵器攻击
		/// </summary>
		public const short Item223 = 222;

		/// <summary>
		/// 招式
		/// </summary>
		public const short Item224 = 223;

		/// <summary>
		/// 追击
		/// </summary>
		public const short Item225 = 224;

		/// <summary>
		/// 攻击耗时
		/// </summary>
		public const short Item226 = 225;

		/// <summary>
		/// 攻击范围
		/// </summary>
		public const short Item227 = 226;

		/// <summary>
		/// 命中与化解
		/// </summary>
		public const short Item228 = 227;

		/// <summary>
		/// 命中要害
		/// </summary>
		public const short Item229 = 228;

		/// <summary>
		/// 兵器切换
		/// </summary>
		public const short Item230 = 229;

		/// <summary>
		/// 变招
		/// </summary>
		public const short Item231 = 230;

		/// <summary>
		/// 解封
		/// </summary>
		public const short Item232 = 231;

		/// <summary>
		/// 生铸
		/// </summary>
		public const short Item233 = 232;

		/// <summary>
		/// 战败标记
		/// </summary>
		public const short Item234 = 233;

		/// <summary>
		/// 直接伤害
		/// </summary>
		public const short Item235 = 234;

		/// <summary>
		/// 伤害累积
		/// </summary>
		public const short Item236 = 235;

		/// <summary>
		/// 身心强健
		/// </summary>
		public const short Item237 = 236;

		/// <summary>
		/// 伤势标记
		/// </summary>
		public const short Item238 = 237;

		/// <summary>
		/// 重创标记
		/// </summary>
		public const short Item239 = 238;

		/// <summary>
		/// 破绽标记
		/// </summary>
		public const short Item240 = 239;

		/// <summary>
		/// 封穴标记
		/// </summary>
		public const short Item241 = 240;

		/// <summary>
		/// 失神标记
		/// </summary>
		public const short Item242 = 241;

		/// <summary>
		/// 毒素标记
		/// </summary>
		public const short Item243 = 242;

		/// <summary>
		/// 蛊虫标记
		/// </summary>
		public const short Item244 = 243;

		/// <summary>
		/// 内息标记
		/// </summary>
		public const short Item245 = 244;

		/// <summary>
		/// 状态标记
		/// </summary>
		public const short Item246 = 245;

		/// <summary>
		/// 真气标记
		/// </summary>
		public const short Item247 = 246;

		/// <summary>
		/// 健康标记
		/// </summary>
		public const short Item248 = 247;

		/// <summary>
		/// 真气盈亏
		/// </summary>
		public const short Item249 = 248;

		/// <summary>
		/// 施展需要
		/// </summary>
		public const short Item250 = 249;

		/// <summary>
		/// 架势
		/// </summary>
		public const short Item251 = 250;

		/// <summary>
		/// 提气
		/// </summary>
		public const short Item252 = 251;

		/// <summary>
		/// 脚力
		/// </summary>
		public const short Item253 = 252;

		/// <summary>
		/// 蓄式
		/// </summary>
		public const short Item254 = 253;

		/// <summary>
		/// 内功
		/// </summary>
		public const short Item255 = 254;

		/// <summary>
		/// 身法
		/// </summary>
		public const short Item256 = 255;

		/// <summary>
		/// 摧破功法
		/// </summary>
		public const short Item257 = 256;

		/// <summary>
		/// 护体功法
		/// </summary>
		public const short Item258 = 257;

		/// <summary>
		/// 奇窍功法
		/// </summary>
		public const short Item259 = 258;

		/// <summary>
		/// 威力成数
		/// </summary>
		public const short Item260 = 259;

		/// <summary>
		/// 反击
		/// </summary>
		public const short Item261 = 260;

		/// <summary>
		/// 反震
		/// </summary>
		public const short Item262 = 261;

		/// <summary>
		/// 封禁
		/// </summary>
		public const short Item263 = 262;

		/// <summary>
		/// 功法反噬
		/// </summary>
		public const short Item264 = 263;

		/// <summary>
		/// 助战同道
		/// </summary>
		public const short Item265 = 264;

		/// <summary>
		/// 助战指令
		/// </summary>
		public const short Item266 = 265;

		/// <summary>
		/// 负面指令
		/// </summary>
		public const short Item267 = 266;

		/// <summary>
		/// 战斗行为
		/// </summary>
		public const short Item268 = 267;

		/// <summary>
		/// 战斗行为-疗伤驱毒
		/// </summary>
		public const short Item269 = 268;

		/// <summary>
		/// 战斗行为-使用物品
		/// </summary>
		public const short Item270 = 269;

		/// <summary>
		/// 逃离战斗
		/// </summary>
		public const short Item271 = 270;

		/// <summary>
		/// 认输投降
		/// </summary>
		public const short Item272 = 271;

		/// <summary>
		/// 处决
		/// </summary>
		public const short Item273 = 272;

		/// <summary>
		/// 产业视图
		/// </summary>
		public const short Item274 = 273;

		/// <summary>
		/// 产业建筑
		/// </summary>
		public const short Item275 = 274;

		/// <summary>
		/// 扩展建筑
		/// </summary>
		public const short Item276 = 275;

		/// <summary>
		/// 建筑受损
		/// </summary>
		public const short Item277 = 276;

		/// <summary>
		/// 自然资源
		/// </summary>
		public const short Item278 = 277;

		/// <summary>
		/// 建造
		/// </summary>
		public const short Item279 = 278;

		/// <summary>
		/// 扩建
		/// </summary>
		public const short Item280 = 279;

		/// <summary>
		/// 培育
		/// </summary>
		public const short Item281 = 280;

		/// <summary>
		/// 重申信誓
		/// </summary>
		public const short Item282 = 281;

		/// <summary>
		/// 撤除
		/// </summary>
		public const short Item283 = 282;

		/// <summary>
		/// 产业规划
		/// </summary>
		public const short Item284 = 283;

		/// <summary>
		/// 产业经营
		/// </summary>
		public const short Item285 = 284;

		/// <summary>
		/// 经营进度
		/// </summary>
		public const short Item286 = 285;

		/// <summary>
		/// 主事与学徒
		/// </summary>
		public const short Item287 = 286;

		/// <summary>
		/// 资源建筑
		/// </summary>
		public const short Item288 = 287;

		/// <summary>
		/// 售货建筑
		/// </summary>
		public const short Item289 = 288;

		/// <summary>
		/// 制造类建筑
		/// </summary>
		public const short Item290 = 289;

		/// <summary>
		/// 居所
		/// </summary>
		public const short Item291 = 290;

		/// <summary>
		/// 蛰室
		/// </summary>
		public const short Item292 = 291;

		/// <summary>
		/// 石屋
		/// </summary>
		public const short Item293 = 292;

		/// <summary>
		/// 太吾氏祠堂
		/// </summary>
		public const short Item294 = 293;

		/// <summary>
		/// 宴堂介绍
		/// </summary>
		public const short Item295 = 294;

		/// <summary>
		/// 仓库
		/// </summary>
		public const short Item296 = 295;

		/// <summary>
		/// 元鸡舍
		/// </summary>
		public const short Item297 = 296;

		/// <summary>
		/// 轮回台
		/// </summary>
		public const short Item298 = 297;

		/// <summary>
		/// 茶马帮
		/// </summary>
		public const short Item299 = 298;

		/// <summary>
		/// 练功房
		/// </summary>
		public const short Item300 = 299;

		/// <summary>
		/// 太吾村民
		/// </summary>
		public const short Item301 = 300;

		/// <summary>
		/// 村民身份
		/// </summary>
		public const short Item302 = 301;

		/// <summary>
		/// 村民身份职能
		/// </summary>
		public const short Item303 = 302;

		/// <summary>
		/// 物品
		/// </summary>
		public const short Item304 = 303;

		/// <summary>
		/// 资源
		/// </summary>
		public const short Item305 = 304;

		/// <summary>
		/// 银钱
		/// </summary>
		public const short Item306 = 305;

		/// <summary>
		/// 威望
		/// </summary>
		public const short Item307 = 306;

		/// <summary>
		/// 历练
		/// </summary>
		public const short Item308 = 307;

		/// <summary>
		/// 食物
		/// </summary>
		public const short Item309 = 308;

		/// <summary>
		/// 丹药
		/// </summary>
		public const short Item310 = 309;

		/// <summary>
		/// 毒药
		/// </summary>
		public const short Item311 = 310;

		/// <summary>
		/// 装备
		/// </summary>
		public const short Item312 = 311;

		/// <summary>
		/// 装备负重
		/// </summary>
		public const short Item313 = 312;

		/// <summary>
		/// 装备特殊效果
		/// </summary>
		public const short Item314 = 313;

		/// <summary>
		/// 兵器
		/// </summary>
		public const short Item315 = 314;

		/// <summary>
		/// 兵器属性
		/// </summary>
		public const short Item316 = 315;

		/// <summary>
		/// 护具
		/// </summary>
		public const short Item317 = 316;

		/// <summary>
		/// 护具属性
		/// </summary>
		public const short Item318 = 317;

		/// <summary>
		/// 宝物
		/// </summary>
		public const short Item319 = 318;

		/// <summary>
		/// 衣装
		/// </summary>
		public const short Item320 = 319;

		/// <summary>
		/// 代步
		/// </summary>
		public const short Item321 = 320;

		/// <summary>
		/// 野兽代步
		/// </summary>
		public const short Item322 = 321;

		/// <summary>
		/// 代步属性
		/// </summary>
		public const short Item323 = 322;

		/// <summary>
		/// 书籍
		/// </summary>
		public const short Item324 = 323;

		/// <summary>
		/// 工具
		/// </summary>
		public const short Item325 = 324;

		/// <summary>
		/// 引子
		/// </summary>
		public const short Item326 = 325;

		/// <summary>
		/// 精制材料
		/// </summary>
		public const short Item327 = 326;

		/// <summary>
		/// 心材
		/// </summary>
		public const short Item328 = 327;

		/// <summary>
		/// 绳索
		/// </summary>
		public const short Item329 = 328;

		/// <summary>
		/// 信鸽
		/// </summary>
		public const short Item330 = 329;

		/// <summary>
		/// 神木种子
		/// </summary>
		public const short Item331 = 330;

		/// <summary>
		/// 养育神木
		/// </summary>
		public const short Item332 = 331;

		/// <summary>
		/// 血露
		/// </summary>
		public const short Item333 = 332;

		/// <summary>
		/// 西域珍宝
		/// </summary>
		public const short Item334 = 333;

		/// <summary>
		/// 制造物品
		/// </summary>
		public const short Item335 = 334;

		/// <summary>
		/// 代制物品
		/// </summary>
		public const short Item336 = 335;

		/// <summary>
		/// 修理物品
		/// </summary>
		public const short Item337 = 336;

		/// <summary>
		/// 拆解物品
		/// </summary>
		public const short Item338 = 337;

		/// <summary>
		/// 精制物品
		/// </summary>
		public const short Item339 = 338;

		/// <summary>
		/// 淬毒
		/// </summary>
		public const short Item340 = 339;

		/// <summary>
		/// 解毒
		/// </summary>
		public const short Item341 = 340;

		/// <summary>
		/// 验毒
		/// </summary>
		public const short Item342 = 341;

		/// <summary>
		/// 改制衣装
		/// </summary>
		public const short Item343 = 342;

		/// <summary>
		/// 志向
		/// </summary>
		public const short Item344 = 343;

		/// <summary>
		/// 志向技能
		/// </summary>
		public const short Item345 = 344;

		/// <summary>
		/// 志向有成
		/// </summary>
		public const short Item346 = 345;

		/// <summary>
		/// 寻找促织
		/// </summary>
		public const short Item347 = 346;

		/// <summary>
		/// 捕捉促织
		/// </summary>
		public const short Item348 = 347;

		/// <summary>
		/// 促织属性
		/// </summary>
		public const short Item349 = 348;

		/// <summary>
		/// 促织决斗
		/// </summary>
		public const short Item350 = 349;

		/// <summary>
		/// 促织战绩
		/// </summary>
		public const short Item351 = 350;

		/// <summary>
		/// 遭遇奇遇
		/// </summary>
		public const short Item352 = 351;

		/// <summary>
		/// 初入奇遇
		/// </summary>
		public const short Item353 = 352;

		/// <summary>
		/// 探索奇遇
		/// </summary>
		public const short Item354 = 353;

		/// <summary>
		/// 较艺准备
		/// </summary>
		public const short Item355 = 354;

		/// <summary>
		/// 开始较艺
		/// </summary>
		public const short Item356 = 355;

		/// <summary>
		/// 使用策略
		/// </summary>
		public const short Item357 = 356;

		/// <summary>
		/// 论战
		/// </summary>
		public const short Item358 = 357;

		/// <summary>
		/// 较艺胜负
		/// </summary>
		public const short Item359 = 358;

		/// <summary>
		/// 较艺压力
		/// </summary>
		public const short Item360 = 359;

		/// <summary>
		/// 较艺结算
		/// </summary>
		public const short Item361 = 360;

		/// <summary>
		/// 诛魔试炼
		/// </summary>
		public const short Item362 = 361;

		/// <summary>
		/// 罗汉开悟
		/// </summary>
		public const short Item363 = 362;

		/// <summary>
		/// 独创心法
		/// </summary>
		public const short Item364 = 363;

		/// <summary>
		/// 生关死节
		/// </summary>
		public const short Item365 = 364;

		/// <summary>
		/// 改正修逆
		/// </summary>
		public const short Item366 = 365;

		/// <summary>
		/// 移宫易穴
		/// </summary>
		public const short Item367 = 366;

		/// <summary>
		/// 神魔入阵
		/// </summary>
		public const short Item368 = 367;

		/// <summary>
		/// 统筹方略
		/// </summary>
		public const short Item369 = 368;

		/// <summary>
		/// 寄托奇书
		/// </summary>
		public const short Item370 = 369;

		/// <summary>
		/// 奇书断执
		/// </summary>
		public const short Item371 = 370;

		/// <summary>
		/// 孤鸾镜水谣
		/// </summary>
		public const short Item372 = 371;

		/// <summary>
		/// 造化生人
		/// </summary>
		public const short Item373 = 372;

		/// <summary>
		/// 天外游历
		/// </summary>
		public const short Item374 = 373;

		/// <summary>
		/// 天枢玄铸
		/// </summary>
		public const short Item375 = 374;

		/// <summary>
		/// 驱使古鼎
		/// </summary>
		public const short Item376 = 375;

		/// <summary>
		/// 鼎蛟淬身
		/// </summary>
		public const short Item377 = 376;

		/// <summary>
		/// 化魂仪式
		/// </summary>
		public const short Item378 = 377;

		/// <summary>
		/// 炼制王蛊
		/// </summary>
		public const short Item379 = 378;

		/// <summary>
		/// 驱动王蛊
		/// </summary>
		public const short Item380 = 379;

		/// <summary>
		/// 奇纹星斗
		/// </summary>
		public const short Item381 = 380;

		/// <summary>
		/// 调遣元鸡
		/// </summary>
		public const short Item382 = 381;

		/// <summary>
		/// 元鸡灵羽
		/// </summary>
		public const short Item383 = 382;

		/// <summary>
		/// 姬穸随行
		/// </summary>
		public const short Item384 = 386;

		/// <summary>
		/// 持印汲气
		/// </summary>
		public const short Item385 = 383;

		/// <summary>
		/// 三才护阵
		/// </summary>
		public const short Item386 = 384;

		/// <summary>
		/// 三魔乱阵
		/// </summary>
		public const short Item387 = 385;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 伏虞剑柄
		/// </summary>
		public static GuidingChapterItem Item1 => Instance[(short)0];

		/// <summary>
		/// 太吾传承
		/// </summary>
		public static GuidingChapterItem Item2 => Instance[(short)1];

		/// <summary>
		/// 遗惠点数
		/// </summary>
		public static GuidingChapterItem Item3 => Instance[(short)2];

		/// <summary>
		/// 生平遗惠
		/// </summary>
		public static GuidingChapterItem Item4 => Instance[(short)3];

		/// <summary>
		/// 铭刻
		/// </summary>
		public static GuidingChapterItem Item5 => Instance[(short)4];

		/// <summary>
		/// 侵袭进度
		/// </summary>
		public static GuidingChapterItem Item6 => Instance[(short)5];

		/// <summary>
		/// 相枢入魔
		/// </summary>
		public static GuidingChapterItem Item7 => Instance[(short)6];

		/// <summary>
		/// 失心人
		/// </summary>
		public static GuidingChapterItem Item8 => Instance[(short)7];

		/// <summary>
		/// 玄石火灰
		/// </summary>
		public static GuidingChapterItem Item9 => Instance[(short)8];

		/// <summary>
		/// 伏虞心念
		/// </summary>
		public static GuidingChapterItem Item10 => Instance[(short)9];

		/// <summary>
		/// 剑冢
		/// </summary>
		public static GuidingChapterItem Item11 => Instance[(short)10];

		/// <summary>
		/// 相枢化身
		/// </summary>
		public static GuidingChapterItem Item12 => Instance[(short)11];

		/// <summary>
		/// 神剑碎片
		/// </summary>
		public static GuidingChapterItem Item13 => Instance[(short)12];

		/// <summary>
		/// 破冢化身
		/// </summary>
		public static GuidingChapterItem Item14 => Instance[(short)13];

		/// <summary>
		/// 紫竹化身
		/// </summary>
		public static GuidingChapterItem Item15 => Instance[(short)14];

		/// <summary>
		/// 州域与地区
		/// </summary>
		public static GuidingChapterItem Item16 => Instance[(short)15];

		/// <summary>
		/// 世界旅行
		/// </summary>
		public static GuidingChapterItem Item17 => Instance[(short)16];

		/// <summary>
		/// 传驿通路
		/// </summary>
		public static GuidingChapterItem Item18 => Instance[(short)17];

		/// <summary>
		/// 地区恩义
		/// </summary>
		public static GuidingChapterItem Item19 => Instance[(short)18];

		/// <summary>
		/// 地格与地形
		/// </summary>
		public static GuidingChapterItem Item20 => Instance[(short)19];

		/// <summary>
		/// 地格移动
		/// </summary>
		public static GuidingChapterItem Item21 => Instance[(short)20];

		/// <summary>
		/// 视野
		/// </summary>
		public static GuidingChapterItem Item22 => Instance[(short)21];

		/// <summary>
		/// 定居点
		/// </summary>
		public static GuidingChapterItem Item23 => Instance[(short)22];

		/// <summary>
		/// 地格资源
		/// </summary>
		public static GuidingChapterItem Item24 => Instance[(short)23];

		/// <summary>
		/// 天灾
		/// </summary>
		public static GuidingChapterItem Item25 => Instance[(short)24];

		/// <summary>
		/// 拾取遗宝
		/// </summary>
		public static GuidingChapterItem Item26 => Instance[(short)25];

		/// <summary>
		/// 行囊超重
		/// </summary>
		public static GuidingChapterItem Item27 => Instance[(short)26];

		/// <summary>
		/// 挖掘系统
		/// </summary>
		public static GuidingChapterItem Item28 => Instance[(short)27];

		/// <summary>
		/// 精力
		/// </summary>
		public static GuidingChapterItem Item29 => Instance[(short)28];

		/// <summary>
		/// 月份更替
		/// </summary>
		public static GuidingChapterItem Item30 => Instance[(short)29];

		/// <summary>
		/// 太吾月报
		/// </summary>
		public static GuidingChapterItem Item31 => Instance[(short)30];

		/// <summary>
		/// 势力与身份
		/// </summary>
		public static GuidingChapterItem Item32 => Instance[(short)31];

		/// <summary>
		/// 势力值
		/// </summary>
		public static GuidingChapterItem Item33 => Instance[(short)32];

		/// <summary>
		/// 晋升
		/// </summary>
		public static GuidingChapterItem Item34 => Instance[(short)33];

		/// <summary>
		/// 守卫
		/// </summary>
		public static GuidingChapterItem Item35 => Instance[(short)34];

		/// <summary>
		/// 法规
		/// </summary>
		public static GuidingChapterItem Item36 => Instance[(short)35];

		/// <summary>
		/// 监牢界面
		/// </summary>
		public static GuidingChapterItem Item37 => Instance[(short)36];

		/// <summary>
		/// 囚犯
		/// </summary>
		public static GuidingChapterItem Item38 => Instance[(short)37];

		/// <summary>
		/// 悬赏与送监
		/// </summary>
		public static GuidingChapterItem Item39 => Instance[(short)38];

		/// <summary>
		/// 犯罪处罚
		/// </summary>
		public static GuidingChapterItem Item40 => Instance[(short)39];

		/// <summary>
		/// 库房
		/// </summary>
		public static GuidingChapterItem Item41 => Instance[(short)40];

		/// <summary>
		/// 库房交换
		/// </summary>
		public static GuidingChapterItem Item42 => Instance[(short)41];

		/// <summary>
		/// 商会
		/// </summary>
		public static GuidingChapterItem Item43 => Instance[(short)42];

		/// <summary>
		/// 商店等级
		/// </summary>
		public static GuidingChapterItem Item44 => Instance[(short)43];

		/// <summary>
		/// 商会好感
		/// </summary>
		public static GuidingChapterItem Item45 => Instance[(short)44];

		/// <summary>
		/// 额外商品
		/// </summary>
		public static GuidingChapterItem Item46 => Instance[(short)45];

		/// <summary>
		/// 交易
		/// </summary>
		public static GuidingChapterItem Item47 => Instance[(short)46];

		/// <summary>
		/// 商队
		/// </summary>
		public static GuidingChapterItem Item48 => Instance[(short)47];

		/// <summary>
		/// 外道与任侠
		/// </summary>
		public static GuidingChapterItem Item49 => Instance[(short)48];

		/// <summary>
		/// 相枢爪牙
		/// </summary>
		public static GuidingChapterItem Item50 => Instance[(short)49];

		/// <summary>
		/// 野兽
		/// </summary>
		public static GuidingChapterItem Item51 => Instance[(short)50];

		/// <summary>
		/// 门派
		/// </summary>
		public static GuidingChapterItem Item52 => Instance[(short)51];

		/// <summary>
		/// 门派戒律
		/// </summary>
		public static GuidingChapterItem Item53 => Instance[(short)52];

		/// <summary>
		/// 学艺许可
		/// </summary>
		public static GuidingChapterItem Item54 => Instance[(short)53];

		/// <summary>
		/// 门派修习
		/// </summary>
		public static GuidingChapterItem Item55 => Instance[(short)54];

		/// <summary>
		/// 门派支持度
		/// </summary>
		public static GuidingChapterItem Item56 => Instance[(short)55];

		/// <summary>
		/// 门派较武
		/// </summary>
		public static GuidingChapterItem Item57 => Instance[(short)56];

		/// <summary>
		/// 地区故事
		/// </summary>
		public static GuidingChapterItem Item58 => Instance[(short)57];

		/// <summary>
		/// 少林派
		/// </summary>
		public static GuidingChapterItem Item59 => Instance[(short)58];

		/// <summary>
		/// 峨眉派
		/// </summary>
		public static GuidingChapterItem Item60 => Instance[(short)59];

		/// <summary>
		/// 百花谷
		/// </summary>
		public static GuidingChapterItem Item61 => Instance[(short)60];

		/// <summary>
		/// 武当派
		/// </summary>
		public static GuidingChapterItem Item62 => Instance[(short)61];

		/// <summary>
		/// 元山派
		/// </summary>
		public static GuidingChapterItem Item63 => Instance[(short)62];

		/// <summary>
		/// 狮相门
		/// </summary>
		public static GuidingChapterItem Item64 => Instance[(short)63];

		/// <summary>
		/// 然山派
		/// </summary>
		public static GuidingChapterItem Item65 => Instance[(short)64];

		/// <summary>
		/// 璇女派
		/// </summary>
		public static GuidingChapterItem Item66 => Instance[(short)65];

		/// <summary>
		/// 铸剑山庄
		/// </summary>
		public static GuidingChapterItem Item67 => Instance[(short)66];

		/// <summary>
		/// 空桑派
		/// </summary>
		public static GuidingChapterItem Item68 => Instance[(short)67];

		/// <summary>
		/// 金刚宗
		/// </summary>
		public static GuidingChapterItem Item69 => Instance[(short)68];

		/// <summary>
		/// 五仙教
		/// </summary>
		public static GuidingChapterItem Item70 => Instance[(short)69];

		/// <summary>
		/// 界青门
		/// </summary>
		public static GuidingChapterItem Item71 => Instance[(short)70];

		/// <summary>
		/// 伏龙坛
		/// </summary>
		public static GuidingChapterItem Item72 => Instance[(short)71];

		/// <summary>
		/// 血犼教
		/// </summary>
		public static GuidingChapterItem Item73 => Instance[(short)72];

		/// <summary>
		/// 姓名
		/// </summary>
		public static GuidingChapterItem Item74 => Instance[(short)73];

		/// <summary>
		/// 生时
		/// </summary>
		public static GuidingChapterItem Item75 => Instance[(short)74];

		/// <summary>
		/// 年龄
		/// </summary>
		public static GuidingChapterItem Item76 => Instance[(short)75];

		/// <summary>
		/// 性别
		/// </summary>
		public static GuidingChapterItem Item77 => Instance[(short)76];

		/// <summary>
		/// 魅力
		/// </summary>
		public static GuidingChapterItem Item78 => Instance[(short)77];

		/// <summary>
		/// 相貌
		/// </summary>
		public static GuidingChapterItem Item79 => Instance[(short)78];

		/// <summary>
		/// 理想门派
		/// </summary>
		public static GuidingChapterItem Item80 => Instance[(short)79];

		/// <summary>
		/// 称号
		/// </summary>
		public static GuidingChapterItem Item81 => Instance[(short)80];

		/// <summary>
		/// 心情
		/// </summary>
		public static GuidingChapterItem Item82 => Instance[(short)81];

		/// <summary>
		/// 好感
		/// </summary>
		public static GuidingChapterItem Item83 => Instance[(short)82];

		/// <summary>
		/// 戒心
		/// </summary>
		public static GuidingChapterItem Item84 => Instance[(short)83];

		/// <summary>
		/// 喜恶
		/// </summary>
		public static GuidingChapterItem Item85 => Instance[(short)84];

		/// <summary>
		/// 立场
		/// </summary>
		public static GuidingChapterItem Item86 => Instance[(short)85];

		/// <summary>
		/// 名誉
		/// </summary>
		public static GuidingChapterItem Item87 => Instance[(short)86];

		/// <summary>
		/// 轮回
		/// </summary>
		public static GuidingChapterItem Item88 => Instance[(short)87];

		/// <summary>
		/// 九世轮回
		/// </summary>
		public static GuidingChapterItem Item89 => Instance[(short)88];

		/// <summary>
		/// 资质
		/// </summary>
		public static GuidingChapterItem Item90 => Instance[(short)89];

		/// <summary>
		/// 造诣
		/// </summary>
		public static GuidingChapterItem Item91 => Instance[(short)90];

		/// <summary>
		/// 主要属性
		/// </summary>
		public static GuidingChapterItem Item92 => Instance[(short)91];

		/// <summary>
		/// 主要属性的消耗与恢复
		/// </summary>
		public static GuidingChapterItem Item93 => Instance[(short)92];

		/// <summary>
		/// 攻击属性
		/// </summary>
		public static GuidingChapterItem Item94 => Instance[(short)93];

		/// <summary>
		/// 防御属性
		/// </summary>
		public static GuidingChapterItem Item95 => Instance[(short)94];

		/// <summary>
		/// 命中属性
		/// </summary>
		public static GuidingChapterItem Item96 => Instance[(short)95];

		/// <summary>
		/// 化解属性
		/// </summary>
		public static GuidingChapterItem Item97 => Instance[(short)96];

		/// <summary>
		/// 次要属性
		/// </summary>
		public static GuidingChapterItem Item98 => Instance[(short)97];

		/// <summary>
		/// 人物特性
		/// </summary>
		public static GuidingChapterItem Item99 => Instance[(short)98];

		/// <summary>
		/// 特性倾向
		/// </summary>
		public static GuidingChapterItem Item100 => Instance[(short)99];

		/// <summary>
		/// 队伍机略
		/// </summary>
		public static GuidingChapterItem Item101 => Instance[(short)100];

		/// <summary>
		/// 七元赋性
		/// </summary>
		public static GuidingChapterItem Item102 => Instance[(short)101];

		/// <summary>
		/// 伤病
		/// </summary>
		public static GuidingChapterItem Item103 => Instance[(short)102];

		/// <summary>
		/// 健康
		/// </summary>
		public static GuidingChapterItem Item104 => Instance[(short)103];

		/// <summary>
		/// 寿元
		/// </summary>
		public static GuidingChapterItem Item105 => Instance[(short)104];

		/// <summary>
		/// 伤势
		/// </summary>
		public static GuidingChapterItem Item106 => Instance[(short)105];

		/// <summary>
		/// 毒素
		/// </summary>
		public static GuidingChapterItem Item107 => Instance[(short)106];

		/// <summary>
		/// 施加毒素
		/// </summary>
		public static GuidingChapterItem Item108 => Instance[(short)107];

		/// <summary>
		/// 混合毒素
		/// </summary>
		public static GuidingChapterItem Item109 => Instance[(short)108];

		/// <summary>
		/// 毒性发作
		/// </summary>
		public static GuidingChapterItem Item110 => Instance[(short)109];

		/// <summary>
		/// 内息
		/// </summary>
		public static GuidingChapterItem Item111 => Instance[(short)110];

		/// <summary>
		/// 蛊虫
		/// </summary>
		public static GuidingChapterItem Item112 => Instance[(short)111];

		/// <summary>
		/// 蛊引
		/// </summary>
		public static GuidingChapterItem Item113 => Instance[(short)112];

		/// <summary>
		/// 蛊虫的成长
		/// </summary>
		public static GuidingChapterItem Item114 => Instance[(short)113];

		/// <summary>
		/// 解蛊
		/// </summary>
		public static GuidingChapterItem Item115 => Instance[(short)114];

		/// <summary>
		/// 王蛊
		/// </summary>
		public static GuidingChapterItem Item116 => Instance[(short)115];

		/// <summary>
		/// 诊疗
		/// </summary>
		public static GuidingChapterItem Item117 => Instance[(short)116];

		/// <summary>
		/// 服食汲饮
		/// </summary>
		public static GuidingChapterItem Item118 => Instance[(short)117];

		/// <summary>
		/// 用药
		/// </summary>
		public static GuidingChapterItem Item119 => Instance[(short)118];

		/// <summary>
		/// 关系
		/// </summary>
		public static GuidingChapterItem Item120 => Instance[(short)119];

		/// <summary>
		/// 爱慕
		/// </summary>
		public static GuidingChapterItem Item121 => Instance[(short)120];

		/// <summary>
		/// 仇敌
		/// </summary>
		public static GuidingChapterItem Item122 => Instance[(short)121];

		/// <summary>
		/// 族谱
		/// </summary>
		public static GuidingChapterItem Item123 => Instance[(short)122];

		/// <summary>
		/// 经历
		/// </summary>
		public static GuidingChapterItem Item124 => Instance[(short)123];

		/// <summary>
		/// 见闻
		/// </summary>
		public static GuidingChapterItem Item125 => Instance[(short)124];

		/// <summary>
		/// 地方见闻
		/// </summary>
		public static GuidingChapterItem Item126 => Instance[(short)125];

		/// <summary>
		/// 门派见闻
		/// </summary>
		public static GuidingChapterItem Item127 => Instance[(short)126];

		/// <summary>
		/// 技艺见闻
		/// </summary>
		public static GuidingChapterItem Item128 => Instance[(short)127];

		/// <summary>
		/// 西域见闻
		/// </summary>
		public static GuidingChapterItem Item129 => Instance[(short)128];

		/// <summary>
		/// 剑冢见闻
		/// </summary>
		public static GuidingChapterItem Item130 => Instance[(short)129];

		/// <summary>
		/// 志向见闻
		/// </summary>
		public static GuidingChapterItem Item131 => Instance[(short)130];

		/// <summary>
		/// 人物互动
		/// </summary>
		public static GuidingChapterItem Item132 => Instance[(short)131];

		/// <summary>
		/// 互动-交谈
		/// </summary>
		public static GuidingChapterItem Item133 => Instance[(short)132];

		/// <summary>
		/// 个人交换
		/// </summary>
		public static GuidingChapterItem Item134 => Instance[(short)133];

		/// <summary>
		/// 互动-比试
		/// </summary>
		public static GuidingChapterItem Item135 => Instance[(short)134];

		/// <summary>
		/// 请教
		/// </summary>
		public static GuidingChapterItem Item136 => Instance[(short)135];

		/// <summary>
		/// 交换藏书
		/// </summary>
		public static GuidingChapterItem Item137 => Instance[(short)136];

		/// <summary>
		/// 互动-修习
		/// </summary>
		public static GuidingChapterItem Item138 => Instance[(short)137];

		/// <summary>
		/// 邀为同道
		/// </summary>
		public static GuidingChapterItem Item139 => Instance[(short)138];

		/// <summary>
		/// 互动-亲近
		/// </summary>
		public static GuidingChapterItem Item140 => Instance[(short)139];

		/// <summary>
		/// 互动-敌对
		/// </summary>
		public static GuidingChapterItem Item141 => Instance[(short)140];

		/// <summary>
		/// 乞丐
		/// </summary>
		public static GuidingChapterItem Item142 => Instance[(short)141];

		/// <summary>
		/// 农户
		/// </summary>
		public static GuidingChapterItem Item143 => Instance[(short)142];

		/// <summary>
		/// 下九流
		/// </summary>
		public static GuidingChapterItem Item144 => Instance[(short)143];

		/// <summary>
		/// 手艺人
		/// </summary>
		public static GuidingChapterItem Item145 => Instance[(short)144];

		/// <summary>
		/// 大夫
		/// </summary>
		public static GuidingChapterItem Item146 => Instance[(short)145];

		/// <summary>
		/// 商人
		/// </summary>
		public static GuidingChapterItem Item147 => Instance[(short)146];

		/// <summary>
		/// 文人
		/// </summary>
		public static GuidingChapterItem Item148 => Instance[(short)147];

		/// <summary>
		/// 富豪
		/// </summary>
		public static GuidingChapterItem Item149 => Instance[(short)148];

		/// <summary>
		/// 城镇二阶身份
		/// </summary>
		public static GuidingChapterItem Item150 => Instance[(short)149];

		/// <summary>
		/// 城镇一阶身份
		/// </summary>
		public static GuidingChapterItem Item151 => Instance[(short)150];

		/// <summary>
		/// 修改法规
		/// </summary>
		public static GuidingChapterItem Item152 => Instance[(short)151];

		/// <summary>
		/// 荐送弟子
		/// </summary>
		public static GuidingChapterItem Item153 => Instance[(short)152];

		/// <summary>
		/// 面壁阅经
		/// </summary>
		public static GuidingChapterItem Item154 => Instance[(short)153];

		/// <summary>
		/// 天府之国
		/// </summary>
		public static GuidingChapterItem Item155 => Instance[(short)154];

		/// <summary>
		/// 起死回生
		/// </summary>
		public static GuidingChapterItem Item156 => Instance[(short)155];

		/// <summary>
		/// 七星调元
		/// </summary>
		public static GuidingChapterItem Item157 => Instance[(short)156];

		/// <summary>
		/// 石牢静坐
		/// </summary>
		public static GuidingChapterItem Item158 => Instance[(short)157];

		/// <summary>
		/// 散播威名
		/// </summary>
		public static GuidingChapterItem Item159 => Instance[(short)158];

		/// <summary>
		/// 王禅典籍
		/// </summary>
		public static GuidingChapterItem Item160 => Instance[(short)159];

		/// <summary>
		/// 玉镜沉思
		/// </summary>
		public static GuidingChapterItem Item161 => Instance[(short)160];

		/// <summary>
		/// 欧冶古具
		/// </summary>
		public static GuidingChapterItem Item162 => Instance[(short)161];

		/// <summary>
		/// 铸剑试炼
		/// </summary>
		public static GuidingChapterItem Item163 => Instance[(short)162];

		/// <summary>
		/// 秘药延寿
		/// </summary>
		public static GuidingChapterItem Item164 => Instance[(short)163];

		/// <summary>
		/// 金刚秘法
		/// </summary>
		public static GuidingChapterItem Item165 => Instance[(short)164];

		/// <summary>
		/// 五圣秘浴
		/// </summary>
		public static GuidingChapterItem Item166 => Instance[(short)165];

		/// <summary>
		/// 委托暗杀
		/// </summary>
		public static GuidingChapterItem Item167 => Instance[(short)166];

		/// <summary>
		/// 龙岛忠仆
		/// </summary>
		public static GuidingChapterItem Item168 => Instance[(short)167];

		/// <summary>
		/// 血池秘法
		/// </summary>
		public static GuidingChapterItem Item169 => Instance[(short)168];

		/// <summary>
		/// 同道
		/// </summary>
		public static GuidingChapterItem Item170 => Instance[(short)169];

		/// <summary>
		/// 俘虏
		/// </summary>
		public static GuidingChapterItem Item171 => Instance[(short)170];

		/// <summary>
		/// 生育
		/// </summary>
		public static GuidingChapterItem Item172 => Instance[(short)171];

		/// <summary>
		/// 怀孕
		/// </summary>
		public static GuidingChapterItem Item173 => Instance[(short)172];

		/// <summary>
		/// 养育子女
		/// </summary>
		public static GuidingChapterItem Item174 => Instance[(short)173];

		/// <summary>
		/// 坟墓
		/// </summary>
		public static GuidingChapterItem Item175 => Instance[(short)174];

		/// <summary>
		/// NPC需求查看
		/// </summary>
		public static GuidingChapterItem Item176 => Instance[(short)175];

		/// <summary>
		/// 满足NPC的需求
		/// </summary>
		public static GuidingChapterItem Item177 => Instance[(short)176];

		/// <summary>
		/// 过月代办意外事件
		/// </summary>
		public static GuidingChapterItem Item178 => Instance[(short)177];

		/// <summary>
		/// 技艺
		/// </summary>
		public static GuidingChapterItem Item179 => Instance[(short)178];

		/// <summary>
		/// 武学
		/// </summary>
		public static GuidingChapterItem Item180 => Instance[(short)179];

		/// <summary>
		/// 研读书籍
		/// </summary>
		public static GuidingChapterItem Item181 => Instance[(short)180];

		/// <summary>
		/// 参考书籍
		/// </summary>
		public static GuidingChapterItem Item182 => Instance[(short)181];

		/// <summary>
		/// 总纲与心法
		/// </summary>
		public static GuidingChapterItem Item183 => Instance[(short)182];

		/// <summary>
		/// 研读技艺
		/// </summary>
		public static GuidingChapterItem Item184 => Instance[(short)183];

		/// <summary>
		/// 周天运转
		/// </summary>
		public static GuidingChapterItem Item185 => Instance[(short)184];

		/// <summary>
		/// 辅助内功
		/// </summary>
		public static GuidingChapterItem Item186 => Instance[(short)185];

		/// <summary>
		/// 灵光一闪
		/// </summary>
		public static GuidingChapterItem Item187 => Instance[(short)186];

		/// <summary>
		/// 研读策略
		/// </summary>
		public static GuidingChapterItem Item188 => Instance[(short)187];

		/// <summary>
		/// 天人感应
		/// </summary>
		public static GuidingChapterItem Item189 => Instance[(short)188];

		/// <summary>
		/// 周天策略
		/// </summary>
		public static GuidingChapterItem Item190 => Instance[(short)189];

		/// <summary>
		/// 专心致志与聚精会神
		/// </summary>
		public static GuidingChapterItem Item191 => Instance[(short)190];

		/// <summary>
		/// 心法效果
		/// </summary>
		public static GuidingChapterItem Item192 => Instance[(short)191];

		/// <summary>
		/// 内外功比例
		/// </summary>
		public static GuidingChapterItem Item193 => Instance[(short)192];

		/// <summary>
		/// 突破准备
		/// </summary>
		public static GuidingChapterItem Item194 => Instance[(short)193];

		/// <summary>
		/// 突破流程
		/// </summary>
		public static GuidingChapterItem Item195 => Instance[(short)194];

		/// <summary>
		/// 连接突破格
		/// </summary>
		public static GuidingChapterItem Item196 => Instance[(short)195];

		/// <summary>
		/// 突破功法 - 天资上限/走火入魔
		/// </summary>
		public static GuidingChapterItem Item197 => Instance[(short)196];

		/// <summary>
		/// 突破功法 - 突破格类型
		/// </summary>
		public static GuidingChapterItem Item198 => Instance[(short)197];

		/// <summary>
		/// 玄机格
		/// </summary>
		public static GuidingChapterItem Item199 => Instance[(short)198];

		/// <summary>
		/// 参悟玄机
		/// </summary>
		public static GuidingChapterItem Item200 => Instance[(short)199];

		/// <summary>
		/// 突破功法 - 完成突破
		/// </summary>
		public static GuidingChapterItem Item201 => Instance[(short)200];

		/// <summary>
		/// 功法五行
		/// </summary>
		public static GuidingChapterItem Item202 => Instance[(short)201];

		/// <summary>
		/// 功法威力
		/// </summary>
		public static GuidingChapterItem Item203 => Instance[(short)202];

		/// <summary>
		/// 发挥需求
		/// </summary>
		public static GuidingChapterItem Item204 => Instance[(short)203];

		/// <summary>
		/// 运功
		/// </summary>
		public static GuidingChapterItem Item205 => Instance[(short)204];

		/// <summary>
		/// 精解
		/// </summary>
		public static GuidingChapterItem Item206 => Instance[(short)205];

		/// <summary>
		/// 运功效果
		/// </summary>
		public static GuidingChapterItem Item207 => Instance[(short)206];

		/// <summary>
		/// 精纯境界
		/// </summary>
		public static GuidingChapterItem Item208 => Instance[(short)207];

		/// <summary>
		/// 内力
		/// </summary>
		public static GuidingChapterItem Item209 => Instance[(short)208];

		/// <summary>
		/// 内力属性
		/// </summary>
		public static GuidingChapterItem Item210 => Instance[(short)209];

		/// <summary>
		/// 内力冲克
		/// </summary>
		public static GuidingChapterItem Item211 => Instance[(short)210];

		/// <summary>
		/// 凝聚真气
		/// </summary>
		public static GuidingChapterItem Item212 => Instance[(short)211];

		/// <summary>
		/// 奇书宝典
		/// </summary>
		public static GuidingChapterItem Item213 => Instance[(short)212];

		/// <summary>
		/// 争夺奇书
		/// </summary>
		public static GuidingChapterItem Item214 => Instance[(short)213];

		/// <summary>
		/// 奇书奇遇
		/// </summary>
		public static GuidingChapterItem Item215 => Instance[(short)214];

		/// <summary>
		/// 解读奇书
		/// </summary>
		public static GuidingChapterItem Item216 => Instance[(short)215];

		/// <summary>
		/// 奇书执迷
		/// </summary>
		public static GuidingChapterItem Item217 => Instance[(short)216];

		/// <summary>
		/// 战斗类型
		/// </summary>
		public static GuidingChapterItem Item218 => Instance[(short)217];

		/// <summary>
		/// 战斗准备
		/// </summary>
		public static GuidingChapterItem Item219 => Instance[(short)218];

		/// <summary>
		/// 战斗限制
		/// </summary>
		public static GuidingChapterItem Item220 => Instance[(short)219];

		/// <summary>
		/// 战斗结算
		/// </summary>
		public static GuidingChapterItem Item221 => Instance[(short)220];

		/// <summary>
		/// 距离与移动
		/// </summary>
		public static GuidingChapterItem Item222 => Instance[(short)221];

		/// <summary>
		/// 兵器攻击
		/// </summary>
		public static GuidingChapterItem Item223 => Instance[(short)222];

		/// <summary>
		/// 招式
		/// </summary>
		public static GuidingChapterItem Item224 => Instance[(short)223];

		/// <summary>
		/// 追击
		/// </summary>
		public static GuidingChapterItem Item225 => Instance[(short)224];

		/// <summary>
		/// 攻击耗时
		/// </summary>
		public static GuidingChapterItem Item226 => Instance[(short)225];

		/// <summary>
		/// 攻击范围
		/// </summary>
		public static GuidingChapterItem Item227 => Instance[(short)226];

		/// <summary>
		/// 命中与化解
		/// </summary>
		public static GuidingChapterItem Item228 => Instance[(short)227];

		/// <summary>
		/// 命中要害
		/// </summary>
		public static GuidingChapterItem Item229 => Instance[(short)228];

		/// <summary>
		/// 兵器切换
		/// </summary>
		public static GuidingChapterItem Item230 => Instance[(short)229];

		/// <summary>
		/// 变招
		/// </summary>
		public static GuidingChapterItem Item231 => Instance[(short)230];

		/// <summary>
		/// 解封
		/// </summary>
		public static GuidingChapterItem Item232 => Instance[(short)231];

		/// <summary>
		/// 生铸
		/// </summary>
		public static GuidingChapterItem Item233 => Instance[(short)232];

		/// <summary>
		/// 战败标记
		/// </summary>
		public static GuidingChapterItem Item234 => Instance[(short)233];

		/// <summary>
		/// 直接伤害
		/// </summary>
		public static GuidingChapterItem Item235 => Instance[(short)234];

		/// <summary>
		/// 伤害累积
		/// </summary>
		public static GuidingChapterItem Item236 => Instance[(short)235];

		/// <summary>
		/// 身心强健
		/// </summary>
		public static GuidingChapterItem Item237 => Instance[(short)236];

		/// <summary>
		/// 伤势标记
		/// </summary>
		public static GuidingChapterItem Item238 => Instance[(short)237];

		/// <summary>
		/// 重创标记
		/// </summary>
		public static GuidingChapterItem Item239 => Instance[(short)238];

		/// <summary>
		/// 破绽标记
		/// </summary>
		public static GuidingChapterItem Item240 => Instance[(short)239];

		/// <summary>
		/// 封穴标记
		/// </summary>
		public static GuidingChapterItem Item241 => Instance[(short)240];

		/// <summary>
		/// 失神标记
		/// </summary>
		public static GuidingChapterItem Item242 => Instance[(short)241];

		/// <summary>
		/// 毒素标记
		/// </summary>
		public static GuidingChapterItem Item243 => Instance[(short)242];

		/// <summary>
		/// 蛊虫标记
		/// </summary>
		public static GuidingChapterItem Item244 => Instance[(short)243];

		/// <summary>
		/// 内息标记
		/// </summary>
		public static GuidingChapterItem Item245 => Instance[(short)244];

		/// <summary>
		/// 状态标记
		/// </summary>
		public static GuidingChapterItem Item246 => Instance[(short)245];

		/// <summary>
		/// 真气标记
		/// </summary>
		public static GuidingChapterItem Item247 => Instance[(short)246];

		/// <summary>
		/// 健康标记
		/// </summary>
		public static GuidingChapterItem Item248 => Instance[(short)247];

		/// <summary>
		/// 真气盈亏
		/// </summary>
		public static GuidingChapterItem Item249 => Instance[(short)248];

		/// <summary>
		/// 施展需要
		/// </summary>
		public static GuidingChapterItem Item250 => Instance[(short)249];

		/// <summary>
		/// 架势
		/// </summary>
		public static GuidingChapterItem Item251 => Instance[(short)250];

		/// <summary>
		/// 提气
		/// </summary>
		public static GuidingChapterItem Item252 => Instance[(short)251];

		/// <summary>
		/// 脚力
		/// </summary>
		public static GuidingChapterItem Item253 => Instance[(short)252];

		/// <summary>
		/// 蓄式
		/// </summary>
		public static GuidingChapterItem Item254 => Instance[(short)253];

		/// <summary>
		/// 内功
		/// </summary>
		public static GuidingChapterItem Item255 => Instance[(short)254];

		/// <summary>
		/// 身法
		/// </summary>
		public static GuidingChapterItem Item256 => Instance[(short)255];

		/// <summary>
		/// 摧破功法
		/// </summary>
		public static GuidingChapterItem Item257 => Instance[(short)256];

		/// <summary>
		/// 护体功法
		/// </summary>
		public static GuidingChapterItem Item258 => Instance[(short)257];

		/// <summary>
		/// 奇窍功法
		/// </summary>
		public static GuidingChapterItem Item259 => Instance[(short)258];

		/// <summary>
		/// 威力成数
		/// </summary>
		public static GuidingChapterItem Item260 => Instance[(short)259];

		/// <summary>
		/// 反击
		/// </summary>
		public static GuidingChapterItem Item261 => Instance[(short)260];

		/// <summary>
		/// 反震
		/// </summary>
		public static GuidingChapterItem Item262 => Instance[(short)261];

		/// <summary>
		/// 封禁
		/// </summary>
		public static GuidingChapterItem Item263 => Instance[(short)262];

		/// <summary>
		/// 功法反噬
		/// </summary>
		public static GuidingChapterItem Item264 => Instance[(short)263];

		/// <summary>
		/// 助战同道
		/// </summary>
		public static GuidingChapterItem Item265 => Instance[(short)264];

		/// <summary>
		/// 助战指令
		/// </summary>
		public static GuidingChapterItem Item266 => Instance[(short)265];

		/// <summary>
		/// 负面指令
		/// </summary>
		public static GuidingChapterItem Item267 => Instance[(short)266];

		/// <summary>
		/// 战斗行为
		/// </summary>
		public static GuidingChapterItem Item268 => Instance[(short)267];

		/// <summary>
		/// 战斗行为-疗伤驱毒
		/// </summary>
		public static GuidingChapterItem Item269 => Instance[(short)268];

		/// <summary>
		/// 战斗行为-使用物品
		/// </summary>
		public static GuidingChapterItem Item270 => Instance[(short)269];

		/// <summary>
		/// 逃离战斗
		/// </summary>
		public static GuidingChapterItem Item271 => Instance[(short)270];

		/// <summary>
		/// 认输投降
		/// </summary>
		public static GuidingChapterItem Item272 => Instance[(short)271];

		/// <summary>
		/// 处决
		/// </summary>
		public static GuidingChapterItem Item273 => Instance[(short)272];

		/// <summary>
		/// 产业视图
		/// </summary>
		public static GuidingChapterItem Item274 => Instance[(short)273];

		/// <summary>
		/// 产业建筑
		/// </summary>
		public static GuidingChapterItem Item275 => Instance[(short)274];

		/// <summary>
		/// 扩展建筑
		/// </summary>
		public static GuidingChapterItem Item276 => Instance[(short)275];

		/// <summary>
		/// 建筑受损
		/// </summary>
		public static GuidingChapterItem Item277 => Instance[(short)276];

		/// <summary>
		/// 自然资源
		/// </summary>
		public static GuidingChapterItem Item278 => Instance[(short)277];

		/// <summary>
		/// 建造
		/// </summary>
		public static GuidingChapterItem Item279 => Instance[(short)278];

		/// <summary>
		/// 扩建
		/// </summary>
		public static GuidingChapterItem Item280 => Instance[(short)279];

		/// <summary>
		/// 培育
		/// </summary>
		public static GuidingChapterItem Item281 => Instance[(short)280];

		/// <summary>
		/// 重申信誓
		/// </summary>
		public static GuidingChapterItem Item282 => Instance[(short)281];

		/// <summary>
		/// 撤除
		/// </summary>
		public static GuidingChapterItem Item283 => Instance[(short)282];

		/// <summary>
		/// 产业规划
		/// </summary>
		public static GuidingChapterItem Item284 => Instance[(short)283];

		/// <summary>
		/// 产业经营
		/// </summary>
		public static GuidingChapterItem Item285 => Instance[(short)284];

		/// <summary>
		/// 经营进度
		/// </summary>
		public static GuidingChapterItem Item286 => Instance[(short)285];

		/// <summary>
		/// 主事与学徒
		/// </summary>
		public static GuidingChapterItem Item287 => Instance[(short)286];

		/// <summary>
		/// 资源建筑
		/// </summary>
		public static GuidingChapterItem Item288 => Instance[(short)287];

		/// <summary>
		/// 售货建筑
		/// </summary>
		public static GuidingChapterItem Item289 => Instance[(short)288];

		/// <summary>
		/// 制造类建筑
		/// </summary>
		public static GuidingChapterItem Item290 => Instance[(short)289];

		/// <summary>
		/// 居所
		/// </summary>
		public static GuidingChapterItem Item291 => Instance[(short)290];

		/// <summary>
		/// 蛰室
		/// </summary>
		public static GuidingChapterItem Item292 => Instance[(short)291];

		/// <summary>
		/// 石屋
		/// </summary>
		public static GuidingChapterItem Item293 => Instance[(short)292];

		/// <summary>
		/// 太吾氏祠堂
		/// </summary>
		public static GuidingChapterItem Item294 => Instance[(short)293];

		/// <summary>
		/// 宴堂介绍
		/// </summary>
		public static GuidingChapterItem Item295 => Instance[(short)294];

		/// <summary>
		/// 仓库
		/// </summary>
		public static GuidingChapterItem Item296 => Instance[(short)295];

		/// <summary>
		/// 元鸡舍
		/// </summary>
		public static GuidingChapterItem Item297 => Instance[(short)296];

		/// <summary>
		/// 轮回台
		/// </summary>
		public static GuidingChapterItem Item298 => Instance[(short)297];

		/// <summary>
		/// 茶马帮
		/// </summary>
		public static GuidingChapterItem Item299 => Instance[(short)298];

		/// <summary>
		/// 练功房
		/// </summary>
		public static GuidingChapterItem Item300 => Instance[(short)299];

		/// <summary>
		/// 太吾村民
		/// </summary>
		public static GuidingChapterItem Item301 => Instance[(short)300];

		/// <summary>
		/// 村民身份
		/// </summary>
		public static GuidingChapterItem Item302 => Instance[(short)301];

		/// <summary>
		/// 村民身份职能
		/// </summary>
		public static GuidingChapterItem Item303 => Instance[(short)302];

		/// <summary>
		/// 物品
		/// </summary>
		public static GuidingChapterItem Item304 => Instance[(short)303];

		/// <summary>
		/// 资源
		/// </summary>
		public static GuidingChapterItem Item305 => Instance[(short)304];

		/// <summary>
		/// 银钱
		/// </summary>
		public static GuidingChapterItem Item306 => Instance[(short)305];

		/// <summary>
		/// 威望
		/// </summary>
		public static GuidingChapterItem Item307 => Instance[(short)306];

		/// <summary>
		/// 历练
		/// </summary>
		public static GuidingChapterItem Item308 => Instance[(short)307];

		/// <summary>
		/// 食物
		/// </summary>
		public static GuidingChapterItem Item309 => Instance[(short)308];

		/// <summary>
		/// 丹药
		/// </summary>
		public static GuidingChapterItem Item310 => Instance[(short)309];

		/// <summary>
		/// 毒药
		/// </summary>
		public static GuidingChapterItem Item311 => Instance[(short)310];

		/// <summary>
		/// 装备
		/// </summary>
		public static GuidingChapterItem Item312 => Instance[(short)311];

		/// <summary>
		/// 装备负重
		/// </summary>
		public static GuidingChapterItem Item313 => Instance[(short)312];

		/// <summary>
		/// 装备特殊效果
		/// </summary>
		public static GuidingChapterItem Item314 => Instance[(short)313];

		/// <summary>
		/// 兵器
		/// </summary>
		public static GuidingChapterItem Item315 => Instance[(short)314];

		/// <summary>
		/// 兵器属性
		/// </summary>
		public static GuidingChapterItem Item316 => Instance[(short)315];

		/// <summary>
		/// 护具
		/// </summary>
		public static GuidingChapterItem Item317 => Instance[(short)316];

		/// <summary>
		/// 护具属性
		/// </summary>
		public static GuidingChapterItem Item318 => Instance[(short)317];

		/// <summary>
		/// 宝物
		/// </summary>
		public static GuidingChapterItem Item319 => Instance[(short)318];

		/// <summary>
		/// 衣装
		/// </summary>
		public static GuidingChapterItem Item320 => Instance[(short)319];

		/// <summary>
		/// 代步
		/// </summary>
		public static GuidingChapterItem Item321 => Instance[(short)320];

		/// <summary>
		/// 野兽代步
		/// </summary>
		public static GuidingChapterItem Item322 => Instance[(short)321];

		/// <summary>
		/// 代步属性
		/// </summary>
		public static GuidingChapterItem Item323 => Instance[(short)322];

		/// <summary>
		/// 书籍
		/// </summary>
		public static GuidingChapterItem Item324 => Instance[(short)323];

		/// <summary>
		/// 工具
		/// </summary>
		public static GuidingChapterItem Item325 => Instance[(short)324];

		/// <summary>
		/// 引子
		/// </summary>
		public static GuidingChapterItem Item326 => Instance[(short)325];

		/// <summary>
		/// 精制材料
		/// </summary>
		public static GuidingChapterItem Item327 => Instance[(short)326];

		/// <summary>
		/// 心材
		/// </summary>
		public static GuidingChapterItem Item328 => Instance[(short)327];

		/// <summary>
		/// 绳索
		/// </summary>
		public static GuidingChapterItem Item329 => Instance[(short)328];

		/// <summary>
		/// 信鸽
		/// </summary>
		public static GuidingChapterItem Item330 => Instance[(short)329];

		/// <summary>
		/// 神木种子
		/// </summary>
		public static GuidingChapterItem Item331 => Instance[(short)330];

		/// <summary>
		/// 养育神木
		/// </summary>
		public static GuidingChapterItem Item332 => Instance[(short)331];

		/// <summary>
		/// 血露
		/// </summary>
		public static GuidingChapterItem Item333 => Instance[(short)332];

		/// <summary>
		/// 西域珍宝
		/// </summary>
		public static GuidingChapterItem Item334 => Instance[(short)333];

		/// <summary>
		/// 制造物品
		/// </summary>
		public static GuidingChapterItem Item335 => Instance[(short)334];

		/// <summary>
		/// 代制物品
		/// </summary>
		public static GuidingChapterItem Item336 => Instance[(short)335];

		/// <summary>
		/// 修理物品
		/// </summary>
		public static GuidingChapterItem Item337 => Instance[(short)336];

		/// <summary>
		/// 拆解物品
		/// </summary>
		public static GuidingChapterItem Item338 => Instance[(short)337];

		/// <summary>
		/// 精制物品
		/// </summary>
		public static GuidingChapterItem Item339 => Instance[(short)338];

		/// <summary>
		/// 淬毒
		/// </summary>
		public static GuidingChapterItem Item340 => Instance[(short)339];

		/// <summary>
		/// 解毒
		/// </summary>
		public static GuidingChapterItem Item341 => Instance[(short)340];

		/// <summary>
		/// 验毒
		/// </summary>
		public static GuidingChapterItem Item342 => Instance[(short)341];

		/// <summary>
		/// 改制衣装
		/// </summary>
		public static GuidingChapterItem Item343 => Instance[(short)342];

		/// <summary>
		/// 志向
		/// </summary>
		public static GuidingChapterItem Item344 => Instance[(short)343];

		/// <summary>
		/// 志向技能
		/// </summary>
		public static GuidingChapterItem Item345 => Instance[(short)344];

		/// <summary>
		/// 志向有成
		/// </summary>
		public static GuidingChapterItem Item346 => Instance[(short)345];

		/// <summary>
		/// 寻找促织
		/// </summary>
		public static GuidingChapterItem Item347 => Instance[(short)346];

		/// <summary>
		/// 捕捉促织
		/// </summary>
		public static GuidingChapterItem Item348 => Instance[(short)347];

		/// <summary>
		/// 促织属性
		/// </summary>
		public static GuidingChapterItem Item349 => Instance[(short)348];

		/// <summary>
		/// 促织决斗
		/// </summary>
		public static GuidingChapterItem Item350 => Instance[(short)349];

		/// <summary>
		/// 促织战绩
		/// </summary>
		public static GuidingChapterItem Item351 => Instance[(short)350];

		/// <summary>
		/// 遭遇奇遇
		/// </summary>
		public static GuidingChapterItem Item352 => Instance[(short)351];

		/// <summary>
		/// 初入奇遇
		/// </summary>
		public static GuidingChapterItem Item353 => Instance[(short)352];

		/// <summary>
		/// 探索奇遇
		/// </summary>
		public static GuidingChapterItem Item354 => Instance[(short)353];

		/// <summary>
		/// 较艺准备
		/// </summary>
		public static GuidingChapterItem Item355 => Instance[(short)354];

		/// <summary>
		/// 开始较艺
		/// </summary>
		public static GuidingChapterItem Item356 => Instance[(short)355];

		/// <summary>
		/// 使用策略
		/// </summary>
		public static GuidingChapterItem Item357 => Instance[(short)356];

		/// <summary>
		/// 论战
		/// </summary>
		public static GuidingChapterItem Item358 => Instance[(short)357];

		/// <summary>
		/// 较艺胜负
		/// </summary>
		public static GuidingChapterItem Item359 => Instance[(short)358];

		/// <summary>
		/// 较艺压力
		/// </summary>
		public static GuidingChapterItem Item360 => Instance[(short)359];

		/// <summary>
		/// 较艺结算
		/// </summary>
		public static GuidingChapterItem Item361 => Instance[(short)360];

		/// <summary>
		/// 诛魔试炼
		/// </summary>
		public static GuidingChapterItem Item362 => Instance[(short)361];

		/// <summary>
		/// 罗汉开悟
		/// </summary>
		public static GuidingChapterItem Item363 => Instance[(short)362];

		/// <summary>
		/// 独创心法
		/// </summary>
		public static GuidingChapterItem Item364 => Instance[(short)363];

		/// <summary>
		/// 生关死节
		/// </summary>
		public static GuidingChapterItem Item365 => Instance[(short)364];

		/// <summary>
		/// 改正修逆
		/// </summary>
		public static GuidingChapterItem Item366 => Instance[(short)365];

		/// <summary>
		/// 移宫易穴
		/// </summary>
		public static GuidingChapterItem Item367 => Instance[(short)366];

		/// <summary>
		/// 神魔入阵
		/// </summary>
		public static GuidingChapterItem Item368 => Instance[(short)367];

		/// <summary>
		/// 统筹方略
		/// </summary>
		public static GuidingChapterItem Item369 => Instance[(short)368];

		/// <summary>
		/// 寄托奇书
		/// </summary>
		public static GuidingChapterItem Item370 => Instance[(short)369];

		/// <summary>
		/// 奇书断执
		/// </summary>
		public static GuidingChapterItem Item371 => Instance[(short)370];

		/// <summary>
		/// 孤鸾镜水谣
		/// </summary>
		public static GuidingChapterItem Item372 => Instance[(short)371];

		/// <summary>
		/// 造化生人
		/// </summary>
		public static GuidingChapterItem Item373 => Instance[(short)372];

		/// <summary>
		/// 天外游历
		/// </summary>
		public static GuidingChapterItem Item374 => Instance[(short)373];

		/// <summary>
		/// 天枢玄铸
		/// </summary>
		public static GuidingChapterItem Item375 => Instance[(short)374];

		/// <summary>
		/// 驱使古鼎
		/// </summary>
		public static GuidingChapterItem Item376 => Instance[(short)375];

		/// <summary>
		/// 鼎蛟淬身
		/// </summary>
		public static GuidingChapterItem Item377 => Instance[(short)376];

		/// <summary>
		/// 化魂仪式
		/// </summary>
		public static GuidingChapterItem Item378 => Instance[(short)377];

		/// <summary>
		/// 炼制王蛊
		/// </summary>
		public static GuidingChapterItem Item379 => Instance[(short)378];

		/// <summary>
		/// 驱动王蛊
		/// </summary>
		public static GuidingChapterItem Item380 => Instance[(short)379];

		/// <summary>
		/// 奇纹星斗
		/// </summary>
		public static GuidingChapterItem Item381 => Instance[(short)380];

		/// <summary>
		/// 调遣元鸡
		/// </summary>
		public static GuidingChapterItem Item382 => Instance[(short)381];

		/// <summary>
		/// 元鸡灵羽
		/// </summary>
		public static GuidingChapterItem Item383 => Instance[(short)382];

		/// <summary>
		/// 姬穸随行
		/// </summary>
		public static GuidingChapterItem Item384 => Instance[(short)386];

		/// <summary>
		/// 持印汲气
		/// </summary>
		public static GuidingChapterItem Item385 => Instance[(short)383];

		/// <summary>
		/// 三才护阵
		/// </summary>
		public static GuidingChapterItem Item386 => Instance[(short)384];

		/// <summary>
		/// 三魔乱阵
		/// </summary>
		public static GuidingChapterItem Item387 => Instance[(short)385];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static GuidingChapter Instance = new GuidingChapter();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Class", "PartTitle", "PartDesc", "TemplateId", "PartImage", "Encyclopedia" };

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
		_dataArray.Add(new GuidingChapterItem(0, LocalStringManager.GetConfig("GuidingChapter_language", "Name_0"), 0, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_0_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_0_1")
		}, "GuidingChapter_Item1_p1,GuidingChapter_Item1_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_0_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_0_1")
		}, "启程-太吾-太吾传人"));
		_dataArray.Add(new GuidingChapterItem(1, LocalStringManager.GetConfig("GuidingChapter_language", "Name_1"), 0, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_1_0") }, "GuidingChapter_Item2_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_1_0") }, "启程-太吾-太吾传承"));
		_dataArray.Add(new GuidingChapterItem(2, LocalStringManager.GetConfig("GuidingChapter_language", "Name_2"), 0, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_2_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_2_1")
		}, "GuidingChapter_Item3_p1,GuidingChapter_Item3_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_2_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_2_1")
		}, "启程-太吾-太吾传承-生平遗惠"));
		_dataArray.Add(new GuidingChapterItem(3, LocalStringManager.GetConfig("GuidingChapter_language", "Name_3"), 0, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_3_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_3_1")
		}, "GuidingChapter_Item4_p1,GuidingChapter_Item4_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_3_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_3_1")
		}, "启程-太吾-太吾传承-生平遗惠"));
		_dataArray.Add(new GuidingChapterItem(4, LocalStringManager.GetConfig("GuidingChapter_language", "Name_4"), 0, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_4_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_4_1")
		}, "GuidingChapter_Item5_p1,GuidingChapter_Item5_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_4_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_4_1")
		}, "启程-太吾-太吾传人-铭刻"));
		_dataArray.Add(new GuidingChapterItem(5, LocalStringManager.GetConfig("GuidingChapter_language", "Name_5"), 0, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_5_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_5_1")
		}, "GuidingChapter_Item6_p1,GuidingChapter_Item6_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_5_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_5_1")
		}, "启程-相枢-相枢-侵袭进度"));
		_dataArray.Add(new GuidingChapterItem(6, LocalStringManager.GetConfig("GuidingChapter_language", "Name_6"), 0, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_6_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_6_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_6_2")
		}, "GuidingChapter_Item7_p1,GuidingChapter_Item7_p2,GuidingChapter_Item7_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_6_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_6_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_6_2")
		}, "启程-相枢-相枢-入魔"));
		_dataArray.Add(new GuidingChapterItem(7, LocalStringManager.GetConfig("GuidingChapter_language", "Name_7"), 0, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_7_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_7_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_7_2")
		}, "GuidingChapter_Item8_p1,GuidingChapter_Item8_p2,GuidingChapter_Item8_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_7_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_7_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_7_2")
		}, "启程-相枢-相枢-失心人"));
		_dataArray.Add(new GuidingChapterItem(8, LocalStringManager.GetConfig("GuidingChapter_language", "Name_8"), 0, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_8_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_8_1")
		}, "GuidingChapter_Item9_p1,GuidingChapter_Item9_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_8_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_8_1")
		}, "启程-相枢-玄石火灰"));
		_dataArray.Add(new GuidingChapterItem(9, LocalStringManager.GetConfig("GuidingChapter_language", "Name_9"), 0, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_9_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_9_1")
		}, "GuidingChapter_Item10_p1,GuidingChapter_Item10_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_9_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_9_1")
		}, "启程-太吾-太吾传人-伏虞心念"));
		_dataArray.Add(new GuidingChapterItem(10, LocalStringManager.GetConfig("GuidingChapter_language", "Name_10"), 0, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_10_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_10_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_10_2")
		}, "GuidingChapter_Item11_p1,GuidingChapter_Item11_p2,GuidingChapter_Item11_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_10_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_10_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_10_2")
		}, "启程-相枢-剑冢"));
		_dataArray.Add(new GuidingChapterItem(11, LocalStringManager.GetConfig("GuidingChapter_language", "Name_11"), 0, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_11_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_11_1")
		}, "GuidingChapter_Item12_p1,GuidingChapter_Item12_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_11_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_11_1")
		}, "启程-相枢-剑冢-相枢化身"));
		_dataArray.Add(new GuidingChapterItem(12, LocalStringManager.GetConfig("GuidingChapter_language", "Name_12"), 0, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_12_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_12_1")
		}, "GuidingChapter_Item13_p1,GuidingChapter_Item13_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_12_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_12_1")
		}, "启程-相枢-剑冢-神剑碎片"));
		_dataArray.Add(new GuidingChapterItem(13, LocalStringManager.GetConfig("GuidingChapter_language", "Name_13"), 0, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_13_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_13_1")
		}, "GuidingChapter_Item14_p1,GuidingChapter_Item14_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_13_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_13_1")
		}, "启程-相枢-剑冢-破冢化身"));
		_dataArray.Add(new GuidingChapterItem(14, LocalStringManager.GetConfig("GuidingChapter_language", "Name_14"), 0, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_14_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_14_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_14_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_14_3")
		}, "GuidingChapter_Item15_p1,GuidingChapter_Item15_p2,GuidingChapter_Item15_p3,GuidingChapter_Item15_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_14_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_14_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_14_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_14_3")
		}, "启程-相枢-剑冢-紫竹化身"));
		_dataArray.Add(new GuidingChapterItem(15, LocalStringManager.GetConfig("GuidingChapter_language", "Name_15"), 1, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_15_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_15_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_15_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_15_3")
		}, "GuidingChapter_Item16_p1,GuidingChapter_Item16_p2,GuidingChapter_Item16_p3,GuidingChapter_Item16_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_15_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_15_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_15_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_15_3")
		}, "世界-地图-州域与地区"));
		_dataArray.Add(new GuidingChapterItem(16, LocalStringManager.GetConfig("GuidingChapter_language", "Name_16"), 1, obsoleteItem: true, new string[0], null, 0, new string[0], null));
		_dataArray.Add(new GuidingChapterItem(17, LocalStringManager.GetConfig("GuidingChapter_language", "Name_17"), 1, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_17_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_17_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_17_2")
		}, "GuidingChapter_Item18_p1,GuidingChapter_Item18_p2,GuidingChapter_Item18_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_17_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_17_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_17_2")
		}, "世界-地图-州域与地区-旅行"));
		_dataArray.Add(new GuidingChapterItem(18, LocalStringManager.GetConfig("GuidingChapter_language", "Name_18"), 1, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_18_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_18_1")
		}, "GuidingChapter_Item19_p1,GuidingChapter_Item19_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_18_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_18_1")
		}, "世界-地图-州域与地区-地区恩义"));
		_dataArray.Add(new GuidingChapterItem(19, LocalStringManager.GetConfig("GuidingChapter_language", "Name_19"), 1, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_19_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_19_1")
		}, "GuidingChapter_Item20_p1,GuidingChapter_Item20_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_19_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_19_1")
		}, "世界-地图-地格"));
		_dataArray.Add(new GuidingChapterItem(20, LocalStringManager.GetConfig("GuidingChapter_language", "Name_20"), 1, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_20_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_20_1")
		}, "GuidingChapter_Item21_p1,GuidingChapter_Item21_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_20_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_20_1")
		}, "世界-地图-地格移动"));
		_dataArray.Add(new GuidingChapterItem(21, LocalStringManager.GetConfig("GuidingChapter_language", "Name_21"), 1, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_21_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_21_1")
		}, "GuidingChapter_Item22_p1,GuidingChapter_Item22_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_21_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_21_1")
		}, "世界-地图-地格移动-视野"));
		_dataArray.Add(new GuidingChapterItem(22, LocalStringManager.GetConfig("GuidingChapter_language", "Name_22"), 1, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_22_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_22_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_22_2")
		}, "GuidingChapter_Item23_p1,GuidingChapter_Item23_p2,GuidingChapter_Item23_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_22_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_22_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_22_2")
		}, "世界-地图-地格-定居点"));
		_dataArray.Add(new GuidingChapterItem(23, LocalStringManager.GetConfig("GuidingChapter_language", "Name_23"), 1, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_23_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_23_1")
		}, "GuidingChapter_Item24_p1,GuidingChapter_Item24_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_23_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_23_1")
		}, "世界-地图-地格-地格资源"));
		_dataArray.Add(new GuidingChapterItem(24, LocalStringManager.GetConfig("GuidingChapter_language", "Name_24"), 1, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_24_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_24_1")
		}, "GuidingChapter_Item25_p1,GuidingChapter_Item25_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_24_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_24_1")
		}, "世界-地图互动-地格互动-采集"));
		_dataArray.Add(new GuidingChapterItem(25, LocalStringManager.GetConfig("GuidingChapter_language", "Name_25"), 1, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_25_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_25_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_25_2")
		}, "GuidingChapter_Item26_p1,GuidingChapter_Item26_p2,GuidingChapter_Item26_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_25_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_25_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_25_2")
		}, "世界-地图互动-地格互动-拾取遗宝"));
		_dataArray.Add(new GuidingChapterItem(26, LocalStringManager.GetConfig("GuidingChapter_language", "Name_26"), 1, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_26_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_26_1")
		}, "GuidingChapter_Item27_p1,GuidingChapter_Item27_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_26_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_26_1")
		}, "物品-物品与资源-行囊-行囊负重"));
		_dataArray.Add(new GuidingChapterItem(27, LocalStringManager.GetConfig("GuidingChapter_language", "Name_27"), 1, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_27_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_27_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_27_2")
		}, "GuidingChapter_Item28_p1,GuidingChapter_Item28_p2,GuidingChapter_Item28_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_27_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_27_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_27_2")
		}, "世界-地图互动-地格互动-挖掘"));
		_dataArray.Add(new GuidingChapterItem(28, LocalStringManager.GetConfig("GuidingChapter_language", "Name_28"), 1, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_28_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_28_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_28_2")
		}, "GuidingChapter_Item29_p1,GuidingChapter_Item29_p2,GuidingChapter_Item29_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_28_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_28_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_28_2")
		}, "世界-地图-月份更替-精力"));
		_dataArray.Add(new GuidingChapterItem(29, LocalStringManager.GetConfig("GuidingChapter_language", "Name_29"), 1, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_29_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_29_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_29_2")
		}, "GuidingChapter_Item30_p1,GuidingChapter_Item30_p2,GuidingChapter_Item30_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_29_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_29_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_29_2")
		}, "世界-地图-月份更替"));
		_dataArray.Add(new GuidingChapterItem(30, LocalStringManager.GetConfig("GuidingChapter_language", "Name_30"), 1, obsoleteItem: true, new string[0], null, 0, new string[0], null));
		_dataArray.Add(new GuidingChapterItem(31, LocalStringManager.GetConfig("GuidingChapter_language", "Name_31"), 2, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_31_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_31_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_31_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_31_3")
		}, "GuidingChapter_Item32_p1,GuidingChapter_Item32_p2,GuidingChapter_Item32_p3,GuidingChapter_Item32_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_31_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_31_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_31_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_31_3")
		}, "世界-势力-势力"));
		_dataArray.Add(new GuidingChapterItem(32, LocalStringManager.GetConfig("GuidingChapter_language", "Name_32"), 2, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_32_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_32_1")
		}, "GuidingChapter_Item33_p1,GuidingChapter_Item33_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_32_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_32_1")
		}, "世界-势力-势力-势力值"));
		_dataArray.Add(new GuidingChapterItem(33, LocalStringManager.GetConfig("GuidingChapter_language", "Name_33"), 2, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_33_0") }, "GuidingChapter_Item34_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_33_0") }, "世界-势力-势力-晋升"));
		_dataArray.Add(new GuidingChapterItem(34, LocalStringManager.GetConfig("GuidingChapter_language", "Name_34"), 2, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_34_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_34_1")
		}, "GuidingChapter_Item35_p1,GuidingChapter_Item35_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_34_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_34_1")
		}, "世界-势力-守卫"));
		_dataArray.Add(new GuidingChapterItem(35, LocalStringManager.GetConfig("GuidingChapter_language", "Name_35"), 2, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_35_0") }, "GuidingChapter_Item36_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_35_0") }, "世界-势力-法规"));
		_dataArray.Add(new GuidingChapterItem(36, LocalStringManager.GetConfig("GuidingChapter_language", "Name_36"), 2, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_36_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_36_1")
		}, "GuidingChapter_Item37_p1,GuidingChapter_Item37_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_36_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_36_1")
		}, "世界-势力-监牢"));
		_dataArray.Add(new GuidingChapterItem(37, LocalStringManager.GetConfig("GuidingChapter_language", "Name_37"), 2, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_37_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_37_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_37_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_37_3")
		}, "GuidingChapter_Item38_p1,GuidingChapter_Item38_p2,GuidingChapter_Item38_p3,GuidingChapter_Item38_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_37_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_37_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_37_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_37_3")
		}, "世界-势力-监牢-囚犯"));
		_dataArray.Add(new GuidingChapterItem(38, LocalStringManager.GetConfig("GuidingChapter_language", "Name_38"), 2, obsoleteItem: false, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_38_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_38_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_38_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_38_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_38_4")
		}, "GuidingChapter_Item39_p1,GuidingChapter_Item39_p2,GuidingChapter_Item39_p3,GuidingChapter_Item39_p4,GuidingChapter_Item39_p5", 5, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_38_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_38_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_38_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_38_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_38_4")
		}, "世界-势力-法规-悬赏"));
		_dataArray.Add(new GuidingChapterItem(39, LocalStringManager.GetConfig("GuidingChapter_language", "Name_39"), 2, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_39_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_39_1")
		}, "GuidingChapter_Item40_p1,GuidingChapter_Item40_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_39_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_39_1")
		}, "世界-势力-法规-处罚"));
		_dataArray.Add(new GuidingChapterItem(40, LocalStringManager.GetConfig("GuidingChapter_language", "Name_40"), 2, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_40_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_40_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_40_2")
		}, "GuidingChapter_Item41_p1,GuidingChapter_Item41_p2,GuidingChapter_Item41_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_40_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_40_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_40_2")
		}, "世界-势力-库房"));
		_dataArray.Add(new GuidingChapterItem(41, LocalStringManager.GetConfig("GuidingChapter_language", "Name_41"), 2, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_41_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_41_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_41_2")
		}, "GuidingChapter_Item42_p1,GuidingChapter_Item42_p2,GuidingChapter_Item42_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_41_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_41_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_41_2")
		}, "世界-势力-库房-库房交换"));
		_dataArray.Add(new GuidingChapterItem(42, LocalStringManager.GetConfig("GuidingChapter_language", "Name_42"), 2, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_42_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_42_1")
		}, "GuidingChapter_Item43_p1,GuidingChapter_Item43_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_42_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_42_1")
		}, "世界-商会-商会"));
		_dataArray.Add(new GuidingChapterItem(43, LocalStringManager.GetConfig("GuidingChapter_language", "Name_43"), 2, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_43_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_43_1")
		}, "GuidingChapter_Item44_p1,GuidingChapter_Item44_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_43_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_43_1")
		}, "世界-商会-商店等级"));
		_dataArray.Add(new GuidingChapterItem(44, LocalStringManager.GetConfig("GuidingChapter_language", "Name_44"), 2, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_44_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_44_1")
		}, "GuidingChapter_Item45_p1,GuidingChapter_Item45_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_44_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_44_1")
		}, "世界-商会-商店等级-商会好感"));
		_dataArray.Add(new GuidingChapterItem(45, LocalStringManager.GetConfig("GuidingChapter_language", "Name_45"), 2, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_45_0") }, "GuidingChapter_Item46_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_45_0") }, "世界-商会-商会-额外商品"));
		_dataArray.Add(new GuidingChapterItem(46, LocalStringManager.GetConfig("GuidingChapter_language", "Name_46"), 2, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_46_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_46_1")
		}, "GuidingChapter_Item47_p1,GuidingChapter_Item47_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_46_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_46_1")
		}, "世界-商会-商会"));
		_dataArray.Add(new GuidingChapterItem(47, LocalStringManager.GetConfig("GuidingChapter_language", "Name_47"), 2, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_47_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_47_1")
		}, "GuidingChapter_Item48_p1,GuidingChapter_Item48_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_47_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_47_1")
		}, "世界-商会-商队"));
		_dataArray.Add(new GuidingChapterItem(48, LocalStringManager.GetConfig("GuidingChapter_language", "Name_48"), 2, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_48_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_48_1")
		}, "GuidingChapter_Item49_p1,GuidingChapter_Item49_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_48_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_48_1")
		}, "世界-地图互动-敌人"));
		_dataArray.Add(new GuidingChapterItem(49, LocalStringManager.GetConfig("GuidingChapter_language", "Name_49"), 2, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_49_0") }, "GuidingChapter_Item50_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_49_0") }, "世界-地图互动-敌人-相枢爪牙"));
		_dataArray.Add(new GuidingChapterItem(50, LocalStringManager.GetConfig("GuidingChapter_language", "Name_50"), 2, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_50_0") }, "GuidingChapter_Item51_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_50_0") }, "世界-地图互动-敌人-野兽"));
		_dataArray.Add(new GuidingChapterItem(51, LocalStringManager.GetConfig("GuidingChapter_language", "Name_51"), 3, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_51_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_51_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_51_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_51_3")
		}, "GuidingChapter_Item52_p1,GuidingChapter_Item52_p2,GuidingChapter_Item52_p3,GuidingChapter_Item52_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_51_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_51_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_51_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_51_3")
		}, "门派-门派概述-门派"));
		_dataArray.Add(new GuidingChapterItem(52, LocalStringManager.GetConfig("GuidingChapter_language", "Name_52"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_52_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_52_1")
		}, "GuidingChapter_Item53_p1,GuidingChapter_Item53_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_52_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_52_1")
		}, "门派-门派概述-门派"));
		_dataArray.Add(new GuidingChapterItem(53, LocalStringManager.GetConfig("GuidingChapter_language", "Name_53"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_53_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_53_1")
		}, "GuidingChapter_Item54_p1,GuidingChapter_Item54_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_53_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_53_1")
		}, "门派-门派概述-门派-学艺许可"));
		_dataArray.Add(new GuidingChapterItem(54, LocalStringManager.GetConfig("GuidingChapter_language", "Name_54"), 3, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_54_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_54_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_54_2")
		}, "GuidingChapter_Item55_p1,GuidingChapter_Item55_p2,GuidingChapter_Item55_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_54_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_54_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_54_2")
		}, "门派-门派概述-门派-门派修习"));
		_dataArray.Add(new GuidingChapterItem(55, LocalStringManager.GetConfig("GuidingChapter_language", "Name_55"), 3, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_55_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_55_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_55_2")
		}, "GuidingChapter_Item56_p1,GuidingChapter_Item56_p2,GuidingChapter_Item56_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_55_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_55_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_55_2")
		}, "门派-门派概述-门派支持"));
		_dataArray.Add(new GuidingChapterItem(56, LocalStringManager.GetConfig("GuidingChapter_language", "Name_56"), 3, obsoleteItem: true, new string[0], null, 1, new string[0], null));
		_dataArray.Add(new GuidingChapterItem(57, LocalStringManager.GetConfig("GuidingChapter_language", "Name_57"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_57_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_57_1")
		}, "GuidingChapter_Item58_p1,GuidingChapter_Item58_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_57_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_57_1")
		}, "门派-门派概述-地区故事"));
		_dataArray.Add(new GuidingChapterItem(58, LocalStringManager.GetConfig("GuidingChapter_language", "Name_58"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_58_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_58_1")
		}, "GuidingChapter_Item59_p1,GuidingChapter_Item59_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_58_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_58_1")
		}, "门派-门派一览-少林派"));
		_dataArray.Add(new GuidingChapterItem(59, LocalStringManager.GetConfig("GuidingChapter_language", "Name_59"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_59_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_59_1")
		}, "GuidingChapter_Item60_p1,GuidingChapter_Item60_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_59_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_59_1")
		}, "门派-门派一览-峨眉派"));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new GuidingChapterItem(60, LocalStringManager.GetConfig("GuidingChapter_language", "Name_60"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_60_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_60_1")
		}, "GuidingChapter_Item61_p1,GuidingChapter_Item61_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_60_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_60_1")
		}, "门派-门派一览-百花谷"));
		_dataArray.Add(new GuidingChapterItem(61, LocalStringManager.GetConfig("GuidingChapter_language", "Name_61"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_61_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_61_1")
		}, "GuidingChapter_Item62_p1,GuidingChapter_Item62_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_61_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_61_1")
		}, "门派-门派一览-武当派"));
		_dataArray.Add(new GuidingChapterItem(62, LocalStringManager.GetConfig("GuidingChapter_language", "Name_62"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_62_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_62_1")
		}, "GuidingChapter_Item63_p1,GuidingChapter_Item63_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_62_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_62_1")
		}, "门派-门派一览-元山派"));
		_dataArray.Add(new GuidingChapterItem(63, LocalStringManager.GetConfig("GuidingChapter_language", "Name_63"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_63_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_63_1")
		}, "GuidingChapter_Item64_p1,GuidingChapter_Item64_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_63_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_63_1")
		}, "门派-门派一览-狮相门"));
		_dataArray.Add(new GuidingChapterItem(64, LocalStringManager.GetConfig("GuidingChapter_language", "Name_64"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_64_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_64_1")
		}, "GuidingChapter_Item65_p1,GuidingChapter_Item65_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_64_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_64_1")
		}, "门派-门派一览-然山派"));
		_dataArray.Add(new GuidingChapterItem(65, LocalStringManager.GetConfig("GuidingChapter_language", "Name_65"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_65_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_65_1")
		}, "GuidingChapter_Item66_p1,GuidingChapter_Item66_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_65_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_65_1")
		}, "门派-门派一览-璇女派"));
		_dataArray.Add(new GuidingChapterItem(66, LocalStringManager.GetConfig("GuidingChapter_language", "Name_66"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_66_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_66_1")
		}, "GuidingChapter_Item67_p1,GuidingChapter_Item67_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_66_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_66_1")
		}, "门派-门派一览-铸剑山庄"));
		_dataArray.Add(new GuidingChapterItem(67, LocalStringManager.GetConfig("GuidingChapter_language", "Name_67"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_67_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_67_1")
		}, "GuidingChapter_Item68_p1,GuidingChapter_Item68_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_67_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_67_1")
		}, "门派-门派一览-空桑派"));
		_dataArray.Add(new GuidingChapterItem(68, LocalStringManager.GetConfig("GuidingChapter_language", "Name_68"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_68_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_68_1")
		}, "GuidingChapter_Item69_p1,GuidingChapter_Item69_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_68_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_68_1")
		}, "门派-门派一览-金刚宗"));
		_dataArray.Add(new GuidingChapterItem(69, LocalStringManager.GetConfig("GuidingChapter_language", "Name_69"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_69_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_69_1")
		}, "GuidingChapter_Item70_p1,GuidingChapter_Item70_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_69_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_69_1")
		}, "门派-门派一览-五仙教"));
		_dataArray.Add(new GuidingChapterItem(70, LocalStringManager.GetConfig("GuidingChapter_language", "Name_70"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_70_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_70_1")
		}, "GuidingChapter_Item71_p1,GuidingChapter_Item71_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_70_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_70_1")
		}, "门派-门派一览-界青门"));
		_dataArray.Add(new GuidingChapterItem(71, LocalStringManager.GetConfig("GuidingChapter_language", "Name_71"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_71_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_71_1")
		}, "GuidingChapter_Item72_p1,GuidingChapter_Item72_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_71_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_71_1")
		}, "门派-门派一览-伏龙坛"));
		_dataArray.Add(new GuidingChapterItem(72, LocalStringManager.GetConfig("GuidingChapter_language", "Name_72"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_72_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_72_1")
		}, "GuidingChapter_Item73_p1,GuidingChapter_Item73_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_72_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_72_1")
		}, "门派-门派一览-血犼教"));
		_dataArray.Add(new GuidingChapterItem(73, LocalStringManager.GetConfig("GuidingChapter_language", "Name_73"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_73_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_73_1")
		}, "GuidingChapter_Item74_p1,GuidingChapter_Item74_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_73_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_73_1")
		}, "人物-人物信息-姓名"));
		_dataArray.Add(new GuidingChapterItem(74, LocalStringManager.GetConfig("GuidingChapter_language", "Name_74"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_74_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_74_1")
		}, "GuidingChapter_Item75_p1,GuidingChapter_Item75_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_74_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_74_1")
		}, "人物-人物信息-生时"));
		_dataArray.Add(new GuidingChapterItem(75, LocalStringManager.GetConfig("GuidingChapter_language", "Name_75"), 4, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_75_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_75_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_75_2")
		}, "GuidingChapter_Item76_p1,GuidingChapter_Item76_p2,GuidingChapter_Item76_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_75_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_75_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_75_2")
		}, "人物-人物信息-年龄"));
		_dataArray.Add(new GuidingChapterItem(76, LocalStringManager.GetConfig("GuidingChapter_language", "Name_76"), 4, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_76_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_76_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_76_2")
		}, "GuidingChapter_Item77_p1,GuidingChapter_Item77_p2,GuidingChapter_Item77_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_76_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_76_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_76_2")
		}, "人物-人物信息-性别"));
		_dataArray.Add(new GuidingChapterItem(77, LocalStringManager.GetConfig("GuidingChapter_language", "Name_77"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_77_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_77_1")
		}, "GuidingChapter_Item78_p1,GuidingChapter_Item78_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_77_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_77_1")
		}, "人物-人物信息-魅力"));
		_dataArray.Add(new GuidingChapterItem(78, LocalStringManager.GetConfig("GuidingChapter_language", "Name_78"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_78_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_78_1")
		}, "GuidingChapter_Item79_p1,GuidingChapter_Item79_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_78_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_78_1")
		}, "人物-人物信息-魅力-相貌"));
		_dataArray.Add(new GuidingChapterItem(79, LocalStringManager.GetConfig("GuidingChapter_language", "Name_79"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_79_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_79_1")
		}, "GuidingChapter_Item80_p1,GuidingChapter_Item80_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_79_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_79_1")
		}, "人物-人物信息-身份-理想门派"));
		_dataArray.Add(new GuidingChapterItem(80, LocalStringManager.GetConfig("GuidingChapter_language", "Name_80"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_80_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_80_1")
		}, "GuidingChapter_Item81_p1,GuidingChapter_Item81_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_80_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_80_1")
		}, "人物-人物信息-称号"));
		_dataArray.Add(new GuidingChapterItem(81, LocalStringManager.GetConfig("GuidingChapter_language", "Name_81"), 4, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_81_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_81_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_81_2")
		}, "GuidingChapter_Item82_p1,GuidingChapter_Item82_p2,GuidingChapter_Item82_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_81_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_81_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_81_2")
		}, "人物-人物信息-心情"));
		_dataArray.Add(new GuidingChapterItem(82, LocalStringManager.GetConfig("GuidingChapter_language", "Name_82"), 4, obsoleteItem: false, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_82_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_82_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_82_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_82_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_82_4")
		}, "GuidingChapter_Item83_p1,GuidingChapter_Item83_p2,GuidingChapter_Item83_p3,GuidingChapter_Item83_p4,GuidingChapter_Item83_p5", 5, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_82_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_82_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_82_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_82_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_82_4")
		}, "人物-人物信息-好感"));
		_dataArray.Add(new GuidingChapterItem(83, LocalStringManager.GetConfig("GuidingChapter_language", "Name_83"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_83_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_83_1")
		}, "GuidingChapter_Item84_p1,GuidingChapter_Item84_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_83_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_83_1")
		}, "人物-人物信息-好感-戒心"));
		_dataArray.Add(new GuidingChapterItem(84, LocalStringManager.GetConfig("GuidingChapter_language", "Name_84"), 4, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_84_0") }, "GuidingChapter_Item85_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_84_0") }, "人物-人物信息-好感-喜恶"));
		_dataArray.Add(new GuidingChapterItem(85, LocalStringManager.GetConfig("GuidingChapter_language", "Name_85"), 4, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_85_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_85_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_85_2")
		}, "GuidingChapter_Item86_p1,GuidingChapter_Item86_p2,GuidingChapter_Item86_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_85_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_85_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_85_2")
		}, "人物-人物信息-立场"));
		_dataArray.Add(new GuidingChapterItem(86, LocalStringManager.GetConfig("GuidingChapter_language", "Name_86"), 4, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_86_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_86_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_86_2")
		}, "GuidingChapter_Item87_p1,GuidingChapter_Item87_p2,GuidingChapter_Item87_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_86_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_86_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_86_2")
		}, "人物-人物信息-名誉"));
		_dataArray.Add(new GuidingChapterItem(87, LocalStringManager.GetConfig("GuidingChapter_language", "Name_87"), 4, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_87_0") }, "GuidingChapter_Item88_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_87_0") }, "人物-人物信息-轮回"));
		_dataArray.Add(new GuidingChapterItem(88, LocalStringManager.GetConfig("GuidingChapter_language", "Name_88"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_88_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_88_1")
		}, "GuidingChapter_Item89_p1,GuidingChapter_Item89_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_88_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_88_1")
		}, "人物-人物信息-轮回"));
		_dataArray.Add(new GuidingChapterItem(89, LocalStringManager.GetConfig("GuidingChapter_language", "Name_89"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_89_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_89_1")
		}, "GuidingChapter_Item90_p1,GuidingChapter_Item90_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_89_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_89_1")
		}, "人物-人物信息-资质"));
		_dataArray.Add(new GuidingChapterItem(90, LocalStringManager.GetConfig("GuidingChapter_language", "Name_90"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_90_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_90_1")
		}, "GuidingChapter_Item91_p1,GuidingChapter_Item91_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_90_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_90_1")
		}, "人物-人物信息-造诣"));
		_dataArray.Add(new GuidingChapterItem(91, LocalStringManager.GetConfig("GuidingChapter_language", "Name_91"), 4, obsoleteItem: false, new string[7]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_91_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_91_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_91_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_91_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_91_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_91_5"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_91_6")
		}, "GuidingChapter_Item92_p1,GuidingChapter_Item92_p2,GuidingChapter_Item92_p3,GuidingChapter_Item92_p4,GuidingChapter_Item92_p5,GuidingChapter_Item92_p6,GuidingChapter_Item92_p7", 7, new string[7]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_91_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_91_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_91_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_91_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_91_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_91_5"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_91_6")
		}, "人物-属性-主要属性"));
		_dataArray.Add(new GuidingChapterItem(92, LocalStringManager.GetConfig("GuidingChapter_language", "Name_92"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_92_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_92_1")
		}, "GuidingChapter_Item93_p1,GuidingChapter_Item93_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_92_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_92_1")
		}, "人物-属性-主要属性"));
		_dataArray.Add(new GuidingChapterItem(93, LocalStringManager.GetConfig("GuidingChapter_language", "Name_93"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_93_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_93_1")
		}, "GuidingChapter_Item94_p1,GuidingChapter_Item94_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_93_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_93_1")
		}, "人物-属性-战斗属性-攻击属性"));
		_dataArray.Add(new GuidingChapterItem(94, LocalStringManager.GetConfig("GuidingChapter_language", "Name_94"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_94_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_94_1")
		}, "GuidingChapter_Item95_p1,GuidingChapter_Item95_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_94_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_94_1")
		}, "人物-属性-战斗属性-防御属性"));
		_dataArray.Add(new GuidingChapterItem(95, LocalStringManager.GetConfig("GuidingChapter_language", "Name_95"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_95_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_95_1")
		}, "GuidingChapter_Item96_p1,GuidingChapter_Item96_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_95_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_95_1")
		}, "人物-属性-战斗属性-命中属性"));
		_dataArray.Add(new GuidingChapterItem(96, LocalStringManager.GetConfig("GuidingChapter_language", "Name_96"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_96_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_96_1")
		}, "GuidingChapter_Item97_p1,GuidingChapter_Item97_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_96_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_96_1")
		}, "人物-属性-战斗属性-化解属性"));
		_dataArray.Add(new GuidingChapterItem(97, LocalStringManager.GetConfig("GuidingChapter_language", "Name_97"), 4, obsoleteItem: false, new string[6]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_97_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_97_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_97_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_97_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_97_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_97_5")
		}, "GuidingChapter_Item98_p1,GuidingChapter_Item98_p2,GuidingChapter_Item98_p3,GuidingChapter_Item98_p4,GuidingChapter_Item98_p5,GuidingChapter_Item98_p6", 6, new string[6]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_97_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_97_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_97_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_97_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_97_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_97_5")
		}, "人物-属性-战斗属性-次要属性"));
		_dataArray.Add(new GuidingChapterItem(98, LocalStringManager.GetConfig("GuidingChapter_language", "Name_98"), 4, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_98_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_98_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_98_2")
		}, "GuidingChapter_Item99_p1,GuidingChapter_Item99_p2,GuidingChapter_Item99_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_98_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_98_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_98_2")
		}, "人物-属性-特性"));
		_dataArray.Add(new GuidingChapterItem(99, LocalStringManager.GetConfig("GuidingChapter_language", "Name_99"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_99_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_99_1")
		}, "GuidingChapter_Item100_p1,GuidingChapter_Item100_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_99_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_99_1")
		}, "人物-属性-特性-特性倾向"));
		_dataArray.Add(new GuidingChapterItem(100, LocalStringManager.GetConfig("GuidingChapter_language", "Name_100"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_100_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_100_1")
		}, "GuidingChapter_Item101_p1,GuidingChapter_Item101_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_100_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_100_1")
		}, "人物-属性-特性-队伍机略"));
		_dataArray.Add(new GuidingChapterItem(101, LocalStringManager.GetConfig("GuidingChapter_language", "Name_101"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_101_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_101_1")
		}, "GuidingChapter_Item102_p1,GuidingChapter_Item102_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_101_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_101_1")
		}, "人物-属性-七元赋性"));
		_dataArray.Add(new GuidingChapterItem(102, LocalStringManager.GetConfig("GuidingChapter_language", "Name_102"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_102_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_102_1")
		}, "GuidingChapter_Item103_p1,GuidingChapter_Item103_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_102_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_102_1")
		}, "人物-伤病-健康"));
		_dataArray.Add(new GuidingChapterItem(103, LocalStringManager.GetConfig("GuidingChapter_language", "Name_103"), 4, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_103_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_103_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_103_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_103_3")
		}, "GuidingChapter_Item104_p1,GuidingChapter_Item104_p2,GuidingChapter_Item104_p3,GuidingChapter_Item104_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_103_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_103_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_103_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_103_3")
		}, "人物-伤病-健康"));
		_dataArray.Add(new GuidingChapterItem(104, LocalStringManager.GetConfig("GuidingChapter_language", "Name_104"), 4, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_104_0") }, "GuidingChapter_Item105_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_104_0") }, "人物-伤病-健康-寿元"));
		_dataArray.Add(new GuidingChapterItem(105, LocalStringManager.GetConfig("GuidingChapter_language", "Name_105"), 4, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_105_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_105_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_105_2")
		}, "GuidingChapter_Item106_p1,GuidingChapter_Item106_p2,GuidingChapter_Item106_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_105_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_105_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_105_2")
		}, "人物-伤病-伤势"));
		_dataArray.Add(new GuidingChapterItem(106, LocalStringManager.GetConfig("GuidingChapter_language", "Name_106"), 4, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_106_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_106_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_106_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_106_3")
		}, "GuidingChapter_Item107_p1,GuidingChapter_Item107_p2,GuidingChapter_Item107_p3,GuidingChapter_Item107_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_106_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_106_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_106_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_106_3")
		}, "人物-伤病-毒素"));
		_dataArray.Add(new GuidingChapterItem(107, LocalStringManager.GetConfig("GuidingChapter_language", "Name_107"), 4, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_107_0") }, "GuidingChapter_Item108_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_107_0") }, "人物-伤病-毒素-施加毒素"));
		_dataArray.Add(new GuidingChapterItem(108, LocalStringManager.GetConfig("GuidingChapter_language", "Name_108"), 4, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_108_0") }, "GuidingChapter_Item109_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_108_0") }, "人物-伤病-毒素-混合毒素"));
		_dataArray.Add(new GuidingChapterItem(109, LocalStringManager.GetConfig("GuidingChapter_language", "Name_109"), 4, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_109_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_109_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_109_2")
		}, "GuidingChapter_Item110_p1,GuidingChapter_Item110_p2,GuidingChapter_Item110_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_109_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_109_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_109_2")
		}, "人物-伤病-毒素-毒性发作"));
		_dataArray.Add(new GuidingChapterItem(110, LocalStringManager.GetConfig("GuidingChapter_language", "Name_110"), 4, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_110_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_110_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_110_2")
		}, "GuidingChapter_Item111_p1,GuidingChapter_Item111_p2,GuidingChapter_Item111_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_110_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_110_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_110_2")
		}, "人物-伤病-内息"));
		_dataArray.Add(new GuidingChapterItem(111, LocalStringManager.GetConfig("GuidingChapter_language", "Name_111"), 4, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_111_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_111_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_111_2")
		}, "GuidingChapter_Item112_p1,GuidingChapter_Item112_p2,GuidingChapter_Item112_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_111_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_111_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_111_2")
		}, "人物-伤病-蛊虫"));
		_dataArray.Add(new GuidingChapterItem(112, LocalStringManager.GetConfig("GuidingChapter_language", "Name_112"), 4, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_112_0") }, "GuidingChapter_Item113_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_112_0") }, "人物-伤病-蛊虫-蛊引"));
		_dataArray.Add(new GuidingChapterItem(113, LocalStringManager.GetConfig("GuidingChapter_language", "Name_113"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_113_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_113_1")
		}, "GuidingChapter_Item114_p1,GuidingChapter_Item114_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_113_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_113_1")
		}, "人物-伤病-蛊虫"));
		_dataArray.Add(new GuidingChapterItem(114, LocalStringManager.GetConfig("GuidingChapter_language", "Name_114"), 4, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_114_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_114_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_114_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_114_3")
		}, "GuidingChapter_Item115_p1,GuidingChapter_Item115_p2,GuidingChapter_Item115_p3,GuidingChapter_Item115_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_114_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_114_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_114_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_114_3")
		}, "人物-伤病-蛊虫-解蛊"));
		_dataArray.Add(new GuidingChapterItem(115, LocalStringManager.GetConfig("GuidingChapter_language", "Name_115"), 4, obsoleteItem: false, new string[6]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_115_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_115_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_115_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_115_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_115_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_115_5")
		}, "GuidingChapter_Item116_p1,GuidingChapter_Item116_p2,GuidingChapter_Item116_p3,GuidingChapter_Item116_p4,GuidingChapter_Item116_p5,GuidingChapter_Item116_p6", 6, new string[6]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_115_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_115_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_115_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_115_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_115_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_115_5")
		}, "人物-伤病-蛊虫-王蛊"));
		_dataArray.Add(new GuidingChapterItem(116, LocalStringManager.GetConfig("GuidingChapter_language", "Name_116"), 4, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_116_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_116_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_116_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_116_3")
		}, "GuidingChapter_Item117_p1,GuidingChapter_Item117_p2,GuidingChapter_Item117_p3,GuidingChapter_Item117_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_116_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_116_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_116_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_116_3")
		}, "人物-伤病-诊疗"));
		_dataArray.Add(new GuidingChapterItem(117, LocalStringManager.GetConfig("GuidingChapter_language", "Name_117"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_117_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_117_1")
		}, "GuidingChapter_Item118_p1,GuidingChapter_Item118_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_117_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_117_1")
		}, "人物-伤病-服食汲饮"));
		_dataArray.Add(new GuidingChapterItem(118, LocalStringManager.GetConfig("GuidingChapter_language", "Name_118"), 4, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_118_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_118_1")
		}, "GuidingChapter_Item119_p1,GuidingChapter_Item119_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_118_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_118_1")
		}, "物品-物品类型-药毒-丹药"));
		_dataArray.Add(new GuidingChapterItem(119, LocalStringManager.GetConfig("GuidingChapter_language", "Name_119"), 5, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_119_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_119_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_119_2")
		}, "GuidingChapter_Item120_p1,GuidingChapter_Item120_p2,GuidingChapter_Item120_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_119_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_119_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_119_2")
		}, "交互-交互信息-关系"));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new GuidingChapterItem(120, LocalStringManager.GetConfig("GuidingChapter_language", "Name_120"), 5, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_120_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_120_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_120_2")
		}, "GuidingChapter_Item121_p1,GuidingChapter_Item121_p2,GuidingChapter_Item121_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_120_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_120_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_120_2")
		}, "交互-交互信息-关系-爱慕"));
		_dataArray.Add(new GuidingChapterItem(121, LocalStringManager.GetConfig("GuidingChapter_language", "Name_121"), 5, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_121_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_121_1")
		}, "GuidingChapter_Item122_p1,GuidingChapter_Item122_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_121_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_121_1")
		}, "交互-交互信息-关系-仇敌"));
		_dataArray.Add(new GuidingChapterItem(122, LocalStringManager.GetConfig("GuidingChapter_language", "Name_122"), 5, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_122_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_122_1")
		}, "GuidingChapter_Item123_p1,GuidingChapter_Item123_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_122_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_122_1")
		}, "交互-交互信息-关系-族谱"));
		_dataArray.Add(new GuidingChapterItem(123, LocalStringManager.GetConfig("GuidingChapter_language", "Name_123"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_123_0") }, "GuidingChapter_Item124_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_123_0") }, "交互-交互信息-经历"));
		_dataArray.Add(new GuidingChapterItem(124, LocalStringManager.GetConfig("GuidingChapter_language", "Name_124"), 5, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_124_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_124_1")
		}, "GuidingChapter_Item125_p1,GuidingChapter_Item125_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_124_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_124_1")
		}, "交互-交互信息-见闻"));
		_dataArray.Add(new GuidingChapterItem(125, LocalStringManager.GetConfig("GuidingChapter_language", "Name_125"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_125_0") }, "GuidingChapter_Item126_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_125_0") }, "交互-交互信息-见闻-地方见闻"));
		_dataArray.Add(new GuidingChapterItem(126, LocalStringManager.GetConfig("GuidingChapter_language", "Name_126"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_126_0") }, "GuidingChapter_Item127_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_126_0") }, "交互-交互信息-见闻-门派见闻"));
		_dataArray.Add(new GuidingChapterItem(127, LocalStringManager.GetConfig("GuidingChapter_language", "Name_127"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_127_0") }, "GuidingChapter_Item128_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_127_0") }, "交互-交互信息-见闻-技艺见闻"));
		_dataArray.Add(new GuidingChapterItem(128, LocalStringManager.GetConfig("GuidingChapter_language", "Name_128"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_128_0") }, "GuidingChapter_Item129_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_128_0") }, "交互-交互信息-见闻-西域见闻"));
		_dataArray.Add(new GuidingChapterItem(129, LocalStringManager.GetConfig("GuidingChapter_language", "Name_129"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_129_0") }, "GuidingChapter_Item130_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_129_0") }, "交互-交互信息-见闻-剑冢见闻"));
		_dataArray.Add(new GuidingChapterItem(130, LocalStringManager.GetConfig("GuidingChapter_language", "Name_130"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_130_0") }, "GuidingChapter_Item131_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_130_0") }, "交互-交互信息-见闻-志向见闻"));
		_dataArray.Add(new GuidingChapterItem(131, LocalStringManager.GetConfig("GuidingChapter_language", "Name_131"), 5, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_131_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_131_1")
		}, "GuidingChapter_Item132_p1,GuidingChapter_Item132_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_131_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_131_1")
		}, "交互-人物互动-人物互动"));
		_dataArray.Add(new GuidingChapterItem(132, LocalStringManager.GetConfig("GuidingChapter_language", "Name_132"), 5, obsoleteItem: false, new string[6]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_132_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_132_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_132_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_132_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_132_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_132_5")
		}, "GuidingChapter_Item133_p1,GuidingChapter_Item133_p2,GuidingChapter_Item133_p3,GuidingChapter_Item133_p4,GuidingChapter_Item133_p5,GuidingChapter_Item133_p6", 6, new string[6]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_132_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_132_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_132_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_132_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_132_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_132_5")
		}, "交互-人物互动-交谈"));
		_dataArray.Add(new GuidingChapterItem(133, LocalStringManager.GetConfig("GuidingChapter_language", "Name_133"), 5, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_133_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_133_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_133_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_133_3")
		}, "GuidingChapter_Item134_p1,GuidingChapter_Item134_p2,GuidingChapter_Item134_p3,GuidingChapter_Item134_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_133_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_133_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_133_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_133_3")
		}, "物品-物品与资源-交换物资"));
		_dataArray.Add(new GuidingChapterItem(134, LocalStringManager.GetConfig("GuidingChapter_language", "Name_134"), 5, obsoleteItem: false, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_134_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_134_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_134_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_134_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_134_4")
		}, "GuidingChapter_Item135_p1,GuidingChapter_Item135_p2,GuidingChapter_Item135_p3,GuidingChapter_Item135_p4,GuidingChapter_Item135_p5", 5, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_134_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_134_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_134_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_134_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_134_4")
		}, "交互-人物互动-比试"));
		_dataArray.Add(new GuidingChapterItem(135, LocalStringManager.GetConfig("GuidingChapter_language", "Name_135"), 5, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_135_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_135_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_135_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_135_3")
		}, "GuidingChapter_Item136_p1,GuidingChapter_Item136_p2,GuidingChapter_Item136_p3,GuidingChapter_Item136_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_135_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_135_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_135_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_135_3")
		}, "交互-人物互动-修习-私下请教"));
		_dataArray.Add(new GuidingChapterItem(136, LocalStringManager.GetConfig("GuidingChapter_language", "Name_136"), 5, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_136_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_136_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_136_2")
		}, "GuidingChapter_Item137_p1,GuidingChapter_Item137_p2,GuidingChapter_Item137_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_136_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_136_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_136_2")
		}, "交互-人物互动-修习-交换私人藏书"));
		_dataArray.Add(new GuidingChapterItem(137, LocalStringManager.GetConfig("GuidingChapter_language", "Name_137"), 5, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_137_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_137_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_137_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_137_3")
		}, "GuidingChapter_Item138_p1,GuidingChapter_Item138_p2,GuidingChapter_Item138_p3,GuidingChapter_Item138_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_137_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_137_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_137_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_137_3")
		}, "交互-人物互动-修习"));
		_dataArray.Add(new GuidingChapterItem(138, LocalStringManager.GetConfig("GuidingChapter_language", "Name_138"), 5, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_138_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_138_1")
		}, "GuidingChapter_Item139_p1,GuidingChapter_Item139_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_138_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_138_1")
		}, "交互-人物互动-亲近-邀为同道"));
		_dataArray.Add(new GuidingChapterItem(139, LocalStringManager.GetConfig("GuidingChapter_language", "Name_139"), 5, obsoleteItem: false, new string[10]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_139_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_139_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_139_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_139_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_139_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_139_5"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_139_6"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_139_7"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_139_8"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_139_9")
		}, "GuidingChapter_Item140_p1,GuidingChapter_Item140_p2,GuidingChapter_Item140_p3,GuidingChapter_Item140_p4,GuidingChapter_Item140_p5,GuidingChapter_Item140_p6,GuidingChapter_Item140_p7,GuidingChapter_Item140_p8,GuidingChapter_Item140_p9,GuidingChapter_Item140_p10", 10, new string[10]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_139_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_139_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_139_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_139_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_139_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_139_5"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_139_6"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_139_7"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_139_8"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_139_9")
		}, "交互-人物互动-亲近"));
		_dataArray.Add(new GuidingChapterItem(140, LocalStringManager.GetConfig("GuidingChapter_language", "Name_140"), 5, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_140_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_140_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_140_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_140_3")
		}, "GuidingChapter_Item141_p1,GuidingChapter_Item141_p2,GuidingChapter_Item141_p3,GuidingChapter_Item141_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_140_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_140_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_140_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_140_3")
		}, "交互-人物互动-敌对"));
		_dataArray.Add(new GuidingChapterItem(141, LocalStringManager.GetConfig("GuidingChapter_language", "Name_141"), 5, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_141_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_141_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_141_2")
		}, "GuidingChapter_Item142_p1,GuidingChapter_Item142_p2,GuidingChapter_Item142_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_141_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_141_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_141_2")
		}, "交互-人物互动-身份互动-施舍银钱"));
		_dataArray.Add(new GuidingChapterItem(142, LocalStringManager.GetConfig("GuidingChapter_language", "Name_142"), 5, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_142_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_142_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_142_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_142_3")
		}, "GuidingChapter_Item143_p1,GuidingChapter_Item143_p2,GuidingChapter_Item143_p3,GuidingChapter_Item143_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_142_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_142_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_142_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_142_3")
		}, "交互-人物互动-身份互动-采买鲜果"));
		_dataArray.Add(new GuidingChapterItem(143, LocalStringManager.GetConfig("GuidingChapter_language", "Name_143"), 5, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_143_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_143_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_143_2")
		}, "GuidingChapter_Item144_p1,GuidingChapter_Item144_p2,GuidingChapter_Item144_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_143_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_143_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_143_2")
		}, "交互-人物互动-身份互动-梳头修面"));
		_dataArray.Add(new GuidingChapterItem(144, LocalStringManager.GetConfig("GuidingChapter_language", "Name_144"), 5, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_144_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_144_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_144_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_144_3")
		}, "GuidingChapter_Item145_p1,GuidingChapter_Item145_p2,GuidingChapter_Item145_p3,GuidingChapter_Item145_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_144_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_144_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_144_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_144_3")
		}, "交互-人物互动-身份互动-修补物品"));
		_dataArray.Add(new GuidingChapterItem(145, LocalStringManager.GetConfig("GuidingChapter_language", "Name_145"), 5, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_145_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_145_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_145_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_145_3")
		}, "GuidingChapter_Item146_p1,GuidingChapter_Item146_p2,GuidingChapter_Item146_p3,GuidingChapter_Item146_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_145_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_145_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_145_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_145_3")
		}, "交互-人物互动-身份互动-诊疗伤病"));
		_dataArray.Add(new GuidingChapterItem(146, LocalStringManager.GetConfig("GuidingChapter_language", "Name_146"), 5, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_146_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_146_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_146_2")
		}, "GuidingChapter_Item147_p1,GuidingChapter_Item147_p2,GuidingChapter_Item147_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_146_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_146_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_146_2")
		}, "交互-人物互动-身份互动-浏览货物"));
		_dataArray.Add(new GuidingChapterItem(147, LocalStringManager.GetConfig("GuidingChapter_language", "Name_147"), 5, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_147_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_147_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_147_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_147_3")
		}, "GuidingChapter_Item148_p1,GuidingChapter_Item148_p2,GuidingChapter_Item148_p3,GuidingChapter_Item148_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_147_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_147_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_147_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_147_3")
		}, "交互-人物互动-身份互动-诗画怡情"));
		_dataArray.Add(new GuidingChapterItem(148, LocalStringManager.GetConfig("GuidingChapter_language", "Name_148"), 5, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_148_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_148_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_148_2")
		}, "GuidingChapter_Item149_p1,GuidingChapter_Item149_p2,GuidingChapter_Item149_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_148_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_148_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_148_2")
		}, "交互-人物互动-身份互动-安定文化"));
		_dataArray.Add(new GuidingChapterItem(149, LocalStringManager.GetConfig("GuidingChapter_language", "Name_149"), 5, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_149_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_149_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_149_2")
		}, "GuidingChapter_Item150_p1,GuidingChapter_Item150_p2,GuidingChapter_Item150_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_149_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_149_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_149_2")
		}, "交互-人物互动-身份互动-牵线搭桥"));
		_dataArray.Add(new GuidingChapterItem(150, LocalStringManager.GetConfig("GuidingChapter_language", "Name_150"), 5, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_150_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_150_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_150_2")
		}, "GuidingChapter_Item151_p1,GuidingChapter_Item151_p2,GuidingChapter_Item151_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_150_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_150_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_150_2")
		}, "交互-人物互动-身份互动-推恩施义"));
		_dataArray.Add(new GuidingChapterItem(151, LocalStringManager.GetConfig("GuidingChapter_language", "Name_151"), 5, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_151_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_151_1")
		}, "GuidingChapter_Item152_p1,GuidingChapter_Item152_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_151_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_151_1")
		}, "交互-人物互动-身份互动-州府法规"));
		_dataArray.Add(new GuidingChapterItem(152, LocalStringManager.GetConfig("GuidingChapter_language", "Name_152"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_152_0") }, "GuidingChapter_Item153_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_152_0") }, "交互-人物互动-身份互动-荐送弟子"));
		_dataArray.Add(new GuidingChapterItem(153, LocalStringManager.GetConfig("GuidingChapter_language", "Name_153"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_153_0") }, "GuidingChapter_Item154_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_153_0") }, "交互-人物互动-门派恩义互动-面壁阅经"));
		_dataArray.Add(new GuidingChapterItem(154, LocalStringManager.GetConfig("GuidingChapter_language", "Name_154"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_154_0") }, "GuidingChapter_Item155_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_154_0") }, "交互-人物互动-门派恩义互动-天府之国"));
		_dataArray.Add(new GuidingChapterItem(155, LocalStringManager.GetConfig("GuidingChapter_language", "Name_155"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_155_0") }, "GuidingChapter_Item156_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_155_0") }, "交互-人物互动-门派恩义互动-起死回生"));
		_dataArray.Add(new GuidingChapterItem(156, LocalStringManager.GetConfig("GuidingChapter_language", "Name_156"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_156_0") }, "GuidingChapter_Item157_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_156_0") }, "交互-人物互动-门派恩义互动-七星调元"));
		_dataArray.Add(new GuidingChapterItem(157, LocalStringManager.GetConfig("GuidingChapter_language", "Name_157"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_157_0") }, "GuidingChapter_Item158_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_157_0") }, "交互-人物互动-门派恩义互动-石牢静坐"));
		_dataArray.Add(new GuidingChapterItem(158, LocalStringManager.GetConfig("GuidingChapter_language", "Name_158"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_158_0") }, "GuidingChapter_Item159_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_158_0") }, "交互-人物互动-门派恩义互动-散播威名"));
		_dataArray.Add(new GuidingChapterItem(159, LocalStringManager.GetConfig("GuidingChapter_language", "Name_159"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_159_0") }, "GuidingChapter_Item160_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_159_0") }, "交互-人物互动-门派恩义互动-王禅典籍"));
		_dataArray.Add(new GuidingChapterItem(160, LocalStringManager.GetConfig("GuidingChapter_language", "Name_160"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_160_0") }, "GuidingChapter_Item161_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_160_0") }, "交互-人物互动-门派恩义互动-玉镜沉思"));
		_dataArray.Add(new GuidingChapterItem(161, LocalStringManager.GetConfig("GuidingChapter_language", "Name_161"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_161_0") }, "GuidingChapter_Item162_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_161_0") }, "交互-人物互动-门派恩义互动-欧冶古具"));
		_dataArray.Add(new GuidingChapterItem(162, LocalStringManager.GetConfig("GuidingChapter_language", "Name_162"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_162_0") }, "GuidingChapter_Item163_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_162_0") }, "交互-人物互动-门派恩义互动-铸剑试炼"));
		_dataArray.Add(new GuidingChapterItem(163, LocalStringManager.GetConfig("GuidingChapter_language", "Name_163"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_163_0") }, "GuidingChapter_Item164_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_163_0") }, "交互-人物互动-门派恩义互动-秘药延寿"));
		_dataArray.Add(new GuidingChapterItem(164, LocalStringManager.GetConfig("GuidingChapter_language", "Name_164"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_164_0") }, "GuidingChapter_Item165_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_164_0") }, "交互-人物互动-门派恩义互动-金刚秘法"));
		_dataArray.Add(new GuidingChapterItem(165, LocalStringManager.GetConfig("GuidingChapter_language", "Name_165"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_165_0") }, "GuidingChapter_Item166_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_165_0") }, "交互-人物互动-门派恩义互动-五圣秘浴"));
		_dataArray.Add(new GuidingChapterItem(166, LocalStringManager.GetConfig("GuidingChapter_language", "Name_166"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_166_0") }, "GuidingChapter_Item167_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_166_0") }, "交互-人物互动-门派恩义互动-委托暗杀"));
		_dataArray.Add(new GuidingChapterItem(167, LocalStringManager.GetConfig("GuidingChapter_language", "Name_167"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_167_0") }, "GuidingChapter_Item168_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_167_0") }, "交互-人物互动-门派恩义互动-龙岛忠仆"));
		_dataArray.Add(new GuidingChapterItem(168, LocalStringManager.GetConfig("GuidingChapter_language", "Name_168"), 5, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_168_0") }, "GuidingChapter_Item169_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_168_0") }, "交互-人物互动-门派恩义互动-血池秘法"));
		_dataArray.Add(new GuidingChapterItem(169, LocalStringManager.GetConfig("GuidingChapter_language", "Name_169"), 5, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_169_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_169_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_169_2")
		}, "GuidingChapter_Item170_p1,GuidingChapter_Item170_p2,GuidingChapter_Item170_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_169_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_169_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_169_2")
		}, "交互-其他交互-同道"));
		_dataArray.Add(new GuidingChapterItem(170, LocalStringManager.GetConfig("GuidingChapter_language", "Name_170"), 5, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_170_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_170_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_170_2")
		}, "GuidingChapter_Item171_p1,GuidingChapter_Item171_p2,GuidingChapter_Item171_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_170_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_170_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_170_2")
		}, "交互-其他交互-俘虏"));
		_dataArray.Add(new GuidingChapterItem(171, LocalStringManager.GetConfig("GuidingChapter_language", "Name_171"), 5, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_171_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_171_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_171_2")
		}, "GuidingChapter_Item172_p1,GuidingChapter_Item172_p2,GuidingChapter_Item172_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_171_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_171_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_171_2")
		}, "交互-其他交互-生育"));
		_dataArray.Add(new GuidingChapterItem(172, LocalStringManager.GetConfig("GuidingChapter_language", "Name_172"), 5, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_172_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_172_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_172_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_172_3")
		}, "GuidingChapter_Item173_p1,GuidingChapter_Item173_p2,GuidingChapter_Item173_p3,GuidingChapter_Item173_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_172_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_172_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_172_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_172_3")
		}, "交互-其他交互-生育-怀孕"));
		_dataArray.Add(new GuidingChapterItem(173, LocalStringManager.GetConfig("GuidingChapter_language", "Name_173"), 5, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_173_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_173_1")
		}, "GuidingChapter_Item174_p1,GuidingChapter_Item174_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_173_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_173_1")
		}, "交互-其他交互-生育-养育事件"));
		_dataArray.Add(new GuidingChapterItem(174, LocalStringManager.GetConfig("GuidingChapter_language", "Name_174"), 5, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_174_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_174_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_174_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_174_3")
		}, "GuidingChapter_Item175_p1,GuidingChapter_Item175_p2,GuidingChapter_Item175_p3,GuidingChapter_Item175_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_174_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_174_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_174_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_174_3")
		}, "世界-地图-坟墓"));
		_dataArray.Add(new GuidingChapterItem(175, LocalStringManager.GetConfig("GuidingChapter_language", "Name_175"), 5, obsoleteItem: true, new string[0], null, 1, new string[0], null));
		_dataArray.Add(new GuidingChapterItem(176, LocalStringManager.GetConfig("GuidingChapter_language", "Name_176"), 5, obsoleteItem: true, new string[0], null, 1, new string[0], null));
		_dataArray.Add(new GuidingChapterItem(177, LocalStringManager.GetConfig("GuidingChapter_language", "Name_177"), 5, obsoleteItem: true, new string[0], null, 1, new string[0], null));
		_dataArray.Add(new GuidingChapterItem(178, LocalStringManager.GetConfig("GuidingChapter_language", "Name_178"), 6, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_178_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_178_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_178_2")
		}, "GuidingChapter_Item179_p1,GuidingChapter_Item179_p2,GuidingChapter_Item179_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_178_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_178_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_178_2")
		}, "修习-技艺-技艺"));
		_dataArray.Add(new GuidingChapterItem(179, LocalStringManager.GetConfig("GuidingChapter_language", "Name_179"), 6, obsoleteItem: false, new string[7]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_179_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_179_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_179_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_179_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_179_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_179_5"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_179_6")
		}, "GuidingChapter_Item180_p1,GuidingChapter_Item180_p2,GuidingChapter_Item180_p3,GuidingChapter_Item180_p4,GuidingChapter_Item180_p5,GuidingChapter_Item180_p6,GuidingChapter_Item180_p7", 7, new string[7]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_179_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_179_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_179_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_179_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_179_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_179_5"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_179_6")
		}, "修习-武学-功法"));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new GuidingChapterItem(180, LocalStringManager.GetConfig("GuidingChapter_language", "Name_180"), 6, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_180_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_180_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_180_2")
		}, "GuidingChapter_Item181_p1,GuidingChapter_Item181_p2,GuidingChapter_Item181_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_180_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_180_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_180_2")
		}, "修习-修习方式-研读书籍"));
		_dataArray.Add(new GuidingChapterItem(181, LocalStringManager.GetConfig("GuidingChapter_language", "Name_181"), 6, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_181_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_181_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_181_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_181_3")
		}, "GuidingChapter_Item182_p1,GuidingChapter_Item182_p2,GuidingChapter_Item182_p3,GuidingChapter_Item182_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_181_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_181_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_181_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_181_3")
		}, "修习-修习方式-研读书籍-参考书籍"));
		_dataArray.Add(new GuidingChapterItem(182, LocalStringManager.GetConfig("GuidingChapter_language", "Name_182"), 6, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_182_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_182_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_182_2")
		}, "GuidingChapter_Item183_p1,GuidingChapter_Item183_p2,GuidingChapter_Item183_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_182_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_182_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_182_2")
		}, "修习-武学-突破-总纲"));
		_dataArray.Add(new GuidingChapterItem(183, LocalStringManager.GetConfig("GuidingChapter_language", "Name_183"), 6, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_183_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_183_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_183_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_183_3")
		}, "GuidingChapter_Item184_p1,GuidingChapter_Item184_p2,GuidingChapter_Item184_p3,GuidingChapter_Item184_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_183_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_183_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_183_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_183_3")
		}, "修习-技艺-技艺"));
		_dataArray.Add(new GuidingChapterItem(184, LocalStringManager.GetConfig("GuidingChapter_language", "Name_184"), 6, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_184_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_184_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_184_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_184_3")
		}, "GuidingChapter_Item185_p1,GuidingChapter_Item185_p2,GuidingChapter_Item185_p3,GuidingChapter_Item185_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_184_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_184_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_184_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_184_3")
		}, "修习-修习方式-周天运转"));
		_dataArray.Add(new GuidingChapterItem(185, LocalStringManager.GetConfig("GuidingChapter_language", "Name_185"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_185_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_185_1")
		}, "GuidingChapter_Item186_p1,GuidingChapter_Item186_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_185_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_185_1")
		}, "修习-修习方式-周天运转-辅助内功"));
		_dataArray.Add(new GuidingChapterItem(186, LocalStringManager.GetConfig("GuidingChapter_language", "Name_186"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_186_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_186_1")
		}, "GuidingChapter_Item187_p1,GuidingChapter_Item187_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_186_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_186_1")
		}, "修习-修习方式-研读书籍-灵光一闪"));
		_dataArray.Add(new GuidingChapterItem(187, LocalStringManager.GetConfig("GuidingChapter_language", "Name_187"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_187_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_187_1")
		}, "GuidingChapter_Item188_p1,GuidingChapter_Item188_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_187_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_187_1")
		}, "修习-修习方式-研读书籍-研读策略"));
		_dataArray.Add(new GuidingChapterItem(188, LocalStringManager.GetConfig("GuidingChapter_language", "Name_188"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_188_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_188_1")
		}, "GuidingChapter_Item189_p1,GuidingChapter_Item189_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_188_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_188_1")
		}, "修习-修习方式-周天运转-天人感应"));
		_dataArray.Add(new GuidingChapterItem(189, LocalStringManager.GetConfig("GuidingChapter_language", "Name_189"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_189_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_189_1")
		}, "GuidingChapter_Item190_p1,GuidingChapter_Item190_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_189_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_189_1")
		}, "修习-修习方式-周天运转-周天策略"));
		_dataArray.Add(new GuidingChapterItem(190, LocalStringManager.GetConfig("GuidingChapter_language", "Name_190"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_190_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_190_1")
		}, "GuidingChapter_Item191_p1,GuidingChapter_Item191_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_190_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_190_1")
		}, "修习-修习方式-研读书籍-专心致志"));
		_dataArray.Add(new GuidingChapterItem(191, LocalStringManager.GetConfig("GuidingChapter_language", "Name_191"), 6, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_191_0") }, "GuidingChapter_Item192_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_191_0") }, "修习-武学-功法-心法效果"));
		_dataArray.Add(new GuidingChapterItem(192, LocalStringManager.GetConfig("GuidingChapter_language", "Name_192"), 6, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_192_0") }, "GuidingChapter_Item193_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_192_0") }, "修习-武学-功法-内外功比例"));
		_dataArray.Add(new GuidingChapterItem(193, LocalStringManager.GetConfig("GuidingChapter_language", "Name_193"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_193_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_193_1")
		}, "GuidingChapter_Item194_p1,GuidingChapter_Item194_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_193_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_193_1")
		}, "修习-武学-突破"));
		_dataArray.Add(new GuidingChapterItem(194, LocalStringManager.GetConfig("GuidingChapter_language", "Name_194"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_194_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_194_1")
		}, "GuidingChapter_Item195_p1,GuidingChapter_Item195_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_194_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_194_1")
		}, "修习-武学-突破"));
		_dataArray.Add(new GuidingChapterItem(195, LocalStringManager.GetConfig("GuidingChapter_language", "Name_195"), 6, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_195_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_195_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_195_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_195_3")
		}, "GuidingChapter_Item196_p1,GuidingChapter_Item196_p2,GuidingChapter_Item196_p3,GuidingChapter_Item196_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_195_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_195_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_195_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_195_3")
		}, "修习-武学-突破-突破格"));
		_dataArray.Add(new GuidingChapterItem(196, LocalStringManager.GetConfig("GuidingChapter_language", "Name_196"), 6, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_196_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_196_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_196_2")
		}, "GuidingChapter_Item197_p1,GuidingChapter_Item197_p2,GuidingChapter_Item197_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_196_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_196_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_196_2")
		}, "修习-武学-突破-天资上限"));
		_dataArray.Add(new GuidingChapterItem(197, LocalStringManager.GetConfig("GuidingChapter_language", "Name_197"), 6, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_197_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_197_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_197_2")
		}, "GuidingChapter_Item198_p1,GuidingChapter_Item198_p2,GuidingChapter_Item198_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_197_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_197_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_197_2")
		}, "修习-武学-突破-突破格"));
		_dataArray.Add(new GuidingChapterItem(198, LocalStringManager.GetConfig("GuidingChapter_language", "Name_198"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_198_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_198_1")
		}, "GuidingChapter_Item199_p1,GuidingChapter_Item199_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_198_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_198_1")
		}, "修习-武学-玄机"));
		_dataArray.Add(new GuidingChapterItem(199, LocalStringManager.GetConfig("GuidingChapter_language", "Name_199"), 6, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_199_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_199_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_199_2")
		}, "GuidingChapter_Item200_p1,GuidingChapter_Item200_p2,GuidingChapter_Item200_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_199_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_199_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_199_2")
		}, "修习-武学-玄机-参悟玄机"));
		_dataArray.Add(new GuidingChapterItem(200, LocalStringManager.GetConfig("GuidingChapter_language", "Name_200"), 6, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_200_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_200_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_200_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_200_3")
		}, "GuidingChapter_Item201_p1,GuidingChapter_Item201_p2,GuidingChapter_Item201_p3,GuidingChapter_Item201_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_200_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_200_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_200_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_200_3")
		}, "修习-武学-突破"));
		_dataArray.Add(new GuidingChapterItem(201, LocalStringManager.GetConfig("GuidingChapter_language", "Name_201"), 6, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_201_0") }, "GuidingChapter_Item202_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_201_0") }, "修习-武学-功法-五行属性"));
		_dataArray.Add(new GuidingChapterItem(202, LocalStringManager.GetConfig("GuidingChapter_language", "Name_202"), 6, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_202_0") }, "GuidingChapter_Item203_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_202_0") }, "修习-武学-功法-威力"));
		_dataArray.Add(new GuidingChapterItem(203, LocalStringManager.GetConfig("GuidingChapter_language", "Name_203"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_203_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_203_1")
		}, "GuidingChapter_Item204_p1,GuidingChapter_Item204_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_203_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_203_1")
		}, "修习-武学-功法-发挥需求"));
		_dataArray.Add(new GuidingChapterItem(204, LocalStringManager.GetConfig("GuidingChapter_language", "Name_204"), 6, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_204_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_204_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_204_2")
		}, "GuidingChapter_Item205_p1,GuidingChapter_Item205_p2,GuidingChapter_Item205_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_204_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_204_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_204_2")
		}, "修习-武学-运功"));
		_dataArray.Add(new GuidingChapterItem(205, LocalStringManager.GetConfig("GuidingChapter_language", "Name_205"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_205_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_205_1")
		}, "GuidingChapter_Item206_p1,GuidingChapter_Item206_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_205_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_205_1")
		}, "修习-武学-运功-精解"));
		_dataArray.Add(new GuidingChapterItem(206, LocalStringManager.GetConfig("GuidingChapter_language", "Name_206"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_206_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_206_1")
		}, "GuidingChapter_Item207_p1,GuidingChapter_Item207_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_206_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_206_1")
		}, "修习-武学-功法-运功效果"));
		_dataArray.Add(new GuidingChapterItem(207, LocalStringManager.GetConfig("GuidingChapter_language", "Name_207"), 6, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_207_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_207_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_207_2")
		}, "GuidingChapter_Item208_p1,GuidingChapter_Item208_p2,GuidingChapter_Item208_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_207_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_207_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_207_2")
		}, "修习-内力-精纯境界"));
		_dataArray.Add(new GuidingChapterItem(208, LocalStringManager.GetConfig("GuidingChapter_language", "Name_208"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_208_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_208_1")
		}, "GuidingChapter_Item209_p1,GuidingChapter_Item209_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_208_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_208_1")
		}, "修习-内力-内力"));
		_dataArray.Add(new GuidingChapterItem(209, LocalStringManager.GetConfig("GuidingChapter_language", "Name_209"), 6, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_209_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_209_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_209_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_209_3")
		}, "GuidingChapter_Item210_p1,GuidingChapter_Item210_p2,GuidingChapter_Item210_p3,GuidingChapter_Item210_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_209_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_209_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_209_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_209_3")
		}, "修习-内力-内力-内力五行"));
		_dataArray.Add(new GuidingChapterItem(210, LocalStringManager.GetConfig("GuidingChapter_language", "Name_210"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_210_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_210_1")
		}, "GuidingChapter_Item211_p1,GuidingChapter_Item211_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_210_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_210_1")
		}, "修习-内力-内力-内力冲克"));
		_dataArray.Add(new GuidingChapterItem(211, LocalStringManager.GetConfig("GuidingChapter_language", "Name_211"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_211_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_211_1")
		}, "GuidingChapter_Item212_p1,GuidingChapter_Item212_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_211_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_211_1")
		}, "修习-内力-真气"));
		_dataArray.Add(new GuidingChapterItem(212, LocalStringManager.GetConfig("GuidingChapter_language", "Name_212"), 6, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_212_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_212_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_212_2")
		}, "GuidingChapter_Item213_p1,GuidingChapter_Item213_p2,GuidingChapter_Item213_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_212_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_212_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_212_2")
		}, "修习-奇书宝典-奇书"));
		_dataArray.Add(new GuidingChapterItem(213, LocalStringManager.GetConfig("GuidingChapter_language", "Name_213"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_213_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_213_1")
		}, "GuidingChapter_Item214_p1,GuidingChapter_Item214_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_213_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_213_1")
		}, "修习-奇书宝典-奇书-争夺奇书"));
		_dataArray.Add(new GuidingChapterItem(214, LocalStringManager.GetConfig("GuidingChapter_language", "Name_214"), 6, obsoleteItem: true, new string[0], null, 0, new string[0], null));
		_dataArray.Add(new GuidingChapterItem(215, LocalStringManager.GetConfig("GuidingChapter_language", "Name_215"), 6, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_215_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_215_1")
		}, "GuidingChapter_Item216_p1,GuidingChapter_Item216_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_215_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_215_1")
		}, "修习-奇书宝典-解读奇书"));
		_dataArray.Add(new GuidingChapterItem(216, LocalStringManager.GetConfig("GuidingChapter_language", "Name_216"), 6, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_216_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_216_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_216_2")
		}, "GuidingChapter_Item217_p1,GuidingChapter_Item217_p2,GuidingChapter_Item217_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_216_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_216_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_216_2")
		}, "修习-奇书宝典-奇书执迷"));
		_dataArray.Add(new GuidingChapterItem(217, LocalStringManager.GetConfig("GuidingChapter_language", "Name_217"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_217_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_217_1")
		}, "GuidingChapter_Item218_p1,GuidingChapter_Item218_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_217_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_217_1")
		}, "战斗-战斗基础-战斗类型"));
		_dataArray.Add(new GuidingChapterItem(218, LocalStringManager.GetConfig("GuidingChapter_language", "Name_218"), 7, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_218_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_218_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_218_2")
		}, "GuidingChapter_Item219_p1,GuidingChapter_Item219_p2,GuidingChapter_Item219_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_218_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_218_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_218_2")
		}, "战斗-战斗基础-战斗流程-战前准备"));
		_dataArray.Add(new GuidingChapterItem(219, LocalStringManager.GetConfig("GuidingChapter_language", "Name_219"), 7, obsoleteItem: true, new string[0], null, 0, new string[0], null));
		_dataArray.Add(new GuidingChapterItem(220, LocalStringManager.GetConfig("GuidingChapter_language", "Name_220"), 7, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_220_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_220_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_220_2")
		}, "GuidingChapter_Item221_p1,GuidingChapter_Item221_p2,GuidingChapter_Item221_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_220_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_220_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_220_2")
		}, "战斗-战斗基础-战斗流程-战利品"));
		_dataArray.Add(new GuidingChapterItem(221, LocalStringManager.GetConfig("GuidingChapter_language", "Name_221"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_221_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_221_1")
		}, "GuidingChapter_Item222_p1,GuidingChapter_Item222_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_221_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_221_1")
		}, "战斗-距离与移动-距离"));
		_dataArray.Add(new GuidingChapterItem(222, LocalStringManager.GetConfig("GuidingChapter_language", "Name_222"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_222_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_222_1")
		}, "GuidingChapter_Item223_p1,GuidingChapter_Item223_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_222_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_222_1")
		}, "战斗-攻击与防御-兵器攻击"));
		_dataArray.Add(new GuidingChapterItem(223, LocalStringManager.GetConfig("GuidingChapter_language", "Name_223"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_223_0") }, "GuidingChapter_Item224_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_223_0") }, "战斗-攻击与防御-兵器攻击-招式"));
		_dataArray.Add(new GuidingChapterItem(224, LocalStringManager.GetConfig("GuidingChapter_language", "Name_224"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_224_0") }, "GuidingChapter_Item225_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_224_0") }, "战斗-攻击与防御-兵器攻击-追击"));
		_dataArray.Add(new GuidingChapterItem(225, LocalStringManager.GetConfig("GuidingChapter_language", "Name_225"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_225_0") }, "GuidingChapter_Item226_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_225_0") }, "战斗-攻击与防御-兵器攻击-攻击耗时"));
		_dataArray.Add(new GuidingChapterItem(226, LocalStringManager.GetConfig("GuidingChapter_language", "Name_226"), 7, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_226_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_226_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_226_2")
		}, "GuidingChapter_Item227_p1,GuidingChapter_Item227_p2,GuidingChapter_Item227_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_226_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_226_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_226_2")
		}, "战斗-攻击与防御-攻击-攻击范围"));
		_dataArray.Add(new GuidingChapterItem(227, LocalStringManager.GetConfig("GuidingChapter_language", "Name_227"), 7, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_227_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_227_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_227_2")
		}, "GuidingChapter_Item228_p1,GuidingChapter_Item228_p2,GuidingChapter_Item228_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_227_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_227_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_227_2")
		}, "战斗-攻击与防御-攻击-命中与化解"));
		_dataArray.Add(new GuidingChapterItem(228, LocalStringManager.GetConfig("GuidingChapter_language", "Name_228"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_228_0") }, "GuidingChapter_Item229_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_228_0") }, "战斗-攻击与防御-攻击-命中要害"));
		_dataArray.Add(new GuidingChapterItem(229, LocalStringManager.GetConfig("GuidingChapter_language", "Name_229"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_229_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_229_1")
		}, "GuidingChapter_Item230_p1,GuidingChapter_Item230_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_229_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_229_1")
		}, "战斗-攻击与防御-兵器攻击-兵器切换"));
		_dataArray.Add(new GuidingChapterItem(230, LocalStringManager.GetConfig("GuidingChapter_language", "Name_230"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_230_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_230_1")
		}, "GuidingChapter_Item231_p1,GuidingChapter_Item231_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_230_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_230_1")
		}, "战斗-攻击与防御-兵器攻击-变招"));
		_dataArray.Add(new GuidingChapterItem(231, LocalStringManager.GetConfig("GuidingChapter_language", "Name_231"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_231_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_231_1")
		}, "GuidingChapter_Item232_p1,GuidingChapter_Item232_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_231_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_231_1")
		}, "战斗-攻击与防御-解封"));
		_dataArray.Add(new GuidingChapterItem(232, LocalStringManager.GetConfig("GuidingChapter_language", "Name_232"), 7, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_232_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_232_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_232_2")
		}, "GuidingChapter_Item233_p1,GuidingChapter_Item233_p2,GuidingChapter_Item233_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_232_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_232_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_232_2")
		}, "战斗-攻击与防御-解封-生铸"));
		_dataArray.Add(new GuidingChapterItem(233, LocalStringManager.GetConfig("GuidingChapter_language", "Name_233"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_233_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_233_1")
		}, "GuidingChapter_Item234_p1,GuidingChapter_Item234_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_233_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_233_1")
		}, "战斗-标记与状态-战败标记"));
		_dataArray.Add(new GuidingChapterItem(234, LocalStringManager.GetConfig("GuidingChapter_language", "Name_234"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_234_0") }, "GuidingChapter_Item235_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_234_0") }, "战斗-攻击与防御-伤害-伤害来源"));
		_dataArray.Add(new GuidingChapterItem(235, LocalStringManager.GetConfig("GuidingChapter_language", "Name_235"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_235_0") }, "GuidingChapter_Item236_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_235_0") }, "战斗-攻击与防御-伤害"));
		_dataArray.Add(new GuidingChapterItem(236, LocalStringManager.GetConfig("GuidingChapter_language", "Name_236"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_236_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_236_1")
		}, "GuidingChapter_Item237_p1,GuidingChapter_Item237_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_236_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_236_1")
		}, "战斗-攻击与防御-伤害-身心强健"));
		_dataArray.Add(new GuidingChapterItem(237, LocalStringManager.GetConfig("GuidingChapter_language", "Name_237"), 7, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_237_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_237_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_237_2")
		}, "GuidingChapter_Item238_p1,GuidingChapter_Item238_p2,GuidingChapter_Item238_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_237_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_237_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_237_2")
		}, "战斗-标记与状态-战败标记-伤势标记"));
		_dataArray.Add(new GuidingChapterItem(238, LocalStringManager.GetConfig("GuidingChapter_language", "Name_238"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_238_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_238_1")
		}, "GuidingChapter_Item239_p1,GuidingChapter_Item239_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_238_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_238_1")
		}, "战斗-标记与状态-战败标记-重创标记"));
		_dataArray.Add(new GuidingChapterItem(239, LocalStringManager.GetConfig("GuidingChapter_language", "Name_239"), 7, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_239_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_239_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_239_2")
		}, "GuidingChapter_Item240_p1,GuidingChapter_Item240_p2,GuidingChapter_Item240_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_239_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_239_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_239_2")
		}, "战斗-标记与状态-战败标记-破绽标记"));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new GuidingChapterItem(240, LocalStringManager.GetConfig("GuidingChapter_language", "Name_240"), 7, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_240_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_240_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_240_2")
		}, "GuidingChapter_Item241_p1,GuidingChapter_Item241_p2,GuidingChapter_Item241_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_240_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_240_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_240_2")
		}, "战斗-标记与状态-战败标记-封穴标记"));
		_dataArray.Add(new GuidingChapterItem(241, LocalStringManager.GetConfig("GuidingChapter_language", "Name_241"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_241_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_241_1")
		}, "GuidingChapter_Item242_p1,GuidingChapter_Item242_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_241_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_241_1")
		}, "战斗-标记与状态-战败标记-失神标记"));
		_dataArray.Add(new GuidingChapterItem(242, LocalStringManager.GetConfig("GuidingChapter_language", "Name_242"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_242_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_242_1")
		}, "GuidingChapter_Item243_p1,GuidingChapter_Item243_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_242_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_242_1")
		}, "战斗-标记与状态-战败标记-毒素标记"));
		_dataArray.Add(new GuidingChapterItem(243, LocalStringManager.GetConfig("GuidingChapter_language", "Name_243"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_243_0") }, "GuidingChapter_Item244_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_243_0") }, "战斗-标记与状态-战败标记-蛊虫标记"));
		_dataArray.Add(new GuidingChapterItem(244, LocalStringManager.GetConfig("GuidingChapter_language", "Name_244"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_244_0") }, "GuidingChapter_Item245_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_244_0") }, "战斗-标记与状态-战败标记-内息标记"));
		_dataArray.Add(new GuidingChapterItem(245, LocalStringManager.GetConfig("GuidingChapter_language", "Name_245"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_245_0") }, "GuidingChapter_Item246_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_245_0") }, "战斗-标记与状态-战败标记-状态标记"));
		_dataArray.Add(new GuidingChapterItem(246, LocalStringManager.GetConfig("GuidingChapter_language", "Name_246"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_246_0") }, "GuidingChapter_Item247_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_246_0") }, "战斗-标记与状态-战败标记-真气标记"));
		_dataArray.Add(new GuidingChapterItem(247, LocalStringManager.GetConfig("GuidingChapter_language", "Name_247"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_247_0") }, "GuidingChapter_Item248_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_247_0") }, "战斗-标记与状态-战败标记-健康标记"));
		_dataArray.Add(new GuidingChapterItem(248, LocalStringManager.GetConfig("GuidingChapter_language", "Name_248"), 7, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_248_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_248_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_248_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_248_3")
		}, "GuidingChapter_Item249_p1,GuidingChapter_Item249_p2,GuidingChapter_Item249_p3,GuidingChapter_Item249_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_248_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_248_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_248_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_248_3")
		}, "战斗-标记与状态-真气状态"));
		_dataArray.Add(new GuidingChapterItem(249, LocalStringManager.GetConfig("GuidingChapter_language", "Name_249"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_249_0") }, "GuidingChapter_Item250_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_249_0") }, "修习-武学-功法-施展需要"));
		_dataArray.Add(new GuidingChapterItem(250, LocalStringManager.GetConfig("GuidingChapter_language", "Name_250"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_250_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_250_1")
		}, "GuidingChapter_Item251_p1,GuidingChapter_Item251_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_250_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_250_1")
		}, "战斗-战斗基础-施展功法-架势"));
		_dataArray.Add(new GuidingChapterItem(251, LocalStringManager.GetConfig("GuidingChapter_language", "Name_251"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_251_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_251_1")
		}, "GuidingChapter_Item252_p1,GuidingChapter_Item252_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_251_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_251_1")
		}, "战斗-战斗基础-施展功法-提气"));
		_dataArray.Add(new GuidingChapterItem(252, LocalStringManager.GetConfig("GuidingChapter_language", "Name_252"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_252_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_252_1")
		}, "GuidingChapter_Item253_p1,GuidingChapter_Item253_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_252_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_252_1")
		}, "战斗-战斗基础-施展功法-脚力"));
		_dataArray.Add(new GuidingChapterItem(253, LocalStringManager.GetConfig("GuidingChapter_language", "Name_253"), 7, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_253_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_253_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_253_2")
		}, "GuidingChapter_Item254_p1,GuidingChapter_Item254_p2,GuidingChapter_Item254_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_253_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_253_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_253_2")
		}, "战斗-战斗基础-施展功法-蓄式"));
		_dataArray.Add(new GuidingChapterItem(254, LocalStringManager.GetConfig("GuidingChapter_language", "Name_254"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_254_0") }, "GuidingChapter_Item255_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_254_0") }, "修习-武学-功法"));
		_dataArray.Add(new GuidingChapterItem(255, LocalStringManager.GetConfig("GuidingChapter_language", "Name_255"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_255_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_255_1")
		}, "GuidingChapter_Item256_p1,GuidingChapter_Item256_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_255_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_255_1")
		}, "战斗-距离与移动-身法"));
		_dataArray.Add(new GuidingChapterItem(256, LocalStringManager.GetConfig("GuidingChapter_language", "Name_256"), 7, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_256_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_256_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_256_2")
		}, "GuidingChapter_Item257_p1,GuidingChapter_Item257_p2,GuidingChapter_Item257_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_256_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_256_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_256_2")
		}, "战斗-攻击与防御-摧破功法"));
		_dataArray.Add(new GuidingChapterItem(257, LocalStringManager.GetConfig("GuidingChapter_language", "Name_257"), 7, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_257_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_257_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_257_2")
		}, "GuidingChapter_Item258_p1,GuidingChapter_Item258_p2,GuidingChapter_Item258_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_257_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_257_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_257_2")
		}, "战斗-攻击与防御-护体功法"));
		_dataArray.Add(new GuidingChapterItem(258, LocalStringManager.GetConfig("GuidingChapter_language", "Name_258"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_258_0") }, "GuidingChapter_Item259_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_258_0") }, "修习-武学-功法"));
		_dataArray.Add(new GuidingChapterItem(259, LocalStringManager.GetConfig("GuidingChapter_language", "Name_259"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_259_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_259_1")
		}, "GuidingChapter_Item260_p1,GuidingChapter_Item260_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_259_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_259_1")
		}, "战斗-攻击与防御-摧破功法-威力成数"));
		_dataArray.Add(new GuidingChapterItem(260, LocalStringManager.GetConfig("GuidingChapter_language", "Name_260"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_260_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_260_1")
		}, "GuidingChapter_Item261_p1,GuidingChapter_Item261_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_260_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_260_1")
		}, "战斗-攻击与防御-护体功法-反击"));
		_dataArray.Add(new GuidingChapterItem(261, LocalStringManager.GetConfig("GuidingChapter_language", "Name_261"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_261_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_261_1")
		}, "GuidingChapter_Item262_p1,GuidingChapter_Item262_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_261_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_261_1")
		}, "战斗-攻击与防御-护体功法-反震"));
		_dataArray.Add(new GuidingChapterItem(262, LocalStringManager.GetConfig("GuidingChapter_language", "Name_262"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_262_0") }, "GuidingChapter_Item263_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_262_0") }, "战斗-标记与状态-封禁"));
		_dataArray.Add(new GuidingChapterItem(263, LocalStringManager.GetConfig("GuidingChapter_language", "Name_263"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_263_0") }, "GuidingChapter_Item264_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_263_0") }, "战斗-攻击与防御-伤害-反噬"));
		_dataArray.Add(new GuidingChapterItem(264, LocalStringManager.GetConfig("GuidingChapter_language", "Name_264"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_264_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_264_1")
		}, "GuidingChapter_Item265_p1,GuidingChapter_Item265_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_264_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_264_1")
		}, "交互-其他交互-同道-助战同道"));
		_dataArray.Add(new GuidingChapterItem(265, LocalStringManager.GetConfig("GuidingChapter_language", "Name_265"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_265_0") }, "GuidingChapter_Item266_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_265_0") }, "战斗-指令与行为-助战指令"));
		_dataArray.Add(new GuidingChapterItem(266, LocalStringManager.GetConfig("GuidingChapter_language", "Name_266"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_266_0") }, "GuidingChapter_Item267_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_266_0") }, "战斗-指令与行为-助战指令-负面指令"));
		_dataArray.Add(new GuidingChapterItem(267, LocalStringManager.GetConfig("GuidingChapter_language", "Name_267"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_267_0") }, "GuidingChapter_Item268_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_267_0") }, "战斗-指令与行为-战斗行为"));
		_dataArray.Add(new GuidingChapterItem(268, LocalStringManager.GetConfig("GuidingChapter_language", "Name_268"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_268_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_268_1")
		}, "GuidingChapter_Item269_p1,GuidingChapter_Item269_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_268_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_268_1")
		}, "战斗-指令与行为-战斗行为-治疗伤势"));
		_dataArray.Add(new GuidingChapterItem(269, LocalStringManager.GetConfig("GuidingChapter_language", "Name_269"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_269_0") }, "GuidingChapter_Item270_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_269_0") }, "战斗-指令与行为-战斗行为-使用物品"));
		_dataArray.Add(new GuidingChapterItem(270, LocalStringManager.GetConfig("GuidingChapter_language", "Name_270"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_270_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_270_1")
		}, "GuidingChapter_Item271_p1,GuidingChapter_Item271_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_270_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_270_1")
		}, "战斗-指令与行为-战斗行为-逃离战斗"));
		_dataArray.Add(new GuidingChapterItem(271, LocalStringManager.GetConfig("GuidingChapter_language", "Name_271"), 7, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_271_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_271_1")
		}, "GuidingChapter_Item272_p1,GuidingChapter_Item272_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_271_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_271_1")
		}, "战斗-指令与行为-战斗行为-认输投降"));
		_dataArray.Add(new GuidingChapterItem(272, LocalStringManager.GetConfig("GuidingChapter_language", "Name_272"), 7, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_272_0") }, "GuidingChapter_Item273_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_272_0") }, "战斗-指令与行为-战斗行为-处决"));
		_dataArray.Add(new GuidingChapterItem(273, LocalStringManager.GetConfig("GuidingChapter_language", "Name_273"), 8, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_273_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_273_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_273_2")
		}, "GuidingChapter_Item274_p1,GuidingChapter_Item274_p2,GuidingChapter_Item274_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_273_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_273_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_273_2")
		}, "产业-产业-产业视图"));
		_dataArray.Add(new GuidingChapterItem(274, LocalStringManager.GetConfig("GuidingChapter_language", "Name_274"), 8, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_274_0") }, "GuidingChapter_Item275_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_274_0") }, "产业-产业-建筑"));
		_dataArray.Add(new GuidingChapterItem(275, LocalStringManager.GetConfig("GuidingChapter_language", "Name_275"), 8, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_275_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_275_1")
		}, "GuidingChapter_Item276_p1,GuidingChapter_Item276_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_275_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_275_1")
		}, "产业-产业-建筑-扩展建筑"));
		_dataArray.Add(new GuidingChapterItem(276, LocalStringManager.GetConfig("GuidingChapter_language", "Name_276"), 8, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_276_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_276_1")
		}, "GuidingChapter_Item277_p1,GuidingChapter_Item277_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_276_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_276_1")
		}, "产业-产业-建筑-受损"));
		_dataArray.Add(new GuidingChapterItem(277, LocalStringManager.GetConfig("GuidingChapter_language", "Name_277"), 8, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_277_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_277_1")
		}, "GuidingChapter_Item278_p1,GuidingChapter_Item278_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_277_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_277_1")
		}, "产业-产业-自然资源"));
		_dataArray.Add(new GuidingChapterItem(278, LocalStringManager.GetConfig("GuidingChapter_language", "Name_278"), 8, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_278_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_278_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_278_2")
		}, "GuidingChapter_Item279_p1,GuidingChapter_Item279_p2,GuidingChapter_Item279_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_278_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_278_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_278_2")
		}, "产业-产业-产业建设-建造"));
		_dataArray.Add(new GuidingChapterItem(279, LocalStringManager.GetConfig("GuidingChapter_language", "Name_279"), 8, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_279_0") }, "GuidingChapter_Item280_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_279_0") }, "产业-产业-产业建设-扩建"));
		_dataArray.Add(new GuidingChapterItem(280, LocalStringManager.GetConfig("GuidingChapter_language", "Name_280"), 8, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_280_0") }, "GuidingChapter_Item281_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_280_0") }, "产业-产业-产业建设-培育"));
		_dataArray.Add(new GuidingChapterItem(281, LocalStringManager.GetConfig("GuidingChapter_language", "Name_281"), 8, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_281_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_281_1")
		}, "GuidingChapter_Item282_p1,GuidingChapter_Item282_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_281_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_281_1")
		}, "产业-特殊建筑-太吾村-信誓等级"));
		_dataArray.Add(new GuidingChapterItem(282, LocalStringManager.GetConfig("GuidingChapter_language", "Name_282"), 8, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_282_0") }, "GuidingChapter_Item283_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_282_0") }, "产业-产业-产业建设-撤除"));
		_dataArray.Add(new GuidingChapterItem(283, LocalStringManager.GetConfig("GuidingChapter_language", "Name_283"), 8, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_283_0") }, "GuidingChapter_Item284_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_283_0") }, "产业-产业-产业建设-规划"));
		_dataArray.Add(new GuidingChapterItem(284, LocalStringManager.GetConfig("GuidingChapter_language", "Name_284"), 8, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_284_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_284_1")
		}, "GuidingChapter_Item285_p1,GuidingChapter_Item285_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_284_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_284_1")
		}, "产业-产业-产业经营"));
		_dataArray.Add(new GuidingChapterItem(285, LocalStringManager.GetConfig("GuidingChapter_language", "Name_285"), 8, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_285_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_285_1")
		}, "GuidingChapter_Item286_p1,GuidingChapter_Item286_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_285_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_285_1")
		}, "产业-产业-产业经营-经营进度"));
		_dataArray.Add(new GuidingChapterItem(286, LocalStringManager.GetConfig("GuidingChapter_language", "Name_286"), 8, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_286_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_286_1")
		}, "GuidingChapter_Item287_p1,GuidingChapter_Item287_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_286_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_286_1")
		}, "产业-产业-产业经营-主事与学徒"));
		_dataArray.Add(new GuidingChapterItem(287, LocalStringManager.GetConfig("GuidingChapter_language", "Name_287"), 8, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_287_0") }, "GuidingChapter_Item288_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_287_0") }, "产业-产业-产业经营-经营效果"));
		_dataArray.Add(new GuidingChapterItem(288, LocalStringManager.GetConfig("GuidingChapter_language", "Name_288"), 8, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_288_0") }, "GuidingChapter_Item289_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_288_0") }, "产业-产业-产业经营-经营效果"));
		_dataArray.Add(new GuidingChapterItem(289, LocalStringManager.GetConfig("GuidingChapter_language", "Name_289"), 8, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_289_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_289_1")
		}, "GuidingChapter_Item290_p1,GuidingChapter_Item290_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_289_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_289_1")
		}, "物品-制造加工-制造建筑"));
		_dataArray.Add(new GuidingChapterItem(290, LocalStringManager.GetConfig("GuidingChapter_language", "Name_290"), 8, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_290_0") }, "GuidingChapter_Item291_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_290_0") }, "产业-特殊建筑-居所"));
		_dataArray.Add(new GuidingChapterItem(291, LocalStringManager.GetConfig("GuidingChapter_language", "Name_291"), 8, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_291_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_291_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_291_2")
		}, "GuidingChapter_Item292_p1,GuidingChapter_Item292_p2,GuidingChapter_Item292_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_291_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_291_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_291_2")
		}, "产业-特殊建筑-太吾村-蛰室"));
		_dataArray.Add(new GuidingChapterItem(292, LocalStringManager.GetConfig("GuidingChapter_language", "Name_292"), 8, obsoleteItem: false, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_292_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_292_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_292_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_292_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_292_4")
		}, "GuidingChapter_Item293_p1,GuidingChapter_Item293_p2,GuidingChapter_Item293_p3,GuidingChapter_Item293_p4,GuidingChapter_Item293_p5", 5, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_292_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_292_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_292_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_292_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_292_4")
		}, "产业-特殊建筑-太吾村-石屋"));
		_dataArray.Add(new GuidingChapterItem(293, LocalStringManager.GetConfig("GuidingChapter_language", "Name_293"), 8, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_293_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_293_1")
		}, "GuidingChapter_Item294_p1,GuidingChapter_Item294_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_293_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_293_1")
		}, "产业-特殊建筑-太吾氏祠堂"));
		_dataArray.Add(new GuidingChapterItem(294, LocalStringManager.GetConfig("GuidingChapter_language", "Name_294"), 8, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_294_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_294_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_294_2")
		}, "GuidingChapter_Item295_p1,GuidingChapter_Item295_p2,GuidingChapter_Item295_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_294_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_294_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_294_2")
		}, "产业-特殊建筑-宴堂"));
		_dataArray.Add(new GuidingChapterItem(295, LocalStringManager.GetConfig("GuidingChapter_language", "Name_295"), 8, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_295_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_295_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_295_2")
		}, "GuidingChapter_Item296_p1,GuidingChapter_Item296_p2,GuidingChapter_Item296_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_295_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_295_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_295_2")
		}, "产业-特殊建筑-仓库"));
		_dataArray.Add(new GuidingChapterItem(296, LocalStringManager.GetConfig("GuidingChapter_language", "Name_296"), 8, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_296_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_296_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_296_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_296_3")
		}, "GuidingChapter_Item297_p1,GuidingChapter_Item297_p2,GuidingChapter_Item297_p3,GuidingChapter_Item297_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_296_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_296_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_296_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_296_3")
		}, "产业-特殊建筑-元鸡舍"));
		_dataArray.Add(new GuidingChapterItem(297, LocalStringManager.GetConfig("GuidingChapter_language", "Name_297"), 8, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_297_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_297_1")
		}, "GuidingChapter_Item298_p1,GuidingChapter_Item298_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_297_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_297_1")
		}, "产业-特殊建筑-轮回台"));
		_dataArray.Add(new GuidingChapterItem(298, LocalStringManager.GetConfig("GuidingChapter_language", "Name_298"), 8, obsoleteItem: false, new string[6]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_298_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_298_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_298_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_298_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_298_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_298_5")
		}, "GuidingChapter_Item299_p1,GuidingChapter_Item299_p2,GuidingChapter_Item299_p3,GuidingChapter_Item299_p4,GuidingChapter_Item299_p5,GuidingChapter_Item299_p6", 6, new string[6]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_298_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_298_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_298_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_298_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_298_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_298_5")
		}, "产业-特殊建筑-茶马帮"));
		_dataArray.Add(new GuidingChapterItem(299, LocalStringManager.GetConfig("GuidingChapter_language", "Name_299"), 8, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_299_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_299_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_299_2")
		}, "GuidingChapter_Item300_p1,GuidingChapter_Item300_p2,GuidingChapter_Item300_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_299_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_299_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_299_2")
		}, "产业-特殊建筑-练功房"));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new GuidingChapterItem(300, LocalStringManager.GetConfig("GuidingChapter_language", "Name_300"), 8, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_300_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_300_1")
		}, "GuidingChapter_Item301_p1,GuidingChapter_Item301_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_300_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_300_1")
		}, "产业-太吾村民-村民"));
		_dataArray.Add(new GuidingChapterItem(301, LocalStringManager.GetConfig("GuidingChapter_language", "Name_301"), 8, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_301_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_301_1")
		}, "GuidingChapter_Item302_p1,GuidingChapter_Item302_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_301_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_301_1")
		}, "产业-太吾村民-村民-村民身份"));
		_dataArray.Add(new GuidingChapterItem(302, LocalStringManager.GetConfig("GuidingChapter_language", "Name_302"), 8, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_302_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_302_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_302_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_302_3")
		}, "GuidingChapter_Item303_p1,GuidingChapter_Item303_p2,GuidingChapter_Item303_p3,GuidingChapter_Item303_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_302_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_302_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_302_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_302_3")
		}, "产业-太吾村民-村民-身份职能"));
		_dataArray.Add(new GuidingChapterItem(303, LocalStringManager.GetConfig("GuidingChapter_language", "Name_303"), 9, obsoleteItem: false, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_303_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_303_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_303_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_303_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_303_4")
		}, "GuidingChapter_Item304_p1,GuidingChapter_Item304_p2,GuidingChapter_Item304_p3,GuidingChapter_Item304_p4,GuidingChapter_Item304_p5", 5, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_303_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_303_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_303_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_303_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_303_4")
		}, "物品-物品与资源-物品"));
		_dataArray.Add(new GuidingChapterItem(304, LocalStringManager.GetConfig("GuidingChapter_language", "Name_304"), 9, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_304_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_304_1")
		}, "GuidingChapter_Item305_p1,GuidingChapter_Item305_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_304_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_304_1")
		}, "物品-物品与资源-资源-资源"));
		_dataArray.Add(new GuidingChapterItem(305, LocalStringManager.GetConfig("GuidingChapter_language", "Name_305"), 9, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_305_0") }, "GuidingChapter_Item306_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_305_0") }, "物品-物品与资源-资源-银钱"));
		_dataArray.Add(new GuidingChapterItem(306, LocalStringManager.GetConfig("GuidingChapter_language", "Name_306"), 9, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_306_0") }, "GuidingChapter_Item307_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_306_0") }, "物品-物品与资源-资源-威望"));
		_dataArray.Add(new GuidingChapterItem(307, LocalStringManager.GetConfig("GuidingChapter_language", "Name_307"), 9, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_307_0") }, "GuidingChapter_Item308_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_307_0") }, "物品-物品与资源-资源-历练"));
		_dataArray.Add(new GuidingChapterItem(308, LocalStringManager.GetConfig("GuidingChapter_language", "Name_308"), 9, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_308_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_308_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_308_2")
		}, "GuidingChapter_Item309_p1,GuidingChapter_Item309_p2,GuidingChapter_Item309_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_308_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_308_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_308_2")
		}, "物品-物品类型-食物"));
		_dataArray.Add(new GuidingChapterItem(309, LocalStringManager.GetConfig("GuidingChapter_language", "Name_309"), 9, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_309_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_309_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_309_2")
		}, "GuidingChapter_Item310_p1,GuidingChapter_Item310_p2,GuidingChapter_Item310_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_309_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_309_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_309_2")
		}, "物品-物品类型-药毒-丹药"));
		_dataArray.Add(new GuidingChapterItem(310, LocalStringManager.GetConfig("GuidingChapter_language", "Name_310"), 9, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_310_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_310_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_310_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_310_3")
		}, "GuidingChapter_Item311_p1,GuidingChapter_Item311_p2,GuidingChapter_Item311_p3,GuidingChapter_Item311_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_310_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_310_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_310_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_310_3")
		}, "物品-物品类型-药毒-毒药"));
		_dataArray.Add(new GuidingChapterItem(311, LocalStringManager.GetConfig("GuidingChapter_language", "Name_311"), 9, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_311_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_311_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_311_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_311_3")
		}, "GuidingChapter_Item312_p1,GuidingChapter_Item312_p2,GuidingChapter_Item312_p3,GuidingChapter_Item312_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_311_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_311_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_311_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_311_3")
		}, "物品-物品类型-装备"));
		_dataArray.Add(new GuidingChapterItem(312, LocalStringManager.GetConfig("GuidingChapter_language", "Name_312"), 9, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_312_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_312_1")
		}, "GuidingChapter_Item313_p1,GuidingChapter_Item313_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_312_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_312_1")
		}, "物品-物品类型-装备-装备负重"));
		_dataArray.Add(new GuidingChapterItem(313, LocalStringManager.GetConfig("GuidingChapter_language", "Name_313"), 9, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_313_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_313_1")
		}, "GuidingChapter_Item314_p1,GuidingChapter_Item314_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_313_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_313_1")
		}, "物品-物品类型-装备-装备特性"));
		_dataArray.Add(new GuidingChapterItem(314, LocalStringManager.GetConfig("GuidingChapter_language", "Name_314"), 9, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_314_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_314_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_314_2")
		}, "GuidingChapter_Item315_p1,GuidingChapter_Item315_p2,GuidingChapter_Item315_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_314_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_314_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_314_2")
		}, "物品-物品类型-武具-兵器"));
		_dataArray.Add(new GuidingChapterItem(315, LocalStringManager.GetConfig("GuidingChapter_language", "Name_315"), 9, obsoleteItem: false, new string[6]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_315_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_315_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_315_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_315_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_315_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_315_5")
		}, "GuidingChapter_Item316_p1,GuidingChapter_Item316_p2,GuidingChapter_Item316_p3,GuidingChapter_Item316_p4,GuidingChapter_Item316_p5,GuidingChapter_Item316_p6", 6, new string[6]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_315_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_315_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_315_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_315_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_315_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_315_5")
		}, "物品-物品类型-武具-兵器"));
		_dataArray.Add(new GuidingChapterItem(316, LocalStringManager.GetConfig("GuidingChapter_language", "Name_316"), 9, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_316_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_316_1")
		}, "GuidingChapter_Item317_p1,GuidingChapter_Item317_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_316_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_316_1")
		}, "物品-物品类型-武具-护具"));
		_dataArray.Add(new GuidingChapterItem(317, LocalStringManager.GetConfig("GuidingChapter_language", "Name_317"), 9, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_317_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_317_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_317_2")
		}, "GuidingChapter_Item318_p1,GuidingChapter_Item318_p2,GuidingChapter_Item318_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_317_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_317_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_317_2")
		}, "物品-物品类型-武具-护具"));
		_dataArray.Add(new GuidingChapterItem(318, LocalStringManager.GetConfig("GuidingChapter_language", "Name_318"), 9, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_318_0") }, "GuidingChapter_Item319_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_318_0") }, "物品-物品类型-武具-宝物"));
		_dataArray.Add(new GuidingChapterItem(319, LocalStringManager.GetConfig("GuidingChapter_language", "Name_319"), 9, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_319_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_319_1")
		}, "GuidingChapter_Item320_p1,GuidingChapter_Item320_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_319_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_319_1")
		}, "物品-物品类型-行装-衣装"));
		_dataArray.Add(new GuidingChapterItem(320, LocalStringManager.GetConfig("GuidingChapter_language", "Name_320"), 9, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_320_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_320_1")
		}, "GuidingChapter_Item321_p1,GuidingChapter_Item321_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_320_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_320_1")
		}, "物品-物品类型-行装-代步"));
		_dataArray.Add(new GuidingChapterItem(321, LocalStringManager.GetConfig("GuidingChapter_language", "Name_321"), 9, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_321_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_321_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_321_2")
		}, "GuidingChapter_Item322_p1,GuidingChapter_Item322_p2,GuidingChapter_Item322_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_321_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_321_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_321_2")
		}, "物品-物品类型-行装-代步"));
		_dataArray.Add(new GuidingChapterItem(322, LocalStringManager.GetConfig("GuidingChapter_language", "Name_322"), 9, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_322_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_322_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_322_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_322_3")
		}, "GuidingChapter_Item323_p1,GuidingChapter_Item323_p2,GuidingChapter_Item323_p3,GuidingChapter_Item323_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_322_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_322_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_322_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_322_3")
		}, "物品-物品类型-行装-代步"));
		_dataArray.Add(new GuidingChapterItem(323, LocalStringManager.GetConfig("GuidingChapter_language", "Name_323"), 9, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_323_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_323_1")
		}, "GuidingChapter_Item324_p1,GuidingChapter_Item324_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_323_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_323_1")
		}, "物品-物品类型-书籍"));
		_dataArray.Add(new GuidingChapterItem(324, LocalStringManager.GetConfig("GuidingChapter_language", "Name_324"), 9, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_324_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_324_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_324_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_324_3")
		}, "GuidingChapter_Item325_p1,GuidingChapter_Item325_p2,GuidingChapter_Item325_p3,GuidingChapter_Item325_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_324_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_324_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_324_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_324_3")
		}, "物品-物品类型-工具"));
		_dataArray.Add(new GuidingChapterItem(325, LocalStringManager.GetConfig("GuidingChapter_language", "Name_325"), 9, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_325_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_325_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_325_2")
		}, "GuidingChapter_Item326_p1,GuidingChapter_Item326_p2,GuidingChapter_Item326_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_325_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_325_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_325_2")
		}, "物品-物品类型-材料-引子"));
		_dataArray.Add(new GuidingChapterItem(326, LocalStringManager.GetConfig("GuidingChapter_language", "Name_326"), 9, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_326_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_326_1")
		}, "GuidingChapter_Item327_p1,GuidingChapter_Item327_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_326_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_326_1")
		}, "物品-物品类型-材料-精制材料"));
		_dataArray.Add(new GuidingChapterItem(327, LocalStringManager.GetConfig("GuidingChapter_language", "Name_327"), 9, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_327_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_327_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_327_2")
		}, "GuidingChapter_Item328_p1,GuidingChapter_Item328_p2,GuidingChapter_Item328_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_327_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_327_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_327_2")
		}, "物品-物品类型-杂物-心材"));
		_dataArray.Add(new GuidingChapterItem(328, LocalStringManager.GetConfig("GuidingChapter_language", "Name_328"), 9, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_328_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_328_1")
		}, "GuidingChapter_Item329_p1,GuidingChapter_Item329_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_328_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_328_1")
		}, "物品-物品类型-杂物-绳索"));
		_dataArray.Add(new GuidingChapterItem(329, LocalStringManager.GetConfig("GuidingChapter_language", "Name_329"), 9, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_329_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_329_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_329_2")
		}, "GuidingChapter_Item330_p1,GuidingChapter_Item330_p2,GuidingChapter_Item330_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_329_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_329_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_329_2")
		}, "物品-物品类型-杂物-信鸽"));
		_dataArray.Add(new GuidingChapterItem(330, LocalStringManager.GetConfig("GuidingChapter_language", "Name_330"), 9, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_330_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_330_1")
		}, "GuidingChapter_Item331_p1,GuidingChapter_Item331_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_330_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_330_1")
		}, "物品-物品类型-杂物-神木种子"));
		_dataArray.Add(new GuidingChapterItem(331, LocalStringManager.GetConfig("GuidingChapter_language", "Name_331"), 9, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_331_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_331_1")
		}, "GuidingChapter_Item332_p1,GuidingChapter_Item332_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_331_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_331_1")
		}, "物品-物品类型-杂物-神木种子"));
		_dataArray.Add(new GuidingChapterItem(332, LocalStringManager.GetConfig("GuidingChapter_language", "Name_332"), 9, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_332_0") }, "GuidingChapter_Item333_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_332_0") }, "物品-物品类型-杂物-血露"));
		_dataArray.Add(new GuidingChapterItem(333, LocalStringManager.GetConfig("GuidingChapter_language", "Name_333"), 9, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_333_0") }, "GuidingChapter_Item334_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_333_0") }, "物品-物品类型-杂物-西域珍宝"));
		_dataArray.Add(new GuidingChapterItem(334, LocalStringManager.GetConfig("GuidingChapter_language", "Name_334"), 9, obsoleteItem: false, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_334_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_334_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_334_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_334_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_334_4")
		}, "GuidingChapter_Item335_p1,GuidingChapter_Item335_p2,GuidingChapter_Item335_p3,GuidingChapter_Item335_p4,GuidingChapter_Item335_p5", 5, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_334_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_334_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_334_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_334_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_334_4")
		}, "物品-制造加工-制造"));
		_dataArray.Add(new GuidingChapterItem(335, LocalStringManager.GetConfig("GuidingChapter_language", "Name_335"), 9, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_335_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_335_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_335_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_335_3")
		}, "GuidingChapter_Item336_p1,GuidingChapter_Item336_p2,GuidingChapter_Item336_p3,GuidingChapter_Item336_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_335_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_335_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_335_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_335_3")
		}, "物品-制造加工-代制"));
		_dataArray.Add(new GuidingChapterItem(336, LocalStringManager.GetConfig("GuidingChapter_language", "Name_336"), 9, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_336_0") }, "GuidingChapter_Item337_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_336_0") }, "物品-制造加工-修理"));
		_dataArray.Add(new GuidingChapterItem(337, LocalStringManager.GetConfig("GuidingChapter_language", "Name_337"), 9, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_337_0") }, "GuidingChapter_Item338_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_337_0") }, "物品-制造加工-拆解"));
		_dataArray.Add(new GuidingChapterItem(338, LocalStringManager.GetConfig("GuidingChapter_language", "Name_338"), 9, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_338_0") }, "GuidingChapter_Item339_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_338_0") }, "物品-制造加工-精制"));
		_dataArray.Add(new GuidingChapterItem(339, LocalStringManager.GetConfig("GuidingChapter_language", "Name_339"), 9, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_339_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_339_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_339_2")
		}, "GuidingChapter_Item340_p1,GuidingChapter_Item340_p2,GuidingChapter_Item340_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_339_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_339_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_339_2")
		}, "物品-制造加工-淬毒"));
		_dataArray.Add(new GuidingChapterItem(340, LocalStringManager.GetConfig("GuidingChapter_language", "Name_340"), 9, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_340_0") }, "GuidingChapter_Item341_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_340_0") }, "物品-制造加工-解毒"));
		_dataArray.Add(new GuidingChapterItem(341, LocalStringManager.GetConfig("GuidingChapter_language", "Name_341"), 9, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_341_0") }, "GuidingChapter_Item342_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_341_0") }, "物品-制造加工-验毒"));
		_dataArray.Add(new GuidingChapterItem(342, LocalStringManager.GetConfig("GuidingChapter_language", "Name_342"), 9, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_342_0") }, "GuidingChapter_Item343_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_342_0") }, "物品-制造加工-改制"));
		_dataArray.Add(new GuidingChapterItem(343, LocalStringManager.GetConfig("GuidingChapter_language", "Name_343"), 9, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_343_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_343_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_343_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_343_3")
		}, "GuidingChapter_Item344_p1,GuidingChapter_Item344_p2,GuidingChapter_Item344_p3,GuidingChapter_Item344_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_343_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_343_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_343_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_343_3")
		}, "游历-志向-志向"));
		_dataArray.Add(new GuidingChapterItem(344, LocalStringManager.GetConfig("GuidingChapter_language", "Name_344"), 10, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_344_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_344_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_344_2")
		}, "GuidingChapter_Item345_p1,GuidingChapter_Item345_p2,GuidingChapter_Item345_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_344_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_344_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_344_2")
		}, "游历-志向-志向-志向技能"));
		_dataArray.Add(new GuidingChapterItem(345, LocalStringManager.GetConfig("GuidingChapter_language", "Name_345"), 10, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_345_0") }, "GuidingChapter_Item346_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_345_0") }, "游历-志向-志向-志向有成"));
		_dataArray.Add(new GuidingChapterItem(346, LocalStringManager.GetConfig("GuidingChapter_language", "Name_346"), 10, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_346_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_346_1")
		}, "GuidingChapter_Item347_p1,GuidingChapter_Item347_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_346_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_346_1")
		}, "游历-促织-捕捉促织-寻找"));
		_dataArray.Add(new GuidingChapterItem(347, LocalStringManager.GetConfig("GuidingChapter_language", "Name_347"), 10, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_347_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_347_1")
		}, "GuidingChapter_Item348_p1,GuidingChapter_Item348_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_347_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_347_1")
		}, "游历-促织-捕捉促织-捕捉"));
		_dataArray.Add(new GuidingChapterItem(348, LocalStringManager.GetConfig("GuidingChapter_language", "Name_348"), 10, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_348_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_348_1")
		}, "GuidingChapter_Item349_p1,GuidingChapter_Item349_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_348_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_348_1")
		}, "游历-促织-促织属性"));
		_dataArray.Add(new GuidingChapterItem(349, LocalStringManager.GetConfig("GuidingChapter_language", "Name_349"), 10, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_349_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_349_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_349_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_349_3")
		}, "GuidingChapter_Item350_p1,GuidingChapter_Item350_p2,GuidingChapter_Item350_p3,GuidingChapter_Item350_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_349_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_349_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_349_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_349_3")
		}, "游历-促织-促织决斗"));
		_dataArray.Add(new GuidingChapterItem(350, LocalStringManager.GetConfig("GuidingChapter_language", "Name_350"), 10, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_350_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_350_1")
		}, "GuidingChapter_Item351_p1,GuidingChapter_Item351_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_350_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_350_1")
		}, "游历-促织-促织决斗-决斗战绩"));
		_dataArray.Add(new GuidingChapterItem(351, LocalStringManager.GetConfig("GuidingChapter_language", "Name_351"), 10, obsoleteItem: true, new string[0], null, 0, new string[0], "世界-地图互动-奇遇"));
		_dataArray.Add(new GuidingChapterItem(352, LocalStringManager.GetConfig("GuidingChapter_language", "Name_352"), 10, obsoleteItem: true, new string[0], null, 0, new string[0], "世界-地图互动-奇遇"));
		_dataArray.Add(new GuidingChapterItem(353, LocalStringManager.GetConfig("GuidingChapter_language", "Name_353"), 10, obsoleteItem: true, new string[0], null, 0, new string[0], "世界-地图互动-奇遇"));
		_dataArray.Add(new GuidingChapterItem(354, LocalStringManager.GetConfig("GuidingChapter_language", "Name_354"), 10, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_354_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_354_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_354_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_354_3")
		}, "GuidingChapter_Item355_p1,GuidingChapter_Item355_p2,GuidingChapter_Item355_p3,GuidingChapter_Item355_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_354_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_354_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_354_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_354_3")
		}, "修习-技艺-较艺-基本流程"));
		_dataArray.Add(new GuidingChapterItem(355, LocalStringManager.GetConfig("GuidingChapter_language", "Name_355"), 10, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_355_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_355_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_355_2")
		}, "GuidingChapter_Item356_p1,GuidingChapter_Item356_p2,GuidingChapter_Item356_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_355_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_355_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_355_2")
		}, "修习-技艺-较艺-基本流程"));
		_dataArray.Add(new GuidingChapterItem(356, LocalStringManager.GetConfig("GuidingChapter_language", "Name_356"), 10, obsoleteItem: false, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_356_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_356_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_356_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_356_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_356_4")
		}, "GuidingChapter_Item357_p1,GuidingChapter_Item357_p2,GuidingChapter_Item357_p3,GuidingChapter_Item357_p4,GuidingChapter_Item357_p5", 5, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_356_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_356_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_356_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_356_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_356_4")
		}, "修习-技艺-较艺-较艺策略"));
		_dataArray.Add(new GuidingChapterItem(357, LocalStringManager.GetConfig("GuidingChapter_language", "Name_357"), 10, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_357_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_357_1")
		}, "GuidingChapter_Item358_p1,GuidingChapter_Item358_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_357_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_357_1")
		}, "修习-技艺-较艺-论战"));
		_dataArray.Add(new GuidingChapterItem(358, LocalStringManager.GetConfig("GuidingChapter_language", "Name_358"), 10, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_358_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_358_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_358_2")
		}, "GuidingChapter_Item359_p1,GuidingChapter_Item359_p2,GuidingChapter_Item359_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_358_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_358_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_358_2")
		}, "修习-技艺-较艺-结论"));
		_dataArray.Add(new GuidingChapterItem(359, LocalStringManager.GetConfig("GuidingChapter_language", "Name_359"), 10, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_359_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_359_1")
		}, "GuidingChapter_Item360_p1,GuidingChapter_Item360_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_359_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_359_1")
		}, "修习-技艺-较艺-压力"));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new GuidingChapterItem(360, LocalStringManager.GetConfig("GuidingChapter_language", "Name_360"), 10, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_360_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_360_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_360_2")
		}, "GuidingChapter_Item361_p1,GuidingChapter_Item361_p2,GuidingChapter_Item361_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_360_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_360_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_360_2")
		}, "修习-技艺-较艺-较艺评价"));
		_dataArray.Add(new GuidingChapterItem(361, LocalStringManager.GetConfig("GuidingChapter_language", "Name_361"), 3, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_361_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_361_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_361_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_361_3")
		}, "GuidingChapter_Item362_p1,GuidingChapter_Item362_p2,GuidingChapter_Item362_p3,GuidingChapter_Item362_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_361_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_361_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_361_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_361_3")
		}, "门派-门派一览-少林派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(362, LocalStringManager.GetConfig("GuidingChapter_language", "Name_362"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_362_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_362_1")
		}, "GuidingChapter_Item363_p1,GuidingChapter_Item363_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_362_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_362_1")
		}, "门派-门派一览-少林派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(363, LocalStringManager.GetConfig("GuidingChapter_language", "Name_363"), 3, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_363_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_363_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_363_2")
		}, "GuidingChapter_Item364_p1,GuidingChapter_Item364_p2,GuidingChapter_Item364_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_363_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_363_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_363_2")
		}, "门派-门派一览-峨眉派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(364, LocalStringManager.GetConfig("GuidingChapter_language", "Name_364"), 3, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_364_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_364_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_364_2")
		}, "GuidingChapter_Item365_p1,GuidingChapter_Item365_p2,GuidingChapter_Item365_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_364_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_364_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_364_2")
		}, "门派-门派一览-百花谷-特有功能"));
		_dataArray.Add(new GuidingChapterItem(365, LocalStringManager.GetConfig("GuidingChapter_language", "Name_365"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_365_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_365_1")
		}, "GuidingChapter_Item366_p1,GuidingChapter_Item366_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_365_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_365_1")
		}, "门派-门派一览-武当派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(366, LocalStringManager.GetConfig("GuidingChapter_language", "Name_366"), 3, obsoleteItem: false, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_366_0") }, "GuidingChapter_Item367_p1", 1, new string[1] { LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_366_0") }, "门派-门派一览-武当派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(367, LocalStringManager.GetConfig("GuidingChapter_language", "Name_367"), 3, obsoleteItem: true, new string[0], null, 0, new string[0], null));
		_dataArray.Add(new GuidingChapterItem(368, LocalStringManager.GetConfig("GuidingChapter_language", "Name_368"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_368_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_368_1")
		}, "GuidingChapter_Item369_p1,GuidingChapter_Item369_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_368_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_368_1")
		}, "门派-门派一览-狮相门-特有功能"));
		_dataArray.Add(new GuidingChapterItem(369, LocalStringManager.GetConfig("GuidingChapter_language", "Name_369"), 3, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_369_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_369_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_369_2")
		}, "GuidingChapter_Item370_p1,GuidingChapter_Item370_p2,GuidingChapter_Item370_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_369_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_369_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_369_2")
		}, "门派-门派一览-然山派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(370, LocalStringManager.GetConfig("GuidingChapter_language", "Name_370"), 3, obsoleteItem: true, new string[0], null, 0, new string[0], null));
		_dataArray.Add(new GuidingChapterItem(371, LocalStringManager.GetConfig("GuidingChapter_language", "Name_371"), 3, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_371_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_371_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_371_2")
		}, "GuidingChapter_Item372_p1,GuidingChapter_Item372_p2,GuidingChapter_Item372_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_371_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_371_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_371_2")
		}, "门派-门派一览-璇女派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(372, LocalStringManager.GetConfig("GuidingChapter_language", "Name_372"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_372_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_372_1")
		}, "GuidingChapter_Item373_p1,GuidingChapter_Item373_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_372_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_372_1")
		}, "门派-门派一览-璇女派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(373, LocalStringManager.GetConfig("GuidingChapter_language", "Name_373"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_373_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_373_1")
		}, "GuidingChapter_Item374_p1,GuidingChapter_Item374_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_373_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_373_1")
		}, "门派-门派一览-璇女派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(374, LocalStringManager.GetConfig("GuidingChapter_language", "Name_374"), 3, obsoleteItem: false, new string[9]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_374_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_374_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_374_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_374_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_374_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_374_5"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_374_6"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_374_7"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_374_8")
		}, "GuidingChapter_Item375_p1,GuidingChapter_Item375_p2,GuidingChapter_Item375_p3,GuidingChapter_Item375_p4,GuidingChapter_Item375_p5,GuidingChapter_Item375_p6,GuidingChapter_Item375_p7,GuidingChapter_Item375_p8,GuidingChapter_Item375_p9", 9, new string[9]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_374_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_374_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_374_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_374_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_374_4"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_374_5"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_374_6"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_374_7"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_374_8")
		}, "门派-门派一览-铸剑山庄-特有功能"));
		_dataArray.Add(new GuidingChapterItem(375, LocalStringManager.GetConfig("GuidingChapter_language", "Name_375"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_375_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_375_1")
		}, "GuidingChapter_Item376_p1,GuidingChapter_Item376_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_375_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_375_1")
		}, "门派-门派一览-空桑派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(376, LocalStringManager.GetConfig("GuidingChapter_language", "Name_376"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_376_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_376_1")
		}, "GuidingChapter_Item377_p1,GuidingChapter_Item377_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_376_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_376_1")
		}, "门派-门派一览-空桑派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(377, LocalStringManager.GetConfig("GuidingChapter_language", "Name_377"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_377_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_377_1")
		}, "GuidingChapter_Item378_p1,GuidingChapter_Item378_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_377_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_377_1")
		}, "门派-门派一览-金刚宗-特有功能"));
		_dataArray.Add(new GuidingChapterItem(378, LocalStringManager.GetConfig("GuidingChapter_language", "Name_378"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_378_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_378_1")
		}, "GuidingChapter_Item379_p1,GuidingChapter_Item379_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_378_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_378_1")
		}, "门派-门派一览-五仙教-特有功能"));
		_dataArray.Add(new GuidingChapterItem(379, LocalStringManager.GetConfig("GuidingChapter_language", "Name_379"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_379_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_379_1")
		}, "GuidingChapter_Item380_p1,GuidingChapter_Item380_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_379_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_379_1")
		}, "门派-门派一览-五仙教-特有功能"));
		_dataArray.Add(new GuidingChapterItem(380, LocalStringManager.GetConfig("GuidingChapter_language", "Name_380"), 3, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_380_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_380_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_380_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_380_3")
		}, "GuidingChapter_Item381_p1,GuidingChapter_Item381_p2,GuidingChapter_Item381_p3,GuidingChapter_Item381_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_380_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_380_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_380_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_380_3")
		}, "门派-门派一览-界青门-特有功能"));
		_dataArray.Add(new GuidingChapterItem(381, LocalStringManager.GetConfig("GuidingChapter_language", "Name_381"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_381_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_381_1")
		}, "GuidingChapter_Item382_p1,GuidingChapter_Item382_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_381_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_381_1")
		}, "门派-门派一览-伏龙坛-特有功能"));
		_dataArray.Add(new GuidingChapterItem(382, LocalStringManager.GetConfig("GuidingChapter_language", "Name_382"), 3, obsoleteItem: false, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_382_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_382_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_382_2")
		}, "GuidingChapter_Item383_p1,GuidingChapter_Item383_p2,GuidingChapter_Item383_p3", 3, new string[3]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_382_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_382_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_382_2")
		}, "门派-门派一览-伏龙坛-特有功能"));
		_dataArray.Add(new GuidingChapterItem(383, LocalStringManager.GetConfig("GuidingChapter_language", "Name_383"), 3, obsoleteItem: false, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_383_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_383_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_383_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_383_3")
		}, "GuidingChapter_Item385_p1,GuidingChapter_Item385_p2,GuidingChapter_Item385_p3,GuidingChapter_Item385_p4", 4, new string[4]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_383_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_383_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_383_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_383_3")
		}, "门派-门派一览-血犼教-特有功能"));
		_dataArray.Add(new GuidingChapterItem(384, LocalStringManager.GetConfig("GuidingChapter_language", "Name_384"), 3, obsoleteItem: false, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_384_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_384_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_384_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_384_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_384_4")
		}, "GuidingChapter_Item386_p1,GuidingChapter_Item386_p2,GuidingChapter_Item386_p3,GuidingChapter_Item386_p4,GuidingChapter_Item386_p5", 5, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_384_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_384_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_384_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_384_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_384_4")
		}, "门派-门派一览-元山派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(385, LocalStringManager.GetConfig("GuidingChapter_language", "Name_385"), 3, obsoleteItem: false, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_385_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_385_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_385_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_385_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_385_4")
		}, "GuidingChapter_Item387_p1,GuidingChapter_Item387_p2,GuidingChapter_Item387_p3,GuidingChapter_Item387_p4,GuidingChapter_Item387_p5", 5, new string[5]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_385_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_385_1"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_385_2"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_385_3"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_385_4")
		}, "门派-门派一览-元山派-特有功能"));
		_dataArray.Add(new GuidingChapterItem(386, LocalStringManager.GetConfig("GuidingChapter_language", "Name_386"), 3, obsoleteItem: false, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_386_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartTitle_386_1")
		}, "GuidingChapter_Item384_p1,GuidingChapter_Item384_p2", 2, new string[2]
		{
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_386_0"),
			LocalStringManager.GetConfig("GuidingChapter_language", "PartDesc_386_1")
		}, "门派-门派一览-血犼教-特有功能"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<GuidingChapterItem>(387);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
	}
}
