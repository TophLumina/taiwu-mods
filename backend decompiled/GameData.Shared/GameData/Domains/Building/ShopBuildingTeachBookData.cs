using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

[SerializableGameData]
public class ShopBuildingTeachBookData : ISerializableGameData
{
	/// <summary>
	/// 结果
	/// </summary>
	[SerializableGameDataField]
	public sbyte TeachBookResult;

	[SerializableGameDataField]
	public List<(short skillBookTemplateId, byte pageId, sbyte pageDirect)> TeachBookInfo;

	/// <summary>
	/// 主事能教多少书，不论学徒有没读过
	/// </summary>
	[SerializableGameDataField]
	public int LeaderCanTeachBookCount;

	/// <summary>
	/// 学徒已学多少书
	/// </summary>
	[SerializableGameDataField]
	public int MemberLearnedBookCount;

	/// <summary>
	/// 外部使用的默认创建
	/// </summary>
	/// <returns></returns>
	public static ShopBuildingTeachBookData CreateDefault()
	{
		return new ShopBuildingTeachBookData
		{
			TeachBookResult = 0,
			TeachBookInfo = new List<(short, byte, sbyte)>()
		};
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public ShopBuildingTeachBookData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public ShopBuildingTeachBookData(ShopBuildingTeachBookData other)
	{
		TeachBookResult = other.TeachBookResult;
		TeachBookInfo = ((other.TeachBookInfo == null) ? null : new List<(short, byte, sbyte)>(other.TeachBookInfo));
		LeaderCanTeachBookCount = other.LeaderCanTeachBookCount;
		MemberLearnedBookCount = other.MemberLearnedBookCount;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(ShopBuildingTeachBookData other)
	{
		TeachBookResult = other.TeachBookResult;
		TeachBookInfo = ((other.TeachBookInfo == null) ? null : new List<(short, byte, sbyte)>(other.TeachBookInfo));
		LeaderCanTeachBookCount = other.LeaderCanTeachBookCount;
		MemberLearnedBookCount = other.MemberLearnedBookCount;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (TeachBookInfo != null)
		{
			totalSize += 2;
			int elementsCount = TeachBookInfo.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				(short, byte, sbyte) element = TeachBookInfo[i];
				totalSize += SerializationHelper.GetSerializedSize(element);
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)TeachBookResult;
		pCurrData++;
		if (TeachBookInfo != null)
		{
			int elementsCount = TeachBookInfo.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				(short, byte, sbyte) element = TeachBookInfo[i];
				pCurrData += SerializationHelper.Serialize(pCurrData, element);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = LeaderCanTeachBookCount;
		pCurrData += 4;
		*(int*)pCurrData = MemberLearnedBookCount;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
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
		TeachBookResult = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (TeachBookInfo == null)
			{
				TeachBookInfo = new List<(short, byte, sbyte)>(elementsCount);
			}
			else
			{
				TeachBookInfo.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += SerializationHelper.Deserialize(pCurrData, out (short, byte, sbyte) tuple);
				TeachBookInfo.Add(tuple);
			}
		}
		else
		{
			TeachBookInfo?.Clear();
		}
		LeaderCanTeachBookCount = *(int*)pCurrData;
		pCurrData += 4;
		MemberLearnedBookCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
