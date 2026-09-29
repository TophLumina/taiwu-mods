using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.LegendaryBook;

[SerializableGameData(NoCopyConstructors = true)]
public class LegendaryBookCharacterRelatedData : ISerializableGameData
{
	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public short PhysiologicalAge;

	[SerializableGameDataField]
	public short FeatureId;

	[SerializableGameDataField]
	public short Favorability;

	[SerializableGameDataField]
	public int Alertness;

	[SerializableGameDataField]
	public short Charm;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public sbyte ConsummateLevel;

	[SerializableGameDataField]
	public sbyte BehaviorType;

	[SerializableGameDataField]
	public sbyte HappinessType;

	[SerializableGameDataField]
	public sbyte FameType;

	[SerializableGameDataField]
	public sbyte HealthType;

	[SerializableGameDataField]
	public sbyte BookType;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	[SerializableGameDataField]
	public NameRelatedData NameRelatedData;

	[SerializableGameDataField]
	public OrganizationInfo OrganizationInfo;

	[SerializableGameDataField]
	public FullBlockName FullBlockName;

	[SerializableGameDataField]
	public short CharacterTemplateId;

	[SerializableGameDataField]
	public LocationNameRelatedData LocationNameRelatedData;

	[SerializableGameDataField]
	public bool Followed;

	[SerializableGameDataField]
	public sbyte DefeatMarkCount;

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
	public CombatSkillShorts CombatSkillAttainments;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

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
	public short ActualAge;

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
	public bool IsSpecialGroupMember;

	[SerializableGameDataField]
	public bool IsCompanion;

	[SerializableGameDataField]
	public bool IsInteractedWithTaiwu;

	[SerializableGameDataField]
	public sbyte BookOwnerState;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public short MaxLeftHealth;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 340;
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize += FullBlockName.GetSerializedSize();
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
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(short*)pCurrData = PhysiologicalAge;
		pCurrData += 2;
		*(short*)pCurrData = FeatureId;
		pCurrData += 2;
		*(short*)pCurrData = Favorability;
		pCurrData += 2;
		*(int*)pCurrData = Alertness;
		pCurrData += 4;
		*(short*)pCurrData = Charm;
		pCurrData += 2;
		*pCurrData = (byte)Gender;
		pCurrData++;
		*pCurrData = (byte)ConsummateLevel;
		pCurrData++;
		*pCurrData = (byte)BehaviorType;
		pCurrData++;
		*pCurrData = (byte)HappinessType;
		pCurrData++;
		*pCurrData = (byte)FameType;
		pCurrData++;
		*pCurrData = (byte)HealthType;
		pCurrData++;
		*pCurrData = (byte)BookType;
		pCurrData++;
		pCurrData += Location.Serialize(pCurrData);
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
		pCurrData += NameRelatedData.Serialize(pCurrData);
		pCurrData += OrganizationInfo.Serialize(pCurrData);
		int fieldSize2 = FullBlockName.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		*(short*)pCurrData = CharacterTemplateId;
		pCurrData += 2;
		pCurrData += LocationNameRelatedData.Serialize(pCurrData);
		*pCurrData = (Followed ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)DefeatMarkCount;
		pCurrData++;
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
		pCurrData += CombatSkillAttainments.Serialize(pCurrData);
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		pCurrData += Personalities.Serialize(pCurrData);
		pCurrData += Resources.Serialize(pCurrData);
		*(int*)pCurrData = CurrInventoryLoad;
		pCurrData += 4;
		*(int*)pCurrData = MaxInventoryLoad;
		pCurrData += 4;
		*pCurrData = (byte)KidnapCount;
		pCurrData++;
		*(short*)pCurrData = ActualAge;
		pCurrData += 2;
		*(short*)pCurrData = ClothDisplayId;
		pCurrData += 2;
		*pCurrData = (FaceVisible ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = CreatingType;
		pCurrData++;
		int fieldSize3 = Command.Serialize(pCurrData);
		pCurrData += fieldSize3;
		Tester.Assert(fieldSize3 <= 65535);
		int fieldSize4 = AdvancedCommand.Serialize(pCurrData);
		pCurrData += fieldSize4;
		Tester.Assert(fieldSize4 <= 65535);
		*pCurrData = (IsSpecialGroupMember ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsCompanion ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsInteractedWithTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)BookOwnerState;
		pCurrData++;
		*(short*)pCurrData = Health;
		pCurrData += 2;
		*(short*)pCurrData = MaxLeftHealth;
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
		Id = *(int*)pCurrData;
		pCurrData += 4;
		PhysiologicalAge = *(short*)pCurrData;
		pCurrData += 2;
		FeatureId = *(short*)pCurrData;
		pCurrData += 2;
		Favorability = *(short*)pCurrData;
		pCurrData += 2;
		Alertness = *(int*)pCurrData;
		pCurrData += 4;
		Charm = *(short*)pCurrData;
		pCurrData += 2;
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		ConsummateLevel = (sbyte)(*pCurrData);
		pCurrData++;
		BehaviorType = (sbyte)(*pCurrData);
		pCurrData++;
		HappinessType = (sbyte)(*pCurrData);
		pCurrData++;
		FameType = (sbyte)(*pCurrData);
		pCurrData++;
		HealthType = (sbyte)(*pCurrData);
		pCurrData++;
		BookType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += Location.Deserialize(pCurrData);
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
		pCurrData += NameRelatedData.Deserialize(pCurrData);
		pCurrData += OrganizationInfo.Deserialize(pCurrData);
		pCurrData += FullBlockName.Deserialize(pCurrData);
		CharacterTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += LocationNameRelatedData.Deserialize(pCurrData);
		Followed = *pCurrData != 0;
		pCurrData++;
		DefeatMarkCount = (sbyte)(*pCurrData);
		pCurrData++;
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
		pCurrData += CombatSkillAttainments.Deserialize(pCurrData);
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += Personalities.Deserialize(pCurrData);
		pCurrData += Resources.Deserialize(pCurrData);
		CurrInventoryLoad = *(int*)pCurrData;
		pCurrData += 4;
		MaxInventoryLoad = *(int*)pCurrData;
		pCurrData += 4;
		KidnapCount = (sbyte)(*pCurrData);
		pCurrData++;
		ActualAge = *(short*)pCurrData;
		pCurrData += 2;
		ClothDisplayId = *(short*)pCurrData;
		pCurrData += 2;
		FaceVisible = *pCurrData != 0;
		pCurrData++;
		CreatingType = *pCurrData;
		pCurrData++;
		pCurrData += Command.Deserialize(pCurrData);
		pCurrData += AdvancedCommand.Deserialize(pCurrData);
		IsSpecialGroupMember = *pCurrData != 0;
		pCurrData++;
		IsCompanion = *pCurrData != 0;
		pCurrData++;
		IsInteractedWithTaiwu = *pCurrData != 0;
		pCurrData++;
		BookOwnerState = (sbyte)(*pCurrData);
		pCurrData++;
		Health = *(short*)pCurrData;
		pCurrData += 2;
		MaxLeftHealth = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
