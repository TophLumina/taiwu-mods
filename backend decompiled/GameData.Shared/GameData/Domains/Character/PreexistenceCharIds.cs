using System;
using GameData.Serializer;
using Redzen.Random;

namespace GameData.Domains.Character;

/// <summary>
/// 前世角色 ID 集合
/// </summary>
public struct PreexistenceCharIds : ISerializableGameData
{
	/// <summary>
	/// 前世角色的最大数量
	/// </summary>
	public const int MaxCount = 9;

	/// <summary>
	/// 位置，固定的
	/// </summary>
	public static readonly int[] Positions = new int[9] { 7, 2, 3, 0, 4, 8, 5, 6, 1 };

	/// <summary>
	/// 前世角色 ID 数组. 数组索引越小, 前世在时间线上离现世越远.
	/// *** 定长数组中的数据在创建对象时并未初始化. 不过由于记录了元素个数, 所以并不用初始化. ***
	/// </summary>
	public unsafe fixed int CharIds[9];

	/// <summary>
	/// 前世的个数
	/// </summary>
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

	/// <summary>
	/// 添加前世
	/// </summary>
	/// <param name="random"></param>
	/// <param name="charId"></param>
	/// <exception cref="T:System.Exception"></exception>
	public unsafe void Add(IRandomSource random, int charId)
	{
		if (Count < 9)
		{
			CharIds[Count++] = charId;
			return;
		}
		throw new Exception("Exceeded the max count of preexistence characters");
	}

	/// <summary>
	/// 清空前世数据
	/// </summary>
	public void Reset()
	{
		Count = 0;
	}

	/// <summary>
	/// 查找指定角色是第几个前世
	/// </summary>
	/// <param name="charId"></param>
	/// <returns>0 表示第一个前世, -1 表示不在此前世集合里</returns>
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

	/// <summary>
	/// 查找指定位置是第几个前世
	/// </summary>
	/// <param name="pos"></param>
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
