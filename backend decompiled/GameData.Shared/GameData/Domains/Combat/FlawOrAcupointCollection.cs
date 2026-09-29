using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public class FlawOrAcupointCollection : ISerializableGameData
{
	public struct ReduceKeepTimeResult
	{
		public bool DataChanged;

		public bool CountChanged;

		public List<(sbyte part, sbyte level)> RemovedList;
	}

	public delegate int ReduceFrameDelegate(int totalFrame);

	public readonly SortedDictionary<sbyte, List<FlawOrAcupointEntry>> BodyPartDict;

	private readonly List<(sbyte part, sbyte level)> _removedList = new List<(sbyte, sbyte)>();

	public FlawOrAcupointCollection()
	{
		BodyPartDict = new SortedDictionary<sbyte, List<FlawOrAcupointEntry>>();
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			BodyPartDict.Add(bodyPart, new List<FlawOrAcupointEntry>());
		}
	}

	public int GetTotalCount()
	{
		int totalCount = 0;
		foreach (List<FlawOrAcupointEntry> lst in BodyPartDict.Values)
		{
			totalCount += lst.Count;
		}
		return totalCount;
	}

	public ReduceKeepTimeResult ReduceKeepTime(int recoverValue, byte[] countArray)
	{
		return ReduceKeepTimePercentInternal((int _) => recoverValue, countArray);
	}

	public ReduceKeepTimeResult ReduceKeepTimePercent(CValuePercent reducePercent, byte[] countArray)
	{
		return ReduceKeepTimePercentInternal((int totalFrame) => totalFrame * reducePercent, countArray);
	}

	private ReduceKeepTimeResult ReduceKeepTimePercentInternal(ReduceFrameDelegate reduceFrameDelegate, IList<byte> countArray)
	{
		bool dataChanged = false;
		bool countChanged = false;
		_removedList.Clear();
		foreach (KeyValuePair<sbyte, List<FlawOrAcupointEntry>> item in BodyPartDict)
		{
			item.Deconstruct(out var key, out var value);
			sbyte bodyPart = key;
			List<FlawOrAcupointEntry> dataList = value;
			for (int i = dataList.Count - 1; i >= 0; i--)
			{
				FlawOrAcupointEntry entry = dataList[i];
				entry.LeftFrame -= reduceFrameDelegate(entry.TotalFrame);
				entry.LeftFrame = Math.Min(entry.LeftFrame, entry.TotalFrame);
				if (entry.LeftFrame <= 0)
				{
					_removedList.Add((bodyPart, entry.Level));
					dataList.RemoveAt(i);
					countArray[bodyPart]--;
					countChanged = true;
				}
				else
				{
					dataList[i] = entry;
				}
				dataChanged = true;
			}
		}
		return new ReduceKeepTimeResult
		{
			DataChanged = dataChanged,
			CountChanged = countChanged,
			RemovedList = _removedList
		};
	}

	public bool RandomRecoverKeepTimeToTotal(IRandomSource random)
	{
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		pool.Clear();
		for (sbyte i = 0; i < 7; i++)
		{
			if (BodyPartDict.TryGetValue(i, out var entries) && entries.Count > 0)
			{
				pool.Add(i);
			}
		}
		sbyte bodyPart = (sbyte)((pool.Count > 0) ? pool.GetRandom(random) : (-1));
		ObjectPool<List<sbyte>>.Instance.Return(pool);
		if (bodyPart < 0)
		{
			return false;
		}
		List<FlawOrAcupointEntry> target = BodyPartDict[bodyPart];
		int index = random.Next(target.Count);
		FlawOrAcupointEntry entry = target[index];
		entry.LeftFrame = entry.TotalFrame;
		target[index] = entry;
		return true;
	}

	public bool OfflineRecoverKeepTimePercent(int recoverPercent)
	{
		if (recoverPercent <= 0)
		{
			return false;
		}
		bool anyChanged = false;
		foreach (List<FlawOrAcupointEntry> dataList in BodyPartDict.Values)
		{
			for (int i = 0; i < dataList.Count; i++)
			{
				anyChanged = true;
				FlawOrAcupointEntry entry = dataList[i];
				entry.LeftFrame = Math.Clamp(entry.LeftFrame + entry.TotalFrame * recoverPercent / 100, 0, entry.TotalFrame);
				dataList[i] = entry;
			}
		}
		return anyChanged;
	}

	public int CalcAcupointParam(sbyte bodyPart)
	{
		if (!BodyPartDict.TryGetValue(bodyPart, out var entries) || entries.Count == 0)
		{
			return 0;
		}
		int maxPercent = 0;
		foreach (FlawOrAcupointEntry entry in entries)
		{
			int percent = entry.LeftFrame * 100 / entry.TotalFrame;
			maxPercent = Math.Max(maxPercent, percent);
		}
		if (maxPercent == 0)
		{
			return 0;
		}
		BodyPartItem config = BodyPart.Instance[bodyPart];
		Tester.Assert(config.AcupointParam.Length == config.AcupointTime.Length);
		for (int i = 0; i < config.AcupointTime.Length; i++)
		{
			if (config.AcupointTime[i] > maxPercent)
			{
				if (i <= 0)
				{
					return 0;
				}
				return config.AcupointParam[i - 1];
			}
		}
		return config.AcupointParam[^1];
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			totalSize += 1 + 9 * BodyPartDict[bodyPart].Count;
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
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			List<FlawOrAcupointEntry> dataList = BodyPartDict[bodyPart];
			*pCurrData = (byte)(sbyte)dataList.Count;
			pCurrData++;
			for (int i = 0; i < dataList.Count; i++)
			{
				FlawOrAcupointEntry entry = dataList[i];
				*pCurrData = (byte)entry.Level;
				pCurrData++;
				*(int*)pCurrData = entry.TotalFrame;
				pCurrData += 4;
				*(int*)pCurrData = entry.LeftFrame;
				pCurrData += 4;
			}
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
		FlawOrAcupointEntry entry = default(FlawOrAcupointEntry);
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			List<FlawOrAcupointEntry> dataList = BodyPartDict[bodyPart];
			sbyte count = (sbyte)(*pCurrData);
			pCurrData++;
			dataList.Clear();
			for (int i = 0; i < count; i++)
			{
				entry.Level = (sbyte)(*pCurrData);
				pCurrData++;
				entry.TotalFrame = *(int*)pCurrData;
				pCurrData += 4;
				entry.LeftFrame = *(int*)pCurrData;
				pCurrData += 4;
				dataList.Add(entry);
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
