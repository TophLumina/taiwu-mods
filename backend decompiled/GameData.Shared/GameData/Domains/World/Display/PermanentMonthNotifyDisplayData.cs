using System.Collections.Generic;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.World.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class PermanentMonthNotifyDisplayData : ISerializableGameData
{
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public PermanentMonthNotify PermanentMonthNotify;

	[SerializableGameDataField]
	public Dictionary<int, ArgumentCollectionRenderArguments> Arguments;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((PermanentMonthNotify == null) ? (totalSize + 4) : (totalSize + (4 + PermanentMonthNotify.GetSerializedSize())));
		totalSize += 4;
		if (Arguments != null)
		{
			foreach (KeyValuePair<int, ArgumentCollectionRenderArguments> pair in Arguments)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
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
		if (PermanentMonthNotify != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 4;
			int fieldSize = PermanentMonthNotify.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= int.MaxValue);
			*(int*)intPtr = fieldSize;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (Arguments != null)
		{
			*(int*)pCurrData = Arguments.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, ArgumentCollectionRenderArguments> pair in Arguments)
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
		int num = *(int*)pCurrData;
		pCurrData += 4;
		if (num > 0)
		{
			PermanentMonthNotify = new PermanentMonthNotify();
			pCurrData += PermanentMonthNotify.Deserialize(pCurrData);
		}
		else
		{
			PermanentMonthNotify = null;
		}
		int ArgumentsElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (ArgumentsElementsCount > 0)
		{
			if (Arguments == null)
			{
				Arguments = new Dictionary<int, ArgumentCollectionRenderArguments>();
			}
			else
			{
				Arguments.Clear();
			}
			for (int i = 0; i < ArgumentsElementsCount; i++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				ArgumentCollectionRenderArguments value = new ArgumentCollectionRenderArguments();
				pCurrData += value.Deserialize(pCurrData);
				Arguments.Add(key, value);
			}
		}
		else
		{
			Arguments?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
