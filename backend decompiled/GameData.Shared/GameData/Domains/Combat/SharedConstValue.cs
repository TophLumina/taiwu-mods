using System.Collections.Generic;
using Config;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 需要与表现模块共享的常量集合
/// </summary>
public class SharedConstValue
{
	/// <summary>
	/// 战败所需必死标记数
	/// </summary>
	public static readonly byte DefeatNeedDieMarkCount = 6;

	/// <summary>
	/// 最小攻击范围
	/// </summary>
	public const short MinAttackRange = 20;

	/// <summary>
	/// 最大攻击范围
	/// </summary>
	public const short MaxAttackRange = 120;

	/// <summary>
	/// 最大装备武器数
	/// </summary>
	public const sbyte MaxWeaponSlots = 3;

	/// <summary>
	/// 最多武器数量（包括随机应变武器）
	/// </summary>
	public const byte MaxWeaponCount = 7;

	/// <summary>
	/// 喉声武器索引
	/// </summary>
	public const int WeaponIndexVoice = 6;

	/// <summary>
	/// 队友数量上限
	/// </summary>
	public const sbyte MaxTeammateCount = 3;

	/// <summary>
	/// 位置非法值
	/// </summary>
	public const int InvalidPosition = int.MinValue;

	/// <summary>
	/// 攻击前靠近动作
	/// </summary>
	public const string AttackForwardAni = "M_003_attack";

	/// <summary>
	/// 攻击前远离动作
	/// </summary>
	public const string AttackBackwardAni = "M_004_attack";

	/// <summary>
	/// 武器默认CD总进度值
	/// </summary>
	public const short WeaponDefaultCdFrame = 30000;

	/// <summary>
	/// 队友出场起始位置偏移
	/// </summary>
	public const int TeammateAppearPosOffset = -1500;

	/// <summary>
	/// 队友出场动画帧数
	/// </summary>
	public const sbyte TeammateEnterAniFrame = 34;

	/// <summary>
	/// 队友离场动画帧数
	/// </summary>
	public const sbyte TeammateExitAniFrame = 48;

	/// <summary>
	/// 坐骑动物离场动画帧数
	/// </summary>
	public const sbyte CarrierAnimalExitAniFrame = 24;

	/// <summary>
	/// 普攻或功法表现位置变化时间（秒）
	/// </summary>
	public const float DisplayDistanceTime = 0.1f;

	/// <summary>
	/// 换人等待时间（秒）
	/// </summary>
	public const float ChangeCharacterWaitTime = 1.5f;

	/// <summary>
	/// 最多蓄式数量
	/// </summary>
	public const byte MaxTrickCount = 9;

	/// <summary>
	/// 伤势自动治愈总进度值
	/// </summary>
	public const short InjuryAutoHealTotalProgress = 900;

	/// <summary>
	/// 子弹时间中的时间比例
	/// </summary>
	public const float BulletTimeTimeScale = 0.2f;

	/// <summary>
	/// 快捷使用物品的槽位数量
	/// </summary>
	public const int QuickUseItemMaxSlotCount = 9;

	/// <summary>
	/// 可施展相枢功法的剑柄对应的BossId
	/// </summary>
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

	/// <summary>
	/// 角色ID对应动物Id的缓存
	/// </summary>
	private static Dictionary<short, sbyte> _charId2AnimalIdCache;

	/// <summary>
	/// 地形子类对应山人技能3特效名
	/// </summary>
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

	/// <summary>
	/// 动物代步对应特效名
	/// </summary>
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
		[85] = "Animal.Loong.Carrier.Chiwen"
	};

	/// <summary>
	/// 所有可生铸的装备槽位
	/// </summary>
	public static readonly IReadOnlyList<sbyte> AllRawCreateSlots = new sbyte[10] { 0, 1, 2, 3, 5, 6, 7, 8, 9, 10 };

	/// <summary>
	/// 角色ID对应动物Id
	/// </summary>
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

	/// <summary>
	/// 初始化角色ID对应动物Id缓存表
	/// </summary>
	public static void InitializeCharId2AnimalIdCache()
	{
		if (_charId2AnimalIdCache == null)
		{
			_charId2AnimalIdCache = CreateCharId2AnimalIdDictionary();
		}
	}
}
