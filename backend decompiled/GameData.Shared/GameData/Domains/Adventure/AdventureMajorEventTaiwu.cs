using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Adventure;

[AutoGenerateSerializableGameData(IsExtensible = true)]
public class AdventureMajorEventTaiwu : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort AdventureId = 0;

		public const ushort Current = 1;

		public const ushort CurrentMain = 2;

		public const ushort UnlockedNodes = 3;

		public const ushort VisitedNodes = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "AdventureId", "Current", "CurrentMain", "UnlockedNodes", "VisitedNodes" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int AdventureId;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Current;

	[SerializableGameDataField(FieldIndex = 2)]
	public int CurrentMain;

	[SerializableGameDataField(FieldIndex = 3)]
	public List<int> UnlockedNodes = new List<int>();

	[SerializableGameDataField(FieldIndex = 4)]
	public List<int> VisitedNodes = new List<int>();

	public bool InAdventure => AdventureId >= 1;

	public bool NotInAdventure => !InAdventure;

	public AdventureMajorEvent MajorEvent => ExternalDataBridge.Context.GetMajorEvent(AdventureId);

	public void Reset()
	{
		AdventureId = 0;
		Current = (CurrentMain = -1);
		UnlockedNodes.Clear();
		VisitedNodes.Clear();
	}

	public AdventureMajorEventTaiwu()
	{
	}

	public AdventureMajorEventTaiwu(AdventureMajorEventTaiwu other)
	{
		AdventureId = other.AdventureId;
		Current = other.Current;
		CurrentMain = other.CurrentMain;
		UnlockedNodes = ((other.UnlockedNodes == null) ? null : new List<int>(other.UnlockedNodes));
		VisitedNodes = ((other.VisitedNodes == null) ? null : new List<int>(other.VisitedNodes));
	}

	public void Assign(AdventureMajorEventTaiwu other)
	{
		AdventureId = other.AdventureId;
		Current = other.Current;
		CurrentMain = other.CurrentMain;
		UnlockedNodes = ((other.UnlockedNodes == null) ? null : new List<int>(other.UnlockedNodes));
		VisitedNodes = ((other.VisitedNodes == null) ? null : new List<int>(other.VisitedNodes));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 14;
		totalSize = ((UnlockedNodes == null) ? (totalSize + 2) : (totalSize + (2 + 4 * UnlockedNodes.Count)));
		totalSize = ((VisitedNodes == null) ? (totalSize + 2) : (totalSize + (2 + 4 * VisitedNodes.Count)));
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
		*(int*)pCurrData = AdventureId;
		pCurrData += 4;
		*(int*)pCurrData = Current;
		pCurrData += 4;
		*(int*)pCurrData = CurrentMain;
		pCurrData += 4;
		if (UnlockedNodes != null)
		{
			int elementsCount = UnlockedNodes.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(int*)pCurrData = UnlockedNodes[i];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (VisitedNodes != null)
		{
			int elementsCount2 = VisitedNodes.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(int*)pCurrData = VisitedNodes[j];
				pCurrData += 4;
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
			AdventureId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			Current = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			CurrentMain = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (UnlockedNodes == null)
				{
					UnlockedNodes = new List<int>();
				}
				else
				{
					UnlockedNodes.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					int element = *(int*)pCurrData;
					pCurrData += 4;
					UnlockedNodes.Add(element);
				}
			}
			else
			{
				UnlockedNodes?.Clear();
			}
		}
		if (fieldCount > 4)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (VisitedNodes == null)
				{
					VisitedNodes = new List<int>();
				}
				else
				{
					VisitedNodes.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					int element2 = *(int*)pCurrData;
					pCurrData += 4;
					VisitedNodes.Add(element2);
				}
			}
			else
			{
				VisitedNodes?.Clear();
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
