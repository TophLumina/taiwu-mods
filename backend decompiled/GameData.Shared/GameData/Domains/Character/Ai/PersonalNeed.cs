using System;
using System.Runtime.InteropServices;
using Config;
using GameData.Domains.Character.Relation;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Character.Ai;

[Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct PersonalNeed : ISerializableGameData
{
	[FieldOffset(0)]
	public sbyte TemplateId;

	[FieldOffset(1)]
	public sbyte RemainingMonths;

	[FieldOffset(2)]
	public sbyte PoisonType;

	[FieldOffset(2)]
	public sbyte InjuryType;

	[FieldOffset(2)]
	public sbyte MainAttributeType;

	[FieldOffset(2)]
	public sbyte WugType;

	[FieldOffset(2)]
	public sbyte ResourceType;

	[FieldOffset(2)]
	public sbyte ItemType;

	[FieldOffset(2)]
	public sbyte LifeSkillType;

	[FieldOffset(2)]
	public sbyte CombatSkillType;

	[FieldOffset(2)]
	public ushort RelationType;

	[FieldOffset(2)]
	public sbyte OrgTemplateId;

	[FieldOffset(4)]
	public int Amount;

	[FieldOffset(4)]
	public short ItemTemplateId;

	[FieldOffset(4)]
	public short CombatSkillTemplateId;

	[FieldOffset(4)]
	public int CharId;

	[FieldOffset(4)]
	public int ItemId;

	[FieldOffset(4)]
	public Location Location;

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
