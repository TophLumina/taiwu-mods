using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public struct TeammateCommandDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public bool IsAlly;

	[SerializableGameDataField]
	public sbyte IndexCharacter;

	[SerializableGameDataField]
	public sbyte ValidIndexCharacter;

	[SerializableGameDataField]
	public sbyte IndexCommand;

	[SerializableGameDataField]
	public sbyte CmdType;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (IsAlly ? ((byte)1) : ((byte)0));
		byte* num = pData + 1;
		*num = (byte)IndexCharacter;
		byte* num2 = num + 1;
		*num2 = (byte)ValidIndexCharacter;
		byte* num3 = num2 + 1;
		*num3 = (byte)IndexCommand;
		byte* num4 = num3 + 1;
		*num4 = (byte)CmdType;
		int totalSize = (int)(num4 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		IsAlly = *pCurrData != 0;
		pCurrData++;
		IndexCharacter = (sbyte)(*pCurrData);
		pCurrData++;
		ValidIndexCharacter = (sbyte)(*pCurrData);
		pCurrData++;
		IndexCommand = (sbyte)(*pCurrData);
		pCurrData++;
		CmdType = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
