using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

public class BuildingAreaData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte Width;

	[SerializableGameDataField]
	public sbyte LandFormType;

	public BuildingAreaData(sbyte width, sbyte landFormType)
	{
		Width = width;
		LandFormType = landFormType;
	}

	public BuildingAreaData()
	{
	}

	public BuildingAreaData(BuildingAreaData other)
	{
		Width = other.Width;
		LandFormType = other.LandFormType;
	}

	public void Assign(BuildingAreaData other)
	{
		Width = other.Width;
		LandFormType = other.LandFormType;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)Width;
		byte* num = pData + 1;
		*num = (byte)LandFormType;
		int totalSize = (int)(num + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		Width = (sbyte)(*pCurrData);
		pCurrData++;
		LandFormType = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public short GetCenterBlockIndex()
	{
		int coord = Width / 2;
		if (Width % 2 == 0)
		{
			coord--;
		}
		return (short)(coord * Width + coord);
	}

	public (int x, int y) GetBlockPos(short index)
	{
		return (x: index % Width, y: index / Width);
	}

	public void GetNeighborBlocks(short blockIndex, sbyte blockWidth, List<short> neighborList, List<int> neighborDistanceList = null, int range = 1)
	{
		int blockX = blockIndex % Width;
		int blockY = blockIndex / Width;
		neighborList.Clear();
		neighborDistanceList?.Clear();
		for (int x = Math.Max(blockX - range, 0); x < Math.Min(blockX + blockWidth + range, Width); x++)
		{
			for (int y = Math.Max(blockY - range, 0); y < Math.Min(blockY + blockWidth + range, Width); y++)
			{
				int distance = MathUtils.GetManhattanDistance(blockX, blockY, x, y, blockWidth);
				if (distance <= range && distance > 0)
				{
					short neighborIndex = (short)(y * Width + x);
					if (neighborIndex != blockIndex && !neighborList.Contains(neighborIndex))
					{
						neighborList.Add(neighborIndex);
						neighborDistanceList?.Add(distance);
					}
				}
			}
		}
	}
}
