using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Building;

/// <summary>
/// 建筑的异常数据集合
/// </summary>
public class BuildingExceptionData : ISerializableGameData
{
	/// <summary>
	/// 建筑异常信息的集合，每月计算
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<BuildingBlockKey, BuildingExceptionItem> BuildingExceptionDict = new Dictionary<BuildingBlockKey, BuildingExceptionItem>();

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public BuildingExceptionData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public BuildingExceptionData(BuildingExceptionData other)
	{
		if (other.BuildingExceptionDict != null)
		{
			Dictionary<BuildingBlockKey, BuildingExceptionItem> buildingExceptionDict = other.BuildingExceptionDict;
			int elementsCount = buildingExceptionDict.Count;
			BuildingExceptionDict = new Dictionary<BuildingBlockKey, BuildingExceptionItem>(elementsCount);
			{
				foreach (KeyValuePair<BuildingBlockKey, BuildingExceptionItem> pair in buildingExceptionDict)
				{
					BuildingExceptionDict.Add(pair.Key, new BuildingExceptionItem(pair.Value));
				}
				return;
			}
		}
		BuildingExceptionDict = null;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(BuildingExceptionData other)
	{
		if (other.BuildingExceptionDict != null)
		{
			Dictionary<BuildingBlockKey, BuildingExceptionItem> buildingExceptionDict = other.BuildingExceptionDict;
			int elementsCount = buildingExceptionDict.Count;
			BuildingExceptionDict = new Dictionary<BuildingBlockKey, BuildingExceptionItem>(elementsCount);
			{
				foreach (KeyValuePair<BuildingBlockKey, BuildingExceptionItem> pair in buildingExceptionDict)
				{
					BuildingExceptionDict.Add(pair.Key, new BuildingExceptionItem(pair.Value));
				}
				return;
			}
		}
		BuildingExceptionDict = null;
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
		totalSize += SerializationHelper.DictionaryOfCustomTypePair.GetSerializedSize(BuildingExceptionDict);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypePair.Serialize(pData, ref BuildingExceptionDict) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypePair.Deserialize(pData, ref BuildingExceptionDict) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
