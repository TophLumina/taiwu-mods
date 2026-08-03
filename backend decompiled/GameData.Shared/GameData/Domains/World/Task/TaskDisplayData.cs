using System.Collections.Generic;
using System.Text;
using GameData.Domains.Map;
using GameData.Domains.Organization.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.World.Task;

public struct TaskDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public TaskData InnerTaskData;

	[SerializableGameDataField]
	public Location TargetLocation;

	[SerializableGameDataField]
	public ShortList SkillIdList;

	[SerializableGameDataField]
	public int CountDown;

	[SerializableGameDataField]
	public string[] StringArray;

	[SerializableGameDataField]
	public int DisplayType;

	[SerializableGameDataField]
	public SettlementNameRelatedData SettlementNameData;

	[SerializableGameDataField]
	public List<Location> TargetLocations;

	[SerializableGameDataField]
	public List<SettlementNameRelatedData> SettlementNameDatas;

	[SerializableGameDataField]
	public int FinishedDate;

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TaskDisplayData(TaskDisplayData other)
	{
		InnerTaskData = other.InnerTaskData;
		TargetLocation = other.TargetLocation;
		SkillIdList = new ShortList(other.SkillIdList);
		CountDown = other.CountDown;
		string[] item = other.StringArray;
		int elementsCount = item.Length;
		StringArray = new string[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			StringArray[i] = item[i];
		}
		DisplayType = other.DisplayType;
		SettlementNameData = other.SettlementNameData;
		TargetLocations = ((other.TargetLocations == null) ? null : new List<Location>(other.TargetLocations));
		SettlementNameDatas = ((other.SettlementNameDatas == null) ? null : new List<SettlementNameRelatedData>(other.SettlementNameDatas));
		FinishedDate = other.FinishedDate;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TaskDisplayData other)
	{
		InnerTaskData = other.InnerTaskData;
		TargetLocation = other.TargetLocation;
		SkillIdList = new ShortList(other.SkillIdList);
		CountDown = other.CountDown;
		string[] item = other.StringArray;
		int elementsCount = item.Length;
		StringArray = new string[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			StringArray[i] = item[i];
		}
		DisplayType = other.DisplayType;
		SettlementNameData = other.SettlementNameData;
		TargetLocations = ((other.TargetLocations == null) ? null : new List<Location>(other.TargetLocations));
		SettlementNameDatas = ((other.SettlementNameDatas == null) ? null : new List<SettlementNameRelatedData>(other.SettlementNameDatas));
		FinishedDate = other.FinishedDate;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 32;
		totalSize += SkillIdList.GetSerializedSize();
		if (StringArray != null)
		{
			totalSize += 2;
			int elementsCount = StringArray.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				string element = StringArray[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + 2 * element.Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((TargetLocations == null) ? (totalSize + 2) : (totalSize + (2 + 4 * TargetLocations.Count)));
		totalSize = ((SettlementNameDatas == null) ? (totalSize + 2) : (totalSize + (2 + 4 * SettlementNameDatas.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += InnerTaskData.Serialize(pCurrData);
		pCurrData += TargetLocation.Serialize(pCurrData);
		int fieldSize = SkillIdList.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = CountDown;
		pCurrData += 4;
		if (StringArray != null)
		{
			int elementsCount = StringArray.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				string element = StringArray[i];
				if (element != null)
				{
					int subElementsCount = element.Length;
					Tester.Assert(subElementsCount <= 65535);
					*(ushort*)pCurrData = (ushort)subElementsCount;
					pCurrData += 2;
					fixed (char* pChar = element)
					{
						for (int j = 0; j < subElementsCount; j++)
						{
							((short*)pCurrData)[j] = (short)pChar[j];
						}
					}
					pCurrData += 2 * subElementsCount;
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
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = DisplayType;
		pCurrData += 4;
		pCurrData += SettlementNameData.Serialize(pCurrData);
		if (TargetLocations != null)
		{
			int elementsCount2 = TargetLocations.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int k = 0; k < elementsCount2; k++)
			{
				pCurrData += TargetLocations[k].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SettlementNameDatas != null)
		{
			int elementsCount3 = SettlementNameDatas.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int l = 0; l < elementsCount3; l++)
			{
				pCurrData += SettlementNameDatas[l].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = FinishedDate;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += InnerTaskData.Deserialize(pCurrData);
		pCurrData += TargetLocation.Deserialize(pCurrData);
		pCurrData += SkillIdList.Deserialize(pCurrData);
		CountDown = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (StringArray == null || StringArray.Length != elementsCount)
			{
				StringArray = new string[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort subDataCount = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount > 0)
				{
					int subDataSize = 2 * subDataCount;
					StringArray[i] = Encoding.Unicode.GetString(pCurrData, subDataSize);
					pCurrData += subDataSize;
				}
				else
				{
					StringArray[i] = null;
				}
			}
		}
		else
		{
			StringArray = null;
		}
		DisplayType = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += SettlementNameData.Deserialize(pCurrData);
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (TargetLocations == null)
			{
				TargetLocations = new List<Location>(elementsCount2);
			}
			else
			{
				TargetLocations.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				Location element = default(Location);
				pCurrData += element.Deserialize(pCurrData);
				TargetLocations.Add(element);
			}
		}
		else
		{
			TargetLocations?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (SettlementNameDatas == null)
			{
				SettlementNameDatas = new List<SettlementNameRelatedData>(elementsCount3);
			}
			else
			{
				SettlementNameDatas.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				SettlementNameRelatedData element2 = default(SettlementNameRelatedData);
				pCurrData += element2.Deserialize(pCurrData);
				SettlementNameDatas.Add(element2);
			}
		}
		else
		{
			SettlementNameDatas?.Clear();
		}
		FinishedDate = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
