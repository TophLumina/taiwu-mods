using System.Collections.Generic;
using GameData.Domains.Character.Ai;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[SerializableGameData(IsExtensible = true)]
public class VillagerTreasuryNeed : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort PersonalNeeds = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "PersonalNeeds" };
	}

	[SerializableGameDataField]
	public List<PersonalNeed> PersonalNeeds;

	public VillagerTreasuryNeed()
	{
	}

	public VillagerTreasuryNeed(VillagerTreasuryNeed other)
	{
		PersonalNeeds = ((other.PersonalNeeds == null) ? null : new List<PersonalNeed>(other.PersonalNeeds));
	}

	public void Assign(VillagerTreasuryNeed other)
	{
		PersonalNeeds = ((other.PersonalNeeds == null) ? null : new List<PersonalNeed>(other.PersonalNeeds));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((PersonalNeeds == null) ? (totalSize + 2) : (totalSize + (2 + 8 * PersonalNeeds.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 1;
		pCurrData += 2;
		if (PersonalNeeds != null)
		{
			int elementsCount = PersonalNeeds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += PersonalNeeds[i].Serialize(pCurrData);
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (PersonalNeeds == null)
				{
					PersonalNeeds = new List<PersonalNeed>(elementsCount);
				}
				else
				{
					PersonalNeeds.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					PersonalNeed element = default(PersonalNeed);
					pCurrData += element.Deserialize(pCurrData);
					PersonalNeeds.Add(element);
				}
			}
			else
			{
				PersonalNeeds?.Clear();
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
