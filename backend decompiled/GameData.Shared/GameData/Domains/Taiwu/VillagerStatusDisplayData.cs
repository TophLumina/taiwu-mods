using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Taiwu.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public struct VillagerStatusDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public NameRelatedData Name;

	[SerializableGameDataField]
	public short CurrAge;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public short MaxLeftHealth;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public sbyte BehaviorType;

	[SerializableGameDataField]
	public short Happiness;

	[SerializableGameDataField]
	public short FavorabilityToTaiwu;

	[SerializableGameDataField]
	public sbyte Fame;

	[SerializableGameDataField]
	public byte LivingStatus;

	[SerializableGameDataField]
	public byte WorkStatus;

	[SerializableGameDataField]
	public short PhysiologicalAge;

	[SerializableGameDataField]
	public short ClothDisplayId;

	[SerializableGameDataField]
	public bool FaceVisible;

	[SerializableGameDataField]
	public byte CreatingType;

	[SerializableGameDataField]
	public int BirthDate;

	[SerializableGameDataField]
	public sbyte DefeatMarkCount;

	[SerializableGameDataField]
	public short Charm;

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
	public LifeSkillShorts LifeSkillAttainment;

	[SerializableGameDataField]
	public sbyte LifeSkillGrowthType;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillQualifications;

	[SerializableGameDataField]
	public sbyte CombatSkillGrowthType;

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
	public OrganizationInfo OrgInfo;

	[SerializableGameDataField]
	public short RoleTemplateId;

	[SerializableGameDataField]
	public VillagerRoleArrangementDisplayDataWrapper ArrangementDisplayData;

	[SerializableGameDataField]
	public short TrappedAreaId;

	[SerializableGameDataField]
	public ushort RelationToTaiwu;

	[SerializableGameDataField]
	public ushort RelationFromTaiwu;

	[SerializableGameDataField]
	public sbyte LeftPotentialCount;

	[SerializableGameDataField]
	public bool IsSameFactionWithTaiwu;

	[SerializableGameDataField]
	public sbyte WorkType;

	[SerializableGameDataField]
	public bool IsInteractedWithTaiwu;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	[SerializableGameDataField]
	public short ActualAge;

	[SerializableGameDataField]
	public SByteList Command;

	[SerializableGameDataField]
	public CharacterLocationDisplayData LocationDisplayData;

	[SerializableGameDataField]
	public short InfluencePower;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 307;
		totalSize = ((ArrangementDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ArrangementDisplayData.GetSerializedSize())));
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize += Command.GetSerializedSize();
		totalSize = ((LocationDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + LocationDisplayData.GetSerializedSize())));
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
		pCurrData += Name.Serialize(pCurrData);
		*(short*)pCurrData = CurrAge;
		pCurrData += 2;
		*(short*)pCurrData = Health;
		pCurrData += 2;
		*(short*)pCurrData = MaxLeftHealth;
		pCurrData += 2;
		*pCurrData = (byte)Gender;
		pCurrData++;
		*pCurrData = (byte)BehaviorType;
		pCurrData++;
		*(short*)pCurrData = Happiness;
		pCurrData += 2;
		*(short*)pCurrData = FavorabilityToTaiwu;
		pCurrData += 2;
		*pCurrData = (byte)Fame;
		pCurrData++;
		*pCurrData = LivingStatus;
		pCurrData++;
		*pCurrData = WorkStatus;
		pCurrData++;
		*(short*)pCurrData = PhysiologicalAge;
		pCurrData += 2;
		*(short*)pCurrData = ClothDisplayId;
		pCurrData += 2;
		*pCurrData = (FaceVisible ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = CreatingType;
		pCurrData++;
		*(int*)pCurrData = BirthDate;
		pCurrData += 4;
		*pCurrData = (byte)DefeatMarkCount;
		pCurrData++;
		*(short*)pCurrData = Charm;
		pCurrData += 2;
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
		pCurrData += LifeSkillAttainment.Serialize(pCurrData);
		*pCurrData = (byte)LifeSkillGrowthType;
		pCurrData++;
		pCurrData += CombatSkillQualifications.Serialize(pCurrData);
		*pCurrData = (byte)CombatSkillGrowthType;
		pCurrData++;
		pCurrData += Personalities.Serialize(pCurrData);
		pCurrData += Resources.Serialize(pCurrData);
		*(int*)pCurrData = CurrInventoryLoad;
		pCurrData += 4;
		*(int*)pCurrData = MaxInventoryLoad;
		pCurrData += 4;
		*pCurrData = (byte)KidnapCount;
		pCurrData++;
		pCurrData += OrgInfo.Serialize(pCurrData);
		*(short*)pCurrData = RoleTemplateId;
		pCurrData += 2;
		if (ArrangementDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ArrangementDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = TrappedAreaId;
		pCurrData += 2;
		*(ushort*)pCurrData = RelationToTaiwu;
		pCurrData += 2;
		*(ushort*)pCurrData = RelationFromTaiwu;
		pCurrData += 2;
		*pCurrData = (byte)LeftPotentialCount;
		pCurrData++;
		*pCurrData = (IsSameFactionWithTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)WorkType;
		pCurrData++;
		*pCurrData = (IsInteractedWithTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (AvatarRelatedData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = AvatarRelatedData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = ActualAge;
		pCurrData += 2;
		int fieldSize3 = Command.Serialize(pCurrData);
		pCurrData += fieldSize3;
		Tester.Assert(fieldSize3 <= 65535);
		if (LocationDisplayData != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = LocationDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = InfluencePower;
		pCurrData += 2;
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
		pCurrData += Name.Deserialize(pCurrData);
		CurrAge = *(short*)pCurrData;
		pCurrData += 2;
		Health = *(short*)pCurrData;
		pCurrData += 2;
		MaxLeftHealth = *(short*)pCurrData;
		pCurrData += 2;
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		BehaviorType = (sbyte)(*pCurrData);
		pCurrData++;
		Happiness = *(short*)pCurrData;
		pCurrData += 2;
		FavorabilityToTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		Fame = (sbyte)(*pCurrData);
		pCurrData++;
		LivingStatus = *pCurrData;
		pCurrData++;
		WorkStatus = *pCurrData;
		pCurrData++;
		PhysiologicalAge = *(short*)pCurrData;
		pCurrData += 2;
		ClothDisplayId = *(short*)pCurrData;
		pCurrData += 2;
		FaceVisible = *pCurrData != 0;
		pCurrData++;
		CreatingType = *pCurrData;
		pCurrData++;
		BirthDate = *(int*)pCurrData;
		pCurrData += 4;
		DefeatMarkCount = (sbyte)(*pCurrData);
		pCurrData++;
		Charm = *(short*)pCurrData;
		pCurrData += 2;
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
		pCurrData += LifeSkillAttainment.Deserialize(pCurrData);
		LifeSkillGrowthType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += CombatSkillQualifications.Deserialize(pCurrData);
		CombatSkillGrowthType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += Personalities.Deserialize(pCurrData);
		pCurrData += Resources.Deserialize(pCurrData);
		CurrInventoryLoad = *(int*)pCurrData;
		pCurrData += 4;
		MaxInventoryLoad = *(int*)pCurrData;
		pCurrData += 4;
		KidnapCount = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += OrgInfo.Deserialize(pCurrData);
		RoleTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (ArrangementDisplayData == null)
			{
				ArrangementDisplayData = new VillagerRoleArrangementDisplayDataWrapper();
			}
			pCurrData += ArrangementDisplayData.Deserialize(pCurrData);
		}
		else
		{
			ArrangementDisplayData = null;
		}
		TrappedAreaId = *(short*)pCurrData;
		pCurrData += 2;
		RelationToTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		RelationFromTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		LeftPotentialCount = (sbyte)(*pCurrData);
		pCurrData++;
		IsSameFactionWithTaiwu = *pCurrData != 0;
		pCurrData++;
		WorkType = (sbyte)(*pCurrData);
		pCurrData++;
		IsInteractedWithTaiwu = *pCurrData != 0;
		pCurrData++;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
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
		ActualAge = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += Command.Deserialize(pCurrData);
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			if (LocationDisplayData == null)
			{
				LocationDisplayData = new CharacterLocationDisplayData();
			}
			pCurrData += LocationDisplayData.Deserialize(pCurrData);
		}
		else
		{
			LocationDisplayData = null;
		}
		InfluencePower = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
