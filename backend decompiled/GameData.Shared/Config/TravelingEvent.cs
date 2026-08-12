using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class TravelingEvent : ConfigData<TravelingEventItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// JingjiMaterial
		/// </summary>
		public const short JingjiMaterial = 0;

		/// <summary>
		/// BashuMaterial
		/// </summary>
		public const short BashuMaterial = 1;

		/// <summary>
		/// GuangnanMaterial
		/// </summary>
		public const short GuangnanMaterial = 2;

		/// <summary>
		/// JingBeiMaterial
		/// </summary>
		public const short JingBeiMaterial = 3;

		/// <summary>
		/// ShanxiMaterial
		/// </summary>
		public const short ShanxiMaterial = 4;

		/// <summary>
		/// GuangdongMaterial
		/// </summary>
		public const short GuangdongMaterial = 5;

		/// <summary>
		/// ShandongMaterial
		/// </summary>
		public const short ShandongMaterial = 6;

		/// <summary>
		/// JingnanMaterial
		/// </summary>
		public const short JingnanMaterial = 7;

		/// <summary>
		/// FujianMaterial
		/// </summary>
		public const short FujianMaterial = 8;

		/// <summary>
		/// LiaodongMaterial
		/// </summary>
		public const short LiaodongMaterial = 9;

		/// <summary>
		/// XiyuMaterial
		/// </summary>
		public const short XiyuMaterial = 10;

		/// <summary>
		/// YunnanMaterial
		/// </summary>
		public const short YunnanMaterial = 11;

		/// <summary>
		/// HuainanMaterial
		/// </summary>
		public const short HuainanMaterial = 12;

		/// <summary>
		/// JiangnanMaterial
		/// </summary>
		public const short JiangnanMaterial = 13;

		/// <summary>
		/// JiangbeiMaterial
		/// </summary>
		public const short JiangbeiMaterial = 14;

		/// <summary>
		/// JingjiResource
		/// </summary>
		public const short JingjiResource = 15;

		/// <summary>
		/// BashuResource
		/// </summary>
		public const short BashuResource = 16;

		/// <summary>
		/// GuangnanResource
		/// </summary>
		public const short GuangnanResource = 17;

		/// <summary>
		/// JingBeiResource
		/// </summary>
		public const short JingBeiResource = 18;

		/// <summary>
		/// ShanxiResource
		/// </summary>
		public const short ShanxiResource = 19;

		/// <summary>
		/// GuangdongResource
		/// </summary>
		public const short GuangdongResource = 20;

		/// <summary>
		/// ShandongResource
		/// </summary>
		public const short ShandongResource = 21;

		/// <summary>
		/// JingnanResource
		/// </summary>
		public const short JingnanResource = 22;

		/// <summary>
		/// FujianResource
		/// </summary>
		public const short FujianResource = 23;

		/// <summary>
		/// LiaodongResource
		/// </summary>
		public const short LiaodongResource = 24;

		/// <summary>
		/// XiyuResource
		/// </summary>
		public const short XiyuResource = 25;

		/// <summary>
		/// YunnanResource
		/// </summary>
		public const short YunnanResource = 26;

		/// <summary>
		/// HuainanResource
		/// </summary>
		public const short HuainanResource = 27;

		/// <summary>
		/// JiangnanResource
		/// </summary>
		public const short JiangnanResource = 28;

		/// <summary>
		/// JiangbeiResource
		/// </summary>
		public const short JiangbeiResource = 29;

		/// <summary>
		/// JingjiFood
		/// </summary>
		public const short JingjiFood = 30;

		/// <summary>
		/// BashuFood
		/// </summary>
		public const short BashuFood = 31;

		/// <summary>
		/// GuangnanFood
		/// </summary>
		public const short GuangnanFood = 32;

		/// <summary>
		/// JingBeiFood
		/// </summary>
		public const short JingBeiFood = 33;

		/// <summary>
		/// ShanxiFood
		/// </summary>
		public const short ShanxiFood = 34;

		/// <summary>
		/// GuangdongFood
		/// </summary>
		public const short GuangdongFood = 35;

		/// <summary>
		/// ShandongFood
		/// </summary>
		public const short ShandongFood = 36;

		/// <summary>
		/// JingnanFood
		/// </summary>
		public const short JingnanFood = 37;

		/// <summary>
		/// FujianFood
		/// </summary>
		public const short FujianFood = 38;

		/// <summary>
		/// LiaodongFood
		/// </summary>
		public const short LiaodongFood = 39;

		/// <summary>
		/// XiyuFood
		/// </summary>
		public const short XiyuFood = 40;

		/// <summary>
		/// YunnanFood
		/// </summary>
		public const short YunnanFood = 41;

		/// <summary>
		/// HuainanFood
		/// </summary>
		public const short HuainanFood = 42;

		/// <summary>
		/// JiangnanFood
		/// </summary>
		public const short JiangnanFood = 43;

		/// <summary>
		/// JiangbeiFood
		/// </summary>
		public const short JiangbeiFood = 44;

		/// <summary>
		/// HealOuterInjury
		/// </summary>
		public const short HealOuterInjury = 45;

		/// <summary>
		/// HealInnerInjury
		/// </summary>
		public const short HealInnerInjury = 46;

		/// <summary>
		/// HealPoison
		/// </summary>
		public const short HealPoison = 47;

		/// <summary>
		/// HealDisorderOfQi
		/// </summary>
		public const short HealDisorderOfQi = 48;

		/// <summary>
		/// HealLifeSpan
		/// </summary>
		public const short HealLifeSpan = 49;

		/// <summary>
		/// FriendResource
		/// </summary>
		public const short FriendResource = 50;

		/// <summary>
		/// FriendFood
		/// </summary>
		public const short FriendFood = 51;

		/// <summary>
		/// FriendTeaWine
		/// </summary>
		public const short FriendTeaWine = 52;

		/// <summary>
		/// FriendMedicine
		/// </summary>
		public const short FriendMedicine = 53;

		/// <summary>
		/// FameResource
		/// </summary>
		public const short FameResource = 54;

		/// <summary>
		/// FameFood
		/// </summary>
		public const short FameFood = 55;

		/// <summary>
		/// FameTeaWine
		/// </summary>
		public const short FameTeaWine = 56;

		/// <summary>
		/// FameMedicine
		/// </summary>
		public const short FameMedicine = 57;

		/// <summary>
		/// RecoverStrength
		/// </summary>
		public const short RecoverStrength = 58;

		/// <summary>
		/// RecoverDexterity
		/// </summary>
		public const short RecoverDexterity = 59;

		/// <summary>
		/// RecoverConcentration
		/// </summary>
		public const short RecoverConcentration = 60;

		/// <summary>
		/// RecoverVitality
		/// </summary>
		public const short RecoverVitality = 61;

		/// <summary>
		/// RecoverEnergy
		/// </summary>
		public const short RecoverEnergy = 62;

		/// <summary>
		/// RecoverIntelligence
		/// </summary>
		public const short RecoverIntelligence = 63;

		/// <summary>
		/// AreaInteractGood
		/// </summary>
		public const short AreaInteractGood = 64;

		/// <summary>
		/// AreaInteractNormal
		/// </summary>
		public const short AreaInteractNormal = 65;

		/// <summary>
		/// AreaInteractBad
		/// </summary>
		public const short AreaInteractBad = 66;

		/// <summary>
		/// AreaInteractIgnored
		/// </summary>
		public const short AreaInteractIgnored = 67;

		/// <summary>
		/// JingjiAreaSpiritualDebtSucceed
		/// </summary>
		public const short JingjiAreaSpiritualDebtSucceed = 68;

		/// <summary>
		/// BashuAreaSpiritualDebtSucceed
		/// </summary>
		public const short BashuAreaSpiritualDebtSucceed = 69;

		/// <summary>
		/// GuangnanAreaSpiritualDebtSucceed
		/// </summary>
		public const short GuangnanAreaSpiritualDebtSucceed = 70;

		/// <summary>
		/// JingBeiAreaSpiritualDebtSucceed
		/// </summary>
		public const short JingBeiAreaSpiritualDebtSucceed = 71;

		/// <summary>
		/// ShanxiAreaSpiritualDebtSucceed
		/// </summary>
		public const short ShanxiAreaSpiritualDebtSucceed = 72;

		/// <summary>
		/// GuangdongAreaSpiritualDebtSucceed
		/// </summary>
		public const short GuangdongAreaSpiritualDebtSucceed = 73;

		/// <summary>
		/// ShandongAreaSpiritualDebtSucceed
		/// </summary>
		public const short ShandongAreaSpiritualDebtSucceed = 74;

		/// <summary>
		/// JingnanAreaSpiritualDebtSucceed
		/// </summary>
		public const short JingnanAreaSpiritualDebtSucceed = 75;

		/// <summary>
		/// FujianAreaSpiritualDebtSucceed
		/// </summary>
		public const short FujianAreaSpiritualDebtSucceed = 76;

		/// <summary>
		/// LiaodongAreaSpiritualDebtSucceed
		/// </summary>
		public const short LiaodongAreaSpiritualDebtSucceed = 77;

		/// <summary>
		/// XiyuAreaSpiritualDebtSucceed
		/// </summary>
		public const short XiyuAreaSpiritualDebtSucceed = 78;

		/// <summary>
		/// YunnanAreaSpiritualDebtSucceed
		/// </summary>
		public const short YunnanAreaSpiritualDebtSucceed = 79;

		/// <summary>
		/// HuainanAreaSpiritualDebtSucceed
		/// </summary>
		public const short HuainanAreaSpiritualDebtSucceed = 80;

		/// <summary>
		/// JiangnanAreaSpiritualDebtSucceed
		/// </summary>
		public const short JiangnanAreaSpiritualDebtSucceed = 81;

		/// <summary>
		/// JiangbeiAreaSpiritualDebtSucceed
		/// </summary>
		public const short JiangbeiAreaSpiritualDebtSucceed = 82;

		/// <summary>
		/// AreaSpiritualDebtIgnored
		/// </summary>
		public const short AreaSpiritualDebtIgnored = 83;

		/// <summary>
		/// TravelBattlePerfectWin
		/// </summary>
		public const short TravelBattlePerfectWin = 84;

		/// <summary>
		/// TravelBattleWin
		/// </summary>
		public const short TravelBattleWin = 85;

		/// <summary>
		/// TravelBattleLose
		/// </summary>
		public const short TravelBattleLose = 86;

		/// <summary>
		/// GroupMemberAccept
		/// </summary>
		public const short GroupMemberAccept = 87;

		/// <summary>
		/// GroupMemberRefuse
		/// </summary>
		public const short GroupMemberRefuse = 88;

		/// <summary>
		/// GroupMemberIgnored
		/// </summary>
		public const short GroupMemberIgnored = 89;

		/// <summary>
		/// ConsumeStrengthSucceed
		/// </summary>
		public const short ConsumeStrengthSucceed = 90;

		/// <summary>
		/// ConsumeDexteritySucceed
		/// </summary>
		public const short ConsumeDexteritySucceed = 91;

		/// <summary>
		/// ConsumeConcentrationSucceed
		/// </summary>
		public const short ConsumeConcentrationSucceed = 92;

		/// <summary>
		/// ConsumeVitalitySucceed
		/// </summary>
		public const short ConsumeVitalitySucceed = 93;

		/// <summary>
		/// ConsumeEnergySucceed
		/// </summary>
		public const short ConsumeEnergySucceed = 94;

		/// <summary>
		/// ConsumeIntelligenceSucceed
		/// </summary>
		public const short ConsumeIntelligenceSucceed = 95;

		/// <summary>
		/// NoConsumeMainAttribute
		/// </summary>
		public const short NoConsumeMainAttribute = 96;

		/// <summary>
		/// RoadBlockAndDetour
		/// </summary>
		public const short RoadBlockAndDetour = 97;

		/// <summary>
		/// RoadBlockAndIgnore
		/// </summary>
		public const short RoadBlockAndIgnore = 98;

		/// <summary>
		/// JingjiInteract
		/// </summary>
		public const short JingjiInteract = 99;

		/// <summary>
		/// BashuInteract
		/// </summary>
		public const short BashuInteract = 100;

		/// <summary>
		/// GuangnanInteract
		/// </summary>
		public const short GuangnanInteract = 101;

		/// <summary>
		/// JingBeiInteract
		/// </summary>
		public const short JingBeiInteract = 102;

		/// <summary>
		/// ShanxiInteract
		/// </summary>
		public const short ShanxiInteract = 103;

		/// <summary>
		/// GuangdongInteract
		/// </summary>
		public const short GuangdongInteract = 104;

		/// <summary>
		/// ShandongInteract
		/// </summary>
		public const short ShandongInteract = 105;

		/// <summary>
		/// JingnanInteract
		/// </summary>
		public const short JingnanInteract = 106;

		/// <summary>
		/// FujianInteract
		/// </summary>
		public const short FujianInteract = 107;

		/// <summary>
		/// LiaodongInteract
		/// </summary>
		public const short LiaodongInteract = 108;

		/// <summary>
		/// XiyuInteract
		/// </summary>
		public const short XiyuInteract = 109;

		/// <summary>
		/// YunnanInteract
		/// </summary>
		public const short YunnanInteract = 110;

		/// <summary>
		/// HuainanInteract
		/// </summary>
		public const short HuainanInteract = 111;

		/// <summary>
		/// JiangnanInteract
		/// </summary>
		public const short JiangnanInteract = 112;

		/// <summary>
		/// JiangbeiInteract
		/// </summary>
		public const short JiangbeiInteract = 113;

		/// <summary>
		/// JingjiAreaSpiritualDebt
		/// </summary>
		public const short JingjiAreaSpiritualDebt = 114;

		/// <summary>
		/// BashuAreaSpiritualDebt
		/// </summary>
		public const short BashuAreaSpiritualDebt = 115;

		/// <summary>
		/// GuangnanAreaSpiritualDebt
		/// </summary>
		public const short GuangnanAreaSpiritualDebt = 116;

		/// <summary>
		/// JingBeiAreaSpiritualDebt
		/// </summary>
		public const short JingBeiAreaSpiritualDebt = 117;

		/// <summary>
		/// ShanxiAreaSpiritualDebt
		/// </summary>
		public const short ShanxiAreaSpiritualDebt = 118;

		/// <summary>
		/// GuangdongAreaSpiritualDebt
		/// </summary>
		public const short GuangdongAreaSpiritualDebt = 119;

		/// <summary>
		/// ShandongAreaSpiritualDebt
		/// </summary>
		public const short ShandongAreaSpiritualDebt = 120;

		/// <summary>
		/// JingnanAreaSpiritualDebt
		/// </summary>
		public const short JingnanAreaSpiritualDebt = 121;

		/// <summary>
		/// FujianAreaSpiritualDebt
		/// </summary>
		public const short FujianAreaSpiritualDebt = 122;

		/// <summary>
		/// LiaodongAreaSpiritualDebt
		/// </summary>
		public const short LiaodongAreaSpiritualDebt = 123;

		/// <summary>
		/// XiyuAreaSpiritualDebt
		/// </summary>
		public const short XiyuAreaSpiritualDebt = 124;

		/// <summary>
		/// YunnanAreaSpiritualDebt
		/// </summary>
		public const short YunnanAreaSpiritualDebt = 125;

		/// <summary>
		/// HuainanAreaSpiritualDebt
		/// </summary>
		public const short HuainanAreaSpiritualDebt = 126;

		/// <summary>
		/// JiangnanAreaSpiritualDebt
		/// </summary>
		public const short JiangnanAreaSpiritualDebt = 127;

		/// <summary>
		/// JiangbeiAreaSpiritualDebt
		/// </summary>
		public const short JiangbeiAreaSpiritualDebt = 128;

		/// <summary>
		/// VisitShaolin
		/// </summary>
		public const short VisitShaolin = 129;

		/// <summary>
		/// VisitEmei
		/// </summary>
		public const short VisitEmei = 130;

		/// <summary>
		/// VisitBaihua
		/// </summary>
		public const short VisitBaihua = 131;

		/// <summary>
		/// VisitWudang
		/// </summary>
		public const short VisitWudang = 132;

		/// <summary>
		/// VisitYuanshan
		/// </summary>
		public const short VisitYuanshan = 133;

		/// <summary>
		/// VisitShixiang
		/// </summary>
		public const short VisitShixiang = 134;

		/// <summary>
		/// VisitRanshan
		/// </summary>
		public const short VisitRanshan = 135;

		/// <summary>
		/// VisitXuannv
		/// </summary>
		public const short VisitXuannv = 136;

		/// <summary>
		/// VisitZhujian
		/// </summary>
		public const short VisitZhujian = 137;

		/// <summary>
		/// VisitKongsang
		/// </summary>
		public const short VisitKongsang = 138;

		/// <summary>
		/// VisitJingang
		/// </summary>
		public const short VisitJingang = 139;

		/// <summary>
		/// VisitWuxian
		/// </summary>
		public const short VisitWuxian = 140;

		/// <summary>
		/// VisitJieqing
		/// </summary>
		public const short VisitJieqing = 141;

		/// <summary>
		/// VisitFulong
		/// </summary>
		public const short VisitFulong = 142;

		/// <summary>
		/// VisitXuehou
		/// </summary>
		public const short VisitXuehou = 143;

		/// <summary>
		/// EnemyAttack
		/// </summary>
		public const short EnemyAttack = 144;

		/// <summary>
		/// RighteousAttack
		/// </summary>
		public const short RighteousAttack = 145;

		/// <summary>
		/// XiangshuMinionAttack
		/// </summary>
		public const short XiangshuMinionAttack = 146;

		/// <summary>
		/// ShaolinAttack
		/// </summary>
		public const short ShaolinAttack = 147;

		/// <summary>
		/// EmeiAttack
		/// </summary>
		public const short EmeiAttack = 148;

		/// <summary>
		/// BaihuaAttack
		/// </summary>
		public const short BaihuaAttack = 149;

		/// <summary>
		/// WudangAttack
		/// </summary>
		public const short WudangAttack = 150;

		/// <summary>
		/// YuanshanAttack
		/// </summary>
		public const short YuanshanAttack = 151;

		/// <summary>
		/// JingangAttack
		/// </summary>
		public const short JingangAttack = 152;

		/// <summary>
		/// WuxianAttack
		/// </summary>
		public const short WuxianAttack = 153;

		/// <summary>
		/// JieqingAttack
		/// </summary>
		public const short JieqingAttack = 154;

		/// <summary>
		/// FulongAttack
		/// </summary>
		public const short FulongAttack = 155;

		/// <summary>
		/// XuehouAttack
		/// </summary>
		public const short XuehouAttack = 156;

		/// <summary>
		/// FriendGroupMember
		/// </summary>
		public const short FriendGroupMember = 157;

		/// <summary>
		/// FameGroupMember
		/// </summary>
		public const short FameGroupMember = 158;

		/// <summary>
		/// ConsumeStrength
		/// </summary>
		public const short ConsumeStrength = 159;

		/// <summary>
		/// ConsumeDexterity
		/// </summary>
		public const short ConsumeDexterity = 160;

		/// <summary>
		/// ConsumeConcentration
		/// </summary>
		public const short ConsumeConcentration = 161;

		/// <summary>
		/// ConsumeVitality
		/// </summary>
		public const short ConsumeVitality = 162;

		/// <summary>
		/// ConsumeEnergy
		/// </summary>
		public const short ConsumeEnergy = 163;

		/// <summary>
		/// ConsumeIntelligence
		/// </summary>
		public const short ConsumeIntelligence = 164;

		/// <summary>
		/// RoadBlock
		/// </summary>
		public const short RoadBlock = 165;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// JingjiMaterial
		/// </summary>
		public static TravelingEventItem JingjiMaterial => Instance[(short)0];

		/// <summary>
		/// BashuMaterial
		/// </summary>
		public static TravelingEventItem BashuMaterial => Instance[(short)1];

		/// <summary>
		/// GuangnanMaterial
		/// </summary>
		public static TravelingEventItem GuangnanMaterial => Instance[(short)2];

		/// <summary>
		/// JingBeiMaterial
		/// </summary>
		public static TravelingEventItem JingBeiMaterial => Instance[(short)3];

		/// <summary>
		/// ShanxiMaterial
		/// </summary>
		public static TravelingEventItem ShanxiMaterial => Instance[(short)4];

		/// <summary>
		/// GuangdongMaterial
		/// </summary>
		public static TravelingEventItem GuangdongMaterial => Instance[(short)5];

		/// <summary>
		/// ShandongMaterial
		/// </summary>
		public static TravelingEventItem ShandongMaterial => Instance[(short)6];

		/// <summary>
		/// JingnanMaterial
		/// </summary>
		public static TravelingEventItem JingnanMaterial => Instance[(short)7];

		/// <summary>
		/// FujianMaterial
		/// </summary>
		public static TravelingEventItem FujianMaterial => Instance[(short)8];

		/// <summary>
		/// LiaodongMaterial
		/// </summary>
		public static TravelingEventItem LiaodongMaterial => Instance[(short)9];

		/// <summary>
		/// XiyuMaterial
		/// </summary>
		public static TravelingEventItem XiyuMaterial => Instance[(short)10];

		/// <summary>
		/// YunnanMaterial
		/// </summary>
		public static TravelingEventItem YunnanMaterial => Instance[(short)11];

		/// <summary>
		/// HuainanMaterial
		/// </summary>
		public static TravelingEventItem HuainanMaterial => Instance[(short)12];

		/// <summary>
		/// JiangnanMaterial
		/// </summary>
		public static TravelingEventItem JiangnanMaterial => Instance[(short)13];

		/// <summary>
		/// JiangbeiMaterial
		/// </summary>
		public static TravelingEventItem JiangbeiMaterial => Instance[(short)14];

		/// <summary>
		/// JingjiResource
		/// </summary>
		public static TravelingEventItem JingjiResource => Instance[(short)15];

		/// <summary>
		/// BashuResource
		/// </summary>
		public static TravelingEventItem BashuResource => Instance[(short)16];

		/// <summary>
		/// GuangnanResource
		/// </summary>
		public static TravelingEventItem GuangnanResource => Instance[(short)17];

		/// <summary>
		/// JingBeiResource
		/// </summary>
		public static TravelingEventItem JingBeiResource => Instance[(short)18];

		/// <summary>
		/// ShanxiResource
		/// </summary>
		public static TravelingEventItem ShanxiResource => Instance[(short)19];

		/// <summary>
		/// GuangdongResource
		/// </summary>
		public static TravelingEventItem GuangdongResource => Instance[(short)20];

		/// <summary>
		/// ShandongResource
		/// </summary>
		public static TravelingEventItem ShandongResource => Instance[(short)21];

		/// <summary>
		/// JingnanResource
		/// </summary>
		public static TravelingEventItem JingnanResource => Instance[(short)22];

		/// <summary>
		/// FujianResource
		/// </summary>
		public static TravelingEventItem FujianResource => Instance[(short)23];

		/// <summary>
		/// LiaodongResource
		/// </summary>
		public static TravelingEventItem LiaodongResource => Instance[(short)24];

		/// <summary>
		/// XiyuResource
		/// </summary>
		public static TravelingEventItem XiyuResource => Instance[(short)25];

		/// <summary>
		/// YunnanResource
		/// </summary>
		public static TravelingEventItem YunnanResource => Instance[(short)26];

		/// <summary>
		/// HuainanResource
		/// </summary>
		public static TravelingEventItem HuainanResource => Instance[(short)27];

		/// <summary>
		/// JiangnanResource
		/// </summary>
		public static TravelingEventItem JiangnanResource => Instance[(short)28];

		/// <summary>
		/// JiangbeiResource
		/// </summary>
		public static TravelingEventItem JiangbeiResource => Instance[(short)29];

		/// <summary>
		/// JingjiFood
		/// </summary>
		public static TravelingEventItem JingjiFood => Instance[(short)30];

		/// <summary>
		/// BashuFood
		/// </summary>
		public static TravelingEventItem BashuFood => Instance[(short)31];

		/// <summary>
		/// GuangnanFood
		/// </summary>
		public static TravelingEventItem GuangnanFood => Instance[(short)32];

		/// <summary>
		/// JingBeiFood
		/// </summary>
		public static TravelingEventItem JingBeiFood => Instance[(short)33];

		/// <summary>
		/// ShanxiFood
		/// </summary>
		public static TravelingEventItem ShanxiFood => Instance[(short)34];

		/// <summary>
		/// GuangdongFood
		/// </summary>
		public static TravelingEventItem GuangdongFood => Instance[(short)35];

		/// <summary>
		/// ShandongFood
		/// </summary>
		public static TravelingEventItem ShandongFood => Instance[(short)36];

		/// <summary>
		/// JingnanFood
		/// </summary>
		public static TravelingEventItem JingnanFood => Instance[(short)37];

		/// <summary>
		/// FujianFood
		/// </summary>
		public static TravelingEventItem FujianFood => Instance[(short)38];

		/// <summary>
		/// LiaodongFood
		/// </summary>
		public static TravelingEventItem LiaodongFood => Instance[(short)39];

		/// <summary>
		/// XiyuFood
		/// </summary>
		public static TravelingEventItem XiyuFood => Instance[(short)40];

		/// <summary>
		/// YunnanFood
		/// </summary>
		public static TravelingEventItem YunnanFood => Instance[(short)41];

		/// <summary>
		/// HuainanFood
		/// </summary>
		public static TravelingEventItem HuainanFood => Instance[(short)42];

		/// <summary>
		/// JiangnanFood
		/// </summary>
		public static TravelingEventItem JiangnanFood => Instance[(short)43];

		/// <summary>
		/// JiangbeiFood
		/// </summary>
		public static TravelingEventItem JiangbeiFood => Instance[(short)44];

		/// <summary>
		/// HealOuterInjury
		/// </summary>
		public static TravelingEventItem HealOuterInjury => Instance[(short)45];

		/// <summary>
		/// HealInnerInjury
		/// </summary>
		public static TravelingEventItem HealInnerInjury => Instance[(short)46];

		/// <summary>
		/// HealPoison
		/// </summary>
		public static TravelingEventItem HealPoison => Instance[(short)47];

		/// <summary>
		/// HealDisorderOfQi
		/// </summary>
		public static TravelingEventItem HealDisorderOfQi => Instance[(short)48];

		/// <summary>
		/// HealLifeSpan
		/// </summary>
		public static TravelingEventItem HealLifeSpan => Instance[(short)49];

		/// <summary>
		/// FriendResource
		/// </summary>
		public static TravelingEventItem FriendResource => Instance[(short)50];

		/// <summary>
		/// FriendFood
		/// </summary>
		public static TravelingEventItem FriendFood => Instance[(short)51];

		/// <summary>
		/// FriendTeaWine
		/// </summary>
		public static TravelingEventItem FriendTeaWine => Instance[(short)52];

		/// <summary>
		/// FriendMedicine
		/// </summary>
		public static TravelingEventItem FriendMedicine => Instance[(short)53];

		/// <summary>
		/// FameResource
		/// </summary>
		public static TravelingEventItem FameResource => Instance[(short)54];

		/// <summary>
		/// FameFood
		/// </summary>
		public static TravelingEventItem FameFood => Instance[(short)55];

		/// <summary>
		/// FameTeaWine
		/// </summary>
		public static TravelingEventItem FameTeaWine => Instance[(short)56];

		/// <summary>
		/// FameMedicine
		/// </summary>
		public static TravelingEventItem FameMedicine => Instance[(short)57];

		/// <summary>
		/// RecoverStrength
		/// </summary>
		public static TravelingEventItem RecoverStrength => Instance[(short)58];

		/// <summary>
		/// RecoverDexterity
		/// </summary>
		public static TravelingEventItem RecoverDexterity => Instance[(short)59];

		/// <summary>
		/// RecoverConcentration
		/// </summary>
		public static TravelingEventItem RecoverConcentration => Instance[(short)60];

		/// <summary>
		/// RecoverVitality
		/// </summary>
		public static TravelingEventItem RecoverVitality => Instance[(short)61];

		/// <summary>
		/// RecoverEnergy
		/// </summary>
		public static TravelingEventItem RecoverEnergy => Instance[(short)62];

		/// <summary>
		/// RecoverIntelligence
		/// </summary>
		public static TravelingEventItem RecoverIntelligence => Instance[(short)63];

		/// <summary>
		/// AreaInteractGood
		/// </summary>
		public static TravelingEventItem AreaInteractGood => Instance[(short)64];

		/// <summary>
		/// AreaInteractNormal
		/// </summary>
		public static TravelingEventItem AreaInteractNormal => Instance[(short)65];

		/// <summary>
		/// AreaInteractBad
		/// </summary>
		public static TravelingEventItem AreaInteractBad => Instance[(short)66];

		/// <summary>
		/// AreaInteractIgnored
		/// </summary>
		public static TravelingEventItem AreaInteractIgnored => Instance[(short)67];

		/// <summary>
		/// JingjiAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem JingjiAreaSpiritualDebtSucceed => Instance[(short)68];

		/// <summary>
		/// BashuAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem BashuAreaSpiritualDebtSucceed => Instance[(short)69];

		/// <summary>
		/// GuangnanAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem GuangnanAreaSpiritualDebtSucceed => Instance[(short)70];

		/// <summary>
		/// JingBeiAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem JingBeiAreaSpiritualDebtSucceed => Instance[(short)71];

		/// <summary>
		/// ShanxiAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem ShanxiAreaSpiritualDebtSucceed => Instance[(short)72];

		/// <summary>
		/// GuangdongAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem GuangdongAreaSpiritualDebtSucceed => Instance[(short)73];

		/// <summary>
		/// ShandongAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem ShandongAreaSpiritualDebtSucceed => Instance[(short)74];

		/// <summary>
		/// JingnanAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem JingnanAreaSpiritualDebtSucceed => Instance[(short)75];

		/// <summary>
		/// FujianAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem FujianAreaSpiritualDebtSucceed => Instance[(short)76];

		/// <summary>
		/// LiaodongAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem LiaodongAreaSpiritualDebtSucceed => Instance[(short)77];

		/// <summary>
		/// XiyuAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem XiyuAreaSpiritualDebtSucceed => Instance[(short)78];

		/// <summary>
		/// YunnanAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem YunnanAreaSpiritualDebtSucceed => Instance[(short)79];

		/// <summary>
		/// HuainanAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem HuainanAreaSpiritualDebtSucceed => Instance[(short)80];

		/// <summary>
		/// JiangnanAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem JiangnanAreaSpiritualDebtSucceed => Instance[(short)81];

		/// <summary>
		/// JiangbeiAreaSpiritualDebtSucceed
		/// </summary>
		public static TravelingEventItem JiangbeiAreaSpiritualDebtSucceed => Instance[(short)82];

		/// <summary>
		/// AreaSpiritualDebtIgnored
		/// </summary>
		public static TravelingEventItem AreaSpiritualDebtIgnored => Instance[(short)83];

		/// <summary>
		/// TravelBattlePerfectWin
		/// </summary>
		public static TravelingEventItem TravelBattlePerfectWin => Instance[(short)84];

		/// <summary>
		/// TravelBattleWin
		/// </summary>
		public static TravelingEventItem TravelBattleWin => Instance[(short)85];

		/// <summary>
		/// TravelBattleLose
		/// </summary>
		public static TravelingEventItem TravelBattleLose => Instance[(short)86];

		/// <summary>
		/// GroupMemberAccept
		/// </summary>
		public static TravelingEventItem GroupMemberAccept => Instance[(short)87];

		/// <summary>
		/// GroupMemberRefuse
		/// </summary>
		public static TravelingEventItem GroupMemberRefuse => Instance[(short)88];

		/// <summary>
		/// GroupMemberIgnored
		/// </summary>
		public static TravelingEventItem GroupMemberIgnored => Instance[(short)89];

		/// <summary>
		/// ConsumeStrengthSucceed
		/// </summary>
		public static TravelingEventItem ConsumeStrengthSucceed => Instance[(short)90];

		/// <summary>
		/// ConsumeDexteritySucceed
		/// </summary>
		public static TravelingEventItem ConsumeDexteritySucceed => Instance[(short)91];

		/// <summary>
		/// ConsumeConcentrationSucceed
		/// </summary>
		public static TravelingEventItem ConsumeConcentrationSucceed => Instance[(short)92];

		/// <summary>
		/// ConsumeVitalitySucceed
		/// </summary>
		public static TravelingEventItem ConsumeVitalitySucceed => Instance[(short)93];

		/// <summary>
		/// ConsumeEnergySucceed
		/// </summary>
		public static TravelingEventItem ConsumeEnergySucceed => Instance[(short)94];

		/// <summary>
		/// ConsumeIntelligenceSucceed
		/// </summary>
		public static TravelingEventItem ConsumeIntelligenceSucceed => Instance[(short)95];

		/// <summary>
		/// NoConsumeMainAttribute
		/// </summary>
		public static TravelingEventItem NoConsumeMainAttribute => Instance[(short)96];

		/// <summary>
		/// RoadBlockAndDetour
		/// </summary>
		public static TravelingEventItem RoadBlockAndDetour => Instance[(short)97];

		/// <summary>
		/// RoadBlockAndIgnore
		/// </summary>
		public static TravelingEventItem RoadBlockAndIgnore => Instance[(short)98];

		/// <summary>
		/// JingjiInteract
		/// </summary>
		public static TravelingEventItem JingjiInteract => Instance[(short)99];

		/// <summary>
		/// BashuInteract
		/// </summary>
		public static TravelingEventItem BashuInteract => Instance[(short)100];

		/// <summary>
		/// GuangnanInteract
		/// </summary>
		public static TravelingEventItem GuangnanInteract => Instance[(short)101];

		/// <summary>
		/// JingBeiInteract
		/// </summary>
		public static TravelingEventItem JingBeiInteract => Instance[(short)102];

		/// <summary>
		/// ShanxiInteract
		/// </summary>
		public static TravelingEventItem ShanxiInteract => Instance[(short)103];

		/// <summary>
		/// GuangdongInteract
		/// </summary>
		public static TravelingEventItem GuangdongInteract => Instance[(short)104];

		/// <summary>
		/// ShandongInteract
		/// </summary>
		public static TravelingEventItem ShandongInteract => Instance[(short)105];

		/// <summary>
		/// JingnanInteract
		/// </summary>
		public static TravelingEventItem JingnanInteract => Instance[(short)106];

		/// <summary>
		/// FujianInteract
		/// </summary>
		public static TravelingEventItem FujianInteract => Instance[(short)107];

		/// <summary>
		/// LiaodongInteract
		/// </summary>
		public static TravelingEventItem LiaodongInteract => Instance[(short)108];

		/// <summary>
		/// XiyuInteract
		/// </summary>
		public static TravelingEventItem XiyuInteract => Instance[(short)109];

		/// <summary>
		/// YunnanInteract
		/// </summary>
		public static TravelingEventItem YunnanInteract => Instance[(short)110];

		/// <summary>
		/// HuainanInteract
		/// </summary>
		public static TravelingEventItem HuainanInteract => Instance[(short)111];

		/// <summary>
		/// JiangnanInteract
		/// </summary>
		public static TravelingEventItem JiangnanInteract => Instance[(short)112];

		/// <summary>
		/// JiangbeiInteract
		/// </summary>
		public static TravelingEventItem JiangbeiInteract => Instance[(short)113];

		/// <summary>
		/// JingjiAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem JingjiAreaSpiritualDebt => Instance[(short)114];

		/// <summary>
		/// BashuAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem BashuAreaSpiritualDebt => Instance[(short)115];

		/// <summary>
		/// GuangnanAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem GuangnanAreaSpiritualDebt => Instance[(short)116];

		/// <summary>
		/// JingBeiAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem JingBeiAreaSpiritualDebt => Instance[(short)117];

		/// <summary>
		/// ShanxiAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem ShanxiAreaSpiritualDebt => Instance[(short)118];

		/// <summary>
		/// GuangdongAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem GuangdongAreaSpiritualDebt => Instance[(short)119];

		/// <summary>
		/// ShandongAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem ShandongAreaSpiritualDebt => Instance[(short)120];

		/// <summary>
		/// JingnanAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem JingnanAreaSpiritualDebt => Instance[(short)121];

		/// <summary>
		/// FujianAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem FujianAreaSpiritualDebt => Instance[(short)122];

		/// <summary>
		/// LiaodongAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem LiaodongAreaSpiritualDebt => Instance[(short)123];

		/// <summary>
		/// XiyuAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem XiyuAreaSpiritualDebt => Instance[(short)124];

		/// <summary>
		/// YunnanAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem YunnanAreaSpiritualDebt => Instance[(short)125];

		/// <summary>
		/// HuainanAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem HuainanAreaSpiritualDebt => Instance[(short)126];

		/// <summary>
		/// JiangnanAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem JiangnanAreaSpiritualDebt => Instance[(short)127];

		/// <summary>
		/// JiangbeiAreaSpiritualDebt
		/// </summary>
		public static TravelingEventItem JiangbeiAreaSpiritualDebt => Instance[(short)128];

		/// <summary>
		/// VisitShaolin
		/// </summary>
		public static TravelingEventItem VisitShaolin => Instance[(short)129];

		/// <summary>
		/// VisitEmei
		/// </summary>
		public static TravelingEventItem VisitEmei => Instance[(short)130];

		/// <summary>
		/// VisitBaihua
		/// </summary>
		public static TravelingEventItem VisitBaihua => Instance[(short)131];

		/// <summary>
		/// VisitWudang
		/// </summary>
		public static TravelingEventItem VisitWudang => Instance[(short)132];

		/// <summary>
		/// VisitYuanshan
		/// </summary>
		public static TravelingEventItem VisitYuanshan => Instance[(short)133];

		/// <summary>
		/// VisitShixiang
		/// </summary>
		public static TravelingEventItem VisitShixiang => Instance[(short)134];

		/// <summary>
		/// VisitRanshan
		/// </summary>
		public static TravelingEventItem VisitRanshan => Instance[(short)135];

		/// <summary>
		/// VisitXuannv
		/// </summary>
		public static TravelingEventItem VisitXuannv => Instance[(short)136];

		/// <summary>
		/// VisitZhujian
		/// </summary>
		public static TravelingEventItem VisitZhujian => Instance[(short)137];

		/// <summary>
		/// VisitKongsang
		/// </summary>
		public static TravelingEventItem VisitKongsang => Instance[(short)138];

		/// <summary>
		/// VisitJingang
		/// </summary>
		public static TravelingEventItem VisitJingang => Instance[(short)139];

		/// <summary>
		/// VisitWuxian
		/// </summary>
		public static TravelingEventItem VisitWuxian => Instance[(short)140];

		/// <summary>
		/// VisitJieqing
		/// </summary>
		public static TravelingEventItem VisitJieqing => Instance[(short)141];

		/// <summary>
		/// VisitFulong
		/// </summary>
		public static TravelingEventItem VisitFulong => Instance[(short)142];

		/// <summary>
		/// VisitXuehou
		/// </summary>
		public static TravelingEventItem VisitXuehou => Instance[(short)143];

		/// <summary>
		/// EnemyAttack
		/// </summary>
		public static TravelingEventItem EnemyAttack => Instance[(short)144];

		/// <summary>
		/// RighteousAttack
		/// </summary>
		public static TravelingEventItem RighteousAttack => Instance[(short)145];

		/// <summary>
		/// XiangshuMinionAttack
		/// </summary>
		public static TravelingEventItem XiangshuMinionAttack => Instance[(short)146];

		/// <summary>
		/// ShaolinAttack
		/// </summary>
		public static TravelingEventItem ShaolinAttack => Instance[(short)147];

		/// <summary>
		/// EmeiAttack
		/// </summary>
		public static TravelingEventItem EmeiAttack => Instance[(short)148];

		/// <summary>
		/// BaihuaAttack
		/// </summary>
		public static TravelingEventItem BaihuaAttack => Instance[(short)149];

		/// <summary>
		/// WudangAttack
		/// </summary>
		public static TravelingEventItem WudangAttack => Instance[(short)150];

		/// <summary>
		/// YuanshanAttack
		/// </summary>
		public static TravelingEventItem YuanshanAttack => Instance[(short)151];

		/// <summary>
		/// JingangAttack
		/// </summary>
		public static TravelingEventItem JingangAttack => Instance[(short)152];

		/// <summary>
		/// WuxianAttack
		/// </summary>
		public static TravelingEventItem WuxianAttack => Instance[(short)153];

		/// <summary>
		/// JieqingAttack
		/// </summary>
		public static TravelingEventItem JieqingAttack => Instance[(short)154];

		/// <summary>
		/// FulongAttack
		/// </summary>
		public static TravelingEventItem FulongAttack => Instance[(short)155];

		/// <summary>
		/// XuehouAttack
		/// </summary>
		public static TravelingEventItem XuehouAttack => Instance[(short)156];

		/// <summary>
		/// FriendGroupMember
		/// </summary>
		public static TravelingEventItem FriendGroupMember => Instance[(short)157];

		/// <summary>
		/// FameGroupMember
		/// </summary>
		public static TravelingEventItem FameGroupMember => Instance[(short)158];

		/// <summary>
		/// ConsumeStrength
		/// </summary>
		public static TravelingEventItem ConsumeStrength => Instance[(short)159];

		/// <summary>
		/// ConsumeDexterity
		/// </summary>
		public static TravelingEventItem ConsumeDexterity => Instance[(short)160];

		/// <summary>
		/// ConsumeConcentration
		/// </summary>
		public static TravelingEventItem ConsumeConcentration => Instance[(short)161];

		/// <summary>
		/// ConsumeVitality
		/// </summary>
		public static TravelingEventItem ConsumeVitality => Instance[(short)162];

		/// <summary>
		/// ConsumeEnergy
		/// </summary>
		public static TravelingEventItem ConsumeEnergy => Instance[(short)163];

		/// <summary>
		/// ConsumeIntelligence
		/// </summary>
		public static TravelingEventItem ConsumeIntelligence => Instance[(short)164];

		/// <summary>
		/// RoadBlock
		/// </summary>
		public static TravelingEventItem RoadBlock => Instance[(short)165];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TravelingEvent Instance = new TravelingEvent();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "StateTemplateId", "OrgTemplateId", "CharacterProperty", "ItemRange", "TemplateId", "DisplayType", "Event", "ValueRange",
		"ItemGradeWeight", "ResourceWeights"
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
		_dataArray.Add(new TravelingEventItem(0, LocalStringManager.GetConfig("TravelingEvent_language", "Name_0"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_0"), new string[5] { "Character", "Item", "", "", "" }, 1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 21, 7)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(1, LocalStringManager.GetConfig("TravelingEvent_language", "Name_1"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_1"), new string[5] { "Character", "Item", "", "", "" }, 2, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 0, 7)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(2, LocalStringManager.GetConfig("TravelingEvent_language", "Name_2"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_2"), new string[5] { "Character", "Item", "", "", "" }, 3, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 140, 96)
		}, new short[9] { 0, 256, 0, 16, 0, 1, 0, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(3, LocalStringManager.GetConfig("TravelingEvent_language", "Name_3"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_3"), new string[5] { "Character", "Item", "", "", "" }, 4, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 7, 7)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(4, LocalStringManager.GetConfig("TravelingEvent_language", "Name_4"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_4"), new string[5] { "Character", "Item", "", "", "" }, 5, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 63, 7)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(5, LocalStringManager.GetConfig("TravelingEvent_language", "Name_5"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_5"), new string[5] { "Character", "Item", "", "", "" }, 6, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 28, 7)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(6, LocalStringManager.GetConfig("TravelingEvent_language", "Name_6"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_6"), new string[5] { "Character", "Item", "", "", "" }, 7, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 49, 7)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(7, LocalStringManager.GetConfig("TravelingEvent_language", "Name_7"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_7"), new string[5] { "Character", "Item", "", "", "" }, 8, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 35, 7)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(8, LocalStringManager.GetConfig("TravelingEvent_language", "Name_8"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_8"), new string[5] { "Character", "Item", "", "", "" }, 9, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 14, 7)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(9, LocalStringManager.GetConfig("TravelingEvent_language", "Name_9"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_9"), new string[5] { "Character", "Item", "", "", "" }, 10, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 140, 96)
		}, new short[9] { 0, 256, 0, 16, 0, 1, 0, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(10, LocalStringManager.GetConfig("TravelingEvent_language", "Name_10"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_10"), new string[5] { "Character", "Item", "", "", "" }, 11, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 42, 7)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(11, LocalStringManager.GetConfig("TravelingEvent_language", "Name_11"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_11"), new string[5] { "Character", "Item", "", "", "" }, 12, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 236, 42)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(12, LocalStringManager.GetConfig("TravelingEvent_language", "Name_12"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_12"), new string[5] { "Character", "Item", "", "", "" }, 13, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 70, 14)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(13, LocalStringManager.GetConfig("TravelingEvent_language", "Name_13"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_13"), new string[5] { "Character", "Item", "", "", "" }, 14, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 77, 7)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(14, LocalStringManager.GetConfig("TravelingEvent_language", "Name_14"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaMaterial, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_14"), new string[5] { "Character", "Item", "", "", "" }, 15, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 236, 42)
		}, new short[9] { 0, 243, 81, 27, 9, 3, 1, 0, 0 }, null));
		_dataArray.Add(new TravelingEventItem(15, LocalStringManager.GetConfig("TravelingEvent_language", "Name_15"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_15"), new string[5] { "Character", "Integer", "Resource", "", "" }, 1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 10, 5, 5, 5, 15, 5, 30, 15 }));
		_dataArray.Add(new TravelingEventItem(16, LocalStringManager.GetConfig("TravelingEvent_language", "Name_16"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_16"), new string[5] { "Character", "Integer", "Resource", "", "" }, 2, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 20, 10, 20, 5, 10, 5, 10, 10 }));
		_dataArray.Add(new TravelingEventItem(17, LocalStringManager.GetConfig("TravelingEvent_language", "Name_17"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_17"), new string[5] { "Character", "Integer", "Resource", "", "" }, 3, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 10, 10, 5, 10, 5, 30, 10, 10 }));
		_dataArray.Add(new TravelingEventItem(18, LocalStringManager.GetConfig("TravelingEvent_language", "Name_18"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_18"), new string[5] { "Character", "Integer", "Resource", "", "" }, 4, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 5, 10, 15, 15, 10, 10, 10, 15 }));
		_dataArray.Add(new TravelingEventItem(19, LocalStringManager.GetConfig("TravelingEvent_language", "Name_19"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_19"), new string[5] { "Character", "Integer", "Resource", "", "" }, 5, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 35, 10, 10, 10, 5, 5, 10, 5 }));
		_dataArray.Add(new TravelingEventItem(20, LocalStringManager.GetConfig("TravelingEvent_language", "Name_20"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_20"), new string[5] { "Character", "Integer", "Resource", "", "" }, 6, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 20, 5, 5, 5, 5, 10, 10, 30 }));
		_dataArray.Add(new TravelingEventItem(21, LocalStringManager.GetConfig("TravelingEvent_language", "Name_21"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_21"), new string[5] { "Character", "Integer", "Resource", "", "" }, 7, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 10, 5, 10, 10, 20, 10, 15, 10 }));
		_dataArray.Add(new TravelingEventItem(22, LocalStringManager.GetConfig("TravelingEvent_language", "Name_22"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_22"), new string[5] { "Character", "Integer", "Resource", "", "" }, 8, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 20, 10, 10, 10, 10, 10, 10, 10 }));
		_dataArray.Add(new TravelingEventItem(23, LocalStringManager.GetConfig("TravelingEvent_language", "Name_23"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_23"), new string[5] { "Character", "Integer", "Resource", "", "" }, 9, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 5, 20, 20, 20, 10, 5, 5, 5 }));
		_dataArray.Add(new TravelingEventItem(24, LocalStringManager.GetConfig("TravelingEvent_language", "Name_24"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_24"), new string[5] { "Character", "Integer", "Resource", "", "" }, 10, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 10, 15, 10, 10, 15, 20, 5, 5 }));
		_dataArray.Add(new TravelingEventItem(25, LocalStringManager.GetConfig("TravelingEvent_language", "Name_25"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_25"), new string[5] { "Character", "Integer", "Resource", "", "" }, 11, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 5, 5, 10, 30, 5, 5, 20, 10 }));
		_dataArray.Add(new TravelingEventItem(26, LocalStringManager.GetConfig("TravelingEvent_language", "Name_26"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_26"), new string[5] { "Character", "Integer", "Resource", "", "" }, 12, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 5, 20, 15, 15, 10, 15, 5, 5 }));
		_dataArray.Add(new TravelingEventItem(27, LocalStringManager.GetConfig("TravelingEvent_language", "Name_27"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_27"), new string[5] { "Character", "Integer", "Resource", "", "" }, 13, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 10, 10, 20, 10, 10, 10, 10, 10 }));
		_dataArray.Add(new TravelingEventItem(28, LocalStringManager.GetConfig("TravelingEvent_language", "Name_28"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_28"), new string[5] { "Character", "Integer", "Resource", "", "" }, 14, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 15, 10, 5, 5, 20, 5, 20, 10 }));
		_dataArray.Add(new TravelingEventItem(29, LocalStringManager.GetConfig("TravelingEvent_language", "Name_29"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_29"), new string[5] { "Character", "Integer", "Resource", "", "" }, 15, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, 6, null, 0, new int[2] { 50, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, new short[8] { 15, 20, 5, 5, 15, 5, 10, 15 }));
		_dataArray.Add(new TravelingEventItem(30, LocalStringManager.GetConfig("TravelingEvent_language", "Name_30"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_30"), new string[5] { "Character", "Item", "", "", "" }, 1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 9, 42)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(31, LocalStringManager.GetConfig("TravelingEvent_language", "Name_31"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_31"), new string[5] { "Character", "Item", "", "", "" }, 2, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 51, 42)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(32, LocalStringManager.GetConfig("TravelingEvent_language", "Name_32"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_32"), new string[5] { "Character", "Item", "", "", "" }, 3, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 93, 42)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(33, LocalStringManager.GetConfig("TravelingEvent_language", "Name_33"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_33"), new string[5] { "Character", "Item", "", "", "" }, 4, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 9, 42)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(34, LocalStringManager.GetConfig("TravelingEvent_language", "Name_34"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_34"), new string[5] { "Character", "Item", "", "", "" }, 5, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 93, 42)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(35, LocalStringManager.GetConfig("TravelingEvent_language", "Name_35"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_35"), new string[5] { "Character", "Item", "", "", "" }, 6, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 0, 9)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(36, LocalStringManager.GetConfig("TravelingEvent_language", "Name_36"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_36"), new string[5] { "Character", "Item", "", "", "" }, 7, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 0, 9)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(37, LocalStringManager.GetConfig("TravelingEvent_language", "Name_37"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_37"), new string[5] { "Character", "Item", "", "", "" }, 8, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 135, 42)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(38, LocalStringManager.GetConfig("TravelingEvent_language", "Name_38"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_38"), new string[5] { "Character", "Item", "", "", "" }, 9, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 135, 42)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(39, LocalStringManager.GetConfig("TravelingEvent_language", "Name_39"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_39"), new string[5] { "Character", "Item", "", "", "" }, 10, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 51, 42)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(40, LocalStringManager.GetConfig("TravelingEvent_language", "Name_40"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_40"), new string[5] { "Character", "Item", "", "", "" }, 11, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 51, 42)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(41, LocalStringManager.GetConfig("TravelingEvent_language", "Name_41"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_41"), new string[5] { "Character", "Item", "", "", "" }, 12, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 0, 9)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(42, LocalStringManager.GetConfig("TravelingEvent_language", "Name_42"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_42"), new string[5] { "Character", "Item", "", "", "" }, 13, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 93, 42)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(43, LocalStringManager.GetConfig("TravelingEvent_language", "Name_43"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_43"), new string[5] { "Character", "Item", "", "", "" }, 14, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 135, 42)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(44, LocalStringManager.GetConfig("TravelingEvent_language", "Name_44"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AreaFood, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_44"), new string[5] { "Character", "Item", "", "", "" }, 15, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 9, 42)
		}, new short[9] { 288, 96, 32, 16, 8, 4, 2, 1, 0 }, null));
		_dataArray.Add(new TravelingEventItem(45, LocalStringManager.GetConfig("TravelingEvent_language", "Name_45"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Heal, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_45"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 5, 0, new sbyte[2] { -100, 100 }, 5, null, 0, new int[2] { 2, 3 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(46, LocalStringManager.GetConfig("TravelingEvent_language", "Name_46"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Heal, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_46"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 5, 0, new sbyte[2] { -100, 100 }, 5, null, 0, new int[2] { 2, 3 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(47, LocalStringManager.GetConfig("TravelingEvent_language", "Name_47"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Heal, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_47"), new string[5] { "Character", "PoisonType", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 5, 0, new sbyte[2] { -100, 100 }, 5, null, 0, new int[2] { 100, 150 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(48, LocalStringManager.GetConfig("TravelingEvent_language", "Name_48"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Heal, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_48"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 5, 0, new sbyte[2] { -100, 100 }, 5, null, 0, new int[2] { 250, 500 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(49, LocalStringManager.GetConfig("TravelingEvent_language", "Name_49"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Heal, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_49"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 5, 0, new sbyte[2] { -100, 100 }, 5, null, 0, new int[2] { 12, 24 }, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(50, LocalStringManager.GetConfig("TravelingEvent_language", "Name_50"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.CharacterGiftResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_50"), new string[5] { "Character", "Location", "Character", "Integer", "Resource" }, -1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(51, LocalStringManager.GetConfig("TravelingEvent_language", "Name_51"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.CharacterGiftItem, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_51"), new string[5] { "Character", "Location", "Character", "Item", "" }, -1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, 7, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(52, LocalStringManager.GetConfig("TravelingEvent_language", "Name_52"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.CharacterGiftItem, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_52"), new string[5] { "Character", "Location", "Character", "Item", "" }, -1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, 9, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(53, LocalStringManager.GetConfig("TravelingEvent_language", "Name_53"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.CharacterGiftItem, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_53"), new string[5] { "Character", "Location", "Character", "Item", "" }, -1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 20, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, 8, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(54, LocalStringManager.GetConfig("TravelingEvent_language", "Name_54"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.CharacterGiftResource, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_54"), new string[5] { "Character", "Location", "Character", "Integer", "Resource" }, -1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(55, LocalStringManager.GetConfig("TravelingEvent_language", "Name_55"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.CharacterGiftItem, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_55"), new string[5] { "Character", "Location", "Character", "Item", "" }, -1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, 7, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(56, LocalStringManager.GetConfig("TravelingEvent_language", "Name_56"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.CharacterGiftItem, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_56"), new string[5] { "Character", "Location", "Character", "Item", "" }, -1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, 9, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(57, LocalStringManager.GetConfig("TravelingEvent_language", "Name_57"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.CharacterGiftItem, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_57"), new string[5] { "Character", "Location", "Character", "Item", "" }, -1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 1, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, 8, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(58, LocalStringManager.GetConfig("TravelingEvent_language", "Name_58"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AttributeRegen, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_58"), new string[5] { "Character", "Location", "Integer", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 3, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, 0, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(59, LocalStringManager.GetConfig("TravelingEvent_language", "Name_59"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AttributeRegen, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_59"), new string[5] { "Character", "Location", "Integer", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 3, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, 1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new TravelingEventItem(60, LocalStringManager.GetConfig("TravelingEvent_language", "Name_60"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AttributeRegen, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_60"), new string[5] { "Character", "Location", "Integer", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 3, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, 2, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(61, LocalStringManager.GetConfig("TravelingEvent_language", "Name_61"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AttributeRegen, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_61"), new string[5] { "Character", "Location", "Integer", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 3, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, 3, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(62, LocalStringManager.GetConfig("TravelingEvent_language", "Name_62"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AttributeRegen, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_62"), new string[5] { "Character", "Location", "Integer", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 3, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, 4, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(63, LocalStringManager.GetConfig("TravelingEvent_language", "Name_63"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.AttributeRegen, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_63"), new string[5] { "Character", "Location", "Integer", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 3, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, 5, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(64, LocalStringManager.GetConfig("TravelingEvent_language", "Name_64"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_64"), new string[5] { "Character", "Location", "Character", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(65, LocalStringManager.GetConfig("TravelingEvent_language", "Name_65"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_65"), new string[5] { "Character", "Location", "Character", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(66, LocalStringManager.GetConfig("TravelingEvent_language", "Name_66"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_66"), new string[5] { "Character", "Location", "Character", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(67, LocalStringManager.GetConfig("TravelingEvent_language", "Name_67"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_67"), new string[5] { "Character", "Location", "Character", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(68, LocalStringManager.GetConfig("TravelingEvent_language", "Name_68"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_68"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(69, LocalStringManager.GetConfig("TravelingEvent_language", "Name_69"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_69"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(70, LocalStringManager.GetConfig("TravelingEvent_language", "Name_70"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_70"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(71, LocalStringManager.GetConfig("TravelingEvent_language", "Name_71"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_71"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(72, LocalStringManager.GetConfig("TravelingEvent_language", "Name_72"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_72"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(73, LocalStringManager.GetConfig("TravelingEvent_language", "Name_73"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_73"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(74, LocalStringManager.GetConfig("TravelingEvent_language", "Name_74"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_74"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(75, LocalStringManager.GetConfig("TravelingEvent_language", "Name_75"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_75"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(76, LocalStringManager.GetConfig("TravelingEvent_language", "Name_76"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_76"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(77, LocalStringManager.GetConfig("TravelingEvent_language", "Name_77"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_77"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(78, LocalStringManager.GetConfig("TravelingEvent_language", "Name_78"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_78"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(79, LocalStringManager.GetConfig("TravelingEvent_language", "Name_79"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_79"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(80, LocalStringManager.GetConfig("TravelingEvent_language", "Name_80"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_80"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(81, LocalStringManager.GetConfig("TravelingEvent_language", "Name_81"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_81"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(82, LocalStringManager.GetConfig("TravelingEvent_language", "Name_82"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_82"), new string[5] { "Character", "Settlement", "CharacterPropertyReferencedType", "Float", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(83, LocalStringManager.GetConfig("TravelingEvent_language", "Name_83"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_83"), new string[5] { "Character", "Settlement", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(84, LocalStringManager.GetConfig("TravelingEvent_language", "Name_84"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_84"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(85, LocalStringManager.GetConfig("TravelingEvent_language", "Name_85"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_85"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(86, LocalStringManager.GetConfig("TravelingEvent_language", "Name_86"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_86"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(87, LocalStringManager.GetConfig("TravelingEvent_language", "Name_87"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_87"), new string[5] { "Character", "Character", "Character", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(88, LocalStringManager.GetConfig("TravelingEvent_language", "Name_88"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_88"), new string[5] { "Character", "Character", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(89, LocalStringManager.GetConfig("TravelingEvent_language", "Name_89"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_89"), new string[5] { "Character", "Character", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(90, LocalStringManager.GetConfig("TravelingEvent_language", "Name_90"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_90"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(91, LocalStringManager.GetConfig("TravelingEvent_language", "Name_91"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_91"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(92, LocalStringManager.GetConfig("TravelingEvent_language", "Name_92"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_92"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(93, LocalStringManager.GetConfig("TravelingEvent_language", "Name_93"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_93"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(94, LocalStringManager.GetConfig("TravelingEvent_language", "Name_94"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_94"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(95, LocalStringManager.GetConfig("TravelingEvent_language", "Name_95"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_95"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(96, LocalStringManager.GetConfig("TravelingEvent_language", "Name_96"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_96"), new string[5] { "Character", "", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(97, LocalStringManager.GetConfig("TravelingEvent_language", "Name_97"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_97"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(98, LocalStringManager.GetConfig("TravelingEvent_language", "Name_98"), ETravelingEventDisplayType.TravelingEvent_0, ETravelingEventType.Notification, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_98"), new string[5] { "Character", "ItemKey", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, null, 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(99, LocalStringManager.GetConfig("TravelingEvent_language", "Name_99"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_99"), new string[5] { "Character", "Location", "Character", "", "" }, 1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 0, "6c26bab3-5247-4c97-a8f8-e7253e58a13e", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(100, LocalStringManager.GetConfig("TravelingEvent_language", "Name_100"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_100"), new string[5] { "Character", "Location", "Character", "", "" }, 2, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 0, "fcdca37f-3f5c-4db4-8f3a-d3067e03cb39", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(101, LocalStringManager.GetConfig("TravelingEvent_language", "Name_101"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_101"), new string[5] { "Character", "Location", "Character", "", "" }, 3, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 2, "a7b3540b-23d9-4bbc-a8f9-7d755ac0b00b", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(102, LocalStringManager.GetConfig("TravelingEvent_language", "Name_102"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_102"), new string[5] { "Character", "Location", "Character", "", "" }, 4, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 4, "05314993-0ab3-4367-811b-127d68ebbf6d", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(103, LocalStringManager.GetConfig("TravelingEvent_language", "Name_103"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_103"), new string[5] { "Character", "Location", "Character", "", "" }, 5, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 1, "aa4de24b-f63d-4dc0-8805-81f31ad18ab8", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(104, LocalStringManager.GetConfig("TravelingEvent_language", "Name_104"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_104"), new string[5] { "Character", "Location", "Character", "", "" }, 6, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 2, "535d8d3c-3b7a-4d87-8f72-fc4db03784d5", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(105, LocalStringManager.GetConfig("TravelingEvent_language", "Name_105"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_105"), new string[5] { "Character", "Location", "Character", "", "" }, 7, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 1, "c3fec540-df56-4d5e-bf08-b4555e18d2ca", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(106, LocalStringManager.GetConfig("TravelingEvent_language", "Name_106"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_106"), new string[5] { "Character", "Location", "Character", "", "" }, 8, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 0, "51cdb901-42e2-45da-a559-d476fd2425ff", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(107, LocalStringManager.GetConfig("TravelingEvent_language", "Name_107"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_107"), new string[5] { "Character", "Location", "Character", "", "" }, 9, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 4, "f7f252c7-e095-4cb4-bbb4-d9bee30db040", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(108, LocalStringManager.GetConfig("TravelingEvent_language", "Name_108"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_108"), new string[5] { "Character", "Location", "Character", "", "" }, 10, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 3, "7af98dc9-d130-4638-94e4-c764645f29fc", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(109, LocalStringManager.GetConfig("TravelingEvent_language", "Name_109"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_109"), new string[5] { "Character", "Location", "Character", "", "" }, 11, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 3, "c62f67a8-b4d6-4a38-a8d3-9a115ec7d940", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(110, LocalStringManager.GetConfig("TravelingEvent_language", "Name_110"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_110"), new string[5] { "Character", "Location", "Character", "", "" }, 12, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 2, "14bd1d59-57a9-4835-808e-8e00f7d08b4a", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(111, LocalStringManager.GetConfig("TravelingEvent_language", "Name_111"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_111"), new string[5] { "Character", "Location", "Character", "", "" }, 13, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 3, "24f51c67-7d85-43a2-ba58-1ba785ae6ee7", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(112, LocalStringManager.GetConfig("TravelingEvent_language", "Name_112"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_112"), new string[5] { "Character", "Location", "Character", "", "" }, 14, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 1, "f496a372-c892-48db-9dad-390a18d3d26a", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(113, LocalStringManager.GetConfig("TravelingEvent_language", "Name_113"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.AreaInteraction, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_113"), new string[5] { "Character", "Location", "Character", "", "" }, 15, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 4, "180336cb-0310-4a55-bdae-e937a1310d6c", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(114, LocalStringManager.GetConfig("TravelingEvent_language", "Name_114"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_114"), new string[5] { "Character", "Settlement", "", "", "" }, 1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 2, "9f6e1296-c192-4f09-8a27-21b23cf6c716", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(115, LocalStringManager.GetConfig("TravelingEvent_language", "Name_115"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_115"), new string[5] { "Character", "Settlement", "", "", "" }, 2, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 4, "b1000d73-c563-487b-b96c-764584b1f1fb", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(116, LocalStringManager.GetConfig("TravelingEvent_language", "Name_116"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_116"), new string[5] { "Character", "Settlement", "", "", "" }, 3, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 0, "c859d7db-01e4-4660-866e-5a72705cad80", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(117, LocalStringManager.GetConfig("TravelingEvent_language", "Name_117"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_117"), new string[5] { "Character", "Settlement", "", "", "" }, 4, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 3, "84983a51-9f61-45b5-a734-fb0c7d17c8e4", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(118, LocalStringManager.GetConfig("TravelingEvent_language", "Name_118"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_118"), new string[5] { "Character", "Settlement", "", "", "" }, 5, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 0, "7747c4da-902a-4da8-ba59-29221db4e874", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(119, LocalStringManager.GetConfig("TravelingEvent_language", "Name_119"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_119"), new string[5] { "Character", "Settlement", "", "", "" }, 6, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 3, "50cd1a13-a3a5-4e62-bd16-3f7bc6f5b767", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new TravelingEventItem(120, LocalStringManager.GetConfig("TravelingEvent_language", "Name_120"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_120"), new string[5] { "Character", "Settlement", "", "", "" }, 7, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 1, "358f6d1c-6994-41fd-bd44-f555219465ea", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(121, LocalStringManager.GetConfig("TravelingEvent_language", "Name_121"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_121"), new string[5] { "Character", "Settlement", "", "", "" }, 8, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 4, "ddca8e22-e230-4c43-8415-959ce9b2899d", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(122, LocalStringManager.GetConfig("TravelingEvent_language", "Name_122"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_122"), new string[5] { "Character", "Settlement", "", "", "" }, 9, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 2, "cad6674d-f904-4100-8634-bf1b3807e293", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(123, LocalStringManager.GetConfig("TravelingEvent_language", "Name_123"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_123"), new string[5] { "Character", "Settlement", "", "", "" }, 10, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 1, "37edc08b-99ff-4b43-8d43-fcff13291091", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(124, LocalStringManager.GetConfig("TravelingEvent_language", "Name_124"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_124"), new string[5] { "Character", "Settlement", "", "", "" }, 11, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 4, "4c5b9706-3834-4de3-8273-01dcbba28b94", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(125, LocalStringManager.GetConfig("TravelingEvent_language", "Name_125"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_125"), new string[5] { "Character", "Settlement", "", "", "" }, 12, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 3, "858060fb-60ed-404e-bdff-e05179409285", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(126, LocalStringManager.GetConfig("TravelingEvent_language", "Name_126"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_126"), new string[5] { "Character", "Settlement", "", "", "" }, 13, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 0, "528ef3f9-3ffb-4652-9c72-e60c2504ae29", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(127, LocalStringManager.GetConfig("TravelingEvent_language", "Name_127"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_127"), new string[5] { "Character", "Settlement", "", "", "" }, 14, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 2, "db69a775-c98d-4398-9f60-0636ab4d026f", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(128, LocalStringManager.GetConfig("TravelingEvent_language", "Name_128"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.SpiritualDebt, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_128"), new string[5] { "Character", "Settlement", "", "", "" }, 15, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, 1, "69ddfc28-4f3c-49a3-91c0-6519e9763f40", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(129, LocalStringManager.GetConfig("TravelingEvent_language", "Name_129"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_129"), new string[5] { "Character", "Location", "", "", "" }, 1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 1, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "7466fa32-741c-4413-a7a6-08c704c687ef", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(130, LocalStringManager.GetConfig("TravelingEvent_language", "Name_130"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_130"), new string[5] { "Character", "Location", "", "", "" }, 2, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 2, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "c0364283-24e7-4e10-b584-48971121299c", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(131, LocalStringManager.GetConfig("TravelingEvent_language", "Name_131"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_131"), new string[5] { "Character", "Location", "", "", "" }, 3, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 3, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "afccbfd5-d5e4-4dcf-82bf-7c9c256e544e", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(132, LocalStringManager.GetConfig("TravelingEvent_language", "Name_132"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_132"), new string[5] { "Character", "Location", "", "", "" }, 4, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 4, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "8adacd25-060e-4a0e-b9da-a814ecc1d9c0", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(133, LocalStringManager.GetConfig("TravelingEvent_language", "Name_133"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_133"), new string[5] { "Character", "Location", "", "", "" }, 5, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 5, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "28475f2c-e368-40c1-88e8-57a18fb0e38e", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(134, LocalStringManager.GetConfig("TravelingEvent_language", "Name_134"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_134"), new string[5] { "Character", "Location", "", "", "" }, 6, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 6, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "ff0f1368-79c9-49df-b5b4-06e47ecde548", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(135, LocalStringManager.GetConfig("TravelingEvent_language", "Name_135"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_135"), new string[5] { "Character", "Location", "", "", "" }, 7, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 7, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "618b4db6-ff20-4dac-8c97-018964ed0b0a", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(136, LocalStringManager.GetConfig("TravelingEvent_language", "Name_136"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_136"), new string[5] { "Character", "Location", "", "", "" }, 8, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 8, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "20ced638-563f-4453-9289-81d811f37851", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(137, LocalStringManager.GetConfig("TravelingEvent_language", "Name_137"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_137"), new string[5] { "Character", "Location", "", "", "" }, 9, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 9, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "b0e48b48-7e41-4d40-a949-079a35d0b8af", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(138, LocalStringManager.GetConfig("TravelingEvent_language", "Name_138"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_138"), new string[5] { "Character", "Location", "", "", "" }, 10, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 10, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "f266965b-ff83-4db1-93a0-6e00da4702ab", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(139, LocalStringManager.GetConfig("TravelingEvent_language", "Name_139"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_139"), new string[5] { "Character", "Location", "", "", "" }, 11, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 11, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "14acf515-76c3-4083-a06c-42e9db67d78f", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(140, LocalStringManager.GetConfig("TravelingEvent_language", "Name_140"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_140"), new string[5] { "Character", "Location", "", "", "" }, 12, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 12, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "5bb5deda-00d3-4976-b737-f31a718886f2", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(141, LocalStringManager.GetConfig("TravelingEvent_language", "Name_141"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_141"), new string[5] { "Character", "Location", "", "", "" }, 13, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 13, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "c1fe70a3-c37f-4c19-9643-2a11414cef7c", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(142, LocalStringManager.GetConfig("TravelingEvent_language", "Name_142"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_142"), new string[5] { "Character", "Location", "", "", "" }, 14, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 14, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "0ac07093-5dd8-479a-85b0-6c80689974f8", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(143, LocalStringManager.GetConfig("TravelingEvent_language", "Name_143"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.SectVisit, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_143"), new string[5] { "Character", "Location", "", "", "" }, 15, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.SectArea, 15, isUnique: true, 100, 100, 0, new sbyte[2] { -100, 100 }, -1, "4772f315-9060-4cf6-9204-3cd41553e4c0", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(144, LocalStringManager.GetConfig("TravelingEvent_language", "Name_144"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.Combat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_144"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, 17, isUnique: false, -1, 25, 0, new sbyte[2] { -100, 100 }, -1, "15892dee-18dc-4ee7-81d5-137068701e13", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(145, LocalStringManager.GetConfig("TravelingEvent_language", "Name_145"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.Combat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_145"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.NormalArea, 18, isUnique: false, -1, 25, -1, new sbyte[2] { -100, -50 }, -1, "15892dee-18dc-4ee7-81d5-137068701e13", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(146, LocalStringManager.GetConfig("TravelingEvent_language", "Name_146"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.Combat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_146"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.BrokenArea, 19, isUnique: false, -1, 5, 0, new sbyte[2] { -100, 100 }, -1, "15892dee-18dc-4ee7-81d5-137068701e13", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(147, LocalStringManager.GetConfig("TravelingEvent_language", "Name_147"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.SectCombat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_147"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, 1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.SectArea, 1, isUnique: false, -1, 20, -1, new sbyte[2] { -100, 100 }, -1, "2b76fef8-3491-47d9-9360-9d72a6b3354b", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(148, LocalStringManager.GetConfig("TravelingEvent_language", "Name_148"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.SectCombat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_148"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, 2, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.SectArea, 2, isUnique: false, -1, 20, -1, new sbyte[2] { -100, 100 }, -1, "f5687014-4ef5-4233-af25-05e55b1012ef", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(149, LocalStringManager.GetConfig("TravelingEvent_language", "Name_149"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.SectCombat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_149"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, 3, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.SectArea, 3, isUnique: false, -1, 20, -1, new sbyte[2] { -100, 100 }, -1, "e504bf16-5f6f-4960-ae85-abea51e87e52", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(150, LocalStringManager.GetConfig("TravelingEvent_language", "Name_150"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.SectCombat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_150"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, 4, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.SectArea, 4, isUnique: false, -1, 20, -1, new sbyte[2] { -100, 100 }, -1, "84b18c01-154b-4235-b288-0d3e2697a741", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(151, LocalStringManager.GetConfig("TravelingEvent_language", "Name_151"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.SectCombat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_151"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, 5, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.SectArea, 5, isUnique: false, -1, 20, -1, new sbyte[2] { -100, 100 }, -1, "5a2f3450-4d04-4a01-b669-617628338e16", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(152, LocalStringManager.GetConfig("TravelingEvent_language", "Name_152"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.SectCombat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_152"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, 11, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.SectArea, 11, isUnique: false, 1, 20, 1, new sbyte[2] { -100, 100 }, -1, "333fa625-5773-4b50-9056-562a6f2002d2", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(153, LocalStringManager.GetConfig("TravelingEvent_language", "Name_153"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.SectCombat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_153"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, 12, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.SectArea, 12, isUnique: false, 1, 20, 1, new sbyte[2] { -100, 100 }, -1, "72e08263-ae2c-49ca-8d4a-7dd302f02756", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(154, LocalStringManager.GetConfig("TravelingEvent_language", "Name_154"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.SectCombat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_154"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, 13, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.SectArea, 13, isUnique: false, 1, 20, 1, new sbyte[2] { -100, 100 }, -1, "e92b0a4b-1478-4b24-b107-588c220d6a6b", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(155, LocalStringManager.GetConfig("TravelingEvent_language", "Name_155"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.SectCombat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_155"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, 14, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.SectArea, 14, isUnique: false, 1, 20, 1, new sbyte[2] { -100, 100 }, -1, "2cab1ae2-59b2-4486-adb5-256ed3364651", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(156, LocalStringManager.GetConfig("TravelingEvent_language", "Name_156"), ETravelingEventDisplayType.TravelingEvent_2, ETravelingEventType.SectCombat, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_156"), new string[5] { "Character", "CharacterTemplate", "", "", "" }, 15, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.SectArea, 15, isUnique: false, 1, 20, 1, new sbyte[2] { -100, 100 }, -1, "f54cdc32-f58f-40ab-93b9-aa926c71ad46", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(157, LocalStringManager.GetConfig("TravelingEvent_language", "Name_157"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.CharacterRecommendVillager, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_157"), new string[5] { "Character", "Location", "Character", "Character", "" }, -1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 15, 0, new sbyte[2] { -100, 100 }, -1, "4c2d630e-bdfd-4f40-9712-d80cf02c746f", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(158, LocalStringManager.GetConfig("TravelingEvent_language", "Name_158"), ETravelingEventDisplayType.TravelingEvent_1, ETravelingEventType.CharacterRecommendVillager, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_158"), new string[5] { "Character", "Location", "Character", "Character", "" }, -1, ETravelingEventTriggerType.OnArea, ETravelingEventTriggerAreaType.NormalArea, -1, isUnique: false, 0, 10, 1, new sbyte[2] { -100, 100 }, -1, "4c2d630e-bdfd-4f40-9712-d80cf02c746f", 3, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(159, LocalStringManager.GetConfig("TravelingEvent_language", "Name_159"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.AttributeCost, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_159"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 1, 0, new sbyte[2] { -100, 100 }, -1, "1162ab17-3ad2-445f-987f-8b3deeb39811", 0, null, 0, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(160, LocalStringManager.GetConfig("TravelingEvent_language", "Name_160"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.AttributeCost, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_160"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 1, 0, new sbyte[2] { -100, 100 }, -1, "2fa259d2-b2e2-4cda-b33c-ff6f2b91bf69", 0, null, 1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(161, LocalStringManager.GetConfig("TravelingEvent_language", "Name_161"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.AttributeCost, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_161"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 1, 0, new sbyte[2] { -100, 100 }, -1, "34675f5a-daad-4e67-88e9-4ed3aa9a5955", 0, null, 2, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(162, LocalStringManager.GetConfig("TravelingEvent_language", "Name_162"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.AttributeCost, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_162"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 1, 0, new sbyte[2] { -100, 100 }, -1, "323d9b3b-e136-4227-a7e3-29ebc11cddec", 0, null, 3, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(163, LocalStringManager.GetConfig("TravelingEvent_language", "Name_163"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.AttributeCost, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_163"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 1, 0, new sbyte[2] { -100, 100 }, -1, "f232f116-4e38-4652-8c6a-ef3c91b0c078", 0, null, 4, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(164, LocalStringManager.GetConfig("TravelingEvent_language", "Name_164"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.AttributeCost, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_164"), new string[5] { "Character", "Integer", "", "", "" }, -1, ETravelingEventTriggerType.ToArea, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 1, 0, new sbyte[2] { -100, 100 }, -1, "ddadb9df-7b41-4076-90f0-95d9afc3a10b", 0, null, 5, -1, new List<PresetItemTemplateIdGroup>(), null, null));
		_dataArray.Add(new TravelingEventItem(165, LocalStringManager.GetConfig("TravelingEvent_language", "Name_165"), ETravelingEventDisplayType.TravelingEvent_3, ETravelingEventType.CarrierDurability, LocalStringManager.GetConfig("TravelingEvent_language", "Desc_165"), new string[5] { "Character", "", "", "", "" }, -1, ETravelingEventTriggerType.Any, ETravelingEventTriggerAreaType.Any, -1, isUnique: false, 0, 0, 0, new sbyte[2] { -100, 100 }, -1, "35a36035-be2a-42cd-8a8e-dc77ee240b09", 0, null, -1, -1, new List<PresetItemTemplateIdGroup>(), null, null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TravelingEventItem>(166);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
