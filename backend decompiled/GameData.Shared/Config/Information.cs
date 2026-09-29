using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Information : ConfigData<InformationItem, short>
{
	public static class DefKey
	{
		public const short KongsangProsperous = 55;

		public const short KongsangFailing = 56;

		public const short XuehouProsperous = 57;

		public const short XuehouFailing = 58;

		public const short ShaolinProsperous = 59;

		public const short ShaolinFailing = 60;

		public const short WudangProsperous = 61;

		public const short WudangFailing = 62;

		public const short XuannvProsperous = 63;

		public const short XuannvFailing = 64;

		public const short YuanshanProsperous = 65;

		public const short YuanshanFailing = 66;

		public const short ShixiangProsperous = 67;

		public const short ShixiangFailing = 68;

		public const short WuxianProsperous = 69;

		public const short WuxianFailing0 = 70;

		public const short WuxianFailing1 = 71;

		public const short EmeiFailing = 72;

		public const short EmeiProsperous = 73;

		public const short JieqingFailing = 74;

		public const short JieqingProsperous = 75;

		public const short RanshanProsperous = 76;

		public const short RanshanFailing = 77;

		public const short JingangProsperous = 78;

		public const short JingangFailing = 79;

		public const short SwordTombMonvFake = 80;

		public const short SwordTomDayueYaochangFake = 81;

		public const short SwordTombJiuhanFake = 82;

		public const short SwordTombJinHuangerFake = 83;

		public const short SwordTombYiYihouFake = 84;

		public const short SwordTombWeiQiFake = 85;

		public const short SwordTombYixiangFake = 86;

		public const short SwordTombXuefengFake = 87;

		public const short SwordTombShuFangFake = 88;

		public const short SwordTombMonvReal = 89;

		public const short SwordTomDayueYaochangReal = 90;

		public const short SwordTombJiuhanReal = 91;

		public const short SwordTombJinHuangerReal = 92;

		public const short SwordTombYiYihouReal = 93;

		public const short SwordTombWeiQiReal = 94;

		public const short SwordTombYixiangReal = 95;

		public const short SwordTombXuefengReal = 96;

		public const short SwordTombShuFangReal = 97;

		public const short SwordTombMonvRealPermanent = 98;

		public const short SwordTomDayueYaochangRealPermanent = 99;

		public const short SwordTombJiuhanRealPermanent = 100;

		public const short SwordTombJinHuangerRealPermanent = 101;

		public const short SwordTombYiYihouRealPermanent = 102;

		public const short SwordTombWeiQiRealPermanent = 103;

		public const short SwordTombYixiangRealPermanent = 104;

		public const short SwordTombXuefengRealPermanent = 105;

		public const short SwordTombShuFangRealPermanent = 106;

		public const short BaihuaProsperous = 107;

		public const short BaihuaFailing = 108;

		public const short FulongProsperous = 109;

		public const short FulongFailing = 110;

		public const short SwordTombMonvSwordTombKeeper = 111;

		public const short SwordTomDayueYaochangSwordTombKeeper = 112;

		public const short SwordTombJiuhanSwordTombKeeper = 113;

		public const short SwordTombJinHuangerSwordTombKeeper = 114;

		public const short SwordTombYiYihouSwordTombKeeper = 115;

		public const short SwordTombWeiQiSwordTombKeeper = 116;

		public const short SwordTombYixiangSwordTombKeeper = 117;

		public const short SwordTombXuefengSwordTombKeeper = 118;

		public const short SwordTombShuFangSwordTombKeeper = 119;

		public const short ZhujianProsperous = 120;

		public const short ZhujianFailing = 121;

		public const short SavageProfession = 122;

		public const short HunterProfession = 123;

		public const short CraftProfession = 124;

		public const short MartialArtistProfession = 125;

		public const short LiteratiProfession = 126;

		public const short TaoistMonkProfession = 127;

		public const short BuddhistMonkProfession = 128;

		public const short WineTasterProfession = 129;

		public const short AristocratProfession = 130;

		public const short BeggarProfession = 131;

		public const short CivilianProfession = 132;

		public const short TravelerProfession = 133;

		public const short TravelingBuddhistMonkProfession = 134;

		public const short DoctorProfession = 135;

		public const short TravelingTaoistMonkProfession = 136;

		public const short CapitalistProfession = 137;

		public const short TeaTasterProfession = 138;

		public const short DukeProfession = 139;

		public const short SwordTombMonvMonk = 140;

		public const short SwordTomDayueYaochangMonk = 141;

		public const short SwordTombJiuhanMonk = 142;

		public const short SwordTombJinHuangerMonk = 143;

		public const short SwordTombYiYihouMonk = 144;

		public const short SwordTombWeiQiMonk = 145;

		public const short SwordTombYixiangMonk = 146;

		public const short SwordTombXuefengMonk = 147;

		public const short SwordTombShuFangMonk = 148;

		public const short XiangshuProfession = 149;
	}

	public static class DefValue
	{
		public static InformationItem KongsangProsperous => Instance[(short)55];

		public static InformationItem KongsangFailing => Instance[(short)56];

		public static InformationItem XuehouProsperous => Instance[(short)57];

		public static InformationItem XuehouFailing => Instance[(short)58];

		public static InformationItem ShaolinProsperous => Instance[(short)59];

		public static InformationItem ShaolinFailing => Instance[(short)60];

		public static InformationItem WudangProsperous => Instance[(short)61];

		public static InformationItem WudangFailing => Instance[(short)62];

		public static InformationItem XuannvProsperous => Instance[(short)63];

		public static InformationItem XuannvFailing => Instance[(short)64];

		public static InformationItem YuanshanProsperous => Instance[(short)65];

		public static InformationItem YuanshanFailing => Instance[(short)66];

		public static InformationItem ShixiangProsperous => Instance[(short)67];

		public static InformationItem ShixiangFailing => Instance[(short)68];

		public static InformationItem WuxianProsperous => Instance[(short)69];

		public static InformationItem WuxianFailing0 => Instance[(short)70];

		public static InformationItem WuxianFailing1 => Instance[(short)71];

		public static InformationItem EmeiFailing => Instance[(short)72];

		public static InformationItem EmeiProsperous => Instance[(short)73];

		public static InformationItem JieqingFailing => Instance[(short)74];

		public static InformationItem JieqingProsperous => Instance[(short)75];

		public static InformationItem RanshanProsperous => Instance[(short)76];

		public static InformationItem RanshanFailing => Instance[(short)77];

		public static InformationItem JingangProsperous => Instance[(short)78];

		public static InformationItem JingangFailing => Instance[(short)79];

		public static InformationItem SwordTombMonvFake => Instance[(short)80];

		public static InformationItem SwordTomDayueYaochangFake => Instance[(short)81];

		public static InformationItem SwordTombJiuhanFake => Instance[(short)82];

		public static InformationItem SwordTombJinHuangerFake => Instance[(short)83];

		public static InformationItem SwordTombYiYihouFake => Instance[(short)84];

		public static InformationItem SwordTombWeiQiFake => Instance[(short)85];

		public static InformationItem SwordTombYixiangFake => Instance[(short)86];

		public static InformationItem SwordTombXuefengFake => Instance[(short)87];

		public static InformationItem SwordTombShuFangFake => Instance[(short)88];

		public static InformationItem SwordTombMonvReal => Instance[(short)89];

		public static InformationItem SwordTomDayueYaochangReal => Instance[(short)90];

		public static InformationItem SwordTombJiuhanReal => Instance[(short)91];

		public static InformationItem SwordTombJinHuangerReal => Instance[(short)92];

		public static InformationItem SwordTombYiYihouReal => Instance[(short)93];

		public static InformationItem SwordTombWeiQiReal => Instance[(short)94];

		public static InformationItem SwordTombYixiangReal => Instance[(short)95];

		public static InformationItem SwordTombXuefengReal => Instance[(short)96];

		public static InformationItem SwordTombShuFangReal => Instance[(short)97];

		public static InformationItem SwordTombMonvRealPermanent => Instance[(short)98];

		public static InformationItem SwordTomDayueYaochangRealPermanent => Instance[(short)99];

		public static InformationItem SwordTombJiuhanRealPermanent => Instance[(short)100];

		public static InformationItem SwordTombJinHuangerRealPermanent => Instance[(short)101];

		public static InformationItem SwordTombYiYihouRealPermanent => Instance[(short)102];

		public static InformationItem SwordTombWeiQiRealPermanent => Instance[(short)103];

		public static InformationItem SwordTombYixiangRealPermanent => Instance[(short)104];

		public static InformationItem SwordTombXuefengRealPermanent => Instance[(short)105];

		public static InformationItem SwordTombShuFangRealPermanent => Instance[(short)106];

		public static InformationItem BaihuaProsperous => Instance[(short)107];

		public static InformationItem BaihuaFailing => Instance[(short)108];

		public static InformationItem FulongProsperous => Instance[(short)109];

		public static InformationItem FulongFailing => Instance[(short)110];

		public static InformationItem SwordTombMonvSwordTombKeeper => Instance[(short)111];

		public static InformationItem SwordTomDayueYaochangSwordTombKeeper => Instance[(short)112];

		public static InformationItem SwordTombJiuhanSwordTombKeeper => Instance[(short)113];

		public static InformationItem SwordTombJinHuangerSwordTombKeeper => Instance[(short)114];

		public static InformationItem SwordTombYiYihouSwordTombKeeper => Instance[(short)115];

		public static InformationItem SwordTombWeiQiSwordTombKeeper => Instance[(short)116];

		public static InformationItem SwordTombYixiangSwordTombKeeper => Instance[(short)117];

		public static InformationItem SwordTombXuefengSwordTombKeeper => Instance[(short)118];

		public static InformationItem SwordTombShuFangSwordTombKeeper => Instance[(short)119];

		public static InformationItem ZhujianProsperous => Instance[(short)120];

		public static InformationItem ZhujianFailing => Instance[(short)121];

		public static InformationItem SavageProfession => Instance[(short)122];

		public static InformationItem HunterProfession => Instance[(short)123];

		public static InformationItem CraftProfession => Instance[(short)124];

		public static InformationItem MartialArtistProfession => Instance[(short)125];

		public static InformationItem LiteratiProfession => Instance[(short)126];

		public static InformationItem TaoistMonkProfession => Instance[(short)127];

		public static InformationItem BuddhistMonkProfession => Instance[(short)128];

		public static InformationItem WineTasterProfession => Instance[(short)129];

		public static InformationItem AristocratProfession => Instance[(short)130];

		public static InformationItem BeggarProfession => Instance[(short)131];

		public static InformationItem CivilianProfession => Instance[(short)132];

		public static InformationItem TravelerProfession => Instance[(short)133];

		public static InformationItem TravelingBuddhistMonkProfession => Instance[(short)134];

		public static InformationItem DoctorProfession => Instance[(short)135];

		public static InformationItem TravelingTaoistMonkProfession => Instance[(short)136];

		public static InformationItem CapitalistProfession => Instance[(short)137];

		public static InformationItem TeaTasterProfession => Instance[(short)138];

		public static InformationItem DukeProfession => Instance[(short)139];

		public static InformationItem SwordTombMonvMonk => Instance[(short)140];

		public static InformationItem SwordTomDayueYaochangMonk => Instance[(short)141];

		public static InformationItem SwordTombJiuhanMonk => Instance[(short)142];

		public static InformationItem SwordTombJinHuangerMonk => Instance[(short)143];

		public static InformationItem SwordTombYiYihouMonk => Instance[(short)144];

		public static InformationItem SwordTombWeiQiMonk => Instance[(short)145];

		public static InformationItem SwordTombYixiangMonk => Instance[(short)146];

		public static InformationItem SwordTombXuefengMonk => Instance[(short)147];

		public static InformationItem SwordTombShuFangMonk => Instance[(short)148];

		public static InformationItem XiangshuProfession => Instance[(short)149];
	}

	public static Information Instance = new Information();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "InfoIds", "Type", "TransformId", "TemplateId", "BaseGainRate", "ExtraGainRate" };

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
		_dataArray.Add(new InformationItem(0, new short[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(1, new short[9] { 9, 10, 11, 12, 13, 14, 15, 16, 17 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(2, new short[9] { 18, 19, 20, 21, 22, 23, 24, 25, 26 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(3, new short[9] { 27, 28, 29, 30, 31, 32, 33, 34, 35 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(4, new short[9] { 36, 37, 38, 39, 40, 41, 42, 43, 44 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(5, new short[9] { 45, 46, 47, 48, 49, 50, 51, 52, 53 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(6, new short[9] { 54, 55, 56, 57, 58, 59, 60, 61, 62 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(7, new short[9] { 63, 64, 65, 66, 67, 68, 69, 70, 71 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(8, new short[9] { 72, 73, 74, 75, 76, 77, 78, 79, 80 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(9, new short[9] { 81, 82, 83, 84, 85, 86, 87, 88, 89 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(10, new short[9] { 90, 91, 92, 93, 94, 95, 96, 97, 98 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(11, new short[9] { 99, 100, 101, 102, 103, 104, 105, 106, 107 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(12, new short[9] { 108, 109, 110, 111, 112, 113, 114, 115, 116 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(13, new short[9] { 117, 118, 119, 120, 121, 122, 123, 124, 125 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(14, new short[9] { 126, 127, 128, 129, 130, 131, 132, 133, 134 }, isGeneral: true, 0, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 75, new short[3] { 50, 10, 0 }, new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(15, new short[9] { 135, 136, 137, 138, 139, 140, 141, 142, 143 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(16, new short[9] { 144, 145, 146, 147, 148, 149, 150, 151, 152 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(17, new short[9] { 153, 154, 155, 156, 157, 158, 159, 160, 161 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(18, new short[9] { 162, 163, 164, 165, 166, 167, 168, 169, 170 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(19, new short[9] { 171, 172, 173, 174, 175, 176, 177, 178, 179 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(20, new short[9] { 180, 181, 182, 183, 184, 185, 186, 187, 188 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(21, new short[9] { 189, 190, 191, 192, 193, 194, 195, 196, 197 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(22, new short[9] { 198, 199, 200, 201, 202, 203, 204, 205, 206 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(23, new short[9] { 207, 208, 209, 210, 211, 212, 213, 214, 215 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(24, new short[9] { 216, 217, 218, 219, 220, 221, 222, 223, 224 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(25, new short[9] { 225, 226, 227, 228, 229, 230, 231, 232, 233 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(26, new short[9] { 234, 235, 236, 237, 238, 239, 240, 241, 242 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(27, new short[9] { 243, 244, 245, 246, 247, 248, 249, 250, 251 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(28, new short[9] { 252, 253, 254, 255, 256, 257, 258, 259, 260 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(29, new short[9] { 261, 262, 263, 264, 265, 266, 267, 268, 269 }, isGeneral: true, 1, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(30, new short[9] { 270, 271, 272, 273, 274, 275, 276, 277, 278 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(31, new short[9] { 279, 280, 281, 282, 283, 284, 285, 286, 287 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(32, new short[9] { 288, 289, 290, 291, 292, 293, 294, 295, 296 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(33, new short[9] { 297, 298, 299, 300, 301, 302, 303, 304, 305 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(34, new short[9] { 306, 307, 308, 309, 310, 311, 312, 313, 314 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(35, new short[9] { 315, 316, 317, 318, 319, 320, 321, 322, 323 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(36, new short[9] { 324, 325, 326, 327, 328, 329, 330, 331, 332 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(37, new short[9] { 333, 334, 335, 336, 337, 338, 339, 340, 341 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(38, new short[9] { 342, 343, 344, 345, 346, 347, 348, 349, 350 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(39, new short[9] { 351, 352, 353, 354, 355, 356, 357, 358, 359 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(40, new short[9] { 360, 361, 362, 363, 364, 365, 366, 367, 368 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(41, new short[9] { 369, 370, 371, 372, 373, 374, 375, 376, 377 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(42, new short[9] { 378, 379, 380, 381, 382, 383, 384, 385, 386 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(43, new short[9] { 387, 388, 389, 390, 391, 392, 393, 394, 395 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(44, new short[9] { 396, 397, 398, 399, 400, 401, 402, 403, 404 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(45, new short[9] { 405, 406, 407, 408, 409, 410, 411, 412, 413 }, isGeneral: true, 2, new sbyte[9] { 100, 100, 100, 100, 100, 100, 100, 100, 100 }, new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(46, new short[9] { 414, 415, 416, 417, 418, 419, 420, 421, 422 }, isGeneral: true, 3, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(47, new short[9] { 423, 424, 425, 426, 427, 428, 429, 430, 431 }, isGeneral: true, 3, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(48, new short[9] { 432, 433, 434, 435, 436, 437, 438, 439, 440 }, isGeneral: true, 3, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(49, new short[9] { 441, 442, 443, 444, 445, 446, 447, 448, 449 }, isGeneral: true, 3, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(50, new short[9] { 450, 451, 452, 453, 454, 455, 456, 457, 458 }, isGeneral: true, 3, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(51, new short[9] { 459, 460, 461, 462, 463, 464, 465, 466, 467 }, isGeneral: true, 3, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(52, new short[9] { 468, 469, 470, 471, 472, 473, 474, 475, 476 }, isGeneral: true, 3, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(53, new short[9] { 477, 478, 479, 480, 481, 482, 483, 484, 485 }, isGeneral: true, 3, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(54, new short[9] { 486, 487, 488, 489, 490, 491, 492, 493, 494 }, isGeneral: true, 3, new sbyte[9] { 40, 40, 40, 30, 20, 10, 0, 0, 0 }, new sbyte[9] { 40, 40, 40, 40, 40, 40, 40, 40, 40 }, 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: true, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(55, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 495 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(56, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 496 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(57, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 497 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(58, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 498 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(59, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 499 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new InformationItem(60, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 500 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(61, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 501 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(62, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 502 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(63, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 503 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(64, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 504 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(65, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 505 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(66, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 506 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(67, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 507 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(68, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 508 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(69, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 511 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(70, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 512 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(71, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 513 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(72, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 514 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(73, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 515 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(74, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 516 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(75, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 517 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(76, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 518 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(77, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 519 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(78, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 509 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(79, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 510 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(80, new short[9] { -1, -1, -1, -1, 520, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, 98, isNeedShowLevel: false, new short[3], 4, 1));
		_dataArray.Add(new InformationItem(81, new short[9] { -1, -1, -1, -1, 521, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, 99, isNeedShowLevel: false, new short[3], 4, 1));
		_dataArray.Add(new InformationItem(82, new short[9] { -1, -1, -1, -1, 522, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, 100, isNeedShowLevel: false, new short[3], 4, 1));
		_dataArray.Add(new InformationItem(83, new short[9] { -1, -1, -1, -1, 523, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, 101, isNeedShowLevel: false, new short[3], 4, 1));
		_dataArray.Add(new InformationItem(84, new short[9] { -1, -1, -1, -1, 524, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, 102, isNeedShowLevel: false, new short[3], 4, 1));
		_dataArray.Add(new InformationItem(85, new short[9] { -1, -1, -1, -1, 525, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, 103, isNeedShowLevel: false, new short[3], 4, 1));
		_dataArray.Add(new InformationItem(86, new short[9] { -1, -1, -1, -1, 526, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, 104, isNeedShowLevel: false, new short[3], 4, 1));
		_dataArray.Add(new InformationItem(87, new short[9] { -1, -1, -1, -1, 527, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, 105, isNeedShowLevel: false, new short[3], 4, 1));
		_dataArray.Add(new InformationItem(88, new short[9] { -1, -1, -1, -1, 528, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, 106, isNeedShowLevel: false, new short[3], 4, 1));
		_dataArray.Add(new InformationItem(89, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 529 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, 98, isNeedShowLevel: false, new short[3], 8, 3));
		_dataArray.Add(new InformationItem(90, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 530 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, 99, isNeedShowLevel: false, new short[3], 8, 3));
		_dataArray.Add(new InformationItem(91, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 531 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, 100, isNeedShowLevel: false, new short[3], 8, 3));
		_dataArray.Add(new InformationItem(92, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 532 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, 101, isNeedShowLevel: false, new short[3], 8, 3));
		_dataArray.Add(new InformationItem(93, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 533 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, 102, isNeedShowLevel: false, new short[3], 8, 3));
		_dataArray.Add(new InformationItem(94, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 534 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, 103, isNeedShowLevel: false, new short[3], 8, 3));
		_dataArray.Add(new InformationItem(95, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 535 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, 104, isNeedShowLevel: false, new short[3], 8, 3));
		_dataArray.Add(new InformationItem(96, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 536 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, 105, isNeedShowLevel: false, new short[3], 8, 3));
		_dataArray.Add(new InformationItem(97, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 537 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, 106, isNeedShowLevel: false, new short[3], 8, 3));
		_dataArray.Add(new InformationItem(98, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 538 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(99, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 539 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(100, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 540 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(101, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 541 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(102, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 542 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(103, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 543 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(104, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 544 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(105, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 545 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(106, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 546 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 100, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(107, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 548 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(108, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 547 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(109, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 550 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(110, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 549 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(111, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 551 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, 98, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(112, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 552 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, 99, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(113, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 553 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, 100, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(114, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 554 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, 101, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(115, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 555 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, 102, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(116, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 556 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, 103, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(117, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 557 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, 104, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(118, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 558 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, 105, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(119, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 559 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 300, 100, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, 106, isNeedShowLevel: false, new short[3], 8, 1));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new InformationItem(120, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 561 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3] { 50, 5, 0 }, new short[3], new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(121, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 560 }, isGeneral: false, 1, new sbyte[9], new sbyte[9], 1, usedCountWithMax: true, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3] { 50, 5, 0 }, new short[3] { 25, 5, 0 }, 0, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(122, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 562 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(123, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 563 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(124, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 564 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(125, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 565 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(126, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 566 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(127, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 567 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(128, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 568 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(129, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 569 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(130, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 570 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(131, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 571 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(132, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 572 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(133, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 573 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(134, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 574 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(135, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 575 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(136, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 576 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(137, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 577 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(138, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 578 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(139, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 579 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 0, -1, isNeedShowLevel: false, new short[3] { 50, 5, 0 }, 8, 1));
		_dataArray.Add(new InformationItem(140, new short[9] { -1, -1, -1, -1, 580, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(141, new short[9] { -1, -1, -1, -1, 581, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(142, new short[9] { -1, -1, -1, -1, 582, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(143, new short[9] { -1, -1, -1, -1, 583, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(144, new short[9] { -1, -1, -1, -1, 584, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(145, new short[9] { -1, -1, -1, -1, 585, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(146, new short[9] { -1, -1, -1, -1, 586, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(147, new short[9] { -1, -1, -1, -1, 587, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(148, new short[9] { -1, -1, -1, -1, 588, -1, -1, -1, -1 }, isGeneral: false, 5, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, -1, isNeedShowLevel: false, new short[3], 8, 1));
		_dataArray.Add(new InformationItem(149, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, 589 }, isGeneral: false, 6, new sbyte[9], new sbyte[9], 1, usedCountWithMax: false, new short[3] { 450, 150, 0 }, 0, new short[3], new short[3], new short[3], new short[3], 200, -1, isNeedShowLevel: false, new short[3], 8, 1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<InformationItem>(150);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
