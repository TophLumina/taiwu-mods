using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true, NotForArchive = true, NoCopyConstructors = true)]
public class CharacterLocationDisplayData : ISerializableGameData
{
	public enum EDisplayType
	{
		Normal,
		Kidnapped,
		InAdventure,
		Buried
	}

	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public sbyte DisplayType;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public FullBlockName FullBlockName;

	[SerializableGameDataField]
	public MapBlockData BlockData;

	[SerializableGameDataField]
	public MapBlockData RootBlockData;

	[SerializableGameDataField]
	public int AdventureCoreId;

	[SerializableGameDataField]
	public CharacterDisplayData Kidnapper;

	[SerializableGameDataField]
	public bool IsCapturedInStoneRoom;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 14;
		totalSize += FullBlockName.GetSerializedSize();
		totalSize = ((BlockData == null) ? (totalSize + 2) : (totalSize + (2 + BlockData.GetSerializedSize())));
		totalSize = ((RootBlockData == null) ? (totalSize + 2) : (totalSize + (2 + RootBlockData.GetSerializedSize())));
		totalSize = ((Kidnapper == null) ? (totalSize + 2) : (totalSize + (2 + Kidnapper.GetSerializedSize())));
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
		*pCurrData = (byte)DisplayType;
		pCurrData++;
		pCurrData += Location.Serialize(pCurrData);
		int fieldSize = FullBlockName.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		if (BlockData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize2 = BlockData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RootBlockData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = RootBlockData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = AdventureCoreId;
		pCurrData += 4;
		if (Kidnapper != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = Kidnapper.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsCapturedInStoneRoom ? ((byte)1) : ((byte)0));
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
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		DisplayType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += Location.Deserialize(pCurrData);
		pCurrData += FullBlockName.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			BlockData = new MapBlockData();
			pCurrData += BlockData.Deserialize(pCurrData);
		}
		else
		{
			BlockData = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			RootBlockData = new MapBlockData();
			pCurrData += RootBlockData.Deserialize(pCurrData);
		}
		else
		{
			RootBlockData = null;
		}
		AdventureCoreId = *(int*)pCurrData;
		pCurrData += 4;
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			Kidnapper = new CharacterDisplayData();
			pCurrData += Kidnapper.Deserialize(pCurrData);
		}
		else
		{
			Kidnapper = null;
		}
		IsCapturedInStoneRoom = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
