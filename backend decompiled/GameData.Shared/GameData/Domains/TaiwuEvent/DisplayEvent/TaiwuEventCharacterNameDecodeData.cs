using GameData.Domains.Character.Display;
using GameData.Serializer;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 太吾事件占位符解析时用到的角色姓名解析数据
/// </summary>
public struct TaiwuEventCharacterNameDecodeData : ISerializableGameData
{
	/// <summary>
	/// 角色id
	/// </summary>
	[SerializableGameDataField]
	public int CharacterId;

	/// <summary>
	/// 角色姓名相关数据
	/// </summary>
	[SerializableGameDataField]
	public NameRelatedData NameRelatedData;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 36;
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
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		pCurrData += NameRelatedData.Serialize(pCurrData);
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
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += NameRelatedData.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
