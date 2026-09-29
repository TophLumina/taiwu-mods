using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterTableElement : ConfigData<CharacterTableElementItem, short>
{
	public static class DefKey
	{
		public const short Avatar = 0;

		public const short Empty = 1;

		public const short PhysiologicalAge = 2;

		public const short Health = 3;

		public const short Injury = 4;

		public const short Charm = 5;

		public const short Behavior = 6;

		public const short Happiness = 7;

		public const short Favor = 8;

		public const short Preexistence = 9;

		public const short Fame = 10;

		public const short Strength = 11;

		public const short Dexterity = 12;

		public const short Concentration = 13;

		public const short Vitality = 14;

		public const short Energy = 15;

		public const short Intelligence = 16;

		public const short PenetrateOfOuter = 17;

		public const short PenetrateOfInner = 18;

		public const short PenetrateResistOfOuter = 19;

		public const short PenetrateResistOfInner = 20;

		public const short HitRateStrength = 21;

		public const short HitRateTechnique = 22;

		public const short HitRateSpeed = 23;

		public const short HitRateMind = 24;

		public const short AvoidRateStrength = 25;

		public const short AvoidRateTechnique = 26;

		public const short AvoidRateSpeed = 27;

		public const short AvoidRateMind = 28;

		public const short DisorderOfQi = 29;

		public const short Music = 30;

		public const short Chess = 31;

		public const short Poem = 32;

		public const short Painting = 33;

		public const short Math = 34;

		public const short Appraisal = 35;

		public const short Forging = 36;

		public const short Woodworking = 37;

		public const short Medicine = 38;

		public const short Toxicology = 39;

		public const short Weaving = 40;

		public const short JadeLifeSkill = 41;

		public const short Taoism = 42;

		public const short Buddhism = 43;

		public const short Cooking = 44;

		public const short Eclectic = 45;

		public const short LifeSkillGrowth = 46;

		public const short Neigong = 47;

		public const short Posing = 48;

		public const short Stunt = 49;

		public const short FistAndPalm = 50;

		public const short Finger = 51;

		public const short Leg = 52;

		public const short Throw = 53;

		public const short Sword = 54;

		public const short Blade = 55;

		public const short Polearm = 56;

		public const short Special = 57;

		public const short Whip = 58;

		public const short ControllableShot = 59;

		public const short CombatMusic = 60;

		public const short CombatSkillGrowth = 61;

		public const short Calm = 62;

		public const short Clever = 63;

		public const short Enthusiastic = 64;

		public const short Brave = 65;

		public const short Firm = 66;

		public const short Lucky = 67;

		public const short Perceptive = 68;

		public const short Food = 69;

		public const short Wood = 70;

		public const short Metal = 71;

		public const short JadeResource = 72;

		public const short Fabric = 73;

		public const short Herb = 74;

		public const short Money = 75;

		public const short Authority = 76;

		public const short Weight = 77;

		public const short CurrLoad = 78;

		public const short MaxLoad = 79;

		public const short Kidnap = 80;

		public const short AttackMedal = 81;

		public const short DefenceMedal = 82;

		public const short WisdomMedal = 83;

		public const short Command0 = 84;

		public const short Command1 = 85;

		public const short Command2 = 86;

		public const short WantedLegendaryBookDesc = 87;

		public const short WantedLegendaryBookIcon = 88;

		public const short OwnedLegendaryBookDesc = 89;

		public const short OwnedLegendaryBookIcon = 90;

		public const short OrganizationName = 91;

		public const short Identity = 92;

		public const short ConsummateLevel = 93;

		public const short Location1 = 94;

		public const short LegendaryBookFeature = 95;

		public const short Gender = 96;

		public const short ActualAge = 97;

		public const short LegendaryBookOwnerState = 98;

		public const short WorkStatus = 99;

		public const short WorkBuilding = 100;

		public const short WorkPost = 101;

		public const short Potential = 102;

		public const short Location2 = 103;

		public const short RelationToTaiwu = 104;

		public const short RelationFromTaiwu = 105;

		public const short SameFaction = 106;

		public const short InfluencePower = 107;

		public const short TakeItemTime = 108;

		public const short TakeItemAmount = 109;
	}

	public static class DefValue
	{
		public static CharacterTableElementItem Avatar => Instance[(short)0];

		public static CharacterTableElementItem Empty => Instance[(short)1];

		public static CharacterTableElementItem PhysiologicalAge => Instance[(short)2];

		public static CharacterTableElementItem Health => Instance[(short)3];

		public static CharacterTableElementItem Injury => Instance[(short)4];

		public static CharacterTableElementItem Charm => Instance[(short)5];

		public static CharacterTableElementItem Behavior => Instance[(short)6];

		public static CharacterTableElementItem Happiness => Instance[(short)7];

		public static CharacterTableElementItem Favor => Instance[(short)8];

		public static CharacterTableElementItem Preexistence => Instance[(short)9];

		public static CharacterTableElementItem Fame => Instance[(short)10];

		public static CharacterTableElementItem Strength => Instance[(short)11];

		public static CharacterTableElementItem Dexterity => Instance[(short)12];

		public static CharacterTableElementItem Concentration => Instance[(short)13];

		public static CharacterTableElementItem Vitality => Instance[(short)14];

		public static CharacterTableElementItem Energy => Instance[(short)15];

		public static CharacterTableElementItem Intelligence => Instance[(short)16];

		public static CharacterTableElementItem PenetrateOfOuter => Instance[(short)17];

		public static CharacterTableElementItem PenetrateOfInner => Instance[(short)18];

		public static CharacterTableElementItem PenetrateResistOfOuter => Instance[(short)19];

		public static CharacterTableElementItem PenetrateResistOfInner => Instance[(short)20];

		public static CharacterTableElementItem HitRateStrength => Instance[(short)21];

		public static CharacterTableElementItem HitRateTechnique => Instance[(short)22];

		public static CharacterTableElementItem HitRateSpeed => Instance[(short)23];

		public static CharacterTableElementItem HitRateMind => Instance[(short)24];

		public static CharacterTableElementItem AvoidRateStrength => Instance[(short)25];

		public static CharacterTableElementItem AvoidRateTechnique => Instance[(short)26];

		public static CharacterTableElementItem AvoidRateSpeed => Instance[(short)27];

		public static CharacterTableElementItem AvoidRateMind => Instance[(short)28];

		public static CharacterTableElementItem DisorderOfQi => Instance[(short)29];

		public static CharacterTableElementItem Music => Instance[(short)30];

		public static CharacterTableElementItem Chess => Instance[(short)31];

		public static CharacterTableElementItem Poem => Instance[(short)32];

		public static CharacterTableElementItem Painting => Instance[(short)33];

		public static CharacterTableElementItem Math => Instance[(short)34];

		public static CharacterTableElementItem Appraisal => Instance[(short)35];

		public static CharacterTableElementItem Forging => Instance[(short)36];

		public static CharacterTableElementItem Woodworking => Instance[(short)37];

		public static CharacterTableElementItem Medicine => Instance[(short)38];

		public static CharacterTableElementItem Toxicology => Instance[(short)39];

		public static CharacterTableElementItem Weaving => Instance[(short)40];

		public static CharacterTableElementItem JadeLifeSkill => Instance[(short)41];

		public static CharacterTableElementItem Taoism => Instance[(short)42];

		public static CharacterTableElementItem Buddhism => Instance[(short)43];

		public static CharacterTableElementItem Cooking => Instance[(short)44];

		public static CharacterTableElementItem Eclectic => Instance[(short)45];

		public static CharacterTableElementItem LifeSkillGrowth => Instance[(short)46];

		public static CharacterTableElementItem Neigong => Instance[(short)47];

		public static CharacterTableElementItem Posing => Instance[(short)48];

		public static CharacterTableElementItem Stunt => Instance[(short)49];

		public static CharacterTableElementItem FistAndPalm => Instance[(short)50];

		public static CharacterTableElementItem Finger => Instance[(short)51];

		public static CharacterTableElementItem Leg => Instance[(short)52];

		public static CharacterTableElementItem Throw => Instance[(short)53];

		public static CharacterTableElementItem Sword => Instance[(short)54];

		public static CharacterTableElementItem Blade => Instance[(short)55];

		public static CharacterTableElementItem Polearm => Instance[(short)56];

		public static CharacterTableElementItem Special => Instance[(short)57];

		public static CharacterTableElementItem Whip => Instance[(short)58];

		public static CharacterTableElementItem ControllableShot => Instance[(short)59];

		public static CharacterTableElementItem CombatMusic => Instance[(short)60];

		public static CharacterTableElementItem CombatSkillGrowth => Instance[(short)61];

		public static CharacterTableElementItem Calm => Instance[(short)62];

		public static CharacterTableElementItem Clever => Instance[(short)63];

		public static CharacterTableElementItem Enthusiastic => Instance[(short)64];

		public static CharacterTableElementItem Brave => Instance[(short)65];

		public static CharacterTableElementItem Firm => Instance[(short)66];

		public static CharacterTableElementItem Lucky => Instance[(short)67];

		public static CharacterTableElementItem Perceptive => Instance[(short)68];

		public static CharacterTableElementItem Food => Instance[(short)69];

		public static CharacterTableElementItem Wood => Instance[(short)70];

		public static CharacterTableElementItem Metal => Instance[(short)71];

		public static CharacterTableElementItem JadeResource => Instance[(short)72];

		public static CharacterTableElementItem Fabric => Instance[(short)73];

		public static CharacterTableElementItem Herb => Instance[(short)74];

		public static CharacterTableElementItem Money => Instance[(short)75];

		public static CharacterTableElementItem Authority => Instance[(short)76];

		public static CharacterTableElementItem Weight => Instance[(short)77];

		public static CharacterTableElementItem CurrLoad => Instance[(short)78];

		public static CharacterTableElementItem MaxLoad => Instance[(short)79];

		public static CharacterTableElementItem Kidnap => Instance[(short)80];

		public static CharacterTableElementItem AttackMedal => Instance[(short)81];

		public static CharacterTableElementItem DefenceMedal => Instance[(short)82];

		public static CharacterTableElementItem WisdomMedal => Instance[(short)83];

		public static CharacterTableElementItem Command0 => Instance[(short)84];

		public static CharacterTableElementItem Command1 => Instance[(short)85];

		public static CharacterTableElementItem Command2 => Instance[(short)86];

		public static CharacterTableElementItem WantedLegendaryBookDesc => Instance[(short)87];

		public static CharacterTableElementItem WantedLegendaryBookIcon => Instance[(short)88];

		public static CharacterTableElementItem OwnedLegendaryBookDesc => Instance[(short)89];

		public static CharacterTableElementItem OwnedLegendaryBookIcon => Instance[(short)90];

		public static CharacterTableElementItem OrganizationName => Instance[(short)91];

		public static CharacterTableElementItem Identity => Instance[(short)92];

		public static CharacterTableElementItem ConsummateLevel => Instance[(short)93];

		public static CharacterTableElementItem Location1 => Instance[(short)94];

		public static CharacterTableElementItem LegendaryBookFeature => Instance[(short)95];

		public static CharacterTableElementItem Gender => Instance[(short)96];

		public static CharacterTableElementItem ActualAge => Instance[(short)97];

		public static CharacterTableElementItem LegendaryBookOwnerState => Instance[(short)98];

		public static CharacterTableElementItem WorkStatus => Instance[(short)99];

		public static CharacterTableElementItem WorkBuilding => Instance[(short)100];

		public static CharacterTableElementItem WorkPost => Instance[(short)101];

		public static CharacterTableElementItem Potential => Instance[(short)102];

		public static CharacterTableElementItem Location2 => Instance[(short)103];

		public static CharacterTableElementItem RelationToTaiwu => Instance[(short)104];

		public static CharacterTableElementItem RelationFromTaiwu => Instance[(short)105];

		public static CharacterTableElementItem SameFaction => Instance[(short)106];

		public static CharacterTableElementItem InfluencePower => Instance[(short)107];

		public static CharacterTableElementItem TakeItemTime => Instance[(short)108];

		public static CharacterTableElementItem TakeItemAmount => Instance[(short)109];
	}

	public static CharacterTableElement Instance = new CharacterTableElement();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId" };

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
		_dataArray.Add(new CharacterTableElementItem(0, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_0"), ECharacterTableElementType.Avatar, canSort: true, canHighlight: false, needAsync: true, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(1, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_1"), ECharacterTableElementType.Empty, canSort: false, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(2, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_2"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(3, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_3"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(4, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_4"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(5, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_5"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(6, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_6"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(7, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_7"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(8, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_8"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(9, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_9"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(10, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_10"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(11, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_11"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(12, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_12"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(13, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_13"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(14, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_14"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(15, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_15"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(16, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_16"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(17, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_17"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(18, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_18"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(19, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_19"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(20, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_20"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(21, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_21"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(22, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_22"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(23, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_23"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(24, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_24"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(25, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_25"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(26, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_26"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(27, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_27"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(28, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_28"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(29, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_29"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(30, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_30"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(31, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_31"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(32, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_32"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(33, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_33"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(34, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_34"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(35, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_35"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(36, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_36"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(37, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_37"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(38, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_38"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(39, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_39"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(40, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_40"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(41, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_41"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(42, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_42"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(43, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_43"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(44, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_44"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(45, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_45"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(46, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_46"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(47, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_47"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(48, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_48"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(49, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_49"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(50, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_50"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(51, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_51"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(52, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_52"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(53, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_53"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(54, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_54"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(55, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_55"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(56, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_56"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(57, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_57"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(58, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_58"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(59, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_59"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CharacterTableElementItem(60, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_60"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(61, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_61"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(62, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_62"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(63, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_63"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(64, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_64"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(65, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_65"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(66, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_66"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(67, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_67"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(68, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_68"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(69, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_69"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(70, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_70"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(71, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_71"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(72, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_72"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(73, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_73"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(74, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_74"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(75, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_75"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(76, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_76"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(77, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_77"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(78, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_78"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(79, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_79"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(80, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_80"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(81, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_81"), ECharacterTableElementType.TextWithIcon, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(82, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_82"), ECharacterTableElementType.TextWithIcon, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(83, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_83"), ECharacterTableElementType.TextWithIcon, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(84, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_84"), ECharacterTableElementType.Command, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(85, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_85"), ECharacterTableElementType.Command, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(86, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_86"), ECharacterTableElementType.Command, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(87, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_87"), ECharacterTableElementType.TextWithIcon, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(88, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_88"), ECharacterTableElementType.TextWithIcon, canSort: false, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(89, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_89"), ECharacterTableElementType.TextWithIcon, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(90, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_90"), ECharacterTableElementType.TextWithIcon, canSort: false, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(91, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_91"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(92, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_92"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(93, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_93"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(94, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_94"), ECharacterTableElementType.TextWithSprite, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(95, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_95"), ECharacterTableElementType.Feature, canSort: false, canHighlight: false, needAsync: true, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(96, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_96"), ECharacterTableElementType.Text, canSort: false, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(97, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_97"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(98, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_98"), ECharacterTableElementType.Text, canSort: false, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(99, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_99"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(100, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_100"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(101, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_101"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(102, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_102"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(103, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_103"), ECharacterTableElementType.TextWithSprite, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(104, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_104"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(105, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_105"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(106, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_106"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(107, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_107"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(108, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_108"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(109, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_109"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CharacterTableElementItem>(110);
		CreateItems0();
		CreateItems1();
	}
}
