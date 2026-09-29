using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class CharacterDisplayDataForInfect : ISerializableGameData
{
	[SerializableGameDataField]
	public CharacterDisplayDataForTooltip DataForTooltip;

	[SerializableGameDataField]
	public byte Infection;

	[SerializableGameDataField]
	public bool IsTaiwu;

	[SerializableGameDataField]
	public bool IsTeammate;

	[SerializableGameDataField]
	public bool IsKidnapped;

	public int TempInfection;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((DataForTooltip == null) ? (totalSize + 2) : (totalSize + (2 + DataForTooltip.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (DataForTooltip != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = DataForTooltip.Serialize(pCurrData);
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
		*pCurrData = (IsTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsTeammate ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsKidnapped ? ((byte)1) : ((byte)0));
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
			DataForTooltip = new CharacterDisplayDataForTooltip();
			pCurrData += DataForTooltip.Deserialize(pCurrData);
		}
		else
		{
			DataForTooltip = null;
		}
		Infection = *pCurrData;
		pCurrData++;
		IsTaiwu = *pCurrData != 0;
		pCurrData++;
		IsTeammate = *pCurrData != 0;
		pCurrData++;
		IsKidnapped = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
