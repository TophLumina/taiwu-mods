using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true, NotForArchive = true)]
public class WugKingDriveDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public sbyte WugType;

	[SerializableGameDataField]
	public sbyte DriveType;

	[SerializableGameDataField]
	public int StartDate;

	[SerializableGameDataField]
	public bool CanDrive;

	[SerializableGameDataField]
	public bool IsInEatingSlot;

	[SerializableGameDataField]
	public ItemDisplayData ItemDisplayData;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize = ((ItemDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ItemDisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*pCurrData = (byte)WugType;
		pCurrData++;
		*pCurrData = (byte)DriveType;
		pCurrData++;
		*(int*)pCurrData = StartDate;
		pCurrData += 4;
		*pCurrData = (CanDrive ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsInEatingSlot ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (ItemDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ItemDisplayData.Serialize(pCurrData);
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
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		WugType = (sbyte)(*pCurrData);
		pCurrData++;
		DriveType = (sbyte)(*pCurrData);
		pCurrData++;
		StartDate = *(int*)pCurrData;
		pCurrData += 4;
		CanDrive = *pCurrData != 0;
		pCurrData++;
		IsInEatingSlot = *pCurrData != 0;
		pCurrData++;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (ItemDisplayData == null)
			{
				ItemDisplayData = new ItemDisplayData();
			}
			pCurrData += ItemDisplayData.Deserialize(pCurrData);
		}
		else
		{
			ItemDisplayData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
