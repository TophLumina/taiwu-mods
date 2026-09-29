using System;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class KidnapCharDisplayData : ITradeableContent, ISerializableGameData
{
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
	public int Alertness;

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
	public MainAttributes MaxMainAttributes;

	[SerializableGameDataField]
	public OuterAndInnerInts Penetrations;

	[SerializableGameDataField]
	public OuterAndInnerInts PenetrationResists;

	[SerializableGameDataField]
	public HitOrAvoidInts HitValues;

	[SerializableGameDataField]
	public HitOrAvoidInts AvoidValues;

	[SerializableGameDataField]
	public short DisorderOfQi;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillQualifications;

	[SerializableGameDataField]
	public sbyte LifeSkillGrowthType;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillQualifications;

	[SerializableGameDataField]
	public sbyte CombatSkillGrowthType;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	[SerializableGameDataField]
	public Personalities Personalities;

	[SerializableGameDataField]
	public ResourceInts Resources;

	[SerializableGameDataField]
	public int CurrInventoryLoad;

	[SerializableGameDataField]
	public int MaxInventoryLoad;

	[SerializableGameDataField]
	public sbyte KidnapCount;

	[SerializableGameDataField]
	public int AttackMedal;

	[SerializableGameDataField]
	public int DefenceMedal;

	[SerializableGameDataField]
	public int WisdomMedal;

	[SerializableGameDataField]
	public SByteList Command;

	[SerializableGameDataField]
	public SByteList AdvancedCommand;

	[SerializableGameDataField]
	public sbyte ConsummateLevel;

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
	public bool CompletelyInfected;

	[SerializableGameDataField]
	public bool OwningBook;

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

	public ItemKey Key => ItemKey.Invalid;

	public ItemKey RealKey => ItemKey.Invalid;

	public long Value
	{
		get
		{
			return ValueImpl(Fame, Charm, Grade, AvatarRelatedData.AvatarData.Gender, AvatarRelatedData.DisplayAge);
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

	public static long ValueImpl(int fame, int charm, int grade, int gender, int age)
	{
		return Math.Clamp(Wager.CharacterValue(fame, charm, grade, gender, age), 0L, 2147483647L);
	}

	public ITradeableContent Clone(int amount = -1)
	{
		return new KidnapCharDisplayData(this);
	}

	public sbyte GetContentType()
	{
		return 1;
	}

	public KidnapCharDisplayData()
	{
	}

	public KidnapCharDisplayData(KidnapCharDisplayData other)
	{
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
		Alertness = other.Alertness;
		PreexistenceCharCount = other.PreexistenceCharCount;
		Gender = other.Gender;
		PhysiologicalAge = other.PhysiologicalAge;
		ClothDisplayId = other.ClothDisplayId;
		FaceVisible = other.FaceVisible;
		CreatingType = other.CreatingType;
		IsInteractedWithTaiwu = other.IsInteractedWithTaiwu;
		MaxMainAttributes = other.MaxMainAttributes;
		Penetrations = other.Penetrations;
		PenetrationResists = other.PenetrationResists;
		HitValues = other.HitValues;
		AvoidValues = other.AvoidValues;
		DisorderOfQi = other.DisorderOfQi;
		LifeSkillQualifications = other.LifeSkillQualifications;
		LifeSkillGrowthType = other.LifeSkillGrowthType;
		CombatSkillQualifications = other.CombatSkillQualifications;
		CombatSkillGrowthType = other.CombatSkillGrowthType;
		LifeSkillAttainments = other.LifeSkillAttainments;
		CombatSkillAttainments = other.CombatSkillAttainments;
		Personalities = other.Personalities;
		Resources = other.Resources;
		CurrInventoryLoad = other.CurrInventoryLoad;
		MaxInventoryLoad = other.MaxInventoryLoad;
		KidnapCount = other.KidnapCount;
		AttackMedal = other.AttackMedal;
		DefenceMedal = other.DefenceMedal;
		WisdomMedal = other.WisdomMedal;
		Command = new SByteList(other.Command);
		AdvancedCommand = new SByteList(other.AdvancedCommand);
		ConsummateLevel = other.ConsummateLevel;
		KidnapBeginDate = other.KidnapBeginDate;
		KidnapDuration = other.KidnapDuration;
		TotalResistance = other.TotalResistance;
		RopeItemKey = other.RopeItemKey;
		EscapeRate = other.EscapeRate;
		RopeEffect = other.RopeEffect;
		CompletelyInfected = other.CompletelyInfected;
		OwningBook = other.OwningBook;
	}

	public void Assign(KidnapCharDisplayData other)
	{
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
		Alertness = other.Alertness;
		PreexistenceCharCount = other.PreexistenceCharCount;
		Gender = other.Gender;
		PhysiologicalAge = other.PhysiologicalAge;
		ClothDisplayId = other.ClothDisplayId;
		FaceVisible = other.FaceVisible;
		CreatingType = other.CreatingType;
		IsInteractedWithTaiwu = other.IsInteractedWithTaiwu;
		MaxMainAttributes = other.MaxMainAttributes;
		Penetrations = other.Penetrations;
		PenetrationResists = other.PenetrationResists;
		HitValues = other.HitValues;
		AvoidValues = other.AvoidValues;
		DisorderOfQi = other.DisorderOfQi;
		LifeSkillQualifications = other.LifeSkillQualifications;
		LifeSkillGrowthType = other.LifeSkillGrowthType;
		CombatSkillQualifications = other.CombatSkillQualifications;
		CombatSkillGrowthType = other.CombatSkillGrowthType;
		LifeSkillAttainments = other.LifeSkillAttainments;
		CombatSkillAttainments = other.CombatSkillAttainments;
		Personalities = other.Personalities;
		Resources = other.Resources;
		CurrInventoryLoad = other.CurrInventoryLoad;
		MaxInventoryLoad = other.MaxInventoryLoad;
		KidnapCount = other.KidnapCount;
		AttackMedal = other.AttackMedal;
		DefenceMedal = other.DefenceMedal;
		WisdomMedal = other.WisdomMedal;
		Command = new SByteList(other.Command);
		AdvancedCommand = new SByteList(other.AdvancedCommand);
		ConsummateLevel = other.ConsummateLevel;
		KidnapBeginDate = other.KidnapBeginDate;
		KidnapDuration = other.KidnapDuration;
		TotalResistance = other.TotalResistance;
		RopeItemKey = other.RopeItemKey;
		EscapeRate = other.EscapeRate;
		RopeEffect = other.RopeEffect;
		CompletelyInfected = other.CompletelyInfected;
		OwningBook = other.OwningBook;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 352;
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize += Command.GetSerializedSize();
		totalSize += AdvancedCommand.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
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
		*(int*)pCurrData = Alertness;
		pCurrData += 4;
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
		pCurrData += MaxMainAttributes.Serialize(pCurrData);
		pCurrData += Penetrations.Serialize(pCurrData);
		pCurrData += PenetrationResists.Serialize(pCurrData);
		pCurrData += HitValues.Serialize(pCurrData);
		pCurrData += AvoidValues.Serialize(pCurrData);
		*(short*)pCurrData = DisorderOfQi;
		pCurrData += 2;
		pCurrData += LifeSkillQualifications.Serialize(pCurrData);
		*pCurrData = (byte)LifeSkillGrowthType;
		pCurrData++;
		pCurrData += CombatSkillQualifications.Serialize(pCurrData);
		*pCurrData = (byte)CombatSkillGrowthType;
		pCurrData++;
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		pCurrData += CombatSkillAttainments.Serialize(pCurrData);
		pCurrData += Personalities.Serialize(pCurrData);
		pCurrData += Resources.Serialize(pCurrData);
		*(int*)pCurrData = CurrInventoryLoad;
		pCurrData += 4;
		*(int*)pCurrData = MaxInventoryLoad;
		pCurrData += 4;
		*pCurrData = (byte)KidnapCount;
		pCurrData++;
		*(int*)pCurrData = AttackMedal;
		pCurrData += 4;
		*(int*)pCurrData = DefenceMedal;
		pCurrData += 4;
		*(int*)pCurrData = WisdomMedal;
		pCurrData += 4;
		int fieldSize2 = Command.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		int fieldSize3 = AdvancedCommand.Serialize(pCurrData);
		pCurrData += fieldSize3;
		Tester.Assert(fieldSize3 <= 65535);
		*pCurrData = (byte)ConsummateLevel;
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
		*pCurrData = (CompletelyInfected ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (OwningBook ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
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
		Alertness = *(int*)pCurrData;
		pCurrData += 4;
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
		pCurrData += MaxMainAttributes.Deserialize(pCurrData);
		pCurrData += Penetrations.Deserialize(pCurrData);
		pCurrData += PenetrationResists.Deserialize(pCurrData);
		pCurrData += HitValues.Deserialize(pCurrData);
		pCurrData += AvoidValues.Deserialize(pCurrData);
		DisorderOfQi = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += LifeSkillQualifications.Deserialize(pCurrData);
		LifeSkillGrowthType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += CombatSkillQualifications.Deserialize(pCurrData);
		CombatSkillGrowthType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += CombatSkillAttainments.Deserialize(pCurrData);
		pCurrData += Personalities.Deserialize(pCurrData);
		pCurrData += Resources.Deserialize(pCurrData);
		CurrInventoryLoad = *(int*)pCurrData;
		pCurrData += 4;
		MaxInventoryLoad = *(int*)pCurrData;
		pCurrData += 4;
		KidnapCount = (sbyte)(*pCurrData);
		pCurrData++;
		AttackMedal = *(int*)pCurrData;
		pCurrData += 4;
		DefenceMedal = *(int*)pCurrData;
		pCurrData += 4;
		WisdomMedal = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Command.Deserialize(pCurrData);
		pCurrData += AdvancedCommand.Deserialize(pCurrData);
		ConsummateLevel = (sbyte)(*pCurrData);
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
		CompletelyInfected = *pCurrData != 0;
		pCurrData++;
		OwningBook = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
