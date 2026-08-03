using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.DLC.FiveLoong;

/// <summary>
/// 神龙位置相关数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct LoongLocationData : ISerializableGameData
{
	/// <summary>
	/// 神龙角色模板
	/// </summary>
	[SerializableGameDataField]
	public int TemplateId;

	/// <summary>
	/// 神龙角色位置
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 基于神龙信息构建本数据结构
	/// </summary>
	public LoongLocationData(LoongInfo loongInfo)
	{
		TemplateId = loongInfo.CharacterTemplateId;
		Location = loongInfo.LoongCurrentLocation;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 8;
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
		*(int*)pCurrData = TemplateId;
		pCurrData += 4;
		pCurrData += Location.Serialize(pCurrData);
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
		TemplateId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Location.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
