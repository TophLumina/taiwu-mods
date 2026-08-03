namespace GameData.Utilities;

public static class SelectionUtils
{
	public unsafe static int SelectTopK(int* pList, int count, int topK)
	{
		if (topK == 1)
		{
			return SelectTop1(pList, count);
		}
		int left = 0;
		int right = count - 1;
		int targetIndex = count - topK;
		while (true)
		{
			if (left == right)
			{
				return left;
			}
			int pivotIndex = (left + right) / 2;
			pivotIndex = Partition(pList, left, right, pivotIndex);
			if (pivotIndex == targetIndex)
			{
				break;
			}
			if (pivotIndex < targetIndex)
			{
				left = pivotIndex + 1;
			}
			else
			{
				right = pivotIndex - 1;
			}
		}
		return targetIndex;
	}

	public unsafe static int SelectTop1(int* pList, int count)
	{
		int maxValue = int.MinValue;
		int maxIdx = 0;
		for (int i = 0; i < count; i++)
		{
			int value = pList[i];
			if (value > maxValue)
			{
				maxValue = value;
				maxIdx = i;
			}
		}
		return maxIdx;
	}

	private unsafe static int GetMedianOfThree(int* pList, int leftIdx, int rightIdx)
	{
		int midIdx = (leftIdx + rightIdx) / 2;
		int leftVal = pList[leftIdx];
		int midVal = pList[midIdx];
		int rightVal = pList[rightIdx];
		if (midVal > leftVal != midVal > rightVal)
		{
			return midIdx;
		}
		if (rightVal > leftVal != rightVal > midVal)
		{
			return rightIdx;
		}
		return leftIdx;
	}

	private unsafe static int Partition(int* pList, int left, int right, int pivotIndex)
	{
		int pivotValue = pList[pivotIndex];
		pList[pivotIndex] = pList[right];
		pList[right] = pivotValue;
		int storeIndex = left;
		for (int i = left; i < right; i++)
		{
			int currValue = pList[i];
			if (currValue < pivotValue)
			{
				pList[i] = pList[storeIndex];
				pList[storeIndex] = currValue;
				storeIndex++;
			}
		}
		pList[right] = pList[storeIndex];
		pList[storeIndex] = pivotValue;
		return storeIndex;
	}
}
