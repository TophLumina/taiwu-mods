using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class CharacterDisplayDataForDirectSamsaraMother : ISerializableGameData
{
	[SerializableGameDataField]
	public FullBlockName FullBlockName;

	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList CharacterDisplayDataForGeneralScrollList;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += FullBlockName.GetSerializedSize();
		totalSize = ((CharacterDisplayDataForGeneralScrollList == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayDataForGeneralScrollList.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int fieldSize = FullBlockName.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		if (CharacterDisplayDataForGeneralScrollList != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize2 = CharacterDisplayDataForGeneralScrollList.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize2;
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

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += FullBlockName.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			CharacterDisplayDataForGeneralScrollList = new CharacterDisplayDataForGeneralScrollList();
			pCurrData += CharacterDisplayDataForGeneralScrollList.Deserialize(pCurrData);
		}
		else
		{
			CharacterDisplayDataForGeneralScrollList = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
