using System;
using GameData.Serializer;
using Redzen.Random;

namespace GameData.Domains.Character;

public struct PreexistenceCharIds : ISerializableGameData
{
	public const int MaxCount = 9;

	public static readonly int[] Positions = new int[9] { 7, 2, 3, 0, 4, 8, 5, 6, 1 };

	public unsafe fixed int CharIds[9];

	public int Count;

	public unsafe int Last
	{
		get
		{
			if (Count <= 0)
			{
				return -1;
			}
			return CharIds[Count - 1];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 40;
	}

	public unsafe int Serialize(byte* pData)
	{
		for (int i = 0; i < 9; i++)
		{
			((int*)pData)[i] = CharIds[i];
		}
		pData += 36;
		*(int*)pData = Count;
		pData += 4;
		return 40;
	}

	public unsafe int Deserialize(byte* pData)
	{
		for (int i = 0; i < 9; i++)
		{
			CharIds[i] = ((int*)pData)[i];
		}
		pData += 36;
		Count = *(int*)pData;
		pData += 4;
		return 40;
	}

	public unsafe void Add(IRandomSource random, int charId)
	{
		if (Count < 9)
		{
			CharIds[Count++] = charId;
			return;
		}
		throw new Exception("Exceeded the max count of preexistence characters");
	}

	public void Reset()
	{
		Count = 0;
	}

	public unsafe int IndexOf(int charId)
	{
		for (int i = 0; i < Count; i++)
		{
			if (CharIds[i] == charId)
			{
				return i;
			}
		}
		return -1;
	}

	public int GetIndexByPos(int pos)
	{
		for (int i = 0; i < 9; i++)
		{
			if (Positions[i] == pos)
			{
				return i;
			}
		}
		return -1;
	}
}
