using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 同道显示数据。用于同道界面获取所有显示所需数据，避免监听
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class GroupCharDisplayData : ISerializableGameData
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

	/// <summary>
	/// 此人为特殊同道
	/// </summary>
	[SerializableGameDataField]
	public bool IsSpecialGroupMember;

	/// <summary>
	/// 与太吾互动过
	/// </summary>
	[SerializableGameDataField]
	public bool IsInteractedWithTaiwu;

	/// <summary>
	/// 相枢化身类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte XiangshuType;

	/// <summary>
	/// 形象数据
	/// </summary>
	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public GroupCharDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public GroupCharDisplayData(GroupCharDisplayData other)
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
		Command = new SByteList(other.Command);
		AdvancedCommand = new SByteList(other.AdvancedCommand);
		ConsummateLevel = other.ConsummateLevel;
		IsSpecialGroupMember = other.IsSpecialGroupMember;
		IsInteractedWithTaiwu = other.IsInteractedWithTaiwu;
		XiangshuType = other.XiangshuType;
		AvatarRelatedData = new AvatarRelatedData(other.AvatarRelatedData);
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(GroupCharDisplayData other)
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
		Command = new SByteList(other.Command);
		AdvancedCommand = new SByteList(other.AdvancedCommand);
		ConsummateLevel = other.ConsummateLevel;
		IsSpecialGroupMember = other.IsSpecialGroupMember;
		IsInteractedWithTaiwu = other.IsInteractedWithTaiwu;
		XiangshuType = other.XiangshuType;
		AvatarRelatedData = new AvatarRelatedData(other.AvatarRelatedData);
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 320;
		totalSize += Command.GetSerializedSize();
		totalSize += AdvancedCommand.GetSerializedSize();
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
		*pCurrData = (IsInteractedWithTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)XiangshuType;
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
		IsInteractedWithTaiwu = *pCurrData != 0;
		pCurrData++;
		XiangshuType = (sbyte)(*pCurrData);
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
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
