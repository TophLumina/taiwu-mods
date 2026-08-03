using System;
using System.Runtime.InteropServices;
using Config;
using GameData.Domains.Character.Relation;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Character.Ai;

/// <summary>
/// 角色的个人需求
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct PersonalNeed : ISerializableGameData
{
	/// <summary>
	/// 需求的模板 Id
	/// </summary>
	[FieldOffset(0)]
	public sbyte TemplateId;

	/// <summary>
	/// 需求的剩余时间
	/// </summary>
	[FieldOffset(1)]
	public sbyte RemainingMonths;

	/// <summary>
	/// 需要解毒的类型 <see cref="T:GameData.Domains.Combat.PoisonType" />
	/// </summary>
	[FieldOffset(2)]
	public sbyte PoisonType;

	/// <summary>
	/// 需要治疗的伤势类型 <see cref="T:GameData.Domains.Character.InjuryType" />
	/// </summary>
	[FieldOffset(2)]
	public sbyte InjuryType;

	/// <summary>
	/// 需求的主要属性类型 <see cref="T:GameData.Domains.Character.MainAttributeType" />
	/// </summary>
	[FieldOffset(2)]
	public sbyte MainAttributeType;

	/// <summary>
	/// 需要处理的蛊的类型 <see cref="T:GameData.Domains.Item.WugType" />
	/// </summary>
	[FieldOffset(2)]
	public sbyte WugType;

	/// <summary>
	/// 需求的资源类型 <see cref="T:GameData.Domains.Character.ResourceType" />
	/// </summary>
	[FieldOffset(2)]
	public sbyte ResourceType;

	/// <summary>
	/// 需求的物品类型 <see cref="T:GameData.Domains.Item.ItemType" />
	/// </summary>
	[FieldOffset(2)]
	public sbyte ItemType;

	/// <summary>
	/// 需求的技艺类型 <see cref="T:GameData.Domains.Character.LifeSkillType" />
	/// </summary>
	[FieldOffset(2)]
	public sbyte LifeSkillType;

	/// <summary>
	/// 需求的功法类型 <see cref="T:GameData.Domains.CombatSkill.CombatSkillType" />
	/// </summary>
	[FieldOffset(2)]
	public sbyte CombatSkillType;

	/// <summary>
	/// 需求的关系类型 <see cref="T:GameData.Domains.Character.Relation.RelationType" />
	/// </summary>
	[FieldOffset(2)]
	public ushort RelationType;

	/// <summary>
	/// 组织模板ID <see cref="F:Config.OrganizationItem.TemplateId" />
	/// </summary>
	[FieldOffset(2)]
	public sbyte OrgTemplateId;

	/// <summary>
	/// 需求 获得/使用 的数量
	/// </summary>
	[FieldOffset(4)]
	public int Amount;

	/// <summary>
	/// 需求物品的模板Id
	/// </summary>
	[FieldOffset(4)]
	public short ItemTemplateId;

	/// <summary>
	/// 需求的功法的模板Id
	/// </summary>
	[FieldOffset(4)]
	public short CombatSkillTemplateId;

	/// <summary>
	/// 需求的目标角色的Id
	/// </summary>
	[FieldOffset(4)]
	public int CharId;

	/// <summary>
	/// 需求的目标物品的实例Id
	/// </summary>
	[FieldOffset(4)]
	public int ItemId;

	/// <summary>
	/// 需求的目标位置的Id
	/// </summary>
	[FieldOffset(4)]
	public Location Location;

	/// <summary>
	/// 对比两个需求是否为同类需求。默认只比较模板ID，如果是要求目标类型匹配的需求则还需要比较目标类型
	/// </summary>
	/// <param name="personalNeedA"></param>
	/// <param name="personalNeedB"></param>
	/// <returns>两个需求是否为同类需求</returns>
	public static bool MatchType(PersonalNeed personalNeedA, PersonalNeed personalNeedB)
	{
		if (personalNeedA.TemplateId != personalNeedB.TemplateId)
		{
			return false;
		}
		if (Config.PersonalNeed.Instance[personalNeedA.TemplateId].MatchType)
		{
			return personalNeedA.RelationType == personalNeedB.RelationType;
		}
		return true;
	}

	public override string ToString()
	{
		switch (TemplateId)
		{
		case 4:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{InjuryType}-{Amount}";
		case 5:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{Poison.Instance[PoisonType].Name}-{Amount}";
		case 6:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{CharacterPropertyDisplay.Instance[MainAttributeType].Name}-{Amount}";
		case 7:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{WugType}-{Amount}";
		case 8:
		case 9:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{Config.ResourceType.Instance[ResourceType].Name}-{Amount}";
		case 10:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{ItemTemplateHelper.GetName(ItemType, ItemTemplateId)}";
		case 11:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{ItemId}";
		case 12:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{Poison.Instance[PoisonType].Name}";
		case 13:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{Amount}";
		case 14:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{Config.CombatSkillType.Instance[CombatSkillType].Name}";
		case 15:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{Config.LifeSkillType.Instance[LifeSkillType].Name}";
		case 17:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{ItemTemplateHelper.GetName(ItemType, ItemTemplateId)}";
		case 18:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{Config.CombatSkill.Instance[CombatSkillTemplateId].Name}";
		case 24:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-({Location.AreaId},{Location.BlockId})";
		case 25:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{GameData.Domains.Character.Relation.RelationType.GetTypeId(RelationType)}";
		case 26:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{Config.Organization.Instance[OrgTemplateId]}";
		default:
			return $"{Config.PersonalNeed.Instance[TemplateId].Name}({RemainingMonths})-{Amount}";
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 8;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)TemplateId;
		pData[1] = (byte)RemainingMonths;
		((short*)pData)[1] = (short)RelationType;
		((int*)pData)[1] = Amount;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		TemplateId = (sbyte)(*pData);
		RemainingMonths = (sbyte)pData[1];
		RelationType = ((ushort*)pData)[1];
		Amount = ((int*)pData)[1];
		return 8;
	}

	public static PersonalNeed CreatePersonalNeed(sbyte templateId, sbyte type, int amount)
	{
		return new PersonalNeed
		{
			TemplateId = templateId,
			RemainingMonths = Config.PersonalNeed.Instance[templateId].Duration,
			PoisonType = type,
			Amount = amount
		};
	}

	public static PersonalNeed CreatePersonalNeed(sbyte templateId, sbyte itemType, short itemTemplateId)
	{
		return new PersonalNeed
		{
			TemplateId = templateId,
			RemainingMonths = Config.PersonalNeed.Instance[templateId].Duration,
			ItemType = itemType,
			ItemTemplateId = itemTemplateId
		};
	}

	public static PersonalNeed CreatePersonalNeed(sbyte templateId, short combatSkillTemplateId)
	{
		return new PersonalNeed
		{
			TemplateId = templateId,
			RemainingMonths = Config.PersonalNeed.Instance[templateId].Duration,
			CombatSkillTemplateId = combatSkillTemplateId
		};
	}

	public static PersonalNeed CreatePersonalNeed(sbyte templateId, Location location)
	{
		return new PersonalNeed
		{
			TemplateId = templateId,
			RemainingMonths = Config.PersonalNeed.Instance[templateId].Duration,
			Location = location
		};
	}

	public static PersonalNeed CreatePersonalNeed(sbyte templateId, int charIdOrAmount)
	{
		return new PersonalNeed
		{
			TemplateId = templateId,
			RemainingMonths = Config.PersonalNeed.Instance[templateId].Duration,
			CharId = charIdOrAmount
		};
	}

	public static PersonalNeed CreatePersonalNeed(sbyte templateId, ushort relationType)
	{
		return new PersonalNeed
		{
			TemplateId = templateId,
			RemainingMonths = Config.PersonalNeed.Instance[templateId].Duration,
			RelationType = relationType
		};
	}

	public static PersonalNeed CreatePersonalNeed(sbyte templateId, sbyte type)
	{
		return new PersonalNeed
		{
			TemplateId = templateId,
			RemainingMonths = Config.PersonalNeed.Instance[templateId].Duration,
			PoisonType = type
		};
	}

	public static PersonalNeed CreatePersonalNeedKillWug(sbyte wugType)
	{
		sbyte templateId = 7;
		return new PersonalNeed
		{
			TemplateId = templateId,
			RemainingMonths = Config.PersonalNeed.Instance[templateId].Duration,
			WugType = wugType
		};
	}
}
