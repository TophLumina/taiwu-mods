using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Domains.Item;

namespace Config;

[Serializable]
public class Material : ConfigData<MaterialItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 白榆木
		/// </summary>
		public const short WoodOuter1 = 0;

		/// <summary>
		/// 铁梨木
		/// </summary>
		public const short WoodOuter2 = 1;

		/// <summary>
		/// 栖凤梧桐
		/// </summary>
		public const short WoodOuter3 = 2;

		/// <summary>
		/// 宝塔血榉
		/// </summary>
		public const short WoodOuter4 = 3;

		/// <summary>
		/// 天香红木
		/// </summary>
		public const short WoodOuter5 = 4;

		/// <summary>
		/// 千结黄花梨
		/// </summary>
		public const short WoodOuter6 = 5;

		/// <summary>
		/// 乌金紫檀
		/// </summary>
		public const short WoodOuter7 = 6;

		/// <summary>
		/// 孟宗竹
		/// </summary>
		public const short WoodInner1 = 7;

		/// <summary>
		/// 地脉乌藤
		/// </summary>
		public const short WoodInner2 = 8;

		/// <summary>
		/// 青菩提枝
		/// </summary>
		public const short WoodInner3 = 9;

		/// <summary>
		/// 龙盘根
		/// </summary>
		public const short WoodInner4 = 10;

		/// <summary>
		/// 百千节结木
		/// </summary>
		public const short WoodInner5 = 11;

		/// <summary>
		/// 活桃木
		/// </summary>
		public const short WoodInner6 = 12;

		/// <summary>
		/// 九曲紫竹
		/// </summary>
		public const short WoodInner7 = 13;

		/// <summary>
		/// 镔铁
		/// </summary>
		public const short MetalOuter1 = 14;

		/// <summary>
		/// 玉钢
		/// </summary>
		public const short MetalOuter2 = 15;

		/// <summary>
		/// 百岳精铁
		/// </summary>
		public const short MetalOuter3 = 16;

		/// <summary>
		/// 乌金
		/// </summary>
		public const short MetalOuter4 = 17;

		/// <summary>
		/// 天外寒铁
		/// </summary>
		public const short MetalOuter5 = 18;

		/// <summary>
		/// 五色神铁
		/// </summary>
		public const short MetalOuter6 = 19;

		/// <summary>
		/// 玄铁
		/// </summary>
		public const short MetalOuter7 = 20;

		/// <summary>
		/// 元铜
		/// </summary>
		public const short MetalInner1 = 21;

		/// <summary>
		/// 镜银
		/// </summary>
		public const short MetalInner2 = 22;

		/// <summary>
		/// 紫金
		/// </summary>
		public const short MetalInner3 = 23;

		/// <summary>
		/// 如意宝铜
		/// </summary>
		public const short MetalInner4 = 24;

		/// <summary>
		/// 狮子金
		/// </summary>
		public const short MetalInner5 = 25;

		/// <summary>
		/// 十二彩霞银
		/// </summary>
		public const short MetalInner6 = 26;

		/// <summary>
		/// 蝉壳精金
		/// </summary>
		public const short MetalInner7 = 27;

		/// <summary>
		/// 黑玛瑙
		/// </summary>
		public const short JadeOuter1 = 28;

		/// <summary>
		/// 红宝石
		/// </summary>
		public const short JadeOuter2 = 29;

		/// <summary>
		/// 青金石
		/// </summary>
		public const short JadeOuter3 = 30;

		/// <summary>
		/// 鬼纹猫眼
		/// </summary>
		public const short JadeOuter4 = 31;

		/// <summary>
		/// 辟邪金刚石
		/// </summary>
		public const short JadeOuter5 = 32;

		/// <summary>
		/// 青霄神石
		/// </summary>
		public const short JadeOuter6 = 33;

		/// <summary>
		/// 神照石
		/// </summary>
		public const short JadeOuter7 = 34;

		/// <summary>
		/// 水玉
		/// </summary>
		public const short JadeInner1 = 35;

		/// <summary>
		/// 翡翠
		/// </summary>
		public const short JadeInner2 = 36;

		/// <summary>
		/// 羊脂白玉
		/// </summary>
		public const short JadeInner3 = 37;

		/// <summary>
		/// 五色琉璃
		/// </summary>
		public const short JadeInner4 = 38;

		/// <summary>
		/// 龙血墨玉
		/// </summary>
		public const short JadeInner5 = 39;

		/// <summary>
		/// 寒玉
		/// </summary>
		public const short JadeInner6 = 40;

		/// <summary>
		/// 昆仑活玉
		/// </summary>
		public const short JadeInner7 = 41;

		/// <summary>
		/// 虎衣
		/// </summary>
		public const short FabricOuter1 = 42;

		/// <summary>
		/// 紫貂衣
		/// </summary>
		public const short FabricOuter2 = 43;

		/// <summary>
		/// 白蟒鳞
		/// </summary>
		public const short FabricOuter3 = 44;

		/// <summary>
		/// 狐仙衣
		/// </summary>
		public const short FabricOuter4 = 45;

		/// <summary>
		/// 鸾凤羽
		/// </summary>
		public const short FabricOuter5 = 46;

		/// <summary>
		/// 龙背金筋
		/// </summary>
		public const short FabricOuter6 = 47;

		/// <summary>
		/// 金缕蝉衣
		/// </summary>
		public const short FabricOuter7 = 48;

		/// <summary>
		/// 秀文黄麻
		/// </summary>
		public const short FabricInner1 = 49;

		/// <summary>
		/// 锦棉丝
		/// </summary>
		public const short FabricInner2 = 50;

		/// <summary>
		/// 百花百草丝
		/// </summary>
		public const short FabricInner3 = 51;

		/// <summary>
		/// 玄金软丝
		/// </summary>
		public const short FabricInner4 = 52;

		/// <summary>
		/// 冰蚕银丝
		/// </summary>
		public const short FabricInner5 = 53;

		/// <summary>
		/// 血露丝
		/// </summary>
		public const short FabricInner6 = 54;

		/// <summary>
		/// 天蚕丝
		/// </summary>
		public const short FabricInner7 = 55;

		/// <summary>
		/// 鸡蛋
		/// </summary>
		public const short CookingBird0 = 56;

		/// <summary>
		/// 云英鸡
		/// </summary>
		public const short CookingBird1 = 57;

		/// <summary>
		/// 绍兴麻鸭
		/// </summary>
		public const short CookingBird2 = 58;

		/// <summary>
		/// 雁鹅
		/// </summary>
		public const short CookingBird3 = 59;

		/// <summary>
		/// 乌骨鸡
		/// </summary>
		public const short CookingBird4 = 60;

		/// <summary>
		/// 玲珑鹌鹑
		/// </summary>
		public const short CookingBird5 = 61;

		/// <summary>
		/// 蓝孔雀
		/// </summary>
		public const short CookingBird6 = 62;

		/// <summary>
		/// 野兔
		/// </summary>
		public const short CookingBeast0 = 63;

		/// <summary>
		/// 山猪
		/// </summary>
		public const short CookingBeast1 = 64;

		/// <summary>
		/// 东山羊
		/// </summary>
		public const short CookingBeast2 = 65;

		/// <summary>
		/// 百花锦蛇
		/// </summary>
		public const short CookingBeast3 = 66;

		/// <summary>
		/// 梅花鹿
		/// </summary>
		public const short CookingBeast4 = 67;

		/// <summary>
		/// 象拔
		/// </summary>
		public const short CookingBeast5 = 68;

		/// <summary>
		/// 黑熊
		/// </summary>
		public const short CookingBeast6 = 69;

		/// <summary>
		/// 小麦
		/// </summary>
		public const short CookingVegetarian0 = 70;

		/// <summary>
		/// 大豆
		/// </summary>
		public const short CookingVegetarian1 = 71;

		/// <summary>
		/// 香菇
		/// </summary>
		public const short CookingVegetarian2 = 72;

		/// <summary>
		/// 玉芦笋
		/// </summary>
		public const short CookingVegetarian3 = 73;

		/// <summary>
		/// 贡莲
		/// </summary>
		public const short CookingVegetarian4 = 74;

		/// <summary>
		/// 银杏子
		/// </summary>
		public const short CookingVegetarian5 = 75;

		/// <summary>
		/// 猴头菇
		/// </summary>
		public const short CookingVegetarian6 = 76;

		/// <summary>
		/// 草鱼
		/// </summary>
		public const short CookingFish0 = 77;

		/// <summary>
		/// 青虾
		/// </summary>
		public const short CookingFish1 = 78;

		/// <summary>
		/// 岩鲤
		/// </summary>
		public const short CookingFish2 = 79;

		/// <summary>
		/// 赤蟹
		/// </summary>
		public const short CookingFish3 = 80;

		/// <summary>
		/// 四鳃鲈
		/// </summary>
		public const short CookingFish4 = 81;

		/// <summary>
		/// 两头网鲍
		/// </summary>
		public const short CookingFish5 = 82;

		/// <summary>
		/// 鲟鳇鱼
		/// </summary>
		public const short CookingFish6 = 83;

		/// <summary>
		/// 接骨草
		/// </summary>
		public const short MedicineOuterInjury1 = 140;

		/// <summary>
		/// 伏地延胡索
		/// </summary>
		public const short MedicineOuterInjury3 = 141;

		/// <summary>
		/// 神木血竭
		/// </summary>
		public const short MedicineOuterInjury5 = 142;

		/// <summary>
		/// 千年活灵芝
		/// </summary>
		public const short MedicineOuterInjury7 = 143;

		/// <summary>
		/// 紫珠草
		/// </summary>
		public const short MedicinePoisonRed1 = 144;

		/// <summary>
		/// 雪山九牛草
		/// </summary>
		public const short MedicinePoisonRed3 = 145;

		/// <summary>
		/// 白犀牛角
		/// </summary>
		public const short MedicinePoisonRed5 = 146;

		/// <summary>
		/// 玉佛露
		/// </summary>
		public const short MedicinePoisonRed7 = 147;

		/// <summary>
		/// 千年健
		/// </summary>
		public const short MedicinePenetrateResistOfOuter1 = 148;

		/// <summary>
		/// 紫花蛇舌草
		/// </summary>
		public const short MedicinePenetrateResistOfOuter3 = 149;

		/// <summary>
		/// 灵龟板
		/// </summary>
		public const short MedicinePenetrateResistOfOuter5 = 150;

		/// <summary>
		/// 女娲石
		/// </summary>
		public const short MedicinePenetrateResistOfOuter7 = 151;

		/// <summary>
		/// 虎骨
		/// </summary>
		public const short MedicineStrength1 = 152;

		/// <summary>
		/// 宿龙草
		/// </summary>
		public const short MedicineStrength3 = 153;

		/// <summary>
		/// 老猿骨
		/// </summary>
		public const short MedicineStrength5 = 154;

		/// <summary>
		/// 赤腹血龟
		/// </summary>
		public const short MedicineStrength7 = 155;

		/// <summary>
		/// 人参
		/// </summary>
		public const short MedicineInnerInjury1 = 156;

		/// <summary>
		/// 紫青降香
		/// </summary>
		public const short MedicineInnerInjury3 = 157;

		/// <summary>
		/// 黑玉沉香
		/// </summary>
		public const short MedicineInnerInjury5 = 158;

		/// <summary>
		/// 千年雪参
		/// </summary>
		public const short MedicineInnerInjury7 = 159;

		/// <summary>
		/// 青蛇胆
		/// </summary>
		public const short MedicinePoisonGloomy1 = 160;

		/// <summary>
		/// 金斑乌药
		/// </summary>
		public const short MedicinePoisonGloomy3 = 161;

		/// <summary>
		/// 玉蟾酥
		/// </summary>
		public const short MedicinePoisonGloomy5 = 162;

		/// <summary>
		/// 紫玉王参
		/// </summary>
		public const short MedicinePoisonGloomy7 = 163;

		/// <summary>
		/// 苏合香
		/// </summary>
		public const short MedicinePenetrateResistOfInner1 = 164;

		/// <summary>
		/// 夜雾石
		/// </summary>
		public const short MedicinePenetrateResistOfInner3 = 165;

		/// <summary>
		/// 灯心檀香
		/// </summary>
		public const short MedicinePenetrateResistOfInner5 = 166;

		/// <summary>
		/// 瑶池兰
		/// </summary>
		public const short MedicinePenetrateResistOfInner7 = 167;

		/// <summary>
		/// 素馨花
		/// </summary>
		public const short MedicineRecoverOfBreath1 = 168;

		/// <summary>
		/// 安魂香
		/// </summary>
		public const short MedicineRecoverOfBreath3 = 169;

		/// <summary>
		/// 黄龙木香
		/// </summary>
		public const short MedicineRecoverOfBreath5 = 170;

		/// <summary>
		/// 天香琼玉石
		/// </summary>
		public const short MedicineRecoverOfBreath7 = 171;

		/// <summary>
		/// 红蜂蜜
		/// </summary>
		public const short MedicineDisorderOfQi1 = 172;

		/// <summary>
		/// 玉鹿血
		/// </summary>
		public const short MedicineDisorderOfQi3 = 173;

		/// <summary>
		/// 白额灵蛇胆
		/// </summary>
		public const short MedicineDisorderOfQi5 = 174;

		/// <summary>
		/// 天山雪莲
		/// </summary>
		public const short MedicineDisorderOfQi7 = 175;

		/// <summary>
		/// 乌蛇骨
		/// </summary>
		public const short MedicinePoisonCold1 = 176;

		/// <summary>
		/// 红罗丁香
		/// </summary>
		public const short MedicinePoisonCold3 = 177;

		/// <summary>
		/// 百年乌头
		/// </summary>
		public const short MedicinePoisonCold5 = 178;

		/// <summary>
		/// 龙合血露
		/// </summary>
		public const short MedicinePoisonCold7 = 179;

		/// <summary>
		/// 长生百合
		/// </summary>
		public const short MedicineAvoidRateStr1 = 180;

		/// <summary>
		/// 奇香灵脂
		/// </summary>
		public const short MedicineAvoidRateStr3 = 181;

		/// <summary>
		/// 金翅鹏鸟血
		/// </summary>
		public const short MedicineAvoidRateStr5 = 182;

		/// <summary>
		/// 九色玉菩提
		/// </summary>
		public const short MedicineAvoidRateStr7 = 183;

		/// <summary>
		/// 绵黄芪
		/// </summary>
		public const short MedicineHitRateTechnique1 = 184;

		/// <summary>
		/// 翡翠芝
		/// </summary>
		public const short MedicineHitRateTechnique3 = 185;

		/// <summary>
		/// 天青水玉
		/// </summary>
		public const short MedicineHitRateTechnique5 = 186;

		/// <summary>
		/// 龙涎石乳
		/// </summary>
		public const short MedicineHitRateTechnique7 = 187;

		/// <summary>
		/// 雪蛤
		/// </summary>
		public const short MedicineHealth1 = 188;

		/// <summary>
		/// 灵芝草
		/// </summary>
		public const short MedicineHealth3 = 189;

		/// <summary>
		/// 铁皮石斛
		/// </summary>
		public const short MedicineHealth5 = 190;

		/// <summary>
		/// 人形何首乌
		/// </summary>
		public const short MedicineHealth7 = 191;

		/// <summary>
		/// 珍珠母
		/// </summary>
		public const short MedicinePoisonIllusory1 = 192;

		/// <summary>
		/// 朱心茯神
		/// </summary>
		public const short MedicinePoisonIllusory3 = 193;

		/// <summary>
		/// 龙脑冰片
		/// </summary>
		public const short MedicinePoisonIllusory5 = 194;

		/// <summary>
		/// 墨天麻
		/// </summary>
		public const short MedicinePoisonIllusory7 = 195;

		/// <summary>
		/// 满天香
		/// </summary>
		public const short MedicineAvoidRateTech1 = 196;

		/// <summary>
		/// 醒魂花
		/// </summary>
		public const short MedicineAvoidRateTech3 = 197;

		/// <summary>
		/// 苍龙骨
		/// </summary>
		public const short MedicineAvoidRateTech5 = 198;

		/// <summary>
		/// 玲珑珊瑚
		/// </summary>
		public const short MedicineAvoidRateTech7 = 199;

		/// <summary>
		/// 野仙姜
		/// </summary>
		public const short MedicineRecoverOfStance1 = 200;

		/// <summary>
		/// 鹿茸
		/// </summary>
		public const short MedicineRecoverOfStance3 = 201;

		/// <summary>
		/// 血燕窝
		/// </summary>
		public const short MedicineRecoverOfStance5 = 202;

		/// <summary>
		/// 琥珀豆蔻
		/// </summary>
		public const short MedicineRecoverOfStance7 = 203;

		/// <summary>
		/// 朱果
		/// </summary>
		public const short MedicineRecoverOtherA1 = 204;

		/// <summary>
		/// 幽胎草
		/// </summary>
		public const short MedicineRecoverOtherA3 = 205;

		/// <summary>
		/// 玉露琼浆
		/// </summary>
		public const short MedicineRecoverOtherA5 = 206;

		/// <summary>
		/// 荼冥花
		/// </summary>
		public const short MedicineRecoverOtherA7 = 207;

		/// <summary>
		/// 铅丹
		/// </summary>
		public const short MedicinePoisonRotten1 = 208;

		/// <summary>
		/// 百虫鬼箭
		/// </summary>
		public const short MedicinePoisonRotten3 = 209;

		/// <summary>
		/// 阎王鬼臼
		/// </summary>
		public const short MedicinePoisonRotten5 = 210;

		/// <summary>
		/// 乌背银蟾
		/// </summary>
		public const short MedicinePoisonRotten7 = 211;

		/// <summary>
		/// 醉芙蓉
		/// </summary>
		public const short MedicineAvoidRateSpeed1 = 212;

		/// <summary>
		/// 天竺佛座
		/// </summary>
		public const short MedicineAvoidRateSpeed3 = 213;

		/// <summary>
		/// 青鸾血
		/// </summary>
		public const short MedicineAvoidRateSpeed5 = 214;

		/// <summary>
		/// 金蚕
		/// </summary>
		public const short MedicineAvoidRateSpeed7 = 215;

		/// <summary>
		/// 碎银慈石
		/// </summary>
		public const short MedicineHitRateSpeed1 = 216;

		/// <summary>
		/// 空青石
		/// </summary>
		public const short MedicineHitRateSpeed3 = 217;

		/// <summary>
		/// 玛瑙清露
		/// </summary>
		public const short MedicineHitRateSpeed5 = 218;

		/// <summary>
		/// 炽羽寒蝉
		/// </summary>
		public const short MedicineHitRateSpeed7 = 219;

		/// <summary>
		/// 九节菖蒲
		/// </summary>
		public const short MedicineRecoverAttackA1 = 220;

		/// <summary>
		/// 银线虫草
		/// </summary>
		public const short MedicineRecoverAttackA3 = 221;

		/// <summary>
		/// 雪熊金胆
		/// </summary>
		public const short MedicineRecoverAttackA5 = 222;

		/// <summary>
		/// 舍利子
		/// </summary>
		public const short MedicineRecoverAttackA7 = 223;

		/// <summary>
		/// 犀黄
		/// </summary>
		public const short MedicinePoisonHot1 = 224;

		/// <summary>
		/// 黑熊胆
		/// </summary>
		public const short MedicinePoisonHot3 = 225;

		/// <summary>
		/// 青花龙葵
		/// </summary>
		public const short MedicinePoisonHot5 = 226;

		/// <summary>
		/// 天蛇蜕
		/// </summary>
		public const short MedicinePoisonHot7 = 227;

		/// <summary>
		/// 麝香
		/// </summary>
		public const short MedicineRecoverOtherB1 = 228;

		/// <summary>
		/// 金香附
		/// </summary>
		public const short MedicineRecoverOtherB3 = 229;

		/// <summary>
		/// 花甲茯苓
		/// </summary>
		public const short MedicineRecoverOtherB5 = 230;

		/// <summary>
		/// 金母蟠桃
		/// </summary>
		public const short MedicineRecoverOtherB7 = 231;

		/// <summary>
		/// 寄鬼虫
		/// </summary>
		public const short MedicineRecoverAttackB1 = 232;

		/// <summary>
		/// 梧桐血蛇
		/// </summary>
		public const short MedicineRecoverAttackB3 = 233;

		/// <summary>
		/// 金披蜥蜴
		/// </summary>
		public const short MedicineRecoverAttackB5 = 234;

		/// <summary>
		/// 巴蟒玄胆
		/// </summary>
		public const short MedicineRecoverAttackB7 = 235;

		/// <summary>
		/// 鸩羽
		/// </summary>
		public const short PoisonHot1 = 236;

		/// <summary>
		/// 雷公藤
		/// </summary>
		public const short PoisonHot2 = 237;

		/// <summary>
		/// 牵机草
		/// </summary>
		public const short PoisonHot3 = 238;

		/// <summary>
		/// 五煞落魂草
		/// </summary>
		public const short PoisonHot4 = 239;

		/// <summary>
		/// 杏黄蛛
		/// </summary>
		public const short PoisonHot5 = 240;

		/// <summary>
		/// 金蛇
		/// </summary>
		public const short PoisonHot6 = 241;

		/// <summary>
		/// 断肠草
		/// </summary>
		public const short PoisonHot7 = 242;

		/// <summary>
		/// 草乌头
		/// </summary>
		public const short PoisonGloomy1 = 243;

		/// <summary>
		/// 相思子
		/// </summary>
		public const short PoisonGloomy2 = 244;

		/// <summary>
		/// 紫蜈蜂
		/// </summary>
		public const short PoisonGloomy3 = 245;

		/// <summary>
		/// 鬼母杜鹃
		/// </summary>
		public const short PoisonGloomy4 = 246;

		/// <summary>
		/// 百眼蜈蚣
		/// </summary>
		public const short PoisonGloomy5 = 247;

		/// <summary>
		/// 七彩玉纱娘
		/// </summary>
		public const short PoisonGloomy6 = 248;

		/// <summary>
		/// 邪窍花
		/// </summary>
		public const short PoisonGloomy7 = 249;

		/// <summary>
		/// 冽霜草
		/// </summary>
		public const short PoisonCold1 = 250;

		/// <summary>
		/// 白蛇胆
		/// </summary>
		public const short PoisonCold2 = 251;

		/// <summary>
		/// 玄阴石
		/// </summary>
		public const short PoisonCold3 = 252;

		/// <summary>
		/// 寒玉蟾蜍
		/// </summary>
		public const short PoisonCold4 = 253;

		/// <summary>
		/// 玄冰琵琶蝎
		/// </summary>
		public const short PoisonCold5 = 254;

		/// <summary>
		/// 青蛟胆
		/// </summary>
		public const short PoisonCold6 = 255;

		/// <summary>
		/// 千年冰蚕
		/// </summary>
		public const short PoisonCold7 = 256;

		/// <summary>
		/// 红信石
		/// </summary>
		public const short PoisonRed1 = 257;

		/// <summary>
		/// 见血封喉
		/// </summary>
		public const short PoisonRed2 = 258;

		/// <summary>
		/// 一品红
		/// </summary>
		public const short PoisonRed3 = 259;

		/// <summary>
		/// 赤血斑蝎
		/// </summary>
		public const short PoisonRed4 = 260;

		/// <summary>
		/// 孔雀胆
		/// </summary>
		public const short PoisonRed5 = 261;

		/// <summary>
		/// 凤凰木
		/// </summary>
		public const short PoisonRed6 = 262;

		/// <summary>
		/// 血蟾
		/// </summary>
		public const short PoisonRed7 = 263;

		/// <summary>
		/// 腐尸虫
		/// </summary>
		public const short PoisonRotten1 = 264;

		/// <summary>
		/// 腹蛇涎
		/// </summary>
		public const short PoisonRotten2 = 265;

		/// <summary>
		/// 散瘟草
		/// </summary>
		public const short PoisonRotten3 = 266;

		/// <summary>
		/// 玄尸水
		/// </summary>
		public const short PoisonRotten4 = 267;

		/// <summary>
		/// 烂髓鬼虫
		/// </summary>
		public const short PoisonRotten5 = 268;

		/// <summary>
		/// 黑水冥蛇骨
		/// </summary>
		public const short PoisonRotten6 = 269;

		/// <summary>
		/// 千年青蛛
		/// </summary>
		public const short PoisonRotten7 = 270;

		/// <summary>
		/// 夹竹桃
		/// </summary>
		public const short PoisonIllusory1 = 271;

		/// <summary>
		/// 彼岸花
		/// </summary>
		public const short PoisonIllusory2 = 272;

		/// <summary>
		/// 缚魂丝
		/// </summary>
		public const short PoisonIllusory3 = 273;

		/// <summary>
		/// 金怠花
		/// </summary>
		public const short PoisonIllusory4 = 274;

		/// <summary>
		/// 烟煴紫瘴
		/// </summary>
		public const short PoisonIllusory5 = 275;

		/// <summary>
		/// 无寐兰
		/// </summary>
		public const short PoisonIllusory6 = 276;

		/// <summary>
		/// 人面曼陀罗
		/// </summary>
		public const short PoisonIllusory7 = 277;

		/// <summary>
		/// 白蛟卵
		/// </summary>
		public const short JiaoWhiteEgg = 278;

		/// <summary>
		/// 黑蛟卵
		/// </summary>
		public const short JiaoBlackEgg = 279;

		/// <summary>
		/// 青蛟卵
		/// </summary>
		public const short JiaoGreenEgg = 280;

		/// <summary>
		/// 赤蛟卵
		/// </summary>
		public const short JiaoRedEgg = 281;

		/// <summary>
		/// 黄蛟卵
		/// </summary>
		public const short JiaoYellowEgg = 282;

		/// <summary>
		/// 白黑蛟卵
		/// </summary>
		public const short JiaoWBEgg = 283;

		/// <summary>
		/// 白青蛟卵
		/// </summary>
		public const short JiaoWGEgg = 284;

		/// <summary>
		/// 白赤蛟卵
		/// </summary>
		public const short JiaoWREgg = 285;

		/// <summary>
		/// 白黄蛟卵
		/// </summary>
		public const short JiaoWYEgg = 286;

		/// <summary>
		/// 黑青蛟卵
		/// </summary>
		public const short JiaoBGEgg = 287;

		/// <summary>
		/// 黑赤蛟卵
		/// </summary>
		public const short JiaoBREgg = 288;

		/// <summary>
		/// 黑黄蛟卵
		/// </summary>
		public const short JiaoBYEgg = 289;

		/// <summary>
		/// 青赤蛟卵
		/// </summary>
		public const short JiaoGREgg = 290;

		/// <summary>
		/// 青黄蛟卵
		/// </summary>
		public const short JiaoGYEgg = 291;

		/// <summary>
		/// 赤黄蛟卵
		/// </summary>
		public const short JiaoRYEgg = 292;

		/// <summary>
		/// 白黑青蛟卵
		/// </summary>
		public const short JiaoWBGEgg = 293;

		/// <summary>
		/// 白黑赤蛟卵
		/// </summary>
		public const short JiaoWBREgg = 294;

		/// <summary>
		/// 白黑黄蛟卵
		/// </summary>
		public const short JiaoWBYEgg = 295;

		/// <summary>
		/// 白青赤蛟卵
		/// </summary>
		public const short JiaoWGREgg = 296;

		/// <summary>
		/// 白青黄蛟卵
		/// </summary>
		public const short JiaoWGYEgg = 297;

		/// <summary>
		/// 白赤黄蛟卵
		/// </summary>
		public const short JiaoWRYEgg = 298;

		/// <summary>
		/// 黑青赤蛟卵
		/// </summary>
		public const short JiaoBGREgg = 299;

		/// <summary>
		/// 黑青黄蛟卵
		/// </summary>
		public const short JiaoBGYEgg = 300;

		/// <summary>
		/// 黑赤黄蛟卵
		/// </summary>
		public const short JiaoBRYEgg = 301;

		/// <summary>
		/// 青赤黄蛟卵
		/// </summary>
		public const short JiaoGRYEgg = 302;

		/// <summary>
		/// 白黑青赤蛟卵
		/// </summary>
		public const short JiaoWBGREgg = 303;

		/// <summary>
		/// 白黑青黄蛟卵
		/// </summary>
		public const short JiaoWBGYEgg = 304;

		/// <summary>
		/// 白黑赤黄蛟卵
		/// </summary>
		public const short JiaoWBRYEgg = 305;

		/// <summary>
		/// 白青赤黄蛟卵
		/// </summary>
		public const short JiaoWGRYEgg = 306;

		/// <summary>
		/// 黑青赤黄蛟卵
		/// </summary>
		public const short JiaoBGRYEgg = 307;

		/// <summary>
		/// 白青赤黄黑蛟卵
		/// </summary>
		public const short JiaoWGRYBEgg = 308;

		/// <summary>
		/// 白幼蛟
		/// </summary>
		public const short JiaoWhite = 309;

		/// <summary>
		/// 黑幼蛟
		/// </summary>
		public const short JiaoBlack = 310;

		/// <summary>
		/// 青幼蛟
		/// </summary>
		public const short JiaoGreen = 311;

		/// <summary>
		/// 赤幼蛟
		/// </summary>
		public const short JiaoRed = 312;

		/// <summary>
		/// 黄幼蛟
		/// </summary>
		public const short JiaoYellow = 313;

		/// <summary>
		/// 白黑幼蛟
		/// </summary>
		public const short JiaoWB = 314;

		/// <summary>
		/// 白青幼蛟
		/// </summary>
		public const short JiaoWG = 315;

		/// <summary>
		/// 白赤幼蛟
		/// </summary>
		public const short JiaoWR = 316;

		/// <summary>
		/// 白黄幼蛟
		/// </summary>
		public const short JiaoWY = 317;

		/// <summary>
		/// 黑青幼蛟
		/// </summary>
		public const short JiaoBG = 318;

		/// <summary>
		/// 黑赤幼蛟
		/// </summary>
		public const short JiaoBR = 319;

		/// <summary>
		/// 黑黄幼蛟
		/// </summary>
		public const short JiaoBY = 320;

		/// <summary>
		/// 青赤幼蛟
		/// </summary>
		public const short JiaoGR = 321;

		/// <summary>
		/// 青黄幼蛟
		/// </summary>
		public const short JiaoGY = 322;

		/// <summary>
		/// 赤黄幼蛟
		/// </summary>
		public const short JiaoRY = 323;

		/// <summary>
		/// 白黑青幼蛟
		/// </summary>
		public const short JiaoWBG = 324;

		/// <summary>
		/// 白黑赤幼蛟
		/// </summary>
		public const short JiaoWBR = 325;

		/// <summary>
		/// 白黑黄幼蛟
		/// </summary>
		public const short JiaoWBY = 326;

		/// <summary>
		/// 白青赤幼蛟
		/// </summary>
		public const short JiaoWGR = 327;

		/// <summary>
		/// 白青黄幼蛟
		/// </summary>
		public const short JiaoWGY = 328;

		/// <summary>
		/// 白赤黄幼蛟
		/// </summary>
		public const short JiaoWRY = 329;

		/// <summary>
		/// 黑青赤幼蛟
		/// </summary>
		public const short JiaoBGR = 330;

		/// <summary>
		/// 黑青黄幼蛟
		/// </summary>
		public const short JiaoBGY = 331;

		/// <summary>
		/// 黑赤黄幼蛟
		/// </summary>
		public const short JiaoBRY = 332;

		/// <summary>
		/// 青赤黄幼蛟
		/// </summary>
		public const short JiaoGRY = 333;

		/// <summary>
		/// 白黑青赤幼蛟
		/// </summary>
		public const short JiaoWBGR = 334;

		/// <summary>
		/// 白黑青黄幼蛟
		/// </summary>
		public const short JiaoWBGY = 335;

		/// <summary>
		/// 白黑赤黄幼蛟
		/// </summary>
		public const short JiaoWBRY = 336;

		/// <summary>
		/// 白青赤黄幼蛟
		/// </summary>
		public const short JiaoWGRY = 337;

		/// <summary>
		/// 黑青赤黄幼蛟
		/// </summary>
		public const short JiaoBGRY = 338;

		/// <summary>
		/// 白青赤黄黑幼蛟
		/// </summary>
		public const short JiaoWGRYB = 339;

		/// <summary>
		/// 青竹片
		/// </summary>
		public const short GreenBambooPiece = 340;

		/// <summary>
		/// 百鸟彩羽
		/// </summary>
		public const short SectStoryFulongFeathers = 342;

		/// <summary>
		/// 冷静元鸡羽
		/// </summary>
		public const short CalmFeathers = 343;

		/// <summary>
		/// 聪颖元鸡羽
		/// </summary>
		public const short CleverFeathers = 344;

		/// <summary>
		/// 热情元鸡羽
		/// </summary>
		public const short EnthusiasticFeathers = 345;

		/// <summary>
		/// 勇壮元鸡羽
		/// </summary>
		public const short BraveFeathers = 346;

		/// <summary>
		/// 坚毅元鸡羽
		/// </summary>
		public const short FirmFeathers = 347;

		/// <summary>
		/// 福缘元鸡羽
		/// </summary>
		public const short LuckyFeathers = 348;

		/// <summary>
		/// 合道元鸡羽
		/// </summary>
		public const short PerceptiveFeathers = 349;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 白榆木
		/// </summary>
		public static MaterialItem WoodOuter1 => Instance[(short)0];

		/// <summary>
		/// 铁梨木
		/// </summary>
		public static MaterialItem WoodOuter2 => Instance[(short)1];

		/// <summary>
		/// 栖凤梧桐
		/// </summary>
		public static MaterialItem WoodOuter3 => Instance[(short)2];

		/// <summary>
		/// 宝塔血榉
		/// </summary>
		public static MaterialItem WoodOuter4 => Instance[(short)3];

		/// <summary>
		/// 天香红木
		/// </summary>
		public static MaterialItem WoodOuter5 => Instance[(short)4];

		/// <summary>
		/// 千结黄花梨
		/// </summary>
		public static MaterialItem WoodOuter6 => Instance[(short)5];

		/// <summary>
		/// 乌金紫檀
		/// </summary>
		public static MaterialItem WoodOuter7 => Instance[(short)6];

		/// <summary>
		/// 孟宗竹
		/// </summary>
		public static MaterialItem WoodInner1 => Instance[(short)7];

		/// <summary>
		/// 地脉乌藤
		/// </summary>
		public static MaterialItem WoodInner2 => Instance[(short)8];

		/// <summary>
		/// 青菩提枝
		/// </summary>
		public static MaterialItem WoodInner3 => Instance[(short)9];

		/// <summary>
		/// 龙盘根
		/// </summary>
		public static MaterialItem WoodInner4 => Instance[(short)10];

		/// <summary>
		/// 百千节结木
		/// </summary>
		public static MaterialItem WoodInner5 => Instance[(short)11];

		/// <summary>
		/// 活桃木
		/// </summary>
		public static MaterialItem WoodInner6 => Instance[(short)12];

		/// <summary>
		/// 九曲紫竹
		/// </summary>
		public static MaterialItem WoodInner7 => Instance[(short)13];

		/// <summary>
		/// 镔铁
		/// </summary>
		public static MaterialItem MetalOuter1 => Instance[(short)14];

		/// <summary>
		/// 玉钢
		/// </summary>
		public static MaterialItem MetalOuter2 => Instance[(short)15];

		/// <summary>
		/// 百岳精铁
		/// </summary>
		public static MaterialItem MetalOuter3 => Instance[(short)16];

		/// <summary>
		/// 乌金
		/// </summary>
		public static MaterialItem MetalOuter4 => Instance[(short)17];

		/// <summary>
		/// 天外寒铁
		/// </summary>
		public static MaterialItem MetalOuter5 => Instance[(short)18];

		/// <summary>
		/// 五色神铁
		/// </summary>
		public static MaterialItem MetalOuter6 => Instance[(short)19];

		/// <summary>
		/// 玄铁
		/// </summary>
		public static MaterialItem MetalOuter7 => Instance[(short)20];

		/// <summary>
		/// 元铜
		/// </summary>
		public static MaterialItem MetalInner1 => Instance[(short)21];

		/// <summary>
		/// 镜银
		/// </summary>
		public static MaterialItem MetalInner2 => Instance[(short)22];

		/// <summary>
		/// 紫金
		/// </summary>
		public static MaterialItem MetalInner3 => Instance[(short)23];

		/// <summary>
		/// 如意宝铜
		/// </summary>
		public static MaterialItem MetalInner4 => Instance[(short)24];

		/// <summary>
		/// 狮子金
		/// </summary>
		public static MaterialItem MetalInner5 => Instance[(short)25];

		/// <summary>
		/// 十二彩霞银
		/// </summary>
		public static MaterialItem MetalInner6 => Instance[(short)26];

		/// <summary>
		/// 蝉壳精金
		/// </summary>
		public static MaterialItem MetalInner7 => Instance[(short)27];

		/// <summary>
		/// 黑玛瑙
		/// </summary>
		public static MaterialItem JadeOuter1 => Instance[(short)28];

		/// <summary>
		/// 红宝石
		/// </summary>
		public static MaterialItem JadeOuter2 => Instance[(short)29];

		/// <summary>
		/// 青金石
		/// </summary>
		public static MaterialItem JadeOuter3 => Instance[(short)30];

		/// <summary>
		/// 鬼纹猫眼
		/// </summary>
		public static MaterialItem JadeOuter4 => Instance[(short)31];

		/// <summary>
		/// 辟邪金刚石
		/// </summary>
		public static MaterialItem JadeOuter5 => Instance[(short)32];

		/// <summary>
		/// 青霄神石
		/// </summary>
		public static MaterialItem JadeOuter6 => Instance[(short)33];

		/// <summary>
		/// 神照石
		/// </summary>
		public static MaterialItem JadeOuter7 => Instance[(short)34];

		/// <summary>
		/// 水玉
		/// </summary>
		public static MaterialItem JadeInner1 => Instance[(short)35];

		/// <summary>
		/// 翡翠
		/// </summary>
		public static MaterialItem JadeInner2 => Instance[(short)36];

		/// <summary>
		/// 羊脂白玉
		/// </summary>
		public static MaterialItem JadeInner3 => Instance[(short)37];

		/// <summary>
		/// 五色琉璃
		/// </summary>
		public static MaterialItem JadeInner4 => Instance[(short)38];

		/// <summary>
		/// 龙血墨玉
		/// </summary>
		public static MaterialItem JadeInner5 => Instance[(short)39];

		/// <summary>
		/// 寒玉
		/// </summary>
		public static MaterialItem JadeInner6 => Instance[(short)40];

		/// <summary>
		/// 昆仑活玉
		/// </summary>
		public static MaterialItem JadeInner7 => Instance[(short)41];

		/// <summary>
		/// 虎衣
		/// </summary>
		public static MaterialItem FabricOuter1 => Instance[(short)42];

		/// <summary>
		/// 紫貂衣
		/// </summary>
		public static MaterialItem FabricOuter2 => Instance[(short)43];

		/// <summary>
		/// 白蟒鳞
		/// </summary>
		public static MaterialItem FabricOuter3 => Instance[(short)44];

		/// <summary>
		/// 狐仙衣
		/// </summary>
		public static MaterialItem FabricOuter4 => Instance[(short)45];

		/// <summary>
		/// 鸾凤羽
		/// </summary>
		public static MaterialItem FabricOuter5 => Instance[(short)46];

		/// <summary>
		/// 龙背金筋
		/// </summary>
		public static MaterialItem FabricOuter6 => Instance[(short)47];

		/// <summary>
		/// 金缕蝉衣
		/// </summary>
		public static MaterialItem FabricOuter7 => Instance[(short)48];

		/// <summary>
		/// 秀文黄麻
		/// </summary>
		public static MaterialItem FabricInner1 => Instance[(short)49];

		/// <summary>
		/// 锦棉丝
		/// </summary>
		public static MaterialItem FabricInner2 => Instance[(short)50];

		/// <summary>
		/// 百花百草丝
		/// </summary>
		public static MaterialItem FabricInner3 => Instance[(short)51];

		/// <summary>
		/// 玄金软丝
		/// </summary>
		public static MaterialItem FabricInner4 => Instance[(short)52];

		/// <summary>
		/// 冰蚕银丝
		/// </summary>
		public static MaterialItem FabricInner5 => Instance[(short)53];

		/// <summary>
		/// 血露丝
		/// </summary>
		public static MaterialItem FabricInner6 => Instance[(short)54];

		/// <summary>
		/// 天蚕丝
		/// </summary>
		public static MaterialItem FabricInner7 => Instance[(short)55];

		/// <summary>
		/// 鸡蛋
		/// </summary>
		public static MaterialItem CookingBird0 => Instance[(short)56];

		/// <summary>
		/// 云英鸡
		/// </summary>
		public static MaterialItem CookingBird1 => Instance[(short)57];

		/// <summary>
		/// 绍兴麻鸭
		/// </summary>
		public static MaterialItem CookingBird2 => Instance[(short)58];

		/// <summary>
		/// 雁鹅
		/// </summary>
		public static MaterialItem CookingBird3 => Instance[(short)59];

		/// <summary>
		/// 乌骨鸡
		/// </summary>
		public static MaterialItem CookingBird4 => Instance[(short)60];

		/// <summary>
		/// 玲珑鹌鹑
		/// </summary>
		public static MaterialItem CookingBird5 => Instance[(short)61];

		/// <summary>
		/// 蓝孔雀
		/// </summary>
		public static MaterialItem CookingBird6 => Instance[(short)62];

		/// <summary>
		/// 野兔
		/// </summary>
		public static MaterialItem CookingBeast0 => Instance[(short)63];

		/// <summary>
		/// 山猪
		/// </summary>
		public static MaterialItem CookingBeast1 => Instance[(short)64];

		/// <summary>
		/// 东山羊
		/// </summary>
		public static MaterialItem CookingBeast2 => Instance[(short)65];

		/// <summary>
		/// 百花锦蛇
		/// </summary>
		public static MaterialItem CookingBeast3 => Instance[(short)66];

		/// <summary>
		/// 梅花鹿
		/// </summary>
		public static MaterialItem CookingBeast4 => Instance[(short)67];

		/// <summary>
		/// 象拔
		/// </summary>
		public static MaterialItem CookingBeast5 => Instance[(short)68];

		/// <summary>
		/// 黑熊
		/// </summary>
		public static MaterialItem CookingBeast6 => Instance[(short)69];

		/// <summary>
		/// 小麦
		/// </summary>
		public static MaterialItem CookingVegetarian0 => Instance[(short)70];

		/// <summary>
		/// 大豆
		/// </summary>
		public static MaterialItem CookingVegetarian1 => Instance[(short)71];

		/// <summary>
		/// 香菇
		/// </summary>
		public static MaterialItem CookingVegetarian2 => Instance[(short)72];

		/// <summary>
		/// 玉芦笋
		/// </summary>
		public static MaterialItem CookingVegetarian3 => Instance[(short)73];

		/// <summary>
		/// 贡莲
		/// </summary>
		public static MaterialItem CookingVegetarian4 => Instance[(short)74];

		/// <summary>
		/// 银杏子
		/// </summary>
		public static MaterialItem CookingVegetarian5 => Instance[(short)75];

		/// <summary>
		/// 猴头菇
		/// </summary>
		public static MaterialItem CookingVegetarian6 => Instance[(short)76];

		/// <summary>
		/// 草鱼
		/// </summary>
		public static MaterialItem CookingFish0 => Instance[(short)77];

		/// <summary>
		/// 青虾
		/// </summary>
		public static MaterialItem CookingFish1 => Instance[(short)78];

		/// <summary>
		/// 岩鲤
		/// </summary>
		public static MaterialItem CookingFish2 => Instance[(short)79];

		/// <summary>
		/// 赤蟹
		/// </summary>
		public static MaterialItem CookingFish3 => Instance[(short)80];

		/// <summary>
		/// 四鳃鲈
		/// </summary>
		public static MaterialItem CookingFish4 => Instance[(short)81];

		/// <summary>
		/// 两头网鲍
		/// </summary>
		public static MaterialItem CookingFish5 => Instance[(short)82];

		/// <summary>
		/// 鲟鳇鱼
		/// </summary>
		public static MaterialItem CookingFish6 => Instance[(short)83];

		/// <summary>
		/// 接骨草
		/// </summary>
		public static MaterialItem MedicineOuterInjury1 => Instance[(short)140];

		/// <summary>
		/// 伏地延胡索
		/// </summary>
		public static MaterialItem MedicineOuterInjury3 => Instance[(short)141];

		/// <summary>
		/// 神木血竭
		/// </summary>
		public static MaterialItem MedicineOuterInjury5 => Instance[(short)142];

		/// <summary>
		/// 千年活灵芝
		/// </summary>
		public static MaterialItem MedicineOuterInjury7 => Instance[(short)143];

		/// <summary>
		/// 紫珠草
		/// </summary>
		public static MaterialItem MedicinePoisonRed1 => Instance[(short)144];

		/// <summary>
		/// 雪山九牛草
		/// </summary>
		public static MaterialItem MedicinePoisonRed3 => Instance[(short)145];

		/// <summary>
		/// 白犀牛角
		/// </summary>
		public static MaterialItem MedicinePoisonRed5 => Instance[(short)146];

		/// <summary>
		/// 玉佛露
		/// </summary>
		public static MaterialItem MedicinePoisonRed7 => Instance[(short)147];

		/// <summary>
		/// 千年健
		/// </summary>
		public static MaterialItem MedicinePenetrateResistOfOuter1 => Instance[(short)148];

		/// <summary>
		/// 紫花蛇舌草
		/// </summary>
		public static MaterialItem MedicinePenetrateResistOfOuter3 => Instance[(short)149];

		/// <summary>
		/// 灵龟板
		/// </summary>
		public static MaterialItem MedicinePenetrateResistOfOuter5 => Instance[(short)150];

		/// <summary>
		/// 女娲石
		/// </summary>
		public static MaterialItem MedicinePenetrateResistOfOuter7 => Instance[(short)151];

		/// <summary>
		/// 虎骨
		/// </summary>
		public static MaterialItem MedicineStrength1 => Instance[(short)152];

		/// <summary>
		/// 宿龙草
		/// </summary>
		public static MaterialItem MedicineStrength3 => Instance[(short)153];

		/// <summary>
		/// 老猿骨
		/// </summary>
		public static MaterialItem MedicineStrength5 => Instance[(short)154];

		/// <summary>
		/// 赤腹血龟
		/// </summary>
		public static MaterialItem MedicineStrength7 => Instance[(short)155];

		/// <summary>
		/// 人参
		/// </summary>
		public static MaterialItem MedicineInnerInjury1 => Instance[(short)156];

		/// <summary>
		/// 紫青降香
		/// </summary>
		public static MaterialItem MedicineInnerInjury3 => Instance[(short)157];

		/// <summary>
		/// 黑玉沉香
		/// </summary>
		public static MaterialItem MedicineInnerInjury5 => Instance[(short)158];

		/// <summary>
		/// 千年雪参
		/// </summary>
		public static MaterialItem MedicineInnerInjury7 => Instance[(short)159];

		/// <summary>
		/// 青蛇胆
		/// </summary>
		public static MaterialItem MedicinePoisonGloomy1 => Instance[(short)160];

		/// <summary>
		/// 金斑乌药
		/// </summary>
		public static MaterialItem MedicinePoisonGloomy3 => Instance[(short)161];

		/// <summary>
		/// 玉蟾酥
		/// </summary>
		public static MaterialItem MedicinePoisonGloomy5 => Instance[(short)162];

		/// <summary>
		/// 紫玉王参
		/// </summary>
		public static MaterialItem MedicinePoisonGloomy7 => Instance[(short)163];

		/// <summary>
		/// 苏合香
		/// </summary>
		public static MaterialItem MedicinePenetrateResistOfInner1 => Instance[(short)164];

		/// <summary>
		/// 夜雾石
		/// </summary>
		public static MaterialItem MedicinePenetrateResistOfInner3 => Instance[(short)165];

		/// <summary>
		/// 灯心檀香
		/// </summary>
		public static MaterialItem MedicinePenetrateResistOfInner5 => Instance[(short)166];

		/// <summary>
		/// 瑶池兰
		/// </summary>
		public static MaterialItem MedicinePenetrateResistOfInner7 => Instance[(short)167];

		/// <summary>
		/// 素馨花
		/// </summary>
		public static MaterialItem MedicineRecoverOfBreath1 => Instance[(short)168];

		/// <summary>
		/// 安魂香
		/// </summary>
		public static MaterialItem MedicineRecoverOfBreath3 => Instance[(short)169];

		/// <summary>
		/// 黄龙木香
		/// </summary>
		public static MaterialItem MedicineRecoverOfBreath5 => Instance[(short)170];

		/// <summary>
		/// 天香琼玉石
		/// </summary>
		public static MaterialItem MedicineRecoverOfBreath7 => Instance[(short)171];

		/// <summary>
		/// 红蜂蜜
		/// </summary>
		public static MaterialItem MedicineDisorderOfQi1 => Instance[(short)172];

		/// <summary>
		/// 玉鹿血
		/// </summary>
		public static MaterialItem MedicineDisorderOfQi3 => Instance[(short)173];

		/// <summary>
		/// 白额灵蛇胆
		/// </summary>
		public static MaterialItem MedicineDisorderOfQi5 => Instance[(short)174];

		/// <summary>
		/// 天山雪莲
		/// </summary>
		public static MaterialItem MedicineDisorderOfQi7 => Instance[(short)175];

		/// <summary>
		/// 乌蛇骨
		/// </summary>
		public static MaterialItem MedicinePoisonCold1 => Instance[(short)176];

		/// <summary>
		/// 红罗丁香
		/// </summary>
		public static MaterialItem MedicinePoisonCold3 => Instance[(short)177];

		/// <summary>
		/// 百年乌头
		/// </summary>
		public static MaterialItem MedicinePoisonCold5 => Instance[(short)178];

		/// <summary>
		/// 龙合血露
		/// </summary>
		public static MaterialItem MedicinePoisonCold7 => Instance[(short)179];

		/// <summary>
		/// 长生百合
		/// </summary>
		public static MaterialItem MedicineAvoidRateStr1 => Instance[(short)180];

		/// <summary>
		/// 奇香灵脂
		/// </summary>
		public static MaterialItem MedicineAvoidRateStr3 => Instance[(short)181];

		/// <summary>
		/// 金翅鹏鸟血
		/// </summary>
		public static MaterialItem MedicineAvoidRateStr5 => Instance[(short)182];

		/// <summary>
		/// 九色玉菩提
		/// </summary>
		public static MaterialItem MedicineAvoidRateStr7 => Instance[(short)183];

		/// <summary>
		/// 绵黄芪
		/// </summary>
		public static MaterialItem MedicineHitRateTechnique1 => Instance[(short)184];

		/// <summary>
		/// 翡翠芝
		/// </summary>
		public static MaterialItem MedicineHitRateTechnique3 => Instance[(short)185];

		/// <summary>
		/// 天青水玉
		/// </summary>
		public static MaterialItem MedicineHitRateTechnique5 => Instance[(short)186];

		/// <summary>
		/// 龙涎石乳
		/// </summary>
		public static MaterialItem MedicineHitRateTechnique7 => Instance[(short)187];

		/// <summary>
		/// 雪蛤
		/// </summary>
		public static MaterialItem MedicineHealth1 => Instance[(short)188];

		/// <summary>
		/// 灵芝草
		/// </summary>
		public static MaterialItem MedicineHealth3 => Instance[(short)189];

		/// <summary>
		/// 铁皮石斛
		/// </summary>
		public static MaterialItem MedicineHealth5 => Instance[(short)190];

		/// <summary>
		/// 人形何首乌
		/// </summary>
		public static MaterialItem MedicineHealth7 => Instance[(short)191];

		/// <summary>
		/// 珍珠母
		/// </summary>
		public static MaterialItem MedicinePoisonIllusory1 => Instance[(short)192];

		/// <summary>
		/// 朱心茯神
		/// </summary>
		public static MaterialItem MedicinePoisonIllusory3 => Instance[(short)193];

		/// <summary>
		/// 龙脑冰片
		/// </summary>
		public static MaterialItem MedicinePoisonIllusory5 => Instance[(short)194];

		/// <summary>
		/// 墨天麻
		/// </summary>
		public static MaterialItem MedicinePoisonIllusory7 => Instance[(short)195];

		/// <summary>
		/// 满天香
		/// </summary>
		public static MaterialItem MedicineAvoidRateTech1 => Instance[(short)196];

		/// <summary>
		/// 醒魂花
		/// </summary>
		public static MaterialItem MedicineAvoidRateTech3 => Instance[(short)197];

		/// <summary>
		/// 苍龙骨
		/// </summary>
		public static MaterialItem MedicineAvoidRateTech5 => Instance[(short)198];

		/// <summary>
		/// 玲珑珊瑚
		/// </summary>
		public static MaterialItem MedicineAvoidRateTech7 => Instance[(short)199];

		/// <summary>
		/// 野仙姜
		/// </summary>
		public static MaterialItem MedicineRecoverOfStance1 => Instance[(short)200];

		/// <summary>
		/// 鹿茸
		/// </summary>
		public static MaterialItem MedicineRecoverOfStance3 => Instance[(short)201];

		/// <summary>
		/// 血燕窝
		/// </summary>
		public static MaterialItem MedicineRecoverOfStance5 => Instance[(short)202];

		/// <summary>
		/// 琥珀豆蔻
		/// </summary>
		public static MaterialItem MedicineRecoverOfStance7 => Instance[(short)203];

		/// <summary>
		/// 朱果
		/// </summary>
		public static MaterialItem MedicineRecoverOtherA1 => Instance[(short)204];

		/// <summary>
		/// 幽胎草
		/// </summary>
		public static MaterialItem MedicineRecoverOtherA3 => Instance[(short)205];

		/// <summary>
		/// 玉露琼浆
		/// </summary>
		public static MaterialItem MedicineRecoverOtherA5 => Instance[(short)206];

		/// <summary>
		/// 荼冥花
		/// </summary>
		public static MaterialItem MedicineRecoverOtherA7 => Instance[(short)207];

		/// <summary>
		/// 铅丹
		/// </summary>
		public static MaterialItem MedicinePoisonRotten1 => Instance[(short)208];

		/// <summary>
		/// 百虫鬼箭
		/// </summary>
		public static MaterialItem MedicinePoisonRotten3 => Instance[(short)209];

		/// <summary>
		/// 阎王鬼臼
		/// </summary>
		public static MaterialItem MedicinePoisonRotten5 => Instance[(short)210];

		/// <summary>
		/// 乌背银蟾
		/// </summary>
		public static MaterialItem MedicinePoisonRotten7 => Instance[(short)211];

		/// <summary>
		/// 醉芙蓉
		/// </summary>
		public static MaterialItem MedicineAvoidRateSpeed1 => Instance[(short)212];

		/// <summary>
		/// 天竺佛座
		/// </summary>
		public static MaterialItem MedicineAvoidRateSpeed3 => Instance[(short)213];

		/// <summary>
		/// 青鸾血
		/// </summary>
		public static MaterialItem MedicineAvoidRateSpeed5 => Instance[(short)214];

		/// <summary>
		/// 金蚕
		/// </summary>
		public static MaterialItem MedicineAvoidRateSpeed7 => Instance[(short)215];

		/// <summary>
		/// 碎银慈石
		/// </summary>
		public static MaterialItem MedicineHitRateSpeed1 => Instance[(short)216];

		/// <summary>
		/// 空青石
		/// </summary>
		public static MaterialItem MedicineHitRateSpeed3 => Instance[(short)217];

		/// <summary>
		/// 玛瑙清露
		/// </summary>
		public static MaterialItem MedicineHitRateSpeed5 => Instance[(short)218];

		/// <summary>
		/// 炽羽寒蝉
		/// </summary>
		public static MaterialItem MedicineHitRateSpeed7 => Instance[(short)219];

		/// <summary>
		/// 九节菖蒲
		/// </summary>
		public static MaterialItem MedicineRecoverAttackA1 => Instance[(short)220];

		/// <summary>
		/// 银线虫草
		/// </summary>
		public static MaterialItem MedicineRecoverAttackA3 => Instance[(short)221];

		/// <summary>
		/// 雪熊金胆
		/// </summary>
		public static MaterialItem MedicineRecoverAttackA5 => Instance[(short)222];

		/// <summary>
		/// 舍利子
		/// </summary>
		public static MaterialItem MedicineRecoverAttackA7 => Instance[(short)223];

		/// <summary>
		/// 犀黄
		/// </summary>
		public static MaterialItem MedicinePoisonHot1 => Instance[(short)224];

		/// <summary>
		/// 黑熊胆
		/// </summary>
		public static MaterialItem MedicinePoisonHot3 => Instance[(short)225];

		/// <summary>
		/// 青花龙葵
		/// </summary>
		public static MaterialItem MedicinePoisonHot5 => Instance[(short)226];

		/// <summary>
		/// 天蛇蜕
		/// </summary>
		public static MaterialItem MedicinePoisonHot7 => Instance[(short)227];

		/// <summary>
		/// 麝香
		/// </summary>
		public static MaterialItem MedicineRecoverOtherB1 => Instance[(short)228];

		/// <summary>
		/// 金香附
		/// </summary>
		public static MaterialItem MedicineRecoverOtherB3 => Instance[(short)229];

		/// <summary>
		/// 花甲茯苓
		/// </summary>
		public static MaterialItem MedicineRecoverOtherB5 => Instance[(short)230];

		/// <summary>
		/// 金母蟠桃
		/// </summary>
		public static MaterialItem MedicineRecoverOtherB7 => Instance[(short)231];

		/// <summary>
		/// 寄鬼虫
		/// </summary>
		public static MaterialItem MedicineRecoverAttackB1 => Instance[(short)232];

		/// <summary>
		/// 梧桐血蛇
		/// </summary>
		public static MaterialItem MedicineRecoverAttackB3 => Instance[(short)233];

		/// <summary>
		/// 金披蜥蜴
		/// </summary>
		public static MaterialItem MedicineRecoverAttackB5 => Instance[(short)234];

		/// <summary>
		/// 巴蟒玄胆
		/// </summary>
		public static MaterialItem MedicineRecoverAttackB7 => Instance[(short)235];

		/// <summary>
		/// 鸩羽
		/// </summary>
		public static MaterialItem PoisonHot1 => Instance[(short)236];

		/// <summary>
		/// 雷公藤
		/// </summary>
		public static MaterialItem PoisonHot2 => Instance[(short)237];

		/// <summary>
		/// 牵机草
		/// </summary>
		public static MaterialItem PoisonHot3 => Instance[(short)238];

		/// <summary>
		/// 五煞落魂草
		/// </summary>
		public static MaterialItem PoisonHot4 => Instance[(short)239];

		/// <summary>
		/// 杏黄蛛
		/// </summary>
		public static MaterialItem PoisonHot5 => Instance[(short)240];

		/// <summary>
		/// 金蛇
		/// </summary>
		public static MaterialItem PoisonHot6 => Instance[(short)241];

		/// <summary>
		/// 断肠草
		/// </summary>
		public static MaterialItem PoisonHot7 => Instance[(short)242];

		/// <summary>
		/// 草乌头
		/// </summary>
		public static MaterialItem PoisonGloomy1 => Instance[(short)243];

		/// <summary>
		/// 相思子
		/// </summary>
		public static MaterialItem PoisonGloomy2 => Instance[(short)244];

		/// <summary>
		/// 紫蜈蜂
		/// </summary>
		public static MaterialItem PoisonGloomy3 => Instance[(short)245];

		/// <summary>
		/// 鬼母杜鹃
		/// </summary>
		public static MaterialItem PoisonGloomy4 => Instance[(short)246];

		/// <summary>
		/// 百眼蜈蚣
		/// </summary>
		public static MaterialItem PoisonGloomy5 => Instance[(short)247];

		/// <summary>
		/// 七彩玉纱娘
		/// </summary>
		public static MaterialItem PoisonGloomy6 => Instance[(short)248];

		/// <summary>
		/// 邪窍花
		/// </summary>
		public static MaterialItem PoisonGloomy7 => Instance[(short)249];

		/// <summary>
		/// 冽霜草
		/// </summary>
		public static MaterialItem PoisonCold1 => Instance[(short)250];

		/// <summary>
		/// 白蛇胆
		/// </summary>
		public static MaterialItem PoisonCold2 => Instance[(short)251];

		/// <summary>
		/// 玄阴石
		/// </summary>
		public static MaterialItem PoisonCold3 => Instance[(short)252];

		/// <summary>
		/// 寒玉蟾蜍
		/// </summary>
		public static MaterialItem PoisonCold4 => Instance[(short)253];

		/// <summary>
		/// 玄冰琵琶蝎
		/// </summary>
		public static MaterialItem PoisonCold5 => Instance[(short)254];

		/// <summary>
		/// 青蛟胆
		/// </summary>
		public static MaterialItem PoisonCold6 => Instance[(short)255];

		/// <summary>
		/// 千年冰蚕
		/// </summary>
		public static MaterialItem PoisonCold7 => Instance[(short)256];

		/// <summary>
		/// 红信石
		/// </summary>
		public static MaterialItem PoisonRed1 => Instance[(short)257];

		/// <summary>
		/// 见血封喉
		/// </summary>
		public static MaterialItem PoisonRed2 => Instance[(short)258];

		/// <summary>
		/// 一品红
		/// </summary>
		public static MaterialItem PoisonRed3 => Instance[(short)259];

		/// <summary>
		/// 赤血斑蝎
		/// </summary>
		public static MaterialItem PoisonRed4 => Instance[(short)260];

		/// <summary>
		/// 孔雀胆
		/// </summary>
		public static MaterialItem PoisonRed5 => Instance[(short)261];

		/// <summary>
		/// 凤凰木
		/// </summary>
		public static MaterialItem PoisonRed6 => Instance[(short)262];

		/// <summary>
		/// 血蟾
		/// </summary>
		public static MaterialItem PoisonRed7 => Instance[(short)263];

		/// <summary>
		/// 腐尸虫
		/// </summary>
		public static MaterialItem PoisonRotten1 => Instance[(short)264];

		/// <summary>
		/// 腹蛇涎
		/// </summary>
		public static MaterialItem PoisonRotten2 => Instance[(short)265];

		/// <summary>
		/// 散瘟草
		/// </summary>
		public static MaterialItem PoisonRotten3 => Instance[(short)266];

		/// <summary>
		/// 玄尸水
		/// </summary>
		public static MaterialItem PoisonRotten4 => Instance[(short)267];

		/// <summary>
		/// 烂髓鬼虫
		/// </summary>
		public static MaterialItem PoisonRotten5 => Instance[(short)268];

		/// <summary>
		/// 黑水冥蛇骨
		/// </summary>
		public static MaterialItem PoisonRotten6 => Instance[(short)269];

		/// <summary>
		/// 千年青蛛
		/// </summary>
		public static MaterialItem PoisonRotten7 => Instance[(short)270];

		/// <summary>
		/// 夹竹桃
		/// </summary>
		public static MaterialItem PoisonIllusory1 => Instance[(short)271];

		/// <summary>
		/// 彼岸花
		/// </summary>
		public static MaterialItem PoisonIllusory2 => Instance[(short)272];

		/// <summary>
		/// 缚魂丝
		/// </summary>
		public static MaterialItem PoisonIllusory3 => Instance[(short)273];

		/// <summary>
		/// 金怠花
		/// </summary>
		public static MaterialItem PoisonIllusory4 => Instance[(short)274];

		/// <summary>
		/// 烟煴紫瘴
		/// </summary>
		public static MaterialItem PoisonIllusory5 => Instance[(short)275];

		/// <summary>
		/// 无寐兰
		/// </summary>
		public static MaterialItem PoisonIllusory6 => Instance[(short)276];

		/// <summary>
		/// 人面曼陀罗
		/// </summary>
		public static MaterialItem PoisonIllusory7 => Instance[(short)277];

		/// <summary>
		/// 白蛟卵
		/// </summary>
		public static MaterialItem JiaoWhiteEgg => Instance[(short)278];

		/// <summary>
		/// 黑蛟卵
		/// </summary>
		public static MaterialItem JiaoBlackEgg => Instance[(short)279];

		/// <summary>
		/// 青蛟卵
		/// </summary>
		public static MaterialItem JiaoGreenEgg => Instance[(short)280];

		/// <summary>
		/// 赤蛟卵
		/// </summary>
		public static MaterialItem JiaoRedEgg => Instance[(short)281];

		/// <summary>
		/// 黄蛟卵
		/// </summary>
		public static MaterialItem JiaoYellowEgg => Instance[(short)282];

		/// <summary>
		/// 白黑蛟卵
		/// </summary>
		public static MaterialItem JiaoWBEgg => Instance[(short)283];

		/// <summary>
		/// 白青蛟卵
		/// </summary>
		public static MaterialItem JiaoWGEgg => Instance[(short)284];

		/// <summary>
		/// 白赤蛟卵
		/// </summary>
		public static MaterialItem JiaoWREgg => Instance[(short)285];

		/// <summary>
		/// 白黄蛟卵
		/// </summary>
		public static MaterialItem JiaoWYEgg => Instance[(short)286];

		/// <summary>
		/// 黑青蛟卵
		/// </summary>
		public static MaterialItem JiaoBGEgg => Instance[(short)287];

		/// <summary>
		/// 黑赤蛟卵
		/// </summary>
		public static MaterialItem JiaoBREgg => Instance[(short)288];

		/// <summary>
		/// 黑黄蛟卵
		/// </summary>
		public static MaterialItem JiaoBYEgg => Instance[(short)289];

		/// <summary>
		/// 青赤蛟卵
		/// </summary>
		public static MaterialItem JiaoGREgg => Instance[(short)290];

		/// <summary>
		/// 青黄蛟卵
		/// </summary>
		public static MaterialItem JiaoGYEgg => Instance[(short)291];

		/// <summary>
		/// 赤黄蛟卵
		/// </summary>
		public static MaterialItem JiaoRYEgg => Instance[(short)292];

		/// <summary>
		/// 白黑青蛟卵
		/// </summary>
		public static MaterialItem JiaoWBGEgg => Instance[(short)293];

		/// <summary>
		/// 白黑赤蛟卵
		/// </summary>
		public static MaterialItem JiaoWBREgg => Instance[(short)294];

		/// <summary>
		/// 白黑黄蛟卵
		/// </summary>
		public static MaterialItem JiaoWBYEgg => Instance[(short)295];

		/// <summary>
		/// 白青赤蛟卵
		/// </summary>
		public static MaterialItem JiaoWGREgg => Instance[(short)296];

		/// <summary>
		/// 白青黄蛟卵
		/// </summary>
		public static MaterialItem JiaoWGYEgg => Instance[(short)297];

		/// <summary>
		/// 白赤黄蛟卵
		/// </summary>
		public static MaterialItem JiaoWRYEgg => Instance[(short)298];

		/// <summary>
		/// 黑青赤蛟卵
		/// </summary>
		public static MaterialItem JiaoBGREgg => Instance[(short)299];

		/// <summary>
		/// 黑青黄蛟卵
		/// </summary>
		public static MaterialItem JiaoBGYEgg => Instance[(short)300];

		/// <summary>
		/// 黑赤黄蛟卵
		/// </summary>
		public static MaterialItem JiaoBRYEgg => Instance[(short)301];

		/// <summary>
		/// 青赤黄蛟卵
		/// </summary>
		public static MaterialItem JiaoGRYEgg => Instance[(short)302];

		/// <summary>
		/// 白黑青赤蛟卵
		/// </summary>
		public static MaterialItem JiaoWBGREgg => Instance[(short)303];

		/// <summary>
		/// 白黑青黄蛟卵
		/// </summary>
		public static MaterialItem JiaoWBGYEgg => Instance[(short)304];

		/// <summary>
		/// 白黑赤黄蛟卵
		/// </summary>
		public static MaterialItem JiaoWBRYEgg => Instance[(short)305];

		/// <summary>
		/// 白青赤黄蛟卵
		/// </summary>
		public static MaterialItem JiaoWGRYEgg => Instance[(short)306];

		/// <summary>
		/// 黑青赤黄蛟卵
		/// </summary>
		public static MaterialItem JiaoBGRYEgg => Instance[(short)307];

		/// <summary>
		/// 白青赤黄黑蛟卵
		/// </summary>
		public static MaterialItem JiaoWGRYBEgg => Instance[(short)308];

		/// <summary>
		/// 白幼蛟
		/// </summary>
		public static MaterialItem JiaoWhite => Instance[(short)309];

		/// <summary>
		/// 黑幼蛟
		/// </summary>
		public static MaterialItem JiaoBlack => Instance[(short)310];

		/// <summary>
		/// 青幼蛟
		/// </summary>
		public static MaterialItem JiaoGreen => Instance[(short)311];

		/// <summary>
		/// 赤幼蛟
		/// </summary>
		public static MaterialItem JiaoRed => Instance[(short)312];

		/// <summary>
		/// 黄幼蛟
		/// </summary>
		public static MaterialItem JiaoYellow => Instance[(short)313];

		/// <summary>
		/// 白黑幼蛟
		/// </summary>
		public static MaterialItem JiaoWB => Instance[(short)314];

		/// <summary>
		/// 白青幼蛟
		/// </summary>
		public static MaterialItem JiaoWG => Instance[(short)315];

		/// <summary>
		/// 白赤幼蛟
		/// </summary>
		public static MaterialItem JiaoWR => Instance[(short)316];

		/// <summary>
		/// 白黄幼蛟
		/// </summary>
		public static MaterialItem JiaoWY => Instance[(short)317];

		/// <summary>
		/// 黑青幼蛟
		/// </summary>
		public static MaterialItem JiaoBG => Instance[(short)318];

		/// <summary>
		/// 黑赤幼蛟
		/// </summary>
		public static MaterialItem JiaoBR => Instance[(short)319];

		/// <summary>
		/// 黑黄幼蛟
		/// </summary>
		public static MaterialItem JiaoBY => Instance[(short)320];

		/// <summary>
		/// 青赤幼蛟
		/// </summary>
		public static MaterialItem JiaoGR => Instance[(short)321];

		/// <summary>
		/// 青黄幼蛟
		/// </summary>
		public static MaterialItem JiaoGY => Instance[(short)322];

		/// <summary>
		/// 赤黄幼蛟
		/// </summary>
		public static MaterialItem JiaoRY => Instance[(short)323];

		/// <summary>
		/// 白黑青幼蛟
		/// </summary>
		public static MaterialItem JiaoWBG => Instance[(short)324];

		/// <summary>
		/// 白黑赤幼蛟
		/// </summary>
		public static MaterialItem JiaoWBR => Instance[(short)325];

		/// <summary>
		/// 白黑黄幼蛟
		/// </summary>
		public static MaterialItem JiaoWBY => Instance[(short)326];

		/// <summary>
		/// 白青赤幼蛟
		/// </summary>
		public static MaterialItem JiaoWGR => Instance[(short)327];

		/// <summary>
		/// 白青黄幼蛟
		/// </summary>
		public static MaterialItem JiaoWGY => Instance[(short)328];

		/// <summary>
		/// 白赤黄幼蛟
		/// </summary>
		public static MaterialItem JiaoWRY => Instance[(short)329];

		/// <summary>
		/// 黑青赤幼蛟
		/// </summary>
		public static MaterialItem JiaoBGR => Instance[(short)330];

		/// <summary>
		/// 黑青黄幼蛟
		/// </summary>
		public static MaterialItem JiaoBGY => Instance[(short)331];

		/// <summary>
		/// 黑赤黄幼蛟
		/// </summary>
		public static MaterialItem JiaoBRY => Instance[(short)332];

		/// <summary>
		/// 青赤黄幼蛟
		/// </summary>
		public static MaterialItem JiaoGRY => Instance[(short)333];

		/// <summary>
		/// 白黑青赤幼蛟
		/// </summary>
		public static MaterialItem JiaoWBGR => Instance[(short)334];

		/// <summary>
		/// 白黑青黄幼蛟
		/// </summary>
		public static MaterialItem JiaoWBGY => Instance[(short)335];

		/// <summary>
		/// 白黑赤黄幼蛟
		/// </summary>
		public static MaterialItem JiaoWBRY => Instance[(short)336];

		/// <summary>
		/// 白青赤黄幼蛟
		/// </summary>
		public static MaterialItem JiaoWGRY => Instance[(short)337];

		/// <summary>
		/// 黑青赤黄幼蛟
		/// </summary>
		public static MaterialItem JiaoBGRY => Instance[(short)338];

		/// <summary>
		/// 白青赤黄黑幼蛟
		/// </summary>
		public static MaterialItem JiaoWGRYB => Instance[(short)339];

		/// <summary>
		/// 青竹片
		/// </summary>
		public static MaterialItem GreenBambooPiece => Instance[(short)340];

		/// <summary>
		/// 百鸟彩羽
		/// </summary>
		public static MaterialItem SectStoryFulongFeathers => Instance[(short)342];

		/// <summary>
		/// 冷静元鸡羽
		/// </summary>
		public static MaterialItem CalmFeathers => Instance[(short)343];

		/// <summary>
		/// 聪颖元鸡羽
		/// </summary>
		public static MaterialItem CleverFeathers => Instance[(short)344];

		/// <summary>
		/// 热情元鸡羽
		/// </summary>
		public static MaterialItem EnthusiasticFeathers => Instance[(short)345];

		/// <summary>
		/// 勇壮元鸡羽
		/// </summary>
		public static MaterialItem BraveFeathers => Instance[(short)346];

		/// <summary>
		/// 坚毅元鸡羽
		/// </summary>
		public static MaterialItem FirmFeathers => Instance[(short)347];

		/// <summary>
		/// 福缘元鸡羽
		/// </summary>
		public static MaterialItem LuckyFeathers => Instance[(short)348];

		/// <summary>
		/// 合道元鸡羽
		/// </summary>
		public static MaterialItem PerceptiveFeathers => Instance[(short)349];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static Material Instance = new Material();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "ItemSubType", "GroupId", "Desc", "FunctionDesc", "ResourceType", "BreakBonusEffect", "TaskLock", "RefiningEffect", "RequiredLifeSkillType",
		"CraftableItemTypes", "DisassembleResultItemList", "PrimaryEffectType", "PrimaryEffectSubType", "SecondaryEffectType", "SecondaryEffectSubType", "TemplateId", "Grade", "Icon", "BaseWeight",
		"ResourceAmount", "RequiredAttainment"
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
		_dataArray.Add(new MaterialItem(0, LocalStringManager.GetConfig("Material_language", "Name_0"), 5, 501, 1, 0, "icon_Material_baiyumu", LocalStringManager.GetConfig("Material_language", "Desc_0"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_0"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 60, 300, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 50, 7, 30, 5, new List<short>
		{
			5, 9, 15, 21, 27, 33, 41, 47, 53, 59,
			65, 70, 74, 79, 87, 95, 103, 111, 120
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(1, LocalStringManager.GetConfig("Material_language", "Name_1"), 5, 501, 2, 0, "icon_Material_tielimu", LocalStringManager.GetConfig("Material_language", "Desc_1"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_1"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 120, 900, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 100, 7, 60, 10, new List<short>
		{
			5, 9, 15, 21, 27, 33, 41, 47, 53, 59,
			65, 70, 74, 79, 87, 95, 103, 111, 120
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(2, LocalStringManager.GetConfig("Material_language", "Name_2"), 5, 501, 3, 0, "icon_Material_qifengwutong", LocalStringManager.GetConfig("Material_language", "Desc_2"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_2"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 80, 2250, 1, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 200, 7, 100, 20, new List<short>
		{
			5, 9, 15, 21, 27, 33, 41, 47, 53, 59,
			65, 70, 74, 79, 87, 95, 103, 111, 120
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(3, LocalStringManager.GetConfig("Material_language", "Name_3"), 5, 501, 4, 0, "icon_Material_baotaxueju", LocalStringManager.GetConfig("Material_language", "Desc_3"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_3"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 4650, 2, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 400, 7, 150, 40, new List<short>
		{
			5, 9, 15, 21, 27, 33, 41, 47, 53, 59,
			65, 70, 74, 79, 87, 95, 103, 111, 120
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(4, LocalStringManager.GetConfig("Material_language", "Name_4"), 5, 501, 5, 0, "icon_Material_tianxianghongmu", LocalStringManager.GetConfig("Material_language", "Desc_4"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_4"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 120, 8400, 3, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 600, 7, 210, 80, new List<short>
		{
			5, 9, 15, 21, 27, 33, 41, 47, 53, 59,
			65, 70, 74, 79, 87, 95, 103, 111, 120
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(5, LocalStringManager.GetConfig("Material_language", "Name_5"), 5, 501, 6, 0, "icon_Material_qianjiehuanghuali", LocalStringManager.GetConfig("Material_language", "Desc_5"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_5"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 80, 13800, 4, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 800, 7, 280, 160, new List<short>
		{
			5, 9, 15, 21, 27, 33, 41, 47, 53, 59,
			65, 70, 74, 79, 87, 95, 103, 111, 120
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(6, LocalStringManager.GetConfig("Material_language", "Name_6"), 5, 501, 7, 0, "icon_Material_wujinzitan", LocalStringManager.GetConfig("Material_language", "Desc_6"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_6"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 21150, 5, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 1000, 7, 360, 320, new List<short>
		{
			5, 9, 15, 21, 27, 33, 41, 47, 53, 59,
			65, 70, 74, 79, 87, 95, 103, 111, 120
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(7, LocalStringManager.GetConfig("Material_language", "Name_7"), 5, 501, 1, 7, "icon_Material_mengzongzhu", LocalStringManager.GetConfig("Material_language", "Desc_7"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_7"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 50, 300, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 50, 7, 30, 5, new List<short>
		{
			12, 18, 24, 30, 37, 44, 50, 56, 62, 68,
			72, 76, 83, 91, 99, 107, 115, 121
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(8, LocalStringManager.GetConfig("Material_language", "Name_8"), 5, 501, 2, 7, "icon_Material_dimaiwuteng", LocalStringManager.GetConfig("Material_language", "Desc_8"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_8"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 40, 900, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 100, 7, 60, 10, new List<short>
		{
			12, 18, 24, 30, 37, 44, 50, 56, 62, 68,
			72, 76, 83, 91, 99, 107, 115, 121
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(9, LocalStringManager.GetConfig("Material_language", "Name_9"), 5, 501, 3, 7, "icon_Material_qingputizhi", LocalStringManager.GetConfig("Material_language", "Desc_9"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_9"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 2250, 1, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 200, 7, 100, 20, new List<short>
		{
			12, 18, 24, 30, 37, 44, 50, 56, 62, 68,
			72, 76, 83, 91, 99, 107, 115, 121
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(10, LocalStringManager.GetConfig("Material_language", "Name_10"), 5, 501, 4, 7, "icon_Material_longpangen", LocalStringManager.GetConfig("Material_language", "Desc_10"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_10"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 4650, 2, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 400, 7, 150, 40, new List<short>
		{
			12, 18, 24, 30, 37, 44, 50, 56, 62, 68,
			72, 76, 83, 91, 99, 107, 115, 121
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(11, LocalStringManager.GetConfig("Material_language", "Name_11"), 5, 501, 5, 7, "icon_Material_baiqianjiejiemu", LocalStringManager.GetConfig("Material_language", "Desc_11"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_11"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 50, 8400, 3, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 600, 7, 210, 80, new List<short>
		{
			12, 18, 24, 30, 37, 44, 50, 56, 62, 68,
			72, 76, 83, 91, 99, 107, 115, 121
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(12, LocalStringManager.GetConfig("Material_language", "Name_12"), 5, 501, 6, 7, "icon_Material_huotaomu", LocalStringManager.GetConfig("Material_language", "Desc_12"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_12"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 60, 13800, 4, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 800, 7, 280, 160, new List<short>
		{
			12, 18, 24, 30, 37, 44, 50, 56, 62, 68,
			72, 76, 83, 91, 99, 107, 115, 121
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(13, LocalStringManager.GetConfig("Material_language", "Name_13"), 5, 501, 7, 7, "icon_Material_jiuquzizhu", LocalStringManager.GetConfig("Material_language", "Desc_13"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_13"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 50, 21150, 5, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 1, 36, EMaterialProperty.Invalid, 30, new List<int>(), -1, 1000, 7, 360, 320, new List<short>
		{
			12, 18, 24, 30, 37, 44, 50, 56, 62, 68,
			72, 76, 83, 91, 99, 107, 115, 121
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(14, LocalStringManager.GetConfig("Material_language", "Name_14"), 5, 502, 1, 14, "icon_Material_bintie", LocalStringManager.GetConfig("Material_language", "Desc_14"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_14"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 300, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 50, 6, 30, 5, new List<short>
		{
			4, 8, 14, 20, 26, 32, 40, 46, 52, 58,
			64, 78, 86, 94, 102, 110
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(15, LocalStringManager.GetConfig("Material_language", "Name_15"), 5, 502, 2, 14, "icon_Material_yugang", LocalStringManager.GetConfig("Material_language", "Desc_15"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_15"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 150, 900, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 100, 6, 60, 10, new List<short>
		{
			4, 8, 14, 20, 26, 32, 40, 46, 52, 58,
			64, 78, 86, 94, 102, 110
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(16, LocalStringManager.GetConfig("Material_language", "Name_16"), 5, 502, 3, 14, "icon_Material_baiyuejingtie", LocalStringManager.GetConfig("Material_language", "Desc_16"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_16"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 180, 2250, 1, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 200, 6, 100, 20, new List<short>
		{
			4, 8, 14, 20, 26, 32, 40, 46, 52, 58,
			64, 78, 86, 94, 102, 110
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(17, LocalStringManager.GetConfig("Material_language", "Name_17"), 5, 502, 4, 14, "icon_Material_wujin", LocalStringManager.GetConfig("Material_language", "Desc_17"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_17"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 120, 4650, 2, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 400, 6, 150, 40, new List<short>
		{
			4, 8, 14, 20, 26, 32, 40, 46, 52, 58,
			64, 78, 86, 94, 102, 110
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(18, LocalStringManager.GetConfig("Material_language", "Name_18"), 5, 502, 5, 14, "icon_Material_tianwaihantie", LocalStringManager.GetConfig("Material_language", "Desc_18"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_18"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 200, 8400, 3, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 600, 6, 210, 80, new List<short>
		{
			4, 8, 14, 20, 26, 32, 40, 46, 52, 58,
			64, 78, 86, 94, 102, 110
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(19, LocalStringManager.GetConfig("Material_language", "Name_19"), 5, 502, 6, 14, "icon_Material_wuseshentie", LocalStringManager.GetConfig("Material_language", "Desc_19"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_19"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 280, 13800, 4, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 800, 6, 280, 160, new List<short>
		{
			4, 8, 14, 20, 26, 32, 40, 46, 52, 58,
			64, 78, 86, 94, 102, 110
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(20, LocalStringManager.GetConfig("Material_language", "Name_20"), 5, 502, 7, 14, "icon_Material_xuantie", LocalStringManager.GetConfig("Material_language", "Desc_20"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_20"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 360, 21150, 5, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 1000, 6, 360, 320, new List<short>
		{
			4, 8, 14, 20, 26, 32, 40, 46, 52, 58,
			64, 78, 86, 94, 102, 110
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(21, LocalStringManager.GetConfig("Material_language", "Name_21"), 5, 502, 1, 21, "icon_Material_yuantong", LocalStringManager.GetConfig("Material_language", "Desc_21"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_21"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 50, 6, 30, 5, new List<short>
		{
			11, 17, 23, 29, 36, 43, 49, 55, 61, 67,
			82, 90, 98, 106, 114
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(22, LocalStringManager.GetConfig("Material_language", "Name_22"), 5, 502, 2, 21, "icon_Material_jingyin", LocalStringManager.GetConfig("Material_language", "Desc_22"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_22"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 60, 900, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 100, 6, 60, 10, new List<short>
		{
			11, 17, 23, 29, 36, 43, 49, 55, 61, 67,
			82, 90, 98, 106, 114
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(23, LocalStringManager.GetConfig("Material_language", "Name_23"), 5, 502, 3, 21, "icon_Material_zijin", LocalStringManager.GetConfig("Material_language", "Desc_23"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_23"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 120, 2250, 1, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 200, 6, 100, 20, new List<short>
		{
			11, 17, 23, 29, 36, 43, 49, 55, 61, 67,
			82, 90, 98, 106, 114
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(24, LocalStringManager.GetConfig("Material_language", "Name_24"), 5, 502, 4, 21, "icon_Material_ruyibaotong", LocalStringManager.GetConfig("Material_language", "Desc_24"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_24"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 140, 4650, 2, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 400, 6, 150, 40, new List<short>
		{
			11, 17, 23, 29, 36, 43, 49, 55, 61, 67,
			82, 90, 98, 106, 114
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(25, LocalStringManager.GetConfig("Material_language", "Name_25"), 5, 502, 5, 21, "icon_Material_shizijin", LocalStringManager.GetConfig("Material_language", "Desc_25"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_25"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 180, 8400, 3, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 600, 6, 210, 80, new List<short>
		{
			11, 17, 23, 29, 36, 43, 49, 55, 61, 67,
			82, 90, 98, 106, 114
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(26, LocalStringManager.GetConfig("Material_language", "Name_26"), 5, 502, 6, 21, "icon_Material_shiercaixiayin", LocalStringManager.GetConfig("Material_language", "Desc_26"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_26"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 50, 13800, 4, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 800, 6, 280, 160, new List<short>
		{
			11, 17, 23, 29, 36, 43, 49, 55, 61, 67,
			82, 90, 98, 106, 114
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(27, LocalStringManager.GetConfig("Material_language", "Name_27"), 5, 502, 7, 21, "icon_Material_chankejingjin", LocalStringManager.GetConfig("Material_language", "Desc_27"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_27"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 40, 21150, 5, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 2, 36, EMaterialProperty.Invalid, 29, new List<int>(), -1, 1000, 6, 360, 320, new List<short>
		{
			11, 17, 23, 29, 36, 43, 49, 55, 61, 67,
			82, 90, 98, 106, 114
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(28, LocalStringManager.GetConfig("Material_language", "Name_28"), 5, 503, 1, 28, "icon_Material_heimanao", LocalStringManager.GetConfig("Material_language", "Desc_28"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_28"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 300, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 50, 11, 30, 5, new List<short>
		{
			10, 16, 22, 28, 34, 42, 48, 54, 60, 66,
			80, 88, 96, 104, 112
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(29, LocalStringManager.GetConfig("Material_language", "Name_29"), 5, 503, 2, 28, "icon_Material_hongbaoshi", LocalStringManager.GetConfig("Material_language", "Desc_29"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_29"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 900, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 100, 11, 60, 10, new List<short>
		{
			10, 16, 22, 28, 34, 42, 48, 54, 60, 66,
			80, 88, 96, 104, 112
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(30, LocalStringManager.GetConfig("Material_language", "Name_30"), 5, 503, 3, 28, "icon_Material_qingjinshi", LocalStringManager.GetConfig("Material_language", "Desc_30"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_30"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 40, 2250, 1, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 200, 11, 100, 20, new List<short>
		{
			10, 16, 22, 28, 34, 42, 48, 54, 60, 66,
			80, 88, 96, 104, 112
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(31, LocalStringManager.GetConfig("Material_language", "Name_31"), 5, 503, 4, 28, "icon_Material_guiwenmaoyan", LocalStringManager.GetConfig("Material_language", "Desc_31"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_31"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 4650, 2, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 400, 11, 150, 40, new List<short>
		{
			10, 16, 22, 28, 34, 42, 48, 54, 60, 66,
			80, 88, 96, 104, 112
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(32, LocalStringManager.GetConfig("Material_language", "Name_32"), 5, 503, 5, 28, "icon_Material_bixiejingangshi", LocalStringManager.GetConfig("Material_language", "Desc_32"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_32"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 90, 8400, 3, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 600, 11, 210, 80, new List<short>
		{
			10, 16, 22, 28, 34, 42, 48, 54, 60, 66,
			80, 88, 96, 104, 112
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(33, LocalStringManager.GetConfig("Material_language", "Name_33"), 5, 503, 6, 28, "icon_Material_qingxiaoshenshi", LocalStringManager.GetConfig("Material_language", "Desc_33"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_33"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 60, 13800, 4, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 800, 11, 280, 160, new List<short>
		{
			10, 16, 22, 28, 34, 42, 48, 54, 60, 66,
			80, 88, 96, 104, 112
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(34, LocalStringManager.GetConfig("Material_language", "Name_34"), 5, 503, 7, 28, "icon_Material_shenzhaoshi", LocalStringManager.GetConfig("Material_language", "Desc_34"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_34"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 80, 21150, 5, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 1000, 11, 360, 320, new List<short>
		{
			10, 16, 22, 28, 34, 42, 48, 54, 60, 66,
			80, 88, 96, 104, 112
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(35, LocalStringManager.GetConfig("Material_language", "Name_35"), 5, 503, 1, 35, "icon_Material_shuiyu", LocalStringManager.GetConfig("Material_language", "Desc_35"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_35"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 300, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 50, 11, 30, 5, new List<short>
		{
			6, 13, 19, 25, 31, 38, 45, 51, 57, 63,
			69, 84, 92, 100, 108, 116
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(36, LocalStringManager.GetConfig("Material_language", "Name_36"), 5, 503, 2, 35, "icon_Material_feicui", LocalStringManager.GetConfig("Material_language", "Desc_36"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_36"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 900, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 100, 11, 60, 10, new List<short>
		{
			6, 13, 19, 25, 31, 38, 45, 51, 57, 63,
			69, 84, 92, 100, 108, 116
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(37, LocalStringManager.GetConfig("Material_language", "Name_37"), 5, 503, 3, 35, "icon_Material_yangzhibaiyu", LocalStringManager.GetConfig("Material_language", "Desc_37"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_37"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 40, 2250, 1, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 200, 11, 100, 20, new List<short>
		{
			6, 13, 19, 25, 31, 38, 45, 51, 57, 63,
			69, 84, 92, 100, 108, 116
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(38, LocalStringManager.GetConfig("Material_language", "Name_38"), 5, 503, 4, 35, "icon_Material_wuseliuli", LocalStringManager.GetConfig("Material_language", "Desc_38"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_38"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 60, 4650, 2, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 400, 11, 150, 40, new List<short>
		{
			6, 13, 19, 25, 31, 38, 45, 51, 57, 63,
			69, 84, 92, 100, 108, 116
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(39, LocalStringManager.GetConfig("Material_language", "Name_39"), 5, 503, 5, 35, "icon_Material_longxuemoyu", LocalStringManager.GetConfig("Material_language", "Desc_39"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_39"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 80, 8400, 3, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 600, 11, 210, 80, new List<short>
		{
			6, 13, 19, 25, 31, 38, 45, 51, 57, 63,
			69, 84, 92, 100, 108, 116
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(40, LocalStringManager.GetConfig("Material_language", "Name_40"), 5, 503, 6, 35, "icon_Material_hanyu", LocalStringManager.GetConfig("Material_language", "Desc_40"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_40"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 60, 13800, 4, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 800, 11, 280, 160, new List<short>
		{
			6, 13, 19, 25, 31, 38, 45, 51, 57, 63,
			69, 84, 92, 100, 108, 116
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(41, LocalStringManager.GetConfig("Material_language", "Name_41"), 5, 503, 7, 35, "icon_Material_kunlunhuoyu", LocalStringManager.GetConfig("Material_language", "Desc_41"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_41"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 90, 21150, 5, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 3, 36, EMaterialProperty.Invalid, 31, new List<int>(), -1, 1000, 11, 360, 320, new List<short>
		{
			6, 13, 19, 25, 31, 38, 45, 51, 57, 63,
			69, 84, 92, 100, 108, 116
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(42, LocalStringManager.GetConfig("Material_language", "Name_42"), 5, 504, 1, 42, "icon_Material_huyi", LocalStringManager.GetConfig("Material_language", "Desc_42"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_42"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 50, 300, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 50, 10, 30, 5, new List<short>
		{
			35, 71, 75, 81, 89, 97, 105, 113, 118, 122,
			123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(43, LocalStringManager.GetConfig("Material_language", "Name_43"), 5, 504, 2, 42, "icon_Material_zidiaoyi", LocalStringManager.GetConfig("Material_language", "Desc_43"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_43"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 40, 900, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 100, 10, 60, 10, new List<short>
		{
			35, 71, 75, 81, 89, 97, 105, 113, 118, 122,
			123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(44, LocalStringManager.GetConfig("Material_language", "Name_44"), 5, 504, 3, 42, "icon_Material_baimanglin", LocalStringManager.GetConfig("Material_language", "Desc_44"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_44"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 2250, 1, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 200, 10, 100, 20, new List<short>
		{
			35, 71, 75, 81, 89, 97, 105, 113, 118, 122,
			123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(45, LocalStringManager.GetConfig("Material_language", "Name_45"), 5, 504, 4, 42, "icon_Material_huxianyi", LocalStringManager.GetConfig("Material_language", "Desc_45"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_45"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 40, 4650, 2, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 400, 10, 150, 40, new List<short>
		{
			35, 71, 75, 81, 89, 97, 105, 113, 118, 122,
			123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(46, LocalStringManager.GetConfig("Material_language", "Name_46"), 5, 504, 5, 42, "icon_Material_luanfengyu", LocalStringManager.GetConfig("Material_language", "Desc_46"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_46"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 8400, 3, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 600, 10, 210, 80, new List<short>
		{
			35, 71, 75, 81, 89, 97, 105, 113, 118, 122,
			123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(47, LocalStringManager.GetConfig("Material_language", "Name_47"), 5, 504, 6, 42, "icon_Material_longbeijinjin", LocalStringManager.GetConfig("Material_language", "Desc_47"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_47"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 60, 13800, 4, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 800, 10, 280, 160, new List<short>
		{
			35, 71, 75, 81, 89, 97, 105, 113, 118, 122,
			123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(48, LocalStringManager.GetConfig("Material_language", "Name_48"), 5, 504, 7, 42, "icon_Material_jinluchanyi", LocalStringManager.GetConfig("Material_language", "Desc_48"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_48"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 21150, 5, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 1000, 10, 360, 320, new List<short>
		{
			35, 71, 75, 81, 89, 97, 105, 113, 118, 122,
			123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(49, LocalStringManager.GetConfig("Material_language", "Name_49"), 5, 504, 1, 49, "icon_Material_xiuwenhuangma", LocalStringManager.GetConfig("Material_language", "Desc_49"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_49"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 300, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 50, 10, 30, 5, new List<short>
		{
			7, 39, 73, 77, 85, 93, 101, 109, 117, 119,
			122, 123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(50, LocalStringManager.GetConfig("Material_language", "Name_50"), 5, 504, 2, 49, "icon_Material_jinmiansi", LocalStringManager.GetConfig("Material_language", "Desc_50"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_50"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 900, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 100, 10, 60, 10, new List<short>
		{
			7, 39, 73, 77, 85, 93, 101, 109, 117, 119,
			122, 123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(51, LocalStringManager.GetConfig("Material_language", "Name_51"), 5, 504, 3, 49, "icon_Material_baihuabaicaosi", LocalStringManager.GetConfig("Material_language", "Desc_51"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_51"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 2250, 1, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 200, 10, 100, 20, new List<short>
		{
			7, 39, 73, 77, 85, 93, 101, 109, 117, 119,
			122, 123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(52, LocalStringManager.GetConfig("Material_language", "Name_52"), 5, 504, 4, 49, "icon_Material_xuanjinruansi", LocalStringManager.GetConfig("Material_language", "Desc_52"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_52"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 4650, 2, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 400, 10, 150, 40, new List<short>
		{
			7, 39, 73, 77, 85, 93, 101, 109, 117, 119,
			122, 123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(53, LocalStringManager.GetConfig("Material_language", "Name_53"), 5, 504, 5, 49, "icon_Material_bingcanyinsi", LocalStringManager.GetConfig("Material_language", "Desc_53"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_53"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 8400, 3, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 600, 10, 210, 80, new List<short>
		{
			7, 39, 73, 77, 85, 93, 101, 109, 117, 119,
			122, 123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(54, LocalStringManager.GetConfig("Material_language", "Name_54"), 5, 504, 6, 49, "icon_Material_xuelusi", LocalStringManager.GetConfig("Material_language", "Desc_54"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_54"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 13800, 4, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 800, 10, 280, 160, new List<short>
		{
			7, 39, 73, 77, 85, 93, 101, 109, 117, 119,
			122, 123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(55, LocalStringManager.GetConfig("Material_language", "Name_55"), 5, 504, 7, 49, "icon_Material_tiancansi", LocalStringManager.GetConfig("Material_language", "Desc_55"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_55"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 21150, 5, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 4, 36, EMaterialProperty.Invalid, 32, new List<int>(), -1, 1000, 10, 360, 320, new List<short>
		{
			7, 39, 73, 77, 85, 93, 101, 109, 117, 119,
			122, 123
		}, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(56, LocalStringManager.GetConfig("Material_language", "Name_56"), 5, 500, 0, 56, "icon_Material_jidan", LocalStringManager.GetConfig("Material_language", "Desc_56"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_56"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 50, 0, 1, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 25, 14, 10, 5, new List<short> { 124 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Bird, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(57, LocalStringManager.GetConfig("Material_language", "Name_57"), 5, 500, 1, 56, "icon_Material_yunyingji", LocalStringManager.GetConfig("Material_language", "Desc_57"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_57"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 100, 0, 2, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 50, 14, 30, 10, new List<short> { 125 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Bird, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(58, LocalStringManager.GetConfig("Material_language", "Name_58"), 5, 500, 2, 56, "icon_Material_shaoxingmaya", LocalStringManager.GetConfig("Material_language", "Desc_58"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_58"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 50, 300, 0, 3, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 100, 14, 60, 20, new List<short> { 126 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Bird, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(59, LocalStringManager.GetConfig("Material_language", "Name_59"), 5, 500, 3, 56, "icon_Material_yane", LocalStringManager.GetConfig("Material_language", "Desc_59"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_59"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 60, 750, 0, 4, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 200, 14, 100, 40, new List<short> { 127 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Bird, EMaterialFilterHardness.Invalid));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new MaterialItem(60, LocalStringManager.GetConfig("Material_language", "Name_60"), 5, 500, 4, 56, "icon_Material_wuguji", LocalStringManager.GetConfig("Material_language", "Desc_60"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_60"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 40, 1550, 1, 5, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 14, 150, 80, new List<short> { 128 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Bird, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(61, LocalStringManager.GetConfig("Material_language", "Name_61"), 5, 500, 5, 56, "icon_Material_linglonganchun", LocalStringManager.GetConfig("Material_language", "Desc_61"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_61"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 14, 210, 160, new List<short> { 129 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Bird, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(62, LocalStringManager.GetConfig("Material_language", "Name_62"), 5, 500, 6, 56, "icon_Material_lankongque", LocalStringManager.GetConfig("Material_language", "Desc_62"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_62"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 80, 4600, 3, 7, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 14, 280, 320, new List<short> { 130 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Bird, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(63, LocalStringManager.GetConfig("Material_language", "Name_63"), 5, 500, 0, 63, "icon_Material_yetu", LocalStringManager.GetConfig("Material_language", "Desc_63"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_63"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 50, 0, 1, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 25, 14, 10, 5, new List<short> { 131 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Beast, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(64, LocalStringManager.GetConfig("Material_language", "Name_64"), 5, 500, 1, 63, "icon_Material_shanzhu", LocalStringManager.GetConfig("Material_language", "Desc_64"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_64"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 60, 100, 0, 2, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 50, 14, 30, 10, new List<short> { 132 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Beast, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(65, LocalStringManager.GetConfig("Material_language", "Name_65"), 5, 500, 2, 63, "icon_Material_dongshanyang", LocalStringManager.GetConfig("Material_language", "Desc_65"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_65"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 50, 300, 0, 3, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 100, 14, 60, 20, new List<short> { 133 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Beast, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(66, LocalStringManager.GetConfig("Material_language", "Name_66"), 5, 500, 3, 63, "icon_Material_baihuajinshe", LocalStringManager.GetConfig("Material_language", "Desc_66"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_66"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 750, 0, 4, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 200, 14, 100, 40, new List<short> { 134 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Beast, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(67, LocalStringManager.GetConfig("Material_language", "Name_67"), 5, 500, 4, 63, "icon_Material_meihualu", LocalStringManager.GetConfig("Material_language", "Desc_67"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_67"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 60, 1550, 1, 5, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 14, 150, 80, new List<short> { 135 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Beast, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(68, LocalStringManager.GetConfig("Material_language", "Name_68"), 5, 500, 5, 63, "icon_Material_xiangba", LocalStringManager.GetConfig("Material_language", "Desc_68"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_68"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 120, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 14, 210, 160, new List<short> { 136 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Beast, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(69, LocalStringManager.GetConfig("Material_language", "Name_69"), 5, 500, 6, 63, "icon_Material_heixiong", LocalStringManager.GetConfig("Material_language", "Desc_69"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_69"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 4600, 3, 7, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 14, 280, 320, new List<short> { 137 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Beast, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(70, LocalStringManager.GetConfig("Material_language", "Name_70"), 5, 500, 0, 70, "icon_Material_xiaomai", LocalStringManager.GetConfig("Material_language", "Desc_70"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_70"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 50, 0, 1, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 25, 14, 10, 5, new List<short> { 138 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Vegetarian, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(71, LocalStringManager.GetConfig("Material_language", "Name_71"), 5, 500, 1, 70, "icon_Material_dadou", LocalStringManager.GetConfig("Material_language", "Desc_71"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_71"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 100, 0, 2, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 50, 14, 30, 10, new List<short> { 139 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Vegetarian, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(72, LocalStringManager.GetConfig("Material_language", "Name_72"), 5, 500, 2, 70, "icon_Material_xianggu", LocalStringManager.GetConfig("Material_language", "Desc_72"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_72"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 300, 0, 3, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 100, 14, 60, 20, new List<short> { 140 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Vegetarian, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(73, LocalStringManager.GetConfig("Material_language", "Name_73"), 5, 500, 3, 70, "icon_Material_yulusun", LocalStringManager.GetConfig("Material_language", "Desc_73"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_73"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 750, 0, 4, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 200, 14, 100, 40, new List<short> { 141 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Vegetarian, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(74, LocalStringManager.GetConfig("Material_language", "Name_74"), 5, 500, 4, 70, "icon_Material_gonglian", LocalStringManager.GetConfig("Material_language", "Desc_74"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_74"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 1550, 1, 5, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 14, 150, 80, new List<short> { 142 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Vegetarian, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(75, LocalStringManager.GetConfig("Material_language", "Name_75"), 5, 500, 5, 70, "icon_Material_yinxingzi", LocalStringManager.GetConfig("Material_language", "Desc_75"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_75"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 14, 210, 160, new List<short> { 143 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Vegetarian, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(76, LocalStringManager.GetConfig("Material_language", "Name_76"), 5, 500, 6, 70, "icon_Material_houtougu", LocalStringManager.GetConfig("Material_language", "Desc_76"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_76"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 4600, 3, 7, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 14, 280, 320, new List<short> { 144 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Vegetarian, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(77, LocalStringManager.GetConfig("Material_language", "Name_77"), 5, 500, 0, 77, "icon_Material_caoyu", LocalStringManager.GetConfig("Material_language", "Desc_77"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_77"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 50, 0, 1, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 25, 14, 10, 5, new List<short> { 145 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Fish, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(78, LocalStringManager.GetConfig("Material_language", "Name_78"), 5, 500, 1, 77, "icon_Material_qingxia", LocalStringManager.GetConfig("Material_language", "Desc_78"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_78"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 100, 0, 2, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 50, 14, 30, 10, new List<short> { 146 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Fish, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(79, LocalStringManager.GetConfig("Material_language", "Name_79"), 5, 500, 2, 77, "icon_Material_yanli", LocalStringManager.GetConfig("Material_language", "Desc_79"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_79"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 50, 300, 0, 3, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 100, 14, 60, 20, new List<short> { 147 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Fish, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(80, LocalStringManager.GetConfig("Material_language", "Name_80"), 5, 500, 3, 77, "icon_Material_chixie", LocalStringManager.GetConfig("Material_language", "Desc_80"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_80"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 750, 0, 4, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 200, 14, 100, 40, new List<short> { 148 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Fish, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(81, LocalStringManager.GetConfig("Material_language", "Name_81"), 5, 500, 4, 77, "icon_Material_sisailu", LocalStringManager.GetConfig("Material_language", "Desc_81"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_81"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 40, 1550, 1, 5, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 14, 150, 80, new List<short> { 149 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Fish, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(82, LocalStringManager.GetConfig("Material_language", "Name_82"), 5, 500, 5, 77, "icon_Material_liangtouwangbao", LocalStringManager.GetConfig("Material_language", "Desc_82"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_82"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 14, 210, 160, new List<short> { 150 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Fish, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(83, LocalStringManager.GetConfig("Material_language", "Name_83"), 5, 500, 6, 77, "icon_Material_xunhuangyu", LocalStringManager.GetConfig("Material_language", "Desc_83"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_83"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 40, 4600, 3, 7, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 12, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 14, 280, 320, new List<short> { 151 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Fish, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(84, LocalStringManager.GetConfig("Material_language", "Name_84"), 5, 501, 0, 84, "icon_Material_baiyumudiaohua", LocalStringManager.GetConfig("Material_language", "Desc_84"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_84"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 150, 0, 1, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 0, 0, 7, 30, 25, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(85, LocalStringManager.GetConfig("Material_language", "Name_85"), 5, 501, 1, 84, "icon_Material_tielimudiaohua", LocalStringManager.GetConfig("Material_language", "Desc_85"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_85"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 300, 0, 2, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 0, 0, 7, 60, 50, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(86, LocalStringManager.GetConfig("Material_language", "Name_86"), 5, 501, 2, 84, "icon_Material_qifengwutongdiaohua", LocalStringManager.GetConfig("Material_language", "Desc_86"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_86"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 900, 0, 3, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 0, 0, 7, 100, 100, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(87, LocalStringManager.GetConfig("Material_language", "Name_87"), 5, 501, 3, 84, "icon_Material_baotaxuejudiaohua", LocalStringManager.GetConfig("Material_language", "Desc_87"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_87"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 0, 0, 7, 150, 200, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(88, LocalStringManager.GetConfig("Material_language", "Name_88"), 5, 501, 4, 84, "icon_Material_tianxianghongmudiaohua", LocalStringManager.GetConfig("Material_language", "Desc_88"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_88"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 0, 0, 7, 210, 400, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(89, LocalStringManager.GetConfig("Material_language", "Name_89"), 5, 501, 5, 84, "icon_Material_qianjiehuanghualidiaohua", LocalStringManager.GetConfig("Material_language", "Desc_89"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_89"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 0, 0, 7, 280, 800, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(90, LocalStringManager.GetConfig("Material_language", "Name_90"), 5, 501, 6, 84, "icon_Material_wujinzitandiaohua", LocalStringManager.GetConfig("Material_language", "Desc_90"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_90"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 0, 0, 7, 360, 1600, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Wooden));
		_dataArray.Add(new MaterialItem(91, LocalStringManager.GetConfig("Material_language", "Name_91"), 5, 501, 0, 91, "icon_Material_mengzongzhubianzhi", LocalStringManager.GetConfig("Material_language", "Desc_91"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_91"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 150, 0, 1, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 1, 0, 7, 30, 25, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(92, LocalStringManager.GetConfig("Material_language", "Name_92"), 5, 501, 1, 91, "icon_Material_dimaiwutengbianzhi", LocalStringManager.GetConfig("Material_language", "Desc_92"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_92"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 300, 0, 2, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 1, 0, 7, 60, 50, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(93, LocalStringManager.GetConfig("Material_language", "Name_93"), 5, 501, 2, 91, "icon_Material_qingputizhibianzhi", LocalStringManager.GetConfig("Material_language", "Desc_93"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_93"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 900, 0, 3, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 1, 0, 7, 100, 100, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(94, LocalStringManager.GetConfig("Material_language", "Name_94"), 5, 501, 3, 91, "icon_Material_longpangenbianzhi", LocalStringManager.GetConfig("Material_language", "Desc_94"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_94"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 1, 0, 7, 150, 200, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(95, LocalStringManager.GetConfig("Material_language", "Name_95"), 5, 501, 4, 91, "icon_Material_baiqianjiejiemubianzhi", LocalStringManager.GetConfig("Material_language", "Desc_95"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_95"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 1, 0, 7, 210, 400, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(96, LocalStringManager.GetConfig("Material_language", "Name_96"), 5, 501, 5, 91, "icon_Material_huotaomubianzhi", LocalStringManager.GetConfig("Material_language", "Desc_96"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_96"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 1, 0, 7, 280, 800, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(97, LocalStringManager.GetConfig("Material_language", "Name_97"), 5, 501, 6, 91, "icon_Material_jiuquzizhubianzhi", LocalStringManager.GetConfig("Material_language", "Desc_97"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_97"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 1, 36, EMaterialProperty.Invalid, -1, new List<int>(), 1, 0, 7, 360, 1600, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Rattan));
		_dataArray.Add(new MaterialItem(98, LocalStringManager.GetConfig("Material_language", "Name_98"), 5, 502, 0, 98, "icon_Material_bintietiehua", LocalStringManager.GetConfig("Material_language", "Desc_98"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_98"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 150, 0, 1, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 2, 0, 6, 30, 25, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(99, LocalStringManager.GetConfig("Material_language", "Name_99"), 5, 502, 1, 98, "icon_Material_yugangtiehua", LocalStringManager.GetConfig("Material_language", "Desc_99"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_99"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 40, 300, 0, 2, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 2, 0, 6, 60, 50, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(100, LocalStringManager.GetConfig("Material_language", "Name_100"), 5, 502, 2, 98, "icon_Material_baiyuejingtietiehua", LocalStringManager.GetConfig("Material_language", "Desc_100"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_100"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 50, 900, 0, 3, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 2, 0, 6, 100, 100, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(101, LocalStringManager.GetConfig("Material_language", "Name_101"), 5, 502, 3, 98, "icon_Material_wujintiehua", LocalStringManager.GetConfig("Material_language", "Desc_101"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_101"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 40, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 2, 0, 6, 150, 200, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(102, LocalStringManager.GetConfig("Material_language", "Name_102"), 5, 502, 4, 98, "icon_Material_tianwaihantietiehua", LocalStringManager.GetConfig("Material_language", "Desc_102"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_102"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 60, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 2, 0, 6, 210, 400, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(103, LocalStringManager.GetConfig("Material_language", "Name_103"), 5, 502, 5, 98, "icon_Material_wuseshentietiehua", LocalStringManager.GetConfig("Material_language", "Desc_103"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_103"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 70, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 2, 0, 6, 280, 800, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(104, LocalStringManager.GetConfig("Material_language", "Name_104"), 5, 502, 6, 98, "icon_Material_xuantietiehua", LocalStringManager.GetConfig("Material_language", "Desc_104"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_104"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 2, 0, 6, 360, 1600, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Icon));
		_dataArray.Add(new MaterialItem(105, LocalStringManager.GetConfig("Material_language", "Name_105"), 5, 502, 0, 105, "icon_Material_yuantonghuasi", LocalStringManager.GetConfig("Material_language", "Desc_105"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_105"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 150, 0, 1, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 3, 0, 6, 30, 25, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(106, LocalStringManager.GetConfig("Material_language", "Name_106"), 5, 502, 1, 105, "icon_Material_jingyinhuasi", LocalStringManager.GetConfig("Material_language", "Desc_106"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_106"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 300, 0, 2, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 3, 0, 6, 60, 50, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(107, LocalStringManager.GetConfig("Material_language", "Name_107"), 5, 502, 2, 105, "icon_Material_zijinhuasi", LocalStringManager.GetConfig("Material_language", "Desc_107"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_107"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 900, 0, 3, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 3, 0, 6, 100, 100, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(108, LocalStringManager.GetConfig("Material_language", "Name_108"), 5, 502, 3, 105, "icon_Material_ruyibaotonghuasi", LocalStringManager.GetConfig("Material_language", "Desc_108"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_108"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 3, 0, 6, 150, 200, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(109, LocalStringManager.GetConfig("Material_language", "Name_109"), 5, 502, 4, 105, "icon_Material_shizijinhuasi", LocalStringManager.GetConfig("Material_language", "Desc_109"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_109"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 40, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 3, 0, 6, 210, 400, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(110, LocalStringManager.GetConfig("Material_language", "Name_110"), 5, 502, 5, 105, "icon_Material_shiercaixiayinhuasi", LocalStringManager.GetConfig("Material_language", "Desc_110"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_110"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 3, 0, 6, 280, 800, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(111, LocalStringManager.GetConfig("Material_language", "Name_111"), 5, 502, 6, 105, "icon_Material_chankejingjinhuasi", LocalStringManager.GetConfig("Material_language", "Desc_111"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_111"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 2, 36, EMaterialProperty.Invalid, -1, new List<int>(), 3, 0, 6, 360, 1600, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.GoldSilver));
		_dataArray.Add(new MaterialItem(112, LocalStringManager.GetConfig("Material_language", "Name_112"), 5, 503, 0, 112, "icon_Material_heimanaoqianshi", LocalStringManager.GetConfig("Material_language", "Desc_112"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_112"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 150, 0, 1, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 4, 0, 11, 30, 25, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(113, LocalStringManager.GetConfig("Material_language", "Name_113"), 5, 503, 1, 112, "icon_Material_hongbaoshiqianshi", LocalStringManager.GetConfig("Material_language", "Desc_113"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_113"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 300, 0, 2, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 4, 0, 11, 60, 50, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(114, LocalStringManager.GetConfig("Material_language", "Name_114"), 5, 503, 2, 112, "icon_Material_qingjinshiqianshi", LocalStringManager.GetConfig("Material_language", "Desc_114"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_114"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 900, 0, 3, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 4, 0, 11, 100, 100, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(115, LocalStringManager.GetConfig("Material_language", "Name_115"), 5, 503, 3, 112, "icon_Material_guiwenmaoyanqianshi", LocalStringManager.GetConfig("Material_language", "Desc_115"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_115"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 4, 0, 11, 150, 200, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(116, LocalStringManager.GetConfig("Material_language", "Name_116"), 5, 503, 4, 112, "icon_Material_bixiejingangshiqianshi", LocalStringManager.GetConfig("Material_language", "Desc_116"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_116"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 4, 0, 11, 210, 400, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(117, LocalStringManager.GetConfig("Material_language", "Name_117"), 5, 503, 5, 112, "icon_Material_qingxiaoshenshiqianshi", LocalStringManager.GetConfig("Material_language", "Desc_117"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_117"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 4, 0, 11, 280, 800, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(118, LocalStringManager.GetConfig("Material_language", "Name_118"), 5, 503, 6, 112, "icon_Material_shenzhaoshiqianshi", LocalStringManager.GetConfig("Material_language", "Desc_118"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_118"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 4, 0, 11, 360, 1600, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Stone));
		_dataArray.Add(new MaterialItem(119, LocalStringManager.GetConfig("Material_language", "Name_119"), 5, 503, 0, 119, "icon_Material_shuiyuzhuizhu", LocalStringManager.GetConfig("Material_language", "Desc_119"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_119"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 150, 0, 1, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 5, 0, 11, 30, 25, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new MaterialItem(120, LocalStringManager.GetConfig("Material_language", "Name_120"), 5, 503, 1, 119, "icon_Material_feicuizhuizhu", LocalStringManager.GetConfig("Material_language", "Desc_120"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_120"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 300, 0, 2, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 5, 0, 11, 60, 50, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(121, LocalStringManager.GetConfig("Material_language", "Name_121"), 5, 503, 2, 119, "icon_Material_yangzhibaiyuzhuizhu", LocalStringManager.GetConfig("Material_language", "Desc_121"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_121"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 900, 0, 3, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 5, 0, 11, 100, 100, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(122, LocalStringManager.GetConfig("Material_language", "Name_122"), 5, 503, 3, 119, "icon_Material_wuseliulizhuizhu", LocalStringManager.GetConfig("Material_language", "Desc_122"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_122"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 5, 0, 11, 150, 200, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(123, LocalStringManager.GetConfig("Material_language", "Name_123"), 5, 503, 4, 119, "icon_Material_longxuemoyuzhuizhu", LocalStringManager.GetConfig("Material_language", "Desc_123"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_123"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 5, 0, 11, 210, 400, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(124, LocalStringManager.GetConfig("Material_language", "Name_124"), 5, 503, 5, 119, "icon_Material_hanyuzhuizhu", LocalStringManager.GetConfig("Material_language", "Desc_124"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_124"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 5, 0, 11, 280, 800, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(125, LocalStringManager.GetConfig("Material_language", "Name_125"), 5, 503, 6, 119, "icon_Material_kunlunhuoyuzhuizhu", LocalStringManager.GetConfig("Material_language", "Desc_125"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_125"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 3, 36, EMaterialProperty.Invalid, -1, new List<int>(), 5, 0, 11, 360, 1600, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Jade));
		_dataArray.Add(new MaterialItem(126, LocalStringManager.GetConfig("Material_language", "Name_126"), 5, 504, 0, 126, "icon_Material_huyibu", LocalStringManager.GetConfig("Material_language", "Desc_126"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_126"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 150, 0, 1, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 6, 0, 10, 30, 25, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(127, LocalStringManager.GetConfig("Material_language", "Name_127"), 5, 504, 1, 126, "icon_Material_zidiaoyibu", LocalStringManager.GetConfig("Material_language", "Desc_127"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_127"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 300, 0, 2, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 6, 0, 10, 60, 50, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(128, LocalStringManager.GetConfig("Material_language", "Name_128"), 5, 504, 2, 126, "icon_Material_baimanglinbu", LocalStringManager.GetConfig("Material_language", "Desc_128"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_128"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 900, 0, 3, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 6, 0, 10, 100, 100, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(129, LocalStringManager.GetConfig("Material_language", "Name_129"), 5, 504, 3, 126, "icon_Material_huxianyibu", LocalStringManager.GetConfig("Material_language", "Desc_129"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_129"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 6, 0, 10, 150, 200, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(130, LocalStringManager.GetConfig("Material_language", "Name_130"), 5, 504, 4, 126, "icon_Material_luanfengyubu", LocalStringManager.GetConfig("Material_language", "Desc_130"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_130"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 6, 0, 10, 210, 400, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(131, LocalStringManager.GetConfig("Material_language", "Name_131"), 5, 504, 5, 126, "icon_Material_longbeijinjinbu", LocalStringManager.GetConfig("Material_language", "Desc_131"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_131"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 6, 0, 10, 280, 800, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(132, LocalStringManager.GetConfig("Material_language", "Name_132"), 5, 504, 6, 126, "icon_Material_jinluchanyibu", LocalStringManager.GetConfig("Material_language", "Desc_132"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_132"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 6, 0, 10, 360, 1600, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Fur));
		_dataArray.Add(new MaterialItem(133, LocalStringManager.GetConfig("Material_language", "Name_133"), 5, 504, 0, 133, "icon_Material_xiuwenhuangmabu", LocalStringManager.GetConfig("Material_language", "Desc_133"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_133"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 150, 0, 1, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 7, 0, 10, 30, 25, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(134, LocalStringManager.GetConfig("Material_language", "Name_134"), 5, 504, 1, 133, "icon_Material_jinmiansibu", LocalStringManager.GetConfig("Material_language", "Desc_134"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_134"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 300, 0, 2, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 7, 0, 10, 60, 50, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(135, LocalStringManager.GetConfig("Material_language", "Name_135"), 5, 504, 2, 133, "icon_Material_baihuabaicaosibu", LocalStringManager.GetConfig("Material_language", "Desc_135"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_135"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 900, 0, 3, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 7, 0, 10, 100, 100, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(136, LocalStringManager.GetConfig("Material_language", "Name_136"), 5, 504, 3, 133, "icon_Material_xuanjinruansibu", LocalStringManager.GetConfig("Material_language", "Desc_136"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_136"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 7, 0, 10, 150, 200, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(137, LocalStringManager.GetConfig("Material_language", "Name_137"), 5, 504, 4, 133, "icon_Material_bingcanyinsibu", LocalStringManager.GetConfig("Material_language", "Desc_137"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_137"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 7, 0, 10, 210, 400, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(138, LocalStringManager.GetConfig("Material_language", "Name_138"), 5, 504, 5, 133, "icon_Material_xuelusibu", LocalStringManager.GetConfig("Material_language", "Desc_138"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_138"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 7, 0, 10, 280, 800, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(139, LocalStringManager.GetConfig("Material_language", "Name_139"), 5, 504, 6, 133, "icon_Material_tiancansibu", LocalStringManager.GetConfig("Material_language", "Desc_139"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_139"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 4, 36, EMaterialProperty.Invalid, -1, new List<int>(), 7, 0, 10, 360, 1600, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Woven));
		_dataArray.Add(new MaterialItem(140, LocalStringManager.GetConfig("Material_language", "Name_140"), 5, 505, 1, 140, "icon_Material_jiegucao", LocalStringManager.GetConfig("Material_language", "Desc_140"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_140"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 158, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(141, LocalStringManager.GetConfig("Material_language", "Name_141"), 5, 505, 3, 140, "icon_Material_fudiyanhusuo", LocalStringManager.GetConfig("Material_language", "Desc_141"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_141"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 158, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(142, LocalStringManager.GetConfig("Material_language", "Name_142"), 5, 505, 5, 140, "icon_Material_shenmuxuejie", LocalStringManager.GetConfig("Material_language", "Desc_142"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_142"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 158, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(143, LocalStringManager.GetConfig("Material_language", "Name_143"), 5, 505, 7, 140, "icon_Material_qiannianhuolingzhi", LocalStringManager.GetConfig("Material_language", "Desc_143"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_143"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 158, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 6, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(144, LocalStringManager.GetConfig("Material_language", "Name_144"), 5, 505, 1, 144, "icon_Material_zizhucao", LocalStringManager.GetConfig("Material_language", "Desc_144"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_144"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 159, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(145, LocalStringManager.GetConfig("Material_language", "Name_145"), 5, 505, 3, 144, "icon_Material_xueshanjiuniucao", LocalStringManager.GetConfig("Material_language", "Desc_145"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_145"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 159, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(146, LocalStringManager.GetConfig("Material_language", "Name_146"), 5, 505, 5, 144, "icon_Material_baixiniujiao", LocalStringManager.GetConfig("Material_language", "Desc_146"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_146"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 159, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(147, LocalStringManager.GetConfig("Material_language", "Name_147"), 5, 505, 7, 144, "icon_Material_yufolu", LocalStringManager.GetConfig("Material_language", "Desc_147"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_147"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 159, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 4, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(148, LocalStringManager.GetConfig("Material_language", "Name_148"), 5, 505, 1, 148, "icon_Material_qiannianjian", LocalStringManager.GetConfig("Material_language", "Desc_148"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_148"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 160, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(149, LocalStringManager.GetConfig("Material_language", "Name_149"), 5, 505, 3, 148, "icon_Material_zihuasheshecao", LocalStringManager.GetConfig("Material_language", "Desc_149"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_149"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 160, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(150, LocalStringManager.GetConfig("Material_language", "Name_150"), 5, 505, 5, 148, "icon_Material_lingguiban", LocalStringManager.GetConfig("Material_language", "Desc_150"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_150"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 160, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(151, LocalStringManager.GetConfig("Material_language", "Name_151"), 5, 505, 7, 148, "icon_Material_nuwashi", LocalStringManager.GetConfig("Material_language", "Desc_151"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_151"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 160, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(152, LocalStringManager.GetConfig("Material_language", "Name_152"), 5, 505, 1, 152, "icon_Material_hugu", LocalStringManager.GetConfig("Material_language", "Desc_152"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_152"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 161, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(153, LocalStringManager.GetConfig("Material_language", "Name_153"), 5, 505, 3, 152, "icon_Material_xiulongcao", LocalStringManager.GetConfig("Material_language", "Desc_153"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_153"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 161, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(154, LocalStringManager.GetConfig("Material_language", "Name_154"), 5, 505, 5, 152, "icon_Material_laoyuangu", LocalStringManager.GetConfig("Material_language", "Desc_154"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_154"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 161, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(155, LocalStringManager.GetConfig("Material_language", "Name_155"), 5, 505, 7, 152, "icon_Material_chifuxuegui", LocalStringManager.GetConfig("Material_language", "Desc_155"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_155"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 161, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(156, LocalStringManager.GetConfig("Material_language", "Name_156"), 5, 505, 1, 156, "icon_Material_renshen", LocalStringManager.GetConfig("Material_language", "Desc_156"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_156"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 162, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(157, LocalStringManager.GetConfig("Material_language", "Name_157"), 5, 505, 3, 156, "icon_Material_ziqingjiangxiang", LocalStringManager.GetConfig("Material_language", "Desc_157"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_157"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 162, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(158, LocalStringManager.GetConfig("Material_language", "Name_158"), 5, 505, 5, 156, "icon_Material_heiyuchenxiang", LocalStringManager.GetConfig("Material_language", "Desc_158"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_158"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 162, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(159, LocalStringManager.GetConfig("Material_language", "Name_159"), 5, 505, 7, 156, "icon_Material_qiannianxuecan", LocalStringManager.GetConfig("Material_language", "Desc_159"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_159"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 162, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 6, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 50, 0, 0, 0, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(160, LocalStringManager.GetConfig("Material_language", "Name_160"), 5, 505, 1, 160, "icon_Material_qingshedan", LocalStringManager.GetConfig("Material_language", "Desc_160"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_160"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 163, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(161, LocalStringManager.GetConfig("Material_language", "Name_161"), 5, 505, 3, 160, "icon_Material_jinbanwuyao", LocalStringManager.GetConfig("Material_language", "Desc_161"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_161"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 163, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(162, LocalStringManager.GetConfig("Material_language", "Name_162"), 5, 505, 5, 160, "icon_Material_yuchansu", LocalStringManager.GetConfig("Material_language", "Desc_162"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_162"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 163, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(163, LocalStringManager.GetConfig("Material_language", "Name_163"), 5, 505, 7, 160, "icon_Material_ziyuwangcan", LocalStringManager.GetConfig("Material_language", "Desc_163"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_163"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 163, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 4, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(164, LocalStringManager.GetConfig("Material_language", "Name_164"), 5, 505, 1, 164, "icon_Material_suhexiang", LocalStringManager.GetConfig("Material_language", "Desc_164"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_164"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 164, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(165, LocalStringManager.GetConfig("Material_language", "Name_165"), 5, 505, 3, 164, "icon_Material_yewushi", LocalStringManager.GetConfig("Material_language", "Desc_165"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_165"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 164, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(166, LocalStringManager.GetConfig("Material_language", "Name_166"), 5, 505, 5, 164, "icon_Material_dengxintanxiang", LocalStringManager.GetConfig("Material_language", "Desc_166"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_166"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 164, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(167, LocalStringManager.GetConfig("Material_language", "Name_167"), 5, 505, 7, 164, "icon_Material_yaochilan", LocalStringManager.GetConfig("Material_language", "Desc_167"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_167"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 164, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(168, LocalStringManager.GetConfig("Material_language", "Name_168"), 5, 505, 1, 168, "icon_Material_suxinhua", LocalStringManager.GetConfig("Material_language", "Desc_168"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_168"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 165, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(169, LocalStringManager.GetConfig("Material_language", "Name_169"), 5, 505, 3, 168, "icon_Material_anhunxiang", LocalStringManager.GetConfig("Material_language", "Desc_169"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_169"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 165, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(170, LocalStringManager.GetConfig("Material_language", "Name_170"), 5, 505, 5, 168, "icon_Material_huanglongmuxiang", LocalStringManager.GetConfig("Material_language", "Desc_170"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_170"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 165, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(171, LocalStringManager.GetConfig("Material_language", "Name_171"), 5, 505, 7, 168, "icon_Material_tianxiangqiongyushi", LocalStringManager.GetConfig("Material_language", "Desc_171"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_171"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 165, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 100, 100, 0, 0, 0, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(172, LocalStringManager.GetConfig("Material_language", "Name_172"), 5, 505, 1, 172, "icon_Material_hongfengmi", LocalStringManager.GetConfig("Material_language", "Desc_172"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_172"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 166, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(173, LocalStringManager.GetConfig("Material_language", "Name_173"), 5, 505, 3, 172, "icon_Material_yuluxue", LocalStringManager.GetConfig("Material_language", "Desc_173"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_173"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 166, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(174, LocalStringManager.GetConfig("Material_language", "Name_174"), 5, 505, 5, 172, "icon_Material_baielingshedan", LocalStringManager.GetConfig("Material_language", "Desc_174"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_174"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 166, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(175, LocalStringManager.GetConfig("Material_language", "Name_175"), 5, 505, 7, 172, "icon_Material_tianshanxuelian", LocalStringManager.GetConfig("Material_language", "Desc_175"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_175"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 166, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 6, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(176, LocalStringManager.GetConfig("Material_language", "Name_176"), 5, 505, 1, 176, "icon_Material_wushegu", LocalStringManager.GetConfig("Material_language", "Desc_176"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_176"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 167, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(177, LocalStringManager.GetConfig("Material_language", "Name_177"), 5, 505, 3, 176, "icon_Material_hongluodingxiang", LocalStringManager.GetConfig("Material_language", "Desc_177"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_177"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 167, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(178, LocalStringManager.GetConfig("Material_language", "Name_178"), 5, 505, 5, 176, "icon_Material_bainianwutou", LocalStringManager.GetConfig("Material_language", "Desc_178"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_178"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 167, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(179, LocalStringManager.GetConfig("Material_language", "Name_179"), 5, 505, 7, 176, "icon_Material_longhexuelu", LocalStringManager.GetConfig("Material_language", "Desc_179"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_179"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 167, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 4, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new MaterialItem(180, LocalStringManager.GetConfig("Material_language", "Name_180"), 5, 505, 1, 180, "icon_Material_changshengbaihe", LocalStringManager.GetConfig("Material_language", "Desc_180"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_180"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 168, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(181, LocalStringManager.GetConfig("Material_language", "Name_181"), 5, 505, 3, 180, "icon_Material_qixianglingzhi", LocalStringManager.GetConfig("Material_language", "Desc_181"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_181"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 168, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(182, LocalStringManager.GetConfig("Material_language", "Name_182"), 5, 505, 5, 180, "icon_Material_jinchipengniaoxue", LocalStringManager.GetConfig("Material_language", "Desc_182"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_182"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 168, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(183, LocalStringManager.GetConfig("Material_language", "Name_183"), 5, 505, 7, 180, "icon_Material_jiuseyuputi", LocalStringManager.GetConfig("Material_language", "Desc_183"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_183"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 168, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(184, LocalStringManager.GetConfig("Material_language", "Name_184"), 5, 505, 1, 184, "icon_Material_mianhuangqi", LocalStringManager.GetConfig("Material_language", "Desc_184"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_184"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 169, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(185, LocalStringManager.GetConfig("Material_language", "Name_185"), 5, 505, 3, 184, "icon_Material_feicuizhi", LocalStringManager.GetConfig("Material_language", "Desc_185"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_185"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 169, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(186, LocalStringManager.GetConfig("Material_language", "Name_186"), 5, 505, 5, 184, "icon_Material_tianqingshuiyu", LocalStringManager.GetConfig("Material_language", "Desc_186"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_186"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 169, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(187, LocalStringManager.GetConfig("Material_language", "Name_187"), 5, 505, 7, 184, "icon_Material_longxianshiru", LocalStringManager.GetConfig("Material_language", "Desc_187"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_187"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 169, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 200, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(188, LocalStringManager.GetConfig("Material_language", "Name_188"), 5, 505, 1, 188, "icon_Material_xueha", LocalStringManager.GetConfig("Material_language", "Desc_188"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_188"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 170, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(189, LocalStringManager.GetConfig("Material_language", "Name_189"), 5, 505, 3, 188, "icon_Material_lingzhicao", LocalStringManager.GetConfig("Material_language", "Desc_189"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_189"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 170, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(190, LocalStringManager.GetConfig("Material_language", "Name_190"), 5, 505, 5, 188, "icon_Material_tiepishihu", LocalStringManager.GetConfig("Material_language", "Desc_190"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_190"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 170, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(191, LocalStringManager.GetConfig("Material_language", "Name_191"), 5, 505, 7, 188, "icon_Material_renxingheshouwu", LocalStringManager.GetConfig("Material_language", "Desc_191"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_191"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 170, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 6, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(192, LocalStringManager.GetConfig("Material_language", "Name_192"), 5, 505, 1, 192, "icon_Material_zhenzhumu", LocalStringManager.GetConfig("Material_language", "Desc_192"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_192"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 171, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(193, LocalStringManager.GetConfig("Material_language", "Name_193"), 5, 505, 3, 192, "icon_Material_zhuxinfushen", LocalStringManager.GetConfig("Material_language", "Desc_193"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_193"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 171, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(194, LocalStringManager.GetConfig("Material_language", "Name_194"), 5, 505, 5, 192, "icon_Material_longnaobingpian", LocalStringManager.GetConfig("Material_language", "Desc_194"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_194"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 171, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(195, LocalStringManager.GetConfig("Material_language", "Name_195"), 5, 505, 7, 192, "icon_Material_motianma", LocalStringManager.GetConfig("Material_language", "Desc_195"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_195"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 171, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 4, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(196, LocalStringManager.GetConfig("Material_language", "Name_196"), 5, 505, 1, 196, "icon_Material_mantianxiang", LocalStringManager.GetConfig("Material_language", "Desc_196"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_196"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 172, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(197, LocalStringManager.GetConfig("Material_language", "Name_197"), 5, 505, 3, 196, "icon_Material_xinghunhua", LocalStringManager.GetConfig("Material_language", "Desc_197"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_197"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 172, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(198, LocalStringManager.GetConfig("Material_language", "Name_198"), 5, 505, 5, 196, "icon_Material_canglonggu", LocalStringManager.GetConfig("Material_language", "Desc_198"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_198"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 172, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(199, LocalStringManager.GetConfig("Material_language", "Name_199"), 5, 505, 7, 196, "icon_Material_linglongshanhu", LocalStringManager.GetConfig("Material_language", "Desc_199"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_199"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 172, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(200, LocalStringManager.GetConfig("Material_language", "Name_200"), 5, 505, 1, 200, "icon_Material_yexianjiang", LocalStringManager.GetConfig("Material_language", "Desc_200"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_200"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 173, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(201, LocalStringManager.GetConfig("Material_language", "Name_201"), 5, 505, 3, 200, "icon_Material_lurong", LocalStringManager.GetConfig("Material_language", "Desc_201"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_201"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 173, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(202, LocalStringManager.GetConfig("Material_language", "Name_202"), 5, 505, 5, 200, "icon_Material_xueyanwo", LocalStringManager.GetConfig("Material_language", "Desc_202"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_202"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 173, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(203, LocalStringManager.GetConfig("Material_language", "Name_203"), 5, 505, 7, 200, "icon_Material_hupodoukou", LocalStringManager.GetConfig("Material_language", "Desc_203"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_203"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 173, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 100, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(204, LocalStringManager.GetConfig("Material_language", "Name_204"), 5, 505, 1, 204, "icon_Material_zhuguo", LocalStringManager.GetConfig("Material_language", "Desc_204"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_204"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 174, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(205, LocalStringManager.GetConfig("Material_language", "Name_205"), 5, 505, 3, 204, "icon_Material_youtaicao", LocalStringManager.GetConfig("Material_language", "Desc_205"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_205"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 174, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(206, LocalStringManager.GetConfig("Material_language", "Name_206"), 5, 505, 5, 204, "icon_Material_yuluqiongjiang", LocalStringManager.GetConfig("Material_language", "Desc_206"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_206"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 174, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(207, LocalStringManager.GetConfig("Material_language", "Name_207"), 5, 505, 7, 204, "icon_Material_tuminghua", LocalStringManager.GetConfig("Material_language", "Desc_207"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_207"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 174, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(208, LocalStringManager.GetConfig("Material_language", "Name_208"), 5, 505, 1, 208, "icon_Material_qiandan", LocalStringManager.GetConfig("Material_language", "Desc_208"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_208"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 175, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(209, LocalStringManager.GetConfig("Material_language", "Name_209"), 5, 505, 3, 208, "icon_Material_baichongguijian", LocalStringManager.GetConfig("Material_language", "Desc_209"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_209"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 175, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(210, LocalStringManager.GetConfig("Material_language", "Name_210"), 5, 505, 5, 208, "icon_Material_yanwangguijiu", LocalStringManager.GetConfig("Material_language", "Desc_210"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_210"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 175, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(211, LocalStringManager.GetConfig("Material_language", "Name_211"), 5, 505, 7, 208, "icon_Material_wubeiyinchan", LocalStringManager.GetConfig("Material_language", "Desc_211"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_211"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 175, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(212, LocalStringManager.GetConfig("Material_language", "Name_212"), 5, 505, 1, 212, "icon_Material_zuifurong", LocalStringManager.GetConfig("Material_language", "Desc_212"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_212"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 176, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(213, LocalStringManager.GetConfig("Material_language", "Name_213"), 5, 505, 3, 212, "icon_Material_tianzhufozuo", LocalStringManager.GetConfig("Material_language", "Desc_213"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_213"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 176, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(214, LocalStringManager.GetConfig("Material_language", "Name_214"), 5, 505, 5, 212, "icon_Material_qingluanxue", LocalStringManager.GetConfig("Material_language", "Desc_214"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_214"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 176, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(215, LocalStringManager.GetConfig("Material_language", "Name_215"), 5, 505, 7, 212, "icon_Material_jincan", LocalStringManager.GetConfig("Material_language", "Desc_215"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_215"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 176, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(216, LocalStringManager.GetConfig("Material_language", "Name_216"), 5, 505, 1, 216, "icon_Material_suiyincishi", LocalStringManager.GetConfig("Material_language", "Desc_216"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_216"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 177, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(217, LocalStringManager.GetConfig("Material_language", "Name_217"), 5, 505, 3, 216, "icon_Material_kongqingshi", LocalStringManager.GetConfig("Material_language", "Desc_217"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_217"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 177, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(218, LocalStringManager.GetConfig("Material_language", "Name_218"), 5, 505, 5, 216, "icon_Material_manaoqinglu", LocalStringManager.GetConfig("Material_language", "Desc_218"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_218"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 177, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(219, LocalStringManager.GetConfig("Material_language", "Name_219"), 5, 505, 7, 216, "icon_Material_chiyuhanchan", LocalStringManager.GetConfig("Material_language", "Desc_219"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_219"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 177, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 200, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(220, LocalStringManager.GetConfig("Material_language", "Name_220"), 5, 505, 1, 220, "icon_Material_jiujiechangpu", LocalStringManager.GetConfig("Material_language", "Desc_220"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_220"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 178, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(221, LocalStringManager.GetConfig("Material_language", "Name_221"), 5, 505, 3, 220, "icon_Material_yinxianchongcao", LocalStringManager.GetConfig("Material_language", "Desc_221"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_221"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 178, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(222, LocalStringManager.GetConfig("Material_language", "Name_222"), 5, 505, 5, 220, "icon_Material_xuexiongjindan", LocalStringManager.GetConfig("Material_language", "Desc_222"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_222"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 178, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(223, LocalStringManager.GetConfig("Material_language", "Name_223"), 5, 505, 7, 220, "icon_Material_shelizi", LocalStringManager.GetConfig("Material_language", "Desc_223"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_223"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 178, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 100, 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(224, LocalStringManager.GetConfig("Material_language", "Name_224"), 5, 505, 1, 224, "icon_Material_xihuang", LocalStringManager.GetConfig("Material_language", "Desc_224"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_224"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 179, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(225, LocalStringManager.GetConfig("Material_language", "Name_225"), 5, 505, 3, 224, "icon_Material_heixiongdan", LocalStringManager.GetConfig("Material_language", "Desc_225"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_225"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 179, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(226, LocalStringManager.GetConfig("Material_language", "Name_226"), 5, 505, 5, 224, "icon_Material_qinghualongkui", LocalStringManager.GetConfig("Material_language", "Desc_226"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_226"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 179, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(227, LocalStringManager.GetConfig("Material_language", "Name_227"), 5, 505, 7, 224, "icon_Material_tianshetui", LocalStringManager.GetConfig("Material_language", "Desc_227"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_227"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 179, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(228, LocalStringManager.GetConfig("Material_language", "Name_228"), 5, 505, 1, 228, "icon_Material_shexiang", LocalStringManager.GetConfig("Material_language", "Desc_228"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_228"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 180, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(229, LocalStringManager.GetConfig("Material_language", "Name_229"), 5, 505, 3, 228, "icon_Material_jinxiangfu", LocalStringManager.GetConfig("Material_language", "Desc_229"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_229"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 180, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(230, LocalStringManager.GetConfig("Material_language", "Name_230"), 5, 505, 5, 228, "icon_Material_huajiafuling", LocalStringManager.GetConfig("Material_language", "Desc_230"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_230"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 180, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(231, LocalStringManager.GetConfig("Material_language", "Name_231"), 5, 505, 7, 228, "icon_Material_jinmupantao", LocalStringManager.GetConfig("Material_language", "Desc_231"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_231"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 180, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 100, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(232, LocalStringManager.GetConfig("Material_language", "Name_232"), 5, 505, 1, 232, "icon_Material_jiguichong", LocalStringManager.GetConfig("Material_language", "Desc_232"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_232"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 100, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 8, 30, 5, new List<short> { 181, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(233, LocalStringManager.GetConfig("Material_language", "Name_233"), 5, 505, 3, 232, "icon_Material_wutongxueshe", LocalStringManager.GetConfig("Material_language", "Desc_233"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_233"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 8, 100, 20, new List<short> { 181, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(234, LocalStringManager.GetConfig("Material_language", "Name_234"), 5, 505, 5, 232, "icon_Material_jinpixiyi", LocalStringManager.GetConfig("Material_language", "Desc_234"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_234"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 8, 210, 80, new List<short> { 181, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(235, LocalStringManager.GetConfig("Material_language", "Name_235"), 5, 505, 7, 232, "icon_Material_bamangxuandan", LocalStringManager.GetConfig("Material_language", "Desc_235"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_235"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 30, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 8, 360, 320, new List<short> { 181, 2 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 2, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(236, LocalStringManager.GetConfig("Material_language", "Name_236"), 5, 506, 1, 236, "icon_Material_zhenyu", LocalStringManager.GetConfig("Material_language", "Desc_236"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_236"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 200, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 9, 30, 5, new List<short> { 152, 3 }, new PoisonsAndLevels(5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(237, LocalStringManager.GetConfig("Material_language", "Name_237"), 5, 506, 2, 236, "icon_Material_leigongteng", LocalStringManager.GetConfig("Material_language", "Desc_237"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_237"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 600, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 50, 9, 60, 10, new List<short> { 152, 3 }, new PoisonsAndLevels(10, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(238, LocalStringManager.GetConfig("Material_language", "Name_238"), 5, 506, 3, 236, "icon_Material_qianjicao", LocalStringManager.GetConfig("Material_language", "Desc_238"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_238"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 1500, 0, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 9, 100, 20, new List<short> { 152, 3 }, new PoisonsAndLevels(15, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(239, LocalStringManager.GetConfig("Material_language", "Name_239"), 5, 506, 4, 236, "icon_Material_wushaluohuncao", LocalStringManager.GetConfig("Material_language", "Desc_239"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_239"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 3100, 1, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 200, 9, 150, 40, new List<short> { 152, 3 }, new PoisonsAndLevels(15, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new MaterialItem(240, LocalStringManager.GetConfig("Material_language", "Name_240"), 5, 506, 5, 236, "icon_Material_xinghuangzhu", LocalStringManager.GetConfig("Material_language", "Desc_240"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_240"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 5600, 2, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 9, 210, 80, new List<short> { 152, 3 }, new PoisonsAndLevels(20, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(241, LocalStringManager.GetConfig("Material_language", "Name_241"), 5, 506, 6, 236, "icon_Material_jinshe", LocalStringManager.GetConfig("Material_language", "Desc_241"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_241"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 9200, 3, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 400, 9, 280, 160, new List<short> { 152, 3 }, new PoisonsAndLevels(25, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(242, LocalStringManager.GetConfig("Material_language", "Name_242"), 5, 506, 7, 236, "icon_Material_duanchangcao", LocalStringManager.GetConfig("Material_language", "Desc_242"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_242"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 14100, 4, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 9, 360, 320, new List<short> { 152, 3 }, new PoisonsAndLevels(25, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(243, LocalStringManager.GetConfig("Material_language", "Name_243"), 5, 506, 1, 243, "icon_Material_caowutou", LocalStringManager.GetConfig("Material_language", "Desc_243"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_243"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 200, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 9, 30, 5, new List<short> { 153, 3 }, new PoisonsAndLevels(0, 0, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(244, LocalStringManager.GetConfig("Material_language", "Name_244"), 5, 506, 2, 243, "icon_Material_xiangsizi", LocalStringManager.GetConfig("Material_language", "Desc_244"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_244"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 600, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 50, 9, 60, 10, new List<short> { 153, 3 }, new PoisonsAndLevels(0, 0, 10, 1, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(245, LocalStringManager.GetConfig("Material_language", "Name_245"), 5, 506, 3, 243, "icon_Material_ziwufeng", LocalStringManager.GetConfig("Material_language", "Desc_245"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_245"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 1500, 0, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 9, 100, 20, new List<short> { 153, 3 }, new PoisonsAndLevels(0, 0, 15, 1, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(246, LocalStringManager.GetConfig("Material_language", "Name_246"), 5, 506, 4, 243, "icon_Material_guimudujuan", LocalStringManager.GetConfig("Material_language", "Desc_246"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_246"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 3100, 1, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 200, 9, 150, 40, new List<short> { 153, 3 }, new PoisonsAndLevels(0, 0, 15, 2, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(247, LocalStringManager.GetConfig("Material_language", "Name_247"), 5, 506, 5, 243, "icon_Material_baiyanwugong", LocalStringManager.GetConfig("Material_language", "Desc_247"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_247"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 5600, 2, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 9, 210, 80, new List<short> { 153, 3 }, new PoisonsAndLevels(0, 0, 20, 2, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(248, LocalStringManager.GetConfig("Material_language", "Name_248"), 5, 506, 6, 243, "icon_Material_qicaiyushaniang", LocalStringManager.GetConfig("Material_language", "Desc_248"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_248"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 9200, 3, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 400, 9, 280, 160, new List<short> { 153, 3 }, new PoisonsAndLevels(0, 0, 25, 2, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(249, LocalStringManager.GetConfig("Material_language", "Name_249"), 5, 506, 7, 243, "icon_Material_xieqiaohua", LocalStringManager.GetConfig("Material_language", "Desc_249"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_249"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 14100, 4, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 9, 360, 320, new List<short> { 153, 3 }, new PoisonsAndLevels(0, 0, 25, 3, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(250, LocalStringManager.GetConfig("Material_language", "Name_250"), 5, 506, 1, 250, "icon_Material_lieshuangcao", LocalStringManager.GetConfig("Material_language", "Desc_250"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_250"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 200, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 9, 30, 5, new List<short> { 154, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 5, 1, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(251, LocalStringManager.GetConfig("Material_language", "Name_251"), 5, 506, 2, 250, "icon_Material_baishedan", LocalStringManager.GetConfig("Material_language", "Desc_251"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_251"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 600, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 50, 9, 60, 10, new List<short> { 154, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 10, 1, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(252, LocalStringManager.GetConfig("Material_language", "Name_252"), 5, 506, 3, 250, "icon_Material_xuanyinshi", LocalStringManager.GetConfig("Material_language", "Desc_252"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_252"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 1500, 0, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 9, 100, 20, new List<short> { 154, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 15, 1, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(253, LocalStringManager.GetConfig("Material_language", "Name_253"), 5, 506, 4, 250, "icon_Material_hanyuchanchu", LocalStringManager.GetConfig("Material_language", "Desc_253"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_253"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 3100, 1, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 200, 9, 150, 40, new List<short> { 154, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 15, 2, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(254, LocalStringManager.GetConfig("Material_language", "Name_254"), 5, 506, 5, 250, "icon_Material_xuanbingpipaxie", LocalStringManager.GetConfig("Material_language", "Desc_254"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_254"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 5600, 2, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 9, 210, 80, new List<short> { 154, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 20, 2, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(255, LocalStringManager.GetConfig("Material_language", "Name_255"), 5, 506, 6, 250, "icon_Material_qingjiaodan", LocalStringManager.GetConfig("Material_language", "Desc_255"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_255"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 9200, 3, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 400, 9, 280, 160, new List<short> { 154, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 25, 2, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(256, LocalStringManager.GetConfig("Material_language", "Name_256"), 5, 506, 7, 250, "icon_Material_qiannianbingcan", LocalStringManager.GetConfig("Material_language", "Desc_256"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_256"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 14100, 4, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 9, 360, 320, new List<short> { 154, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 25, 3, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(257, LocalStringManager.GetConfig("Material_language", "Name_257"), 5, 506, 1, 257, "icon_Material_hongxinshi", LocalStringManager.GetConfig("Material_language", "Desc_257"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_257"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 200, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 9, 30, 5, new List<short> { 155, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 5, 1, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(258, LocalStringManager.GetConfig("Material_language", "Name_258"), 5, 506, 2, 257, "icon_Material_jianxuefenghou", LocalStringManager.GetConfig("Material_language", "Desc_258"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_258"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 600, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 50, 9, 60, 10, new List<short> { 155, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 10, 1, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(259, LocalStringManager.GetConfig("Material_language", "Name_259"), 5, 506, 3, 257, "icon_Material_yipinhong", LocalStringManager.GetConfig("Material_language", "Desc_259"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_259"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 1500, 0, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 9, 100, 20, new List<short> { 155, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 15, 1, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(260, LocalStringManager.GetConfig("Material_language", "Name_260"), 5, 506, 4, 257, "icon_Material_chixuebanxie", LocalStringManager.GetConfig("Material_language", "Desc_260"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_260"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 3100, 1, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 200, 9, 150, 40, new List<short> { 155, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 15, 2, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(261, LocalStringManager.GetConfig("Material_language", "Name_261"), 5, 506, 5, 257, "icon_Material_kongquedan", LocalStringManager.GetConfig("Material_language", "Desc_261"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_261"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 5600, 2, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 9, 210, 80, new List<short> { 155, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 20, 2, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(262, LocalStringManager.GetConfig("Material_language", "Name_262"), 5, 506, 6, 257, "icon_Material_fenghuangmu", LocalStringManager.GetConfig("Material_language", "Desc_262"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_262"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 9200, 3, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 400, 9, 280, 160, new List<short> { 155, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 25, 2, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(263, LocalStringManager.GetConfig("Material_language", "Name_263"), 5, 506, 7, 257, "icon_Material_xuechan", LocalStringManager.GetConfig("Material_language", "Desc_263"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_263"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 14100, 4, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 9, 360, 320, new List<short> { 155, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 25, 3, 0, 0, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(264, LocalStringManager.GetConfig("Material_language", "Name_264"), 5, 506, 1, 264, "icon_Material_fushichong", LocalStringManager.GetConfig("Material_language", "Desc_264"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_264"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 200, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 25, 9, 30, 5, new List<short> { 156, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 5, 1, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(265, LocalStringManager.GetConfig("Material_language", "Name_265"), 5, 506, 2, 264, "icon_Material_fushexian", LocalStringManager.GetConfig("Material_language", "Desc_265"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_265"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 600, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 50, 9, 60, 10, new List<short> { 156, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 10, 1, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(266, LocalStringManager.GetConfig("Material_language", "Name_266"), 5, 506, 3, 264, "icon_Material_sanwencao", LocalStringManager.GetConfig("Material_language", "Desc_266"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_266"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 1500, 0, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 100, 9, 100, 20, new List<short> { 156, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 15, 1, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(267, LocalStringManager.GetConfig("Material_language", "Name_267"), 5, 506, 4, 264, "icon_Material_xuanshishui", LocalStringManager.GetConfig("Material_language", "Desc_267"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_267"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 3100, 1, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 200, 9, 150, 40, new List<short> { 156, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 15, 2, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(268, LocalStringManager.GetConfig("Material_language", "Name_268"), 5, 506, 5, 264, "icon_Material_lansuiguichong", LocalStringManager.GetConfig("Material_language", "Desc_268"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_268"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 5600, 2, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 300, 9, 210, 80, new List<short> { 156, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 20, 2, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(269, LocalStringManager.GetConfig("Material_language", "Name_269"), 5, 506, 6, 264, "icon_Material_heishuimingshegu", LocalStringManager.GetConfig("Material_language", "Desc_269"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_269"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 20, 9200, 3, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 400, 9, 280, 160, new List<short> { 156, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 25, 2, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(270, LocalStringManager.GetConfig("Material_language", "Name_270"), 5, 506, 7, 264, "icon_Material_qiannianqingzhu", LocalStringManager.GetConfig("Material_language", "Desc_270"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_270"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 14100, 4, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yang, -1, new List<int>(), -1, 500, 9, 360, 320, new List<short> { 156, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 25, 3, 0, 0), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(271, LocalStringManager.GetConfig("Material_language", "Name_271"), 5, 506, 1, 271, "icon_Material_jiazhutao", LocalStringManager.GetConfig("Material_language", "Desc_271"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_271"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 200, 0, 2, 600, 3, allowRandomCreate: true, 40, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 25, 9, 30, 5, new List<short> { 157, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 1), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(272, LocalStringManager.GetConfig("Material_language", "Name_272"), 5, 506, 2, 271, "icon_Material_bianhua", LocalStringManager.GetConfig("Material_language", "Desc_272"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_272"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 600, 0, 3, 1200, 4, allowRandomCreate: true, 35, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 50, 9, 60, 10, new List<short> { 157, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 1), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(273, LocalStringManager.GetConfig("Material_language", "Name_273"), 5, 506, 3, 271, "icon_Material_fuhunsi", LocalStringManager.GetConfig("Material_language", "Desc_273"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_273"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 1500, 0, 4, 1800, 5, allowRandomCreate: true, 30, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 100, 9, 100, 20, new List<short> { 157, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 15, 1), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(274, LocalStringManager.GetConfig("Material_language", "Name_274"), 5, 506, 4, 271, "icon_Material_jindaihua", LocalStringManager.GetConfig("Material_language", "Desc_274"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_274"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 3100, 1, 5, 3000, 6, allowRandomCreate: true, 25, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 200, 9, 150, 40, new List<short> { 157, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 15, 2), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(275, LocalStringManager.GetConfig("Material_language", "Name_275"), 5, 506, 5, 271, "icon_Material_yanyunzizhang", LocalStringManager.GetConfig("Material_language", "Desc_275"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_275"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 5600, 2, 6, 4200, 7, allowRandomCreate: true, 20, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 300, 9, 210, 80, new List<short> { 157, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20, 2), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(276, LocalStringManager.GetConfig("Material_language", "Name_276"), 5, 506, 6, 271, "icon_Material_wumeilan", LocalStringManager.GetConfig("Material_language", "Desc_276"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_276"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 9200, 3, 7, 5400, 7, allowRandomCreate: true, 15, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 400, 9, 280, 160, new List<short> { 157, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 25, 2), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(277, LocalStringManager.GetConfig("Material_language", "Name_277"), 5, 506, 7, 271, "icon_Material_renmianmantuoluo", LocalStringManager.GetConfig("Material_language", "Desc_277"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_277"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 14100, 4, 8, 7200, 8, allowRandomCreate: true, 10, isSpecial: false, 5, 12, EMaterialProperty.Yin, -1, new List<int>(), -1, 500, 9, 360, 320, new List<short> { 157, 3 }, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 25, 3), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Poison, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(278, LocalStringManager.GetConfig("Material_language", "Name_278"), 5, 506, 4, -1, "icon_Material_JiaoWhiteEgg", LocalStringManager.GetConfig("Material_language", "Desc_278"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_278"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 50, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 200, 9, 150, 0, new List<short>(), new PoisonsAndLevels(15, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 236, 50, 100),
			new PresetInventoryItem("Material", 237, 40, 100),
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(279, LocalStringManager.GetConfig("Material_language", "Name_279"), 5, 506, 4, -1, "icon_Material_JiaoBlackEgg", LocalStringManager.GetConfig("Material_language", "Desc_279"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_279"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 50, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 200, 9, 150, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 15, 2, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 243, 50, 100),
			new PresetInventoryItem("Material", 244, 40, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(280, LocalStringManager.GetConfig("Material_language", "Name_280"), 5, 506, 4, -1, "icon_Material_JiaoGreenEgg", LocalStringManager.GetConfig("Material_language", "Desc_280"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_280"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 50, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 200, 9, 150, 0, new List<short>(), new PoisonsAndLevels(0, 0, 15, 2, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 250, 50, 100),
			new PresetInventoryItem("Material", 251, 40, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(281, LocalStringManager.GetConfig("Material_language", "Name_281"), 5, 506, 4, -1, "icon_Material_JiaoRedEgg", LocalStringManager.GetConfig("Material_language", "Desc_281"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_281"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 50, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 200, 9, 150, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 15, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 257, 50, 100),
			new PresetInventoryItem("Material", 258, 40, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(282, LocalStringManager.GetConfig("Material_language", "Name_282"), 5, 506, 4, -1, "icon_Material_JiaoYellowEgg", LocalStringManager.GetConfig("Material_language", "Desc_282"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_282"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 50, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 200, 9, 150, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 15, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 264, 50, 100),
			new PresetInventoryItem("Material", 265, 40, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(283, LocalStringManager.GetConfig("Material_language", "Name_283"), 5, 506, 5, -1, "icon_Material_JiaoWBEgg", LocalStringManager.GetConfig("Material_language", "Desc_283"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_283"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 300, 9, 210, 0, new List<short>(), new PoisonsAndLevels(20, 2, 0, 0, 20, 2, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 237, 40, 100),
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 251, 40, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(284, LocalStringManager.GetConfig("Material_language", "Name_284"), 5, 506, 5, -1, "icon_Material_JiaoWGEgg", LocalStringManager.GetConfig("Material_language", "Desc_284"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_284"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 300, 9, 210, 0, new List<short>(), new PoisonsAndLevels(20, 2, 20, 2, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 237, 40, 100),
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 244, 40, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(285, LocalStringManager.GetConfig("Material_language", "Name_285"), 5, 506, 5, -1, "icon_Material_JiaoWREgg", LocalStringManager.GetConfig("Material_language", "Desc_285"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_285"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 300, 9, 210, 0, new List<short>(), new PoisonsAndLevels(20, 2, 0, 0, 0, 0, 20, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 237, 40, 100),
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 258, 40, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(286, LocalStringManager.GetConfig("Material_language", "Name_286"), 5, 506, 5, -1, "icon_Material_JiaoWYEgg", LocalStringManager.GetConfig("Material_language", "Desc_286"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_286"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 300, 9, 210, 0, new List<short>(), new PoisonsAndLevels(20, 2, 0, 0, 0, 0, 0, 0, 20, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 237, 40, 100),
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 265, 40, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(287, LocalStringManager.GetConfig("Material_language", "Name_287"), 5, 506, 5, -1, "icon_Material_JiaoBGEgg", LocalStringManager.GetConfig("Material_language", "Desc_287"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_287"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 300, 9, 210, 0, new List<short>(), new PoisonsAndLevels(0, 0, 20, 2, 20, 2, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 251, 40, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 244, 40, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(288, LocalStringManager.GetConfig("Material_language", "Name_288"), 5, 506, 5, -1, "icon_Material_JiaoBREgg", LocalStringManager.GetConfig("Material_language", "Desc_288"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_288"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 300, 9, 210, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 20, 2, 20, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 251, 40, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 258, 40, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(289, LocalStringManager.GetConfig("Material_language", "Name_289"), 5, 506, 5, -1, "icon_Material_JiaoBYEgg", LocalStringManager.GetConfig("Material_language", "Desc_289"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_289"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 300, 9, 210, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 20, 2, 0, 0, 20, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 251, 40, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 265, 40, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(290, LocalStringManager.GetConfig("Material_language", "Name_290"), 5, 506, 5, -1, "icon_Material_JiaoGREgg", LocalStringManager.GetConfig("Material_language", "Desc_290"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_290"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 300, 9, 210, 0, new List<short>(), new PoisonsAndLevels(0, 0, 20, 2, 0, 0, 20, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 244, 40, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 258, 40, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(291, LocalStringManager.GetConfig("Material_language", "Name_291"), 5, 506, 5, -1, "icon_Material_JiaoGYEgg", LocalStringManager.GetConfig("Material_language", "Desc_291"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_291"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 300, 9, 210, 0, new List<short>(), new PoisonsAndLevels(0, 0, 20, 2, 0, 0, 0, 0, 20, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 244, 40, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 265, 40, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(292, LocalStringManager.GetConfig("Material_language", "Name_292"), 5, 506, 5, -1, "icon_Material_JiaoRYEgg", LocalStringManager.GetConfig("Material_language", "Desc_292"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_292"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 300, 9, 210, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 20, 2, 20, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 258, 40, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 265, 40, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(293, LocalStringManager.GetConfig("Material_language", "Name_293"), 5, 506, 6, -1, "icon_Material_JiaoWBGEgg", LocalStringManager.GetConfig("Material_language", "Desc_293"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_293"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 280, 0, new List<short>(), new PoisonsAndLevels(25, 2, 25, 2, 25, 2, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(294, LocalStringManager.GetConfig("Material_language", "Name_294"), 5, 506, 6, -1, "icon_Material_JiaoWBREgg", LocalStringManager.GetConfig("Material_language", "Desc_294"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_294"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 280, 0, new List<short>(), new PoisonsAndLevels(25, 2, 0, 0, 25, 2, 25, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(295, LocalStringManager.GetConfig("Material_language", "Name_295"), 5, 506, 6, -1, "icon_Material_JiaoWBYEgg", LocalStringManager.GetConfig("Material_language", "Desc_295"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_295"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 280, 0, new List<short>(), new PoisonsAndLevels(25, 2, 0, 0, 25, 2, 0, 0, 25, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(296, LocalStringManager.GetConfig("Material_language", "Name_296"), 5, 506, 6, -1, "icon_Material_JiaoWGREgg", LocalStringManager.GetConfig("Material_language", "Desc_296"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_296"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 280, 0, new List<short>(), new PoisonsAndLevels(25, 2, 25, 2, 0, 0, 25, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(297, LocalStringManager.GetConfig("Material_language", "Name_297"), 5, 506, 6, -1, "icon_Material_JiaoWGYEgg", LocalStringManager.GetConfig("Material_language", "Desc_297"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_297"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 280, 0, new List<short>(), new PoisonsAndLevels(25, 2, 25, 2, 0, 0, 0, 0, 25, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(298, LocalStringManager.GetConfig("Material_language", "Name_298"), 5, 506, 6, -1, "icon_Material_JiaoWRYEgg", LocalStringManager.GetConfig("Material_language", "Desc_298"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_298"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 280, 0, new List<short>(), new PoisonsAndLevels(25, 2, 0, 0, 0, 0, 25, 2, 25, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(299, LocalStringManager.GetConfig("Material_language", "Name_299"), 5, 506, 6, -1, "icon_Material_JiaoBGREgg", LocalStringManager.GetConfig("Material_language", "Desc_299"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_299"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 280, 0, new List<short>(), new PoisonsAndLevels(0, 0, 25, 2, 25, 2, 25, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new MaterialItem(300, LocalStringManager.GetConfig("Material_language", "Name_300"), 5, 506, 6, -1, "icon_Material_JiaoBGYEgg", LocalStringManager.GetConfig("Material_language", "Desc_300"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_300"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 280, 0, new List<short>(), new PoisonsAndLevels(0, 0, 25, 2, 25, 2, 0, 0, 25, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(301, LocalStringManager.GetConfig("Material_language", "Name_301"), 5, 506, 6, -1, "icon_Material_JiaoBRYEgg", LocalStringManager.GetConfig("Material_language", "Desc_301"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_301"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 280, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 25, 2, 25, 2, 25, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(302, LocalStringManager.GetConfig("Material_language", "Name_302"), 5, 506, 6, -1, "icon_Material_JiaoGRYEgg", LocalStringManager.GetConfig("Material_language", "Desc_302"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_302"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 280, 0, new List<short>(), new PoisonsAndLevels(0, 0, 25, 2, 0, 0, 25, 2, 25, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(303, LocalStringManager.GetConfig("Material_language", "Name_303"), 5, 506, 7, -1, "icon_Material_JiaoWBGREgg", LocalStringManager.GetConfig("Material_language", "Desc_303"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_303"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 20, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 500, 9, 360, 0, new List<short>(), new PoisonsAndLevels(25, 3, 25, 3, 25, 3, 25, 3, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(304, LocalStringManager.GetConfig("Material_language", "Name_304"), 5, 506, 7, -1, "icon_Material_JiaoWBGYEgg", LocalStringManager.GetConfig("Material_language", "Desc_304"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_304"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 20, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 500, 9, 360, 0, new List<short>(), new PoisonsAndLevels(25, 3, 25, 3, 25, 3, 0, 0, 25, 3, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(305, LocalStringManager.GetConfig("Material_language", "Name_305"), 5, 506, 7, -1, "icon_Material_JiaoWBRYEgg", LocalStringManager.GetConfig("Material_language", "Desc_305"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_305"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 20, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 500, 9, 360, 0, new List<short>(), new PoisonsAndLevels(25, 3, 0, 0, 25, 3, 25, 3, 25, 3, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(306, LocalStringManager.GetConfig("Material_language", "Name_306"), 5, 506, 7, -1, "icon_Material_JiaoWGRYEgg", LocalStringManager.GetConfig("Material_language", "Desc_306"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_306"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 20, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 500, 9, 360, 0, new List<short>(), new PoisonsAndLevels(25, 3, 25, 3, 0, 0, 25, 3, 25, 3, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(307, LocalStringManager.GetConfig("Material_language", "Name_307"), 5, 506, 7, -1, "icon_Material_JiaoBGRYEgg", LocalStringManager.GetConfig("Material_language", "Desc_307"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_307"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 20, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 500, 9, 360, 0, new List<short>(), new PoisonsAndLevels(0, 0, 25, 3, 25, 3, 25, 3, 25, 3, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(308, LocalStringManager.GetConfig("Material_language", "Name_308"), 5, 506, 8, -1, "icon_Material_JiaoWGRYBEgg", LocalStringManager.GetConfig("Material_language", "Desc_308"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_308"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 100, 15, 0, 0, 50, 8, allowRandomCreate: false, 10, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 9, 450, 0, new List<short>(), new PoisonsAndLevels(25, 3, 25, 3, 25, 3, 25, 3, 25, 3, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 1, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.JiaoEgg, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(309, LocalStringManager.GetConfig("Material_language", "Name_309"), 5, 506, 4, -1, "icon_Material_baiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_309"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_309"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 50, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 150, 0, new List<short>(), new PoisonsAndLevels(30, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 236, 50, 100),
			new PresetInventoryItem("Material", 237, 40, 100),
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(310, LocalStringManager.GetConfig("Material_language", "Name_310"), 5, 506, 4, -1, "icon_Material_baiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_310"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_310"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 50, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 150, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 30, 2, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 243, 50, 100),
			new PresetInventoryItem("Material", 244, 40, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(311, LocalStringManager.GetConfig("Material_language", "Name_311"), 5, 506, 4, -1, "icon_Material_baiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_311"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_311"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 50, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 150, 0, new List<short>(), new PoisonsAndLevels(0, 0, 30, 2, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 250, 50, 100),
			new PresetInventoryItem("Material", 251, 40, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(312, LocalStringManager.GetConfig("Material_language", "Name_312"), 5, 506, 4, -1, "icon_Material_baiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_312"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_312"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 50, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 150, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 30, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 257, 50, 100),
			new PresetInventoryItem("Material", 258, 40, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(313, LocalStringManager.GetConfig("Material_language", "Name_313"), 5, 506, 4, -1, "icon_Material_baiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_313"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_313"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 50, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 400, 9, 150, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 30, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 264, 50, 100),
			new PresetInventoryItem("Material", 265, 40, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(314, LocalStringManager.GetConfig("Material_language", "Name_314"), 5, 506, 5, -1, "icon_Material_baiheiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_314"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_314"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 9, 210, 0, new List<short>(), new PoisonsAndLevels(40, 2, 0, 0, 40, 2, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 237, 40, 100),
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 251, 40, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(315, LocalStringManager.GetConfig("Material_language", "Name_315"), 5, 506, 5, -1, "icon_Material_baiheiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_315"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_315"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 9, 210, 0, new List<short>(), new PoisonsAndLevels(40, 2, 40, 2, 0, 0, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 237, 40, 100),
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 244, 40, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(316, LocalStringManager.GetConfig("Material_language", "Name_316"), 5, 506, 5, -1, "icon_Material_baiheiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_316"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_316"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 9, 210, 0, new List<short>(), new PoisonsAndLevels(40, 2, 0, 0, 0, 0, 40, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 237, 40, 100),
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 258, 40, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(317, LocalStringManager.GetConfig("Material_language", "Name_317"), 5, 506, 5, -1, "icon_Material_baiheiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_317"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_317"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 9, 210, 0, new List<short>(), new PoisonsAndLevels(40, 2, 0, 0, 0, 0, 0, 0, 40, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 237, 40, 100),
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 265, 40, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(318, LocalStringManager.GetConfig("Material_language", "Name_318"), 5, 506, 5, -1, "icon_Material_baiheiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_318"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_318"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 9, 210, 0, new List<short>(), new PoisonsAndLevels(0, 0, 40, 2, 40, 2, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 251, 40, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 244, 40, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(319, LocalStringManager.GetConfig("Material_language", "Name_319"), 5, 506, 5, -1, "icon_Material_baiheiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_319"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_319"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 9, 210, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 40, 2, 40, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 251, 40, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 258, 40, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(320, LocalStringManager.GetConfig("Material_language", "Name_320"), 5, 506, 5, -1, "icon_Material_baiheiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_320"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_320"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 9, 210, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 40, 2, 0, 0, 40, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 251, 40, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 265, 40, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(321, LocalStringManager.GetConfig("Material_language", "Name_321"), 5, 506, 5, -1, "icon_Material_baiheiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_321"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_321"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 9, 210, 0, new List<short>(), new PoisonsAndLevels(0, 0, 40, 2, 0, 0, 40, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 244, 40, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 258, 40, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(322, LocalStringManager.GetConfig("Material_language", "Name_322"), 5, 506, 5, -1, "icon_Material_baiheiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_322"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_322"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 9, 210, 0, new List<short>(), new PoisonsAndLevels(0, 0, 40, 2, 0, 0, 0, 0, 40, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 244, 40, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 265, 40, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(323, LocalStringManager.GetConfig("Material_language", "Name_323"), 5, 506, 5, -1, "icon_Material_baiheiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_323"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_323"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 40, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 600, 9, 210, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 40, 2, 40, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 258, 40, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 265, 40, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(324, LocalStringManager.GetConfig("Material_language", "Name_324"), 5, 506, 6, -1, "icon_Material_baiheiqingyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_324"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_324"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 9, 280, 0, new List<short>(), new PoisonsAndLevels(50, 2, 50, 2, 50, 2, 0, 0, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(325, LocalStringManager.GetConfig("Material_language", "Name_325"), 5, 506, 6, -1, "icon_Material_baiheiqingyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_325"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_325"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 9, 280, 0, new List<short>(), new PoisonsAndLevels(50, 2, 0, 0, 50, 2, 50, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(326, LocalStringManager.GetConfig("Material_language", "Name_326"), 5, 506, 6, -1, "icon_Material_baiheiqingyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_326"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_326"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 9, 280, 0, new List<short>(), new PoisonsAndLevels(50, 2, 0, 0, 50, 2, 0, 0, 50, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(327, LocalStringManager.GetConfig("Material_language", "Name_327"), 5, 506, 6, -1, "icon_Material_baiheiqingyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_327"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_327"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 9, 280, 0, new List<short>(), new PoisonsAndLevels(50, 2, 50, 2, 0, 0, 50, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(328, LocalStringManager.GetConfig("Material_language", "Name_328"), 5, 506, 6, -1, "icon_Material_baiheiqingyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_328"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_328"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 9, 280, 0, new List<short>(), new PoisonsAndLevels(50, 2, 50, 2, 0, 0, 0, 0, 50, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(329, LocalStringManager.GetConfig("Material_language", "Name_329"), 5, 506, 6, -1, "icon_Material_baiheiqingyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_329"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_329"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 9, 280, 0, new List<short>(), new PoisonsAndLevels(50, 2, 0, 0, 0, 0, 50, 2, 50, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 238, 30, 100),
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(330, LocalStringManager.GetConfig("Material_language", "Name_330"), 5, 506, 6, -1, "icon_Material_baiheiqingyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_330"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_330"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 9, 280, 0, new List<short>(), new PoisonsAndLevels(0, 0, 50, 2, 50, 2, 50, 2, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(331, LocalStringManager.GetConfig("Material_language", "Name_331"), 5, 506, 6, -1, "icon_Material_baiheiqingyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_331"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_331"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 9, 280, 0, new List<short>(), new PoisonsAndLevels(0, 0, 50, 2, 50, 2, 0, 0, 50, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(332, LocalStringManager.GetConfig("Material_language", "Name_332"), 5, 506, 6, -1, "icon_Material_baiheiqingyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_332"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_332"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 9, 280, 0, new List<short>(), new PoisonsAndLevels(0, 0, 0, 0, 50, 2, 50, 2, 50, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 252, 30, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(333, LocalStringManager.GetConfig("Material_language", "Name_333"), 5, 506, 6, -1, "icon_Material_baiheiqingyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_333"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_333"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 30, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 800, 9, 280, 0, new List<short>(), new PoisonsAndLevels(0, 0, 50, 2, 0, 0, 50, 2, 50, 2, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 245, 30, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 259, 30, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 266, 30, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(334, LocalStringManager.GetConfig("Material_language", "Name_334"), 5, 506, 7, -1, "icon_Material_baiheiqingchiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_334"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_334"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 20, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 1000, 9, 360, 0, new List<short>(), new PoisonsAndLevels(50, 3, 50, 3, 50, 3, 50, 3, 0, 0, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(335, LocalStringManager.GetConfig("Material_language", "Name_335"), 5, 506, 7, -1, "icon_Material_baiheiqingchiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_335"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_335"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 20, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 1000, 9, 360, 0, new List<short>(), new PoisonsAndLevels(50, 3, 50, 3, 50, 3, 0, 0, 50, 3, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(336, LocalStringManager.GetConfig("Material_language", "Name_336"), 5, 506, 7, -1, "icon_Material_baiheiqingchiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_336"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_336"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 20, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 1000, 9, 360, 0, new List<short>(), new PoisonsAndLevels(50, 3, 0, 0, 50, 3, 50, 3, 50, 3, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(337, LocalStringManager.GetConfig("Material_language", "Name_337"), 5, 506, 7, -1, "icon_Material_baiheiqingchiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_337"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_337"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 20, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 1000, 9, 360, 0, new List<short>(), new PoisonsAndLevels(50, 3, 50, 3, 0, 0, 50, 3, 50, 3, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 239, 20, 100),
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(338, LocalStringManager.GetConfig("Material_language", "Name_338"), 5, 506, 7, -1, "icon_Material_baiheiqingchiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_338"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_338"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 20, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 1000, 9, 360, 0, new List<short>(), new PoisonsAndLevels(0, 0, 50, 3, 50, 3, 50, 3, 50, 3, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 253, 20, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 246, 20, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 260, 20, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 267, 20, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(339, LocalStringManager.GetConfig("Material_language", "Name_339"), 5, 506, 8, -1, "icon_Material_baiqingchihuangheiyoujiao", LocalStringManager.GetConfig("Material_language", "Desc_339"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_339"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 10, isSpecial: true, 5, 36, EMaterialProperty.Invalid, -1, new List<int>(), -1, 1200, 9, 450, 0, new List<short>(), new PoisonsAndLevels(50, 3, 50, 3, 50, 3, 50, 3, 50, 3, 0, 0), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 240, 10, 100),
			new PresetInventoryItem("Material", 241, 5, 100),
			new PresetInventoryItem("Material", 242, 1, 100),
			new PresetInventoryItem("Material", 247, 10, 100),
			new PresetInventoryItem("Material", 248, 5, 100),
			new PresetInventoryItem("Material", 249, 1, 100),
			new PresetInventoryItem("Material", 254, 10, 100),
			new PresetInventoryItem("Material", 255, 5, 100),
			new PresetInventoryItem("Material", 256, 1, 100),
			new PresetInventoryItem("Material", 261, 10, 100),
			new PresetInventoryItem("Material", 262, 5, 100),
			new PresetInventoryItem("Material", 263, 1, 100),
			new PresetInventoryItem("Material", 268, 10, 100),
			new PresetInventoryItem("Material", 269, 5, 100),
			new PresetInventoryItem("Material", 270, 1, 100)
		}, 3, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Jiao, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(340, LocalStringManager.GetConfig("Material_language", "Name_340"), 5, 501, 0, -1, "icon_Material_qingzhupian", LocalStringManager.GetConfig("Material_language", "Desc_340"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_340"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, 1, -1, EMaterialProperty.Invalid, -1, new List<int>(), -1, 0, 7, 0, 10, new List<short> { 0 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(341, LocalStringManager.GetConfig("Material_language", "Name_341"), 5, 505, 8, -1, "icon_Material_dizhaoyufuhua", LocalStringManager.GetConfig("Material_language", "Desc_341"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_341"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, 5, -1, EMaterialProperty.Invalid, -1, new List<int>(), -1, 0, 8, 450, 30000, new List<short> { 1 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(342, LocalStringManager.GetConfig("Material_language", "Name_342"), 5, 504, 7, -1, "icon_Material_bainiaocaiyu", LocalStringManager.GetConfig("Material_language", "Desc_342"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_342"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, -1, 0, 15, 0, 0, 50, 8, allowRandomCreate: false, 0, isSpecial: true, 4, -1, EMaterialProperty.Invalid, -1, new List<int>(), -1, 0, 10, 30, 30, new List<short> { 182 }, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Invalid, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(343, LocalStringManager.GetConfig("Material_language", "Name_343"), 5, 504, 6, -1, "icon_Material_lengjingyuanjiyu", LocalStringManager.GetConfig("Material_language", "Desc_343"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_343"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 13800, 4, 7, 7200, 8, allowRandomCreate: false, 0, isSpecial: true, 4, -1, EMaterialProperty.Invalid, -1, new List<int>(), 8, 0, 10, 360, 0, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Feather, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(344, LocalStringManager.GetConfig("Material_language", "Name_344"), 5, 504, 6, -1, "icon_Material_congyingyuanjiyu", LocalStringManager.GetConfig("Material_language", "Desc_344"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_344"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 13800, 4, 7, 7200, 8, allowRandomCreate: false, 0, isSpecial: true, 4, -1, EMaterialProperty.Invalid, -1, new List<int>(), 12, 0, 10, 360, 0, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Feather, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(345, LocalStringManager.GetConfig("Material_language", "Name_345"), 5, 504, 6, -1, "icon_Material_reqingyuanjiyu", LocalStringManager.GetConfig("Material_language", "Desc_345"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_345"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 13800, 4, 7, 7200, 8, allowRandomCreate: false, 0, isSpecial: true, 4, -1, EMaterialProperty.Invalid, -1, new List<int>(), 11, 0, 10, 360, 0, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Feather, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(346, LocalStringManager.GetConfig("Material_language", "Name_346"), 5, 504, 6, -1, "icon_Material_yongzhuangyuanjiyu", LocalStringManager.GetConfig("Material_language", "Desc_346"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_346"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 13800, 4, 7, 7200, 8, allowRandomCreate: false, 0, isSpecial: true, 4, -1, EMaterialProperty.Invalid, -1, new List<int>(), 10, 0, 10, 360, 0, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Feather, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(347, LocalStringManager.GetConfig("Material_language", "Name_347"), 5, 504, 6, -1, "icon_Material_jianyiyuanjiyu", LocalStringManager.GetConfig("Material_language", "Desc_347"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_347"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 13800, 4, 7, 7200, 8, allowRandomCreate: false, 0, isSpecial: true, 4, -1, EMaterialProperty.Invalid, -1, new List<int>(), 9, 0, 10, 360, 0, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Feather, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(348, LocalStringManager.GetConfig("Material_language", "Name_348"), 5, 504, 6, -1, "icon_Material_fuyuanyuanjiyu", LocalStringManager.GetConfig("Material_language", "Desc_348"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_348"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 13800, 4, 7, 7200, 8, allowRandomCreate: false, 0, isSpecial: true, 4, -1, EMaterialProperty.Invalid, -1, new List<int>(), 13, 0, 10, 360, 0, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Feather, EMaterialFilterHardness.Invalid));
		_dataArray.Add(new MaterialItem(349, LocalStringManager.GetConfig("Material_language", "Name_349"), 5, 504, 6, -1, "icon_Material_hedaoyuanjiyu", LocalStringManager.GetConfig("Material_language", "Desc_349"), LocalStringManager.GetConfig("Material_language", "FunctionDesc_349"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 13800, 4, 7, 7200, 8, allowRandomCreate: false, 0, isSpecial: true, 4, -1, EMaterialProperty.Invalid, -1, new List<int>(), 14, 0, 10, 360, 0, new List<short>(), new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), new List<PresetInventoryItem>(), 0, 1, 0, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, primaryRecoverAllInjuries: false, EMedicineEffectType.Invalid, EMedicineEffectSubType.Invalid, 0, 0, 0, secondaryRecoverAllInjuries: false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 60, EMaterialFilterType.Feather, EMaterialFilterHardness.Invalid));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MaterialItem>(350);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
	}

	public static int GetCharacterPropertyBonus(int key, ECharacterPropertyReferencedType property)
	{
		return Instance[key]?.GetCharacterPropertyBonusInt(property) ?? 0;
	}

	public static int GetCharacterPropertyBonus(short[] keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Length; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}

	public static int GetCharacterPropertyBonus(List<short> keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Count; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}

	public static int GetCharacterPropertyBonus(int[] keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Length; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}

	public static int GetCharacterPropertyBonus(List<int> keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Count; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}
}
