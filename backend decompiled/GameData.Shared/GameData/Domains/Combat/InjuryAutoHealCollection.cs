using System;
using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Serializer;

namespace GameData.Domains.Combat;

public class InjuryAutoHealCollection : ISerializableGameData
{
	public readonly List<short>[] OuterBodyPartList;

	public readonly List<short>[] InnerBodyPartList;

	public InjuryAutoHealCollection()
	{
		OuterBodyPartList = new List<short>[7];
		InnerBodyPartList = new List<short>[7];
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			OuterBodyPartList[bodyPart] = new List<short>();
			InnerBodyPartList[bodyPart] = new List<short>();
		}
	}

	public void SyncInjuries(ref Injuries injuries)
	{
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			(sbyte outer, sbyte inner) tuple = injuries.Get(bodyPart);
			sbyte outer = tuple.outer;
			sbyte inner = tuple.inner;
			List<short> outerProgressList = OuterBodyPartList[bodyPart];
			List<short> innerProgressList = InnerBodyPartList[bodyPart];
			outer = Math.Max(outer, 0);
			inner = Math.Max(inner, 0);
			while (outer < outerProgressList.Count)
			{
				outerProgressList.RemoveAt(0);
			}
			while (outer > outerProgressList.Count)
			{
				outerProgressList.Add(0);
			}
			while (inner < innerProgressList.Count)
			{
				innerProgressList.RemoveAt(0);
			}
			while (inner > innerProgressList.Count)
			{
				innerProgressList.Add(0);
			}
		}
	}

	public bool UpdateProgress(Dictionary<sbyte, OuterAndInnerInts> bodyPart2Deltas, int outerSpeed, int innerSpeed)
	{
		bodyPart2Deltas.Clear();
		if (outerSpeed <= 0 && innerSpeed <= 0)
		{
			return false;
		}
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			int outerDelta = UpdateProgress(isInner: false, bodyPart, outerSpeed);
			int innerDelta = UpdateProgress(isInner: true, bodyPart, innerSpeed);
			bodyPart2Deltas[bodyPart] = new OuterAndInnerInts(outerDelta, innerDelta);
		}
		return true;
	}

	private int UpdateProgress(bool isInner, sbyte bodyPart, int speed)
	{
		if (speed <= 0)
		{
			return 0;
		}
		int delta = 0;
		List<short> progress = (isInner ? InnerBodyPartList : OuterBodyPartList)[bodyPart];
		for (int i = progress.Count - 1; i >= 0; i--)
		{
			progress[i] = (short)Math.Clamp(progress[i] + speed, 0, 900);
			if (progress[i] >= 900)
			{
				delta++;
				progress.RemoveAt(i);
			}
		}
		return delta;
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
			totalSize += 1 + 2 * OuterBodyPartList[bodyPart].Count;
			totalSize += 1 + 2 * InnerBodyPartList[bodyPart].Count;
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
			List<short> dataList = OuterBodyPartList[bodyPart];
			*pCurrData = (byte)(sbyte)dataList.Count;
			pCurrData++;
			for (int i = 0; i < dataList.Count; i++)
			{
				*(short*)pCurrData = dataList[i];
				pCurrData += 2;
			}
			dataList = InnerBodyPartList[bodyPart];
			*pCurrData = (byte)(sbyte)dataList.Count;
			pCurrData++;
			for (int j = 0; j < dataList.Count; j++)
			{
				*(short*)pCurrData = dataList[j];
				pCurrData += 2;
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
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			List<short> dataList = OuterBodyPartList[bodyPart];
			sbyte count = (sbyte)(*pCurrData);
			pCurrData++;
			dataList.Clear();
			for (int i = 0; i < count; i++)
			{
				short dataValue = *(short*)pCurrData;
				pCurrData += 2;
				dataList.Add(dataValue);
			}
			dataList = InnerBodyPartList[bodyPart];
			count = (sbyte)(*pCurrData);
			pCurrData++;
			dataList.Clear();
			for (int j = 0; j < count; j++)
			{
				short dataValue2 = *(short*)pCurrData;
				pCurrData += 2;
				dataList.Add(dataValue2);
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
