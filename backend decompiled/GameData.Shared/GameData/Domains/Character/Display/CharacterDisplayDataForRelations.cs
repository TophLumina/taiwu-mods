using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class CharacterDisplayDataForRelations : ISerializableGameData
{
	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList Main;

	[SerializableGameDataField]
	public sbyte LifeState;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public ushort RelationType;

	[SerializableGameDataField]
	public int DeathDate = -1;

	public int CharacterId => Main?.CharacterId ?? (-1);

	public CharacterDisplayDataForRelations()
	{
	}

	public CharacterDisplayDataForRelations(CharacterDisplayDataForRelations other)
	{
		Main = new CharacterDisplayDataForGeneralScrollList(other.Main);
		LifeState = other.LifeState;
		Location = other.Location;
		RelationType = other.RelationType;
		DeathDate = other.DeathDate;
	}

	public void Assign(CharacterDisplayDataForRelations other)
	{
		Main = new CharacterDisplayDataForGeneralScrollList(other.Main);
		LifeState = other.LifeState;
		Location = other.Location;
		RelationType = other.RelationType;
		DeathDate = other.DeathDate;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		totalSize = ((Main == null) ? (totalSize + 2) : (totalSize + (2 + Main.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Main != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Main.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)LifeState;
		pCurrData++;
		pCurrData += Location.Serialize(pCurrData);
		*(ushort*)pCurrData = RelationType;
		pCurrData += 2;
		*(int*)pCurrData = DeathDate;
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
			Main = new CharacterDisplayDataForGeneralScrollList();
			pCurrData += Main.Deserialize(pCurrData);
		}
		else
		{
			Main = null;
		}
		LifeState = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += Location.Deserialize(pCurrData);
		RelationType = *(ushort*)pCurrData;
		pCurrData += 2;
		DeathDate = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
