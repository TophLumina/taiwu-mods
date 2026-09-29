using System;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.LifeRecord.GeneralRecord;

[SerializableGameData(NotForDisplayModule = true)]
public class WriteableRecordCollection : ReadonlyRecordCollection
{
	private const int DefaultInitialCapacity = 1024;

	public WriteableRecordCollection()
		: this(1024)
	{
	}

	public WriteableRecordCollection(int initialCapacity)
		: base(initialCapacity)
	{
	}

	protected int BeginAddingRecord(short recordType)
	{
		throw new NotImplementedException();
	}

	protected unsafe void EndAddingRecord(int beginOffset)
	{
		int size = Size - beginOffset;
		if (size > 255)
		{
			throw new Exception("Record exceeded the max size");
		}
		fixed (byte* pRawData = RawData)
		{
			pRawData[beginOffset] = (byte)size;
		}
		int count = base.Count + 1;
		base.Count = count;
	}

	protected unsafe void AppendCharacter(int charId)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = charId;
		}
	}

	protected unsafe void AppendLocation(Location location)
	{
		int offset = Size;
		int newSize = Size + 2 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(short*)num = location.AreaId;
			((short*)num)[1] = location.BlockId;
		}
	}

	protected unsafe void AppendItem(sbyte itemType, short itemTemplateId)
	{
		int offset = Size;
		int newSize = Size + 1 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*num = (byte)itemType;
			*(short*)(num + 1) = itemTemplateId;
		}
	}

	protected unsafe void AppendCombatSkill(short combatSkillTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = combatSkillTemplateId;
		}
	}

	protected unsafe void AppendResource(sbyte resourceType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)resourceType;
		}
	}

	protected unsafe void AppendSettlement(short settlementId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = settlementId;
		}
	}

	protected unsafe void AppendOrgGrade(sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int offset = Size;
		int newSize = Size + 1 + 1 + 1 + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*num = (byte)orgTemplateId;
			num[1] = (byte)orgGrade;
			(num + 1)[1] = (orgPrincipal ? ((byte)1) : ((byte)0));
			(num + 1 + 1)[1] = (byte)gender;
		}
	}

	protected unsafe void AppendBuilding(short buildingTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = buildingTemplateId;
		}
	}

	protected unsafe void AppendSwordTomb(sbyte xiangshuAvatarId)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)xiangshuAvatarId;
		}
	}

	protected unsafe void AppendJuniorXiangshu(sbyte xiangshuAvatarId)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)xiangshuAvatarId;
		}
	}

	protected unsafe void AppendAdventure(int adventureCoreId)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = adventureCoreId;
		}
	}

	protected unsafe void AppendBehaviorType(sbyte behaviorType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)behaviorType;
		}
	}

	protected unsafe void AppendFavorabilityType(sbyte favorabilityType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)favorabilityType;
		}
	}

	protected unsafe void AppendCricket(short colorId, short partId, int nameId)
	{
		int offset = Size;
		int newSize = Size + 2 + 2 + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(short*)num = colorId;
			((short*)num)[1] = partId;
			*(int*)(num + 2 + 2) = nameId;
		}
	}

	protected unsafe void AppendItemSubType(short itemSubType)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = itemSubType;
		}
	}

	protected unsafe void AppendChicken(short chickenId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = chickenId;
		}
	}

	protected unsafe void AppendCharacterPropertyReferencedType(short characterPropertyReferencedType)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = characterPropertyReferencedType;
		}
	}

	protected unsafe void AppendBodyPartType(sbyte bodyPartType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)bodyPartType;
		}
	}

	protected unsafe void AppendInjuryType(sbyte injuryType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)injuryType;
		}
	}

	protected unsafe void AppendPoisonType(sbyte poisonType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)poisonType;
		}
	}

	protected unsafe void AppendCharacterTemplate(short templateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = templateId;
		}
	}

	protected unsafe void AppendFeature(short featureId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = featureId;
		}
	}

	protected unsafe void AppendInteger(int value)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = value;
		}
	}

	protected unsafe void AppendLifeSkill(short lifeSkillTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = lifeSkillTemplateId;
		}
	}

	protected unsafe void AppendMerchantType(sbyte merchantType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)merchantType;
		}
	}

	protected unsafe void AppendItemKey(ulong itemKey)
	{
		int offset = Size;
		int newSize = Size + 8;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(ulong*)(pRawData + offset) = itemKey;
		}
	}

	protected unsafe void AppendCombatType(sbyte combatType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)combatType;
		}
	}

	protected unsafe void AppendLifeSkillType(sbyte lifeSkillType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)lifeSkillType;
		}
	}

	protected unsafe void AppendCombatSkillType(sbyte combatSkillType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)combatSkillType;
		}
	}

	protected unsafe void AppendInformation(short infoTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = infoTemplateId;
		}
	}

	protected unsafe void AppendSecretInformationTemplate(short secretInfoTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = secretInfoTemplateId;
		}
	}

	protected unsafe void AppendPunishmentType(short punishmentType)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = punishmentType;
		}
	}

	protected unsafe void AppendCharacterTitle(short titleTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = titleTemplateId;
		}
	}

	protected unsafe void AppendFloat(float floatValue)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(float*)(pRawData + offset) = floatValue;
		}
	}

	protected void AppendCharacterRealName(int charId)
	{
		AppendCharacter(charId);
	}

	protected unsafe void AppendMonth(sbyte month)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)month;
		}
	}

	protected unsafe void AppendProfession(int professionTemplateId)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = professionTemplateId;
		}
	}

	protected unsafe void AppendProfessionSkill(int skillTemplateId)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = skillTemplateId;
		}
	}

	protected unsafe void AppendItemGrade(sbyte grade)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)grade;
		}
	}

	protected unsafe void AppendText(string value)
	{
		int offset = Size;
		int newSize = Size + 2 + value.Length * 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			SerializationHelper.Serialize(pRawData + offset, value);
		}
	}

	protected unsafe void AppendMusic(short musicTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = musicTemplateId;
		}
	}

	protected unsafe void AppendMapState(sbyte stateTemplateId)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)stateTemplateId;
		}
	}

	protected unsafe void AppendJiaoLoong(int jiaoLoongId)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = jiaoLoongId;
		}
	}

	protected unsafe void AppendJiaoProperty(short jiaoPropertyId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = jiaoPropertyId;
		}
	}

	protected unsafe void AppendDestinyType(sbyte destinyType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)destinyType;
		}
	}

	protected unsafe void AppendSecretInformation(short templateId, int id)
	{
		int offset = Size;
		int newSize = Size + 2 + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(short*)num = templateId;
			*(int*)(num + 2) = id;
		}
	}

	protected unsafe void AppendMerchant(sbyte templateId)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)templateId;
		}
	}

	protected unsafe void AppendLegacy(short templateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = templateId;
		}
	}

	protected unsafe void AppendCharGrade(sbyte grade)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)grade;
		}
	}

	protected unsafe void AppendFeast(short feast)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = feast;
		}
	}

	protected unsafe void AppendAdventureElement(int elementCoreId)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = elementCoreId;
		}
	}

	protected unsafe void AppendPersonalityType(sbyte personalityType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)personalityType;
		}
	}
}
