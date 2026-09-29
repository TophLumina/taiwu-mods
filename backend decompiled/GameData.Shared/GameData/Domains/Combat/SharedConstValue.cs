using System.Collections.Generic;
using Config;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public class SharedConstValue
{
	public static readonly byte DefeatNeedDieMarkCount = 6;

	public const short MinAttackRange = 20;

	public const short MaxAttackRange = 120;

	public const sbyte MaxWeaponSlots = 3;

	public const byte MaxWeaponCount = 7;

	public const int WeaponIndexVoice = 6;

	public const sbyte MaxTeammateCount = 3;

	public const int InvalidPosition = int.MinValue;

	public const string AttackForwardAni = "M_003_attack";

	public const string AttackBackwardAni = "M_004_attack";

	public const short WeaponDefaultCdFrame = 30000;

	public const int TeammateAppearPosOffset = -1500;

	public const sbyte TeammateEnterAniFrame = 34;

	public const sbyte TeammateExitAniFrame = 48;

	public const sbyte CarrierAnimalExitAniFrame = 24;

	public const float DisplayDistanceTime = 0.1f;

	public const float ChangeCharacterWaitTime = 1.5f;

	public const byte MaxTrickCount = 9;

	public const short InjuryAutoHealTotalProgress = 900;

	public const float BulletTimeTimeScale = 0.2f;

	public const int QuickUseItemMaxSlotCount = 9;

	public static readonly Dictionary<short, sbyte> SwordFragment2BossId = new Dictionary<short, sbyte>
	{
		[229] = 0,
		[230] = 1,
		[231] = 2,
		[232] = 3,
		[233] = 4,
		[234] = 5,
		[235] = 6,
		[236] = 7,
		[237] = 8
	};

	private static Dictionary<short, sbyte> _charId2AnimalIdCache;

	public static readonly Dictionary<EMapBlockSubType, string> MapBlockSubType2SavageEffect = new Dictionary<EMapBlockSubType, string>
	{
		[EMapBlockSubType.Mountain] = "Profession.Savage.LingJueDing",
		[EMapBlockSubType.BigMountain] = "Profession.Savage.LingJueDing",
		[EMapBlockSubType.Canyon] = "Profession.Savage.YiXianTian",
		[EMapBlockSubType.BigCanyon] = "Profession.Savage.YiXianTian",
		[EMapBlockSubType.Hill] = "Profession.Savage.JiuZheJing",
		[EMapBlockSubType.BigHill] = "Profession.Savage.JiuZheJing",
		[EMapBlockSubType.Field] = "Profession.Savage.CangMangYe",
		[EMapBlockSubType.BigField] = "Profession.Savage.CangMangYe",
		[EMapBlockSubType.Woodland] = "Profession.Savage.LianShanCui",
		[EMapBlockSubType.BigWoodland] = "Profession.Savage.LianShanCui",
		[EMapBlockSubType.RiverBeach] = "Profession.Savage.KongXingJian",
		[EMapBlockSubType.BigRiverBeach] = "Profession.Savage.KongXingJian",
		[EMapBlockSubType.Lake] = "Profession.Savage.YanBoDang",
		[EMapBlockSubType.Jungle] = "Profession.Savage.SenLuoZhang",
		[EMapBlockSubType.Cave] = "Profession.Savage.YanXueMing",
		[EMapBlockSubType.Swamp] = "Profession.Savage.YouTanChen",
		[EMapBlockSubType.TaoYuan] = "Profession.Savage.TaoHuaYuan",
		[EMapBlockSubType.Valley] = "Profession.Savage.KongXingJian"
	};

	public static readonly Dictionary<short, string> AnimalCarrier2Effect = new Dictionary<short, string>
	{
		[27] = "Animal.Beast.Carrier.Monkey0",
		[28] = "Animal.Beast.Carrier.Eagle0",
		[29] = "Animal.Beast.Carrier.Pig0",
		[30] = "Animal.Beast.Carrier.Bear0",
		[31] = "Animal.Beast.Carrier.Bull0",
		[32] = "Animal.Beast.Carrier.Snake0",
		[33] = "Animal.Beast.Carrier.Jaguar0",
		[34] = "Animal.Beast.Carrier.Lion0",
		[35] = "Animal.Beast.Carrier.Tiger0",
		[36] = "Animal.Beast.Carrier.Monkey1",
		[37] = "Animal.Beast.Carrier.Eagle1",
		[38] = "Animal.Beast.Carrier.Pig1",
		[39] = "Animal.Beast.Carrier.Bear1",
		[40] = "Animal.Beast.Carrier.Bull1",
		[41] = "Animal.Beast.Carrier.Snake1",
		[42] = "Animal.Beast.Carrier.Jaguar1",
		[43] = "Animal.Beast.Carrier.Lion1",
		[44] = "Animal.Beast.Carrier.Tiger1",
		[77] = "Animal.Loong.Carrier.Qiuniu",
		[78] = "Animal.Loong.Carrier.Yazi",
		[79] = "Animal.Loong.Carrier.Chaofeng",
		[80] = "Animal.Loong.Carrier.Pulao",
		[81] = "Animal.Loong.Carrier.Suanni",
		[82] = "Animal.Loong.Carrier.Baxia",
		[83] = "Animal.Loong.Carrier.Bian",
		[84] = "Animal.Loong.Carrier.Fuxi",
		[85] = "Animal.Loong.Carrier.Chiwen",
		[86] = "Animal.Loong.Carrier.LoongMetal",
		[87] = "Animal.Loong.Carrier.LoongWater",
		[88] = "Animal.Loong.Carrier.LoongWood",
		[89] = "Animal.Loong.Carrier.LoongFire",
		[90] = "Animal.Loong.Carrier.LoongEarth"
	};

	public static readonly IReadOnlyList<sbyte> AllRawCreateSlots = new sbyte[10] { 0, 1, 2, 3, 5, 6, 7, 8, 9, 10 };

	public static IReadOnlyDictionary<short, sbyte> CharId2AnimalId => _charId2AnimalIdCache ?? (_charId2AnimalIdCache = CreateCharId2AnimalIdDictionary());

	private static Dictionary<short, sbyte> CreateCharId2AnimalIdDictionary()
	{
		Dictionary<short, sbyte> data = new Dictionary<short, sbyte>();
		foreach (AnimalItem animal in (IEnumerable<AnimalItem>)Animal.Instance)
		{
			short[] characterIdList = animal.CharacterIdList;
			foreach (short charTemplateId in characterIdList)
			{
				if (data.ContainsKey(charTemplateId))
				{
					AdaptableLog.Warning($"charId -> animalId already exist charId={charTemplateId}->{data[charTemplateId]}, animalId={animal.TemplateId} will be ignored");
				}
				else
				{
					data.Add(charTemplateId, animal.TemplateId);
				}
			}
		}
		return data;
	}

	public static void InitializeCharId2AnimalIdCache()
	{
		if (_charId2AnimalIdCache == null)
		{
			_charId2AnimalIdCache = CreateCharId2AnimalIdDictionary();
		}
	}
}
