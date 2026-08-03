using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Display;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

/// <summary>
/// 招募角色信息
/// <para>用于存储已经预招募的角色。如此方可用于预览，以及用此数据创建真正的角色。</para>
/// </summary>
[SerializableGameData(IsExtensible = true, NotRestrictCollectionSerializedSize = true)]
public class RecruitCharacterData : ISerializableGameData, ITradeableContent
{
	private static class FieldIds
	{
		public const ushort TemplateId = 0;

		public const ushort PeopleLevel = 1;

		public const ushort Age = 2;

		public const ushort FullName = 3;

		public const ushort BaseAttraction = 4;

		public const ushort AvatarData = 5;

		public const ushort MainAttributes = 6;

		public const ushort FeatureIds = 7;

		public const ushort Gender = 8;

		public const ushort Transgender = 9;

		public const ushort CombatSkillQualifications = 10;

		public const ushort CombatSkillQualificationGrowthType = 11;

		public const ushort LifeSkillQualifications = 12;

		public const ushort LifeSkillQualificationGrowthType = 13;

		public const ushort CalculatedPersonalities = 14;

		public const ushort ClothingTemplateId = 15;

		public const ushort TeammateCommands = 16;

		public const ushort BirthMonth = 17;

		public const ushort FinalAttraction = 18;

		public const ushort Count = 19;

		public static readonly string[] FieldId2FieldName = new string[19]
		{
			"TemplateId", "PeopleLevel", "Age", "FullName", "BaseAttraction", "AvatarData", "MainAttributes", "FeatureIds", "Gender", "Transgender",
			"CombatSkillQualifications", "CombatSkillQualificationGrowthType", "LifeSkillQualifications", "LifeSkillQualificationGrowthType", "CalculatedPersonalities", "ClothingTemplateId", "TeammateCommands", "BirthMonth", "FinalAttraction"
		};
	}

	/// <summary>
	/// 人物模板ID
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 人物等级
	/// </summary>
	[SerializableGameDataField]
	public sbyte PeopleLevel;

	/// <summary>
	/// 年龄
	/// </summary>
	[SerializableGameDataField]
	public short Age;

	/// <summary>
	/// 姓名
	/// </summary>
	[SerializableGameDataField]
	public FullName FullName;

	/// <summary>
	/// 基础魅力
	/// </summary>
	[SerializableGameDataField]
	public short BaseAttraction;

	/// <summary>
	/// 外貌
	/// </summary>
	[SerializableGameDataField]
	public AvatarData AvatarData;

	/// <summary>
	/// 主属性
	/// </summary>
	[SerializableGameDataField]
	public MainAttributes MainAttributes;

	/// <summary>
	/// 特性列表
	/// </summary>
	[SerializableGameDataField]
	public List<short> FeatureIds;

	/// <summary>
	/// 性别
	/// </summary>
	[SerializableGameDataField]
	public sbyte Gender;

	/// <summary>
	/// 异性相
	/// </summary>
	[SerializableGameDataField]
	public bool Transgender;

	/// <summary>
	/// 武学资质
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillQualifications;

	/// <summary>
	/// 武学资质成长类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte CombatSkillQualificationGrowthType;

	/// <summary>
	/// 技艺资质
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillQualifications;

	/// <summary>
	/// 技艺资质成长类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte LifeSkillQualificationGrowthType;

	/// <summary>
	/// 计算出的七元，通常仅显示用
	/// </summary>
	[SerializableGameDataField]
	public Personalities CalculatedPersonalities;

	/// <summary>
	/// 衣服模板 Id
	/// </summary>
	[SerializableGameDataField]
	public short ClothingTemplateId;

	/// <summary>
	/// 队友指令组
	/// </summary>
	[SerializableGameDataField]
	public List<sbyte> TeammateCommands;

	/// <summary>
	/// 出生月份
	/// </summary>
	[SerializableGameDataField]
	public sbyte BirthMonth;

	/// <summary>
	/// 最终魅力，尽可能接近正式计算值
	/// </summary>
	[SerializableGameDataField]
	public short FinalAttraction;

	public bool Interactable { get; set; }

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
			return (int)Math.Clamp(Wager.CharacterValue(0, BaseAttraction, Grade, AvatarData.Gender, Age), 0L, 2147483647L);
		}
		set
		{
		}
	}

	public sbyte Grade => PeopleLevel;

	sbyte ITradeableContent.Gender => Gender;

	int ITradeableContent.CharacterId => 0;

	NameRelatedData ITradeableContent.NameRelatedData => new NameRelatedData(FullName, Gender);

	AvatarRelatedData ITradeableContent.AvatarRelatedData => new AvatarRelatedData
	{
		AvatarData = AvatarData,
		ClothingDisplayId = ClothingTemplateId,
		HasNewGoods = false
	};

	/// <summary>
	/// 重新计算一些显示字段
	/// </summary>
	public unsafe void Recalculate()
	{
		for (int i = 0; i < 7; i++)
		{
			ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)(94 + i);
			int personality = 10;
			if (FeatureIds != null)
			{
				foreach (short featureId in FeatureIds)
				{
					int value = CharacterFeature.GetCharacterPropertyBonus(featureId, propertyType);
					personality += value;
				}
			}
			CalculatedPersonalities.Items[i] = (sbyte)Math.Clamp(personality, 0, 100);
		}
	}

	/// <summary>
	/// 获取基础立场值
	/// </summary>
	public unsafe short GetBaseMorality()
	{
		long seed = BaseAttraction % 10;
		for (int i = 0; i < 6; i++)
		{
			seed += MainAttributes.Items[i];
		}
		seed = (1664525 * seed + 1013904223) % 4294967296L;
		return (short)Math.Clamp(seed % 1001 + -500, -500L, 500L);
	}

	/// <summary>
	/// 生成能够用于显示的形象数据
	/// </summary>
	public AvatarRelatedData GenerateAvatarRelatedData()
	{
		ClothingItem clothingConfig = Clothing.Instance.GetItem(ClothingTemplateId);
		return new AvatarRelatedData
		{
			AvatarData = AvatarData,
			ClothingDisplayId = (clothingConfig?.DisplayId ?? 0),
			DisplayAge = Age,
			HasNewGoods = false
		};
	}

	/// <summary>
	/// 获得助阵指令
	/// <para><paramref name="receiver" />在调用前需要手动清空</para>
	/// </summary>
	public void GetTeammateCommands(IList<sbyte> receiver)
	{
		if (TeammateCommands == null)
		{
			return;
		}
		foreach (sbyte command in TeammateCommands)
		{
			receiver.Add(command);
		}
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public RecruitCharacterData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public RecruitCharacterData(RecruitCharacterData other)
	{
		TemplateId = other.TemplateId;
		PeopleLevel = other.PeopleLevel;
		Age = other.Age;
		FullName = other.FullName;
		BaseAttraction = other.BaseAttraction;
		AvatarData = new AvatarData(other.AvatarData);
		MainAttributes = other.MainAttributes;
		FeatureIds = ((other.FeatureIds == null) ? null : new List<short>(other.FeatureIds));
		Gender = other.Gender;
		Transgender = other.Transgender;
		CombatSkillQualifications = other.CombatSkillQualifications;
		CombatSkillQualificationGrowthType = other.CombatSkillQualificationGrowthType;
		LifeSkillQualifications = other.LifeSkillQualifications;
		LifeSkillQualificationGrowthType = other.LifeSkillQualificationGrowthType;
		CalculatedPersonalities = other.CalculatedPersonalities;
		ClothingTemplateId = other.ClothingTemplateId;
		TeammateCommands = ((other.TeammateCommands == null) ? null : new List<sbyte>(other.TeammateCommands));
		BirthMonth = other.BirthMonth;
		FinalAttraction = other.FinalAttraction;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(RecruitCharacterData other)
	{
		TemplateId = other.TemplateId;
		PeopleLevel = other.PeopleLevel;
		Age = other.Age;
		FullName = other.FullName;
		BaseAttraction = other.BaseAttraction;
		AvatarData = new AvatarData(other.AvatarData);
		MainAttributes = other.MainAttributes;
		FeatureIds = ((other.FeatureIds == null) ? null : new List<short>(other.FeatureIds));
		Gender = other.Gender;
		Transgender = other.Transgender;
		CombatSkillQualifications = other.CombatSkillQualifications;
		CombatSkillQualificationGrowthType = other.CombatSkillQualificationGrowthType;
		LifeSkillQualifications = other.LifeSkillQualifications;
		LifeSkillQualificationGrowthType = other.LifeSkillQualificationGrowthType;
		CalculatedPersonalities = other.CalculatedPersonalities;
		ClothingTemplateId = other.ClothingTemplateId;
		TeammateCommands = ((other.TeammateCommands == null) ? null : new List<sbyte>(other.TeammateCommands));
		BirthMonth = other.BirthMonth;
		FinalAttraction = other.FinalAttraction;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 108;
		totalSize = ((AvatarData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarData.GetSerializedSize())));
		totalSize = ((FeatureIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * FeatureIds.Count)));
		totalSize = ((TeammateCommands == null) ? (totalSize + 2) : (totalSize + (2 + TeammateCommands.Count)));
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
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*pCurrData = (byte)PeopleLevel;
		pCurrData++;
		*(short*)pCurrData = Age;
		pCurrData += 2;
		pCurrData += FullName.Serialize(pCurrData);
		*(short*)pCurrData = BaseAttraction;
		pCurrData += 2;
		if (AvatarData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = AvatarData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		pCurrData += CalculatedPersonalities.Serialize(pCurrData);
		*(short*)pCurrData = ClothingTemplateId;
		pCurrData += 2;
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
		*pCurrData = (byte)BirthMonth;
		pCurrData++;
		*(short*)pCurrData = FinalAttraction;
		pCurrData += 2;
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
			PeopleLevel = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			Age = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 3)
		{
			pCurrData += FullName.Deserialize(pCurrData);
		}
		if (fieldCount > 4)
		{
			BaseAttraction = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 5)
		{
			ushort num = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num > 0)
			{
				if (AvatarData == null)
				{
					AvatarData = new AvatarData();
				}
				pCurrData += AvatarData.Deserialize(pCurrData);
			}
			else
			{
				AvatarData = null;
			}
		}
		if (fieldCount > 6)
		{
			pCurrData += MainAttributes.Deserialize(pCurrData);
		}
		if (fieldCount > 7)
		{
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
		}
		if (fieldCount > 8)
		{
			Gender = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 9)
		{
			Transgender = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 10)
		{
			pCurrData += CombatSkillQualifications.Deserialize(pCurrData);
		}
		if (fieldCount > 11)
		{
			CombatSkillQualificationGrowthType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 12)
		{
			pCurrData += LifeSkillQualifications.Deserialize(pCurrData);
		}
		if (fieldCount > 13)
		{
			LifeSkillQualificationGrowthType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 14)
		{
			pCurrData += CalculatedPersonalities.Deserialize(pCurrData);
		}
		if (fieldCount > 15)
		{
			ClothingTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 16)
		{
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
		}
		if (fieldCount > 17)
		{
			BirthMonth = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 18)
		{
			FinalAttraction = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public ITradeableContent Clone(int amount = -1)
	{
		return new RecruitCharacterData(this);
	}

	public sbyte GetContentType()
	{
		return -1;
	}
}
