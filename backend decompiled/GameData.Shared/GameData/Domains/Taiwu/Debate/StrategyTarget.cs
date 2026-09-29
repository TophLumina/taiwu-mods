using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Debate;

public class StrategyTarget : ISerializableGameData
{
	[SerializableGameDataField]
	public int ObjectType;

	[SerializableGameDataField]
	public List<ulong> List;

	public EDebateStrategyTargetObjectType Type => (EDebateStrategyTargetObjectType)ObjectType;

	public StrategyTarget(EDebateStrategyTargetObjectType type, List<ulong> list)
	{
		ObjectType = (int)type;
		List = list;
	}

	public StrategyTarget()
	{
	}

	public StrategyTarget(StrategyTarget other)
	{
		ObjectType = other.ObjectType;
		List = ((other.List == null) ? null : new List<ulong>(other.List));
	}

	public void Assign(StrategyTarget other)
	{
		ObjectType = other.ObjectType;
		List = ((other.List == null) ? null : new List<ulong>(other.List));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((List == null) ? (totalSize + 2) : (totalSize + (2 + 8 * List.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = ObjectType;
		pCurrData += 4;
		if (List != null)
		{
			int elementsCount = List.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((long*)pCurrData)[i] = (long)List[i];
			}
			pCurrData += 8 * elementsCount;
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
		ObjectType = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (List == null)
			{
				List = new List<ulong>(elementsCount);
			}
			else
			{
				List.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				List.Add(((ulong*)pCurrData)[i]);
			}
			pCurrData += 8 * elementsCount;
		}
		else
		{
			List?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
