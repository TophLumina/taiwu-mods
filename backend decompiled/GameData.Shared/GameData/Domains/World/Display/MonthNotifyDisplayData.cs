using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.World.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class MonthNotifyDisplayData : ISerializableGameData
{
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<MonthNotify> MonthNotifies = new List<MonthNotify>();

	[SerializableGameDataField]
	public Dictionary<int, FullBlockName> SecretInformationLocation = new Dictionary<int, FullBlockName>();

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ArgumentCollectionRenderArguments> Arguments = new List<ArgumentCollectionRenderArguments>();

	[SerializableGameDataField]
	public Dictionary<ItemKey, ItemDisplayData> EatenItem = new Dictionary<ItemKey, ItemDisplayData>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (MonthNotifies != null)
		{
			totalSize += 2;
			for (int i = 0; i < MonthNotifies.Count; i++)
			{
				totalSize = ((MonthNotifies[i] == null) ? (totalSize + 4) : (totalSize + (4 + MonthNotifies[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += 4;
		if (SecretInformationLocation != null)
		{
			foreach (KeyValuePair<int, FullBlockName> pair in SecretInformationLocation)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		if (Arguments != null)
		{
			totalSize += 2;
			for (int j = 0; j < Arguments.Count; j++)
			{
				totalSize = ((Arguments[j] == null) ? (totalSize + 4) : (totalSize + (4 + Arguments[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += 4;
		if (EatenItem != null)
		{
			foreach (KeyValuePair<ItemKey, ItemDisplayData> pair2 in EatenItem)
			{
				totalSize += pair2.Key.GetSerializedSize();
				totalSize += pair2.Value.GetSerializedSize();
			}
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
		if (MonthNotifies != null)
		{
			int elementsCount = MonthNotifies.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (MonthNotifies[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 4;
					int fieldSize = MonthNotifies[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= int.MaxValue);
					*(int*)intPtr = fieldSize;
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
		if (SecretInformationLocation != null)
		{
			*(int*)pCurrData = SecretInformationLocation.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, FullBlockName> pair in SecretInformationLocation)
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
		if (Arguments != null)
		{
			int elementsCount2 = Arguments.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (Arguments[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 4;
					int fieldSize2 = Arguments[j].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= int.MaxValue);
					*(int*)intPtr2 = fieldSize2;
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
		if (EatenItem != null)
		{
			*(int*)pCurrData = EatenItem.Count;
			pCurrData += 4;
			foreach (KeyValuePair<ItemKey, ItemDisplayData> pair2 in EatenItem)
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (MonthNotifies == null)
			{
				MonthNotifies = new List<MonthNotify>();
			}
			else
			{
				MonthNotifies.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int num = *(int*)pCurrData;
				pCurrData += 4;
				MonthNotify element;
				if (num > 0)
				{
					element = new MonthNotify();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				MonthNotifies.Add(element);
			}
		}
		else
		{
			MonthNotifies?.Clear();
		}
		int SecretInformationLocationElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (SecretInformationLocationElementsCount > 0)
		{
			if (SecretInformationLocation == null)
			{
				SecretInformationLocation = new Dictionary<int, FullBlockName>();
			}
			else
			{
				SecretInformationLocation.Clear();
			}
			for (int j = 0; j < SecretInformationLocationElementsCount; j++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				FullBlockName value = default(FullBlockName);
				pCurrData += value.Deserialize(pCurrData);
				SecretInformationLocation.Add(key, value);
			}
		}
		else
		{
			SecretInformationLocation?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (Arguments == null)
			{
				Arguments = new List<ArgumentCollectionRenderArguments>();
			}
			else
			{
				Arguments.Clear();
			}
			for (int k = 0; k < elementsCount2; k++)
			{
				int num2 = *(int*)pCurrData;
				pCurrData += 4;
				ArgumentCollectionRenderArguments element2;
				if (num2 > 0)
				{
					element2 = new ArgumentCollectionRenderArguments();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				Arguments.Add(element2);
			}
		}
		else
		{
			Arguments?.Clear();
		}
		int EatenItemElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (EatenItemElementsCount > 0)
		{
			if (EatenItem == null)
			{
				EatenItem = new Dictionary<ItemKey, ItemDisplayData>();
			}
			else
			{
				EatenItem.Clear();
			}
			for (int l = 0; l < EatenItemElementsCount; l++)
			{
				ItemKey key2 = default(ItemKey);
				pCurrData += key2.Deserialize(pCurrData);
				ItemDisplayData value2 = new ItemDisplayData();
				pCurrData += value2.Deserialize(pCurrData);
				EatenItem.Add(key2, value2);
			}
		}
		else
		{
			EatenItem?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
