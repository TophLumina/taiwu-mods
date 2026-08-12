using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public struct CharacterTableWorkData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte WorkType;

	[SerializableGameDataField]
	public byte WorkStatus;

	[SerializableGameDataField]
	public int ArrangementTemplateId;

	[SerializableGameDataField]
	public int IntValue;

	[SerializableGameDataField]
	public bool BoolValue;

	[SerializableGameDataField]
	public bool IsLeader;

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
		*pData = (byte)WorkType;
		byte* num = pData + 1;
		*num = WorkStatus;
		byte* num2 = num + 1;
		*(int*)num2 = ArrangementTemplateId;
		byte* num3 = num2 + 4;
		*(int*)num3 = IntValue;
		byte* num4 = num3 + 4;
		*num4 = (BoolValue ? ((byte)1) : ((byte)0));
		byte* num5 = num4 + 1;
		*num5 = (IsLeader ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num5 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		WorkType = (sbyte)(*pCurrData);
		pCurrData++;
		WorkStatus = *pCurrData;
		pCurrData++;
		ArrangementTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		IntValue = *(int*)pCurrData;
		pCurrData += 4;
		BoolValue = *pCurrData != 0;
		pCurrData++;
		IsLeader = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
