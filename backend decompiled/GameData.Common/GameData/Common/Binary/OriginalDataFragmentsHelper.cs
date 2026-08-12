using System.Collections.Generic;

namespace GameData.Common.Binary;

public static class OriginalDataFragmentsHelper
{
	public static void ApplyInsertRecord(List<OriginalDataFragment> fragments, int offset, int size)
	{
		int index = FindFirstSegment(fragments, offset);
		ChangeOffsetOfFragments(fragments, index, size);
	}

	public static void ApplyWriteRecord(List<OriginalDataFragment> fragments, int offset, int size)
	{
		int index = FindFirstSegment(fragments, offset);
		RemoveFragments(fragments, index, offset + size);
	}

	public static void ApplyDeleteRecord(List<OriginalDataFragment> fragments, int offset, int size)
	{
		int index = FindFirstSegment(fragments, offset);
		RemoveFragments(fragments, index, offset + size);
		ChangeOffsetOfFragments(fragments, index, -size);
	}

	private static int FindFirstSegment(List<OriginalDataFragment> fragments, int offset)
	{
		int index = fragments.BinarySearch(new OriginalDataFragment(offset, -1, -1));
		if (index >= 0)
		{
			return index;
		}
		index = ~index;
		if (index == 0)
		{
			return index;
		}
		OriginalDataFragment fragment = fragments[index - 1];
		if (fragment.CurrOffset + fragment.Size <= offset)
		{
			return index;
		}
		Split(fragments, index - 1, offset);
		return index;
	}

	private static void Split(List<OriginalDataFragment> fragments, int index, int splitOffset)
	{
		OriginalDataFragment firstFragment = fragments[index];
		int firstSize = (firstFragment.Size = splitOffset - firstFragment.CurrOffset);
		fragments[index] = firstFragment;
		int secondSize = firstFragment.Size - firstSize;
		int secondOriOffset = firstFragment.OriOffset + firstSize;
		OriginalDataFragment secondFragment = new OriginalDataFragment(splitOffset, secondSize, secondOriOffset);
		fragments.Insert(index + 1, secondFragment);
	}

	private static void ChangeOffsetOfFragments(List<OriginalDataFragment> fragments, int index, int delta)
	{
		int i = index;
		for (int count = fragments.Count; i < count; i++)
		{
			OriginalDataFragment fragment = fragments[i];
			fragment.CurrOffset += delta;
			fragments[i] = fragment;
		}
	}

	private static void RemoveFragments(List<OriginalDataFragment> fragments, int index, int endOffset)
	{
		int endIndex = -1;
		int i = index;
		for (int count = fragments.Count; i < count; i++)
		{
			OriginalDataFragment fragment = fragments[i];
			if (fragment.CurrOffset >= endOffset)
			{
				break;
			}
			if (fragment.CurrOffset + fragment.Size <= endOffset)
			{
				endIndex = i;
				continue;
			}
			int firstSize = endOffset - fragment.CurrOffset;
			fragment.CurrOffset = endOffset;
			fragment.Size -= firstSize;
			fragment.OriOffset += firstSize;
			fragments[i] = fragment;
			break;
		}
		if (endIndex >= 0)
		{
			fragments.RemoveRange(index, endIndex - index + 1);
		}
	}
}
