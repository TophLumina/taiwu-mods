using System;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 玄灰显示数据
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true)]
public struct DarkAshCounter : ISerializableGameData
{
	/// <summary>
	/// 倒计时 - 基础特性
	/// </summary>
	[SerializableGameDataField]
	public int Tips1;

	/// <summary>
	/// 倒计时 - 精纯特性
	/// </summary>
	[SerializableGameDataField]
	public int Tips2;

	/// <summary>
	/// 倒计时 - 心念特性
	/// </summary>
	[SerializableGameDataField]
	public int Tips3;

	/// <summary>
	/// 倒计时 - 剩余寿命
	/// </summary>
	public int Total => Tips1 + Tips2 + Tips3;

	/// <summary>
	/// 精纯与心念用完的情况
	/// </summary>
	/// <param name="total"></param>
	public DarkAshCounter(int expiredDate, int currDate)
	{
		Tips1 = Math.Max(expiredDate - currDate, 0);
		Tips2 = (Tips3 = 0);
	}

	/// <summary>
	/// 仍有精纯和心念的情况
	/// </summary>
	/// <param name="total"></param>
	/// <param name="data"></param>
	public DarkAshCounter(int expiredDate, int currDate, DarkAshCounterData data)
	{
		Tips3 = Math.Max(data.ExpiredDate3 - currDate, 0);
		Tips2 = Math.Max(data.ExpiredDate2 - currDate - Tips3, 0);
		Tips1 = Math.Max(expiredDate - currDate - Tips2 - Tips3, 0);
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = Tips1;
		byte* num = pData + 4;
		*(int*)num = Tips2;
		byte* num2 = num + 4;
		*(int*)num2 = Tips3;
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
		Tips1 = *(int*)pCurrData;
		pCurrData += 4;
		Tips2 = *(int*)pCurrData;
		pCurrData += 4;
		Tips3 = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
