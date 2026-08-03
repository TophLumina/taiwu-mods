using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 人物列表所需的数据，包含人物显示数据和秘闻数量数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true)]
public class CharacterDisplayDataWithInfo : ISerializableGameData
{
	/// <summary>
	/// 人物显示数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData CharacterDisplayData;

	/// <summary>
	/// 秘闻数量数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterInfoCountData CharacterInfoCountData;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize = ((CharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayData.GetSerializedSize())));
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
		if (CharacterDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += CharacterInfoCountData.Serialize(pCurrData);
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (CharacterDisplayData == null)
			{
				CharacterDisplayData = new CharacterDisplayData();
			}
			pCurrData += CharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			CharacterDisplayData = null;
		}
		if (CharacterInfoCountData == null)
		{
			CharacterInfoCountData = new CharacterInfoCountData();
		}
		pCurrData += CharacterInfoCountData.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
