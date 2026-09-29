using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

[SerializableGameData(IsExtensible = true)]
public class SectStoryThiefData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CatchThiefTimes = 0;

		public const ushort AreaId = 1;

		public const ushort ThiefBlockIds = 2;

		public const ushort ThiefTriggered = 3;

		public const ushort RealThiefIndex = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "CatchThiefTimes", "AreaId", "ThiefBlockIds", "ThiefTriggered", "RealThiefIndex" };
	}

	[SerializableGameDataField]
	public int CatchThiefTimes;

	[SerializableGameDataField]
	public short AreaId;

	[SerializableGameDataField]
	public List<short> ThiefBlockIds;

	[SerializableGameDataField]
	public List<bool> ThiefTriggered;

	[SerializableGameDataField]
	public int RealThiefIndex;

	public bool AllIsTriggered()
	{
		bool allIsTriggered = true;
		for (int i = 0; i < ThiefTriggered.Count; i++)
		{
			allIsTriggered = allIsTriggered && ThiefTriggered[i];
		}
		return allIsTriggered;
	}

	public SectStoryThiefData()
	{
	}

	public SectStoryThiefData(SectStoryThiefData other)
	{
		CatchThiefTimes = other.CatchThiefTimes;
		AreaId = other.AreaId;
		ThiefBlockIds = ((other.ThiefBlockIds == null) ? null : new List<short>(other.ThiefBlockIds));
		ThiefTriggered = ((other.ThiefTriggered == null) ? null : new List<bool>(other.ThiefTriggered));
		RealThiefIndex = other.RealThiefIndex;
	}

	public void Assign(SectStoryThiefData other)
	{
		CatchThiefTimes = other.CatchThiefTimes;
		AreaId = other.AreaId;
		ThiefBlockIds = ((other.ThiefBlockIds == null) ? null : new List<short>(other.ThiefBlockIds));
		ThiefTriggered = ((other.ThiefTriggered == null) ? null : new List<bool>(other.ThiefTriggered));
		RealThiefIndex = other.RealThiefIndex;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize = ((ThiefBlockIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ThiefBlockIds.Count)));
		totalSize = ((ThiefTriggered == null) ? (totalSize + 2) : (totalSize + (2 + ThiefTriggered.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 5;
		pCurrData += 2;
		*(int*)pCurrData = CatchThiefTimes;
		pCurrData += 4;
		*(short*)pCurrData = AreaId;
		pCurrData += 2;
		if (ThiefBlockIds != null)
		{
			int elementsCount = ThiefBlockIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = ThiefBlockIds[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ThiefTriggered != null)
		{
			int elementsCount2 = ThiefTriggered.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData[j] = (ThiefTriggered[j] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = RealThiefIndex;
		pCurrData += 4;
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
			CatchThiefTimes = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			AreaId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 2)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (ThiefBlockIds == null)
				{
					ThiefBlockIds = new List<short>(elementsCount);
				}
				else
				{
					ThiefBlockIds.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ThiefBlockIds.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				ThiefBlockIds?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (ThiefTriggered == null)
				{
					ThiefTriggered = new List<bool>(elementsCount2);
				}
				else
				{
					ThiefTriggered.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					ThiefTriggered.Add(pCurrData[j] != 0);
				}
				pCurrData += (int)elementsCount2;
			}
			else
			{
				ThiefTriggered?.Clear();
			}
		}
		if (fieldCount > 4)
		{
			RealThiefIndex = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
