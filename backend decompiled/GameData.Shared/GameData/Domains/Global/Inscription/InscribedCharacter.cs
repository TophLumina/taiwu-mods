using System;
using System.Collections.Generic;
using System.Text;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Global.Inscription;

/// <summary>
/// 铭刻的角色
/// </summary>
/// <summary>
/// 铭刻的角色 - 属性计算相关
/// </summary>
[Serializable]
[SerializableGameData(IsExtensible = true)]
public class InscribedCharacter : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Timestamp = 0;

		public const ushort Surname = 1;

		public const ushort GivenName = 2;

		public const ushort Gender = 3;

		public const ushort ActualAge = 4;

		public const ushort CurrAge = 5;

		public const ushort BaseMaxHealth = 6;

		public const ushort Morality = 7;

		public const ushort OrganizationInfo = 8;

		public const ushort Avatar = 9;

		public const ushort ClothingDisplayId = 10;

		public const ushort BirthMonth = 11;

		public const ushort FeatureIds = 12;

		public const ushort BaseMainAttributes = 13;

		public const ushort BaseLifeSkillQualifications = 14;

		public const ushort LifeSkillQualificationGrowthType = 15;

		public const ushort BaseCombatSkillQualifications = 16;

		public const ushort CombatSkillQualificationGrowthType = 17;

		public const ushort InnateSkillQualificationBonuses = 18;

		public const ushort Count = 19;

		public static readonly string[] FieldId2FieldName = new string[19]
		{
			"Timestamp", "Surname", "GivenName", "Gender", "ActualAge", "CurrAge", "BaseMaxHealth", "Morality", "OrganizationInfo", "Avatar",
			"ClothingDisplayId", "BirthMonth", "FeatureIds", "BaseMainAttributes", "BaseLifeSkillQualifications", "LifeSkillQualificationGrowthType", "BaseCombatSkillQualifications", "CombatSkillQualificationGrowthType", "InnateSkillQualificationBonuses"
		};
	}

	/// <summary>
	/// 铭刻时间戳
	/// </summary>
	[SerializableGameDataField]
	public long Timestamp;

	/// <summary>
	/// 基本信息 - 姓
	/// </summary>
	[SerializableGameDataField]
	public string Surname;

	/// <summary>
	/// 基本信息 - 名
	/// </summary>
	[SerializableGameDataField]
	public string GivenName;

	/// <summary>
	/// 基本信息 - 性别
	/// 0: 女, 1: 男, -1: 未知/不限制.
	/// </summary>
	[SerializableGameDataField]
	public sbyte Gender;

	/// <summary>
	/// 基本信息 - 实际年龄
	/// </summary>
	[SerializableGameDataField]
	public short ActualAge;

	/// <summary>
	/// 基本信息 - 当前年龄
	/// </summary>
	[SerializableGameDataField]
	public short CurrAge;

	/// <summary>
	/// 基本信息 - 基础最大健康
	/// 以月为单位
	/// </summary>
	[SerializableGameDataField]
	public short BaseMaxHealth;

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
	/// 基本信息 - 出生月份
	/// </summary>
	[SerializableGameDataField]
	public sbyte BirthMonth;

	/// <summary>
	/// 基本信息 - 特性列表
	/// 只包括可铭刻的特性
	/// </summary>
	[SerializableGameDataField]
	public List<short> FeatureIds = new List<short>();

	/// <summary>
	/// 基础主要属性
	/// </summary>
	[SerializableGameDataField]
	public MainAttributes BaseMainAttributes;

	/// <summary>
	/// 基础技艺资质
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts BaseLifeSkillQualifications;

	/// <summary>
	/// 技艺资质成长
	/// </summary>
	[SerializableGameDataField]
	public sbyte LifeSkillQualificationGrowthType;

	/// <summary>
	/// 基础武学资质
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts BaseCombatSkillQualifications;

	/// <summary>
	/// 武学资质成长
	/// </summary>
	[SerializableGameDataField]
	public sbyte CombatSkillQualificationGrowthType;

	/// <summary>
	/// 天赋
	/// </summary>
	[SerializableGameDataField(ArrayElementsCount = 2)]
	public SkillQualificationBonus[] InnateSkillQualificationBonuses;

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
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public InscribedCharacter()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public InscribedCharacter(InscribedCharacter other)
	{
		Timestamp = other.Timestamp;
		Surname = other.Surname;
		GivenName = other.GivenName;
		Gender = other.Gender;
		ActualAge = other.ActualAge;
		CurrAge = other.CurrAge;
		BaseMaxHealth = other.BaseMaxHealth;
		Morality = other.Morality;
		OrganizationInfo = other.OrganizationInfo;
		Avatar = new AvatarData(other.Avatar);
		ClothingDisplayId = other.ClothingDisplayId;
		BirthMonth = other.BirthMonth;
		FeatureIds = ((other.FeatureIds == null) ? null : new List<short>(other.FeatureIds));
		BaseMainAttributes = other.BaseMainAttributes;
		BaseLifeSkillQualifications = other.BaseLifeSkillQualifications;
		LifeSkillQualificationGrowthType = other.LifeSkillQualificationGrowthType;
		BaseCombatSkillQualifications = other.BaseCombatSkillQualifications;
		CombatSkillQualificationGrowthType = other.CombatSkillQualificationGrowthType;
		SkillQualificationBonus[] item = other.InnateSkillQualificationBonuses;
		int elementsCount = item.Length;
		InnateSkillQualificationBonuses = new SkillQualificationBonus[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			InnateSkillQualificationBonuses[i] = item[i];
		}
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(InscribedCharacter other)
	{
		Timestamp = other.Timestamp;
		Surname = other.Surname;
		GivenName = other.GivenName;
		Gender = other.Gender;
		ActualAge = other.ActualAge;
		CurrAge = other.CurrAge;
		BaseMaxHealth = other.BaseMaxHealth;
		Morality = other.Morality;
		OrganizationInfo = other.OrganizationInfo;
		Avatar = new AvatarData(other.Avatar);
		ClothingDisplayId = other.ClothingDisplayId;
		BirthMonth = other.BirthMonth;
		FeatureIds = ((other.FeatureIds == null) ? null : new List<short>(other.FeatureIds));
		BaseMainAttributes = other.BaseMainAttributes;
		BaseLifeSkillQualifications = other.BaseLifeSkillQualifications;
		LifeSkillQualificationGrowthType = other.LifeSkillQualificationGrowthType;
		BaseCombatSkillQualifications = other.BaseCombatSkillQualifications;
		CombatSkillQualificationGrowthType = other.CombatSkillQualificationGrowthType;
		SkillQualificationBonus[] item = other.InnateSkillQualificationBonuses;
		int elementsCount = item.Length;
		InnateSkillQualificationBonuses = new SkillQualificationBonus[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			InnateSkillQualificationBonuses[i] = item[i];
		}
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
		totalSize = ((Surname == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Surname.Length)));
		totalSize = ((GivenName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * GivenName.Length)));
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
		*(short*)pCurrData = 19;
		pCurrData += 2;
		*(long*)pCurrData = Timestamp;
		pCurrData += 8;
		if (Surname != null)
		{
			int elementsCount = Surname.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = Surname)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GivenName != null)
		{
			int elementsCount2 = GivenName.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			fixed (char* pChar2 = GivenName)
			{
				for (int j = 0; j < elementsCount2; j++)
				{
					((short*)pCurrData)[j] = (short)pChar2[j];
				}
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)Gender;
		pCurrData++;
		*(short*)pCurrData = ActualAge;
		pCurrData += 2;
		*(short*)pCurrData = CurrAge;
		pCurrData += 2;
		*(short*)pCurrData = BaseMaxHealth;
		pCurrData += 2;
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
		*pCurrData = (byte)BirthMonth;
		pCurrData++;
		if (FeatureIds != null)
		{
			int elementsCount3 = FeatureIds.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = FeatureIds[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += BaseMainAttributes.Serialize(pCurrData);
		pCurrData += BaseLifeSkillQualifications.Serialize(pCurrData);
		*pCurrData = (byte)LifeSkillQualificationGrowthType;
		pCurrData++;
		pCurrData += BaseCombatSkillQualifications.Serialize(pCurrData);
		*pCurrData = (byte)CombatSkillQualificationGrowthType;
		pCurrData++;
		Tester.Assert(InnateSkillQualificationBonuses.Length == 2);
		for (int l = 0; l < 2; l++)
		{
			pCurrData += InnateSkillQualificationBonuses[l].Serialize(pCurrData);
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			Timestamp = *(long*)pCurrData;
			pCurrData += 8;
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				int fieldSize = 2 * elementsCount;
				Surname = Encoding.Unicode.GetString(pCurrData, fieldSize);
				pCurrData += fieldSize;
			}
			else
			{
				Surname = null;
			}
		}
		if (fieldCount > 2)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				int fieldSize2 = 2 * elementsCount2;
				GivenName = Encoding.Unicode.GetString(pCurrData, fieldSize2);
				pCurrData += fieldSize2;
			}
			else
			{
				GivenName = null;
			}
		}
		if (fieldCount > 3)
		{
			Gender = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 4)
		{
			ActualAge = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 5)
		{
			CurrAge = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 6)
		{
			BaseMaxHealth = *(short*)pCurrData;
			pCurrData += 2;
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
			BirthMonth = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 12)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (FeatureIds == null)
				{
					FeatureIds = new List<short>(elementsCount3);
				}
				else
				{
					FeatureIds.Clear();
				}
				for (int i = 0; i < elementsCount3; i++)
				{
					FeatureIds.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount3;
			}
			else
			{
				FeatureIds?.Clear();
			}
		}
		if (fieldCount > 13)
		{
			pCurrData += BaseMainAttributes.Deserialize(pCurrData);
		}
		if (fieldCount > 14)
		{
			pCurrData += BaseLifeSkillQualifications.Deserialize(pCurrData);
		}
		if (fieldCount > 15)
		{
			LifeSkillQualificationGrowthType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 16)
		{
			pCurrData += BaseCombatSkillQualifications.Deserialize(pCurrData);
		}
		if (fieldCount > 17)
		{
			CombatSkillQualificationGrowthType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 18)
		{
			if (InnateSkillQualificationBonuses == null || InnateSkillQualificationBonuses.Length != 2)
			{
				InnateSkillQualificationBonuses = new SkillQualificationBonus[2];
			}
			for (int j = 0; j < 2; j++)
			{
				SkillQualificationBonus element = default(SkillQualificationBonus);
				pCurrData += element.Deserialize(pCurrData);
				InnateSkillQualificationBonuses[j] = element;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <summary>
	/// 计算最大健康.
	/// 参考角色对象的方法 <see cref="!:GameData.Domains.Character.Character.CalcMaxHealth" />, 需要确保与其逻辑同步.
	/// </summary>
	/// <param name="actualAge">实际年龄</param>
	/// <returns></returns>
	public short CalcMaxHealth(short actualAge)
	{
		int percentBonus = 0;
		if (FeatureIds != null)
		{
			int i = 0;
			for (int count = FeatureIds.Count; i < count; i++)
			{
				short featureId = FeatureIds[i];
				percentBonus += CharacterFeature.Instance[featureId].MaxHealthPercentBonus;
			}
		}
		int value = BaseMaxHealth * (100 + percentBonus) / 100;
		return (short)((value >= 0) ? value : 0);
	}

	/// <summary>
	/// 计算魅力.
	/// 参考角色对象的方法 <see cref="!:GameData.Domains.Character.Character.CalcAttraction" />, 需要确保与其逻辑同步.
	/// </summary>
	/// <param name="actualAge">实际年龄</param>
	/// <param name="clothingDisplayId">衣装的显示 ID</param>
	/// <returns></returns>
	public short CalcAttraction(short actualAge, short clothingDisplayId)
	{
		if (CurrAge < 16)
		{
			return GlobalConfig.Instance.ImmaturityAttraction;
		}
		short physiologicalAge = actualAge;
		int value = Avatar.GetCharm(physiologicalAge, (byte)clothingDisplayId);
		value += GetCommonPropertyBonus(ECharacterPropertyReferencedType.Attraction);
		if (clothingDisplayId <= 0)
		{
			value /= 2;
		}
		return (short)MathUtils.Clamp(value, 0, 900);
	}

	/// <summary>
	/// 计算主要属性最大值.
	/// 参考角色对象的方法 <see cref="!:GameData.Domains.Character.Character.CalcMaxMainAttributes" />, 需要确保与其逻辑同步.
	/// </summary>
	/// <param name="actualAge">实际年龄</param>
	/// <returns></returns>
	public unsafe MainAttributes CalcMaxMainAttributes(short actualAge)
	{
		MainAttributes value = BaseMainAttributes;
		for (int i = 0; i < 6; i++)
		{
			ref short reference = ref value.Items[i];
			reference += (short)GetCommonPropertyBonus((ECharacterPropertyReferencedType)(0 + i));
		}
		short physiologicalAge = actualAge;
		int clampedAge = ((physiologicalAge <= 100) ? physiologicalAge : 100);
		MainAttributes ageInfluence = AgeEffect.Instance[clampedAge].MainAttributes;
		for (int j = 0; j < 6; j++)
		{
			value.Items[j] = (short)(value.Items[j] * ageInfluence.Items[j] / 100);
		}
		for (int k = 0; k < 6; k++)
		{
			value.Items[k] = Math.Clamp(value.Items[k], GlobalConfig.Instance.MinValueOfMaxMainAttributes, GlobalConfig.Instance.MaxValueOfMaxMainAttributes);
		}
		return value;
	}

	/// <summary>
	/// 计算技艺资质.
	/// 参考角色对象的方法 <see cref="!:GameData.Domains.Character.Character.CalcLifeSkillQualifications" />, 需要确保与其逻辑同步.
	/// </summary>
	/// <param name="actualAge">实际年龄</param>
	/// <returns></returns>
	public unsafe LifeSkillShorts CalcLifeSkillQualifications(short actualAge)
	{
		LifeSkillShorts value = BaseLifeSkillQualifications;
		for (int i = 0; i < 16; i++)
		{
			ref short reference = ref value.Items[i];
			reference += (short)GetCommonPropertyBonus((ECharacterPropertyReferencedType)(34 + i));
		}
		int j = 0;
		for (int count = InnateSkillQualificationBonuses.Length; j < count; j++)
		{
			SkillQualificationBonus bonus = InnateSkillQualificationBonuses[j];
			var (skillGroup, skillType) = bonus.GetSkillGroupAndType();
			if (skillGroup == 0)
			{
				ref short reference2 = ref value.Items[skillType];
				reference2 += bonus.Bonus;
			}
		}
		int clampedAge = ((actualAge <= 100) ? actualAge : 100);
		AgeEffectItem ageEffectCfg = AgeEffect.Instance[clampedAge];
		sbyte ageBonus = LifeSkillQualificationGrowthType switch
		{
			0 => ageEffectCfg.SkillQualificationAverage, 
			1 => ageEffectCfg.SkillQualificationPrecocious, 
			2 => ageEffectCfg.SkillQualificationLateBlooming, 
			_ => throw new Exception($"Unsupported LifeSkillQualificationGrowthType: {LifeSkillQualificationGrowthType}"), 
		};
		for (int k = 0; k < 16; k++)
		{
			ref short reference3 = ref value.Items[k];
			reference3 += ageBonus;
		}
		if (clampedAge < 16)
		{
			for (int l = 0; l < 16; l++)
			{
				value.Items[l] = (short)(value.Items[l] * clampedAge / 16);
			}
		}
		for (int m = 0; m < 16; m++)
		{
			if (value.Items[m] < 0)
			{
				value.Items[m] = 0;
			}
		}
		return value;
	}

	/// <summary>
	/// 计算武学资质.
	/// 参考角色对象的方法 <see cref="!:GameData.Domains.Character.Character.CalcCombatSkillQualifications" />, 需要确保与其逻辑同步.
	/// </summary>
	/// <param name="actualAge">实际年龄</param>
	/// <returns></returns>
	public unsafe CombatSkillShorts CalcCombatSkillQualifications(short actualAge)
	{
		CombatSkillShorts value = BaseCombatSkillQualifications;
		for (int i = 0; i < 14; i++)
		{
			ref short reference = ref value.Items[i];
			reference += (short)GetCommonPropertyBonus((ECharacterPropertyReferencedType)(66 + i));
		}
		int j = 0;
		for (int count = InnateSkillQualificationBonuses.Length; j < count; j++)
		{
			SkillQualificationBonus bonus = InnateSkillQualificationBonuses[j];
			var (skillGroup, skillType) = bonus.GetSkillGroupAndType();
			if (skillGroup == 1)
			{
				ref short reference2 = ref value.Items[skillType];
				reference2 += bonus.Bonus;
			}
		}
		int clampedAge = ((actualAge <= 100) ? actualAge : 100);
		AgeEffectItem ageEffectCfg = AgeEffect.Instance[clampedAge];
		sbyte ageBonus = CombatSkillQualificationGrowthType switch
		{
			0 => ageEffectCfg.SkillQualificationAverage, 
			1 => ageEffectCfg.SkillQualificationPrecocious, 
			2 => ageEffectCfg.SkillQualificationLateBlooming, 
			_ => throw new Exception($"Unsupported CombatSkillQualificationGrowthType: {CombatSkillQualificationGrowthType}"), 
		};
		for (int k = 0; k < 14; k++)
		{
			ref short reference3 = ref value.Items[k];
			reference3 += ageBonus;
		}
		if (clampedAge < 16)
		{
			for (int l = 0; l < 14; l++)
			{
				value.Items[l] = (short)(value.Items[l] * clampedAge / 16);
			}
		}
		for (int m = 0; m < 14; m++)
		{
			if (value.Items[m] < 0)
			{
				value.Items[m] = 0;
			}
		}
		return value;
	}

	/// <summary>
	/// 获取人物属性的通用附加值.
	/// 铭刻人物只包括特性的通用附加值.
	/// 参考角色对象的方法 <see cref="!:GameData.Domains.Character.Character.GetCommonPropertyBonus" />, 需要确保与其逻辑同步.
	/// </summary>
	/// <param name="propertyType"></param>
	/// <returns></returns>
	private int GetCommonPropertyBonus(ECharacterPropertyReferencedType propertyType)
	{
		if (FeatureIds != null)
		{
			return CharacterFeature.GetCharacterPropertyBonus(FeatureIds, propertyType);
		}
		return 0;
	}
}
