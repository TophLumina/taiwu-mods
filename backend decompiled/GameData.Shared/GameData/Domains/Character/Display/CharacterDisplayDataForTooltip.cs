using System.Collections.Generic;
using GameData.Domains.Building;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

[SerializableGameData(NoCopyConstructors = true)]
public class CharacterDisplayDataForTooltip : ISerializableGameData
{
	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public byte CreatingType;

	[SerializableGameDataField]
	public OrganizationInfo OrganizationInfo;

	[SerializableGameDataField]
	public short Age;

	[SerializableGameDataField]
	public FullName FullName;

	[SerializableGameDataField]
	public byte MonkType;

	[SerializableGameDataField]
	public MonasticTitle MonasticTitle;

	[SerializableGameDataField]
	public int CustomDisplayNameId;

	[SerializableGameDataField]
	public short Attraction;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	[SerializableGameDataField]
	public sbyte BehaviorType;

	[SerializableGameDataField]
	public MainAttributes MainAttributes;

	[SerializableGameDataField]
	public List<short> FeatureIds;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public bool Transgender;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillQualifications;

	[SerializableGameDataField]
	public sbyte CombatSkillQualificationGrowthType;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillQualifications;

	[SerializableGameDataField]
	public sbyte LifeSkillQualificationGrowthType;

	[SerializableGameDataField]
	public Personalities Personalities;

	[SerializableGameDataField]
	public List<sbyte> TeammateCommands;

	[SerializableGameDataField]
	public int NickNameId;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField]
	public short FavorabilityToTaiwu;

	[SerializableGameDataField]
	public bool IsInteractedCharacter;

	public CharacterDisplayDataForTooltip()
	{
		NickNameId = -1;
	}

	public CharacterDisplayDataForTooltip(RecruitCharacterData recruitCharacter)
	{
		TemplateId = recruitCharacter.TemplateId;
		CreatingType = 1;
		OrganizationInfo = new OrganizationInfo(0, 0, principal: true, -1);
		Age = recruitCharacter.Age;
		FullName = recruitCharacter.FullName;
		MonkType = 0;
		MonasticTitle = new MonasticTitle(-1, -1);
		CustomDisplayNameId = -1;
		BehaviorType = GameData.Domains.Character.BehaviorType.GetBehaviorType(recruitCharacter.GetBaseMorality());
		Attraction = recruitCharacter.FinalAttraction;
		AvatarRelatedData = recruitCharacter.GenerateAvatarRelatedData();
		MainAttributes = recruitCharacter.MainAttributes;
		FeatureIds = recruitCharacter.FeatureIds;
		Gender = recruitCharacter.Gender;
		Transgender = recruitCharacter.Transgender;
		CombatSkillQualifications = recruitCharacter.CombatSkillQualifications;
		CombatSkillQualificationGrowthType = recruitCharacter.CombatSkillQualificationGrowthType;
		LifeSkillQualifications = recruitCharacter.LifeSkillQualifications;
		LifeSkillQualificationGrowthType = recruitCharacter.LifeSkillQualificationGrowthType;
		Personalities = recruitCharacter.CalculatedPersonalities;
		TeammateCommands = recruitCharacter.TeammateCommands;
		NickNameId = -1;
		LifeSkillAttainments = default(LifeSkillShorts);
		FavorabilityToTaiwu = 0;
		IsInteractedCharacter = false;
	}

	public NameRelatedData GetNameRelatedData()
	{
		NameRelatedData nameRelatedData = new NameRelatedData();
		nameRelatedData.CharTemplateId = TemplateId;
		nameRelatedData.Gender = Gender;
		nameRelatedData.MonkType = MonkType;
		nameRelatedData.FullName = FullName;
		nameRelatedData.OrgTemplateId = OrganizationInfo.OrgTemplateId;
		nameRelatedData.OrgGrade = OrganizationInfo.Grade;
		nameRelatedData.MonasticTitle = MonasticTitle;
		nameRelatedData.CustomDisplayNameId = CustomDisplayNameId;
		nameRelatedData.NickNameId = NickNameId;
		nameRelatedData.ExtraNameTextTemplateId = -1;
		return nameRelatedData;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 162;
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize = ((FeatureIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * FeatureIds.Count)));
		totalSize = ((TeammateCommands == null) ? (totalSize + 2) : (totalSize + (2 + TeammateCommands.Count)));
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
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*pCurrData = CreatingType;
		pCurrData++;
		pCurrData += OrganizationInfo.Serialize(pCurrData);
		*(short*)pCurrData = Age;
		pCurrData += 2;
		pCurrData += FullName.Serialize(pCurrData);
		*pCurrData = MonkType;
		pCurrData++;
		pCurrData += MonasticTitle.Serialize(pCurrData);
		*(int*)pCurrData = CustomDisplayNameId;
		pCurrData += 4;
		*(short*)pCurrData = Attraction;
		pCurrData += 2;
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
		*pCurrData = (byte)BehaviorType;
		pCurrData++;
		pCurrData += MainAttributes.Serialize(pCurrData);
		if (FeatureIds != null)
		{
			int elementsCount = FeatureIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = FeatureIds[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)Gender;
		pCurrData++;
		*pCurrData = (Transgender ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += CombatSkillQualifications.Serialize(pCurrData);
		*pCurrData = (byte)CombatSkillQualificationGrowthType;
		pCurrData++;
		pCurrData += LifeSkillQualifications.Serialize(pCurrData);
		*pCurrData = (byte)LifeSkillQualificationGrowthType;
		pCurrData++;
		pCurrData += Personalities.Serialize(pCurrData);
		if (TeammateCommands != null)
		{
			int elementsCount2 = TeammateCommands.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData[j] = (byte)TeammateCommands[j];
			}
			pCurrData += elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = NickNameId;
		pCurrData += 4;
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		*(short*)pCurrData = FavorabilityToTaiwu;
		pCurrData += 2;
		*pCurrData = (IsInteractedCharacter ? ((byte)1) : ((byte)0));
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
		Id = *(int*)pCurrData;
		pCurrData += 4;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		CreatingType = *pCurrData;
		pCurrData++;
		pCurrData += OrganizationInfo.Deserialize(pCurrData);
		Age = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += FullName.Deserialize(pCurrData);
		MonkType = *pCurrData;
		pCurrData++;
		pCurrData += MonasticTitle.Deserialize(pCurrData);
		CustomDisplayNameId = *(int*)pCurrData;
		pCurrData += 4;
		Attraction = *(short*)pCurrData;
		pCurrData += 2;
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
		BehaviorType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += MainAttributes.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (FeatureIds == null)
			{
				FeatureIds = new List<short>(elementsCount);
			}
			else
			{
				FeatureIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				FeatureIds.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			FeatureIds?.Clear();
		}
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		Transgender = *pCurrData != 0;
		pCurrData++;
		pCurrData += CombatSkillQualifications.Deserialize(pCurrData);
		CombatSkillQualificationGrowthType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += LifeSkillQualifications.Deserialize(pCurrData);
		LifeSkillQualificationGrowthType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += Personalities.Deserialize(pCurrData);
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (TeammateCommands == null)
			{
				TeammateCommands = new List<sbyte>(elementsCount2);
			}
			else
			{
				TeammateCommands.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				TeammateCommands.Add((sbyte)pCurrData[j]);
			}
			pCurrData += (int)elementsCount2;
		}
		else
		{
			TeammateCommands?.Clear();
		}
		NickNameId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		FavorabilityToTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		IsInteractedCharacter = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
