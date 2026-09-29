using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class CharacterDisplayDataForLifeLink : ISerializableGameData
{
	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList ListData;

	[SerializableGameDataField]
	public sbyte NeiliType;

	[SerializableGameDataField]
	public sbyte HealthType;

	[SerializableGameDataField]
	public NeiliProportionOfFiveElements NeiliPercent;

	[SerializableGameDataField]
	public bool IsTeammate;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		totalSize = ((ListData == null) ? (totalSize + 2) : (totalSize + (2 + ListData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (ListData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ListData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)NeiliType;
		pCurrData++;
		*pCurrData = (byte)HealthType;
		pCurrData++;
		pCurrData += NeiliPercent.Serialize(pCurrData);
		*pCurrData = (IsTeammate ? ((byte)1) : ((byte)0));
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
			ListData = new CharacterDisplayDataForGeneralScrollList();
			pCurrData += ListData.Deserialize(pCurrData);
		}
		else
		{
			ListData = null;
		}
		NeiliType = (sbyte)(*pCurrData);
		pCurrData++;
		HealthType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += NeiliPercent.Deserialize(pCurrData);
		IsTeammate = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
