using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class CharacterDisplayDataForGeneralScrollList : ISerializableGameData, ITaiwuSelectCharacterData, ISelectCharacterData
{
	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public short CharacterTemplateId;

	[SerializableGameDataField]
	public NameRelatedData NameData;

	[SerializableGameDataField]
	public short CurrAge;

	[SerializableGameDataField]
	public short ActualAge;

	[SerializableGameDataField]
	public int BirthDate;

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
	public int AttackMedal;

	[SerializableGameDataField]
	public int DefenceMedal;

	[SerializableGameDataField]
	public int WisdomMedal;

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
	public SByteList Command;

	[SerializableGameDataField]
	public SByteList AdvancedCommand;

	[SerializableGameDataField]
	public sbyte ConsummateLevel;

	[SerializableGameDataField]
	public bool IsSpecialGroupMember;

	[SerializableGameDataField]
	public bool IsCompanion;

	[SerializableGameDataField]
	public bool IsInteractedWithTaiwu;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	[SerializableGameDataField]
	public OrganizationInfo OrgInfo;

	[SerializableGameDataField]
	public ushort RelationToTaiwu;

	[SerializableGameDataField]
	public ushort RelationFromTaiwu;

	[SerializableGameDataField]
	public bool IsSameFactionWithTaiwu;

	[SerializableGameDataField]
	public bool HideHealth;

	[SerializableGameDataField]
	public int DarkAshRemainTime;

	[SerializableGameDataField]
	public int TripodVesselProtectRemainTime;

	[SerializableGameDataField]
	public int PoisonCount;

	[SerializableGameDataField]
	public sbyte WugCount;

	[SerializableGameDataField]
	public int Infection;

	[SerializableGameDataField]
	public NeiliAllocation ExtraNeiliAllocation;

	[SerializableGameDataField]
	public NeiliProportionOfFiveElements NeiliPercent;

	[SerializableGameDataField]
	public sbyte XiangshuType;

	public bool IsTaiwuTeammate => IsCompanion;

	int ISelectCharacterData.CharacterId => CharacterId;

	CharacterDisplayDataForGeneralScrollList ISelectCharacterData.GetGeneralScrollListData()
	{
		return this;
	}

	public CharacterDisplayDataForGeneralScrollList()
	{
	}

	public CharacterDisplayDataForGeneralScrollList(CharacterDisplayDataForGeneralScrollList other)
	{
		CharacterId = other.CharacterId;
		CharacterTemplateId = other.CharacterTemplateId;
		NameData = other.NameData;
		CurrAge = other.CurrAge;
		ActualAge = other.ActualAge;
		BirthDate = other.BirthDate;
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
		AttackMedal = other.AttackMedal;
		DefenceMedal = other.DefenceMedal;
		WisdomMedal = other.WisdomMedal;
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
		Gender = other.Gender;
		PhysiologicalAge = other.PhysiologicalAge;
		ClothDisplayId = other.ClothDisplayId;
		FaceVisible = other.FaceVisible;
		CreatingType = other.CreatingType;
		Command = other.Command;
		AdvancedCommand = other.AdvancedCommand;
		ConsummateLevel = other.ConsummateLevel;
		IsSpecialGroupMember = other.IsSpecialGroupMember;
		IsCompanion = other.IsCompanion;
		IsInteractedWithTaiwu = other.IsInteractedWithTaiwu;
		AvatarRelatedData = new AvatarRelatedData(other.AvatarRelatedData);
		OrgInfo = other.OrgInfo;
		RelationToTaiwu = other.RelationToTaiwu;
		RelationFromTaiwu = other.RelationFromTaiwu;
		IsSameFactionWithTaiwu = other.IsSameFactionWithTaiwu;
		HideHealth = other.HideHealth;
		DarkAshRemainTime = other.DarkAshRemainTime;
		TripodVesselProtectRemainTime = other.TripodVesselProtectRemainTime;
		PoisonCount = other.PoisonCount;
		WugCount = other.WugCount;
		Infection = other.Infection;
		ExtraNeiliAllocation = other.ExtraNeiliAllocation;
		NeiliPercent = other.NeiliPercent;
		XiangshuType = other.XiangshuType;
	}

	public void Assign(CharacterDisplayDataForGeneralScrollList other)
	{
		CharacterId = other.CharacterId;
		CharacterTemplateId = other.CharacterTemplateId;
		NameData = other.NameData;
		CurrAge = other.CurrAge;
		ActualAge = other.ActualAge;
		BirthDate = other.BirthDate;
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
		AttackMedal = other.AttackMedal;
		DefenceMedal = other.DefenceMedal;
		WisdomMedal = other.WisdomMedal;
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
		Gender = other.Gender;
		PhysiologicalAge = other.PhysiologicalAge;
		ClothDisplayId = other.ClothDisplayId;
		FaceVisible = other.FaceVisible;
		CreatingType = other.CreatingType;
		Command = other.Command;
		AdvancedCommand = other.AdvancedCommand;
		ConsummateLevel = other.ConsummateLevel;
		IsSpecialGroupMember = other.IsSpecialGroupMember;
		IsCompanion = other.IsCompanion;
		IsInteractedWithTaiwu = other.IsInteractedWithTaiwu;
		AvatarRelatedData = new AvatarRelatedData(other.AvatarRelatedData);
		OrgInfo = other.OrgInfo;
		RelationToTaiwu = other.RelationToTaiwu;
		RelationFromTaiwu = other.RelationFromTaiwu;
		IsSameFactionWithTaiwu = other.IsSameFactionWithTaiwu;
		HideHealth = other.HideHealth;
		DarkAshRemainTime = other.DarkAshRemainTime;
		TripodVesselProtectRemainTime = other.TripodVesselProtectRemainTime;
		PoisonCount = other.PoisonCount;
		WugCount = other.WugCount;
		Infection = other.Infection;
		ExtraNeiliAllocation = other.ExtraNeiliAllocation;
		NeiliPercent = other.NeiliPercent;
		XiangshuType = other.XiangshuType;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 368;
		totalSize += Command.GetSerializedSize();
		totalSize += AdvancedCommand.GetSerializedSize();
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
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
		*(short*)pCurrData = CurrAge;
		pCurrData += 2;
		*(short*)pCurrData = ActualAge;
		pCurrData += 2;
		*(int*)pCurrData = BirthDate;
		pCurrData += 4;
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
		*(int*)pCurrData = AttackMedal;
		pCurrData += 4;
		*(int*)pCurrData = DefenceMedal;
		pCurrData += 4;
		*(int*)pCurrData = WisdomMedal;
		pCurrData += 4;
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
		int fieldSize = Command.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		int fieldSize2 = AdvancedCommand.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		*pCurrData = (byte)ConsummateLevel;
		pCurrData++;
		*pCurrData = (IsSpecialGroupMember ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsCompanion ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsInteractedWithTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (AvatarRelatedData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize3 = AvatarRelatedData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += OrgInfo.Serialize(pCurrData);
		*(ushort*)pCurrData = RelationToTaiwu;
		pCurrData += 2;
		*(ushort*)pCurrData = RelationFromTaiwu;
		pCurrData += 2;
		*pCurrData = (IsSameFactionWithTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (HideHealth ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = DarkAshRemainTime;
		pCurrData += 4;
		*(int*)pCurrData = TripodVesselProtectRemainTime;
		pCurrData += 4;
		*(int*)pCurrData = PoisonCount;
		pCurrData += 4;
		*pCurrData = (byte)WugCount;
		pCurrData++;
		*(int*)pCurrData = Infection;
		pCurrData += 4;
		pCurrData += ExtraNeiliAllocation.Serialize(pCurrData);
		pCurrData += NeiliPercent.Serialize(pCurrData);
		*pCurrData = (byte)XiangshuType;
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
		CurrAge = *(short*)pCurrData;
		pCurrData += 2;
		ActualAge = *(short*)pCurrData;
		pCurrData += 2;
		BirthDate = *(int*)pCurrData;
		pCurrData += 4;
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
		AttackMedal = *(int*)pCurrData;
		pCurrData += 4;
		DefenceMedal = *(int*)pCurrData;
		pCurrData += 4;
		WisdomMedal = *(int*)pCurrData;
		pCurrData += 4;
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
		pCurrData += Command.Deserialize(pCurrData);
		pCurrData += AdvancedCommand.Deserialize(pCurrData);
		ConsummateLevel = (sbyte)(*pCurrData);
		pCurrData++;
		IsSpecialGroupMember = *pCurrData != 0;
		pCurrData++;
		IsCompanion = *pCurrData != 0;
		pCurrData++;
		IsInteractedWithTaiwu = *pCurrData != 0;
		pCurrData++;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			AvatarRelatedData = new AvatarRelatedData();
			pCurrData += AvatarRelatedData.Deserialize(pCurrData);
		}
		else
		{
			AvatarRelatedData = null;
		}
		pCurrData += OrgInfo.Deserialize(pCurrData);
		RelationToTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		RelationFromTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		IsSameFactionWithTaiwu = *pCurrData != 0;
		pCurrData++;
		HideHealth = *pCurrData != 0;
		pCurrData++;
		DarkAshRemainTime = *(int*)pCurrData;
		pCurrData += 4;
		TripodVesselProtectRemainTime = *(int*)pCurrData;
		pCurrData += 4;
		PoisonCount = *(int*)pCurrData;
		pCurrData += 4;
		WugCount = (sbyte)(*pCurrData);
		pCurrData++;
		Infection = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += ExtraNeiliAllocation.Deserialize(pCurrData);
		pCurrData += NeiliPercent.Deserialize(pCurrData);
		XiangshuType = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
