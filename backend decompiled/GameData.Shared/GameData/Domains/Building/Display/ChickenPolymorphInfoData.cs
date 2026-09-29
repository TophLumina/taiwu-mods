using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building.Display;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class ChickenPolymorphInfoData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte PersonalityType;

	[SerializableGameDataField]
	public bool IsPolymorph;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public CharacterDisplayData CharacterDisplayData;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((CharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)PersonalityType;
		pCurrData++;
		*pCurrData = (IsPolymorph ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)Gender;
		pCurrData++;
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
		PersonalityType = (sbyte)(*pCurrData);
		pCurrData++;
		IsPolymorph = *pCurrData != 0;
		pCurrData++;
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			CharacterDisplayData = new CharacterDisplayData();
			pCurrData += CharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			CharacterDisplayData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
