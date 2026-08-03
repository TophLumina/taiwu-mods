using System;
using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 破绽/点穴条目
/// </summary>
[SerializableGameData(NotForArchive = true, NotForDisplayModule = true)]
public struct FlawOrAcupointEntry : ISerializableGameData, IComparable<FlawOrAcupointEntry>
{
	/// <summary>
	/// 等级
	/// </summary>
	[SerializableGameDataField]
	public sbyte Level;

	/// <summary>
	/// 总帧数
	/// </summary>
	[SerializableGameDataField]
	public int TotalFrame;

	/// <summary>
	/// 剩余帧数
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
