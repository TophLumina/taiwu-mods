using System;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 关押角色显示数据。用于关押界面获取所有显示所需数据，避免监听
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class KidnapCharDisplayDataForInteraction : ITradeableContent, ISerializableGameData
{
	[SerializableGameDataField]
	public ItemKey _key;

	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public short CharacterTemplateId;

	[SerializableGameDataField]
	public NameRelatedData NameData;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	[SerializableGameDataField]
	public OrganizationInfo OrganizationInfo;

	[SerializableGameDataField]
	public short CurrAge;

	[SerializableGameDataField]
	public short ActualAge;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public short MaxLeftHealth;

	[SerializableGameDataField]
	public sbyte DefeatMarkCount;

	[SerializableGameDataField]
	public short Charm;

	[SerializableGameDataField]
	public sbyte BehaviorType;

	[SerializableGameDataField]
	public sbyte Fame;

	[SerializableGameDataField]
	public sbyte Happiness;

	[SerializableGameDataField]
	public short FavorabilityToTaiwu;

	[SerializableGameDataField]
	public short PreexistenceCharCount;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public short PhysiologicalAge;

	[SerializableGameDataField]
	public short ClothDisplayId;

	[SerializableGameDataField]
	public bool FaceVisible;

	[SerializableGameDataField]
	public byte CreatingType;

	[SerializableGameDataField]
	public bool IsInteractedWithTaiwu;

	[SerializableGameDataField]
	public int KidnapBeginDate;

	[SerializableGameDataField]
	public int KidnapDuration;

	[SerializableGameDataField]
	public int TotalResistance;

	[SerializableGameDataField]
	public ItemKey RopeItemKey;

	[SerializableGameDataField]
	public int EscapeRate;

	[SerializableGameDataField]
	public int RopeEffect;

	[SerializableGameDataField]
	public int AlertFactor;

	private static readonly LocalObjectPool<Inventory> LocalObjectPool = new LocalObjectPool<Inventory>(1, 4);

	int ITradeableContent.AlertFactor => AlertFactor;

	/// <summary>
	/// 俘虏总是可交互
	/// </summary>
	public bool Interactable
	{
		get
		{
			return true;
		}
		set
		{
			if (!value)
			{
				AdaptableLog.Warning("Set Interactable for KidnapChar is not implement yet.", appendWarningMessage: true);
			}
		}
	}

	public int Amount
	{
		get
		{
			return 1;
		}
		set
		{
			if (value != 1)
			{
				AdaptableLog.Warning("Should not set Amount for KidnapChar", appendWarningMessage: true);
			}
		}
	}

	/// <summary>
	/// templateId为Misc的俘虏
	/// id为俘虏的CharacterId
	/// </summary>
	public ItemKey Key
	{
		get
		{
			return _key;
		}
		set
		{
			_key = value;
		}
	}

	public ItemKey RealKey => _key;

	public long Value
	{
		get
		{
			return (int)Math.Clamp(Wager.CharacterValue(Fame, Charm, Grade, AvatarRelatedData.AvatarData.Gender, AvatarRelatedData.DisplayAge), 0L, 2147483647L);
		}
		set
		{
		}
	}

	public sbyte Grade => NameData.OrgGrade;

	sbyte ITradeableContent.Gender => Gender;

	int ITradeableContent.CharacterId => CharacterId;

	OrganizationInfo ITradeableContent.OrganizationInfo => OrganizationInfo;

	NameRelatedData ITradeableContent.NameRelatedData => NameData;

	AvatarRelatedData ITradeableContent.AvatarRelatedData => AvatarRelatedData;

	Inventory ITradeableContent.GetAllInventoryFromPool()
	{
		return GetAllItemKeysFromPool();
	}

	/// <summary>
	/// 从对象池获取，必须归还
	/// </summary>
	/// <returns></returns>
	public static Inventory GetItemKeyListFromPool()
	{
		return LocalObjectPool.Get();
	}

	/// <summary>
	/// </summary>
	/// <returns></returns>
	public Inventory GetAllItemKeysFromPool()
	{
		Inventory itemKeyListFromPool = GetItemKeyListFromPool();
		itemKeyListFromPool.Items.Add(_key, Amount);
		return itemKeyListFromPool;
	}

	public ITradeableContent Clone(int amount = -1)
	{
		return new KidnapCharDisplayDataForInteraction(this);
	}

	public sbyte GetContentType()
	{
		return 1;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public KidnapCharDisplayDataForInteraction()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public KidnapCharDisplayDataForInteraction(KidnapCharDisplayDataForInteraction other)
	{
		_key = other._key;
		CharacterId = other.CharacterId;
		CharacterTemplateId = other.CharacterTemplateId;
		NameData = other.NameData;
		AvatarRelatedData = new AvatarRelatedData(other.AvatarRelatedData);
		OrganizationInfo = other.OrganizationInfo;
		CurrAge = other.CurrAge;
		ActualAge = other.ActualAge;
		Health = other.Health;
		MaxLeftHealth = other.MaxLeftHealth;
		DefeatMarkCount = other.DefeatMarkCount;
		Charm = other.Charm;
		BehaviorType = other.BehaviorType;
		Fame = other.Fame;
		Happiness = other.Happiness;
		FavorabilityToTaiwu = other.FavorabilityToTaiwu;
		PreexistenceCharCount = other.PreexistenceCharCount;
		Gender = other.Gender;
		PhysiologicalAge = other.PhysiologicalAge;
		ClothDisplayId = other.ClothDisplayId;
		FaceVisible = other.FaceVisible;
		CreatingType = other.CreatingType;
		IsInteractedWithTaiwu = other.IsInteractedWithTaiwu;
		KidnapBeginDate = other.KidnapBeginDate;
		KidnapDuration = other.KidnapDuration;
		TotalResistance = other.TotalResistance;
		RopeItemKey = other.RopeItemKey;
		EscapeRate = other.EscapeRate;
		RopeEffect = other.RopeEffect;
		AlertFactor = other.AlertFactor;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(KidnapCharDisplayDataForInteraction other)
	{
		_key = other._key;
		CharacterId = other.CharacterId;
		CharacterTemplateId = other.CharacterTemplateId;
		NameData = other.NameData;
		AvatarRelatedData = new AvatarRelatedData(other.AvatarRelatedData);
		OrganizationInfo = other.OrganizationInfo;
		CurrAge = other.CurrAge;
		ActualAge = other.ActualAge;
		Health = other.Health;
		MaxLeftHealth = other.MaxLeftHealth;
		DefeatMarkCount = other.DefeatMarkCount;
		Charm = other.Charm;
		BehaviorType = other.BehaviorType;
		Fame = other.Fame;
		Happiness = other.Happiness;
		FavorabilityToTaiwu = other.FavorabilityToTaiwu;
		PreexistenceCharCount = other.PreexistenceCharCount;
		Gender = other.Gender;
		PhysiologicalAge = other.PhysiologicalAge;
		ClothDisplayId = other.ClothDisplayId;
		FaceVisible = other.FaceVisible;
		CreatingType = other.CreatingType;
		IsInteractedWithTaiwu = other.IsInteractedWithTaiwu;
		KidnapBeginDate = other.KidnapBeginDate;
		KidnapDuration = other.KidnapDuration;
		TotalResistance = other.TotalResistance;
		RopeItemKey = other.RopeItemKey;
		EscapeRate = other.EscapeRate;
		RopeEffect = other.RopeEffect;
		AlertFactor = other.AlertFactor;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 112;
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
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
		pCurrData += _key.Serialize(pCurrData);
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*(short*)pCurrData = CharacterTemplateId;
		pCurrData += 2;
		pCurrData += NameData.Serialize(pCurrData);
		if (AvatarRelatedData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = AvatarRelatedData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += OrganizationInfo.Serialize(pCurrData);
		*(short*)pCurrData = CurrAge;
		pCurrData += 2;
		*(short*)pCurrData = ActualAge;
		pCurrData += 2;
		*(short*)pCurrData = Health;
		pCurrData += 2;
		*(short*)pCurrData = MaxLeftHealth;
		pCurrData += 2;
		*pCurrData = (byte)DefeatMarkCount;
		pCurrData++;
		*(short*)pCurrData = Charm;
		pCurrData += 2;
		*pCurrData = (byte)BehaviorType;
		pCurrData++;
		*pCurrData = (byte)Fame;
		pCurrData++;
		*pCurrData = (byte)Happiness;
		pCurrData++;
		*(short*)pCurrData = FavorabilityToTaiwu;
		pCurrData += 2;
		*(short*)pCurrData = PreexistenceCharCount;
		pCurrData += 2;
		*pCurrData = (byte)Gender;
		pCurrData++;
		*(short*)pCurrData = PhysiologicalAge;
		pCurrData += 2;
		*(short*)pCurrData = ClothDisplayId;
		pCurrData += 2;
		*pCurrData = (FaceVisible ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = CreatingType;
		pCurrData++;
		*pCurrData = (IsInteractedWithTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = KidnapBeginDate;
		pCurrData += 4;
		*(int*)pCurrData = KidnapDuration;
		pCurrData += 4;
		*(int*)pCurrData = TotalResistance;
		pCurrData += 4;
		pCurrData += RopeItemKey.Serialize(pCurrData);
		*(int*)pCurrData = EscapeRate;
		pCurrData += 4;
		*(int*)pCurrData = RopeEffect;
		pCurrData += 4;
		*(int*)pCurrData = AlertFactor;
		pCurrData += 4;
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
		pCurrData += _key.Deserialize(pCurrData);
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		CharacterTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += NameData.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (AvatarRelatedData == null)
			{
				AvatarRelatedData = new AvatarRelatedData();
			}
			pCurrData += AvatarRelatedData.Deserialize(pCurrData);
		}
		else
		{
			AvatarRelatedData = null;
		}
		pCurrData += OrganizationInfo.Deserialize(pCurrData);
		CurrAge = *(short*)pCurrData;
		pCurrData += 2;
		ActualAge = *(short*)pCurrData;
		pCurrData += 2;
		Health = *(short*)pCurrData;
		pCurrData += 2;
		MaxLeftHealth = *(short*)pCurrData;
		pCurrData += 2;
		DefeatMarkCount = (sbyte)(*pCurrData);
		pCurrData++;
		Charm = *(short*)pCurrData;
		pCurrData += 2;
		BehaviorType = (sbyte)(*pCurrData);
		pCurrData++;
		Fame = (sbyte)(*pCurrData);
		pCurrData++;
		Happiness = (sbyte)(*pCurrData);
		pCurrData++;
		FavorabilityToTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		PreexistenceCharCount = *(short*)pCurrData;
		pCurrData += 2;
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		PhysiologicalAge = *(short*)pCurrData;
		pCurrData += 2;
		ClothDisplayId = *(short*)pCurrData;
		pCurrData += 2;
		FaceVisible = *pCurrData != 0;
		pCurrData++;
		CreatingType = *pCurrData;
		pCurrData++;
		IsInteractedWithTaiwu = *pCurrData != 0;
		pCurrData++;
		KidnapBeginDate = *(int*)pCurrData;
		pCurrData += 4;
		KidnapDuration = *(int*)pCurrData;
		pCurrData += 4;
		TotalResistance = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += RopeItemKey.Deserialize(pCurrData);
		EscapeRate = *(int*)pCurrData;
		pCurrData += 4;
		RopeEffect = *(int*)pCurrData;
		pCurrData += 4;
		AlertFactor = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
