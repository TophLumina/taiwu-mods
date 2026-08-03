using System.Collections.Generic;
using GameData.Adventure;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇地格缓存桶
/// </summary>
public class AdventureBlockBucket
{
	private readonly int _size;

	private readonly int _bucketSize;

	/// <summary>
	/// 此处 BoolArray16 对应 <see cref="F:GameData.Adventure.AdventureBlockIndex.SubBlockCount" />
	/// </summary>
	private BoolArray16[][] _buckets;

	private readonly AdventureBlockData[][][] _blockCores;

	public AdventureBlockBucket(int size, IReadOnlyList<AdventureBlockData> blockCores)
	{
		_size = size;
		_bucketSize = size * 2 + 1;
		_blockCores = new AdventureBlockData[_bucketSize][][];
		foreach (AdventureBlockData blockCore in blockCores)
		{
			AdventureBlockIndex index = blockCore.Index;
			AdventureBlockData[][][] blockCores2 = _blockCores;
			int num = index.X + _size;
			AdventureBlockData[][] array = blockCores2[num] ?? (blockCores2[num] = new AdventureBlockData[_bucketSize][]);
			num = index.Y + _size;
			(array[num] ?? (array[num] = new AdventureBlockData[9]))[index.I] = blockCore;
		}
	}

	public AdventureBlockData GetBlockCore(AdventureBlockIndex index)
	{
		return _blockCores.GetOrDefault(index.X + _size)?.GetOrDefault(index.Y + _size)?.GetOrDefault(index.I);
	}

	public bool GetPassable(AdventureBlockIndex index)
	{
		BoolArray16? iBucket = _buckets?.GetOrDefault(index.X + _size)?.GetOrDefault(index.Y + _size);
		if (iBucket.HasValue)
		{
			return iBucket.Value[index.I];
		}
		return false;
	}

	public void SetPassable(AdventureBlockIndex index, bool value)
	{
		if (GetPassable(index) != value)
		{
			if (_buckets == null)
			{
				_buckets = new BoolArray16[_bucketSize][];
			}
			BoolArray16[][] buckets = _buckets;
			int num = index.X + _size;
			(buckets[num] ?? (buckets[num] = new BoolArray16[_bucketSize]))[index.Y + _size][index.I] = value;
		}
	}
}
