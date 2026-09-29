using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(AllowFixedSize = false, NotForArchive = true, NoCopyConstructors = true)]
public struct NameAndAvatar : ISerializableGameData
{
	[SerializableGameDataField]
	public AvatarRelatedData Avatar;

	[SerializableGameDataField]
	public NameRelatedData Name;

	[SerializableGameDataField]
	public bool IsTaiwu;

	[SerializableGameDataField]
	public int CharId;

	public short CharTemplateId => Name.CharTemplateId;

	public bool IsAlive => Avatar != null;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 37;
		totalSize = ((Avatar == null) ? (totalSize + 2) : (totalSize + (2 + Avatar.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Avatar != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Avatar.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += Name.Serialize(pCurrData);
		*pCurrData = (IsTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
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
			Avatar = new AvatarRelatedData();
			pCurrData += Avatar.Deserialize(pCurrData);
		}
		else
		{
			Avatar = null;
		}
		pCurrData += Name.Deserialize(pCurrData);
		IsTaiwu = *pCurrData != 0;
		pCurrData++;
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
