using System.Collections.Generic;
using Config;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

[SerializableGameData(IsExtensible = true)]
public class DeadCharacter : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort TemplateId = 0;

		public const ushort FullName = 1;

		public const ushort MonasticTitle = 2;

		public const ushort TitleIds = 3;

		public const ushort Gender = 4;

		public const ushort FameType = 5;

		public const ushort Happiness = 6;

		public const ushort Morality = 7;

		public const ushort OrganizationInfo = 8;

		public const ushort Avatar = 9;

		public const ushort ClothingDisplayId = 10;

		public const ushort Attraction = 11;

		public const ushort BirthDate = 12;

		public const ushort DeathDate = 13;

		public const ushort MonkType = 14;

		public const ushort FeatureIds = 15;

		public const ushort BaseMainAttributes = 16;

		public const ushort CurrAge = 17;

		public const ushort BaseLifeSkillQualifications = 18;

		public const ushort BaseCombatSkillQualifications = 19;

		public const ushort PreexistenceCharIds = 20;

		public const ushort Count = 21;

		public static readonly string[] FieldId2FieldName = new string[21]
		{
			"TemplateId", "FullName", "MonasticTitle", "TitleIds", "Gender", "FameType", "Happiness", "Morality", "OrganizationInfo", "Avatar",
			"ClothingDisplayId", "Attraction", "BirthDate", "DeathDate", "MonkType", "FeatureIds", "BaseMainAttributes", "CurrAge", "BaseLifeSkillQualifications", "BaseCombatSkillQualifications",
			"PreexistenceCharIds"
		};
	}

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public FullName FullName;

	[SerializableGameDataField]
	public MonasticTitle MonasticTitle;

	[SerializableGameDataField]
	public List<short> TitleIds;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public sbyte FameType;

	[SerializableGameDataField]
	public sbyte Happiness;

	[SerializableGameDataField]
	public short Morality;

	[SerializableGameDataField]
	public OrganizationInfo OrganizationInfo;

	[SerializableGameDataField]
	public AvatarData Avatar;

	[SerializableGameDataField]
	public short ClothingDisplayId;

	[SerializableGameDataField]
	public short Attraction;

	[SerializableGameDataField]
	public int BirthDate;

	[SerializableGameDataField]
	public int DeathDate;

	[SerializableGameDataField]
	public byte MonkType;

	[SerializableGameDataField]
	public List<short> FeatureIds;

	[SerializableGameDataField]
	public MainAttributes BaseMainAttributes;

	[SerializableGameDataField]
	public short CurrAge;

	[SerializableGameDataField]
	public LifeSkillShorts BaseLifeSkillQualifications;

	[SerializableGameDataField]
	public CombatSkillShorts BaseCombatSkillQualifications;

	[SerializableGameDataField]
	public PreexistenceCharIds PreexistenceCharIds;

	public DeadCharacter()
	{
	}

	public DeadCharacter(DeadCharacter other)
	{
		TemplateId = other.TemplateId;
		FullName = other.FullName;
		MonasticTitle = other.MonasticTitle;
		TitleIds = ((other.TitleIds == null) ? null : new List<short>(other.TitleIds));
		Gender = other.Gender;
		FameType = other.FameType;
		Happiness = other.Happiness;
		Morality = other.Morality;
		OrganizationInfo = other.OrganizationInfo;
		Avatar = new AvatarData(other.Avatar);
		ClothingDisplayId = other.ClothingDisplayId;
		Attraction = other.Attraction;
		BirthDate = other.BirthDate;
		DeathDate = other.DeathDate;
		MonkType = other.MonkType;
		FeatureIds = ((other.FeatureIds == null) ? null : new List<short>(other.FeatureIds));
		BaseMainAttributes = other.BaseMainAttributes;
		CurrAge = other.CurrAge;
		BaseLifeSkillQualifications = other.BaseLifeSkillQualifications;
		BaseCombatSkillQualifications = other.BaseCombatSkillQualifications;
		PreexistenceCharIds = other.PreexistenceCharIds;
	}

	public void Assign(DeadCharacter other)
	{
		TemplateId = other.TemplateId;
		FullName = other.FullName;
		MonasticTitle = other.MonasticTitle;
		TitleIds = ((other.TitleIds == null) ? null : new List<short>(other.TitleIds));
		Gender = other.Gender;
		FameType = other.FameType;
		Happiness = other.Happiness;
		Morality = other.Morality;
		OrganizationInfo = other.OrganizationInfo;
		Avatar = new AvatarData(other.Avatar);
		ClothingDisplayId = other.ClothingDisplayId;
		Attraction = other.Attraction;
		BirthDate = other.BirthDate;
		DeathDate = other.DeathDate;
		MonkType = other.MonkType;
		FeatureIds = ((other.FeatureIds == null) ? null : new List<short>(other.FeatureIds));
		BaseMainAttributes = other.BaseMainAttributes;
		CurrAge = other.CurrAge;
		BaseLifeSkillQualifications = other.BaseLifeSkillQualifications;
		BaseCombatSkillQualifications = other.BaseCombatSkillQualifications;
		PreexistenceCharIds = other.PreexistenceCharIds;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 158;
		totalSize = ((TitleIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TitleIds.Count)));
		totalSize = ((Avatar == null) ? (totalSize + 2) : (totalSize + (2 + Avatar.GetSerializedSize())));
		totalSize = ((FeatureIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * FeatureIds.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 21;
		pCurrData += 2;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		pCurrData += FullName.Serialize(pCurrData);
		pCurrData += MonasticTitle.Serialize(pCurrData);
		if (TitleIds != null)
		{
			int elementsCount = TitleIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = TitleIds[i];
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
		*pCurrData = (byte)FameType;
		pCurrData++;
		*pCurrData = (byte)Happiness;
		pCurrData++;
		*(short*)pCurrData = Morality;
		pCurrData += 2;
		pCurrData += OrganizationInfo.Serialize(pCurrData);
		if (Avatar != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Avatar.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = ClothingDisplayId;
		pCurrData += 2;
		*(short*)pCurrData = Attraction;
		pCurrData += 2;
		*(int*)pCurrData = BirthDate;
		pCurrData += 4;
		*(int*)pCurrData = DeathDate;
		pCurrData += 4;
		*pCurrData = MonkType;
		pCurrData++;
		if (FeatureIds != null)
		{
			int elementsCount2 = FeatureIds.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((short*)pCurrData)[j] = FeatureIds[j];
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += BaseMainAttributes.Serialize(pCurrData);
		*(short*)pCurrData = CurrAge;
		pCurrData += 2;
		pCurrData += BaseLifeSkillQualifications.Serialize(pCurrData);
		pCurrData += BaseCombatSkillQualifications.Serialize(pCurrData);
		pCurrData += PreexistenceCharIds.Serialize(pCurrData);
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			TemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 1)
		{
			pCurrData += FullName.Deserialize(pCurrData);
		}
		if (fieldCount > 2)
		{
			pCurrData += MonasticTitle.Deserialize(pCurrData);
		}
		if (fieldCount > 3)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (TitleIds == null)
				{
					TitleIds = new List<short>(elementsCount);
				}
				else
				{
					TitleIds.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					TitleIds.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				TitleIds?.Clear();
			}
		}
		if (fieldCount > 4)
		{
			Gender = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 5)
		{
			FameType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 6)
		{
			Happiness = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 7)
		{
			Morality = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 8)
		{
			pCurrData += OrganizationInfo.Deserialize(pCurrData);
		}
		if (fieldCount > 9)
		{
			ushort num = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num > 0)
			{
				if (Avatar == null)
				{
					Avatar = new AvatarData();
				}
				pCurrData += Avatar.Deserialize(pCurrData);
			}
			else
			{
				Avatar = null;
			}
		}
		if (fieldCount > 10)
		{
			ClothingDisplayId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 11)
		{
			Attraction = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 12)
		{
			BirthDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 13)
		{
			DeathDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 14)
		{
			MonkType = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 15)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (FeatureIds == null)
				{
					FeatureIds = new List<short>(elementsCount2);
				}
				else
				{
					FeatureIds.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					FeatureIds.Add(((short*)pCurrData)[j]);
				}
				pCurrData += 2 * elementsCount2;
			}
			else
			{
				FeatureIds?.Clear();
			}
		}
		if (fieldCount > 16)
		{
			pCurrData += BaseMainAttributes.Deserialize(pCurrData);
		}
		if (fieldCount > 17)
		{
			CurrAge = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 18)
		{
			pCurrData += BaseLifeSkillQualifications.Deserialize(pCurrData);
		}
		if (fieldCount > 19)
		{
			pCurrData += BaseCombatSkillQualifications.Deserialize(pCurrData);
		}
		if (fieldCount > 20)
		{
			pCurrData += PreexistenceCharIds.Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public AvatarRelatedData GenerateAvatarRelatedData()
	{
		return new AvatarRelatedData
		{
			AvatarData = new AvatarData(Avatar),
			DisplayAge = CurrAge,
			ClothingDisplayId = ClothingDisplayId
		};
	}

	public bool OrgAndMonkTypeAllowMarriage()
	{
		if (MonkType == 0)
		{
			OrganizationMemberItem orgMemberConfig = OrganizationInfo.GetOrgMemberConfig();
			if (orgMemberConfig != null)
			{
				sbyte[] childGrade = orgMemberConfig.ChildGrade;
				if (childGrade != null)
				{
					return childGrade.Length > 0;
				}
			}
			return false;
		}
		return false;
	}

	public sbyte GetConsummateLevel()
	{
		return OrganizationInfo.GetOrgMemberConfig().ConsummateLevel;
	}

	public short GetActualAge()
	{
		return (short)((DeathDate - BirthDate) / 12);
	}

	public bool IsCompletelyInfected()
	{
		return FeatureIds.Contains(211);
	}

	public NameRelatedData GetRawNameRelatedData()
	{
		NameRelatedData result = new NameRelatedData();
		result.CharTemplateId = TemplateId;
		result.Gender = Gender;
		result.MonkType = MonkType;
		result.FullName = FullName;
		result.OrgTemplateId = OrganizationInfo.OrgTemplateId;
		result.OrgGrade = OrganizationInfo.Grade;
		result.MonasticTitle = MonasticTitle;
		result.ExtraNameTextTemplateId = -1;
		return result;
	}

	public override string ToString()
	{
		(string, string) name = GetRawNameRelatedData().GetMonasticTitleOrDisplayName(isTaiwu: false);
		return $"{OrganizationInfo}-{name.Item1}{name.Item2}";
	}
}
