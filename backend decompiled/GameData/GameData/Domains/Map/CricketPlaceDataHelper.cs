using System;
using System.Collections.Generic;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Map;

public static class CricketPlaceDataHelper
{
	public static bool BlockAllowCricket(MapBlockData block)
	{
		return block.TemplateId != 126 && block.TemplateId != 125 && !block.IsCityTown() && !DomainManager.Map.IsLocationInFulongFlameArea(block.GetLocation());
	}

	public static void Init(this CricketPlaceData data, short areaId, IRandomSource random, int minGroupCount = 3, int maxGroupCount = 5, int minDistance = -1, int maxDistance = -1)
	{
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
		int groupCount = random.Next(minGroupCount, maxGroupCount + 1);
		data.CricketBlocks = new short[3 * groupCount];
		data.CricketTriggered = new bool[3 * groupCount];
		data.RealCircketIdx = new byte[groupCount];
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		ByteCoordinate taiwuPos = (taiwuLocation.IsValid() ? DomainManager.Map.GetBlock(taiwuLocation).GetBlockPos() : new ByteCoordinate(0, 0));
		List<MapBlockData> availableBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		List<MapBlockData> blockRandomPool = ObjectPool<List<MapBlockData>>.Instance.Get();
		List<MapBlockData> neighborList = ObjectPool<List<MapBlockData>>.Instance.Get();
		availableBlocks.Clear();
		for (int i = 0; i < blocks.Length; i++)
		{
			MapBlockData block = blocks[i];
			if (BlockAllowCricket(block) && (areaId != taiwuLocation.AreaId || block.BlockId != taiwuLocation.BlockId) && (minDistance < 0 || (taiwuLocation.IsValid() && block.GetManhattanDistanceToPos(taiwuPos.X, taiwuPos.Y) >= minDistance)) && (maxDistance < 0 || (taiwuLocation.IsValid() && block.GetManhattanDistanceToPos(taiwuPos.X, taiwuPos.Y) <= maxDistance)))
			{
				availableBlocks.Add(block);
			}
		}
		int generatedGroupCount = 0;
		int rerandomCounter = 0;
		while (generatedGroupCount < minGroupCount && rerandomCounter < 50)
		{
			blockRandomPool.Clear();
			blockRandomPool.AddRange(availableBlocks);
			CollectionUtils.Shuffle(random, blockRandomPool);
			generatedGroupCount = 0;
			for (int j = 0; j < groupCount; j++)
			{
				for (int k = 0; k < blockRandomPool.Count; k++)
				{
					MapBlockData center = blockRandomPool[k];
					DomainManager.Map.GetRealNeighborBlocks(center.AreaId, center.BlockId, neighborList);
					neighborList.RemoveAll((MapBlockData item) => !blockRandomPool.Contains(item));
					if (neighborList.Count >= 2)
					{
						CollectionUtils.Shuffle(random, neighborList);
						data.CricketBlocks[3 * j] = center.BlockId;
						data.CricketBlocks[3 * j + 1] = neighborList[0].BlockId;
						data.CricketBlocks[3 * j + 2] = neighborList[1].BlockId;
						data.RealCircketIdx[j] = (byte)random.Next(3);
						blockRandomPool.RemoveAll(delegate(MapBlockData mapBlockData)
						{
							ByteCoordinate byteCoordinate = mapBlockData.GetBlockPos() - center.GetBlockPos();
							return byteCoordinate.X <= 3 && byteCoordinate.Y <= 3;
						});
						generatedGroupCount++;
						break;
					}
				}
			}
			rerandomCounter++;
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(availableBlocks);
		ObjectPool<List<MapBlockData>>.Instance.Return(blockRandomPool);
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborList);
		data.FixInvalidData(areaId);
	}

	public static void ChangePlace(this CricketPlaceData data, short areaId, int index)
	{
		int minDistance = 1;
		int maxDistance = 3;
		MapBlockData[] blocks = DomainManager.Map.GetAreaBlocks(areaId).ToArray();
		int groupIndex = index / 3;
		MapBlockData centerBlock = blocks[data.CricketBlocks[groupIndex * 3]];
		ByteCoordinate centerBlockPos = centerBlock.GetBlockPos();
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		List<short> remainIndexList = ObjectPool<List<short>>.Instance.Get();
		List<short> otherGroupBlocks = ObjectPool<List<short>>.Instance.Get();
		List<MapBlockData> blockList1 = ObjectPool<List<MapBlockData>>.Instance.Get();
		List<MapBlockData> blockList2 = ObjectPool<List<MapBlockData>>.Instance.Get();
		remainIndexList.Clear();
		for (int i = 0; i < 3; i++)
		{
			if (!data.CricketTriggered[groupIndex * 3 + i])
			{
				remainIndexList.Add((short)(groupIndex * 3 + i));
			}
		}
		otherGroupBlocks.Clear();
		for (int j = 0; j < data.RealCircketIdx.Length; j++)
		{
			if (j != groupIndex && !data.CricketTriggered[j * 3 + data.RealCircketIdx[j]])
			{
				otherGroupBlocks.Add(data.CricketBlocks[j * 3]);
			}
		}
		DomainManager.Map.GetRealNeighborBlocks(areaId, centerBlock.BlockId, blockList1, maxDistance);
		DomainManager.Map.GetRealNeighborBlocks(areaId, centerBlock.BlockId, blockList2, minDistance);
		blockList1.RemoveAll((MapBlockData mapBlockData) => blockList2.Contains(mapBlockData) || mapBlockData.IsCityTown() || mapBlockData.TemplateId == 126 || mapBlockData.TemplateId == 125 || Array.IndexOf(data.CricketBlocks, mapBlockData.BlockId) >= 0 || (areaId == taiwuLocation.AreaId && mapBlockData.BlockId == taiwuLocation.BlockId));
		blockList1.RemoveAll((MapBlockData mapBlockData) => otherGroupBlocks.Exists(delegate(short blockId)
		{
			ByteCoordinate byteCoordinate = blocks[blockId].GetBlockPos() - mapBlockData.GetBlockPos();
			return byteCoordinate.X <= minDistance && byteCoordinate.Y <= minDistance;
		}));
		blockList1.Sort((MapBlockData blockA, MapBlockData blockB) => blockA.GetBlockPos().GetManhattanDistance(centerBlockPos).CompareTo(blockB.GetBlockPos().GetManhattanDistance(centerBlockPos)));
		foreach (MapBlockData block in blockList1)
		{
			DomainManager.Map.GetRealNeighborBlocks(areaId, block.BlockId, blockList2);
			blockList2.RemoveAll((MapBlockData mapBlockData) => mapBlockData.IsCityTown() || mapBlockData.TemplateId == 126 || Array.IndexOf(data.CricketBlocks, mapBlockData.BlockId) >= 0 || (areaId == taiwuLocation.AreaId && mapBlockData.BlockId == taiwuLocation.BlockId));
			blockList2.Insert(0, block);
			if (blockList2.Count < remainIndexList.Count)
			{
				continue;
			}
			for (int i2 = 0; i2 < remainIndexList.Count; i2++)
			{
				data.CricketBlocks[remainIndexList[i2]] = blockList2[i2].BlockId;
			}
			break;
		}
		ObjectPool<List<short>>.Instance.Return(remainIndexList);
		ObjectPool<List<short>>.Instance.Return(otherGroupBlocks);
		ObjectPool<List<MapBlockData>>.Instance.Return(blockList1);
		ObjectPool<List<MapBlockData>>.Instance.Return(blockList2);
	}

	internal static void FixInvalidData(this CricketPlaceData data, short areaId)
	{
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
		int i = 0;
		for (int len = data.CricketBlocks.Length; i < len; i++)
		{
			short blockId = data.CricketBlocks[i];
			if (blockId >= 0 && blockId < blocks.Length)
			{
				MapBlockData block = blocks[blockId];
				if (block.TemplateId == 126)
				{
					data.CricketTriggered[i] = true;
				}
				if (block.IsCityTown())
				{
					data.CricketTriggered[i] = true;
				}
			}
			else
			{
				data.CricketTriggered[i] = true;
			}
		}
	}
}
