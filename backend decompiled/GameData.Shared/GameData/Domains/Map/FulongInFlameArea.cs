using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

[SerializableGameData(IsExtensible = true)]
public class FulongInFlameArea : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort LightedBlocks = 0;

		public const ushort ExtinguishedBlocks = 1;

		public const ushort MineBlocks = 2;

		public const ushort TriggeredMineBlocks = 3;

		public const ushort RewardGrade = 4;

		public const ushort EdgeBlocks = 5;

		public const ushort AreaId = 6;

		public const ushort MineCount = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "LightedBlocks", "ExtinguishedBlocks", "MineBlocks", "TriggeredMineBlocks", "RewardGrade", "EdgeBlocks", "AreaId", "MineCount" };
	}

	[SerializableGameDataField]
	public Dictionary<short, int> LightedBlocks;

	[SerializableGameDataField]
	public List<short> ExtinguishedBlocks;

	[SerializableGameDataField]
	public List<short> MineBlocks;

	[SerializableGameDataField]
	public List<short> TriggeredMineBlocks;

	[SerializableGameDataField]
	public sbyte RewardGrade;

	[SerializableGameDataField]
	public Dictionary<short, sbyte> EdgeBlocks;

	[SerializableGameDataField]
	public short AreaId;

	[SerializableGameDataField]
	public int MineCount;

	public FulongInFlameArea()
	{
		LightedBlocks = new Dictionary<short, int>();
		MineBlocks = new List<short>();
		EdgeBlocks = new Dictionary<short, sbyte>();
		AreaId = -1;
		ExtinguishedBlocks = new List<short>();
		TriggeredMineBlocks = new List<short>();
		RewardGrade = -1;
		MineCount = -1;
	}

	public FulongInFlameArea(Dictionary<short, int> lightedBlocks, List<short> mineBlocks, Dictionary<short, sbyte> edgeBlocks, bool isBig, short areaId, int mineCount)
	{
		LightedBlocks = lightedBlocks;
		MineBlocks = mineBlocks;
		EdgeBlocks = edgeBlocks;
		AreaId = areaId;
		ExtinguishedBlocks = new List<short>();
		TriggeredMineBlocks = new List<short>();
		RewardGrade = (sbyte)(isBig ? 6 : 3);
		MineCount = mineCount;
	}

	public static bool IsAdjacent(MapBlockData a, MapBlockData b)
	{
		return a.GetBlockPos().GetManhattanDistance(b.GetBlockPos()) == 1;
	}

	public bool IsFullyExtinguished()
	{
		return ExtinguishedBlocks.Count + MineBlocks.Count >= LightedBlocks.Count;
	}

	public bool IsLocationInFlame(Location location)
	{
		if (location.AreaId == AreaId)
		{
			return LightedBlocks.ContainsKey(location.BlockId);
		}
		return false;
	}

	public bool IsLocationInActiveFlame(Location location)
	{
		if (IsLocationInFlame(location) && !ExtinguishedBlocks.Contains(location.BlockId))
		{
			return !TriggeredMineBlocks.Contains(location.BlockId);
		}
		return false;
	}

	public FulongInFlameArea(FulongInFlameArea other)
	{
		LightedBlocks = ((other.LightedBlocks == null) ? null : new Dictionary<short, int>(other.LightedBlocks));
		ExtinguishedBlocks = ((other.ExtinguishedBlocks == null) ? null : new List<short>(other.ExtinguishedBlocks));
		MineBlocks = ((other.MineBlocks == null) ? null : new List<short>(other.MineBlocks));
		TriggeredMineBlocks = ((other.TriggeredMineBlocks == null) ? null : new List<short>(other.TriggeredMineBlocks));
		RewardGrade = other.RewardGrade;
		EdgeBlocks = ((other.EdgeBlocks == null) ? null : new Dictionary<short, sbyte>(other.EdgeBlocks));
		AreaId = other.AreaId;
		MineCount = other.MineCount;
	}

	public void Assign(FulongInFlameArea other)
	{
		LightedBlocks = ((other.LightedBlocks == null) ? null : new Dictionary<short, int>(other.LightedBlocks));
		ExtinguishedBlocks = ((other.ExtinguishedBlocks == null) ? null : new List<short>(other.ExtinguishedBlocks));
		MineBlocks = ((other.MineBlocks == null) ? null : new List<short>(other.MineBlocks));
		TriggeredMineBlocks = ((other.TriggeredMineBlocks == null) ? null : new List<short>(other.TriggeredMineBlocks));
		RewardGrade = other.RewardGrade;
		EdgeBlocks = ((other.EdgeBlocks == null) ? null : new Dictionary<short, sbyte>(other.EdgeBlocks));
		AreaId = other.AreaId;
		MineCount = other.MineCount;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(LightedBlocks);
		totalSize = ((ExtinguishedBlocks == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ExtinguishedBlocks.Count)));
		totalSize = ((MineBlocks == null) ? (totalSize + 2) : (totalSize + (2 + 2 * MineBlocks.Count)));
		totalSize = ((TriggeredMineBlocks == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TriggeredMineBlocks.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(EdgeBlocks);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 8;
		pCurrData += 2;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref LightedBlocks);
		if (ExtinguishedBlocks != null)
		{
			int elementsCount = ExtinguishedBlocks.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = ExtinguishedBlocks[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (MineBlocks != null)
		{
			int elementsCount2 = MineBlocks.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((short*)pCurrData)[j] = MineBlocks[j];
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TriggeredMineBlocks != null)
		{
			int elementsCount3 = TriggeredMineBlocks.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = TriggeredMineBlocks[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)RewardGrade;
		pCurrData++;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref EdgeBlocks);
		*(short*)pCurrData = AreaId;
		pCurrData += 2;
		*(int*)pCurrData = MineCount;
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
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref LightedBlocks);
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (ExtinguishedBlocks == null)
				{
					ExtinguishedBlocks = new List<short>(elementsCount);
				}
				else
				{
					ExtinguishedBlocks.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ExtinguishedBlocks.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				ExtinguishedBlocks?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (MineBlocks == null)
				{
					MineBlocks = new List<short>(elementsCount2);
				}
				else
				{
					MineBlocks.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					MineBlocks.Add(((short*)pCurrData)[j]);
				}
				pCurrData += 2 * elementsCount2;
			}
			else
			{
				MineBlocks?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (TriggeredMineBlocks == null)
				{
					TriggeredMineBlocks = new List<short>(elementsCount3);
				}
				else
				{
					TriggeredMineBlocks.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					TriggeredMineBlocks.Add(((short*)pCurrData)[k]);
				}
				pCurrData += 2 * elementsCount3;
			}
			else
			{
				TriggeredMineBlocks?.Clear();
			}
		}
		if (fieldCount > 4)
		{
			RewardGrade = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 5)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref EdgeBlocks);
		}
		if (fieldCount > 6)
		{
			AreaId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 7)
		{
			MineCount = *(int*)pCurrData;
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
