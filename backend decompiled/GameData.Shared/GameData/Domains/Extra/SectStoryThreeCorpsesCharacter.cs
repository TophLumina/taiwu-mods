using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

[SerializableGameData(IsExtensible = true)]
public class SectStoryThreeCorpsesCharacter : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort TemplateId = 0;

		public const ushort IsGoodEnd = 1;

		public const ushort Target = 2;

		public const ushort EndDate = 3;

		public const ushort NextDate = 4;

		public const ushort Notch = 5;

		public const ushort LegendaryBooks = 6;

		public const ushort IsUpgraded = 7;

		public const ushort Id = 8;

		public const ushort TargetOwner = 9;

		public const ushort Progress = 10;

		public const ushort IsAroundTaiwu = 11;

		public const ushort TaiwuId = 12;

		public const ushort PassLegacyEventTriggered = 13;

		public const ushort GiveUpCount = 14;

		public const ushort Count = 15;

		public static readonly string[] FieldId2FieldName = new string[15]
		{
			"TemplateId", "IsGoodEnd", "Target", "EndDate", "NextDate", "Notch", "LegendaryBooks", "IsUpgraded", "Id", "TargetOwner",
			"Progress", "IsAroundTaiwu", "TaiwuId", "PassLegacyEventTriggered", "GiveUpCount"
		};
	}

	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public bool IsGoodEnd;

	[SerializableGameDataField]
	public sbyte Progress;

	[SerializableGameDataField]
	public sbyte Target;

	[SerializableGameDataField]
	public int TargetOwner;

	[SerializableGameDataField]
	public int EndDate;

	[SerializableGameDataField]
	public int NextDate;

	[SerializableGameDataField]
	public sbyte Notch;

	[SerializableGameDataField]
	public List<sbyte> LegendaryBooks;

	[SerializableGameDataField]
	public bool IsUpgraded;

	[SerializableGameDataField]
	public bool IsAroundTaiwu;

	[SerializableGameDataField]
	public int TaiwuId;

	[SerializableGameDataField]
	public bool PassLegacyEventTriggered;

	[SerializableGameDataField]
	public Dictionary<int, int> GiveUpCount;

	public SectStoryThreeCorpsesCharacter(int id, short templateId, int taiwuId)
	{
		Id = id;
		TemplateId = templateId;
		IsGoodEnd = false;
		Progress = 0;
		Target = -1;
		TargetOwner = -1;
		EndDate = -1;
		NextDate = -1;
		Notch = 0;
		LegendaryBooks = null;
		IsUpgraded = false;
		IsAroundTaiwu = true;
		TaiwuId = taiwuId;
		PassLegacyEventTriggered = false;
		GiveUpCount = new Dictionary<int, int>();
	}

	public SectStoryThreeCorpsesCharacter()
	{
	}

	public SectStoryThreeCorpsesCharacter(SectStoryThreeCorpsesCharacter other)
	{
		TemplateId = other.TemplateId;
		IsGoodEnd = other.IsGoodEnd;
		Target = other.Target;
		EndDate = other.EndDate;
		NextDate = other.NextDate;
		Notch = other.Notch;
		LegendaryBooks = ((other.LegendaryBooks == null) ? null : new List<sbyte>(other.LegendaryBooks));
		IsUpgraded = other.IsUpgraded;
		Id = other.Id;
		TargetOwner = other.TargetOwner;
		Progress = other.Progress;
		IsAroundTaiwu = other.IsAroundTaiwu;
		TaiwuId = other.TaiwuId;
		PassLegacyEventTriggered = other.PassLegacyEventTriggered;
		GiveUpCount = ((other.GiveUpCount == null) ? null : new Dictionary<int, int>(other.GiveUpCount));
	}

	public void Assign(SectStoryThreeCorpsesCharacter other)
	{
		TemplateId = other.TemplateId;
		IsGoodEnd = other.IsGoodEnd;
		Target = other.Target;
		EndDate = other.EndDate;
		NextDate = other.NextDate;
		Notch = other.Notch;
		LegendaryBooks = ((other.LegendaryBooks == null) ? null : new List<sbyte>(other.LegendaryBooks));
		IsUpgraded = other.IsUpgraded;
		Id = other.Id;
		TargetOwner = other.TargetOwner;
		Progress = other.Progress;
		IsAroundTaiwu = other.IsAroundTaiwu;
		TaiwuId = other.TaiwuId;
		PassLegacyEventTriggered = other.PassLegacyEventTriggered;
		GiveUpCount = ((other.GiveUpCount == null) ? null : new Dictionary<int, int>(other.GiveUpCount));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 31;
		totalSize = ((LegendaryBooks == null) ? (totalSize + 2) : (totalSize + (2 + LegendaryBooks.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(GiveUpCount);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 15;
		pCurrData += 2;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*pCurrData = (IsGoodEnd ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)Target;
		pCurrData++;
		*(int*)pCurrData = EndDate;
		pCurrData += 4;
		*(int*)pCurrData = NextDate;
		pCurrData += 4;
		*pCurrData = (byte)Notch;
		pCurrData++;
		if (LegendaryBooks != null)
		{
			int elementsCount = LegendaryBooks.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = (byte)LegendaryBooks[i];
			}
			pCurrData += elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsUpgraded ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(int*)pCurrData = TargetOwner;
		pCurrData += 4;
		*pCurrData = (byte)Progress;
		pCurrData++;
		*pCurrData = (IsAroundTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = TaiwuId;
		pCurrData += 4;
		*pCurrData = (PassLegacyEventTriggered ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref GiveUpCount);
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
			TemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 1)
		{
			IsGoodEnd = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			Target = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 3)
		{
			EndDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 4)
		{
			NextDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 5)
		{
			Notch = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 6)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (LegendaryBooks == null)
				{
					LegendaryBooks = new List<sbyte>(elementsCount);
				}
				else
				{
					LegendaryBooks.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					LegendaryBooks.Add((sbyte)pCurrData[i]);
				}
				pCurrData += (int)elementsCount;
			}
			else
			{
				LegendaryBooks?.Clear();
			}
		}
		if (fieldCount > 7)
		{
			IsUpgraded = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 8)
		{
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 9)
		{
			TargetOwner = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 10)
		{
			Progress = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 11)
		{
			IsAroundTaiwu = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 12)
		{
			TaiwuId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 13)
		{
			PassLegacyEventTriggered = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 14)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref GiveUpCount);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
