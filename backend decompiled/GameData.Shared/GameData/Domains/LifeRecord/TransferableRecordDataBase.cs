using System.Collections.Generic;
using System.Linq;
using GameData.DLC.FiveLoong;
using GameData.Domains.Character.Display;
using GameData.Domains.Map;
using GameData.Domains.Organization.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.LifeRecord;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true, NotRestrictCollectionSerializedSize = true, GenerateVirtualMethods = true)]
public class TransferableRecordDataBase : ISerializableGameData
{
	[SerializableGameDataField(FieldIndex = 0)]
	public int HeaderCount;

	[SerializableGameDataField(FieldIndex = 1, CollectionMaxElementsCount = int.MaxValue)]
	public List<TransferableRecord> Record = new List<TransferableRecord>();

	[SerializableGameDataField(FieldIndex = 2, SubDataMaxCount = int.MaxValue)]
	public TransferableArgumentCollection ArgumentCollection = new TransferableArgumentCollection();

	[SerializableGameDataField(FieldIndex = 3, CollectionMaxElementsCount = int.MaxValue)]
	public Dictionary<int, NameAndLifeRelatedData> CharNames;

	[SerializableGameDataField(FieldIndex = 4, CollectionMaxElementsCount = int.MaxValue)]
	public Dictionary<Location, LocationNameRelatedData> LocationNames;

	[SerializableGameDataField(FieldIndex = 5, CollectionMaxElementsCount = int.MaxValue)]
	public Dictionary<short, SettlementNameRelatedData> SettlementNames;

	[SerializableGameDataField(FieldIndex = 6, CollectionMaxElementsCount = int.MaxValue)]
	public Dictionary<int, JiaoLoongNameRelatedData> JiaoLoongNames;

	[SerializableGameDataField(FieldIndex = 7)]
	public int ExtraCount;

	[SerializableGameDataField(FieldIndex = 8)]
	public int TaiwuCharId;

	[SerializableGameDataField(FieldIndex = 9)]
	public int CharId = -1;

	[SerializableGameDataField(FieldIndex = 10)]
	public int StartDate = -1;

	[SerializableGameDataField(FieldIndex = 11)]
	public int EndDate = -1;

	[SerializableGameDataField(FieldIndex = 12)]
	public bool IsDreamBack;

	[SerializableGameDataField(FieldIndex = 13)]
	public short FavorToTaiwu;

	public NameAndLifeRelatedData CharName
	{
		get
		{
			if (CharId != -1)
			{
				return CharNames[CharId];
			}
			return new NameAndLifeRelatedData
			{
				NameRelatedData = default(NameRelatedData),
				LifeState = 2
			};
		}
	}

	public int LifeRecordCount => Record.Count - HeaderCount - ExtraCount;

	public virtual void AddDate(int date, bool increaseExtraCount = true)
	{
		TransferableRecord dateLine = new TransferableRecord(date, -2);
		dateLine.Arguments.Add((-1, date));
		Record.Add(dateLine);
		if (increaseExtraCount)
		{
			ExtraCount++;
		}
	}

	public virtual void AddSeparateLine(int date, bool increaseExtraCount = true)
	{
	}

	public virtual void AddBirth(int date)
	{
	}

	public virtual void TransferData(TransferableRecordDataBase data)
	{
		if (data.LifeRecordCount != 0)
		{
			Record.RemoveRange(Record.Count - HeaderCount, HeaderCount);
			if (StartDate != data.EndDate)
			{
				AddDate(StartDate);
			}
			Record.AddRange(data.Record.Select((TransferableRecord x) => ArgumentCollection.TransferRecord(x, data.ArgumentCollection)));
			MergeDict(ref CharNames, ref data.CharNames);
			MergeDict(ref LocationNames, ref data.LocationNames);
			MergeDict(ref SettlementNames, ref data.SettlementNames);
			MergeDict(ref JiaoLoongNames, ref data.JiaoLoongNames);
			ExtraCount += data.ExtraCount;
			HeaderCount = data.HeaderCount;
			data.Record.Clear();
			data.ArgumentCollection.Clear();
		}
	}

	public void MergeDict<TK, TV>(ref Dictionary<TK, TV> dst, ref Dictionary<TK, TV> src)
	{
		if (src == null)
		{
			return;
		}
		if (dst == null)
		{
			Dictionary<TK, TV> dictionary = dst;
			Dictionary<TK, TV> dictionary2 = src;
			src = dictionary;
			dst = dictionary2;
			return;
		}
		if (src.Count > dst.Count)
		{
			Dictionary<TK, TV> dictionary2 = dst;
			Dictionary<TK, TV> dictionary = src;
			src = dictionary2;
			dst = dictionary;
		}
		foreach (var (k, v) in src)
		{
			dst[k] = v;
		}
		src.Clear();
	}

	public virtual bool IsSerializedSizeFixed()
	{
		return false;
	}

	public virtual int GetSerializedSize()
	{
		int totalSize = 27;
		if (Record != null)
		{
			totalSize += 4;
			for (int i = 0; i < Record.Count; i++)
			{
				totalSize = ((Record[i] == null) ? (totalSize + 2) : (totalSize + (2 + Record[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 4;
		}
		totalSize = ((ArgumentCollection == null) ? (totalSize + 4) : (totalSize + (4 + ArgumentCollection.GetSerializedSize())));
		totalSize += 4;
		if (CharNames != null)
		{
			foreach (KeyValuePair<int, NameAndLifeRelatedData> pair in CharNames)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (LocationNames != null)
		{
			foreach (KeyValuePair<Location, LocationNameRelatedData> pair2 in LocationNames)
			{
				totalSize += pair2.Key.GetSerializedSize();
				totalSize += pair2.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (SettlementNames != null)
		{
			foreach (KeyValuePair<short, SettlementNameRelatedData> pair3 in SettlementNames)
			{
				totalSize += 2;
				totalSize += pair3.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (JiaoLoongNames != null)
		{
			foreach (KeyValuePair<int, JiaoLoongNameRelatedData> pair4 in JiaoLoongNames)
			{
				totalSize += 4;
				totalSize += pair4.Value.GetSerializedSize();
			}
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe virtual int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = HeaderCount;
		pCurrData += 4;
		if (Record != null)
		{
			int elementsCount = Record.Count;
			Tester.Assert(elementsCount <= int.MaxValue);
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			for (int i = 0; i < elementsCount; i++)
			{
				if (Record[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = Record[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
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
		if (ArgumentCollection != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 4;
			int fieldSize2 = ArgumentCollection.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= int.MaxValue);
			*(int*)intPtr2 = fieldSize2;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (CharNames != null)
		{
			*(int*)pCurrData = CharNames.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, NameAndLifeRelatedData> pair in CharNames)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (LocationNames != null)
		{
			*(int*)pCurrData = LocationNames.Count;
			pCurrData += 4;
			foreach (KeyValuePair<Location, LocationNameRelatedData> pair2 in LocationNames)
			{
				pCurrData += pair2.Key.Serialize(pCurrData);
				pCurrData += pair2.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (SettlementNames != null)
		{
			*(int*)pCurrData = SettlementNames.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, SettlementNameRelatedData> pair3 in SettlementNames)
			{
				*(short*)pCurrData = pair3.Key;
				pCurrData += 2;
				pCurrData += pair3.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (JiaoLoongNames != null)
		{
			*(int*)pCurrData = JiaoLoongNames.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, JiaoLoongNameRelatedData> pair4 in JiaoLoongNames)
			{
				*(int*)pCurrData = pair4.Key;
				pCurrData += 4;
				pCurrData += pair4.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*(int*)pCurrData = ExtraCount;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuCharId;
		pCurrData += 4;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*(int*)pCurrData = StartDate;
		pCurrData += 4;
		*(int*)pCurrData = EndDate;
		pCurrData += 4;
		*pCurrData = (IsDreamBack ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = FavorToTaiwu;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe virtual int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		HeaderCount = *(int*)pCurrData;
		pCurrData += 4;
		int elementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (elementsCount > 0)
		{
			if (Record == null)
			{
				Record = new List<TransferableRecord>();
			}
			else
			{
				Record.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				TransferableRecord element;
				if (num > 0)
				{
					element = new TransferableRecord();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				Record.Add(element);
			}
		}
		else
		{
			Record?.Clear();
		}
		int num2 = *(int*)pCurrData;
		pCurrData += 4;
		if (num2 > 0)
		{
			ArgumentCollection = new TransferableArgumentCollection();
			pCurrData += ArgumentCollection.Deserialize(pCurrData);
		}
		else
		{
			ArgumentCollection = null;
		}
		int CharNamesElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (CharNamesElementsCount > 0)
		{
			if (CharNames == null)
			{
				CharNames = new Dictionary<int, NameAndLifeRelatedData>();
			}
			else
			{
				CharNames.Clear();
			}
			for (int j = 0; j < CharNamesElementsCount; j++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				NameAndLifeRelatedData value = default(NameAndLifeRelatedData);
				pCurrData += value.Deserialize(pCurrData);
				CharNames.Add(key, value);
			}
		}
		else
		{
			CharNames?.Clear();
		}
		int LocationNamesElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (LocationNamesElementsCount > 0)
		{
			if (LocationNames == null)
			{
				LocationNames = new Dictionary<Location, LocationNameRelatedData>();
			}
			else
			{
				LocationNames.Clear();
			}
			for (int k = 0; k < LocationNamesElementsCount; k++)
			{
				Location key2 = default(Location);
				pCurrData += key2.Deserialize(pCurrData);
				LocationNameRelatedData value2 = default(LocationNameRelatedData);
				pCurrData += value2.Deserialize(pCurrData);
				LocationNames.Add(key2, value2);
			}
		}
		else
		{
			LocationNames?.Clear();
		}
		int SettlementNamesElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (SettlementNamesElementsCount > 0)
		{
			if (SettlementNames == null)
			{
				SettlementNames = new Dictionary<short, SettlementNameRelatedData>();
			}
			else
			{
				SettlementNames.Clear();
			}
			for (int l = 0; l < SettlementNamesElementsCount; l++)
			{
				short key3 = *(short*)pCurrData;
				pCurrData += 2;
				SettlementNameRelatedData value3 = default(SettlementNameRelatedData);
				pCurrData += value3.Deserialize(pCurrData);
				SettlementNames.Add(key3, value3);
			}
		}
		else
		{
			SettlementNames?.Clear();
		}
		int JiaoLoongNamesElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (JiaoLoongNamesElementsCount > 0)
		{
			if (JiaoLoongNames == null)
			{
				JiaoLoongNames = new Dictionary<int, JiaoLoongNameRelatedData>();
			}
			else
			{
				JiaoLoongNames.Clear();
			}
			for (int m = 0; m < JiaoLoongNamesElementsCount; m++)
			{
				int key4 = *(int*)pCurrData;
				pCurrData += 4;
				JiaoLoongNameRelatedData value4 = default(JiaoLoongNameRelatedData);
				pCurrData += value4.Deserialize(pCurrData);
				JiaoLoongNames.Add(key4, value4);
			}
		}
		else
		{
			JiaoLoongNames?.Clear();
		}
		ExtraCount = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuCharId = *(int*)pCurrData;
		pCurrData += 4;
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		StartDate = *(int*)pCurrData;
		pCurrData += 4;
		EndDate = *(int*)pCurrData;
		pCurrData += 4;
		IsDreamBack = *pCurrData != 0;
		pCurrData++;
		FavorToTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
