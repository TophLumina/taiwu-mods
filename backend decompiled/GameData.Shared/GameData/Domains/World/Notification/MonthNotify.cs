using System;
using System.Collections.Generic;
using GameData.DLC.FiveLoong;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.World.Notification;

/// <summary>
/// 过月月报单月数据
/// </summary>
/// <summary>
/// 对于引用类型字段, 构造函数中可以不创建对象, 保留默认的 null 值.
/// 在进行反序列化时, 允许所有引用类型字段都为 null.
/// 但是在序列化时, 要求所有是定长集合的引用字段都已经被创建, 且长度与定义一致. 集合中的引用类型元素若也为定长, 则也必须被创建; 变长的则可以为 null.
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class MonthNotify : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Date = 0;

		public const ushort MonthlyNotificationCollection = 1;

		public const ushort CharacterNames = 2;

		public const ushort Avatars = 3;

		public const ushort JiaoLoongNames = 4;

		public const ushort PrevInjuries = 5;

		public const ushort CurrInjuries = 6;

		public const ushort PrevPoison = 7;

		public const ushort CurrPoison = 8;

		public const ushort PrevHappiness = 9;

		public const ushort CurrHappiness = 10;

		public const ushort PrevHealth = 11;

		public const ushort CurrHealth = 12;

		public const ushort PrevQiDisorder = 13;

		public const ushort CurrQiDisorder = 14;

		public const ushort PrevAttributes = 15;

		public const ushort CurrAttributes = 16;

		public const ushort PrevMaxAttributes = 17;

		public const ushort CurrMaxAttributes = 18;

		public const ushort Eaten = 19;

		public const ushort LoopingCombatSkillTemplateId = 20;

		public const ushort PrevNeili = 21;

		public const ushort CurrNeili = 22;

		public const ushort PrevMaxNeili = 23;

		public const ushort CurrMaxNeili = 24;

		public const ushort PrevNeiliPercent = 25;

		public const ushort CurrNeiliPercent = 26;

		public const ushort NeiliTransferType = 27;

		public const ushort NeiliDstType = 28;

		public const ushort NeiliTransferAmount = 29;

		public const ushort PrevExtraNeiliAllocationProgress = 30;

		public const ushort CurrExtraNeiliAllocationProgress = 31;

		public const ushort ReadingBook = 32;

		public const ushort ReferenceBooks = 33;

		public const ushort ReadingEvent = 34;

		public const ushort BookMaxDurability = 35;

		public const ushort BookPrevDurability = 36;

		public const ushort BookCurrDurability = 37;

		public const ushort BookRefSpeed = 38;

		public const ushort CharacterScore = 39;

		public const ushort PrevFavor = 40;

		public const ushort CurrFavor = 41;

		public const ushort TaiwuRelations = 42;

		public const ushort LoopingObtainedNeili = 43;

		public const ushort LoopingEvent = 44;

		public const ushort LoopingTotalObtainableNeili = 45;

		public const ushort CurrMaxLeftHealth = 46;

		public const ushort PrevMaxLeftHealth = 47;

		public const ushort ActiveLoopingProgress = 48;

		public const ushort ActiveReadingProgress = 49;

		public const ushort PrevNeiliType = 50;

		public const ushort CurrNeiliType = 51;

		public const ushort ReadingProgress = 52;

		public const ushort PrevReadingProgress = 53;

		public const ushort CurrReadingProgress = 54;

		public const ushort ReadingBookState = 55;

		public const ushort ReadingBookType = 56;

		public const ushort RemovedRelation = 57;

		public const ushort AddedRelation = 58;

		public const ushort RemovedPassiveRelation = 59;

		public const ushort AddedPassiveRelation = 60;

		public const ushort TaiwuId = 61;

		public const ushort SecretInformationSnapshots = 62;

		public const ushort Information = 63;

		public const ushort RoleCount = 64;

		public const ushort SafetyMax = 65;

		public const ushort CultureCurr = 66;

		public const ushort SafetyCurr = 67;

		public const ushort CultureMax = 68;

		public const ushort WarehouseCurr = 69;

		public const ushort WarehouseMax = 70;

		public const ushort StoneCurr = 71;

		public const ushort StoneMax = 72;

		public const ushort HouseCapacity = 73;

		public const ushort DispatchCount = 74;

		public const ushort GainMoney = 75;

		public const ushort IdleCount = 76;

		public const ushort YouthCount = 77;

		public const ushort VillagerCount = 78;

		public const ushort PawnShopItem = 79;

		public const ushort GainItem = 80;

		public const ushort GainVillager = 81;

		public const ushort GainAuthority = 82;

		public const ushort ResourceDelta = 83;

		public const ushort Resources = 84;

		public const ushort BuildingCount = 85;

		public const ushort ManagingCount = 86;

		public const ushort BuildingCapacity = 87;

		public const ushort VillagerRoleRecords = 88;

		public const ushort Count = 89;

		public static readonly string[] FieldId2FieldName = new string[89]
		{
			"Date", "MonthlyNotificationCollection", "CharacterNames", "Avatars", "JiaoLoongNames", "PrevInjuries", "CurrInjuries", "PrevPoison", "CurrPoison", "PrevHappiness",
			"CurrHappiness", "PrevHealth", "CurrHealth", "PrevQiDisorder", "CurrQiDisorder", "PrevAttributes", "CurrAttributes", "PrevMaxAttributes", "CurrMaxAttributes", "Eaten",
			"LoopingCombatSkillTemplateId", "PrevNeili", "CurrNeili", "PrevMaxNeili", "CurrMaxNeili", "PrevNeiliPercent", "CurrNeiliPercent", "NeiliTransferType", "NeiliDstType", "NeiliTransferAmount",
			"PrevExtraNeiliAllocationProgress", "CurrExtraNeiliAllocationProgress", "ReadingBook", "ReferenceBooks", "ReadingEvent", "BookMaxDurability", "BookPrevDurability", "BookCurrDurability", "BookRefSpeed", "CharacterScore",
			"PrevFavor", "CurrFavor", "TaiwuRelations", "LoopingObtainedNeili", "LoopingEvent", "LoopingTotalObtainableNeili", "CurrMaxLeftHealth", "PrevMaxLeftHealth", "ActiveLoopingProgress", "ActiveReadingProgress",
			"PrevNeiliType", "CurrNeiliType", "ReadingProgress", "PrevReadingProgress", "CurrReadingProgress", "ReadingBookState", "ReadingBookType", "RemovedRelation", "AddedRelation", "RemovedPassiveRelation",
			"AddedPassiveRelation", "TaiwuId", "SecretInformationSnapshots", "Information", "RoleCount", "SafetyMax", "CultureCurr", "SafetyCurr", "CultureMax", "WarehouseCurr",
			"WarehouseMax", "StoneCurr", "StoneMax", "HouseCapacity", "DispatchCount", "GainMoney", "IdleCount", "YouthCount", "VillagerCount", "PawnShopItem",
			"GainItem", "GainVillager", "GainAuthority", "ResourceDelta", "Resources", "BuildingCount", "ManagingCount", "BuildingCapacity", "VillagerRoleRecords"
		};
	}

	/// <summary>
	/// 日期
	/// </summary>
	[SerializableGameDataField]
	public int Date;

	/// <summary>
	/// 保存这份月报时的太吾Id
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuId;

	/// <summary>
	/// 过月通知
	/// </summary>
	[SerializableGameDataField]
	public MonthlyNotificationCollection MonthlyNotificationCollection;

	/// <summary>
	/// 关联的角色名信息
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, NameAndLifeRelatedData> CharacterNames = new Dictionary<int, NameAndLifeRelatedData>();

	/// <summary>
	/// 关联角色显示数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, AvatarRelatedData> Avatars = new Dictionary<int, AvatarRelatedData>();

	/// <summary>
	/// 关联的蛟、龙名字相关显示数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, JiaoLoongNameRelatedData> JiaoLoongNames = new Dictionary<int, JiaoLoongNameRelatedData>();

	[SerializableGameDataField]
	public Injuries PrevInjuries;

	[SerializableGameDataField]
	public Injuries CurrInjuries;

	[SerializableGameDataField]
	public PoisonInts PrevPoison;

	[SerializableGameDataField]
	public PoisonInts CurrPoison;

	[SerializableGameDataField]
	public sbyte PrevHappiness;

	[SerializableGameDataField]
	public sbyte CurrHappiness;

	[SerializableGameDataField]
	public short PrevHealth;

	[SerializableGameDataField]
	public short CurrHealth;

	[SerializableGameDataField]
	public short PrevMaxLeftHealth;

	[SerializableGameDataField]
	public short CurrMaxLeftHealth;

	[SerializableGameDataField]
	public short PrevQiDisorder;

	[SerializableGameDataField]
	public short CurrQiDisorder;

	[SerializableGameDataField]
	public MainAttributes PrevAttributes;

	[SerializableGameDataField]
	public MainAttributes CurrAttributes;

	[SerializableGameDataField]
	public MainAttributes PrevMaxAttributes;

	[SerializableGameDataField]
	public MainAttributes CurrMaxAttributes;

	[SerializableGameDataField]
	public EatingItems Eaten;

	[SerializableGameDataField]
	public short LoopingCombatSkillTemplateId;

	[SerializableGameDataField]
	public short LoopingObtainedNeili;

	[SerializableGameDataField]
	public short LoopingTotalObtainableNeili;

	[SerializableGameDataField]
	public bool LoopingEvent;

	[SerializableGameDataField]
	public short ActiveLoopingProgress;

	[SerializableGameDataField]
	public int PrevNeili;

	[SerializableGameDataField]
	public int CurrNeili;

	[SerializableGameDataField]
	public int PrevMaxNeili;

	[SerializableGameDataField]
	public int CurrMaxNeili;

	[SerializableGameDataField]
	public NeiliProportionOfFiveElements PrevNeiliPercent;

	[SerializableGameDataField]
	public NeiliProportionOfFiveElements CurrNeiliPercent;

	[SerializableGameDataField]
	public sbyte NeiliTransferType;

	[SerializableGameDataField]
	public sbyte NeiliDstType;

	[SerializableGameDataField]
	public int NeiliTransferAmount;

	[SerializableGameDataField]
	public sbyte PrevNeiliType;

	[SerializableGameDataField]
	public sbyte CurrNeiliType;

	[SerializableGameDataField]
	public int[] PrevExtraNeiliAllocationProgress = new int[4];

	[SerializableGameDataField]
	public int[] CurrExtraNeiliAllocationProgress = new int[4];

	[SerializableGameDataField]
	public ItemKey ReadingBook;

	[SerializableGameDataField]
	public List<ItemKey> ReferenceBooks = new List<ItemKey>();

	[SerializableGameDataField]
	public bool ReadingEvent;

	[SerializableGameDataField]
	public short ReadingProgress;

	[SerializableGameDataField]
	public short ActiveReadingProgress;

	[SerializableGameDataField]
	public sbyte[] PrevReadingProgress;

	[SerializableGameDataField]
	public sbyte[] CurrReadingProgress;

	[SerializableGameDataField]
	public sbyte[] ReadingBookState;

	[SerializableGameDataField]
	public sbyte[] ReadingBookType;

	[SerializableGameDataField]
	public Dictionary<ItemKey, short> BookMaxDurability = new Dictionary<ItemKey, short>();

	[SerializableGameDataField]
	public Dictionary<ItemKey, short> BookPrevDurability = new Dictionary<ItemKey, short>();

	[SerializableGameDataField]
	public Dictionary<ItemKey, short> BookCurrDurability = new Dictionary<ItemKey, short>();

	[SerializableGameDataField]
	public Dictionary<ItemKey, int> BookRefSpeed = new Dictionary<ItemKey, int>();

	[SerializableGameDataField]
	public Dictionary<int, short> PrevFavor = new Dictionary<int, short>();

	[SerializableGameDataField]
	public Dictionary<int, short> CurrFavor = new Dictionary<int, short>();

	/// <summary>
	/// 关系的变化
	/// (角色A的Id, 角色B的Id) -&gt; RelationDisplayType.TemplateId的位运算
	/// </summary>
	[Obsolete]
	[SerializableGameDataField]
	public Dictionary<IntPair, int> RemovedRelation = new Dictionary<IntPair, int>();

	[Obsolete]
	[SerializableGameDataField]
	public Dictionary<IntPair, int> AddedRelation = new Dictionary<IntPair, int>();

	[Obsolete]
	[SerializableGameDataField]
	public Dictionary<IntPair, int> RemovedPassiveRelation = new Dictionary<IntPair, int>();

	[Obsolete]
	[SerializableGameDataField]
	public Dictionary<IntPair, int> AddedPassiveRelation = new Dictionary<IntPair, int>();

	/// <summary>
	/// 见闻
	/// </summary>
	[SerializableGameDataField]
	public List<NormalInformation> Information = new List<NormalInformation>();

	/// <summary>
	/// 与太吾之间的关系快照，秘闻专用
	/// 角色Id -&gt; 得分最高的关系RelationDisplayType.TemplateId
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, short> TaiwuRelations = new Dictionary<int, short>();

	/// <summary>
	/// 角色在秘闻排序中的得分
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, int> CharacterScore = new Dictionary<int, int>();

	/// <summary>
	/// 秘闻快照
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, SecretInformationSnapshot> SecretInformationSnapshots = new Dictionary<int, SecretInformationSnapshot>();

	/// <summary>
	/// 资源
	/// </summary>
	[SerializableGameDataField]
	public ResourceInts Resources = new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int));

	/// <summary>
	/// 资源增长
	/// </summary>
	[SerializableGameDataField]
	public int[] ResourceDelta = new int[8];

	/// <summary>
	/// 可收获银钱
	/// </summary>
	[SerializableGameDataField]
	public int GainMoney;

	/// <summary>
	/// 可收获威望
	/// </summary>
	[SerializableGameDataField]
	public int GainAuthority;

	/// <summary>
	/// 可招揽人才
	/// </summary>
	[SerializableGameDataField]
	public int GainVillager;

	/// <summary>
	/// 可收获物品
	/// </summary>
	[SerializableGameDataField]
	public int GainItem;

	/// <summary>
	/// 可购买物品
	/// </summary>
	[SerializableGameDataField]
	public int PawnShopItem;

	/// <summary>
	/// 人口
	/// </summary>
	[SerializableGameDataField]
	public int VillagerCount;

	/// <summary>
	/// 幼年
	/// </summary>
	[SerializableGameDataField]
	public int YouthCount;

	/// <summary>
	/// 空闲
	/// </summary>
	[SerializableGameDataField]
	public int IdleCount;

	/// <summary>
	/// 经营
	/// </summary>
	[SerializableGameDataField]
	public int ManagingCount;

	/// <summary>
	/// 派遣
	/// </summary>
	[SerializableGameDataField]
	public int DispatchCount;

	/// <summary>
	/// 身份
	/// </summary>
	[SerializableGameDataField]
	public int RoleCount;

	/// <summary>
	/// 居所
	/// </summary>
	[SerializableGameDataField]
	public int HouseCapacity;

	/// <summary>
	/// 石屋
	/// </summary>
	[SerializableGameDataField]
	public int StoneMax;

	/// <summary>
	/// 石屋
	/// </summary>
	[SerializableGameDataField]
	public int StoneCurr;

	/// <summary>
	/// 负重上限
	/// </summary>
	[SerializableGameDataField]
	public int WarehouseMax;

	/// <summary>
	/// 仓库负重
	/// </summary>
	[SerializableGameDataField]
	public int WarehouseCurr;

	/// <summary>
	/// 文化
	/// </summary>
	[SerializableGameDataField]
	public int CultureMax;

	/// <summary>
	/// 文化
	/// </summary>
	[SerializableGameDataField]
	public int CultureCurr;

	/// <summary>
	/// 安定
	/// </summary>
	[SerializableGameDataField]
	public int SafetyMax;

	/// <summary>
	/// 安定
	/// </summary>
	[SerializableGameDataField]
	public int SafetyCurr;

	/// <summary>
	/// 建设空间
	/// </summary>
	[SerializableGameDataField]
	public int BuildingCount;

	/// <summary>
	/// 建设空间
	/// </summary>
	[SerializableGameDataField]
	public int BuildingCapacity;

	/// <summary>
	/// 村民身份相关记录
	/// VillagerRoleActionRecordTemplateId -&gt; Value
	/// </summary>
	[Obsolete]
	[SerializableGameDataField]
	public Dictionary<short, int> VillagerRoleRecords = new Dictionary<short, int>();

	public MonthNotify()
	{
		Eaten.Initialize();
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 424;
		totalSize = ((MonthlyNotificationCollection == null) ? (totalSize + 2) : (totalSize + (2 + MonthlyNotificationCollection.GetSerializedSize())));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CharacterNames);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(Avatars);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(JiaoLoongNames);
		totalSize = ((PrevExtraNeiliAllocationProgress == null) ? (totalSize + 2) : (totalSize + (2 + 4 * PrevExtraNeiliAllocationProgress.Length)));
		totalSize = ((CurrExtraNeiliAllocationProgress == null) ? (totalSize + 2) : (totalSize + (2 + 4 * CurrExtraNeiliAllocationProgress.Length)));
		totalSize = ((ReferenceBooks == null) ? (totalSize + 2) : (totalSize + (2 + 8 * ReferenceBooks.Count)));
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(BookMaxDurability);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(BookPrevDurability);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(BookCurrDurability);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(BookRefSpeed);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CharacterScore);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(PrevFavor);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CurrFavor);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(TaiwuRelations);
		totalSize = ((PrevReadingProgress == null) ? (totalSize + 2) : (totalSize + (2 + PrevReadingProgress.Length)));
		totalSize = ((CurrReadingProgress == null) ? (totalSize + 2) : (totalSize + (2 + CurrReadingProgress.Length)));
		totalSize = ((ReadingBookState == null) ? (totalSize + 2) : (totalSize + (2 + ReadingBookState.Length)));
		totalSize = ((ReadingBookType == null) ? (totalSize + 2) : (totalSize + (2 + ReadingBookType.Length)));
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(RemovedRelation);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(AddedRelation);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(RemovedPassiveRelation);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(AddedPassiveRelation);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SecretInformationSnapshots);
		totalSize = ((Information == null) ? (totalSize + 2) : (totalSize + (2 + 3 * Information.Count)));
		totalSize = ((ResourceDelta == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ResourceDelta.Length)));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(VillagerRoleRecords);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 89;
		pCurrData += 2;
		*(int*)pCurrData = Date;
		pCurrData += 4;
		if (MonthlyNotificationCollection != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = MonthlyNotificationCollection.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CharacterNames);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref Avatars);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref JiaoLoongNames);
		pCurrData += PrevInjuries.Serialize(pCurrData);
		pCurrData += CurrInjuries.Serialize(pCurrData);
		pCurrData += PrevPoison.Serialize(pCurrData);
		pCurrData += CurrPoison.Serialize(pCurrData);
		*pCurrData = (byte)PrevHappiness;
		pCurrData++;
		*pCurrData = (byte)CurrHappiness;
		pCurrData++;
		*(short*)pCurrData = PrevHealth;
		pCurrData += 2;
		*(short*)pCurrData = CurrHealth;
		pCurrData += 2;
		*(short*)pCurrData = PrevQiDisorder;
		pCurrData += 2;
		*(short*)pCurrData = CurrQiDisorder;
		pCurrData += 2;
		pCurrData += PrevAttributes.Serialize(pCurrData);
		pCurrData += CurrAttributes.Serialize(pCurrData);
		pCurrData += PrevMaxAttributes.Serialize(pCurrData);
		pCurrData += CurrMaxAttributes.Serialize(pCurrData);
		pCurrData += Eaten.Serialize(pCurrData);
		*(short*)pCurrData = LoopingCombatSkillTemplateId;
		pCurrData += 2;
		*(int*)pCurrData = PrevNeili;
		pCurrData += 4;
		*(int*)pCurrData = CurrNeili;
		pCurrData += 4;
		*(int*)pCurrData = PrevMaxNeili;
		pCurrData += 4;
		*(int*)pCurrData = CurrMaxNeili;
		pCurrData += 4;
		pCurrData += PrevNeiliPercent.Serialize(pCurrData);
		pCurrData += CurrNeiliPercent.Serialize(pCurrData);
		*pCurrData = (byte)NeiliTransferType;
		pCurrData++;
		*pCurrData = (byte)NeiliDstType;
		pCurrData++;
		*(int*)pCurrData = NeiliTransferAmount;
		pCurrData += 4;
		if (PrevExtraNeiliAllocationProgress != null)
		{
			int elementsCount = PrevExtraNeiliAllocationProgress.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = PrevExtraNeiliAllocationProgress[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CurrExtraNeiliAllocationProgress != null)
		{
			int elementsCount2 = CurrExtraNeiliAllocationProgress.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = CurrExtraNeiliAllocationProgress[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += ReadingBook.Serialize(pCurrData);
		if (ReferenceBooks != null)
		{
			int elementsCount3 = ReferenceBooks.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData += ReferenceBooks[k].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (ReadingEvent ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref BookMaxDurability);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref BookPrevDurability);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref BookCurrDurability);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref BookRefSpeed);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref CharacterScore);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref PrevFavor);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref CurrFavor);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref TaiwuRelations);
		*(short*)pCurrData = LoopingObtainedNeili;
		pCurrData += 2;
		*pCurrData = (LoopingEvent ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = LoopingTotalObtainableNeili;
		pCurrData += 2;
		*(short*)pCurrData = CurrMaxLeftHealth;
		pCurrData += 2;
		*(short*)pCurrData = PrevMaxLeftHealth;
		pCurrData += 2;
		*(short*)pCurrData = ActiveLoopingProgress;
		pCurrData += 2;
		*(short*)pCurrData = ActiveReadingProgress;
		pCurrData += 2;
		*pCurrData = (byte)PrevNeiliType;
		pCurrData++;
		*pCurrData = (byte)CurrNeiliType;
		pCurrData++;
		*(short*)pCurrData = ReadingProgress;
		pCurrData += 2;
		if (PrevReadingProgress != null)
		{
			int elementsCount4 = PrevReadingProgress.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData[l] = (byte)PrevReadingProgress[l];
			}
			pCurrData += elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CurrReadingProgress != null)
		{
			int elementsCount5 = CurrReadingProgress.Length;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				pCurrData[m] = (byte)CurrReadingProgress[m];
			}
			pCurrData += elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ReadingBookState != null)
		{
			int elementsCount6 = ReadingBookState.Length;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				pCurrData[n] = (byte)ReadingBookState[n];
			}
			pCurrData += elementsCount6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ReadingBookType != null)
		{
			int elementsCount7 = ReadingBookType.Length;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				pCurrData[num] = (byte)ReadingBookType[num];
			}
			pCurrData += elementsCount7;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref RemovedRelation);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref AddedRelation);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref RemovedPassiveRelation);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref AddedPassiveRelation);
		*(int*)pCurrData = TaiwuId;
		pCurrData += 4;
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SecretInformationSnapshots);
		if (Information != null)
		{
			int elementsCount8 = Information.Count;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				pCurrData += Information[num2].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = RoleCount;
		pCurrData += 4;
		*(int*)pCurrData = SafetyMax;
		pCurrData += 4;
		*(int*)pCurrData = CultureCurr;
		pCurrData += 4;
		*(int*)pCurrData = SafetyCurr;
		pCurrData += 4;
		*(int*)pCurrData = CultureMax;
		pCurrData += 4;
		*(int*)pCurrData = WarehouseCurr;
		pCurrData += 4;
		*(int*)pCurrData = WarehouseMax;
		pCurrData += 4;
		*(int*)pCurrData = StoneCurr;
		pCurrData += 4;
		*(int*)pCurrData = StoneMax;
		pCurrData += 4;
		*(int*)pCurrData = HouseCapacity;
		pCurrData += 4;
		*(int*)pCurrData = DispatchCount;
		pCurrData += 4;
		*(int*)pCurrData = GainMoney;
		pCurrData += 4;
		*(int*)pCurrData = IdleCount;
		pCurrData += 4;
		*(int*)pCurrData = YouthCount;
		pCurrData += 4;
		*(int*)pCurrData = VillagerCount;
		pCurrData += 4;
		*(int*)pCurrData = PawnShopItem;
		pCurrData += 4;
		*(int*)pCurrData = GainItem;
		pCurrData += 4;
		*(int*)pCurrData = GainVillager;
		pCurrData += 4;
		*(int*)pCurrData = GainAuthority;
		pCurrData += 4;
		if (ResourceDelta != null)
		{
			int elementsCount9 = ResourceDelta.Length;
			Tester.Assert(elementsCount9 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount9;
			pCurrData += 2;
			for (int num3 = 0; num3 < elementsCount9; num3++)
			{
				((int*)pCurrData)[num3] = ResourceDelta[num3];
			}
			pCurrData += 4 * elementsCount9;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += Resources.Serialize(pCurrData);
		*(int*)pCurrData = BuildingCount;
		pCurrData += 4;
		*(int*)pCurrData = ManagingCount;
		pCurrData += 4;
		*(int*)pCurrData = BuildingCapacity;
		pCurrData += 4;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref VillagerRoleRecords);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			Date = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			ushort num = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num > 0)
			{
				if (MonthlyNotificationCollection == null)
				{
					MonthlyNotificationCollection = new MonthlyNotificationCollection();
				}
				pCurrData += MonthlyNotificationCollection.Deserialize(pCurrData);
			}
			else
			{
				MonthlyNotificationCollection = null;
			}
		}
		if (fieldCount > 2)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CharacterNames);
		}
		if (fieldCount > 3)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref Avatars);
		}
		if (fieldCount > 4)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref JiaoLoongNames);
		}
		if (fieldCount > 5)
		{
			pCurrData += PrevInjuries.Deserialize(pCurrData);
		}
		if (fieldCount > 6)
		{
			pCurrData += CurrInjuries.Deserialize(pCurrData);
		}
		if (fieldCount > 7)
		{
			pCurrData += PrevPoison.Deserialize(pCurrData);
		}
		if (fieldCount > 8)
		{
			pCurrData += CurrPoison.Deserialize(pCurrData);
		}
		if (fieldCount > 9)
		{
			PrevHappiness = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 10)
		{
			CurrHappiness = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 11)
		{
			PrevHealth = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 12)
		{
			CurrHealth = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 13)
		{
			PrevQiDisorder = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 14)
		{
			CurrQiDisorder = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 15)
		{
			pCurrData += PrevAttributes.Deserialize(pCurrData);
		}
		if (fieldCount > 16)
		{
			pCurrData += CurrAttributes.Deserialize(pCurrData);
		}
		if (fieldCount > 17)
		{
			pCurrData += PrevMaxAttributes.Deserialize(pCurrData);
		}
		if (fieldCount > 18)
		{
			pCurrData += CurrMaxAttributes.Deserialize(pCurrData);
		}
		if (fieldCount > 19)
		{
			pCurrData += Eaten.Deserialize(pCurrData);
		}
		if (fieldCount > 20)
		{
			LoopingCombatSkillTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 21)
		{
			PrevNeili = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 22)
		{
			CurrNeili = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 23)
		{
			PrevMaxNeili = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 24)
		{
			CurrMaxNeili = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 25)
		{
			pCurrData += PrevNeiliPercent.Deserialize(pCurrData);
		}
		if (fieldCount > 26)
		{
			pCurrData += CurrNeiliPercent.Deserialize(pCurrData);
		}
		if (fieldCount > 27)
		{
			NeiliTransferType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 28)
		{
			NeiliDstType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 29)
		{
			NeiliTransferAmount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 30)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (PrevExtraNeiliAllocationProgress == null || PrevExtraNeiliAllocationProgress.Length != elementsCount)
				{
					PrevExtraNeiliAllocationProgress = new int[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					PrevExtraNeiliAllocationProgress[i] = ((int*)pCurrData)[i];
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				PrevExtraNeiliAllocationProgress = null;
			}
		}
		if (fieldCount > 31)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (CurrExtraNeiliAllocationProgress == null || CurrExtraNeiliAllocationProgress.Length != elementsCount2)
				{
					CurrExtraNeiliAllocationProgress = new int[elementsCount2];
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					CurrExtraNeiliAllocationProgress[j] = ((int*)pCurrData)[j];
				}
				pCurrData += 4 * elementsCount2;
			}
			else
			{
				CurrExtraNeiliAllocationProgress = null;
			}
		}
		if (fieldCount > 32)
		{
			pCurrData += ReadingBook.Deserialize(pCurrData);
		}
		if (fieldCount > 33)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (ReferenceBooks == null)
				{
					ReferenceBooks = new List<ItemKey>(elementsCount3);
				}
				else
				{
					ReferenceBooks.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					ItemKey element = default(ItemKey);
					pCurrData += element.Deserialize(pCurrData);
					ReferenceBooks.Add(element);
				}
			}
			else
			{
				ReferenceBooks?.Clear();
			}
		}
		if (fieldCount > 34)
		{
			ReadingEvent = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 35)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref BookMaxDurability);
		}
		if (fieldCount > 36)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref BookPrevDurability);
		}
		if (fieldCount > 37)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref BookCurrDurability);
		}
		if (fieldCount > 38)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref BookRefSpeed);
		}
		if (fieldCount > 39)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref CharacterScore);
		}
		if (fieldCount > 40)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref PrevFavor);
		}
		if (fieldCount > 41)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref CurrFavor);
		}
		if (fieldCount > 42)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref TaiwuRelations);
		}
		if (fieldCount > 43)
		{
			LoopingObtainedNeili = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 44)
		{
			LoopingEvent = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 45)
		{
			LoopingTotalObtainableNeili = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 46)
		{
			CurrMaxLeftHealth = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 47)
		{
			PrevMaxLeftHealth = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 48)
		{
			ActiveLoopingProgress = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 49)
		{
			ActiveReadingProgress = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 50)
		{
			PrevNeiliType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 51)
		{
			CurrNeiliType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 52)
		{
			ReadingProgress = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 53)
		{
			ushort elementsCount4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount4 > 0)
			{
				if (PrevReadingProgress == null || PrevReadingProgress.Length != elementsCount4)
				{
					PrevReadingProgress = new sbyte[elementsCount4];
				}
				for (int l = 0; l < elementsCount4; l++)
				{
					PrevReadingProgress[l] = (sbyte)pCurrData[l];
				}
				pCurrData += (int)elementsCount4;
			}
			else
			{
				PrevReadingProgress = null;
			}
		}
		if (fieldCount > 54)
		{
			ushort elementsCount5 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount5 > 0)
			{
				if (CurrReadingProgress == null || CurrReadingProgress.Length != elementsCount5)
				{
					CurrReadingProgress = new sbyte[elementsCount5];
				}
				for (int m = 0; m < elementsCount5; m++)
				{
					CurrReadingProgress[m] = (sbyte)pCurrData[m];
				}
				pCurrData += (int)elementsCount5;
			}
			else
			{
				CurrReadingProgress = null;
			}
		}
		if (fieldCount > 55)
		{
			ushort elementsCount6 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount6 > 0)
			{
				if (ReadingBookState == null || ReadingBookState.Length != elementsCount6)
				{
					ReadingBookState = new sbyte[elementsCount6];
				}
				for (int n = 0; n < elementsCount6; n++)
				{
					ReadingBookState[n] = (sbyte)pCurrData[n];
				}
				pCurrData += (int)elementsCount6;
			}
			else
			{
				ReadingBookState = null;
			}
		}
		if (fieldCount > 56)
		{
			ushort elementsCount7 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount7 > 0)
			{
				if (ReadingBookType == null || ReadingBookType.Length != elementsCount7)
				{
					ReadingBookType = new sbyte[elementsCount7];
				}
				for (int num2 = 0; num2 < elementsCount7; num2++)
				{
					ReadingBookType[num2] = (sbyte)pCurrData[num2];
				}
				pCurrData += (int)elementsCount7;
			}
			else
			{
				ReadingBookType = null;
			}
		}
		if (fieldCount > 57)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref RemovedRelation);
		}
		if (fieldCount > 58)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref AddedRelation);
		}
		if (fieldCount > 59)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref RemovedPassiveRelation);
		}
		if (fieldCount > 60)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref AddedPassiveRelation);
		}
		if (fieldCount > 61)
		{
			TaiwuId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 62)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SecretInformationSnapshots);
		}
		if (fieldCount > 63)
		{
			ushort elementsCount8 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount8 > 0)
			{
				if (Information == null)
				{
					Information = new List<NormalInformation>(elementsCount8);
				}
				else
				{
					Information.Clear();
				}
				for (int num3 = 0; num3 < elementsCount8; num3++)
				{
					NormalInformation element2 = default(NormalInformation);
					pCurrData += element2.Deserialize(pCurrData);
					Information.Add(element2);
				}
			}
			else
			{
				Information?.Clear();
			}
		}
		if (fieldCount > 64)
		{
			RoleCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 65)
		{
			SafetyMax = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 66)
		{
			CultureCurr = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 67)
		{
			SafetyCurr = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 68)
		{
			CultureMax = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 69)
		{
			WarehouseCurr = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 70)
		{
			WarehouseMax = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 71)
		{
			StoneCurr = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 72)
		{
			StoneMax = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 73)
		{
			HouseCapacity = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 74)
		{
			DispatchCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 75)
		{
			GainMoney = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 76)
		{
			IdleCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 77)
		{
			YouthCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 78)
		{
			VillagerCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 79)
		{
			PawnShopItem = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 80)
		{
			GainItem = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 81)
		{
			GainVillager = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 82)
		{
			GainAuthority = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 83)
		{
			ushort elementsCount9 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount9 > 0)
			{
				if (ResourceDelta == null || ResourceDelta.Length != elementsCount9)
				{
					ResourceDelta = new int[elementsCount9];
				}
				for (int num4 = 0; num4 < elementsCount9; num4++)
				{
					ResourceDelta[num4] = ((int*)pCurrData)[num4];
				}
				pCurrData += 4 * elementsCount9;
			}
			else
			{
				ResourceDelta = null;
			}
		}
		if (fieldCount > 84)
		{
			pCurrData += Resources.Deserialize(pCurrData);
		}
		if (fieldCount > 85)
		{
			BuildingCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 86)
		{
			ManagingCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 87)
		{
			BuildingCapacity = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 88)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref VillagerRoleRecords);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
