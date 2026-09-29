using System;
using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.LifeRecord.GeneralRecord;

[SerializableGameData(NotForDisplayModule = true)]
public class ReadonlyRecordCollection : RawDataBlock, IBinary, ISerializableGameData
{
	public int Count { get; set; }

	public ReadonlyRecordCollection()
	{
		Count = 0;
	}

	public ReadonlyRecordCollection(int initialCapacity)
		: base(initialCapacity)
	{
		Count = 0;
	}

	public new bool IsSerializedSizeFixed()
	{
		return false;
	}

	public new int GetSerializedSize()
	{
		return base.GetSerializedSize() + 4;
	}

	public new unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += base.Serialize(pCurrData);
		*(int*)pCurrData = Count;
		pCurrData += 4;
		return (int)(pCurrData - pData);
	}

	public new unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += base.Deserialize(pCurrData);
		Count = *(int*)pCurrData;
		pCurrData += 4;
		return (int)(pCurrData - pData);
	}

	public new void Clear()
	{
		Size = 0;
		Count = 0;
	}

	public new ushort GetSerializedFixedSizeOfMetadata()
	{
		return 8;
	}

	public new unsafe int SerializeMetadata(byte* pData)
	{
		*(int*)pData = Size;
		((int*)pData)[1] = Count;
		return 8;
	}

	public new unsafe int DeserializeMetadata(byte* pData)
	{
		Size = *(int*)pData;
		Count = ((int*)pData)[1];
		EnsureCapacity(Size);
		return 8;
	}

	public bool Next(ref int index, ref int offset)
	{
		if (index < 0)
		{
			if (Count > 0)
			{
				index = 0;
				offset = 0;
				return true;
			}
			return false;
		}
		if (++index >= Count)
		{
			return false;
		}
		byte recordSize = RawData[offset];
		offset += recordSize;
		return true;
	}

	public int Next(int offset)
	{
		if (offset < 0)
		{
			if (Size <= 0)
			{
				return -1;
			}
			return 0;
		}
		byte recordSize = RawData[offset];
		offset += recordSize;
		if (offset >= Size)
		{
			return -1;
		}
		return offset;
	}

	public int GetOffsetByIndex(int index)
	{
		if (index < 0 || index >= Count)
		{
			return -1;
		}
		int offset = 0;
		for (int i = 0; i < index; i++)
		{
			offset += RawData[offset];
		}
		return offset;
	}

	public int GetRecordSize(int offset)
	{
		return RawData[offset];
	}

	public void GetRenderInfos(List<RenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			RenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	public RenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		throw new NotImplementedException();
	}

	protected unsafe static int ReadArgumentAndGetIndex(sbyte paramType, byte** ppData, ArgumentCollection argumentCollection)
	{
		switch (paramType)
		{
		case 0:
		{
			int charId = ReadCharacter(ppData);
			return argumentCollection.AddCharacter(charId);
		}
		case 1:
		{
			Location location = ReadLocation(ppData);
			return argumentCollection.AddLocation(location);
		}
		case 2:
			var (itemType, itemTemplateId) = ReadItem(ppData);
			return argumentCollection.AddItem(itemType, itemTemplateId);
		case 3:
		{
			short combatSkillId = ReadCombatSkill(ppData);
			return argumentCollection.AddCombatSkill(combatSkillId);
		}
		case 4:
		{
			sbyte resourceType = ReadResource(ppData);
			return argumentCollection.AddResource(resourceType);
		}
		case 5:
		{
			short settlementId = ReadSettlement(ppData);
			return argumentCollection.AddSettlement(settlementId);
		}
		case 6:
			var (orgTemplateId, orgGrade, orgPrincipal, gender) = ReadOrgGrade(ppData);
			return argumentCollection.AddOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		case 7:
		{
			short buildingTemplateId = ReadBuilding(ppData);
			return argumentCollection.AddBuilding(buildingTemplateId);
		}
		case 8:
		{
			sbyte xiangshuAvatarId2 = ReadSwordTomb(ppData);
			return argumentCollection.AddSwordTomb(xiangshuAvatarId2);
		}
		case 9:
		{
			sbyte xiangshuAvatarId = ReadJuniorXiangshu(ppData);
			return argumentCollection.AddJuniorXiangshu(xiangshuAvatarId);
		}
		case 10:
		{
			int adventureCoreId = ReadAdventure(ppData);
			return argumentCollection.AddAdventure(adventureCoreId);
		}
		case 11:
		{
			sbyte behaviorType = ReadBehaviorType(ppData);
			return argumentCollection.AddBehaviorType(behaviorType);
		}
		case 12:
		{
			sbyte favorabilityType = ReadFavorabilityType(ppData);
			return argumentCollection.AddFavorabilityType(favorabilityType);
		}
		case 13:
			var (colorId, partId, nameId) = ReadCricket(ppData);
			return argumentCollection.AddCricket(colorId, partId, nameId);
		case 14:
		{
			short itemSubType = ReadItemSubType(ppData);
			return argumentCollection.AddItemSubType(itemSubType);
		}
		case 15:
		{
			short chickenId = ReadChicken(ppData);
			return argumentCollection.AddChicken(chickenId);
		}
		case 16:
		{
			short characterPropertyReferencedType = ReadCharacterPropertyReferencedType(ppData);
			return argumentCollection.AddCharacterPropertyReferencedType(characterPropertyReferencedType);
		}
		case 17:
		{
			sbyte bodyPartType = ReadBodyPartType(ppData);
			return argumentCollection.AddBodyPartType(bodyPartType);
		}
		case 18:
		{
			sbyte injuryType = ReadInjuryType(ppData);
			return argumentCollection.AddInjuryType(injuryType);
		}
		case 19:
		{
			sbyte poisonType = ReadPoisonType(ppData);
			return argumentCollection.AddPoisonType(poisonType);
		}
		case 20:
		{
			short charTemplate = ReadCharacterTemplate(ppData);
			return argumentCollection.AddCharacterTemplate(charTemplate);
		}
		case 21:
		{
			short featureId = ReadFeature(ppData);
			return argumentCollection.AddFeature(featureId);
		}
		case 22:
		{
			int value29 = ReadInteger(ppData);
			return argumentCollection.AddInteger(value29);
		}
		case 23:
		{
			short value28 = ReadLifeSkill(ppData);
			return argumentCollection.AddLifeSkill(value28);
		}
		case 24:
		{
			sbyte value27 = ReadMerchantType(ppData);
			return argumentCollection.AddMerchantType(value27);
		}
		case 25:
		{
			ulong value26 = ReadItemKey(ppData);
			return argumentCollection.AddItemKey(value26);
		}
		case 26:
		{
			sbyte value25 = ReadCombatType(ppData);
			return argumentCollection.AddCombatType(value25);
		}
		case 27:
		{
			sbyte value24 = ReadLifeSkillType(ppData);
			return argumentCollection.AddLifeSkillType(value24);
		}
		case 28:
		{
			sbyte value23 = ReadCombatSkillType(ppData);
			return argumentCollection.AddCombatSkillType(value23);
		}
		case 29:
		{
			short value22 = ReadInformation(ppData);
			return argumentCollection.AddInformation(value22);
		}
		case 30:
		{
			short value21 = ReadSecretInformationTemplate(ppData);
			return argumentCollection.AddSecretInformationTemplate(value21);
		}
		case 31:
		{
			short value20 = ReadPunishmentType(ppData);
			return argumentCollection.AddPunishmentType(value20);
		}
		case 32:
		{
			short value19 = ReadCharacterTitle(ppData);
			return argumentCollection.AddCharacterTitle(value19);
		}
		case 33:
		{
			float value18 = ReadFloat(ppData);
			return argumentCollection.AddFloat(value18);
		}
		case 34:
		{
			int value17 = ReadCharacter(ppData);
			return argumentCollection.AddCharacterRealName(value17);
		}
		case 35:
		{
			sbyte value16 = ReadMonth(ppData);
			return argumentCollection.AddMonth(value16);
		}
		case 36:
		{
			int value15 = ReadInt(ppData);
			return argumentCollection.AddProfession(value15);
		}
		case 37:
		{
			int value14 = ReadInt(ppData);
			return argumentCollection.AddProfessionSkill(value14);
		}
		case 38:
		{
			sbyte value13 = ReadSByte(ppData);
			return argumentCollection.AddItemGrade(value13);
		}
		case 39:
		{
			string value12 = ReadText(ppData);
			return argumentCollection.AddText(value12);
		}
		case 40:
		{
			short value11 = ReadGeneric<short>(ppData);
			return argumentCollection.AddMusic(value11);
		}
		case 41:
		{
			sbyte value10 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddMapState(value10);
		}
		case 42:
		{
			int value9 = ReadGeneric<int>(ppData);
			return argumentCollection.AddJiaoLoong(value9);
		}
		case 43:
		{
			short value8 = ReadGeneric<short>(ppData);
			return argumentCollection.AddJiaoProperty(value8);
		}
		case 44:
		{
			sbyte value7 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddDestinyType(value7);
		}
		case 45:
			var (templateId, id) = ReadSecretInformation(ppData);
			return argumentCollection.AddSecretInformation(templateId, id);
		case 46:
		{
			sbyte value6 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddMerchant(value6);
		}
		case 47:
		{
			short value5 = ReadGeneric<short>(ppData);
			return argumentCollection.AddLegacy(value5);
		}
		case 48:
		{
			sbyte value4 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddCharGrade(value4);
		}
		case 49:
		{
			sbyte value3 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddFeast(value3);
		}
		case 50:
		{
			int value2 = ReadGeneric<int>(ppData);
			return argumentCollection.AddAdventureElement(value2);
		}
		case 51:
		{
			sbyte value = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddPersonalityType(value);
		}
		default:
			throw new Exception($"Unsupported ParameterType: {paramType}");
		}
	}

	protected unsafe static int ReadArgumentAndGetIndex(sbyte paramType, byte** ppData, TransferableArgumentCollection argumentCollection)
	{
		switch (paramType)
		{
		case 0:
		{
			int charId = ReadCharacter(ppData);
			return argumentCollection.AddCharacter(charId);
		}
		case 1:
		{
			Location location = ReadLocation(ppData);
			return argumentCollection.AddLocation(location);
		}
		case 2:
			var (itemType, itemTemplateId) = ReadItem(ppData);
			return argumentCollection.AddItem(itemType, itemTemplateId);
		case 3:
		{
			short combatSkillId = ReadCombatSkill(ppData);
			return argumentCollection.AddCombatSkill(combatSkillId);
		}
		case 4:
		{
			sbyte resourceType = ReadResource(ppData);
			return argumentCollection.AddResource(resourceType);
		}
		case 5:
		{
			short settlementId = ReadSettlement(ppData);
			return argumentCollection.AddSettlement(settlementId);
		}
		case 6:
			var (orgTemplateId, orgGrade, orgPrincipal, gender) = ReadOrgGrade(ppData);
			return argumentCollection.AddOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		case 7:
		{
			short buildingTemplateId = ReadBuilding(ppData);
			return argumentCollection.AddBuilding(buildingTemplateId);
		}
		case 8:
		{
			sbyte xiangshuAvatarId2 = ReadSwordTomb(ppData);
			return argumentCollection.AddSwordTomb(xiangshuAvatarId2);
		}
		case 9:
		{
			sbyte xiangshuAvatarId = ReadJuniorXiangshu(ppData);
			return argumentCollection.AddJuniorXiangshu(xiangshuAvatarId);
		}
		case 10:
		{
			int adventureCoreId = ReadAdventure(ppData);
			return argumentCollection.AddAdventure(adventureCoreId);
		}
		case 11:
		{
			sbyte behaviorType = ReadBehaviorType(ppData);
			return argumentCollection.AddBehaviorType(behaviorType);
		}
		case 12:
		{
			sbyte favorabilityType = ReadFavorabilityType(ppData);
			return argumentCollection.AddFavorabilityType(favorabilityType);
		}
		case 13:
			var (colorId, partId, nameId) = ReadCricket(ppData);
			return argumentCollection.AddCricket(colorId, partId, nameId);
		case 14:
		{
			short itemSubType = ReadItemSubType(ppData);
			return argumentCollection.AddItemSubType(itemSubType);
		}
		case 15:
		{
			short chickenId = ReadChicken(ppData);
			return argumentCollection.AddChicken(chickenId);
		}
		case 16:
		{
			short characterPropertyReferencedType = ReadCharacterPropertyReferencedType(ppData);
			return argumentCollection.AddCharacterPropertyReferencedType(characterPropertyReferencedType);
		}
		case 17:
		{
			sbyte bodyPartType = ReadBodyPartType(ppData);
			return argumentCollection.AddBodyPartType(bodyPartType);
		}
		case 18:
		{
			sbyte injuryType = ReadInjuryType(ppData);
			return argumentCollection.AddInjuryType(injuryType);
		}
		case 19:
		{
			sbyte poisonType = ReadPoisonType(ppData);
			return argumentCollection.AddPoisonType(poisonType);
		}
		case 20:
		{
			short charTemplate = ReadCharacterTemplate(ppData);
			return argumentCollection.AddCharacterTemplate(charTemplate);
		}
		case 21:
		{
			short featureId = ReadFeature(ppData);
			return argumentCollection.AddFeature(featureId);
		}
		case 22:
		{
			int value29 = ReadInteger(ppData);
			return argumentCollection.AddInteger(value29);
		}
		case 23:
		{
			short value28 = ReadLifeSkill(ppData);
			return argumentCollection.AddLifeSkill(value28);
		}
		case 24:
		{
			sbyte value27 = ReadMerchantType(ppData);
			return argumentCollection.AddMerchantType(value27);
		}
		case 25:
		{
			ulong value26 = ReadItemKey(ppData);
			return argumentCollection.AddItemKey(value26);
		}
		case 26:
		{
			sbyte value25 = ReadCombatType(ppData);
			return argumentCollection.AddCombatType(value25);
		}
		case 27:
		{
			sbyte value24 = ReadLifeSkillType(ppData);
			return argumentCollection.AddLifeSkillType(value24);
		}
		case 28:
		{
			sbyte value23 = ReadCombatSkillType(ppData);
			return argumentCollection.AddCombatSkillType(value23);
		}
		case 29:
		{
			short value22 = ReadInformation(ppData);
			return argumentCollection.AddInformation(value22);
		}
		case 30:
		{
			short value21 = ReadSecretInformationTemplate(ppData);
			return argumentCollection.AddSecretInformationTemplate(value21);
		}
		case 31:
		{
			short value20 = ReadPunishmentType(ppData);
			return argumentCollection.AddPunishmentType(value20);
		}
		case 32:
		{
			short value19 = ReadCharacterTitle(ppData);
			return argumentCollection.AddCharacterTitle(value19);
		}
		case 33:
		{
			float value18 = ReadFloat(ppData);
			return argumentCollection.AddFloat(value18);
		}
		case 34:
		{
			int value17 = ReadCharacter(ppData);
			return argumentCollection.AddCharacterRealName(value17);
		}
		case 35:
		{
			sbyte value16 = ReadMonth(ppData);
			return argumentCollection.AddMonth(value16);
		}
		case 36:
		{
			int value15 = ReadInt(ppData);
			return argumentCollection.AddProfession(value15);
		}
		case 37:
		{
			int value14 = ReadInt(ppData);
			return argumentCollection.AddProfessionSkill(value14);
		}
		case 38:
		{
			sbyte value13 = ReadSByte(ppData);
			return argumentCollection.AddItemGrade(value13);
		}
		case 39:
		{
			string value12 = ReadText(ppData);
			return argumentCollection.AddText(value12);
		}
		case 40:
		{
			short value11 = ReadGeneric<short>(ppData);
			return argumentCollection.AddMusic(value11);
		}
		case 41:
		{
			sbyte value10 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddMapState(value10);
		}
		case 42:
		{
			int value9 = ReadGeneric<int>(ppData);
			return argumentCollection.AddJiaoLoong(value9);
		}
		case 43:
		{
			short value8 = ReadGeneric<short>(ppData);
			return argumentCollection.AddJiaoProperty(value8);
		}
		case 44:
		{
			sbyte value7 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddDestinyType(value7);
		}
		case 45:
			var (templateId, id) = ReadSecretInformation(ppData);
			return argumentCollection.AddSecretInformation(templateId, id);
		case 46:
		{
			sbyte value6 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddMerchant(value6);
		}
		case 47:
		{
			short value5 = ReadGeneric<short>(ppData);
			return argumentCollection.AddLegacy(value5);
		}
		case 48:
		{
			sbyte value4 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddCharGrade(value4);
		}
		case 49:
		{
			sbyte value3 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddFeast(value3);
		}
		case 50:
		{
			int value2 = ReadGeneric<int>(ppData);
			return argumentCollection.AddAdventureElement(value2);
		}
		case 51:
		{
			sbyte value = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddPersonalityTypes(value);
		}
		default:
			throw new Exception($"Unsupported ParameterType: {paramType}");
		}
	}

	private unsafe static int ReadCharacter(byte** ppData)
	{
		int result = *(int*)(*ppData);
		*ppData += 4;
		return result;
	}

	private unsafe static Location ReadLocation(byte** ppData)
	{
		short areaId = *(short*)(*ppData);
		short blockId = ((short*)(*ppData))[1];
		*ppData += 4;
		return new Location(areaId, blockId);
	}

	private unsafe static (sbyte itemType, short itemTemplateId) ReadItem(byte** ppData)
	{
		byte item = *(*ppData);
		short itemTemplateId = *(short*)(*ppData + 1);
		*ppData += 3;
		return (itemType: (sbyte)item, itemTemplateId: itemTemplateId);
	}

	private unsafe static short ReadCombatSkill(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static sbyte ReadResource(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static short ReadSettlement(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static (sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender) ReadOrgGrade(byte** ppData)
	{
		byte item = *(*ppData);
		sbyte orgGrade = (sbyte)(*ppData)[1];
		bool orgPrincipal = (*ppData + 1)[1] != 0;
		sbyte gender = (sbyte)(*ppData + 1 + 1)[1];
		*ppData += 4;
		return (orgTemplateId: (sbyte)item, orgGrade: orgGrade, orgPrincipal: orgPrincipal, gender: gender);
	}

	private unsafe static short ReadBuilding(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static sbyte ReadSwordTomb(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static sbyte ReadJuniorXiangshu(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static int ReadAdventure(byte** ppData)
	{
		int result = *(int*)(*ppData);
		*ppData += 4;
		return result;
	}

	private unsafe static sbyte ReadBehaviorType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static sbyte ReadFavorabilityType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static (short colorId, short partId, int nameId) ReadCricket(byte** ppData)
	{
		short item = *(short*)(*ppData);
		short partId = ((short*)(*ppData))[1];
		int nameId = *(int*)(*ppData + 2 + 2);
		*ppData += 8;
		return (colorId: item, partId: partId, nameId: nameId);
	}

	private unsafe static short ReadItemSubType(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static short ReadChicken(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static short ReadCharacterPropertyReferencedType(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static sbyte ReadBodyPartType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static sbyte ReadInjuryType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static sbyte ReadPoisonType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static short ReadCharacterTemplate(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static short ReadFeature(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static int ReadInteger(byte** ppData)
	{
		int result = *(int*)(*ppData);
		*ppData += 4;
		return result;
	}

	private unsafe static short ReadLifeSkill(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static sbyte ReadMerchantType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static ulong ReadItemKey(byte** ppData)
	{
		long result = *(long*)(*ppData);
		*ppData += 8;
		return (ulong)result;
	}

	private unsafe static sbyte ReadCombatType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static sbyte ReadLifeSkillType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static sbyte ReadCombatSkillType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static short ReadInformation(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static short ReadSecretInformationTemplate(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static short ReadPunishmentType(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static short ReadCharacterTitle(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	private unsafe static float ReadFloat(byte** ppData)
	{
		float result = *(float*)(*ppData);
		*ppData += 4;
		return result;
	}

	private unsafe static sbyte ReadMonth(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static int ReadInt(byte** ppData)
	{
		int result = *(int*)(*ppData);
		*ppData += 4;
		return result;
	}

	private unsafe static sbyte ReadSByte(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	private unsafe static T ReadGeneric<T>(byte** ppData) where T : unmanaged
	{
		T result = *(T*)(*ppData);
		*ppData += sizeof(T);
		return result;
	}

	private unsafe static string ReadText(byte** ppData)
	{
		string val;
		int size = SerializationHelper.Deserialize(*ppData, out val);
		*ppData += size;
		return val;
	}

	public unsafe static (short templateId, int id) ReadSecretInformation(byte** ppData)
	{
		short item = *(short*)(*ppData);
		int id = *(int*)(*ppData + 2);
		*ppData += 6;
		return (templateId: item, id: id);
	}

	public void ReadData(TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		int index = -1;
		int offset = -1;
		int date = -1;
		while (Next(ref index, ref offset))
		{
			TransferableRecord record = ReadRenderInfo(offset, data, getParameters);
			if (data.Record.Count == 0)
			{
				data.AddSeparateLine(data.EndDate = (date = record.Date));
			}
			else if (record.Date < date)
			{
				data.AddDate(date);
				date = record.Date;
				data.AddSeparateLine(date);
			}
			else if (record.Date > date)
			{
				record.Date = date;
			}
			data.Record.Add(record);
		}
		data.StartDate = date;
	}

	public void ReadDataWithNormalOrder(TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		ReadDataWithNormalOrder(data, getParameters, ReadRenderInfo);
	}

	public void ReadDataWithNormalOrder(TransferableRecordDataBase data, Func<int, string[]> getParameters, Func<int, TransferableRecordDataBase, Func<int, string[]>, TransferableRecord> readRenderInfo)
	{
		int index = -1;
		int offset = -1;
		int date = -1;
		while (Next(ref index, ref offset))
		{
			TransferableRecord record = readRenderInfo(offset, data, getParameters);
			if (record == null)
			{
				break;
			}
			if (data.Record.Count == 0 || record.Date > date)
			{
				if (data.Record.Count == 0)
				{
					data.StartDate = record.Date;
				}
				else
				{
					data.AddSeparateLine(date);
				}
				date = record.Date;
				data.AddDate(date);
			}
			else if (record.Date < date)
			{
				record.Date = date;
			}
			data.Record.Add(record);
		}
		data.AddSeparateLine(data.EndDate = date);
		data.Record.Reverse();
	}

	public unsafe TransferableRecord ReadRenderInfo(int offset, TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			int date = *(int*)(pCurrData + 1);
			short recordType = ((short*)(pCurrData + 1))[2];
			pCurrData += 7;
			string[] parameters = getParameters(recordType);
			if (parameters == null)
			{
				return null;
			}
			TransferableRecord info = new TransferableRecord(date, recordType);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadArgumentAndGetIndex(paramType, &pCurrData, data.ArgumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			return info;
		}
	}

	public void ReadTaiwuVillageDataWithNormalOrder(TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		ReadDataWithNormalOrder(data, getParameters, ReadTaiwuVillageRenderInfo);
	}

	public unsafe TransferableRecord ReadTaiwuVillageRenderInfo(int offset, TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			sbyte storageType = (sbyte)(*pCurrData);
			pCurrData++;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			string[] parameters = getParameters(recordType);
			if (parameters == null)
			{
				return null;
			}
			TransferableRecord info = new TransferableRecord(date, recordType);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadArgumentAndGetIndex(paramType, &pCurrData, data.ArgumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			info.Arguments.Add((22, storageType));
			return info;
		}
	}

	public void ReadOrganizationRecordDataWithNormalOrder(TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		ReadDataWithNormalOrder(data, getParameters, ReadOrganizationRecordRenderInfo);
	}

	public unsafe TransferableRecord ReadOrganizationRecordRenderInfo(int offset, TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			short settlementId = *(short*)pCurrData;
			pCurrData += 2;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			string[] parameters = getParameters(recordType);
			if (parameters == null)
			{
				return null;
			}
			TransferableRecord info = new TransferableRecord(date, recordType);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadArgumentAndGetIndex(paramType, &pCurrData, data.ArgumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			info.Arguments.Add((22, settlementId));
			return info;
		}
	}

	public void ReadTeaHorseEventWithNormalOrder(TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		ReadDataWithNormalOrder(data, getParameters, ReadTeaHorseEventRenderInfo);
	}

	public unsafe TransferableRecord ReadTeaHorseEventRenderInfo(int offset, TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData += 5;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			string[] parameters = getParameters(recordType);
			if (parameters == null)
			{
				return null;
			}
			TransferableRecord info = new TransferableRecord(date, recordType);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadArgumentAndGetIndex(paramType, &pCurrData, data.ArgumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			return info;
		}
	}

	public void ReadTeammateBubbleWithNormalOrder(TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		ReadDataWithNormalOrder(data, getParameters, ReadTeammateBubbleRenderInfo);
	}

	public unsafe TransferableRecord ReadTeammateBubbleRenderInfo(int offset, TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset + 1;
			int index = *(int*)pCurrData;
			pCurrData += 4;
			int subtype = *(int*)pCurrData;
			pCurrData += 4;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			int charTemplateId = ((subtype == 5) ? (*(short*)pCurrData) : 0);
			if (subtype == 5)
			{
				pCurrData += 2;
			}
			string[] parameters = getParameters(recordType);
			if (parameters == null)
			{
				return null;
			}
			TransferableRecord info = new TransferableRecord(0, recordType);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadArgumentAndGetIndex(paramType, &pCurrData, data.ArgumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			info.Arguments.Add((22, charTemplateId));
			info.Arguments.Add((22, index));
			info.Arguments.Add((22, subtype));
			return info;
		}
	}

	private unsafe int BeginAddingRecord(int index, short recordType, int subtype)
	{
		int offset = Size;
		int newSize = Size + 1 + 4 + 4 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = index;
			((int*)(num + 1))[1] = subtype;
			((short*)(num + 1 + 4))[2] = recordType;
		}
		return offset;
	}

	public virtual void FillEventArgBox(int offset, IVariantCollection<string> eventArgBox)
	{
	}

	protected unsafe void ReadArgumentToEventArgBox(string keyPrefix, int argIndex, sbyte paramType, byte** ppData, IVariantCollection<string> argBox)
	{
		string argKey = $"{keyPrefix}{argIndex}";
		switch (paramType)
		{
		case 0:
		{
			int charId = ReadCharacter(ppData);
			argBox.Set(argKey, charId);
			break;
		}
		case 1:
		{
			Location location = ReadLocation(ppData);
			argBox.Set(argKey, location);
			break;
		}
		case 2:
			var (itemType, itemTemplateId) = ReadItem(ppData);
			argBox.Set(argKey + "_itemType", itemType);
			argBox.Set(argKey + "_itemTemplateId", itemTemplateId);
			break;
		case 3:
		{
			short combatSkillId = ReadCombatSkill(ppData);
			argBox.Set(argKey, combatSkillId);
			break;
		}
		case 4:
		{
			sbyte resourceType = ReadResource(ppData);
			argBox.Set(argKey, resourceType);
			break;
		}
		case 5:
		{
			short settlementId = ReadSettlement(ppData);
			argBox.Set(argKey, settlementId);
			break;
		}
		case 6:
			var (orgTemplateId, orgGrade, orgPrincipal, gender) = ReadOrgGrade(ppData);
			argBox.Set(argKey + "_orgTemplateId", orgTemplateId);
			argBox.Set(argKey + "_orgGrade", orgGrade);
			argBox.Set(argKey + "_orgPrincipal", orgPrincipal);
			argBox.Set(argKey + "_gender", gender);
			break;
		case 7:
		{
			short buildingTemplateId = ReadBuilding(ppData);
			argBox.Set(argKey, buildingTemplateId);
			break;
		}
		case 8:
		{
			sbyte xiangshuAvatarId2 = ReadSwordTomb(ppData);
			argBox.Set(argKey, xiangshuAvatarId2);
			break;
		}
		case 9:
		{
			sbyte xiangshuAvatarId = ReadJuniorXiangshu(ppData);
			argBox.Set(argKey, xiangshuAvatarId);
			break;
		}
		case 10:
		{
			int adventureTemplateId = ReadAdventure(ppData);
			argBox.Set(argKey, adventureTemplateId);
			break;
		}
		case 11:
		{
			sbyte behaviorType = ReadBehaviorType(ppData);
			argBox.Set(argKey, behaviorType);
			break;
		}
		case 12:
		{
			sbyte favorabilityType = ReadFavorabilityType(ppData);
			argBox.Set(argKey, favorabilityType);
			break;
		}
		case 13:
			var (colorId, partId, nameId) = ReadCricket(ppData);
			argBox.Set(argKey + "_colorId", colorId);
			argBox.Set(argKey + "_partId", partId);
			argBox.Set(argKey + "_nameId", nameId);
			break;
		case 14:
		{
			short itemSubType = ReadItemSubType(ppData);
			argBox.Set(argKey, itemSubType);
			break;
		}
		case 15:
		{
			short chickenId = ReadChicken(ppData);
			argBox.Set(argKey, chickenId);
			break;
		}
		case 16:
		{
			short characterPropertyReferencedType = ReadCharacterPropertyReferencedType(ppData);
			argBox.Set(argKey, characterPropertyReferencedType);
			break;
		}
		case 17:
		{
			sbyte bodyPartType = ReadBodyPartType(ppData);
			argBox.Set(argKey, bodyPartType);
			break;
		}
		case 18:
		{
			sbyte injuryType = ReadInjuryType(ppData);
			argBox.Set(argKey, injuryType);
			break;
		}
		case 19:
		{
			sbyte poisonType = ReadPoisonType(ppData);
			argBox.Set(argKey, poisonType);
			break;
		}
		case 20:
		{
			short charTemplate = ReadCharacterTemplate(ppData);
			argBox.Set(argKey, charTemplate);
			break;
		}
		case 21:
		{
			short featureId = ReadFeature(ppData);
			argBox.Set(argKey, featureId);
			break;
		}
		case 22:
		{
			int value23 = ReadInteger(ppData);
			argBox.Set(argKey, value23);
			break;
		}
		case 23:
		{
			short value22 = ReadLifeSkill(ppData);
			argBox.Set(argKey, value22);
			break;
		}
		case 24:
		{
			sbyte value21 = ReadMerchantType(ppData);
			argBox.Set(argKey, value21);
			break;
		}
		case 25:
		{
			ulong value20 = ReadItemKey(ppData);
			argBox.Set(argKey, (ItemKey)value20);
			break;
		}
		case 26:
		{
			sbyte value19 = ReadCombatType(ppData);
			argBox.Set(argKey, value19);
			break;
		}
		case 27:
		{
			sbyte value18 = ReadLifeSkillType(ppData);
			argBox.Set(argKey, value18);
			break;
		}
		case 28:
		{
			sbyte value17 = ReadCombatSkillType(ppData);
			argBox.Set(argKey, value17);
			break;
		}
		case 29:
		{
			short value16 = ReadInformation(ppData);
			argBox.Set(argKey, value16);
			break;
		}
		case 30:
		{
			short value15 = ReadSecretInformationTemplate(ppData);
			argBox.Set(argKey, value15);
			break;
		}
		case 31:
		{
			short value14 = ReadPunishmentType(ppData);
			argBox.Set(argKey, value14);
			break;
		}
		case 32:
		{
			short value13 = ReadCharacterTitle(ppData);
			argBox.Set(argKey, value13);
			break;
		}
		case 33:
		{
			float value12 = ReadFloat(ppData);
			argBox.Set(argKey, value12);
			break;
		}
		case 34:
		{
			int value11 = ReadCharacter(ppData);
			argBox.Set(argKey, value11);
			break;
		}
		case 35:
		{
			sbyte value10 = ReadMonth(ppData);
			argBox.Set(argKey, value10);
			break;
		}
		case 36:
		{
			int value9 = ReadInt(ppData);
			argBox.Set(argKey, value9);
			break;
		}
		case 37:
		{
			int value8 = ReadInt(ppData);
			argBox.Set(argKey, value8);
			break;
		}
		case 38:
		{
			sbyte value7 = ReadSByte(ppData);
			argBox.Set(argKey, value7);
			break;
		}
		case 39:
		{
			string value6 = ReadText(ppData);
			argBox.Set(argKey, value6);
			break;
		}
		case 40:
		{
			short value5 = ReadGeneric<short>(ppData);
			argBox.Set(argKey, value5);
			break;
		}
		case 41:
		{
			sbyte value4 = ReadGeneric<sbyte>(ppData);
			argBox.Set(argKey, value4);
			break;
		}
		case 42:
		{
			int value3 = ReadGeneric<int>(ppData);
			argBox.Set(argKey, value3);
			break;
		}
		case 43:
		{
			short value2 = ReadGeneric<short>(ppData);
			argBox.Set(argKey, value2);
			break;
		}
		case 44:
		{
			sbyte value = ReadGeneric<sbyte>(ppData);
			argBox.Set(argKey, value);
			break;
		}
		case 45:
			var (templateId, id) = ReadSecretInformation(ppData);
			argBox.Set(argKey + "_templateId", templateId);
			argBox.Set(argKey + "_id", id);
			break;
		default:
			throw new Exception($"Unsupported ParameterType: {paramType}");
		}
	}
}
