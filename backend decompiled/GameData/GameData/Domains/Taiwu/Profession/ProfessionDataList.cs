using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true, NotForDisplayModule = true)]
public class ProfessionDataList : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CurrProfessionId = 0;

		public const ushort Items = 1;

		public const ushort TaiwuDemandTeachingCount = 2;

		public const ushort LastTeachTaiwuDate = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "CurrProfessionId", "Items", "TaiwuDemandTeachingCount", "LastTeachTaiwuDate" };
	}

	[SerializableGameDataField]
	public int CurrProfessionId;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	private List<ProfessionData> _items;

	[SerializableGameDataField]
	[Obsolete]
	private Dictionary<int, int> _taiwuDemandTeachingCount;

	[SerializableGameDataField]
	private int _lastTeachTaiwuDate;

	public ProfessionData CurrProfession
	{
		get
		{
			for (int index = _items.Count - 1; index >= 0; index--)
			{
				ProfessionData profession = _items[index];
				if (profession.TemplateId == CurrProfessionId)
				{
					return profession;
				}
			}
			return null;
		}
	}

	public ProfessionDataList()
	{
		_items = new List<ProfessionData>();
		_lastTeachTaiwuDate = int.MinValue;
	}

	[Obsolete]
	public int GetTeachTaiwuCount(int professionId)
	{
		return _taiwuDemandTeachingCount?.GetValueOrDefault(professionId, 0) ?? 0;
	}

	[Obsolete]
	public void AddTeachTaiwuCount(int professionId, int count)
	{
		if (_taiwuDemandTeachingCount == null)
		{
			_taiwuDemandTeachingCount = new Dictionary<int, int>();
		}
		int prevCount = _taiwuDemandTeachingCount.GetValueOrDefault(professionId, 0);
		_taiwuDemandTeachingCount[professionId] = prevCount + count;
	}

	public int GetTeachTaiwuDate()
	{
		return _lastTeachTaiwuDate;
	}

	public void SetTeachTaiwuDate(int date)
	{
		_lastTeachTaiwuDate = date;
	}

	public ProfessionData GetProfession(int professionId)
	{
		for (int i = _items.Count - 1; i >= 0; i--)
		{
			ProfessionData profession = _items[i];
			if (profession.TemplateId == professionId)
			{
				return profession;
			}
		}
		return null;
	}

	public List<ProfessionData> GetAllProfession()
	{
		return _items;
	}

	public ProfessionData ChangeCurrProfession(int professionId)
	{
		CurrProfessionId = professionId;
		ProfessionData professionData = GetProfession(professionId);
		if (professionData != null)
		{
			return professionData;
		}
		professionData = new ProfessionData(professionId, 1);
		_items.Add(professionData);
		return professionData;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (_items != null)
		{
			totalSize += 2;
			int elementsCount = _items.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				ProfessionData element = _items[i];
				totalSize = ((element == null) ? (totalSize + 4) : (totalSize + (4 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(_taiwuDemandTeachingCount);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 4;
		pCurrData += 2;
		*(int*)pCurrData = CurrProfessionId;
		pCurrData += 4;
		if (_items != null)
		{
			int elementsCount = _items.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				ProfessionData element = _items[i];
				if (element != null)
				{
					byte* pSubDataCount = pCurrData;
					pCurrData += 4;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= int.MaxValue);
					*(int*)pSubDataCount = subDataSize;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref _taiwuDemandTeachingCount);
		*(int*)pCurrData = _lastTeachTaiwuDate;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			CurrProfessionId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (_items == null)
				{
					_items = new List<ProfessionData>(elementsCount);
				}
				else
				{
					_items.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					int subDataCount = *(int*)pCurrData;
					pCurrData += 4;
					if (subDataCount > 0)
					{
						ProfessionData element = new ProfessionData();
						pCurrData += element.Deserialize(pCurrData);
						_items.Add(element);
					}
					else
					{
						_items.Add(null);
					}
				}
			}
			else
			{
				_items?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref _taiwuDemandTeachingCount);
		}
		if (fieldCount > 3)
		{
			_lastTeachTaiwuDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
