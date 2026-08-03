using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

/// <summary>
/// 建筑的异常内容
/// </summary>
public class BuildingExceptionItem : ISerializableGameData
{
	/// <summary>
	/// 异常列表
	/// </summary>
	[SerializableGameDataField]
	public List<sbyte> ExceptionTypeList = new List<sbyte>();

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public BuildingExceptionItem()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public BuildingExceptionItem(BuildingExceptionItem other)
	{
		ExceptionTypeList = ((other.ExceptionTypeList == null) ? null : new List<sbyte>(other.ExceptionTypeList));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(BuildingExceptionItem other)
	{
		ExceptionTypeList = ((other.ExceptionTypeList == null) ? null : new List<sbyte>(other.ExceptionTypeList));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((ExceptionTypeList == null) ? (totalSize + 2) : (totalSize + (2 + ExceptionTypeList.Count)));
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
		if (ExceptionTypeList != null)
		{
			int elementsCount = ExceptionTypeList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = (byte)ExceptionTypeList[i];
			}
			pCurrData += elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ExceptionTypeList == null)
			{
				ExceptionTypeList = new List<sbyte>(elementsCount);
			}
			else
			{
				ExceptionTypeList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ExceptionTypeList.Add((sbyte)pCurrData[i]);
			}
			pCurrData += (int)elementsCount;
		}
		else
		{
			ExceptionTypeList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
