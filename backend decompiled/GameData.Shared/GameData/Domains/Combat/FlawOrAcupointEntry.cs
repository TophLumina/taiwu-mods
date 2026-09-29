using System;
using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true, NotForDisplayModule = true)]
public struct FlawOrAcupointEntry : ISerializableGameData, IComparable<FlawOrAcupointEntry>
{
	[SerializableGameDataField]
	public sbyte Level;

	[SerializableGameDataField]
	public int TotalFrame;

	[SerializableGameDataField]
	public int LeftFrame;

	public static implicit operator FlawOrAcupointEntry((sbyte level, int totalFrame, int leftFrame) entry)
	{
		FlawOrAcupointEntry result = default(FlawOrAcupointEntry);
		(result.Level, result.TotalFrame, result.LeftFrame) = entry;
		return result;
	}

	public void Deconstruct(out sbyte level, out int totalFrame, out int leftFrame)
	{
		level = Level;
		totalFrame = TotalFrame;
		leftFrame = LeftFrame;
	}

	public int CompareTo(FlawOrAcupointEntry other)
	{
		int levelComparison = Level.CompareTo(other.Level);
		if (levelComparison != 0)
		{
			return levelComparison;
		}
		int leftFrameComparison = LeftFrame.CompareTo(other.LeftFrame);
		if (leftFrameComparison != 0)
		{
			return leftFrameComparison;
		}
		return TotalFrame.CompareTo(other.TotalFrame);
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)Level;
		byte* num = pData + 1;
		*(int*)num = TotalFrame;
		byte* num2 = num + 4;
		*(int*)num2 = LeftFrame;
		int totalSize = (int)(num2 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		Level = (sbyte)(*pCurrData);
		pCurrData++;
		TotalFrame = *(int*)pCurrData;
		pCurrData += 4;
		LeftFrame = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
