using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public struct CharacterTableLocationData : ISerializableGameData
{
	[SerializableGameDataField]
	public short AreaId = -1;

	[SerializableGameDataField]
	public short BlockId = -1;

	[SerializableGameDataField]
	public sbyte BlockIndex = -1;

	[SerializableGameDataField]
	public sbyte StateTemplateId = -1;

	[SerializableGameDataField]
	public short AreaTemplateId = -1;

	[SerializableGameDataField]
	public short BlockTemplateId = -1;

	[SerializableGameDataField]
	public int AdventureCoreId = 0;

	[SerializableGameDataField]
	public bool IsCapturedInStoneRoom = false;

	[SerializableGameDataField]
	public int KidnapperId = -1;

	public CharacterTableLocationData()
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 19;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = AreaId;
		byte* num = pData + 2;
		*(short*)num = BlockId;
		byte* num2 = num + 2;
		*num2 = (byte)BlockIndex;
		byte* num3 = num2 + 1;
		*num3 = (byte)StateTemplateId;
		byte* num4 = num3 + 1;
		*(short*)num4 = AreaTemplateId;
		byte* num5 = num4 + 2;
		*(short*)num5 = BlockTemplateId;
		byte* num6 = num5 + 2;
		*(int*)num6 = AdventureCoreId;
		byte* num7 = num6 + 4;
		*num7 = (IsCapturedInStoneRoom ? ((byte)1) : ((byte)0));
		byte* num8 = num7 + 1;
		*(int*)num8 = KidnapperId;
		int totalSize = (int)(num8 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		AreaId = *(short*)pCurrData;
		pCurrData += 2;
		BlockId = *(short*)pCurrData;
		pCurrData += 2;
		BlockIndex = (sbyte)(*pCurrData);
		pCurrData++;
		StateTemplateId = (sbyte)(*pCurrData);
		pCurrData++;
		AreaTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		BlockTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		AdventureCoreId = *(int*)pCurrData;
		pCurrData += 4;
		IsCapturedInStoneRoom = *pCurrData != 0;
		pCurrData++;
		KidnapperId = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
