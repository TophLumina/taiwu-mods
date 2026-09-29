using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class CharacterDisplayDataForYuanshanSelect : ISerializableGameData
{
	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList GeneralData;

	[SerializableGameDataField]
	public byte Infection;

	public CharacterDisplayDataForYuanshanSelect()
	{
	}

	public CharacterDisplayDataForYuanshanSelect(CharacterDisplayDataForYuanshanSelect other)
	{
		GeneralData = new CharacterDisplayDataForGeneralScrollList(other.GeneralData);
		Infection = other.Infection;
	}

	public void Assign(CharacterDisplayDataForYuanshanSelect other)
	{
		GeneralData = new CharacterDisplayDataForGeneralScrollList(other.GeneralData);
		Infection = other.Infection;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 1;
		totalSize = ((GeneralData == null) ? (totalSize + 2) : (totalSize + (2 + GeneralData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (GeneralData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = GeneralData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = Infection;
		pCurrData++;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			GeneralData = new CharacterDisplayDataForGeneralScrollList();
			pCurrData += GeneralData.Deserialize(pCurrData);
		}
		else
		{
			GeneralData = null;
		}
		Infection = *pCurrData;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
