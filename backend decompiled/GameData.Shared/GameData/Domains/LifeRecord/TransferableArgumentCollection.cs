using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.LifeRecord;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true, NotRestrictCollectionSerializedSize = true)]
public class TransferableArgumentCollection : ISerializableGameData
{
	[SerializableGameDataField(FieldIndex = 0, CollectionMaxElementsCount = int.MaxValue)]
	public List<float> Floats;

	[SerializableGameDataField(FieldIndex = 1, CollectionMaxElementsCount = int.MaxValue)]
	public List<ulong> ItemKeys;

	[SerializableGameDataField(FieldIndex = 2, CollectionMaxElementsCount = int.MaxValue)]
	public List<Location> Locations;

	[SerializableGameDataField(FieldIndex = 3, CollectionMaxElementsCount = int.MaxValue)]
	public List<(sbyte, short)> Items;

	[SerializableGameDataField(FieldIndex = 4, CollectionMaxElementsCount = int.MaxValue)]
	public List<(sbyte, sbyte, bool, sbyte)> OrgGrades;

	[SerializableGameDataField(FieldIndex = 5, CollectionMaxElementsCount = int.MaxValue)]
	public List<(short, short, int)> Crickets;

	[SerializableGameDataField(FieldIndex = 6, CollectionMaxElementsCount = int.MaxValue)]
	public List<(short, int)> SecretInformations;

	[SerializableGameDataField(FieldIndex = 7, CollectionMaxElementsCount = int.MaxValue)]
	public List<string> Texts;

	public HashSet<int> CharacterSet;

	public HashSet<int> JiaoLoongSet;

	public HashSet<Location> LocationSet;

	public HashSet<short> SettlementSet;

	public TransferableArgumentCollection()
	{
		Floats = new List<float>();
		ItemKeys = new List<ulong>();
		Locations = new List<Location>();
		Items = new List<(sbyte, short)>();
		OrgGrades = new List<(sbyte, sbyte, bool, sbyte)>();
		Crickets = new List<(short, short, int)>();
		SecretInformations = new List<(short, int)>();
		Texts = new List<string>();
		CharacterSet = new HashSet<int>();
		JiaoLoongSet = new HashSet<int>();
		LocationSet = new HashSet<Location>();
		SettlementSet = new HashSet<short>();
	}

	public void Clear()
	{
		Floats.Clear();
		ItemKeys.Clear();
		Locations.Clear();
		Items.Clear();
		OrgGrades.Clear();
		Crickets.Clear();
		SecretInformations.Clear();
		Texts.Clear();
		CharacterSet.Clear();
		JiaoLoongSet.Clear();
		LocationSet.Clear();
		SettlementSet.Clear();
	}

	private int AddSbyte(sbyte data)
	{
		return data;
	}

	private int AddShort(short data)
	{
		return data;
	}

	private int AddInt(int data)
	{
		return data;
	}

	public TransferableRecord TransferRecord(TransferableRecord record, TransferableArgumentCollection oldCollection)
	{
		record.Arguments = record.Arguments.Select(((sbyte, int) typeIndex) => typeIndex.Item1 switch
		{
			1 => (typeIndex.Item1, ConvertLocation(typeIndex.Item2, oldCollection)), 
			2 => (typeIndex.Item1, ConvertItem(typeIndex.Item2, oldCollection)), 
			6 => (typeIndex.Item1, ConvertOrgGrade(typeIndex.Item2, oldCollection)), 
			13 => (typeIndex.Item1, ConvertCricket(typeIndex.Item2, oldCollection)), 
			25 => (typeIndex.Item1, ConvertItemKey(typeIndex.Item2, oldCollection)), 
			33 => (typeIndex.Item1, ConvertFloat(typeIndex.Item2, oldCollection)), 
			39 => (typeIndex.Item1, ConvertText(typeIndex.Item2, oldCollection)), 
			45 => (typeIndex.Item1, ConvertSecretInformation(typeIndex.Item2, oldCollection)), 
			_ => typeIndex, 
		}).ToList();
		return record;
	}

	public int AddCharacter(int charId)
	{
		CharacterSet.Add(charId);
		return AddInt(charId);
	}

	public int AddLocation(Location location)
	{
		LocationSet.Add(location);
		int count = Locations.Count;
		Locations.Add(location);
		return count;
	}

	public int ConvertLocation(int index, TransferableArgumentCollection oldCollection)
	{
		return AddLocation(oldCollection.Locations[index]);
	}

	public int AddItem(sbyte itemType, short itemTemplateId)
	{
		int count = Items.Count;
		Items.Add((itemType, itemTemplateId));
		return count;
	}

	public int ConvertItem(int index, TransferableArgumentCollection oldCollection)
	{
		return AddItem(oldCollection.Items[index].Item1, oldCollection.Items[index].Item2);
	}

	public int AddCombatSkill(short combatSkillId)
	{
		return AddShort(combatSkillId);
	}

	public int AddResource(sbyte resourceType)
	{
		return AddSbyte(resourceType);
	}

	public int AddSettlement(short settlementId)
	{
		SettlementSet.Add(settlementId);
		return AddShort(settlementId);
	}

	public int AddOrgGrade(sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int count = OrgGrades.Count;
		OrgGrades.Add((orgTemplateId, orgGrade, orgPrincipal, gender));
		return count;
	}

	public int ConvertOrgGrade(int index, TransferableArgumentCollection oldCollection)
	{
		var (orgTemplateId, orgGrade, orgPrincipal, gender) = oldCollection.OrgGrades[index];
		return AddOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
	}

	public int AddBuilding(short buildingTemplateId)
	{
		return AddShort(buildingTemplateId);
	}

	public int AddSwordTomb(sbyte xiangshuAvatarId)
	{
		return AddSbyte(xiangshuAvatarId);
	}

	public int AddJuniorXiangshu(sbyte xiangshuAvatarId)
	{
		return AddSbyte(xiangshuAvatarId);
	}

	public int AddAdventure(int adventureCoreId)
	{
		return AddInt(adventureCoreId);
	}

	public int AddBehaviorType(sbyte behaviorType)
	{
		return AddSbyte(behaviorType);
	}

	public int AddFavorabilityType(sbyte favorabilityType)
	{
		return AddSbyte(favorabilityType);
	}

	public int AddCricket(short colorId, short partId, int nameId)
	{
		int count = Crickets.Count;
		Crickets.Add((colorId, partId, nameId));
		return count;
	}

	public int ConvertCricket(int index, TransferableArgumentCollection oldCollection)
	{
		return AddCricket(oldCollection.Crickets[index].Item1, oldCollection.Crickets[index].Item2, oldCollection.Crickets[index].Item3);
	}

	public int AddItemSubType(short itemSubType)
	{
		return AddShort(itemSubType);
	}

	public int AddChicken(short chickenId)
	{
		return AddShort(chickenId);
	}

	public int AddCharacterPropertyReferencedType(short characterPropertyReferencedType)
	{
		return AddShort(characterPropertyReferencedType);
	}

	public int AddBodyPartType(sbyte bodyPartType)
	{
		return AddSbyte(bodyPartType);
	}

	public int AddInjuryType(sbyte injuryType)
	{
		return AddSbyte(injuryType);
	}

	public int AddPoisonType(sbyte poisonType)
	{
		return AddSbyte(poisonType);
	}

	public int AddCharacterTemplate(short templateId)
	{
		return AddShort(templateId);
	}

	public int AddFeature(short featureId)
	{
		return AddShort(featureId);
	}

	public int AddInteger(int value)
	{
		return AddInt(value);
	}

	public int AddLifeSkill(short lifeSkillTemplateId)
	{
		return AddShort(lifeSkillTemplateId);
	}

	public int AddMerchantType(sbyte merchantType)
	{
		return AddSbyte(merchantType);
	}

	public int AddItemKey(ulong itemKey)
	{
		int count = ItemKeys.Count;
		ItemKeys.Add(itemKey);
		return count;
	}

	public int ConvertItemKey(int index, TransferableArgumentCollection oldCollection)
	{
		return AddItemKey(oldCollection.ItemKeys[index]);
	}

	public int AddCombatType(sbyte combatType)
	{
		return AddSbyte(combatType);
	}

	public int AddLifeSkillType(sbyte lifeSkillType)
	{
		return AddSbyte(lifeSkillType);
	}

	public int AddCombatSkillType(sbyte combatSkillType)
	{
		return AddSbyte(combatSkillType);
	}

	public int AddInformation(short infoTemplateId)
	{
		return AddShort(infoTemplateId);
	}

	public int AddSecretInformationTemplate(short secretInfoTemplateId)
	{
		return AddShort(secretInfoTemplateId);
	}

	public int AddPunishmentType(short punishmentType)
	{
		return AddShort(punishmentType);
	}

	public int AddCharacterTitle(short titleTemplateId)
	{
		return AddShort(titleTemplateId);
	}

	public int AddFloat(float floatValue)
	{
		int count = Floats.Count;
		Floats.Add(floatValue);
		return count;
	}

	public int ConvertFloat(int index, TransferableArgumentCollection oldCollection)
	{
		return AddFloat(oldCollection.Floats[index]);
	}

	public int AddCharacterRealName(int charId)
	{
		return AddInt(charId);
	}

	public int AddMonth(sbyte month)
	{
		return AddSbyte(month);
	}

	public int AddProfession(int professionTemplateId)
	{
		return AddInt(professionTemplateId);
	}

	public int AddProfessionSkill(int skillTemplateId)
	{
		return AddInt(skillTemplateId);
	}

	public int AddItemGrade(sbyte grade)
	{
		return AddSbyte(grade);
	}

	public int AddText(string text)
	{
		int count = Texts.Count;
		Texts.Add(text);
		return count;
	}

	public int ConvertText(int index, TransferableArgumentCollection oldCollection)
	{
		return AddText(oldCollection.Texts[index]);
	}

	public int AddMusic(short musicTemplateId)
	{
		return AddShort(musicTemplateId);
	}

	public int AddMapState(sbyte stateTemplateId)
	{
		return AddSbyte(stateTemplateId);
	}

	public int AddJiaoLoong(int jiaoLoongId)
	{
		JiaoLoongSet.Add(jiaoLoongId);
		return AddInt(jiaoLoongId);
	}

	public int AddJiaoProperty(short jiaoPropertyId)
	{
		return AddShort(jiaoPropertyId);
	}

	public int AddDestinyType(sbyte destinyType)
	{
		return AddSbyte(destinyType);
	}

	public int AddSecretInformation(short templateId, int id)
	{
		int count = SecretInformations.Count;
		SecretInformations.Add((templateId, id));
		return count;
	}

	public int ConvertSecretInformation(int index, TransferableArgumentCollection oldCollection)
	{
		return AddSecretInformation(oldCollection.SecretInformations[index].Item1, oldCollection.SecretInformations[index].Item2);
	}

	public int AddMerchant(sbyte templateId)
	{
		return AddSbyte(templateId);
	}

	public int AddLegacy(short templateId)
	{
		return AddShort(templateId);
	}

	public int AddCharGrade(sbyte grade)
	{
		return AddSbyte(grade);
	}

	public int AddFeast(short feast)
	{
		return AddShort(feast);
	}

	public int AddAdventureElement(int elementCoreId)
	{
		return AddInt(elementCoreId);
	}

	public int AddPersonalityTypes(sbyte personalityType)
	{
		return AddSbyte(personalityType);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((Floats == null) ? (totalSize + 4) : (totalSize + (4 + 4 * Floats.Count)));
		totalSize = ((ItemKeys == null) ? (totalSize + 4) : (totalSize + (4 + 8 * ItemKeys.Count)));
		totalSize = ((Locations == null) ? (totalSize + 4) : (totalSize + (4 + 4 * Locations.Count)));
		totalSize = ((Items == null) ? (totalSize + 4) : (totalSize + (4 + 3 * Items.Count)));
		totalSize = ((OrgGrades == null) ? (totalSize + 4) : (totalSize + (4 + 4 * OrgGrades.Count)));
		totalSize = ((Crickets == null) ? (totalSize + 4) : (totalSize + (4 + 8 * Crickets.Count)));
		totalSize = ((SecretInformations == null) ? (totalSize + 4) : (totalSize + (4 + 6 * SecretInformations.Count)));
		if (Texts != null)
		{
			totalSize += 4;
			for (int i = 0; i < Texts.Count; i++)
			{
				totalSize = ((Texts[i] == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Texts[i].Length)));
			}
		}
		else
		{
			totalSize += 4;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Floats != null)
		{
			int elementsCount = Floats.Count;
			Tester.Assert(elementsCount <= int.MaxValue);
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			for (int i = 0; i < elementsCount; i++)
			{
				*(float*)pCurrData = Floats[i];
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (ItemKeys != null)
		{
			int elementsCount2 = ItemKeys.Count;
			Tester.Assert(elementsCount2 <= int.MaxValue);
			*(int*)pCurrData = elementsCount2;
			pCurrData += 4;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(ulong*)pCurrData = ItemKeys[j];
				pCurrData += 8;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (Locations != null)
		{
			int elementsCount3 = Locations.Count;
			Tester.Assert(elementsCount3 <= int.MaxValue);
			*(int*)pCurrData = elementsCount3;
			pCurrData += 4;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData += Locations[k].Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (Items != null)
		{
			int elementsCount4 = Items.Count;
			Tester.Assert(elementsCount4 <= int.MaxValue);
			*(int*)pCurrData = elementsCount4;
			pCurrData += 4;
			for (int l = 0; l < elementsCount4; l++)
			{
				*pCurrData = (byte)Items[l].Item1;
				pCurrData++;
				*(short*)pCurrData = Items[l].Item2;
				pCurrData += 2;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (OrgGrades != null)
		{
			int elementsCount5 = OrgGrades.Count;
			Tester.Assert(elementsCount5 <= int.MaxValue);
			*(int*)pCurrData = elementsCount5;
			pCurrData += 4;
			for (int m = 0; m < elementsCount5; m++)
			{
				*pCurrData = (byte)OrgGrades[m].Item1;
				pCurrData++;
				*pCurrData = (byte)OrgGrades[m].Item2;
				pCurrData++;
				*pCurrData = (OrgGrades[m].Item3 ? ((byte)1) : ((byte)0));
				pCurrData++;
				*pCurrData = (byte)OrgGrades[m].Item4;
				pCurrData++;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (Crickets != null)
		{
			int elementsCount6 = Crickets.Count;
			Tester.Assert(elementsCount6 <= int.MaxValue);
			*(int*)pCurrData = elementsCount6;
			pCurrData += 4;
			for (int n = 0; n < elementsCount6; n++)
			{
				*(short*)pCurrData = Crickets[n].Item1;
				pCurrData += 2;
				*(short*)pCurrData = Crickets[n].Item2;
				pCurrData += 2;
				*(int*)pCurrData = Crickets[n].Item3;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (SecretInformations != null)
		{
			int elementsCount7 = SecretInformations.Count;
			Tester.Assert(elementsCount7 <= int.MaxValue);
			*(int*)pCurrData = elementsCount7;
			pCurrData += 4;
			for (int num = 0; num < elementsCount7; num++)
			{
				*(short*)pCurrData = SecretInformations[num].Item1;
				pCurrData += 2;
				*(int*)pCurrData = SecretInformations[num].Item2;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (Texts != null)
		{
			int elementsCount8 = Texts.Count;
			Tester.Assert(elementsCount8 <= int.MaxValue);
			*(int*)pCurrData = elementsCount8;
			pCurrData += 4;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				if (Texts[num2] != null)
				{
					int stringCount = Texts[num2].Length;
					Tester.Assert(stringCount <= 65535);
					*(ushort*)pCurrData = (ushort)stringCount;
					pCurrData += 2;
					fixed (char* pChar = Texts[num2])
					{
						for (int stringIndex = 0; stringIndex < stringCount; stringIndex++)
						{
							((short*)pCurrData)[stringIndex] = (short)pChar[stringIndex];
						}
					}
					pCurrData += 2 * stringCount;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
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
		int elementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (elementsCount > 0)
		{
			if (Floats == null)
			{
				Floats = new List<float>();
			}
			else
			{
				Floats.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				float element = *(float*)pCurrData;
				pCurrData += 4;
				Floats.Add(element);
			}
		}
		else
		{
			Floats?.Clear();
		}
		int elementsCount2 = *(int*)pCurrData;
		pCurrData += 4;
		if (elementsCount2 > 0)
		{
			if (ItemKeys == null)
			{
				ItemKeys = new List<ulong>();
			}
			else
			{
				ItemKeys.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ulong element2 = *(ulong*)pCurrData;
				pCurrData += 8;
				ItemKeys.Add(element2);
			}
		}
		else
		{
			ItemKeys?.Clear();
		}
		int elementsCount3 = *(int*)pCurrData;
		pCurrData += 4;
		if (elementsCount3 > 0)
		{
			if (Locations == null)
			{
				Locations = new List<Location>();
			}
			else
			{
				Locations.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				Location element3 = default(Location);
				pCurrData += element3.Deserialize(pCurrData);
				Locations.Add(element3);
			}
		}
		else
		{
			Locations?.Clear();
		}
		int elementsCount4 = *(int*)pCurrData;
		pCurrData += 4;
		if (elementsCount4 > 0)
		{
			if (Items == null)
			{
				Items = new List<(sbyte, short)>();
			}
			else
			{
				Items.Clear();
			}
			(sbyte, short) element4 = default((sbyte, short));
			for (int l = 0; l < elementsCount4; l++)
			{
				element4.Item1 = (sbyte)(*pCurrData);
				pCurrData++;
				element4.Item2 = *(short*)pCurrData;
				pCurrData += 2;
				Items.Add(element4);
			}
		}
		else
		{
			Items?.Clear();
		}
		int elementsCount5 = *(int*)pCurrData;
		pCurrData += 4;
		if (elementsCount5 > 0)
		{
			if (OrgGrades == null)
			{
				OrgGrades = new List<(sbyte, sbyte, bool, sbyte)>();
			}
			else
			{
				OrgGrades.Clear();
			}
			(sbyte, sbyte, bool, sbyte) element5 = default((sbyte, sbyte, bool, sbyte));
			for (int m = 0; m < elementsCount5; m++)
			{
				element5.Item1 = (sbyte)(*pCurrData);
				pCurrData++;
				element5.Item2 = (sbyte)(*pCurrData);
				pCurrData++;
				element5.Item3 = *pCurrData != 0;
				pCurrData++;
				element5.Item4 = (sbyte)(*pCurrData);
				pCurrData++;
				OrgGrades.Add(element5);
			}
		}
		else
		{
			OrgGrades?.Clear();
		}
		int elementsCount6 = *(int*)pCurrData;
		pCurrData += 4;
		if (elementsCount6 > 0)
		{
			if (Crickets == null)
			{
				Crickets = new List<(short, short, int)>();
			}
			else
			{
				Crickets.Clear();
			}
			(short, short, int) element6 = default((short, short, int));
			for (int n = 0; n < elementsCount6; n++)
			{
				element6.Item1 = *(short*)pCurrData;
				pCurrData += 2;
				element6.Item2 = *(short*)pCurrData;
				pCurrData += 2;
				element6.Item3 = *(int*)pCurrData;
				pCurrData += 4;
				Crickets.Add(element6);
			}
		}
		else
		{
			Crickets?.Clear();
		}
		int elementsCount7 = *(int*)pCurrData;
		pCurrData += 4;
		if (elementsCount7 > 0)
		{
			if (SecretInformations == null)
			{
				SecretInformations = new List<(short, int)>();
			}
			else
			{
				SecretInformations.Clear();
			}
			(short, int) element7 = default((short, int));
			for (int num = 0; num < elementsCount7; num++)
			{
				element7.Item1 = *(short*)pCurrData;
				pCurrData += 2;
				element7.Item2 = *(int*)pCurrData;
				pCurrData += 4;
				SecretInformations.Add(element7);
			}
		}
		else
		{
			SecretInformations?.Clear();
		}
		int elementsCount8 = *(int*)pCurrData;
		pCurrData += 4;
		if (elementsCount8 > 0)
		{
			if (Texts == null)
			{
				Texts = new List<string>();
			}
			else
			{
				Texts.Clear();
			}
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				ushort stringCount = *(ushort*)pCurrData;
				pCurrData += 2;
				string element8;
				if (stringCount > 0)
				{
					int fieldSize = 2 * stringCount;
					element8 = Encoding.Unicode.GetString(pCurrData, fieldSize);
					pCurrData += fieldSize;
				}
				else
				{
					element8 = null;
				}
				Texts.Add(element8);
			}
		}
		else
		{
			Texts?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
