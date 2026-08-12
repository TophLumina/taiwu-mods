using GameData.Domains.Map;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 同道显示数据。用于同道界面获取所有显示所需数据，避免监听
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true, NotForArchive = true, NoCopyConstructors = true)]
public class VillagerCharDisplayData : ISerializableGameData, IVillagerSelectCharacterData, ISelectCharacterData
{
	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public short CharacterTemplateId;

	[SerializableGameDataField]
	public short RoleTemplateId;

	/// <summary>
	/// 标记
	/// </summary>
	[SerializableGameDataField]
	public byte Flags;

	[SerializableGameDataField]
	public OrganizationInfo OrgInfo;

	[SerializableGameDataField]
	public ulong ExternalRelation;

	[SerializableGameDataField]
	public VillagerWorkData VillagerWorkData;

	[SerializableGameDataField]
	public byte WorkStatus;

	[SerializableGameDataField]
	public int ArrangementTemplateId = -1;

	[SerializableGameDataField]
	public int BuildingBlockTemplateId = -1;

	[SerializableGameDataField]
	public bool IsBuyOperation;

	[SerializableGameDataField]
	public int GraveId = -1;

	[SerializableGameDataField]
	public int SwordTombId = -1;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public LocationNameRelatedData LocationNameRelatedData;

	[SerializableGameDataField]
	public int Potential;

	[SerializableGameDataField]
	public sbyte Happiness;

	[SerializableGameDataField]
	public bool Followed;

	[SerializableGameDataField]
	public NameRelatedData NameData;

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

	/// <summary>
	/// 武学造诣，村长信息需要
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	/// <summary>
	/// 技艺造诣，村长信息需要
	/// </summary>
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

	/// <summary>
	/// 此人为特殊同道
	/// </summary>
	[SerializableGameDataField]
	public bool IsSpecialGroupMember;

	/// <summary>
	/// 此人为同道
	/// </summary>
	[SerializableGameDataField]
	public bool IsCompanion;

	/// <summary>
	/// 与太吾互动过
	/// </summary>
	[SerializableGameDataField]
	public bool IsInteractedWithTaiwu;

	/// <summary>
	/// 形象数据
	/// </summary>
	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList GeneralScrollListData;

	int ISelectCharacterData.CharacterId => CharacterId;

	sbyte IVillagerSelectCharacterData.WorkType => VillagerWorkData?.WorkType ?? (-1);

	byte IVillagerSelectCharacterData.WorkStatus => WorkStatus;

	int IVillagerSelectCharacterData.ArrangementTemplateId => ArrangementTemplateId;

	int IVillagerSelectCharacterData.BuildingBlockTemplateId => BuildingBlockTemplateId;

	bool IVillagerSelectCharacterData.IsBuyOperation => IsBuyOperation;

	int IVillagerSelectCharacterData.GraveId => GraveId;

	int IVillagerSelectCharacterData.SwordTombId => SwordTombId;

	int IVillagerSelectCharacterData.RoleTemplateId => RoleTemplateId;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 392;
		totalSize += Command.GetSerializedSize();
		totalSize += AdvancedCommand.GetSerializedSize();
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize = ((GeneralScrollListData == null) ? (totalSize + 2) : (totalSize + (2 + GeneralScrollListData.GetSerializedSize())));
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
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*(short*)pCurrData = CharacterTemplateId;
		pCurrData += 2;
		*(short*)pCurrData = RoleTemplateId;
		pCurrData += 2;
		*pCurrData = Flags;
		pCurrData++;
		pCurrData += OrgInfo.Serialize(pCurrData);
		*(ulong*)pCurrData = ExternalRelation;
		pCurrData += 8;
		pCurrData += VillagerWorkData.Serialize(pCurrData);
		*pCurrData = WorkStatus;
		pCurrData++;
		*(int*)pCurrData = ArrangementTemplateId;
		pCurrData += 4;
		*(int*)pCurrData = BuildingBlockTemplateId;
		pCurrData += 4;
		*pCurrData = (IsBuyOperation ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = GraveId;
		pCurrData += 4;
		*(int*)pCurrData = SwordTombId;
		pCurrData += 4;
		pCurrData += Location.Serialize(pCurrData);
		pCurrData += LocationNameRelatedData.Serialize(pCurrData);
		*(int*)pCurrData = Potential;
		pCurrData += 4;
		*pCurrData = (byte)Happiness;
		pCurrData++;
		*pCurrData = (Followed ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += NameData.Serialize(pCurrData);
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
		if (GeneralScrollListData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = GeneralScrollListData.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		CharacterTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		RoleTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		Flags = *pCurrData;
		pCurrData++;
		pCurrData += OrgInfo.Deserialize(pCurrData);
		ExternalRelation = *(ulong*)pCurrData;
		pCurrData += 8;
		if (VillagerWorkData == null)
		{
			VillagerWorkData = new VillagerWorkData();
		}
		pCurrData += VillagerWorkData.Deserialize(pCurrData);
		WorkStatus = *pCurrData;
		pCurrData++;
		ArrangementTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		BuildingBlockTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		IsBuyOperation = *pCurrData != 0;
		pCurrData++;
		GraveId = *(int*)pCurrData;
		pCurrData += 4;
		SwordTombId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Location.Deserialize(pCurrData);
		pCurrData += LocationNameRelatedData.Deserialize(pCurrData);
		Potential = *(int*)pCurrData;
		pCurrData += 4;
		Happiness = (sbyte)(*pCurrData);
		pCurrData++;
		Followed = *pCurrData != 0;
		pCurrData++;
		pCurrData += NameData.Deserialize(pCurrData);
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
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (GeneralScrollListData == null)
			{
				GeneralScrollListData = new CharacterDisplayDataForGeneralScrollList();
			}
			pCurrData += GeneralScrollListData.Deserialize(pCurrData);
		}
		else
		{
			GeneralScrollListData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	CharacterDisplayDataForGeneralScrollList ISelectCharacterData.GetGeneralScrollListData()
	{
		return GeneralScrollListData;
	}
}
