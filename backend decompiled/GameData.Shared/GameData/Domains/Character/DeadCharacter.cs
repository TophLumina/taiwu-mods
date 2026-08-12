using System.Collections.Generic;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 已死亡角色
/// </summary>
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

	/// <summary>
	/// 模板 ID
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 随机姓名
	/// </summary>
	[SerializableGameDataField]
	public FullName FullName;

	/// <summary>
	/// 法号
	/// </summary>
	[SerializableGameDataField]
	public MonasticTitle MonasticTitle;

	/// <summary>
	/// 称号列表
	/// 原计算数据
	/// </summary>
	[SerializableGameDataField]
	public List<short> TitleIds;

	/// <summary>
	/// 基本信息 - 性别
	/// 0: 女, 1: 男, -1: 未知/不限制.
	/// </summary>
	[SerializableGameDataField]
	public sbyte Gender;

	/// <summary>
	/// 基本信息 - 名誉类型
	/// 原计算数据
	/// </summary>
	[SerializableGameDataField]
	public sbyte FameType;

	/// <summary>
	/// 基本信息 - 心情
	/// (-120, -90]: 悲极, (-90, -60]: 痛苦, (-60, -30]: 沮丧, (-30, 30): 寻常, [30, 60): 开怀, [60, 90): 欢喜, [90, 120): 乐极.
	/// </summary>
	[SerializableGameDataField]
	public sbyte Happiness;

	/// <summary>
	/// 基本信息 - 立场
	/// [-500, 500]. 实际为性格的道德部分, [-500, -375]: 唯我, (-375, -125]: 叛逆, (-125, 125): 中庸, [125, 375): 仁善, [375, 500]: 刚正.
	/// </summary>
	[SerializableGameDataField]
	public short Morality;

	/// <summary>
	/// 基本信息 - 团体信息
	/// </summary>
	[SerializableGameDataField]
	public OrganizationInfo OrganizationInfo;

	/// <summary>
	/// 基本信息 - 外貌
	/// </summary>
	[SerializableGameDataField]
	public AvatarData Avatar;

	/// <summary>
	/// 基本信息 - 衣装的显示 ID
	/// </summary>
	[SerializableGameDataField]
	public short ClothingDisplayId;

	/// <summary>
	/// 基本信息 - 魅力
	/// 原缓存字段
	/// </summary>
	[SerializableGameDataField]
	public short Attraction;

	/// <summary>
	/// 基本信息 - 出生日期
	/// </summary>
	[SerializableGameDataField]
	public int BirthDate;

	/// <summary>
	/// 基本信息 - 死亡日期
	/// </summary>
	[SerializableGameDataField]
	public int DeathDate;

	/// <summary>
	/// 基本信息 - 出家类型
	/// 0: 未出家, 1: 门派道人, 2: 门派和尚, 3: 道人, 4: 和尚. 其中 1, 2 为门派出家, 有赐法号. 3, 4 为非门派出家, 无法号.
	/// </summary>
	[SerializableGameDataField]
	public byte MonkType;

	/// <summary>
	/// 基本信息 - 特性列表
	/// </summary>
	[SerializableGameDataField]
	public List<short> FeatureIds;

	/// <summary>
	/// 基础主要属性
	/// </summary>
	[SerializableGameDataField]
	public MainAttributes BaseMainAttributes;

	/// <summary>
	/// 当前年龄（真实年龄通过生日和死亡日期计算）
	/// </summary>
	[SerializableGameDataField]
	public short CurrAge;

	/// <summary>
	/// 基础技艺资质
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts BaseLifeSkillQualifications;

	/// <summary>
	/// 基础武学资质
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts BaseCombatSkillQualifications;

	/// <summary>
	/// 前世
	/// </summary>
	[SerializableGameDataField]
	public PreexistenceCharIds PreexistenceCharIds;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public DeadCharacter()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
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

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

	/// <summary>
	/// 生成能够用于显示的形象数据
	/// </summary>
	public AvatarRelatedData GenerateAvatarRelatedData()
	{
		return new AvatarRelatedData
		{
			AvatarData = new AvatarData(Avatar),
			DisplayAge = CurrAge,
			ClothingDisplayId = ClothingDisplayId
		};
	}

	/// <summary>
	/// 该角色的职位和出家状态是否允许婚配
	/// </summary>
	/// <returns>是否允许婚配</returns>
	public bool OrgAndMonkTypeAllowMarriage()
	{
		if (MonkType == 0)
		{
			return OrganizationInfo.GetOrgMemberConfig().ChildGrade >= 0;
		}
		return false;
	}

	/// <summary>
	/// 获得该角色职位对应的精纯境界
	/// </summary>
	/// <returns>职位对应的精纯境界</returns>
	public sbyte GetConsummateLevel()
	{
		return OrganizationInfo.GetOrgMemberConfig().ConsummateLevel;
	}

	/// <summary>
	/// 获取死亡时的真实年龄
	/// </summary>
	/// <returns></returns>
	public short GetActualAge()
	{
		return (short)((DeathDate - BirthDate) / 12);
	}

	/// <summary>
	/// 死人是否已经相枢入魔
	/// </summary>
	/// <returns></returns>
	public bool IsCompletelyInfected()
	{
		return FeatureIds.Contains(211);
	}

	/// <summary>
	/// 获取不包含昵称、自定义显示名.
	/// 注意该方法获取到的数据不完整，不包含自定义名相关, 外部使用获取完整的数据需要通过 CharacterDomain.GetNameRelatedData.
	/// </summary>
	/// <returns></returns>
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
