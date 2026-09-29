using System;
using System.Collections.Generic;
using System.Text;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[SerializableGameData(IsExtensible = true)]
public class BeggarSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort LookingForCharName = 0;

		public const ushort AlreadyFoundCharacters = 1;

		public const ushort ForbiddenLocations = 2;

		public const ushort EatenItems = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "LookingForCharName", "AlreadyFoundCharacters", "ForbiddenLocations", "EatenItems" };
	}

	[SerializableGameDataField]
	public string LookingForCharName;

	[SerializableGameDataField]
	public CharacterSet AlreadyFoundCharacters;

	[SerializableGameDataField]
	public List<Location> ForbiddenLocations;

	[Obsolete]
	[SerializableGameDataField]
	public List<ItemKey> EatenItems;

	public bool FoundMoreAlive;

	public bool FoundMoreDead;

	public void Initialize()
	{
		ClearData();
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		if (sourceData is ObsoleteBeggarSkillsData skillsData)
		{
			LookingForCharName = skillsData.LookingForCharName;
			FoundMoreAlive = skillsData.FoundMoreAlive;
			FoundMoreDead = skillsData.FoundMoreDead;
			AlreadyFoundCharacters = skillsData.AlreadyFoundCharacters;
			if (ForbiddenLocations == null)
			{
				ForbiddenLocations = new List<Location>();
			}
		}
	}

	public void ClearData()
	{
		LookingForCharName = null;
		AlreadyFoundCharacters.Clear();
		FoundMoreDead = false;
		FoundMoreAlive = false;
		if (ForbiddenLocations != null)
		{
			ForbiddenLocations.Clear();
		}
		else
		{
			ForbiddenLocations = new List<Location>();
		}
		if (EatenItems != null)
		{
			EatenItems.Clear();
		}
		else
		{
			EatenItems = new List<ItemKey>();
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((LookingForCharName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LookingForCharName.Length)));
		totalSize += AlreadyFoundCharacters.GetSerializedSize();
		totalSize = ((ForbiddenLocations == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ForbiddenLocations.Count)));
		totalSize = ((EatenItems == null) ? (totalSize + 2) : (totalSize + (2 + 8 * EatenItems.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 4;
		pCurrData += 2;
		if (LookingForCharName != null)
		{
			int elementsCount = LookingForCharName.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = LookingForCharName)
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
		int fieldSize = AlreadyFoundCharacters.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		if (ForbiddenLocations != null)
		{
			int elementsCount2 = ForbiddenLocations.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += ForbiddenLocations[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (EatenItems != null)
		{
			int elementsCount3 = EatenItems.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData += EatenItems[k].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				int fieldSize = 2 * elementsCount;
				LookingForCharName = Encoding.Unicode.GetString(pCurrData, fieldSize);
				pCurrData += fieldSize;
			}
			else
			{
				LookingForCharName = null;
			}
		}
		if (fieldCount > 1)
		{
			pCurrData += AlreadyFoundCharacters.Deserialize(pCurrData);
		}
		if (fieldCount > 2)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (ForbiddenLocations == null)
				{
					ForbiddenLocations = new List<Location>(elementsCount2);
				}
				else
				{
					ForbiddenLocations.Clear();
				}
				for (int i = 0; i < elementsCount2; i++)
				{
					Location element = default(Location);
					pCurrData += element.Deserialize(pCurrData);
					ForbiddenLocations.Add(element);
				}
			}
			else
			{
				ForbiddenLocations?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (EatenItems == null)
				{
					EatenItems = new List<ItemKey>(elementsCount3);
				}
				else
				{
					EatenItems.Clear();
				}
				for (int j = 0; j < elementsCount3; j++)
				{
					ItemKey element2 = default(ItemKey);
					pCurrData += element2.Deserialize(pCurrData);
					EatenItems.Add(element2);
				}
			}
			else
			{
				EatenItems?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
