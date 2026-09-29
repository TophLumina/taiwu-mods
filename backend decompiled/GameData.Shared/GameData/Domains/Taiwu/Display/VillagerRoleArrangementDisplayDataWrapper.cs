using GameData.Domains.Taiwu.Display.VillagerRoleArrangement;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Display;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class VillagerRoleArrangementDisplayDataWrapper : ISerializableGameData
{
	[SerializableGameDataField]
	public int ArrangementTemplateId = -1;

	[SerializableGameDataField]
	public short AreaId = -1;

	[SerializableGameDataField]
	public int ArrangementDataId = -1;

	[SerializableGameDataField]
	public IVillagerRoleArrangementDisplayData ArrangementData;

	private static IVillagerRoleArrangementDisplayData CreateRealArrangementData(int arrangementTemplateId)
	{
		switch (arrangementTemplateId)
		{
		case 6:
			return new HealingDisplayData();
		case 8:
			return new PeddlingDisplayData();
		case 11:
			return new EntertainingDisplayData();
		case 13:
			return new GuardingSwordTombDisplayData();
		case 15:
			return new TaiwuEnvoyDisplayData();
		case 1:
		case 2:
			return new FarmerDisplayData();
		default:
			return null;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		totalSize = ((ArrangementData == null) ? (totalSize + 2) : (totalSize + (2 + ArrangementData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = ArrangementTemplateId;
		pCurrData += 4;
		*(short*)pCurrData = AreaId;
		pCurrData += 2;
		*(int*)pCurrData = ArrangementDataId;
		pCurrData += 4;
		if (ArrangementData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ArrangementData.Serialize(pCurrData);
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
		ArrangementTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		AreaId = *(short*)pCurrData;
		pCurrData += 2;
		ArrangementDataId = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (ArrangementData == null)
			{
				ArrangementData = CreateRealArrangementData(ArrangementDataId);
			}
			pCurrData += ArrangementData.Deserialize(pCurrData);
		}
		else
		{
			ArrangementData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
